using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using CorpusExplorer.Sdk.Diagnostic;
using CorpusExplorer.Sdk.Extern.TextSharp.PDF;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;

namespace CorpusExplorer.Sdk.Extern.TextSharp.APAEK
{
  public class ApaekScraper : AbstractScraper
  {
    public override string DisplayName => "APAEK";

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      var regexNum = new Regex(@"[0-9]$");
      var scraper = new TextSharpPdfScraper { Strategy = TextSharpPdfScraper.TextSharpPdfScraperStrategy.Simple };
      scraper.Input.Enqueue(file);
      scraper.Execute();
      var pdf = scraper.Output.FirstOrDefault();
      if (pdf == null)
        return null;

      var lines = ((string)pdf["Text"]).Split(Splitter.LineBreaks, StringSplitOptions.RemoveEmptyEntries);

      // META
      var meta = new Dictionary<string, object>();
      string fach = "",
             stundenthema = "",
             datum = "",
             schulform = "",
             teilnehmer = "",
             projektkontext = "",
             transkribiertVon = "",
             korrigiertDurch = "";

      var i = 0;
      for (; i < lines.Length; i++)
      {
        var line = lines[i];
        if (string.IsNullOrWhiteSpace(line))
          continue;

        if (line.StartsWith("Fach:"))
          fach = line.Replace("Fach:", "").Trim();
        if (line.StartsWith("Stundenthema:"))
        {
          stundenthema = line.Replace("Stundenthema:", "").Trim();
          while (i + 1 < lines.Length && !string.IsNullOrWhiteSpace(lines[i + 1]))
          {
            i++;
            stundenthema += $" {lines[i]}";
          }

          continue;
        }

        if (line.StartsWith("Datum der Aufnahme:"))
          datum = line.Replace("Datum der Aufnahme:", "").Trim();
        if (line.StartsWith("Schulform:"))
          schulform = line.Replace("Schulform:", "").Trim();
        if (line.StartsWith("Liste der Teilnehmer:"))
          teilnehmer = line.Replace("Liste der Teilnehmer:", "").Trim();
        if (line.StartsWith("Projektkontext:"))
          projektkontext = line.Replace("Projektkontext:", "").Trim();
        if (line.StartsWith("transkribiert durch:"))
          transkribiertVon = line.Replace("transkribiert durch:", "").Trim();
        if (line.StartsWith("korrigiert durch:"))
          korrigiertDurch = line.Replace("korrigiert durch:", "").Trim();

        if (line.StartsWith("Datum der Korrektur:"))
        {
          meta.Add("Datei", Path.GetFileName(file));
          meta.Add("Fach", fach);
          meta.Add("Stundenthema", stundenthema);
          meta.Add("Datum (Original)", datum);
          meta.Add("Datum", DateTimeHelper.Parse(datum, "dd.MM.yyyy"));
          meta.Add("Schulform", schulform);
          meta.Add("Teilnehmer", teilnehmer);
          meta.Add("Projektkontext", projektkontext);
          meta.Add("transkribiert durch", transkribiertVon);
          meta.Add("korrigiert durch", korrigiertDurch);

          break;
        }
      }

      i++;

      // Parse Text
      var res = new List<Dictionary<string, object>>();
      var speaker = "";
      var stb = new StringBuilder();
      var id = 0;

      for (; i < lines.Length; i++)
        try
        {
          if (string.IsNullOrWhiteSpace(lines[i]))
            continue;

          // Entferne: - = < > [ ]
          var line = lines[i]
                    .Replace("-", "")
                    .Replace("–", "")
                    .Replace("=", "")
                    .Replace("<", "[")
                    .Replace(">", "]")
                    //.Replace("[", "")
                    //.Replace("]", "")
                    .Trim();

          while (regexNum.IsMatch(line))
            line = line.Substring(0, line.Length - 1);

          line = line.Trim();
          if (line.ToUpper().StartsWith("APAEK") || line.ToUpper().StartsWith("URL"))
            continue;
          if (line.ToLower().StartsWith("zusätzliche informationen:"))
            break;

          if (line.Length > 2
           && (line[0] == 'L' || line[0] == 'S' || line[0] == 'K' || line.ToLower().StartsWith("all:") ||
               line.ToLower().StartsWith("alle:"))
           && line.Substring(1, 7 > line.Length ? line.Length - 1 : 7).Contains(':'))
          {
            // Abschluss
            if (speaker != "")
              NewEntry(ref meta, ref speaker, ref stb, ref res, ref id);

            // Neu erstellen
            speaker = line.Substring(0, 8).Split(Splitter.Colon, StringSplitOptions.RemoveEmptyEntries)[0].Trim();
            stb = new StringBuilder();
            stb.AppendLine(line.Replace($"{speaker}:", "").Trim());

            if (speaker.Length < 2) continue;

            // Speaker - Korrektur Geschlecht
            var g = speaker[1].ToString().ToLower()[0]; // gender
            speaker = $"{speaker[0]}{g}{(speaker.Length > 2 ? speaker.Substring(2) : "")}";
          }
          else
          {
            stb.AppendLine(line);
          }
        }
        catch (Exception ex)
        {
          InMemoryErrorConsole.Log(ex);
        }

      NewEntry(ref meta, ref speaker, ref stb, ref res, ref id);

      return res;
    }

    private string Clean(string content)
    {
      while (content.Contains("{"))
      {
        var start = content.IndexOf("{");
        var stop = content.IndexOf("}");
        if (stop < start)
          break;
        content = content.Substring(0, start) + content.Substring(stop + 1);
      }

      while (content.Contains("("))
      {
        var start = content.IndexOf("(");
        var stop = content.IndexOf(")");
        if (stop < start)
          break;
        content = content.Substring(0, start) + content.Substring(stop + 1);
      }

      return content.Replace("  ", " ").Replace("...", ".").Replace("…", ".").Replace("„", "\"").Replace("“", "\"");
    }

    private void NewEntry(ref Dictionary<string, object> meta, ref string speaker, ref StringBuilder content,
      ref List<Dictionary<string, object>> res, ref int id)
    {
      var text = Clean(content.ToString());
      content.Clear();
      speaker = "";

      if (string.IsNullOrWhiteSpace(text))
        return;

      var dic = meta.ToDictionary(x => x.Key, x => x.Value);
      dic.Add("Sprecher", speaker);
      dic.Add("Text", text);
      dic.Add("Äußerung", ++id);

      res.Add(dic);
    }
  }
}