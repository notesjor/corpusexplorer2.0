using System;
using System.Collections.Generic;
using System.IO;
using CorpusExplorer.Sdk.Diagnostic;
using CorpusExplorer.Sdk.Extern.Json.Abstract;
using CorpusExplorer.Sdk.Extern.Json.TwitterStatus.Model;
using Newtonsoft.Json;

namespace CorpusExplorer.Sdk.Extern.Json.TwitterStatus.Reader
{
  public class TwitterStatusReader : AbstractGenericDataReader<Tweet>
  {
    public override IEnumerable<Tweet> ReadData(string path)
    {
      try
      {
        return new[]
        {
          path.StartsWith("{")
            ? JsonConvert.DeserializeObject<Tweet>(path)
            : JsonConvert.DeserializeObject<Tweet>(File.ReadAllText(path))
        };
      }
      catch (Exception ex)
      {
        InMemoryErrorConsole.Log(ex);
        return null;
      }
    }
  }
}