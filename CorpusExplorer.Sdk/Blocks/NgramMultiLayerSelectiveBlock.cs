using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Blocks.NgramMultiLayerSelectiveQuery;
using CorpusExplorer.Sdk.Blocks.NgramMultiLayerSelectiveQuery.ValidateCall.Abstract;
using CorpusExplorer.Sdk.Model.Extension;

namespace CorpusExplorer.Sdk.Blocks
{
  [Serializable]
  public class NgramMultiLayerSelectiveBlock : AbstractBlock
  {
    private string Pattern { get; set; } = "*";
    public Dictionary<string, double> NGramFrequency { get; private set; }
    /// <summary>
    /// Query Key = Layer Name, Value = Position mit Query (*, PREFIX*, *SUFFIX, REGEX:...)
    /// </summary>
    public Dictionary<string, string[]> LayerQueries { get; set; } = null;
    /// <summary>
    /// Ermöglicht es vorkompilierte Queries zu verwenden. Achtung: Wenn mehrere Korpora eingesetzt werden, müssen die Queries für jedes Korpus neu kompiliert werden.
    /// </summary>
    public List<Dictionary<string, AbstractValidateCall>> LayerQueriesPreCompiled { get; set; } = null;
    public string LayerDisplayname { get; set; } = "Wort";

    public override void Calculate()
    {
      var @lock = new object();
      NGramFrequency = new Dictionary<string, double>();

      int nMax;
      string[] layers;

      if (LayerQueriesPreCompiled == null)
      {
        nMax = LayerQueries.First().Value.Length;
        if (LayerQueries.Keys.Any(k => LayerQueries[k].Length != nMax))
          return;
        layers = LayerQueries.Keys.ToArray();
      }
      else
      {
        nMax = LayerQueriesPreCompiled.Count;
        layers = LayerQueriesPreCompiled.First().Keys.ToArray();
      }

      Parallel.ForEach(Selection.CorporaAndDocumentGuids, csel =>
      {
        var corpus = Selection.GetCorpus(csel.Key);
        var queriesCompiled = LayerQueriesPreCompiled ?? QueryCompiler.Compile(corpus.ToSelection(), LayerQueries, Pattern);

        var layerNames = new HashSet<string>(layers) { LayerDisplayname };
        var mainLayer = corpus.GetLayers(LayerDisplayname).First();

        Parallel.ForEach(csel.Value, dsel =>
        {
          var multi = corpus.GetMultilayerDocument(dsel, layerNames);
          if (multi.Count != layerNames.Count)
            return;

          var first = multi.First(x => x.Key == LayerDisplayname).Value;
          for (var s = 0; s < first.Length; s++)
          {
            for (var t = 0; t < first[s].Length; t++)
            {
              var valid = true;
              for (var n = 0; n < nMax; n++)
              {
                if (t + n >= first[s].Length)
                  break;

                if (layers.Any(l => !queriesCompiled[n][l].Validate(multi[l][s][t + n])))
                  valid = false;

                if (!valid)
                  break;
              }

              if (!valid)
                continue;

              if (nMax + t >= first[s].Length)
                continue;

              var tmp = new List<string>();
              for (var n = 0; n < nMax; n++)
                tmp.Add(mainLayer[first[s][t + n]]);
              var key = string.Join(" ", tmp);
              lock (@lock)
              {
                if (NGramFrequency.ContainsKey(key))
                  NGramFrequency[key]++;
                else
                  NGramFrequency.Add(key, 1);
              }
            }
          }
        });
      });
    }
  }
}