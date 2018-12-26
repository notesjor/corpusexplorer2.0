using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Diagnostic;
using CorpusExplorer.Sdk.Extern.Json.Abstract;
using CorpusExplorer.Sdk.Extern.Json.Wordpress.Model;
using Newtonsoft.Json;

namespace CorpusExplorer.Sdk.Extern.Json.Wordpress.Reader
{
  public sealed class WordpressDataReader : AbstractGenericDataReader<Post>
  {
    public override IEnumerable<Post> ReadData(string path)
    {
      try
      {
        return new[]
        {
          path.StartsWith("{")
            ? JsonConvert.DeserializeObject<Post>(path)
            : JsonConvert.DeserializeObject<Post>(File.ReadAllText(path))
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
