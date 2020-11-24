using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpusExplorer.Terminal.Automate.Helper
{
  public static class AddonRepositoryEntriesToDictionaryHelper
  {
    public static Dictionary<string, T> Convert<T>(this IEnumerable<KeyValuePair<string, T>> addons)
    {
      try
      {
        return addons.ToDictionary(x => x.Key?.Split('|')[0], x => x.Value);
      }
      catch
      {
        return new Dictionary<string, T>();
      }
    }
  }
}
