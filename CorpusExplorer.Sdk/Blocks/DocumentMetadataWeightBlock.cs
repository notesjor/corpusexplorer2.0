#region

using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using CorpusExplorer.Sdk.Properties;

#endregion

namespace CorpusExplorer.Sdk.Blocks
{
  /// <summary>
  ///   Class DocumentMetadataWeightBlock.
  /// </summary>
  [Serializable]
  public class DocumentMetadataWeightBlock : AbstractSimple1LayerBlock
  {
    [NonSerialized] private object _lockDocument;

    /// <summary>
    ///   The _lock document metasize
    /// </summary>
    [NonSerialized] private object _lockMetadata;

    private Dictionary<Guid, double> _token;
    private Dictionary<Guid, int> _types;

    /// <summary>
    ///   Dictionary mit den Dokumentgrößen. Key = DocumentGuid / Value[0] = Token / Value[1] = Type
    /// </summary>
    /// <value>Key = DocumentGuid / Value[0] = Token / Value[1] = Type</value>
    public Dictionary<Guid, int[]> DocumentSize { get; set; }

    public Dictionary<string, Dictionary<string, HashSet<Guid>>> MetaDataDictionary { get; set; }

    /// <summary>
    ///   Gibt ein aggergiertes Dictionary zurück das alle Metawerte enthält.
    /// </summary>
    /// <returns>
    ///   Dictionary.Key = Bezeichnung / Dictionary.Value.Key = Wert / Dictionary.Value.Value [0] = token /
    ///   [1] = type / [2] = Dokumente
    /// </returns>
    public Dictionary<string, Dictionary<string, double[]>> GetAggregatedRelativeSize()
    {
      var data = GetAggregatedSize();

      // ReSharper disable SuggestVarOrType_BuiltInTypes
      var tokens = data.SelectMany(d => d.Value).Sum(v => v.Value[0]);
      var types = data.SelectMany(d => d.Value).Sum(v => v.Value[1]);
      var docs = data.SelectMany(d => d.Value).Sum(v => v.Value[2]);
      // ReSharper restore SuggestVarOrType_BuiltInTypes

      return data.ToDictionary(
                               x => x.Key,
                               x => x.Value.ToDictionary(y => y.Key,
                                                         y => new[]
                                                         {
                                                           y.Value[0] / tokens, y.Value[1] / types, y.Value[2] / docs
                                                         }));
    }

    /// <summary>
    ///   Gibt ein aggergiertes Dictionary zurück das alle Metawerte enthält.
    /// </summary>
    /// <returns>
    ///   Dictionary.Key = Kategorie / Dictionary.Value.Value [0] = token /
    ///   [1] = type / [2] = Dokumente
    /// </returns>
    public Dictionary<string, double[]> GetAggregatedRelativeSize(string category)
    {
      var data = GetAggregatedSize(category);

      double tokens = data.Sum(v => v.Value[0]);
      double types = data.Sum(v => v.Value[1]);
      double docs = data.Sum(v => v.Value[2]);

      return data.ToDictionary(x => x.Key, x => new[] { x.Value[0] / tokens, x.Value[1] / types, x.Value[2] / docs });
    }

    /// <summary>
    ///   Aggregiert die Dokumentengrößen nach zwei gegebenen Gruppen.
    /// </summary>
    /// <param name="categoryA">Gruppe A</param>
    /// <param name="categoryB">Gruppe B</param>
    /// <returns>
    ///   Dictionary.Key = Wert Gruppe A / Dictionary.Value.Key = Wert Gruppe B / Dictionary.Value.Value [0] = token /
    ///   [1] = type / [2] = Dokumente
    /// </returns>
    /// <exception cref="System.ArgumentOutOfRangeException">
    ///   categoryA;Der Parameter ist keine gültige Metaangabe
    ///   or
    ///   categoryB;Der Parameter ist keine gültige Metaangabe
    /// </exception>
    public Dictionary<string, Dictionary<string, int[]>> GetAggregatedSize(string categoryA, string categoryB)
    {
      if (!MetaDataDictionary.ContainsKey(categoryA))
        throw new ArgumentOutOfRangeException(Resources.CategoryA, Resources.MetaErrorNoValidValue);
      if (!MetaDataDictionary.ContainsKey(categoryB))
        throw new ArgumentOutOfRangeException(Resources.CategoryB, Resources.MetaErrorNoValidValue);

      var cA = from x in MetaDataDictionary where x.Key == categoryA from k in x.Value select k.Key;
      var cB = (from x in MetaDataDictionary where x.Key == categoryB from k in x.Value select k.Key).ToArray();

      var res = new Dictionary<string, Dictionary<string, int[]>>();

      foreach (var a in cA)
        foreach (var b in cB)
        {
          var docA = MetaDataDictionary[categoryA][a];
          var docB = MetaDataDictionary[categoryB][b];

          var cross = docA.Where(docB.Contains);
          var results = new[] { 0, 0, 0 };

          foreach (var values in from guid in cross where DocumentSize.ContainsKey(guid) select DocumentSize[guid])
          {
            results[0] += values[0];
            results[1] += values[1];
            results[2]++;
          }

          if (res.ContainsKey(a))
            res[a].Add(b, results);
          else
            res.Add(a, new Dictionary<string, int[]> { { b, results } });
        }

      return res;
    }

    /// <summary>
    ///   Aggregiert die Dokumentengrößen nach zwei gegebenen Gruppen.
    /// </summary>
    /// <param name="category">Kategorie</param>
    /// <returns>
    ///   Dictionary.Key = Kategorie / Dictionary.Value.Value [0] = token /
    ///   [1] = type / [2] = Dokumente
    /// </returns>
    /// <exception cref="System.ArgumentOutOfRangeException">
    ///   categoryA;Der Parameter ist keine gültige Metaangabe
    ///   or
    ///   categoryB;Der Parameter ist keine gültige Metaangabe
    /// </exception>
    public Dictionary<string, int[]> GetAggregatedSize(string category)
    {
      if (!MetaDataDictionary.ContainsKey(category))
        throw new ArgumentOutOfRangeException(Resources.CategoryA, Resources.MetaErrorNoValidValue);

      var res = new Dictionary<string, int[]>();
      if (!MetaDataDictionary.ContainsKey(category))
        return res;

      foreach (var x in MetaDataDictionary[category])
      {
        var sumA = new[] { 0, 0, 0 };
        foreach (var guid in x.Value)
        {
          sumA[0] += DocumentSize[guid][0];
          sumA[1] += DocumentSize[guid][1];
          sumA[2]++;
        }

        res.Add(x.Key, sumA);
      }

      return res;
    }

    /// <summary>
    ///   Gibt ein aggergiertes Dictionary zurück das alle Metawerte enthält.
    ///   Aus Performancegründen wird empfohlen die überladene Version dieser Funktion zu nutzen (GetAggregatedSize(categoryA,
    ///   categoryB))
    /// </summary>
    /// <returns>
    ///   Dictionary.Key = Wert Gruppe A / Dictionary.Value.Key = Wert Gruppe B / Dictionary.Value.Value [0] = token /
    ///   [1] = type / [2] = Dokumente
    /// </returns>
    public Dictionary<string, Dictionary<string, double[]>> GetAggregatedSize()
    {
      var res = new Dictionary<string, Dictionary<string, double[]>>();

      foreach (var x in MetaDataDictionary)
      {
        var xDic = new Dictionary<string, double[]>();
        foreach (var y in x.Value)
        {
          var yArr = new double[] { 0, 0, 0 };
          foreach (var val in y.Value.Select(z => DocumentSize[z]))
          {
            yArr[0] += val[0];
            yArr[1] += val[1];
            yArr[2]++;
          }

          xDic.Add(y.Key, yArr);
        }

        res.Add(x.Key, xDic);
      }

      return res;
    }

    /// <summary>
    ///   Gibt ein aggergiertes Dictionary zurück das alle Metawerte enthält.
    ///   Aus Performancegründen wird empfohlen die überladene Version dieser Funktion zu nutzen (GetAggregatedSize(categoryA,
    ///   categoryB))
    /// </summary>
    /// <returns>
    ///   Dictionary.Key = Wert Gruppe A / Dictionary.Value.Key = Wert Gruppe B / Dictionary.Value.Value [0] = token /
    ///   [1] = type / [2] = Dokumente
    /// </returns>
    public Dictionary<string, Dictionary<string, double[]>> GetUrlShrinkedAggregatedSize()
    {
      var res = new Dictionary<string, Dictionary<string, double[]>>();

      foreach (var x in MetaDataDictionary)
      {
        var xDic = new Dictionary<string, double[]>();
        foreach (var y in x.Value)
        {
          var yArr = new double[] { 0, 0, 0 };
          foreach (var val in y.Value.Select(z => DocumentSize[z]))
          {
            yArr[0] += val[0];
            yArr[1] += val[1];
            yArr[2]++;
          }

          var key = UrlShrink(y.Key);

          if (xDic.ContainsKey(key))
            xDic[key] = new[] { xDic[key][0] + yArr[0], xDic[key][1] + yArr[1], xDic[key][2] + yArr[2] };
          else
            xDic.Add(key, yArr);
        }

        res.Add(x.Key, xDic);
      }

      return res;
    }

    private string UrlShrink(string value)
    {
      if (!value.StartsWith("http"))
        return value;

      value = value.Replace("https://", "").Replace("http://", "");
      var idx = value.IndexOf("/");

      return idx == -1 ? value : value.Substring(0, idx);
    }

    /// <summary>
    ///   Führt die Berechnung aus
    /// </summary>
    /// <param name="corpus">
    ///   Korpus
    /// </param>
    /// <param name="layer">
    ///   Layer
    /// </param>
    /// <param name="dsel">
    ///   Dokument GUID
    /// </param>
    /// <param name="doc">
    ///   Dokument
    /// </param>
    protected override void CalculateCall(
      AbstractCorpusAdapter corpus,
      AbstractLayerAdapter layer,
      Guid dsel,
      int[][] doc)
    {
      var metas = corpus.GetDocumentMetadata(dsel);
      if (metas == null)
        return;

      lock (_lockDocument)
      {
        DocumentSize.Add(dsel, new[] { (int)_token[dsel], _types[dsel] });
      }

      lock (_lockMetadata)
      {
        foreach (var meta in metas)
          try
          {
            if (meta.Value == null ||
                string.IsNullOrEmpty(meta.Key))
              continue;

            var key = (meta.Value as DateTime?)?.ToString("yyyy-MM-dd HH:mm:ss") ?? meta.Value.ToString();

            if (MetaDataDictionary.ContainsKey(meta.Key))
              if (MetaDataDictionary[meta.Key].ContainsKey(key))
                MetaDataDictionary[meta.Key][key].Add(dsel);
              else
                MetaDataDictionary[meta.Key].Add(key, new HashSet<Guid> { dsel });
            else
              MetaDataDictionary.Add(
                                     meta.Key,
                                     new Dictionary<string, HashSet<Guid>> { { key, new HashSet<Guid> { dsel } } });
          }
          catch
          {
            // ignore
          }
      }
    }

    /// <summary>
    ///   Wird nach der Berechnung aufgerufen (nach CalculateCall)
    ///   und dient der Bereinigung von Daten
    /// </summary>
    protected override void CalculateCleanup()
    {
      _token.Clear();
      _types.Clear();
    }

    /// <summary>
    ///   Wird nach der Bereinigung aufgerufen (nach CalculateCall + CalculateCleanup)
    ///   und dient dem zusammenfassen der bereinigen Ergebnisse
    /// </summary>
    protected override void CalculateFinalize()
    {
    }

    /// <summary>
    ///   Wird vor der Berechnung aufgerufen (vor CalculateCall)
    /// </summary>
    protected override void CalculateInitProperties()
    {
      MetaDataDictionary = new Dictionary<string, Dictionary<string, HashSet<Guid>>>();
      _lockMetadata = new object();

      DocumentSize = new Dictionary<Guid, int[]>();
      _lockDocument = new object();

      var dfdBlock = Selection.CreateBlock<DocumentFrequencyDictionaryBlock>();
      dfdBlock.LayerDisplayname = LayerDisplayname;
      dfdBlock.Calculate();

      _token = dfdBlock.DocumentSizeInToken;
      _types = dfdBlock.DocumentDictionaries.ToDictionary(x => x.Key, x => x.Value.Count);
    }
  }
}