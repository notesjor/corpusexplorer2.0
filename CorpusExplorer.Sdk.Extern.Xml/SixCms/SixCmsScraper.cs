using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;
using System.Collections.Generic;
using System.Text;
using System.Web;
using CorpusExplorer.Sdk.Helper;
using HtmlAgilityPack;

namespace CorpusExplorer.Sdk.Extern.Xml.SixCms
{
  public class SixCmsScraper : AbstractScraper
  {
    public override string DisplayName => "SixCMS Scraper";

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      var doc = new HtmlDocument();
      doc.Load(file, Encoding.UTF8);

      var articles = doc.DocumentNode.SelectNodes("//sixcms_article");
      if (articles == null)
        return null;

      var res = new List<Dictionary<string, object>>();
      foreach (var article in articles)
      {
        var ndoc = new Dictionary<string, object>();

        foreach (var child in article.ChildNodes)
          switch (child.Name)
          {
            case "online_date":
              ndoc.Add("Datum (Text)", child.InnerText);
              ndoc.Add("Datum", DateTimeHelper.Parse(child.InnerText, "yyyy-MM-dd HH:mm:ss"));
              break;
            case "title":
              ndoc.Add("Titel", child.InnerText);
              break;
            case "id":
              ndoc.Add("ID", child.InnerText);
              break;
            case "field":
              if(child.GetAttributeValue("type", "") != "text")
                continue;
              switch(child.GetAttributeValue("name", ""))
              {
                case "text":
                  ndoc.Add("Text", CleanInnerXml(child.InnerText));
                  break;
                case "dachzeile":
                  ndoc.Add("Dachzeile", child.InnerText);
                  break;
                case "vorspann":
                  ndoc.Add("Vorspann", child.InnerText);
                  break;
                case "keywords":
                  ndoc.Add("Schlagworte", child.InnerText);
                  break;
              }
              break;
          }

        res.Add(ndoc);
      }
      
      return res;
    }

    private string CleanInnerXml(string childInnerText)
    {
      var doc = new HtmlDocument();
      doc.LoadHtml(HttpUtility.HtmlDecode(childInnerText));
      return doc.DocumentNode.InnerText;
    }
  }
}
