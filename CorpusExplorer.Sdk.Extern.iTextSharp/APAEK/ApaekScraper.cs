using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
      var scraper = new TextSharpPdfScraper { Strategy = TextSharpPdfScraper.TextSharpPdfScraperStrategy.Simple };
      scraper.Input.Enqueue(file);
      scraper.Execute();
      var pdf = scraper.Output.FirstOrDefault();
      if (pdf == null)
        return null;

      var lines = ((string)pdf["Text"]).Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

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
      bool b1 = false, b2 = false;
      var id = 0;

      for (; i < lines.Length; i++)
      {
        try
        {
          if (string.IsNullOrWhiteSpace(lines[i]) ||
              lines[i].StartsWith("APAEK - Archiv für") ||
              lines[i].StartsWith("URL des Datensatzes"))
            continue;

          // Substring(0, lines[i].LastIndexOf(" ")) - entfernt nachgestellte Zeilennummern
          // Entferne: - = < > [ ]
          var idx = lines[i].Trim().LastIndexOf(" ");
          if (idx < 1)
            continue;
          var line = lines[i]
            .Substring(0, idx)
            .Replace("-", "")
            .Replace("–", "")
            .Replace("=", "")
            .Replace("<", "")
            .Replace(">", "")
            .Replace("[", "")
            .Replace("]", "")
            .Trim();
          if ((line.StartsWith("L") || line.StartsWith("S")) &&
              line.Length > 5 &&
              (line[2] == ':' || line[3] == ':' || line[4] == ':'))
          {
            // Abschluss
            if (speaker != "")
              NewEntry(ref meta, speaker, stb.ToString(), ref res, ref id);

            // Neu erstellen
            speaker = line.Substring(0, 5).Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)[0]
                          .Replace(":", "")
                          .Trim();
            stb = new StringBuilder();
            stb.AppendLine(line.Replace($"{speaker}:", "").Trim());
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
      }
      NewEntry(ref meta, speaker, stb.ToString(), ref res, ref id);

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

    private void NewEntry(ref Dictionary<string, object> meta, string speaker, string content, ref List<Dictionary<string, object>> res, ref int id)
    {
      var text = Clean(content);
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
