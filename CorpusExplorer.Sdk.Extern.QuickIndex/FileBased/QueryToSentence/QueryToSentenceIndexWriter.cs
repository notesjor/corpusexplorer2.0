using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Adapter.Corpus;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;

namespace CorpusExplorer.Sdk.Extern.QuickIndex.FileBased.QueryToSentence
{
  public class QueryToSentenceIndexWriter
  {
    /// <summary>
    /// Erzeugt einen neuen Index
    /// </summary>
    /// <param name="pathToCec6">Pfad zur CEC6-Datei</param>
    /// <param name="layerDisplayname">Name des Layers für den der Index erstellt werden soll.</param>
    /// <param name="storeDictionary">Soll zusätzlich zum Index das Wörterbuch gespeichert werden? - Reduziert Zugriffsgeschwindigkeit</param>
    /// <param name="storeCec6FuriousIndex">Soll (falls es sich um ein CEC6-Korpus handelt) ein FuriousIndex erstellt werden? - Erhöht Zugriffsgeschwindigkeit</param>
    public static void Create(string pathToCec6, string layerDisplayname, bool storeDictionary = true, bool storeCec6FuriousIndex = true)
    {
      var corpus = CorpusAdapterWriteDirect.Create(pathToCec6);

      var layer = corpus.GetLayers(layerDisplayname).SingleOrDefault();
      if (layer == null)
        return;

      // Speichert falls gewünscht das Dictionary (Token > Index)
      if (storeDictionary)
        using (var fs = new FileStream(pathToCec6 + ".dic", FileMode.Create, FileAccess.Write))
          DictionarySerializerHelper.Serialize(layer.ReciveRawLayerDictionary(), fs);

      // Erstelle ggf. FuriousIndex
      if(storeCec6FuriousIndex && corpus is CorpusAdapterWriteDirect cec6)
        using(var fs = new FileStream(pathToCec6 + ".fi", FileMode.Create, FileAccess.Write))
          Serialize(cec6.GetFuriousIndex(layerDisplayname), fs);

      // Daten vorbereiten
      var positionDict = new Dictionary<int, long>(); // Speichert die Position der Indices
      var indexingDict = new Dictionary<int, Dictionary<Guid, HashSet<int>>>(); // Speichert die Indices
      foreach (var key in layer.ReciveRawReverseLayerDictionary().Keys)
      {
        positionDict.Add(key, -1);
        indexingDict.Add(key, new Dictionary<Guid, HashSet<int>>());
      }

      // Erzeuge Indices
      var layerLock = new object();
      Parallel.ForEach(layer.DocumentGuids, dsel =>
      {
        var doc = layer[dsel];
        var currentDict = new Dictionary<int, HashSet<int>>();

        for (int i = 0; i < doc.Length; i++)
          for (int j = 0; j < doc[i].Length; j++)
            if (currentDict.ContainsKey(doc[i][j]))
              currentDict[doc[i][j]].Add(i);
            else
              currentDict.Add(doc[i][j], new HashSet<int> { i });

        lock (layerLock)
          foreach (var x in currentDict)
            indexingDict[x.Key].Add(dsel, x.Value);
      });

      // Speichere Indices
      using (var fs = new FileStream(pathToCec6 + ".idx", FileMode.Create, FileAccess.Write))
      {
        long position;
        // Speichere Index-Daten
        foreach (var entry in indexingDict)
        {
          position = fs.Position; // Merke Datei-Position des Index
          WriteDictionaryEntry(entry, fs);
          positionDict[entry.Key] = position;
        }

        // Speichere Index-Positions-Daten
        position = fs.Position;
        var bufferInt = new byte[sizeof(int)];
        var bufferLon = new byte[sizeof(long)];
        foreach (var pair in positionDict.OrderBy(x => x.Key)) // Ordnung ist wichtig zur Optimierung
        {
          bufferInt = BitConverter.GetBytes(pair.Key);
          fs.Write(bufferInt, 0, bufferInt.Length);
          bufferLon = BitConverter.GetBytes(pair.Value);
          fs.Write(bufferLon, 0, bufferLon.Length);
        }
        bufferLon = BitConverter.GetBytes(position);
        fs.Write(bufferLon, 0, bufferLon.Length);
      }
    }

    private static void WriteDictionaryEntry(KeyValuePair<int, Dictionary<Guid, HashSet<int>>> entry, Stream stream)
    {
      foreach (var x in entry.Value)
      {
        var bufferGuid = x.Key.ToByteArray();
        stream.Write(bufferGuid, 0, bufferGuid.Length);

        var bufferInt = BitConverter.GetBytes(x.Value.Count);
        stream.Write(bufferInt, 0, bufferInt.Length);
        foreach (var v in x.Value)
        {
          bufferInt = BitConverter.GetBytes(v);
          stream.Write(bufferInt, 0, bufferInt.Length);
        }
      }
      var bufferSplit = Guid.Empty.ToByteArray();
      stream.Write(bufferSplit, 0, bufferSplit.Length);
    }

    public static void Serialize(Dictionary<Guid, long> dict, Stream stream)
    {
      foreach (var x in dict)
      {
        var buffer = x.Key.ToByteArray(); // Konvertiere Guid zu guid-byte[]
        stream.Write(buffer, 0, buffer.Length); // Schreibe guid-byte[]
        var bufferLong = BitConverter.GetBytes(x.Value); // Position zu pos-byte[]
        stream.Write(bufferLong, 0, bufferLong.Length); // Schreibe pos-byte[]
      }

      // Kein SPLIT
    }
  }
}
