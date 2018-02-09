using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;

namespace CorpusExplorer.Sdk.Blocks
{
  [Serializable]
  public class DocumentFrequenceDistributionBlock : AbstractSimple1LayerBlock
  {
    private readonly object _docLock = new object();
    private readonly object _totalLock = new object();
    private HashSet<string> _hashset;
    private double _total;

    public DocumentFrequenceDistributionBlock()
    {
      Granulation = 10;
      MuteShortText = true;
    }

    public int FrequencySum => (int) _total;

    public double[] GranulatedDocument { get; set; }
    public int Granulation { get; set; }

    /// <summary>
    ///   Wenn true werden alle Texte die kürzer sind als Granulation ignoriert.
    /// </summary>
    public bool MuteShortText { get; set; }

    public IEnumerable<string> Queries { get; set; }

    /// <summary>
    ///   Führt die Berechnung aus
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
    protected override void CalculateCall(
      AbstractCorpusAdapter corpus,
      AbstractLayerAdapter layer,
      Guid dsel,
      int[][] doc)
    {
      // Wird dazu verwendet um festzustellen ob das Segment abgschlossen ist.
      var cntJ = 0;
      // Segmentgrenze
      var maxJ = doc.SelectMany(s => s).Count() / (double) Granulation;

      // Ignoriere kurze Texte?
      if (MuteShortText && maxJ < 1.0d)
        return;

      // Index/Segment in den das aktuelle Ergebnis geschrieben wird.
      var gI = 0;

      foreach (var w in doc.SelectMany(s => s))
      {
        // Überprüfe ob das Wort einem der Suchausdrück entspricht.
        if (_hashset.Contains(layer[w]))
        {
          lock (_totalLock)
          {
            _total++; // Erhöhe die Summe der totalen Ergebnisse
          }

          // Überprüfe Überläufe
          // Wenn cntJ + 1 > maxJ dann liegt ein Überlauf vor vertele dann die Frequenz auf das aktuelle und das nächste Segment
          lock (_docLock)
          {
            if (cntJ + 1 > maxJ)
            {
              GranulatedDocument[gI] += 0.5;
              // Schütze vor IndexOutOfRangeException
              if (gI + 1 >= GranulatedDocument.Length)
                GranulatedDocument[gI] += 0.5;
              else
                GranulatedDocument[gI + 1] += 0.5;
            }
            // Normalfall
            else
            {
              GranulatedDocument[gI] += 1.0;
            }
          }
        }

        // Erhöhe Segment-Zähler
        cntJ++;
        // Überprüfe auf Segement-Ende - Wenn wahr, Rücksetzen, Erhöhen, Überläufe testen
        // ReSharper disable once InvertIf
        if (cntJ > maxJ)
        {
          cntJ = 0;
          gI++;
          lock (_docLock)
          {
            if (gI >= GranulatedDocument.Length)
              gI = GranulatedDocument.Length - 1;
          }
        }
      }
    }

    /// <summary>
    ///   Wird nach der Berechnung aufgerufen (nach CalculateCall)
    ///   und dient der Bereinigung von Daten
    /// </summary>
    protected override void CalculateCleanup()
    {
      for (var i = 0; i < GranulatedDocument.Length; i++)
        GranulatedDocument[i] /= _total;
    }

    /// <summary>
    ///   Wird nach der Bereinigung aufgerufen (nach CalculateCall + CalculateCleanup)
    ///   und dient dem zusammenfassen der bereinigen Ergebnisse
    /// </summary>
    protected override void CalculateFinalize()
    {
      _hashset.Clear();
      _hashset = null;
    }

    /// <summary>
    ///   Wird vor der Berechnung aufgerufen (vor CalculateCall)
    /// </summary>
    protected override void CalculateInitProperties()
    {
      GranulatedDocument = new double[Granulation];
      _hashset = new HashSet<string>(Queries);
      _total = 0d;
    }
  }
}