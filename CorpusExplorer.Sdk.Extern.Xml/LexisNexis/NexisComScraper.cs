using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;
using HtmlAgilityPack;

namespace CorpusExplorer.Sdk.Extern.Xml.LexisNexis
{
  public class NexisComScraper : AbstractScraper
  {
    public override string DisplayName => "nexis.com - Nachrichten (bis 2020)";

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      var res = new List<Dictionary<string, object>>();
      var sections = GetDocumentSections(file);
      var l = new object();

      Parallel.ForEach(sections, section =>
      {
        try
        {
          var lines = section?.Split(new[] { "<br>" }, StringSplitOptions.RemoveEmptyEntries);
          if (lines == null || lines.Length < 1)
            return;

          var i = 0;
          for (; i < lines.Length; i++)
            if (lines[i].StartsWith("<p class=\"c1\">")) // Finde Einsprungspunkt
              break;

          var verlag = GetText(lines[++i]);
          var datum = GetText(lines[++i]);
          var titel = GetText(lines[++i]);
          i++;
          for (; i < lines.Length; i++)
          {
            if (lines[i].StartsWith("<div"))
              break;
            titel = $"{titel} {GetText(lines[i])}";
          }

          titel = titel.Trim();
          if (titel.StartsWith("LÄNGE:")) // Kein Titel Fix
          {
            titel = "";
            i--;
          }

          string autor = string.Empty, rubrik = string.Empty, type = string.Empty;
          var start = 0;
          var stop = 0;

          for (; i < lines.Length; i++)
          {
            var test = GetText(lines[i]);
            if (test.StartsWith("AUTOR:"))
              autor = test.Replace("AUTOR:", "").Trim();
            if (test.StartsWith("RUBRIK:"))
              rubrik = test.Replace("RUBRIK:", "").Trim();
            if (test.StartsWith("UPDATE:") && string.IsNullOrEmpty(datum))
              datum = test.Replace("UPDATE:", "").Trim();
            if (test.StartsWith("PUBLICATION-TYPE:"))
              type = test.Replace("PUBLICATION-TYPE:", "").Trim();
            if (test.StartsWith("LÄNGE:"))
              start = i + 1;
            if (!test.StartsWith("UPDATE:"))
              continue;
            stop = i;
            if (string.IsNullOrEmpty(datum))
              datum = test.Replace("UPDATE:", "").Trim();
          }

          if (stop == 0)
            return;

          var stb = new StringBuilder();
          for (i = start; i < stop; i++)
          {
            var line = GetText(lines[i]);
            if (line.StartsWith("HIGHLIGHT:"))
            {
              var c = i;
              for (; i < lines.Length; i++)
              {
                if (lines[i].StartsWith("<div"))
                  break;
              }

              if (c + 1 == i)
                continue;

              i--;
              continue;
            }

            if (!string.IsNullOrEmpty(autor))
            {
              if (line.StartsWith($"Von {autor}"))
                line = line.Replace($"Von {autor}", "");
              if (line.StartsWith($"Von: {autor}"))
                line = line.Replace($"Von: {autor}", "");
              if (line.StartsWith($"von {autor}"))
                line = line.Replace($"von {autor}", "");
              if (line.StartsWith($"von: {autor}"))
                line = line.Replace($"von: {autor}", "");
              if (line.StartsWith(autor))
                line = line.Replace(autor, "");
            }

            stb.AppendLine(line.Trim());
          }

          var text = stb.ToString().Trim();

          lock (l)
            res.Add(
                    new Dictionary<string, object>
                    {
                    {"Text", text},
                    {"Titel", titel},
                    {"Autor", autor},
                    {"Rubrik", rubrik},
                    {"Publikation", type},
                    {"Zeitung", verlag},
                    {"Datum", DateTimeHelper.Parse(datum, true)}
                    });
        }
        catch
        {
          // ignore
        }
      });

      return res;
    }

    private static IEnumerable<string> GetDocumentSections(string file)
    {
      var html = new HtmlDocument();
      using (var fs = new FileStream(file, FileMode.Open, FileAccess.Read))
      using (var bs = new BufferedStream(fs))
      {
        html.Load(bs, Configuration.Encoding);
      }

      var body = html.DocumentNode.SelectSingleNode("//body");
      var cont = body.InnerHtml.Split(Splitter.LineBreaks, StringSplitOptions.RemoveEmptyEntries);
      var stb = new StringBuilder();

      foreach (var s in cont)
      {
        if (s.StartsWith("<DOC NUMBER=") || s.StartsWith("<DOCFULL> -->") || s.StartsWith("</DOCFULL>") ||
            s.StartsWith("</DOC> -->"))
          continue;
        stb.AppendLine(s);
      }

      stb.Replace("&Auml;", "Ä");
      stb.Replace("&auml;", "ä");
      stb.Replace("&Ouml;", "Ö");
      stb.Replace("&ouml;", "ö");
      stb.Replace("&Uuml;", "Ü");
      stb.Replace("&uuml;", "ü");
      stb.Replace("&szlig;", "ß");

      var sections = stb.ToString()
        .Split(new[] { "<!-- Hide XML section from browser" }, StringSplitOptions.RemoveEmptyEntries);
      return sections.Where(x => x.Length > 70);
    }

    private static string GetText(string html)
    {
      var doc = new HtmlDocument();
      using (var ms = new MemoryStream(Configuration.Encoding.GetBytes(html)))
        doc.Load(ms, Configuration.Encoding);
      return doc.DocumentNode?.InnerText?.Trim() ?? string.Empty;
    }
  }
}