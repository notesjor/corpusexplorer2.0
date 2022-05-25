using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CorpusExplorer.Sdk.Extern.Xml.Abstract;
using CorpusExplorer.Sdk.Helper;
using HtmlAgilityPack;

namespace CorpusExplorer.Sdk.Extern.Xml.BundestagOpenAccess.Plenarprotokolle.v2
{
  public class BundestagDtdPlenarprotokolleScraper : AbstractHtmlScraper
  {
    public override string DisplayName { get; } = "Bundestag Plenarprotokolle (DTD ab Wahlperiode 19)";
    protected override IEnumerable<Dictionary<string, object>> Execute(string file, HtmlDocument xmlDoc)
    {
      var meta = new Dictionary<string, object>();

      var root = xmlDoc.DocumentNode.SelectSingleNode("/dbtplenarprotokoll");

      meta.Add("Datum", DateTimeHelper.Parse(root.GetAttributeValue("sitzung-datum", "01.01.0001")));
      meta.Add("Datum (nächste Sitzung)", DateTimeHelper.Parse(root.GetAttributeValue("sitzung-naechste-datum", "01.01.0001")));
      //meta.Add("Start", root.GetAttributeValue("sitzung-start-uhrzeit", "00:00"));
      //meta.Add("Ende", root.GetAttributeValue("sitzung-ende-uhrzeit", "00:00"));
      meta.Add("Wahlperiode", root.GetAttributeValue("wahlperiode", "0"));
      meta.Add("Sitzungs Nr.", root.GetAttributeValue("sitzung-nr", "0"));

      var res = new List<Dictionary<string, object>>();
      var history = root.SelectSingleNode("sitzungsverlauf");
      if (history == null)
        return null;

      foreach (var top in history.SelectNodes("tagesordnungspunkt"))
      {
        var metaT = Clone(meta);
        metaT.Add("TOP (ID)", top.GetAttributeValue("top-id", ""));
        metaT.Add("TOP (Titel)", top.GetAttributeValue("top-titel", ""));

        ProcessAllTalks(top.SelectNodes("rede"), metaT, ref res);
      }

      return res;
    }

    private void ProcessAllTalks(HtmlNodeCollection stack, Dictionary<string, object> meta, ref List<Dictionary<string, object>> res)
    {
      if (stack != null)
        foreach (var rede in stack)
        {
          var own = Clone(meta);
          own.Add("Id", rede.GetAttributeValue("id", ""));
          var lines = rede.SelectNodes("p")?.ToList();
          if (lines != null && lines.Count > 0 && lines[0].GetAttributeValue("klasse", "") == "redner")
          {
            var speaker = lines[0].ChildNodes.FirstOrDefault(x => x.Name == "redner");
            if (speaker == null)
              continue;

            own.Add("Redner*in (ID)", speaker.GetAttributeValue("id", ""));

            var name = speaker.ChildNodes?.FirstOrDefault(x => x.Name == "name");
            if (name != null)
            {
              var titel = name.ChildNodes?.FirstOrDefault(x => x.Name == "titel")?.InnerText ?? "";
              var vorname = name.ChildNodes?.FirstOrDefault(x => x.Name == "vorname")?.InnerText ?? "";
              var nachname = name.ChildNodes?.FirstOrDefault(x => x.Name == "nachname")?.InnerText ?? "";

              own.Add("Redner*in", $"{nachname}, {vorname}");
              own.Add("Redner*in (Titel)", titel);
            }

            var rolle = name?.ChildNodes?.FirstOrDefault(x => x.Name == "rolle");
            if (rolle != null)
              own.Add("Redner*in (Rolle)", rolle.ChildNodes?.FirstOrDefault(x => x.Name == "rolle_lang")?.InnerText);

            var fraktion = name?.ChildNodes?.FirstOrDefault(x => x.Name == "fraktion");
            if(fraktion != null)
              own.Add("Fraktion", fraktion.InnerText);

            lines.RemoveAt(0);
          }

          own.Add("Text", GetText(lines));

          res.Add(own);
        }
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
