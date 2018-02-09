#region

using System;
using System.Collections.Generic;
using System.IO;
using CorpusExplorer.Sdk.Diagnostic;
using CorpusExplorer.Sdk.Extern.Json.Abstract;
using CorpusExplorer.Sdk.Extern.Json.TwitterStream.Model;
using Newtonsoft.Json;

#endregion

namespace CorpusExplorer.Sdk.Extern.Json.TwitterStream.Reader
{
  public sealed class TwitterDataReader : AbstractGenericDataReader<StreamMessage>
  {
    public override IEnumerable<StreamMessage> ReadData(string path)
    {
      try
      {
        return new[]
        {
          path.StartsWith("{")
            ? JsonConvert.DeserializeObject<StreamMessage>(path)
            : JsonConvert.DeserializeObject<StreamMessage>(File.ReadAllText(path))
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