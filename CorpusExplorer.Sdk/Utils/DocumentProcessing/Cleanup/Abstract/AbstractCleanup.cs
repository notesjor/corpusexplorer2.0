﻿#region

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Model.Extension;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Cleanup.Abstract
{
  public abstract class AbstractCleanup :
    AbstractDocumentProcessingStepFull<Dictionary<string, object>, Dictionary<string, object>>
  {
    public override void Execute()
    {
      var count = Input.Count;
      while (count > 0)
      {
        Parallel.For(
                     0,
                     count,
                     Configuration.ParallelOptions,
                     i =>
                     {
                       if (!Input.TryDequeue(out var doc))
                         return;
                       if (doc?.Keys == null)
                         return;
                       if (string.IsNullOrWhiteSpace(doc.Get("Text", "")))
                         return;

                       var keys = doc.Keys.ToArray();
                       foreach (var key in keys)
                         try
                         {
                           if (key.StartsWith("!"))
                             continue;

                           var text = doc.Get(key, string.Empty);

                           // Nur Bereingung von Text zulassen, DateTime und andere Typen müssen via Scraper definiert/berinigt werden.
                           if (text?.GetType() != typeof(string) || string.IsNullOrWhiteSpace(text))
                             continue;

                           text = Execute(key, text);

                           // Schütze vor fehlerhafte Bereinigung - nehme im Fehlerfall den Orignaltext
                           if (string.IsNullOrWhiteSpace(text))
                             continue;

                           doc[key] = text;
                         }
                         catch
                         {
                           // ignore
                         }

                       Output.Enqueue(doc);
                     });
        count = Input.Count;
      }
    }

    protected abstract string Execute(string key, string input);
  }
}