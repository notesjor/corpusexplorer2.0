using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Ecosystem.Model;

namespace CorpusExplorer.Sdk.Blocks
{
  [Serializable]
  public class DocumentContainsLayerValueBlock : AbstractBlock
  {
    private readonly object _lock = new object();

    public DocumentContainsLayerValueBlock()
    {
      LayerDisplayname = "Wort";
    }

    public string LayerDisplayname { get; set; }

    public Dictionary<string, HashSet<Guid>> LayerValueToDocument { get; set; }

    /// <summary>
    ///   Funktion die aufgerufen wird, wenn eine Berechnung durchgeführt werden soll.
    /// </summary>
    public override void Calculate()
    {
      LayerValueToDocument = new Dictionary<string, HashSet<Guid>>();

      Parallel.ForEach(
        Selection,
        Configuration.ParallelOptions,
        csel =>
        {
          var corpus = Selection.GetCorpus(csel.Key);

          var layer = corpus?.GetLayers(LayerDisplayname)?.FirstOrDefault();
          if (layer == null)
            return;

          lock (_lock)
          {
            foreach (var v in layer.Values.Where(v => !LayerValueToDocument.ContainsKey(v)))
              LayerValueToDocument.Add(v, new HashSet<Guid>());
          }

          Parallel.ForEach(
            csel.Value,
            Configuration.ParallelOptions,
            dsel =>
            {
              var doc = layer[dsel];
              if (doc == null)
                return;

              var hash = new HashSet<string>();
              foreach (var w in doc.SelectMany(s => s))
                hash.Add(layer[w]);

              lock (_lock)
              {
                foreach (var v in hash)
                  LayerValueToDocument[v].Add(dsel);
              }
            });
        });
    }
  }
}