using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpusExplorer.Sdk.Db.RocksDb
{
  public class EasyRocksDbBatchWriter : IDisposable
  {
    private readonly EasyRocksDb _rdb;
    private readonly EasyRocksDbBatchWriterConcurrentDelegate _func;
    private object _cacheLock = new object();
    private int _cacheSize;
    private readonly Dictionary<string, string> _cache;

    public EasyRocksDbBatchWriter(EasyRocksDb rdb, EasyRocksDbBatchWriterConcurrentDelegate func, int cacheSize = 10000)
    {
      _rdb = rdb ?? throw new ArgumentNullException(nameof(rdb));
      _func = func ?? throw new ArgumentNullException(nameof(func));
      _cacheSize = cacheSize;
      _cache = new Dictionary<string, string>();
    }

    public delegate string EasyRocksDbBatchWriterConcurrentDelegate(string oldValue, string newValue);

    public void Add(string key, string value)
    {
      lock (_cacheLock)
      {
        if (_cache.ContainsKey(key))
          _cache[key] = _func(_cache[key], value);
        else
          _cache.Add(key, value);

        if (_cache.Count > _cacheSize)
          Flush();
      }
    }

    private void Flush()
    {
      try
      {
        lock (_cacheLock)
        {
          var keys = _cache.Keys.ToArray();
          var data = _rdb.GetBatch(keys).ToDictionary(x => x.Key, x => x.Value);

          foreach (var key in keys)
            data[key] = _func(data[key], _cache[key]);

          _rdb.PutBatch(data);
        }
      }
      catch (OutOfMemoryException)
      {
        _cacheSize /= 10;
        if (_cacheSize < 1)
          _cacheSize = 1;
      }
      catch
      {
        // ignore
      }
    }

    public void Dispose()
    {
      Flush();
      _rdb.Dispose();
    }
  }
}
