#region

using System.Collections.Generic;

#endregion

namespace CorpusExplorer.Sdk.Extern.Binary.Abstract
{
  public abstract class AbstractGenericDataReader<T>
  {
    public abstract IEnumerable<T> ReadData(string path);
  }
}