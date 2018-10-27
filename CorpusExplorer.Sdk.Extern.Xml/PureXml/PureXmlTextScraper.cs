using System.Collections.Generic;
using System.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;
using HtmlAgilityPack;

namespace CorpusExplorer.Sdk.Extern.Xml.PureXml
{
  public class PureXmlTextScraper : AbstractScraper
  {
    public override string DisplayName => "XML > Text";

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      var doc = new HtmlDocument();
      using (var fs = new FileStream(file, FileMode.Open, FileAccess.Read))
      using (var bs = new BufferedStream(fs))
      {
        doc.Load(bs, Configuration.Encoding);
      }

      return new[]
      {
        new Dictionary<string, object>
        {
          {"Text", doc.DocumentNode.InnerText}
        }
      };
    }
  }
}