using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        doc.Load(fs);
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
