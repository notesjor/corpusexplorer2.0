#region

using System;
using System.Linq;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Blocks.Abstract
{
  [Serializable]
  public abstract class AbstractLayerValueBlock : AbstractBlock
  {
    /// <summary>
    ///   Initializes a new instance of the <see cref="Abstract.AbstractLayerValueBlock" /> class.
    /// </summary>
    protected AbstractLayerValueBlock() => LayerDisplayname = "Wort";

    public string LayerDisplayname { get; set; }

    /// <summary>
    ///   Funktion die aufgerufen wird, wenn eine Berechnung durchgeführt werden soll.
    /// </summary>
    public override void Calculate()
    {
      Parallel.ForEach(
                       Selection,
                       Configuration.ParallelOptions,
                       csel =>
                       {
                         var corpus = Selection.GetCorpus(csel.Key);
                         if (corpus == null)
                           return;

                         Parallel.ForEach(
                                          csel.Value,
                                          Configuration.ParallelOptions,
                                          dsel =>
                                          {
                                            if (!corpus.ContainsDocument(dsel))
                                              return;

                                            var layer = corpus.GetLayers(LayerDisplayname).FirstOrDefault();
                                            if (layer == null)
                                              return;

                                            CalculateCall(
                                                          dsel,
                                                          layer);
                                          });
                       });
    }

    protected abstract void CalculateCall(Guid dsel, AbstractLayerAdapter layer);
  }
}