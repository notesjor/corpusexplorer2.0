using System.Collections.Generic;
using System.IO;
using System.Linq;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Extern.Json.SimpleStandoff.Model;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;
using Newtonsoft.Json;

namespace CorpusExplorer.Sdk.Extern.Json.SimpleStandoff
{
  public class SimpleJsonStandoffScraper : AbstractScraper
  {
    public override string DisplayName => "Einfaches JSON-StandOff";

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      var document = JsonConvert.DeserializeObject<Document>(File.ReadAllText(file, Configuration.Encoding));
      if (document == null)
        return null;

      var res = document.Metadata ?? new Dictionary<string, object>();
      if (!res.ContainsKey("Text"))
        res.Add("Text", "");

      if (!string.IsNullOrEmpty(document.Text))
      {
        res["Text"] = document.Text;
        return new[] { res };
      }

      if (document.TextToken != null)
      {
        res["Text"] = string.Join(" ", document.TextToken);
        return new[] { res };
      }

      // ReSharper disable once InvertIf
      if (document.TextSentenceToken != null)
      {
        res["Text"] = string.Join("\r\n", document.TextSentenceToken.Select(s => string.Join(" ", s)));
        return new[] { res };
      }

      return null;
    }
  }
}
