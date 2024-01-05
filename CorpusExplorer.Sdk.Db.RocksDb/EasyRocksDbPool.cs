using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace CorpusExplorer.Sdk.Db.RocksDb
{
  public class EasyRocksDbPool
  {
    private readonly int _waitTimeout;
    private readonly EasyRocksDb[] _pool;
    private ConcurrentQueue<int> _queue = new ConcurrentQueue<int>();

    public EasyRocksDbPool(string rocksDbPath, int poolSize, int waitTimeout = 200)
    {
      _waitTimeout = waitTimeout;
      _pool = new EasyRocksDb[poolSize];
      for (var i = 0; i < poolSize; i++)
      {
        _pool[i] = new EasyRocksDb(rocksDbPath);
        _queue.Enqueue(i);
      }
    }

    /// <summary>
    /// Gibt die unter keys gespeicherten Werte zurück
    /// </summary>
    /// <param name="keys">Schlüssel</param>
    /// <returns>Wert</returns>
    public KeyValuePair<string, string>[] GetBatch(string[] keys)
    {
      if (!_queue.TryDequeue(out var i))
        Thread.Sleep(_waitTimeout);

      KeyValuePair<string, string>[] res = null;
      try
      {
        res = _pool[i].GetBatch(keys);
      }
      catch
      {
        // ignore
      }
      finally
      {
        _queue.Enqueue(i);
      }
      
      return res;
    }
  }
}
