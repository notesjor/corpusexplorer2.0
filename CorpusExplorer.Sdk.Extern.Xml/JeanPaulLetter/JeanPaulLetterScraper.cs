using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper;
using CorpusExplorer.Sdk.Extern.Xml.Helper;
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
      var helper = new HtmlAgilityPackHelper(file);
      helper.RemoveNodes(new[] { "//note", "//lb", "//dateline" });

      var text = helper.GetBodyText("//body")?.Replace("↩", "").Replace("„", "\"").Replace("“", "\"");
      if (string.IsNullOrEmpty(text))
        return null;
      text = TextHelper.RemoveMultiSpacesAndLinebreaks(text);

      var titlePrint = TextHelper.SafeJoin(() =>
        model?.teiHeader?.fileDesc?.titleStmt?.title?.FirstOrDefault(x => x.n == "print")?.Text);
      var titleDigit = TextHelper.SafeJoin(() =>
        model?.teiHeader?.fileDesc?.titleStmt?.title?.FirstOrDefault(x => x.n == "digital")?.Text);      

      return new[]
      {
        new Dictionary<string, object>
        {
          {"Titel", string.IsNullOrEmpty(titleDigit) ? titlePrint : titleDigit},
          {"Titel (Druck)", titlePrint},
          {"Titel (Digital)", titleDigit},
          {"URLWeb",TextHelper.SafeJoin(() =>model?.teiHeader?.fileDesc?.publicationStmt?.idno?.idno1?.FirstOrDefault(x => x.type == "URLWeb")?.Text)},
          {"URLXML",TextHelper.SafeJoin(() =>model?.teiHeader?.fileDesc?.publicationStmt?.idno?.idno1?.FirstOrDefault(x => x.type == "URLXML")?.Text)},
          {"TELOTAID",TextHelper.SafeJoin(() =>model?.teiHeader?.fileDesc?.publicationStmt?.idno?.idno1?.FirstOrDefault(x => x.type == "TELOTAID")?.Text)},
          {"Quelle", TextHelper.SafeJoin(() => model?.teiHeader?.fileDesc?.sourceDesc?.bibl?.title?.Text)},{"Band", model?.teiHeader?.fileDesc?.sourceDesc?.bibl?.title?.n},
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
          var name = $"{TextHelper.SafeJoin(() => n.Text)} {n.Name()}";
          if (name.StartsWith(", "))
            name = name.Substring(2);
          names.Add(name);
        }

        return TextHelper.RemoveMultiSpacesAndLinebreaks(string.Join(JoinMark, names.OrderBy(x => x)));
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
        return TextHelper.RemoveMultiSpacesAndLinebreaks(string.Join(JoinMark, refs.Select(r => r.target)));
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
        return TextHelper.RemoveMultiSpacesAndLinebreaks(string.Join(JoinMark, places.Select(p => p.@ref)));
      }
      catch
      {
        return "";
      }
    }
  }
}