#region

using System.Collections;
using System.Collections.Generic;
using System.Linq;

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
      unchecked
      {
        return obj.Aggregate(1, (current, s) => current * s.GetHashCode());
      }
    }
  }
}