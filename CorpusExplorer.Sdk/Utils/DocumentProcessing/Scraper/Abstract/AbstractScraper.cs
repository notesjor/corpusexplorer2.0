#region

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Diagnostic;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract
{
  public abstract class AbstractScraper : AbstractDocumentProcessingStepFull<string, Dictionary<string, object>>
  {
    public override void Execute()
    {
      var count = Input.Count;
      while (count > 0)
      {
        Parallel.For(
          0,
          count,
          i =>
          {
            try
            {
              string item;
              if (!Input.TryDequeue(out item))
                return;

              var temp = Execute(item);
              if (temp == null)
                return;
              foreach (var t in temp)
                Output.Enqueue(t);
            }
            catch (Exception ex)
            {
              InMemoryErrorConsole.Log(ex);
            }
          });
        count = Input.Count;
      }
    }

    protected abstract IEnumerable<Dictionary<string, object>> Execute(string file);
  }
}