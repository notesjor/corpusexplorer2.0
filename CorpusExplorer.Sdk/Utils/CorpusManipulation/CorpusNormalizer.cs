using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract.Model.Abstract;

namespace CorpusExplorer.Sdk.Utils.CorpusManipulation
{
  public static class CorpusNormalizer
  {
    /// <summary>
    /// Normalisiert ein Korpus
    /// </summary>
    /// <param name="builder">CorpusBuilder</param>
    /// <param name="corpus">Korpus</param>
    /// <returns>Normalisiertes Korpus</returns>
    public static AbstractCorpusAdapter Input(AbstractCorpusBuilder builder, AbstractCorpusAdapter corpus)
    {
      var normDict = new Dictionary<string, Dictionary<string, int>>();
      foreach (var layer in corpus.Layers)
      {
        var dict = layer.ReciveRawReverseLayerDictionary();
        var norm = new Dictionary<string, int>();
        foreach (var x in dict.Where(x => !norm.ContainsKey(x.Value)))
          norm.Add(x.Value, x.Key);
        normDict.Add(layer.Displayname, norm);
      }

      return Input(builder, corpus, normDict);
    }

    /// <summary>
    /// Normalisiert ein Korpus
    /// </summary>
    /// <param name="builder">CorpusBuilder</param>
    /// <param name="corpus">Korpus</param>
    /// <param name="normalizedDictionary">Das normalisierende Dictionary muss alle im Korpus vorkommenden Layer und Layer-Werte enthalten.</param>
    /// <returns>Normalisiertes Korpus</returns>
    public static AbstractCorpusAdapter Input(AbstractCorpusBuilder builder, AbstractCorpusAdapter corpus, Dictionary<string, Dictionary<string, int>> normalizedDictionary)
    {
      var layers = new List<AbstractLayerState>();
      Parallel.ForEach(corpus.Layers, Configuration.ParallelOptions, layer =>
      {
        var ndict = normalizedDictionary[layer.Displayname];
        var state = layer.ToLayerState();
        var fixes = new Dictionary<int, int>();

        var cache = state.GetCache().ToDictionary(x => x.Key, x => x.Value);
        foreach (var key in cache.Keys.ToArray())
        {
          var nval = ndict.ContainsKey(key) ? ndict[key] : -1;

          fixes.Add(cache[key], nval);
          cache[key] = nval;
        }
        state.ForceReplaceCache(cache);

        object dlock = new object();
        var documents = state.GetDocuments();
        Parallel.ForEach(documents.Select(x => x.Key).ToArray(), Configuration.ParallelOptions, dsel =>
        {
          int[][] doc;
          lock (dlock)
            doc = state.DocumentGet(dsel);

          // ReSharper disable once ForCanBeConvertedToForeach
          for (var i = 0; i < doc.Length; i++)
            for (var j = 0; j < doc[i].Length; j++)
              doc[i][j] = fixes[doc[i][j]];

          lock (dlock)
            state.ForceReplaceDocument(dsel, doc);
        });
      });

      return builder.Create(layers, corpus.DocumentMetadata.ToDictionary(x => x.Key, x => x.Value), corpus.GetCorpusMetadata().ToDictionary(x => x.Key, x => x.Value), corpus.Concepts?.ToList()).First();
    }
  }
}
