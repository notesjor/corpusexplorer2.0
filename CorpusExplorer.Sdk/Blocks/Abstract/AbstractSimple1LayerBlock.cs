#region

#region

using System;
using System.Linq;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Diagnostic;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using CorpusExplorer.Sdk.Model.Cache.Helper.Exception;

#endregion

#endregion

namespace CorpusExplorer.Sdk.Blocks.Abstract
{
  /// <summary>
  ///   Abstrakter Block der es vereinfacht wenn ein Block erstellt werden soll,
  ///   der nur auf einen Layer zugreift.
  /// </summary>
  [Serializable]
  public abstract class AbstractSimple1LayerBlock : AbstractBlock
  {
    /// <summary>
    ///   Initializes a new instance of the <see cref="AbstractSimple1LayerBlock" /> class.
    /// </summary>
    protected AbstractSimple1LayerBlock() => LayerDisplayname = "Wort";

    /// <summary>
    ///   Gets or sets the layer displayname.
    /// </summary>
    public string LayerDisplayname { get; set; }

    /// <summary>
    ///   Funktion die aufgerufen wird, wenn eine Berechnung durchgef�hrt werden soll.
    /// </summary>
    public override void Calculate()
    {
      try
      {
        CalculateInitProperties();
      }
      catch (BlockAlreadyCachedException)
      {
        return;
      }

      Parallel.ForEach(Selection, Configuration.ParallelOptions, csel =>
      {
        try
        {
          var corpus = Selection.GetCorpus(csel.Key);

          var layer = corpus?.GetLayers(LayerDisplayname)?.FirstOrDefault();
          if (layer == null)
            return;

          Parallel.ForEach(csel.Value, Configuration.ParallelOptions, dsel =>
          {
            try
            {
              if (!layer.ContainsDocument(dsel))
                return;

              var doc = layer[dsel];
              if (doc == null)
                return;

              CalculateCall(corpus, layer, dsel, doc);
            }
            catch (Exception ex)
            {
              InMemoryErrorConsole.Log(ex);
            }
          });
        }
        catch (Exception ex)
        {
          InMemoryErrorConsole.Log(ex);
        }
      });

      CalculateCleanup();

      CalculateFinalize();
    }

    /// <summary>
    ///   Führt die Berechnung aus. Bitte beachten Sie, dass diese Funktion in parallelen Threads aufgerufen wird.
    ///   Sollte die Funktion auf die Daten anderer Blocks zugreifen, dann lagern Sie diese Abfragen nach Möglichkeit
    ///   in die Funktion CalculateInitProperties() aus.
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
    protected abstract void CalculateCall(
      AbstractCorpusAdapter corpus,
      AbstractLayerAdapter layer,
      Guid dsel,
      int[][] doc);

    /// <summary>
    ///   Wird nach der Berechnung aufgerufen (nach CalculateCall)
    ///   und dient der Bereinigung von Daten
    /// </summary>
    protected abstract void CalculateCleanup();

    /// <summary>
    ///   Wird nach der Bereinigung aufgerufen (nach CalculateCall + CalculateCleanup)
    ///   und dient dem zusammenfassen der bereinigen Ergebnisse
    /// </summary>
    protected abstract void CalculateFinalize();

    /// <summary>
    ///   Wird vor der Berechnung aufgerufen (vor CalculateCall).
    ///   Hier sollten Sie auch Abfragen anderer Blocks auslagern, damit die Abfrage Threadsafe ist.
    /// </summary>
    protected abstract void CalculateInitProperties();
  }
}