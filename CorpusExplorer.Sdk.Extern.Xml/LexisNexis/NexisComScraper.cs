using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;
using HtmlAgilityPack;

namespace CorpusExplorer.Sdk.Extern.Xml.LexisNexis
{
  public class NexisComScraper : AbstractScraper
  {
    public override string DisplayName => "nexis.com - Nachrichten";

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      var res = new List<Dictionary<string, object>>();
      var sections = GetDocumentSections(file);

      foreach (var section in sections)
      {
        var lines = section.Split(new[] { "<br>" }, StringSplitOptions.RemoveEmptyEntries);
        if (lines.Length < 8)
          continue;

        var verlag = GetText(lines[4]);
        var datum = DateTimeHelper.Parse(GetText(lines[5]), true);
        var titel = GetText(lines[6]);
        var i = 7;
        for (; i < lines.Length; i++)
        {
          if (lines[i].StartsWith("<div"))
            break;
          titel = $"{titel} {GetText(lines[i])}";
        }

        titel = titel.Trim();

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
          if (test.StartsWith("LÄNGE:"))
            start = i + 1;
          if (test.StartsWith("UPDATE:"))
            stop = i;
          if (test.StartsWith("PUBLICATION-TYPE:"))
            type = test.Replace("PUBLICATION-TYPE:", "").Trim();
        }

        if (stop == 0)
          continue;
        var testAuthor = !string.IsNullOrEmpty(autor);
        var vonAutor = $"Von {autor}";

        var stb = new StringBuilder();
        for (i = start; i < stop; i++)
        {
          var line = GetText(lines[i]);
          if (line.StartsWith("HIGHLIGHT:"))
          {
            for (; i < lines.Length; i++)
              if (lines[i].StartsWith("<div"))
                break;
            continue;
          }

          if (testAuthor)
          {
            if (line.StartsWith(vonAutor))
              line = line.Replace(vonAutor, "");
            if (line.StartsWith(autor))
              line = line.Replace(autor, "");
          }

          stb.AppendLine(line.Trim());
        }

        var text = stb.ToString().Trim();

        res.Add(
          new Dictionary<string, object>
          {
            {"Text", text},
            {"Titel", titel},
            {"Autor", autor},
            {"Rubrik", rubrik},
            {"Publikation", type},
            {"Zeitung", verlag},
            {"Datum", datum}
          });
      }

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
      var cont = body.InnerHtml.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
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