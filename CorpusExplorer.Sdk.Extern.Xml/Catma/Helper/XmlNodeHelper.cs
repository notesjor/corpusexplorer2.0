using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace CorpusExplorer.Sdk.Extern.Xml.Catma.Helper
{
  public static class XmlNodeHelper
  {
    public static string GetAttribute(this XmlNode node, string attributeName)
    {
      return node?.Attributes?[attributeName]?.Value;
    }

    public static XmlNode GetFirstSubNode(this XmlNode node, string name)
    {
      return node.Name == name ? node : node.ChildNodes.Cast<XmlNode>().FirstOrDefault(child => child.Name == name);
    }

    public static XmlNode GetFirstSubNodeRecursive(this XmlNode node, string name)
    {
      return node.Name == name
        ? node
        : (from XmlNode childchild in node.ChildNodes select GetFirstSubNodeRecursive(childchild, name)).FirstOrDefault(
          res => res != null);
    }

    public static IEnumerable<XmlNode> GetSubNodes(this XmlNode node, string name)
    {
      if (node == null)
        return null;
      var res = node.ChildNodes.Cast<XmlNode>().Where(child => child.Name == name).ToList();
      if (node.Name == name)
        res.Add(node);
      return res;
    }

    public static IEnumerable<XmlNode> GetSubNodesRecursive(this XmlNode node, string name)
    {
      var list = new List<XmlNode>();
      if (node.Name == name)
        list.Add(node);

      foreach (XmlNode childchild in node.ChildNodes)
        list.AddRange(GetSubNodesRecursive(childchild, name));

      return list;
    }

    public static bool HasAttribute(this XmlNode node, string attributeName)
    {
      return node?.Attributes != null && node.Attributes.Cast<XmlAttribute>().Any(x => x.Name == attributeName);
    }
  }
}