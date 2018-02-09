#region

using System;
using System.Linq;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using CorpusExplorer.Sdk.Model.Cache.Helper.Exception;

#endregion

namespace CorpusExplorer.Sdk.Blocks.Abstract
{
  /// <summary>
  ///   The abstract simple 3 layer block.
  /// </summary>
  [Serializable]
  public abstract class AbstractSimple3LayerBlock : AbstractBlock
  {
    /// <summary>
    ///   Initializes a new instance of the <see cref="AbstractSimple3LayerBlock" /> class.
    /// </summary>
    protected AbstractSimple3LayerBlock()
    {
      Layer1Displayname = "Wort";
      Layer2Displayname = "Lemma";
      Layer3Displayname = "POS";
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
    ///   Gets or sets the layer 3 displayname.
    /// </summary>
    public string Layer3Displayname { get; set; }

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
        csel =>
        {
          var corpus = Selection.GetCorpus(csel.Key);

          var layer1 = corpus?.GetLayers(Layer1Displayname).FirstOrDefault();
          if (layer1 == null)
            return;

          var layer2 = corpus.GetLayers(Layer2Displayname).FirstOrDefault();
          if (layer2 == null)
            return;

          var layer3 = corpus.GetLayers(Layer3Displayname).FirstOrDefault();
          if (layer3 == null)
            return;

          Parallel.ForEach(
            csel.Value,
            dsel =>
            {
              if (!layer1.ContainsDocument(dsel) || !layer2.ContainsDocument(dsel) || !layer3.ContainsDocument(dsel))
                return;

              var doc1 = layer1[dsel];
              var doc2 = layer2[dsel];
              var doc3 = layer3[dsel];
              if (doc1 == null ||
                  doc2 == null ||
                  doc3 == null)
                return;

              // Alle Dokumente müssen die gleiche Länge haben
              var len2 = doc2.DocumentSize();
              if (doc1.DocumentSize() != len2 ||
                  len2 != doc3.DocumentSize())
                return;

              try
              {
                CalculateCall(corpus, dsel, layer1, doc1, layer2, doc2, layer3, doc3);
              }
              catch
              {
                // ignore
              }
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
    /// <param name="layer3">
    ///   Layer 3
    /// </param>
    /// <param name="doc3">
    ///   Dokument 3
    /// </param>
    protected abstract void CalculateCall(
      AbstractCorpusAdapter corpus,
      Guid dsel,
      AbstractLayerAdapter layer1,
      int[][] doc1,
      AbstractLayerAdapter layer2,
      int[][] doc2,
      AbstractLayerAdapter layer3,
      int[][] doc3);

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