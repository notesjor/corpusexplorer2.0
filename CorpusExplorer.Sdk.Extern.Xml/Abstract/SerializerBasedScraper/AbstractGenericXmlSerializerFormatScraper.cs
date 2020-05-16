#region

using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper
{
  public abstract class AbstractGenericXmlSerializerFormatScraper<T> : AbstractScraper
    where T : class
  {
    protected abstract AbstractGenericSerializer<T> Serializer { get; }

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      return ScrapDocuments(file, Serializer.Deserialize(file));
    }

    protected abstract IEnumerable<Dictionary<string, object>> ScrapDocuments(string file, T model);

    protected string SerializeSubNode<T>(T node)
    {
      using (var ms = new MemoryStream())
      {
        var xml = new XmlSerializer(typeof(T));
        xml.Serialize(ms, node);
        return Encoding.UTF8.GetString(ms.ToArray());
      }
    }

    protected string GetInnerPlaintext<T>(T node)
    {
      var html = new HtmlAgilityPack.HtmlDocument();
      html.LoadHtml(SerializeSubNode(node));
      return html.DocumentNode.InnerText;
    }
  }
}