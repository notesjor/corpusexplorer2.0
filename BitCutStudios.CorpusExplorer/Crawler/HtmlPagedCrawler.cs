using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml.Serialization;
using Bcs.Crawler.Interface;
using HtmlAgilityPack;

namespace Bcs.Crawler
{
  /// <summary>
  ///   Class HtmlSearchCrawler
  /// </summary>
  [XmlRoot]
  [Serializable]
  public sealed class HtmlPagedCrawler : ICrawler
  {
    /// <summary>
    ///   The PAGE
    /// </summary>
    [XmlIgnore] [NonSerialized] private const string Page = "[PAGE]";

    /// <summary>
    ///   The _page increment value
    /// </summary>
    [XmlAttribute("increment")] private int _pageIncrementValue = -1;

    /// <summary>
    ///   The _page start value
    /// </summary>
    [XmlAttribute("startIndex")] private int _pageStartValue = -1;

    /// <summary>
    ///   The _url blocked prefix
    /// </summary>
    [XmlArray("blocks")] private List<string> _urlBlockedPrefix = new List<string>();

    public HtmlPagedCrawler()
    {
      MaxResults = 0;
    }

    /// <summary>
    ///   Gets or sets the page crawler.
    /// </summary>
    /// <value>The page crawler.</value>
    [XmlElement]
    public ICrawler Crawler { get; set; }

    [XmlAttribute("max")]
    public int MaxResults { get; set; }

    // ReSharper disable once MemberCanBePrivate.Global

    // ReSharper disable once MemberCanBePrivate.Global
    /// <summary>
    ///   Gets or sets the page increment value.
    /// </summary>
    /// <value>The page increment value.</value>
    [XmlIgnore]
    public int PageIncrementValue
    {
      get => _pageIncrementValue;
      set => _pageIncrementValue = value;
    }

    /// <summary>
    ///   Gets or sets the page start value.
    /// </summary>
    /// <value>The page start value.</value>
    [XmlIgnore]
    public int PageStartValue
    {
      get => _pageStartValue;
      set => _pageStartValue = value;
    }

    /// <summary>
    ///   Gets or sets the query.
    /// </summary>
    /// <value>The query.</value>
    [XmlIgnore]
    public IEnumerable<string> Queries { get; set; }

    // ReSharper disable once MemberCanBePrivate.Global
    /// <summary>
    ///   Gets or sets the results xpath.
    /// </summary>
    /// <value>The results xpath.</value>
    [XmlIgnore]
    public string ResultsXpath { get; set; }

    // ReSharper disable once MemberCanBePrivate.Global

    // ReSharper disable once MemberCanBePrivate.Global

    /// <summary>
    ///   Gets or sets the URL blocked prefix.
    /// </summary>
    /// <value>The URL blocked prefix.</value>
    [XmlIgnore]
    public List<string> UrlBlockedPrefix
    {
      // ReSharper disable once MemberCanBePrivate.Global
      get => _urlBlockedPrefix;
      set => _urlBlockedPrefix = value;
    }

    /// <summary>
    ///   Gets or sets the URL result prefix.
    /// </summary>
    /// <value>The URL result prefix.</value>
    [XmlAttribute("urlPrefix")]
    public string UrlResultPrefix { get; set; }

    /// <summary>
    ///   Crawls this instance.
    /// </summary>
    /// <returns>Dictionary{System.StringSystem.String}[][].</returns>
    public Dictionary<string, object>[] Crawl()
    {
      CheckPrerequisites();

      var res = new List<Dictionary<string, object>>();

      foreach (var query in Queries)
      {
        if (string.IsNullOrEmpty(query))
          continue;

        HtmlNodeCollection nodes;
        do
        {
          var web = new HtmlWeb();
          var doc =
            web.Load(
                     Url.Replace(Page, PageStartValue.ToString(CultureInfo.InvariantCulture)));
          PageStartValue += PageIncrementValue;

          nodes = doc.DocumentNode.SelectNodes(ResultsXpath);
          if (nodes       == null ||
              nodes.Count == 0)
            break;

          foreach (var node in nodes)
            try
            {
              var url = node.GetAttributeValue("href", "");
              if (string.IsNullOrEmpty(url) ||
                  UrlBlockedPrefix.Find(url.StartsWith) != null)
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
        } while (nodes.Count > 0);
      }

      return res.ToArray();
    }

    /// <summary>
    ///   Gets or sets the URL.
    /// </summary>
    /// <value>The URL.</value>
    [XmlAttribute("url")]
    public string Url { get; set; }

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
        // ReSharper disable once NotResolvedInText
        throw new ArgumentNullException("Url");

      if (!Url.Contains(Page))
        // ReSharper disable once NotResolvedInText
        throw new ArgumentException("Property Url must contains [PAGE] in string.", "Url");

      if (Queries == null)
        // ReSharper disable once NotResolvedInText
        throw new ArgumentNullException("Queries");

      if (Crawler == null)
        // ReSharper disable once NotResolvedInText
        throw new ArgumentNullException("PageCrawler");

      if (string.IsNullOrEmpty(ResultsXpath))
        // ReSharper disable once NotResolvedInText
        throw new ArgumentNullException("ResultsXpath");

      if (PageIncrementValue == -1)
        // ReSharper disable once NotResolvedInText
        throw new ArgumentException("Value must be set", "PageIncrementValue");

      if (PageStartValue == -1)
        // ReSharper disable once NotResolvedInText
        throw new ArgumentException("Value must be set", "PageStartValue");
    }
  }
}