using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Model.Cache.Helper.Exception;

namespace CorpusExplorer.Sdk.Blocks.Abstract
{
  [Serializable]
  public abstract class AbstractDocumentMetadataBlock : AbstractBlock
  {
    /// <summary>
    ///   Initializes a new instance of the <see cref="Abstract.AbstractSimple1LayerBlock" /> class.
    /// </summary>
    protected AbstractDocumentMetadataBlock()
    {
      LayerDisplayname = "Wort";
    }

    public string LayerDisplayname { get; set; }

    /// <summary>
    ///   Funktion die aufgerufen wird, wenn eine Berechnung durchgeführt werden soll.
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

                                            CalculateCall(
                                                          dsel,
                                                          corpus.GetDocumentMetadata(dsel));
                                          });
                       });

      CalculateCleanup();

      CalculateFinalize();
    }

    /// <summary>
    ///   Führt die Berechnung aus
    /// </summary>
    /// <param name="dsel">
    ///   Dokument GUID
    /// </param>
    /// <param name="metadata">
    ///   Metadaten des Dokuments
    /// </param>
    protected abstract void CalculateCall(
      Guid dsel,
      Dictionary<string, object> metadata);

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
    ///   Wird vor der Berechnung aufgerufen (vor CalculateCall)
    /// </summary>
    protected abstract void CalculateInitProperties();
  }
}