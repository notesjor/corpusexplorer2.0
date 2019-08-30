using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract.Model.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Builder;

namespace CorpusExplorer.Sdk.Utils.CorpusManipulation
{
  public static class CorpusNormalizer
  {
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

        foreach (var key in state.Cache.Keys.ToArray())
        {
          var nval = ndict.ContainsKey(key) ? ndict[key] : -1;

          fixes.Add(state.Cache[key], nval);
          state.Cache[key] = nval;
        }

        object dlock = new object();
        Parallel.ForEach(state.Documents.Keys.ToArray(), Configuration.ParallelOptions, dsel =>
        {
          int[][] doc;
          lock (dlock)
            doc = state.Documents[dsel];

          for (int i = 0; i < doc.Length; i++)
            for (int j = 0; j < doc[i].Length; j++)
              doc[i][j] = fixes[doc[i][j]];

          lock(dlock)
            state.Documents[dsel] = doc;
        });
      });

      return builder.Create(layers, corpus.DocumentMetadata.ToDictionary(x => x.Key, x => x.Value), corpus.GetCorpusMetadata().ToDictionary(x => x.Key, x => x.Value), corpus.Concepts?.ToList()).First();
    }
  }
}
