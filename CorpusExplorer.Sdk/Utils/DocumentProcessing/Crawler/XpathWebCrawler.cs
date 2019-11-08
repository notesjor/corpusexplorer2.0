#region

using System.Collections.Generic;
using System.IO;
using Bcs.Crawler;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Crawler.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Crawler
{
  public class XpathWebCrawler : AbstractCrawler
  {
    private string _displayName;

    private XpathWebCrawler()
    {
    }

    public override string DisplayName => _displayName;

    public IEnumerable<string> Queries { get; set; }

    private HtmlSearchCrawler Crawler { get; set; }

    /// <summary>
    ///   Erzeugt einen neuen Crawler und speichert ihn als XML-CrawlerDefinition
    /// </summary>
    /// <param name="displayName">Datei unter der dieser Crawler gespeichert wird</param>
    /// <param name="searchUrl">URL der Suche</param>
    /// <param name="searchPageIndex">Erster Index mit dem die Suche startet</param>
    /// <param name="searchPageIncrement">Wert um den der Such-Index jede Runde erhöht wird.</param>
    /// <param name="searchResultXpath">XPath der die Suchergebnisse markiert</param>
    /// <param name="searchResultUrlPrefix">URL-Abschnitt der dem der Ergebnisurl vorangestellt wird.</param>
    /// <param name="crawlerUrlLimmit">Limmit das vorgibt ob die Seite gelesen werden kann</param>
    /// <param name="crawlerMapping">Paramter (Key=XPath / Value=Metadaten bzw. Text wenn Textinhalt</param>
    /// <param name="alternativePath">Alternative Pfad unter dem der Crawler gespeichert wird</param>
    /// <example>
    ///   var search = new HtmlSearchCrawler
    ///   {
    ///   PageIncrementValue = 1,
    ///   PageStartValue = 0,
    ///   Url = "http://www.taz.de/!s=[QUERY]/?search_page=[PAGE]",
    ///   ResultsXpath = ".//*[@id='pages']/div[1]/span/div/ul/li/a",
    ///   UrlResultPrefix = "http://www.taz.de",
    ///   Crawler =
    ///   new HtmlCrawler
    ///   {
    ///   UrlLimmit = "http://www.taz.de/",
    ///   Parameters =
    ///   new Dictionary[string, string]
    ///   {
    ///   {
    ///   ".//*[@id='pages']/div[1]/span[1]/div[2]/div[1]/h4",
    ///   Resources.Title
    ///   },
    ///   {
    ///   ".//*[@id='pages']/div[1]/span[1]/div[2]/div[1]/h1",
    ///   "Headline"
    ///   },
    ///   {
    ///   ".//*[@id='pages']/div[1]/span[1]/div[2]/div[1]/p",
    ///   "Text"
    ///   },
    ///   {
    ///   ".//span[@class='date']",
    ///   "Datum"
    ///   },
    ///   }
    ///   }
    ///   };
    /// </example>
    public static void Create(
      string displayName,
      string searchUrl,
      int searchPageIndex,
      int searchPageIncrement,
      string searchResultXpath,
      string searchResultUrlPrefix,
      string crawlerUrlLimmit,
      Dictionary<string, string> crawlerMapping,
      string alternativePath = null)
    {
      var c = new XpathWebCrawler
      {
        _displayName = displayName,
        Crawler = new HtmlSearchCrawler
        {
          PageIncrementValue = searchPageIncrement,
          PageStartValue = searchPageIndex,
          Url = searchUrl,
          ResultsXpath = searchResultXpath,
          UrlResultPrefix = searchResultUrlPrefix,
          MaxResults = 10000,
          Crawler =
            new HtmlCrawler
            {
              UrlLimmit = crawlerUrlLimmit,
              Parameters = crawlerMapping
            }
        }
      };

      Save(c, Path.Combine(Configuration.MyDataSources, c.DisplayName + ".cml"));
      if (!string.IsNullOrEmpty(alternativePath))
        Save(
             c,
             !alternativePath.EndsWith(".cml")
               ? Path.Combine(alternativePath, c.DisplayName + ".cml")
               : alternativePath);
    }

    public override void Execute()
    {
      Crawler.Queries = Queries;
      var output = Crawler.Crawl();
      if (output == null)
        return;

      foreach (var result in output)
        if (result.ContainsKey("Text") && !string.IsNullOrWhiteSpace(result["Text"] as string))
          Output.Enqueue(result);
    }

    public static XpathWebCrawler Load(string path)
    {
      return new XpathWebCrawler
      {
        Crawler = Serializer.DeserializeSharpSerializer(path) as HtmlSearchCrawler,
        _displayName = Path.GetFileNameWithoutExtension(path)
      };
    }

    public void Save(string path)
    {
      Save(this, path);
    }

    private static void Save(XpathWebCrawler xpathWebCrawler, string path)
    {
      Serializer.SerializeXml(xpathWebCrawler.Crawler, path);
    }
  }
}