#region

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Db.RocksDb;
using CorpusExplorer.Sdk.Model.Adapter.Layer;

#endregion

namespace CorpusExplorer.Sdk.Extern.QuickIndexRocks.Indices
{
  public static class InverseIndex
  {
    public static void Create(LayerAdapterWriteDirect layer, Dictionary<Guid, long> gdic, string pathToCec6)
    {
      // Daten vorbereiten
      var indexingMeta = new Dictionary<int, long>(); // Speichert die Position der Indices
      var indexingDict = new Dictionary<int, Dictionary<long, HashSet<int>>>(); // Speichert die Indices
      foreach (var key in layer.ReciveRawReverseLayerDictionary().Keys)
      {
        indexingMeta.Add(key, -1);
        indexingDict.Add(key, new Dictionary<long, HashSet<int>>());
      }

      // Erzeuge Indices
      var layerLock = new object();
      Parallel.ForEach(layer.DocumentGuids, dsel =>
      {
        var doc = layer[dsel];
        var currentDict = new Dictionary<int, HashSet<int>>();

        for (var i = 0; i < doc.Length; i++)
        for (var j = 0; j < doc[i].Length; j++)
          if (currentDict.ContainsKey(doc[i][j]))
            currentDict[doc[i][j]].Add(i);
          else
            currentDict.Add(doc[i][j], new HashSet<int> {i});

        lock (layerLock)
        {
          foreach (var x in currentDict)
            indexingDict[x.Key].Add(gdic[dsel], x.Value);
        }
      });

      // Speichere Indices
      using (var fs = new FileStream(pathToCec6 + $"_{layer.Displayname}.idx", FileMode.Create, FileAccess.Write))
      {
        long position;
        // Speichere Index-Daten
        foreach (var entry in indexingDict)
        {
          position = fs.Position; // Merke Datei-Position des Index
          WriteDictionaryEntry(entry.Value, fs);
          indexingMeta[entry.Key] = position;
        }
      }

      Save(pathToCec6, layer.Displayname, ref indexingMeta);
    }

    public static void Save(string pathToCec6, string layerDisplayname, ref Dictionary<int, long> indexingMeta)
    {
      var db = new EasyRocksDb(pathToCec6 + $"_{layerDisplayname}.idxmrRDB", true);
      var cache = new Dictionary<string, string>();

      foreach (var x in indexingMeta)
      {
        cache.Add(x.Key.ToString(), x.Value.ToString());
        if (cache.Count % 10000 == 0)
        {
          db.PutBatch(cache);
          cache.Clear();
        }
      }

      if(cache.Count > 0)
        db.PutBatch(cache);

      cache.Clear();
    }

    public static Dictionary<long, HashSet<int>> GetPositions(string pathToCec6, string layerDisplayname, long position)
    {
      var res = new Dictionary<long, HashSet<int>>();
      var bufferLong = new byte[sizeof(long)];
      var bufferInt = new byte[sizeof(int)];

      using (var stream = new FileStream(pathToCec6 + $"_{layerDisplayname}.idx", FileMode.Open, FileAccess.Read,
                                         FileShare.Read))
      {
        stream.Seek(position, SeekOrigin.Begin);
        while (true)
        {
          stream.Read(bufferLong, 0, bufferLong.Length);
          var pos = BitConverter.ToInt64(bufferLong, 0);
          if (pos == -1)
            break;

          stream.Read(bufferInt, 0, bufferInt.Length);
          var size = BitConverter.ToInt32(bufferInt, 0);
          var hash = new HashSet<int>();
          var buffer = new byte[size * sizeof(int)];
          stream.Read(buffer, 0, buffer.Length);

          for (var i = 0; i < buffer.Length; i += sizeof(int))
            hash.Add(BitConverter.ToInt32(buffer, i));

          res.Add(pos, hash);
        }
      }

      return res;
    }

    public static EasyRocksDb Read(string pathToCec6, string layerDisplayname)
    {
      return new EasyRocksDb(pathToCec6 + $"_{layerDisplayname}.idxmrRDB", false);
    }

    private static void WriteDictionaryEntry(Dictionary<long, HashSet<int>> entry, Stream stream)
    {
      foreach (var x in entry)
      {
        var bufferLng = BitConverter.GetBytes(x.Key);
        stream.Write(bufferLng, 0, bufferLng.Length);

        var bufferInt = BitConverter.GetBytes(x.Value.Count);
        stream.Write(bufferInt, 0, bufferInt.Length);
        foreach (var v in x.Value)
        {
          bufferInt = BitConverter.GetBytes(v);
          stream.Write(bufferInt, 0, bufferInt.Length);
        }
      }

      var bufferSplit = BitConverter.GetBytes((long) -1);
      stream.Write(bufferSplit, 0, bufferSplit.Length);
    }
  }
}