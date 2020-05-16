#region

using System;
using System.Collections.Generic;
using Bcs.Crawler.Interface;
using HtmlAgilityPack;

#endregion

namespace Bcs.Crawler
{
  [Serializable]
  public class HtmlMultipageCrawler : ICrawler
  {
    public HtmlCrawler Crawler { get; set; }

    public string DocumentSeperatorXPath { get; set; }

    public Dictionary<string, object>[] Crawl()
    {
      var res = new List<Dictionary<string, object>>();

      var web = new HtmlWeb();
      var doc = web.Load(Url);

      var nodes = doc.DocumentNode.SelectNodes(DocumentSeperatorXPath);
      if (nodes == null || nodes.Count == 0) return null;

      foreach (var node in nodes)
        try
        {
          var url = node.GetAttributeValue("href", "");
          if (string.IsNullOrEmpty(url)) continue;

          var items = Crawler.Crawl(node.InnerHtml);
          if (items != null) res.AddRange(items);
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex.Message);
          Console.WriteLine(ex.StackTrace);
        }

      return res.ToArray();
    }

    public string Url { get; set; }
  }
}