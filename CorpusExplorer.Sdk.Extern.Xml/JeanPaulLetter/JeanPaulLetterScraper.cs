using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper;
using CorpusExplorer.Sdk.Extern.Xml.JeanPaulLetter.Extension;
using CorpusExplorer.Sdk.Extern.Xml.JeanPaulLetter.Model;
using CorpusExplorer.Sdk.Extern.Xml.JeanPaulLetter.Serializer;
using HtmlAgilityPack;

namespace CorpusExplorer.Sdk.Extern.Xml.JeanPaulLetter
{
  public class JeanPaulLetterScraper : AbstractGenericXmlSerializerFormatScraper<TEI>
  {
    private const string JoinMark = " | ";
    public override string DisplayName => "Jean Paul Edition";
    protected override AbstractGenericSerializer<TEI> Serializer => new JeanPaulLetterSerializer();

    protected override IEnumerable<Dictionary<string, object>> ScrapDocuments(string file, TEI model)
    {
      var text = GetText(file);
      if (string.IsNullOrEmpty(text))
        return null;

      var titlePrint = SafeJoin(() =>
        model?.teiHeader?.fileDesc?.titleStmt?.title?.FirstOrDefault(x => x.n == "print")?.Text);
      var titleDigit = SafeJoin(() =>
        model?.teiHeader?.fileDesc?.titleStmt?.title?.FirstOrDefault(x => x.n == "digital")?.Text);

      return new[]
      {
        new Dictionary<string, object>
        {
          {"Titel", string.IsNullOrEmpty(titleDigit) ? titlePrint : titleDigit},
          {"Titel (Druck)", titlePrint},
          {"Titel (Digital)", titleDigit},
          {"URLWeb",SafeJoin(() =>model?.teiHeader?.fileDesc?.publicationStmt?.idno?.idno1?.FirstOrDefault(x => x.type == "URLWeb")?.Text)},
          {"URLXML",SafeJoin(() =>model?.teiHeader?.fileDesc?.publicationStmt?.idno?.idno1?.FirstOrDefault(x => x.type == "URLXML")?.Text)},
          {"TELOTAID",SafeJoin(() =>model?.teiHeader?.fileDesc?.publicationStmt?.idno?.idno1?.FirstOrDefault(x => x.type == "TELOTAID")?.Text)},
          {"Quelle", SafeJoin(() => model?.teiHeader?.fileDesc?.sourceDesc?.bibl?.title?.Text)},{"Band", model?.teiHeader?.fileDesc?.sourceDesc?.bibl?.title?.n},
          {"Seite (von)",GetPageNumber(model?.teiHeader?.fileDesc?.sourceDesc?.bibl?.biblScope?.FirstOrDefault(x => x.n == "text")?.num, 0)},
          {"Seite (bis)",GetPageNumber(model?.teiHeader?.fileDesc?.sourceDesc?.bibl?.biblScope?.FirstOrDefault(x => x.n == "text")?.num, 1)},
          {"Autor",GetPersonName(model?.teiHeader?.profileDesc?.correspDesc?.correspAction?.Where(x => x.type == "sent").SelectMany(x => x.persName))},
          {"Datum",GetSendDate(model?.teiHeader?.profileDesc?.correspDesc?.correspAction?.Where(x => x.type == "sent").SelectMany(x => x.date))},
          {"Ort",GetSendLocation(model?.teiHeader?.profileDesc?.correspDesc?.correspAction?.Where(x => x.type == "sent").SelectMany(x => x.PlaceNames()))},
          {"Empfänger",GetPersonName(model?.teiHeader?.profileDesc?.correspDesc?.correspAction?.Where(x => x.type == "received").SelectMany(x => x.persName))},
          {"Brief (nächster)",GetPreviewLetters(model?.teiHeader?.profileDesc?.correspDesc?.correspContext?.Where(x => x.type == "next"))},
          {"Brief (vorheriger)",GetPreviewLetters(model?.teiHeader?.profileDesc?.correspDesc?.correspContext?.Where(x => x.type == "prev"))},
          {"Text", text}
        }
      };
    }

    private void DetectDate(DateTime current, ref DateTime res)
    {
      try
      {
        if (current > DateTime.MinValue && current < res)
          res = current;
      }
      catch
      {
        // ignore
      }
    }

    private int GetPageNumber(string[] num, int index)
    {
      try
      {
        if (num == null || index < 0 || index >= num.Length)
          return -1;

        return int.Parse(num[index]);
      }
      catch
      {
        return -1;
      }
    }

    private string GetPersonName(IEnumerable<persName> persNames)
    {
      try
      {
        var names = new List<string>();
        foreach (var n in persNames)
        {
          var name = $"{SafeJoin(() => n.Text)} {n.Name()}";
          if (name.StartsWith(", "))
            name = name.Substring(2);
          names.Add(name);
        }

        return SafeClean(string.Join(JoinMark, names.OrderBy(x => x)));
      }
      catch
      {
        return "";
      }
    }

    private string GetPreviewLetters(IEnumerable<@ref> refs)
    {
      try
      {
        return SafeClean(string.Join(JoinMark, refs.Select(r => r.target)));
      }
      catch
      {
        return "";
      }
    }

    private DateTime GetSendDate(IEnumerable<date> dates)
    {
      if (dates == null)
        return DateTime.MinValue;

      var res = DateTime.MaxValue;
      try
      {
        foreach (var d in dates)
        {
          try
          {
            DetectDate(d.from, ref res);
          }
          catch
          {
            /**/
          }

          try
          {
            DetectDate(d.to, ref res);
          }
          catch
          {
            /**/
          }

          try
          {
            DetectDate(d.when, ref res);
          }
          catch
          {
            /**/
          }

          try
          {
            DetectDate(d.notAfter, ref res);
          }
          catch
          {
            /**/
          }

          try
          {
            DetectDate(d.notBefore, ref res);
          }
          catch
          {
            /**/
          }
        }
      }
      catch
      {
        /**/
      }

      return res;
    }

    private string GetSendLocation(IEnumerable<placeName> places)
    {
      try
      {
        return SafeClean(string.Join(JoinMark, places.Select(p => p.@ref)));
      }
      catch
      {
        return "";
      }
    }

    private string GetText(string file)
    {
      try
      {
        var doc = new HtmlDocument();
        using (var fs = new FileStream(file, FileMode.Open, FileAccess.Read))
        {
          doc.Load(fs, Encoding.UTF8);
        }

        var body = doc.DocumentNode.SelectNodes("//body").FirstOrDefault();
        if (body == null)
          return string.Empty;

        var remove = new[]
        {
          "//note",
          "//lb",
          "//dateline"
        };

        foreach (var x in remove)
          RemoveNodes(ref doc, x);

        return SafeClean(body.InnerText.Replace("↩", "").Replace("„", "\"").Replace("“", "\""));
      }
      catch
      {
        return string.Empty;
      }
    }

    private static void RemoveNodes(ref HtmlDocument doc, string xpath)
    {
      try
      {
        var nodes = doc.DocumentNode.SelectNodes(xpath);
        if (nodes == null) return;
        foreach (var node in nodes)
          node.Remove();
      }
      catch
      {
        // ignore
      }
    }

    private string SafeJoin(Func<IEnumerable<string>> call, string separator = " ")
    {
      try
      {
        return SafeClean(string.Join(separator, call()));
      }
      catch
      {
        return "";
      }
    }

    private string SafeClean(string text)
    {
      try
      {
        return text.Trim()
          .Replace("\r\n", " ")
          .Replace("\r", " ")
          .Replace("\n", " ")
          .Replace("  ", " ")
          .Replace("  ", " ")
          .Replace("  ", " ")
          .Replace("  ", " ")
          .Replace("  ", " ");
      }
      catch
      {
        return text;
      }
    }
  }
}