using System;
using System.Collections.Generic;
using System.Linq;
using Bcs.Crawler.Interface;
using HtmlAgilityPack;

namespace Bcs.Crawler
{
  public class HtmlStaticIndexCrawlerFilterLinks : ICrawler
  {
    public delegate IEnumerable<HtmlNode> FilterNodes(IEnumerable<HtmlNode> hnc);

    public FilterNodes FilterFunction;

    #region Public Methods and Operators

    /// <summary>
    ///   Crawls this instance.
    /// </summary>
    /// <returns>Dictionary{System.StringSystem.String}[][].</returns>
    public Dictionary<string, object>[] Crawl()
    {
      CheckPrerequisites();

      var res = new List<Dictionary<string, object>>();

      var web = new HtmlWeb();
      var doc = web.Load(Url);

      IEnumerable<HtmlNode> nodes = doc.DocumentNode.SelectNodes("//a");
      if (nodes == null || !nodes.Any())
        return null;
      if (FilterFunction != null)
        nodes = FilterFunction(nodes);

      foreach (var node in nodes)
        try
        {
          var url = node.GetAttributeValue("href", "");
          if (string.IsNullOrEmpty(url) || UrlBlockedPrefix.Find(url.StartsWith) != null)
            continue;

          Crawler.Url = string.IsNullOrEmpty(UrlResultPrefix)
            ? url
            : UrlResultPrefix + (url.StartsWith(".") ? url.Substring(1) : url);

          var items = Crawler.Crawl();
          if (items != null)
            res.AddRange(items);
          if (MaxResults == 0)
            continue;
          if (res.Count >= MaxResults)
            return res.ToArray();
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex.Message);
          Console.WriteLine(ex.StackTrace);
        }

      return res.ToArray();
    }

    #endregion

    #region Methods

    /// <summary>
    ///   Checks the prerequisites.
    /// </summary>
    /// <exception cref="System.ArgumentNullException">
    ///   Url
    ///   or
    ///   Parameters
    ///   or
    ///   Query
    ///   or
    ///   Crawler
    ///   or
    ///   ResultsXpath
    /// </exception>
    /// <exception cref="System.ArgumentException">
    ///   Property Url must contains [QUERY] and [PAGE] in string.;Url
    ///   or
    ///   Value must be set;PageIncrementValue
    ///   or
    ///   Value must be set;PageStartValue
    /// </exception>
    private void CheckPrerequisites()
    {
      if (string.IsNullOrEmpty(Url))
        throw new ArgumentNullException(nameof(Url));

      if (Crawler == null)
        throw new ArgumentNullException(nameof(Crawler));

      if (FilterFunction == null)
        throw new ArgumentNullException(nameof(FilterFunction));
    }

    #endregion

    #region Fields

    /// <summary>
    ///   The _parameters
    /// </summary>
    private Dictionary<string, string> _parameters = new Dictionary<string, string>();

    public HtmlStaticIndexCrawlerFilterLinks(FilterNodes filterFunction)
    {
      FilterFunction = filterFunction;
    }

    #endregion

    #region Public Properties

    /// <summary>
    ///   Gets or sets the page crawler.
    /// </summary>
    /// <value>The page crawler.</value>
    public ICrawler Crawler { get; set; }

    // ReSharper disable once MemberCanBePrivate.Global

    // ReSharper disable once MemberCanBePrivate.Global
    /// <summary>
    ///   Gets or sets the URL.
    /// </summary>
    /// <value>The URL.</value>
    public string Url { get; set; }

    /// <summary>
    ///   Gets or sets the URL blocked prefix.
    /// </summary>
    /// <value>The URL blocked prefix.</value>
    public List<string> UrlBlockedPrefix { get; set; } = new List<string>();

    /// <summary>
    ///   Gets or sets the URL result prefix.
    /// </summary>
    /// <value>The URL result prefix.</value>
    public string UrlResultPrefix { get; set; }

    public int MaxResults { get; set; } = 0;

    #endregion
  }
}