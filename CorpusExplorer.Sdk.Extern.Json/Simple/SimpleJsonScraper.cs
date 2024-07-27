using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CorpusExplorer.Sdk.Extern.Json.Simple
{
  public class SimpleJsonScraper : AbstractScraper
  {
    public override string DisplayName => "Einfaches JSON-Dokument";

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      var text = File.ReadAllText(file, Configuration.Encoding);

      if (IsArray(ref text))
      {
        var res = JsonConvert.DeserializeObject<Dictionary<string, object>[]>(text);
        if (res == null)
          return null;

        foreach (var x in res)
        {
          if (x.ContainsKey("text"))
          {
            x.Add("Text", x["text"]);
            x.Remove("text");
          }

          if (!x.ContainsKey("Pfad"))
            x.Add("Pfad", file);
        }

        return res;
      }
      else
      {
        var res = JsonConvert.DeserializeObject<Dictionary<string, object>>(text);
        if (res == null)
          return null;

        if (res.ContainsKey("text"))
        {
          res.Add("Text", res["text"]);
          res.Remove("text");
        }

        if (!res.ContainsKey("Pfad"))
          res.Add("Pfad", file);

        return new[] { res };
      }

    }

    private bool IsArray(ref string text)
    {
      var res = JsonConvert.DeserializeObject<object>(text);
      return res is JArray;
    }
  }
}
