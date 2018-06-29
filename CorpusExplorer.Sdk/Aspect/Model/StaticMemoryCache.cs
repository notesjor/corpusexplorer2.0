#region

using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Aspect.Model.Interfaces;

#endregion

namespace CorpusExplorer.Sdk.Aspect.Model
{
  // ReSharper disable once UnusedMember.Global
  public class StaticMemoryCache<T> : ICache<T>
    where T : class
  {
    private static readonly IList<CachedObject<T>> Cache = new List<CachedObject<T>>();
    private readonly TimeSpan _cacheLife;

    public StaticMemoryCache(TimeSpan cacheLife)
    {
      _cacheLife = cacheLife;
    }

    public T this[string key]
    {
      get
      {
        var cacheHit = Cache.FirstOrDefault(c => c.Key == key);
        if (cacheHit == null)
          return null;
        if (DateTime.Now - cacheHit.CachedDate <= _cacheLife)
          return cacheHit.Value;
        Cache.Remove(cacheHit);
        return null;
      }
      set
      {
        var cacheHit = Cache.FirstOrDefault(c => c.Key == key);
        if (cacheHit != null)
          Cache.Remove(cacheHit);
        Cache.Add(new CachedObject<T> {Key = key, Value = value, CachedDate = DateTime.Now});
      }
    }

    private sealed class CachedObject<TO>
      where TO : class
    {
      public DateTime CachedDate { get; set; }
      public string Key { get; set; }
      public TO Value { get; set; }
    }
  }
}