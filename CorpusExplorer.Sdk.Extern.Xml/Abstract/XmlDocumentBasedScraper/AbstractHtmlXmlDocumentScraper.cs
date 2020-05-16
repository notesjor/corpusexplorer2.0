using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;
using HtmlAgilityPack;

namespace CorpusExplorer.Sdk.Extern.Xml.Abstract.XmlDocumentBasedScraper
{
  public abstract class AbstractHtmlXmlDocumentScraper : AbstractScraper
  {
    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      var xmlDoc = new HtmlDocument();
      xmlDoc.Load(file);
      return Execute(file, xmlDoc);
    }

    protected abstract IEnumerable<Dictionary<string, object>> Execute(string file, HtmlDocument xmlDoc);
  }
}
