#region

using System.Collections.Generic;
using System.IO;
using CorpusExplorer.Sdk.Extern.Json.Abstract;
using CorpusExplorer.Sdk.Extern.Json.YourTwapperKeeper.Model;
using Newtonsoft.Json;

#endregion

namespace CorpusExplorer.Sdk.Extern.Json.YourTwapperKeeper.Reader
{
  public class TwapperCorpusReader : AbstractGenericDataReader<TwapperCorpus>
  {
    public override IEnumerable<TwapperCorpus> ReadData(string path)
    {
      return new[] {JsonConvert.DeserializeObject<TwapperCorpus>(File.ReadAllText(path))};
    }
  }
}