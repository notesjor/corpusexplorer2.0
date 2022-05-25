using System.Collections.Generic;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;
using HtmlAgilityPack;

namespace CorpusExplorer.Sdk.Extern.Xml.Abstract
{
  public abstract class AbstractHtmlScraper : AbstractScraper
  {
    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      var xmlDoc = new HtmlDocument();
      xmlDoc.Load(file, Configuration.Encoding);
      return Execute(file, xmlDoc);
    }

    protected abstract IEnumerable<Dictionary<string, object>> Execute(string file, HtmlDocument xmlDoc);
  }
}
