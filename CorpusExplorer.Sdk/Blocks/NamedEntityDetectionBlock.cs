using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;

namespace CorpusExplorer.Sdk.Blocks
{
  public class NamedEntityDetectionBlock : AbstractSimple2LayerBlock
  {
    private readonly object _layerDictionaryLock = new object();

    private readonly object _neLock = new object();
    private Dictionary<Guid, HashSet<int>> _layerDictionary;
    private Dictionary<string, HashSet<string>> _namedEntitiesItemsLinks;

    public NamedEntityDetectionBlock()
    {
      Layer1Displayname = "Wort";
      Layer2Displayname = "POS";

      Layer2Values = new[] {"NE"};
    }

    public IEnumerable<string> Layer2Values { get; set; }

    public Dictionary<string, double> NamedEntities { get; set; }

    public Dictionary<string, HashSet<string>> NamedEntitiesItems { get; set; }

    /// <summary>
    ///   F�hrt die Berechnung aus
    /// </summary>
    /// <param name="corpus">
    ///   Korpus
    /// </param>
    /// <param name="dsel">
    ///   Dokument GUID
    /// </param>
    /// <param name="layer1">
    ///   Layer 1
    /// </param>
    /// <param name="doc1">
    ///   Dokument 1
    /// </param>
    /// <param name="layer2">
    ///   Layer 2
    /// </param>
    /// <param name="doc2">
    ///   Dokument 2
    /// </param>
    protected override void CalculateCall(
      AbstractCorpusAdapter corpus,
      Guid dsel,
      AbstractLayerAdapter layer1,
      int[][] doc1,
      AbstractLayerAdapter layer2,
      int[][] doc2)
    {
      HashSet<int> dic;
      lock (_layerDictionaryLock)
      {
        if (_layerDictionary.ContainsKey(layer2.Guid))
        {
          dic = _layerDictionary[layer2.Guid];
        }
        else
        {
          dic = new HashSet<int>();
          foreach (var layer2Value in Layer2Values)
            dic.Add(layer2[layer2Value]);
          _layerDictionary.Add(layer2.Guid, dic);
        }
      }

      var items = new List<string>();
      var isentity = false;

      for (var i = 0; i < doc2.Length; i++)
      for (var j = 0; j < doc2[i].Length; j++)
        if (dic.Contains(doc2[i][j]))
        {
          items.Add(layer1[doc1[i][j]]);
          isentity = true;
        }
        else if (isentity)
        {
          if (items.Count > 1)
          {
            var key = string.Join(" ", items);
            lock (_neLock)
            {
              if (NamedEntities.ContainsKey(key))
              {
                NamedEntities[key]++;
              }
              else
              {
                NamedEntities.Add(key, 1);
                NamedEntitiesItems.Add(key, new HashSet<string>(items));
                foreach (var item in items)
                  if (_namedEntitiesItemsLinks.ContainsKey(item))
                    _namedEntitiesItemsLinks[item].Add(key);
                  else
                    _namedEntitiesItemsLinks.Add(item, new HashSet<string> {key});
              }
            }
            items.Clear();
          }
          isentity = false;
        }
    }

    /// <summary>
    ///   Wird nach der Berechnung aufgerufen (nach CalculateCall)
    ///   und dient der Bereinigung von Daten
    /// </summary>
    protected override void CalculateCleanup()
    {
      // Simple Cleanup - Step 1
      _layerDictionary = null;

      // Complex Cleanup - Changes for Merge - Step 2
      var changes = new Dictionary<string, string>();
      foreach (var link in _namedEntitiesItemsLinks)
      foreach (var k1 in link.Value)
        if (!changes.ContainsKey(k1))
          foreach (
            var k2 in
            link.Value.Where(k2 => !k1.Equals(k2))
                .Where(k2 => NamedEntitiesItems[k1].All(v => NamedEntitiesItems[k2].Contains(v))))
          {
            changes.Add(k1, k2);
            break;
          }

      // Resolve Dependencies - Step 3
      var keys = changes.Keys.ToArray();
      bool changed;
      do
      {
        changed = false;
        foreach (
          var key in
          keys.Where(key => changes.ContainsKey(changes[key]))
              .Where(key => !changes[key].Equals(changes[changes[key]])))
        {
          changes[key] = changes[changes[key]];
          changed = true;
        }
      }
      while (changed);

      // Merge - Step 4
      foreach (var change in changes)
        NamedEntities[change.Value] += NamedEntities[change.Key];

      // Clean - Step 5
      foreach (var change in changes)
      {
        NamedEntitiesItems.Remove(change.Key);
        NamedEntities.Remove(change.Key);
      }

      // Simple Cleanup - Step 6
      _namedEntitiesItemsLinks = null;
    }

    /// <summary>
    ///   Wird nach der Bereinigung aufgerufen (nach CalculateCall + CalculateCleanup)
    ///   und dient dem zusammenfassen der bereinigen Ergebnisse
    /// </summary>
    protected override void CalculateFinalize() { }

    /// <summary>
    ///   Wird vor der Berechnung aufgerufen (vor CalculateCall)
    /// </summary>
    protected override void CalculateInitProperties()
    {
      NamedEntities = new Dictionary<string, double>();
      NamedEntitiesItems = new Dictionary<string, HashSet<string>>();

      _layerDictionary = new Dictionary<Guid, HashSet<int>>();
      _namedEntitiesItemsLinks = new Dictionary<string, HashSet<string>>();
    }

    private byte[] MakeKeyMd5(MD5 hash, HashSet<string> items)
    {
      var list = new List<string>(items);
      list.Sort();
      return hash.ComputeHash(Configuration.Encoding.GetBytes(string.Join("|", list)));
    }

    private byte[] MakeKeySha512(SHA512 hash, HashSet<string> items)
    {
      var list = new List<string>(items);
      list.Sort();
      return hash.ComputeHash(Configuration.Encoding.GetBytes(string.Join("|", list)));
    }
  }
}