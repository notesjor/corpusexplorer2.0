#region

using System.Collections.Generic;
using System.IO;
using System.Text;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;

#endregion

namespace CorpusExplorer.Core.DocumentProcessing.Scraper.Txt
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
            File.ReadAllText(file, Configuration.Encoding)
          },
          {
            "Titel", Path.GetFileNameWithoutExtension(file)
          }
        }
      };
    }
  }
}