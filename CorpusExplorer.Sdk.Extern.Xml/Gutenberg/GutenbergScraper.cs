using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;
using HtmlAgilityPack;

namespace CorpusExplorer.Sdk.Extern.Xml.Gutenberg
{
  public class GutenbergScraper : AbstractScraper
  {
    private readonly object _lock = new object();
    public override string DisplayName { get { return "Gutenberg DVD - SimpleScraper"; } }

    private static Dictionary<string, object> BuildHead(HtmlNode head)
    {
      var res = new Dictionary<string, object>();

      foreach (var node in head.ChildNodes)
        switch (node.Name)
        {
          case "title":
            res.Add("Titel", node.InnerText);
            break;
          case "meta":
            var attrN = node.Attributes.FirstOrDefault(a => a.Name == "name");
            var attrC = node.Attributes.FirstOrDefault(a => a.Name == "content");

            if ((attrN == null) ||
                (attrC == null) ||
                res.ContainsKey(attrN.Value))
              continue;

            if ((attrN.Value == "year") ||
                (attrN.Value == "firstpub"))
            {
              int year;
              var stry = attrC.Value;
              if (int.TryParse(stry, out year))
                res.Add(attrN.Value, year);
              else
                res.Add(attrN.Value, stry);
            }
            else
              res.Add(attrN.Value, attrC.Value);
            break;
        }

      return res;
    }

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      lock (_lock)
      {
        var scraper = new HtmlDocument();
        scraper.Load(file);
        var html = scraper.DocumentNode?.ChildNodes.FirstOrDefault(childNode => childNode.Name == "html");
        var head = html?.ChildNodes.FirstOrDefault(childNode => childNode.Name == "head");
        if (head == null)
          return null;
        var body = html.ChildNodes.FirstOrDefault(childNode => childNode.Name == "body");
        if (body == null)
          return null;

        var dic = BuildHead(head);
        dic.Add("Text", body.InnerText);

        return new[] {dic};
      }
    }
  }
}