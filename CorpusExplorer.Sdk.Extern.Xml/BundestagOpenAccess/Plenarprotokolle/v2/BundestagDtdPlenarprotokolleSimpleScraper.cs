using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CorpusExplorer.Sdk.Extern.Xml.Abstract;
using CorpusExplorer.Sdk.Helper;
using HtmlAgilityPack;

namespace CorpusExplorer.Sdk.Extern.Xml.BundestagOpenAccess.Plenarprotokolle.v2
{
  public class BundestagDtdPlenarprotokolleSimpleScraper : AbstractHtmlScraper
  {
    public override string DisplayName { get; } = "Bundestag Plenarprotokolle (DTD ab Wahlperiode 19 - gesamtes Protokoll)";
    protected override IEnumerable<Dictionary<string, object>> Execute(string file, HtmlDocument xmlDoc)
    {
      var res = new Dictionary<string, object>();

      var root = xmlDoc.DocumentNode.SelectSingleNode("/dbtplenarprotokoll");

      res.Add("Datum", DateTimeHelper.Parse(root.GetAttributeValue("sitzung-datum", "01.01.0001")));
      res.Add("Datum (nächste Sitzung)", DateTimeHelper.Parse(root.GetAttributeValue("sitzung-naechste-datum", "01.01.0001")));
      //res.Add("Start", root.GetAttributeValue("sitzung-start-uhrzeit", "00:00"));
      //res.Add("Ende", root.GetAttributeValue("sitzung-ende-uhrzeit", "00:00"));
      res.Add("Wahlperiode", root.GetAttributeValue("wahlperiode", "0"));
      res.Add("Sitzungs Nr.", root.GetAttributeValue("sitzung-nr", "0"));

      var history = root.SelectSingleNode("sitzungsverlauf");
      if (history == null)
        return null;

      var stb = new StringBuilder();
      foreach (var top in history.SelectNodes("tagesordnungspunkt"))
      {
        stb.AppendLine(ProcessAllTalks(top.SelectNodes("rede")));
      }
      res.Add("Text", stb.ToString());

      return new[] { res };
    }

    private string ProcessAllTalks(HtmlNodeCollection stack)
    {
      if (stack == null)
        return "";

      var stb = new StringBuilder();
      foreach (var rede in stack)
      {
        var lines = rede.SelectNodes("p")?.ToList();
        if (lines == null)
          continue;
        if (lines != null && lines.Count > 0 && lines[0].GetAttributeValue("klasse", "") == "redner" && lines[0].ChildNodes.FirstOrDefault(x => x.Name == "redner") != null)
          lines.RemoveAt(0);
        stb.AppendLine(GetText(lines));
      }

      return stb.ToString();
    }

    private Dictionary<string, object> Clone(Dictionary<string, object> orig)
      => orig.ToDictionary(x => x.Key, x => x.Value);

    private string GetText(List<HtmlNode> items)
    {
      var stb = new StringBuilder();

      foreach (var x in items)
      {
        try
        {
          if (x.Name != "p")
            continue;

          stb.AppendLine(x.InnerText);
        }
        catch
        {
          // ignore
        }
      }

      return stb.ToString();
    }
  }
}
