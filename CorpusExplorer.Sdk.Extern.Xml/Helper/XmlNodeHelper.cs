using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using CorpusExplorer.Sdk.Helper;

namespace CorpusExplorer.Sdk.Extern.Xml.Helper
{
  public static class XmlNodeHelper
  {
    public static string GetAttribute(this XmlNode node, string attributeName)
    {
      return node?.Attributes?[attributeName]?.Value;
    }

    public static string GetAttribute(this XmlNode node, string attributeName, string defaultValue)
    {
      return node?.Attributes?[attributeName]?.Value ?? defaultValue;
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

    public static XmlNode GetSimpleXpathFirst(this XmlNode node, string xpath)
    {
      var query = xpath.Split(Splitter.Slash, StringSplitOptions.RemoveEmptyEntries);
      return GetSimpleXpathFirst(node, query, 0, query.Length - 1);
    }

    private static XmlNode GetSimpleXpathFirst(this XmlNode node, string[] xpath, int idx, int max)
    {
      var key = xpath[idx];

      return idx < max 
        ? (from XmlNode child in node.ChildNodes where child.Name == key select GetSimpleXpathFirst(child, xpath, idx + 1, max)).FirstOrDefault(tmp => tmp != null) 
        : node.ChildNodes.Cast<XmlNode>().FirstOrDefault(child => child.Name == key);
    }

    public static List<XmlNode> GetSimpleXpath(this XmlNode node, string xpath)
    {
      var query = xpath.Split(Splitter.Slash, StringSplitOptions.RemoveEmptyEntries);
      return GetSimpleXpath(node, query, 0, query.Length - 1);
    }

    private static List<XmlNode> GetSimpleXpath(this XmlNode node, string[] xpath, int idx, int max)
    {
      var res = new List<XmlNode>();
      var key = xpath[idx];

      if (idx < max)
      {
        foreach (XmlNode child in node.ChildNodes)
          if (child.Name == key)
          {
            var tmp = GetSimpleXpath(child, xpath, idx + 1, max);
            if (tmp.Count > 0)
              res.AddRange(tmp);
          }
      }
      else
        res.AddRange(node.ChildNodes.Cast<XmlNode>().Where(child => child.Name == key));

      return res;
    }

  public static bool HasAttribute(this XmlNode node, string attributeName)
  {
    return node?.Attributes != null && node.Attributes.Cast<XmlAttribute>().Any(x => x.Name == attributeName);
  }
}
}