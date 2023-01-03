using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.Abstract;
using CorpusExplorer.Terminal.Universal.Message.Request.Corpus;
using CorpusExplorer.Terminal.Universal.Message.Response.Corpus;
using Tfres;

namespace CorpusExplorer.Terminal.Universal
{
  public static partial class Program
  {
    private static void CorpusAnnotate(HttpContext obj)
    {
      throw new NotImplementedException();
      var res = new Dictionary<Guid, string>(); // Rückgabe von corpus.DocumentGuidAndDisplaynames notwendig
      _terminal.Project.SelectAll.Displayname = "ALL";
    }

    private static void CorpusAnnotateFormatOptions(HttpContext obj)
    {
      obj.Response.Send(new ResponseCorpusFormatAnnotate
      {
        Scraper = Configuration.AddonScrapers.Select(MakeScraperFormat).ToArray(),
        Tagger = Configuration.AddonTaggers.Select(MakeTaggerFormat).ToArray()
      });
    }

    private static ResponseCorpusAnnotateTagger MakeTaggerFormat(AbstractTagger entry)
    {
      return new ResponseCorpusAnnotateTagger
      {
        Id = entry.GetType().Name.Replace("Tagger", ""),
        DisplayName = entry.DisplayName,
        LanguagesAvailable = entry.LanguagesAvailabel.ToArray()
      };
    }

    private static ResponseCorpusAnnotateScraper MakeScraperFormat(KeyValuePair<string, AbstractScraper> entry)
    {
      var split = entry.Key.Split("|");
      return new ResponseCorpusAnnotateScraper
      {
        Id = entry.Value.GetType().Name.Replace("Scraper", ""),
        DisplayName = split[0],
        Extensions = split[1].Split(';')
                             .Where(x => x.Length > 1)
                             .Select(x => x.Replace("*", "")).ToArray()
      };
    }

    private static void CorpusImport(HttpContext obj)
    {
      try
      {
        var request = obj.Request.PostData<RequestCorpus>();
        var importer = Configuration.AddonImporters.GetReflectedType(request.Format, "Importer");
        if (importer == null)
        {
          obj.Response.Send(HttpStatusCode.NotFound);
          return;
        }

        var res = new Dictionary<Guid, string>();
        foreach (var corpus in importer.Execute(request.Paths))
        {
          _terminal.Project.Add(corpus);
          foreach(var x in corpus.DocumentGuidAndDisplaynames)
            res.Add(x.Key, x.Value);
        }

        _terminal.Project.SelectAll.Displayname = "ALL";
        obj.Response.Send(res);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message); // DEBUG
      }
    }

    private static void CorpusImportFormatOptions(HttpContext obj)
    {
      obj.Response.Send(Configuration.AddonImporters.Select(MakeImportFormat));
    }

    private static ResponseCorpusFormatImport MakeImportFormat(KeyValuePair<string, AbstractImporter> entry)
    {
      var split = entry.Key.Split("|");
      return new ResponseCorpusFormatImport
      {
        Id = entry.Value.GetType().Name.Replace("Importer", ""),
        DisplayName = split[0],
        Extensions = split[1].Split(';')
                             .Where(x => x.Length > 1)
                             .Select(x => x.Replace("*", "")).ToArray()
      };
    }
  }
}
