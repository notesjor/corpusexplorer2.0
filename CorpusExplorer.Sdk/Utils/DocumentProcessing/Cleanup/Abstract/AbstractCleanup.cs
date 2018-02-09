#region

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
          i =>
          {
            Dictionary<string, object> doc;
            if (!Input.TryDequeue(out doc))
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

                var text = doc.Get(key, "");

                // Nur Bereingung von Text zulassen, DateTime und andere Typen müssen via Scraper definiert/berinigt werden.
                if (text.GetType() != typeof(string) ||
                    string.IsNullOrEmpty(text))
                  continue;

                text = Execute(text);

                // Schütze vor fehlerhafte Bereinigung - nehme im Fehlerfall den Orignaltext
                if (string.IsNullOrEmpty(text))
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

    protected abstract string Execute(string input);
  }
}