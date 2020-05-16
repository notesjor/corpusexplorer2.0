using System.Collections.Generic;
using System.Linq;
using System.Text;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Cleanup.Abstract;
using HtmlAgilityPack;

namespace CorpusExplorer.Core.Utils.DocumentProcessing.Cleanup
{
  public class DomTreeRankCleanup : AbstractCleanup
  {
    public int MinTextLength { get; set; } = 75;

    public override string DisplayName => "DOM-Tree (Simple)";

    protected override string Execute(string key, string input)
    {
      var doc = new HtmlDocument();
      doc.LoadHtml(input);

      var node = doc.DocumentNode.SelectNodes("//body").FirstOrDefault();
      if (node == null)
        return input;

      var best = FindRTV(CalulateNodes(doc));
      return best == null || string.IsNullOrWhiteSpace(best.Text) ? input : best.Text;
    }

    public DiscoverNode DebugFullTree(string input)
    {
      var doc = new HtmlDocument();
      doc.LoadHtml(input);
      return CalulateNodes(doc);
    }

    public DiscoverNode DebugBestTree(string input)
    {
      var doc = new HtmlDocument();
      doc.LoadHtml(input);
      return FindRTV(CalulateNodes(doc));
    }

    private DiscoverNode FindRTV(DiscoverNode root)
    {
      try
      {
        var top = root;

        if (root.Children != null)
          foreach (var c in root.Children)
          {
            var test = FindRTV(c);
            if (test.RealTextValue > top.RealTextValue)
              top = test;
          }

        return top;
      }
      catch
      {
        return null;
      }
    }

    private DiscoverNode CalulateNodes(HtmlDocument doc)
    {
      var body = doc.DocumentNode.SelectNodes("//body").FirstOrDefault();

      if (body == null)
        return null;

      RemoveNodes(ref body, "script");
      RemoveNodes(ref body, "style");
      RemoveNodes(ref body, "form");

      return CalulateNodes(body);
    }

    private void RemoveNodes(ref HtmlNode body, string name)
    {
      var ns = body.Descendants(name)?.ToArray();
      if (ns != null)
        foreach (var n in ns)
          n.Remove();
    }


    private DiscoverNode CalulateNodes(HtmlNode node)
    {
      if (node.ChildNodes == null || node.Name == "#text") // Bubble up
        if (string.IsNullOrWhiteSpace(node.InnerText))
          return null;
        else
          return new DiscoverNode
          {
            ChildNodes = 0,
            ChildNodesRecursiv = 1,
            Children = null,
            InnerTextNodes = 0,
            RealTextValue = node.InnerText.Length > MinTextLength ? 1 : 0,
            Text = node.InnerText
          };

      var stb = new StringBuilder();
      var cnr = 0;
      var children = new List<DiscoverNode>();
      var itn = node.ChildNodes.Count(x => x.Name == "#text");
      var rtv = 0d;

      foreach (var n in node.ChildNodes)
      {
        var cn = CalulateNodes(n);
        if (cn == null)
          continue;

        cnr += cn.ChildNodesRecursiv;
        itn += cn.InnerTextNodes;
        rtv += cn.RealTextValue;

        stb.Append(cn.Text);

        children.Add(cn);
      }

      var text = stb.Replace("\r\n", " ").Replace("\r", " ").Replace("\n", " ").Replace("\t", " ").Replace("  ", " ").Replace("  ", " ").Replace("  ", " ").ToString();
      rtv = (rtv + text.Length / (cnr + 1d)) / 2d;

      return string.IsNullOrWhiteSpace(text) || text.Length < MinTextLength
               ? null
               : new DiscoverNode
               {
                 ChildNodes = node.ChildNodes.Count,
                 ChildNodesRecursiv = cnr,
                 Children = children,
                 InnerTextNodes = itn,
                 RealTextValue = node.Name == "a" ? 0 : rtv,
                 Text = text
               };
    }

    public class DiscoverNode
    {
      public string Text { get; set; }
      public int ChildNodes { get; set; }
      public int ChildNodesRecursiv { get; set; }
      public int InnerTextNodes { get; set; }
      public double RealTextValue { get; set; }
      public List<DiscoverNode> Children { get; set; } = new List<DiscoverNode>();
    }
  }
}