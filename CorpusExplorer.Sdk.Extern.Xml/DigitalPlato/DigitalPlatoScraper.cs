using System.Collections.Generic;
using System.Linq;
using System.Xml;
using CorpusExplorer.Sdk.Extern.Xml.Abstract.XmlDocumentBasedScraper;

namespace CorpusExplorer.Sdk.Extern.Xml.DigitalPlato
{
  public class DigitalPlatoScraper : AbstractXmlDocumentScraper
  {
    public override string DisplayName => "Digital-Plato.org";

    public bool ReplaceLinebreakWithSentence { get; set; } = true;

    private string GetPlaintext(XmlDocument xmlDoc)
    {
      RemoveAllChilds(ref xmlDoc, "//foreign");
      RemoveAllChilds(ref xmlDoc, "//note");
      RemoveAllChilds(ref xmlDoc, "//speaker");
      RemoveAllChilds(ref xmlDoc, "//hi");

      if (ReplaceLinebreakWithSentence)
        ReplaceAll(ref xmlDoc, "//lb", ".");
      else
        RemoveAllChilds(ref xmlDoc, "//lb");

      return xmlDoc.InnerText.Replace("\t", " ").Replace("  ", " ").Replace(". .", ".").Replace("..", ".").Replace("  ", " ").Replace("..", ".").Replace("  ", " ").Replace("..", ".");
    }

    private void RemoveAllChilds(ref XmlDocument xmlDoc, string xpath)
    {
      var nodes = xmlDoc.SelectNodes(xpath);
      if (nodes == null || nodes.Count == 0)
        return;
      foreach (XmlNode node in nodes)
        node?.ParentNode?.RemoveChild(node);
    }

    private void ReplaceAll(ref XmlDocument xmlDoc, string xpath, string replaceText)
    {
      var parent = new List<KeyValuePair<XmlNode, XmlNode>>();
      var nodes = xmlDoc.SelectNodes(xpath);
      if (nodes == null || nodes.Count == 0)
        return;

      foreach (XmlNode node in nodes)
      {
        if (node.ParentNode != null)
          parent.Add(new KeyValuePair<XmlNode, XmlNode>(node.ParentNode, node));
      }

      foreach (var x in parent)
      {
        x.Key.ReplaceChild(xmlDoc.CreateTextNode(replaceText), x.Value);
      }
    }

    protected override IEnumerable<Dictionary<string, object>> Execute(string file, XmlDocument xmlDoc)
    {
      try
      {
        var div = xmlDoc?.SelectNodes("/div")?.Cast<XmlElement>().Single();

        var res = new Dictionary<string, object>
        {
          {"AuthorId", PickAttributeValue(div, "author_id", "-")},
          {"WorkId", PickAttributeValue(div, "work_id", "-")},
          {"WorkShort", PickAttributeValue(div, "work_short", "-")},
          {"Text", GetPlaintext(xmlDoc)}
        };

        return new[] { res };
      }
      catch
      {
        var res = new Dictionary<string, object>
        {
          {"Text", GetPlaintext(xmlDoc)}
        };

        return new[] { res };
      }
    }
  }
}
