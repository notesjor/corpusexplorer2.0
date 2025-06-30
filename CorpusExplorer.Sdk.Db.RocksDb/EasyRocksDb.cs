using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RocksDbSharp;

namespace CorpusExplorer.Sdk.Db.RocksDb
{
  public class EasyRocksDb : IDisposable
  {
    private RocksDbSharp.RocksDb _db;

    /// <summary>
    /// Gibt den unter key gespeicherten Wert in einer Datenbank zurück
    /// </summary>
    /// <param name="dbTemplate">Vorlage für dbFullname - muss {NAME} enthalten (wird durch dbName ersetzt).</param>
    /// <param name="dbName">Ersetzt {NAME} in dbTemplate</param>
    /// <param name="key">Schlüssel</param>
    /// <returns>Wert</returns>
    public static string Get(string dbTemplate, string dbName, string key)
      => Get(dbTemplate.Replace("{NAME}", dbName), key);

    /// <summary>
    /// Gibt den unter key gespeicherten Wert in einer Datenbank zurück
    /// </summary>
    /// <param name="dbFullname">Voller Datenbankname</param>
    /// <param name="key">Schlüssel</param>
    /// <returns>Wert</returns>
    private static string Get(string dbFullname, string key)
    {
      using (var db = RocksDbSharp.RocksDb.Open(new DbOptions().SetCreateIfMissing(false), dbFullname))
        return db.Get(key, encoding: Encoding.UTF8);
    }

    /// <summary>
    /// Stellt eine einfache Verbindung zu einer RocksDB-Datenbank her.
    /// </summary>
    /// <param name="dbTemplate">Vorlage für dbFullname - muss {NAME} enthalten (wird durch dbName ersetzt).</param>
    /// <param name="dbName">Ersetzt {NAME} in dbTemplate</param>
    /// <param name="enablePut">Aktiviert den Schreibzugriff</param>
    /// <param name="keepLogFiles">Behalte Log-Files</param>
    public EasyRocksDb(string dbTemplate, string dbName, bool enablePut = false, ulong keepLogFiles = 5) : this(dbTemplate.Replace("{NAME}", dbName), enablePut, keepLogFiles){}
    
    /// <summary>
    /// Stellt eine einfache Verbindung zu einer RocksDB-Datenbank her.
    /// </summary>
    /// <param name="dbFullname">Voller Datenbankname</param>
    /// <param name="enablePut">Aktiviert den Schreibzugriff</param>
    /// <param name="keepLogFiles">Behalte Log-Files</param>
    public EasyRocksDb(string dbFullname, bool enablePut = false, ulong keepLogFiles = 5)
    {
      if(keepLogFiles < 1)
        keepLogFiles = 1;
      Path = dbFullname;
      _db = enablePut
              ? RocksDbSharp.RocksDb.Open(new DbOptions().SetCreateIfMissing(true).SetKeepLogFileNum(keepLogFiles).PrepareForBulkLoad(), dbFullname) 
              : RocksDbSharp.RocksDb.OpenReadOnly(new DbOptions().SetCreateIfMissing(false), dbFullname, false);
    }

    /// <summary>
    /// Pfad zur Datenbank
    /// </summary>
    public string Path { get; }

    /// <summary>
    /// Gibt den unter key gespeicherten Wert zurück
    /// </summary>
    /// <param name="key">Schlüssel</param>
    /// <returns>Wert</returns>
    public string Get(string key)
    {
      try
      {
        return _db.Get(key, encoding: Encoding.UTF8);
      }
      catch
      {
        return null;
      }
    }

    /// <summary>
    /// Gibt die unter keys gespeicherten Werte zurück
    /// </summary>
    /// <param name="keys">Schlüssel</param>
    /// <returns>Wert</returns>
    public KeyValuePair<string, string>[] GetBatch(string[] keys)
    {
      try
      {
        return _db.MultiGet(keys);
      }
      catch
      {
        return null;
      }
    }

    /// <summary>
    /// Gibt die unter keys gespeicherten Werte zurück
    /// </summary>
    /// <param name="keys">Schlüssel</param>
    /// <returns>Wert</returns>
    public List<KeyValuePair<string, string>> GetBatchPaged(string[] keys, int pageSize = 10000)
    {
      try
      {
        var current = 0;
        var res = new List<KeyValuePair<string, string>>(keys.Length);

        while(current < keys.Length)
        {
          res.AddRange(_db.MultiGet(keys.Skip(0).Take(pageSize).ToArray()));
          current += pageSize;
        }

        return res;
      }
      catch
      {
        return null;
      }
    }

    /// <summary>
    /// Listet alle Keys der RocksDb
    /// </summary>
    public IEnumerable<string> Keys
    {
      get
      {
        try
        {
          var res = new List<string>();

          var iterator = _db.NewIterator(null, new ReadOptions());
          iterator.SeekToFirst();
          while (iterator.Valid())
          {
            res.Add(Encoding.UTF8.GetString(iterator.Key()));
            iterator.Next();
          }

          return res;
        }
        catch
        {
          return null;
        }
      }
    }

    /// <summary>
    /// Speichert einen Wert in der Datenbank
    /// </summary>
    /// <param name="key">Key</param>
    /// <param name="value">Wert</param>
    public void Put(string key, string value)
    {
      try
      {
        _db.Put(key, value, encoding: Encoding.UTF8);
      }
      catch
      {
        // ignore
      }
    }

    /// <summary>
    /// Speichert eine Sammlung von Key/Value-Paaren in der Datenbank
    /// </summary>
    /// <param name="data">zu speichernde Daten</param>
    public void PutBatch(Dictionary<string, string> data)
    {
      try
      {
        var batch = new WriteBatch();
        foreach (var x in data)
          batch.Put(x.Key, x.Value, encoding: Encoding.UTF8);
        _db.Write(batch);
      }
      catch
      {
        // ignore
      }
    }

    /// <summary>
    /// Löscht einen Key
    /// </summary>
    /// <param name="key">Key</param>
    /// <returns>Löschen erfolgreich?</returns>
    public bool Remove(string key)
    {
      try
      {
        _db.Remove(key);
        return true;
      }
      catch
      {
        return false;
      }
    }

    public void Dispose()
    {
      _db?.Dispose();
    }

    public void CompactRange()
    {
      _db.CompactRange(null, null, null);
    }
  }
}
