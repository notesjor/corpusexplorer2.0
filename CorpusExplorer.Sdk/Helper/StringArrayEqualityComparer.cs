#region

using System.Collections;
using System.Collections.Generic;

#endregion

namespace CorpusExplorer.Sdk.Helper
{
  public class StringArrayEqualityComparer : IEqualityComparer<string[]>
  {
    public bool Equals(string[] x, string[] y)
    {
      return ((IStructuralEquatable) x).Equals(y, EqualityComparer<string>.Default);
    }

    public int GetHashCode(string[] obj)
    {
      if (obj == null)
        return -1;
      return obj.GetHashCode();
    }
  }
}