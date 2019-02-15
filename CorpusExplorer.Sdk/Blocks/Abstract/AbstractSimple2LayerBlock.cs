using System.Linq;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using CorpusExplorer.Sdk.Model.Cache.Helper.Exception;

#region

using System;
using System.Threading.Tasks;

#endregion

namespace CorpusExplorer.Sdk.Blocks.Abstract
{
  /// <summary>
  ///   The abstract simple 2 layer block.
  /// </summary>
  [Serializable]
  public abstract class AbstractSimple2LayerBlock : AbstractBlock
  {
    /// <summary>
    ///   Initializes a new instance of the <see cref="AbstractSimple2LayerBlock" /> class.
    /// </summary>
    protected AbstractSimple2LayerBlock()
    {
      Layer1Displayname = "Wort";
      Layer2Displayname = "Lemma";
    }

    /// <summary>
    ///   Gets or sets the layer 1 displayname.
    /// </summary>
    public string Layer1Displayname { get; set; }

    /// <summary>
    ///   Gets or sets the layer 2 displayname.
    /// </summary>
    public string Layer2Displayname { get; set; }

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

      Parallel.ForEach(
                       Selection,
                       Configuration.ParallelOptions,
                       csel =>
                       {
                         var corpus = Selection.GetCorpus(csel.Key);

                         var layer1 = corpus?.GetLayers(Layer1Displayname).FirstOrDefault();
                         if (layer1 == null)
                           return;

                         var layer2 = corpus.GetLayers(Layer2Displayname).FirstOrDefault();
                         if (layer2 == null)
                           return;

                         Parallel.ForEach(
                                          csel.Value,
                                          Configuration.ParallelOptions,
                                          dsel =>
                                          {
                                            if (!layer1.ContainsDocument(dsel) || !layer2.ContainsDocument(dsel))
                                              return;

                                            var doc1 = layer1[dsel];
                                            var doc2 = layer2[dsel];

                                            // Überprüfung 
                                            if (doc1 == null ||
                                                doc2 == null)
                                              return;

                                            // Alle Dokumente müssen die gleiche Länge haben (Stichprobe)
                                            if (doc1.Length                  != doc2.Length    || doc1.Length < 1 ||
                                                doc1[0].Length               != doc2[0].Length ||
                                                doc2[doc2.Length - 1].Length != doc1[doc1.Length - 1].Length)
                                              return;

                                            CalculateCall(corpus, dsel, layer1, doc1, layer2, doc2);
                                          });
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
    protected abstract void CalculateCall(
      AbstractCorpusAdapter corpus,
      Guid dsel,
      AbstractLayerAdapter layer1,
      int[][] doc1,
      AbstractLayerAdapter layer2,
      int[][] doc2);

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