#region

using System.Collections.Generic;
using System.Linq;

#endregion

namespace CorpusExplorer.Sdk.Extern.Json.Abstract
{
  public abstract class AbstractGenericDataReader<T>
  {
    public abstract IEnumerable<T> ReadData(string path);

    public IEnumerable<T> ReadData(IEnumerable<string> paths)
    {
      return paths.SelectMany(ReadData);
    }
  }
}