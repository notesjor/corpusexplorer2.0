#region

using System.IO;
using System.Text;
using System.Xml.Serialization;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;
using HtmlAgilityPack;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Abstract
{
  public abstract class AbstractXmlScraper : AbstractScraper
  {
    protected string SerializeSubNode<T>(T node)
    {
      using (var ms = new MemoryStream())
      {
        var xml = new XmlSerializer(typeof(T));
        xml.Serialize(ms, node);
        return Encoding.UTF8.GetString(ms.ToArray());
      }
    }

    protected HtmlDocument SubNodeToHtml<T>(T node)
    {
      var html = new HtmlDocument();
      html.LoadHtml(SerializeSubNode(node));
      return html;
    }

    protected string GetInnerPlaintext<T>(T node) 
      => SubNodeToHtml(node).DocumentNode.InnerText;
  }
}