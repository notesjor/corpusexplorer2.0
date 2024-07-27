using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Diagnostic;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpusExplorer.Sdk.Blocks
{
  [Serializable]
  public class DocumentContainsLayerValueSelectBlock : AbstractBlock
  {
    public Dictionary<string, int> Frequency { get; private set; }

    public string LayerDisplayname { get; private set; } = "Wort";

    public HashSet<string> LayerQueries { get; private set; }

    public void Add(string layerValue) => LayerQueries.Add(layerValue);

    public override void Calculate()
    {
      Frequency = LayerQueries.ToDictionary(x => x, x => 0);
      var frequencyLock = new object();

      Parallel.ForEach(Selection.CorporaGuids, Configuration.ParallelOptions, csel =>
      {
        try
        {
          var layer = Selection.GetCorpus(csel).GetLayers(LayerDisplayname).First();
          var values = new HashSet<int>(layer.ValuesToIndices(LayerQueries));
          if (values.Count == 0)
            return;

          var tmp1 = values.ToDictionary(x => x, x => 0);
          var tmpLock = new object();

          var docs = Selection.DocumentGuidsOfCorpus(csel);
          Parallel.ForEach(docs, Configuration.ParallelOptions, dsel =>
          {
            try
            {
              var doc = layer[dsel];
              var tmp2 = values.ToDictionary(x => x, x => false);
              foreach (var t in from s in doc
                                from t in s
                                where tmp2.ContainsKey(t)
                                select t)
              {
                tmp2[t] = true;
              }

              lock (tmpLock)
                foreach (var k in tmp2.Where(x => x.Value))
                  tmp1[k.Key]++;
            }
            catch (Exception ex)
            {
              InMemoryErrorConsole.Log(ex);
            }
          });

          lock (frequencyLock)
            foreach (var k in tmp1)
              Frequency[layer[k.Key]] += k.Value;
        }
        catch (Exception ex)
        {
          InMemoryErrorConsole.Log(ex);
        }
      });
    }
  }
}
