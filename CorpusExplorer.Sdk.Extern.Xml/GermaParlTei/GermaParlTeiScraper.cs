using Bcs.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpusExplorer.Sdk.Extern.Xml.GermaParlTei
{
  public class GermaParlTeiScraper : AbstractScraper
  {
    public override string DisplayName => "GermaParlTEI";

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      var xml = new HtmlAgilityPack.HtmlDocument();
      xml.LoadHtml(FileIO.ReadText(file, Configuration.Encoding));

      var period = xml.DocumentNode.SelectSingleNode("//titlestmt/legislativeperiod")?.InnerText;
      var session = xml.DocumentNode.SelectSingleNode("//titlestmt/sessionno")?.InnerText;
      var datum = DateTimeHelper.Parse(xml.DocumentNode.SelectSingleNode("//publicationstmt/date")?.InnerText ?? "0001-01-01");

      var res = new List<Dictionary<string, object>>();

      foreach (var entry in xml.DocumentNode.SelectNodes("//sp"))
      {
        var name = entry.GetAttributeValue("name", "");
        var who = entry.GetAttributeValue("who_original", "");
        var group = entry.GetAttributeValue("parliamentary_group", "");
        var role = entry.GetAttributeValue("role", "");
        var position = entry.GetAttributeValue("position", "");

        res.Add(new Dictionary<string, object>
        {
          { "Wahlperiode", period },
          { "Sitzung", session },
          { "Datum", datum },
          { "Sprecher*in", name },
          { "Sprecher*in (Original)", who },
          { "Fraktion", group },
          { "Rolle", role },
          { "Position", position },
          { "Text", string.Join(" ", entry.ChildNodes.Where(x => x.Name == "p").Select(x => x.InnerText)) },          
        });
      }

      return res;
    }
  }
}
