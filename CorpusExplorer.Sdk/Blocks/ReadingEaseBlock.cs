using System.Collections.Concurrent;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;

#region

using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Blocks.ReadingEase;

#endregion

namespace CorpusExplorer.Sdk.Blocks
{
  /// <summary>
  ///   The reading ease block.
  /// </summary>
  [Serializable]
  public class ReadingEaseBlock : AbstractSimple1LayerBlock
  {
    private Dictionary<Guid, Dictionary<string, Dictionary<string, int>>> _docValues;
    private ConcurrentDictionary<Guid, double> _values;

    /// <summary>
    ///   Initializes a new instance of the <see cref="ReadingEaseBlock" /> class.
    /// </summary>
    public ReadingEaseBlock()
    {
      ReadingEaseAlgorithm = new WienerSachtextV4Index();
      LayerDisplayname = "Wort";
    }

    /// <summary>
    ///   Gets or sets the reading ease algorithm.
    /// </summary>
    public AbstractReadingEaseIndex ReadingEaseAlgorithm { get; set; }

    /// <summary>
    ///   Gets or sets the reading ease indices.
    /// </summary>
    public Dictionary<Guid, double> ReadingEaseIndices { get; set; }

    /// <summary>
    ///   The calculate call.
    /// </summary>
    /// <param name="corpus">
    ///   The corpus.
    /// </param>
    /// <param name="layer">
    ///   The layer.
    /// </param>
    /// <param name="dsel">
    ///   The dsel.
    /// </param>
    /// <param name="doc">
    ///   The doc.
    /// </param>
    protected override void CalculateCall(
      AbstractCorpusAdapter corpus,
      AbstractLayerAdapter layer,
      Guid dsel,
      int[][] doc)
    {
      if (!_docValues.ContainsKey(dsel))
        return;

      var countHypens = 0.0d;
      var hypenCount3More = 0.0d;
      var hypenCount1 = 0.0d;
      var characterCount6More = 0.0d;

      foreach (var word in from s in doc from w in s select layer[w])
      {
        var count = _docValues[dsel] != null && _docValues[dsel].ContainsKey(word) ? _docValues[dsel][word].Count : 0;

        countHypens += count;

        if (count > 3)
          hypenCount3More++;

        if (count == 1)
          hypenCount1++;

        if (word.Length > 6)
          characterCount6More++;
      }

      var countSentences = (double) doc.Length;
      var countWords = (double) doc.SelectMany(s => s).Count();
      var averageSentenceLength = countWords            / countSentences;
      var averageNumberOfSyllablesPerWord = countHypens / countWords;
      var ms = hypenCount3More     / countWords         * 100.0d;
      var iw = characterCount6More / countWords         * 100.0d;
      var es = hypenCount1         / countWords         * 100.0d;

      _values.TryAdd(
                     dsel,
                     ReadingEaseAlgorithm.CalculateIndex(
                                                         averageSentenceLength,
                                                         averageNumberOfSyllablesPerWord,
                                                         ms,
                                                         iw,
                                                         es,
                                                         hypenCount3More));
    }

    /// <summary>
    ///   The calculate cleanup.
    /// </summary>
    protected override void CalculateCleanup()
    {
      ReadingEaseIndices = _values.ToDictionary(x => x.Key, x => x.Value);
      _values = new ConcurrentDictionary<Guid, double>();
    }

    /// <summary>
    ///   The calculate finalize.
    /// </summary>
    protected override void CalculateFinalize()
    {
      _docValues.Clear();
      _docValues = null;
    }

    /// <summary>
    ///   The calculate init properties.
    /// </summary>
    protected override void CalculateInitProperties()
    {
      ReadingEaseIndices = new Dictionary<Guid, double>();

      var block = Selection.CreateBlock<HyphenDocumentWordFrequencyBlock>();
      block.Calculate();

      _docValues = block.HyphenFrequency;

      _values = new ConcurrentDictionary<Guid, double>();
    }
  }
}