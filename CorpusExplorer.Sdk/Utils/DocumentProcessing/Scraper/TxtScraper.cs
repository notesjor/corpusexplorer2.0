#region

using System.Collections.Generic;
using System.IO;
using Bcs.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper
{
  public sealed class TxtScraper : AbstractScraper
  {
    public override string DisplayName => "TXT";

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      return new List<Dictionary<string, object>>
      {
        new Dictionary<string, object>
        {
          {
            "Text",
            FileIO.ReadText(file, Configuration.Encoding)
          },
          {
            "Titel", Path.GetFileNameWithoutExtension(file)
          }
        }
      };
    }
  }
}