using System.Collections.Generic;
using Bcs.IO;
using CorpusExplorer.Sdk.Extern.Json.Abstract;
using Newtonsoft.Json;

namespace CorpusExplorer.Sdk.Extern.Json.Speedy
{
  public class SpeedyDataReader : AbstractGenericDataReader<Model.Speedy>
  {
    public override IEnumerable<Model.Speedy> ReadData(string path)
      => new[] { JsonConvert.DeserializeObject<Model.Speedy>(FileIO.ReadText(path)) };
  }
}