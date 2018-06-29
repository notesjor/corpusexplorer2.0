using System.Collections.Generic;
using CorpusExplorer.Sdk.Model;

namespace CorpusExplorer.Sdk.Helper
{
  public class SelectionEqualityComparer : IEqualityComparer<Selection>
  {
    public bool Equals(Selection x, Selection y)
    {
      return x.Guid == y.Guid;
    }

    public int GetHashCode(Selection obj)
    {
      return obj.GetHashCode();
    }
  }
}