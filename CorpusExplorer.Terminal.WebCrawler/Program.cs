using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Bcs.IO;
using CorpusExplorer.Sdk.Diagnostic;
using CorpusExplorer.Sdk.Ecosystem;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Crawler;
using CorpusExplorer.Terminal.WebCrawler.Properties;

namespace CorpusExplorer.Terminal.WebCrawler
{
  internal class Program
  {
    private static readonly List<XpathWebCrawler> _crawlers = new List<XpathWebCrawler>();
    private static string _outputPath;
    private static string[] _queries;

    private static bool CheckConfiguration()
    {
      CorpusExplorerEcosystem.InitializeMinimal();

      var appPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
      if (!File.Exists("queries.txt"))
        File.WriteAllLines("queries.txt", new[] { "CorpusExplorer" });

      var files = Directory.GetFiles(appPath, "*.cml");
      if (files.Length > 0)
        return true;

      XpathWebCrawler.Create(
        "notesjor",
        "http://notes.jan-oliver-ruediger.de/page/[PAGE]/?s=[QUERY]",
        1,
        1,
        ".//*[@id='recent-posts']/article/div/div/div/div/h1/a",
        "",
        "",
        new Dictionary<string, string>
        {
          {".//*[@id='recent-posts']/article/div[1]/div/div/div[1]/h1", "Titel"},
          {".//*[@id='recent-posts']/article/div[1]/div/div/div[1]/span", "Datum"},
          {".//*[@id='recent-posts']/article/div[1]/div/div/div[2]/p", "Text"}
        },
        appPath);

      ShowHeader();
      WriteText(Resources.Error_NoCML);
      WriteLine();

      Console.WriteLine("<<< DRÜCKEN SIE ENTER >>>");
      Console.ReadLine();

      return false;
    }

    private static void LoadCrawlers()
    {
      var files = Directory.GetFiles(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "*.cml");
      foreach (var file in files)
        try
        {
          var c = XpathWebCrawler.Load(file);
          _crawlers.Add(c);
          WriteText(c.DisplayName);
        }
        catch (Exception ex)
        {
          InMemoryErrorConsole.Log(ex);
        }
    }

    private static void LoadQueries()
    {
      if (!File.Exists("queries.txt"))
      {
        _queries = new string[0];
        return;
      }

      _queries = FileIO.ReadLines("queries.txt");
      foreach (var query in _queries)
        WriteText(query);
    }

    private static void Main()
    {
      if (!CheckConfiguration())
        return;
      ShowInformation();
      PrepareOutput();
      StartCrawlingProcess();
    }

    private static void PrepareOutput()
    {
      _outputPath = Path.Combine(
        Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "output"),
        DateTime.Now.ToString("yyyy-MM-dd_hh-mm"));
      if (!Directory.Exists(_outputPath))
        Directory.CreateDirectory(_outputPath);
    }

    private static void ShowHeader()
    {
      WriteLine();
      WriteText(Resources.ApplicationHeader);
      WriteLine();
    }

    private static void ShowInformation()
    {
      ShowHeader();
      WriteText(Resources.CrawlerLoaded);
      LoadCrawlers();
      WriteLine();
      WriteText(Resources.QueriesLoaded);
      LoadQueries();
      WriteLine();
      Console.WriteLine("Abfrage läuft...");
    }

    private static void StartCrawlingProcess()
    {
      Parallel.ForEach(_crawlers,
                       crawler =>
                       {
                         try
                         {
                           crawler.Queries = _queries.Where(x => !string.IsNullOrWhiteSpace(x));
                           crawler.Execute();

                           if (crawler.Output.Count <= 0)
                             return;
                           var arr = crawler.Output.ToArray();
                           Serializer.Serialize(arr.ToArray(),
                                                Path.Combine(_outputPath, $"{crawler.DisplayName}.sdd"),
                                                false);
                         }
                         catch (Exception ex)
                         {
                           InMemoryErrorConsole.Log(ex);
                         }
                       });
    }

    private static void WriteLine()
    {
      Console.WriteLine(@"+------------------------------------------------------------+");
    }

    private static void WriteText(string text)
    {
      if (text.Length > 60)
        text = text.Substring(0, 60);

      while (text.Length < 60)
        text = " " + text + " ";

      if (text.Length == 61)
        text = text.Substring(0, 60);

      Console.WriteLine(@"|" + text + @"|");
    }
  }
}