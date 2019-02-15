using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper;
using CorpusExplorer.Sdk.Extern.Xml.Tei.P5Cal2.Model;
using CorpusExplorer.Sdk.Extern.Xml.Tei.P5Cal2.Model.Extension;
using CorpusExplorer.Sdk.Extern.Xml.Tei.P5Cal2.Serializer;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;
using HtmlAgilityPack;

namespace CorpusExplorer.Sdk.Extern.Xml.Tei.P5Cal2
{
  public class P5Cal2Scraper : AbstractScraper
  {
    public override string DisplayName => "TEI-P5 (based on CAL2)";

    private Cal2TeiSerializer _single = new Cal2TeiSerializer();
    private Cal2TeiCorpusSerializer _corpus = new Cal2TeiCorpusSerializer();
    public bool ScrapeText { get; set; } = true;

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      try
      {
        var doc = _single.Deserialize(file);
        if (doc == null)
          throw new NullReferenceException();
        return Scrape(new[] { doc });
      }
      catch
      {
        try
        {
          return Scrape(_corpus.Deserialize(file).TEI);
        }
        catch
        {
          // ignore
        }
      }

      return null;
    }

    private IEnumerable<Dictionary<string, object>> Scrape(TEI[] tei)
    {
      var res = new List<Dictionary<string, object>>();

      foreach (var t in tei)
      {
        if (t == null)
          continue;

        var doc = new Dictionary<string, object>
        {
          {"Textklasse", $"{t.teiHeader?.profileDesc?.textClass?.keywords?.term}"},
          {"Datei", SafeJoin((from x in t.teiHeader?.fileDesc?.titleStmt?.title where x.type == "file_reference" select x).FirstOrDefault()?.Text)},
        };
        TitleMod(ref doc, t.teiHeader?.fileDesc?.sourceDesc?.GetBiblStruct()?.analytic?.title);
        IdnoMod(ref doc, t.teiHeader?.fileDesc?.sourceDesc?.GetBiblStruct()?.analytic?.idno);
        RefMod(ref doc, t.teiHeader?.fileDesc?.sourceDesc?.GetBiblStruct()?.analytic?.@ref);
        DateMod(ref doc, t.teiHeader?.fileDesc?.sourceDesc?.GetBiblStruct()?.analytic?.date);
        AuthorMod(ref doc, t.teiHeader?.fileDesc?.sourceDesc?.GetBiblStruct()?.analytic?.GetAuthors());
        RespStmtMod(ref doc, t.teiHeader?.fileDesc?.sourceDesc?.GetBiblStruct()?.analytic?.GetRespStmt());
        if (ScrapeText)
          RunTextScraper(ref doc, tei);

        res.Add(doc);
      }

      return res;
    }

    private void RunTextScraper(ref Dictionary<string, object> doc, TEI[] tei)
    {
      var xml = new HtmlDocument();
      xml.LoadHtml(Sdk.Helper.Serializer.SerializeXml(tei));

      var ns = xml.DocumentNode.SelectNodes("//text");
      var stb = new StringBuilder();
      foreach (var n in ns)
      {
        stb.AppendLine(n.InnerText);
      }

      doc.Add("Text", stb.ToString());
    }

    private void RespStmtMod(ref Dictionary<string, object> doc, respStmt getRespStmt)
    {
      if (getRespStmt == null)
        return;

      var org = (from x in getRespStmt.Items where x is string select x as string).FirstOrDefault();
      if (!string.IsNullOrEmpty(org))
        doc.Add("org", org);

      var pla = (from x in getRespStmt.Items where x is name && ((name)x).type == "place" select x as name).FirstOrDefault();
      if (pla != null)
        doc.Add("Ort", SafeJoin(pla.Text));
    }

    private void AuthorMod(ref Dictionary<string, object> doc, IEnumerable<author> getAuthors)
    {
      if (getAuthors == null)
        return;

      doc.Add("Autor", string.Join(";", (from author in getAuthors from name in author.name select name.GetName())));
    }

    private void DateMod(ref Dictionary<string, object> doc, string analyticDate)
    {
      if (!string.IsNullOrEmpty(analyticDate))
        doc.Add("Datum", DateTimeHelper.Parse(analyticDate, "yyyy-MM-dd"));
    }

    private void RefMod(ref Dictionary<string, object> doc, @ref analyticRef)
    {
      if (analyticRef == null)
        return;
      doc.Add("URL", SafeJoin(analyticRef.Text));
    }

    private void IdnoMod(ref Dictionary<string, object> doc, idno[] analyticIdno)
    {
      if (analyticIdno == null)
        return;

      foreach (var idno in analyticIdno)
      {
        if (!doc.ContainsKey(idno.type))
          doc.Add(idno.type, SafeJoin(idno.Text));
      }
    }

    private void TitleMod(ref Dictionary<string, object> doc, title[] titles)
    {
      if (titles == null)
        return;

      switch (titles.Length)
      {
        case 1:
          doc.Add("Titel", SafeJoin(titles.FirstOrDefault()?.Text));
          break;
        case 2:
          doc.Add("Titel", SafeJoin((from x in titles where x.type == "full" select x).FirstOrDefault()?.Text));
          doc.Add("Titelzusatz", SafeJoin((from x in titles where x.type == "abbr" select x).FirstOrDefault()?.Text));
          break;
        default:
          doc.Add("Titel", SafeJoin(titles.SelectMany(x => x.Text).ToArray()));
          break;
      }
    }

    private string SafeJoin(string[] lines, string separator = " ") => lines == null ? "" : string.Join(separator, lines);
  }
}
