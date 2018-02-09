using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace CorpusExplorer.Sdk.Extern.Xml.Abstract.XmlDocumentBasedScraper
{
  public abstract class AbstractXmlDocumentScraper : AbstractScraper
  {
    protected string SafeJoin(IEnumerable<string> lines)
    {
      return lines == null ? string.Empty : string.Join(" ", lines);
    }

    protected string PickInnerXml(XmlElement element, params string[] path)
    {
      var first = path.FirstOrDefault();
      foreach (XmlElement node in element.ChildNodes)
      {
        if (node.Name != first)
          continue;

        if (path.Length == 1)
        {
          return node.InnerXml;
        }
        else
        {
          var list = new List<string>();
          for (int i = 1; i < path.Length; i++)
          {
            list.Add(path[i]);
          }
          return PickInnerXml(node, list.ToArray());
        }
      }
      return null;
    }

    protected string PickAttributeValue(XmlElement element, string attribute, string defaultAttributeValue, params string[] path)
    {
      var first = path.FirstOrDefault();
      foreach (XmlElement node in element.ChildNodes)
      {
        if (node.Name != first)
          continue;

        if (path.Length == 1)
        {
          return node.HasAttribute(attribute) ? node.GetAttribute(attribute) : defaultAttributeValue;
        }
        else
        {
          var list = new List<string>();
          for (int i = 1; i < path.Length; i++)
          {
            list.Add(path[i]);
          }
          return PickAttributeValue(node, attribute, defaultAttributeValue, list.ToArray());
        }
      }
      return null;
    }

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      var xmlDoc = new XmlDocument();
      xmlDoc.Load(file);
      return Execute(file, xmlDoc);
    }

    protected abstract IEnumerable<Dictionary<string, object>> Execute(string file, XmlDocument xmlDoc);
  }
}
