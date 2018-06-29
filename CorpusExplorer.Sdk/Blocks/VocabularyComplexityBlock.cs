#region

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Blocks.VocabularyComplaxity;
using CorpusExplorer.Sdk.Ecosystem.Model;

#endregion

namespace CorpusExplorer.Sdk.Blocks
{
  /// <summary>
  ///   The vocabulary complexity block.
  /// </summary>
  [Serializable]
  public class VocabularyComplexityBlock : AbstractBlock
  {
    /// <summary>
    ///   Gets or sets the complexity algorithm.
    /// </summary>
    public AbstractVocabularyComplexity ComplexityAlgorithm { get; set; } = new VocabularyComplexityByYule1938();

    /// <summary>
    ///   DokumentGUID/Komplexität-Wörterbuch
    /// </summary>
    public Dictionary<Guid, double> ComplexityValues { get; set; }

    public string LayerDisplayname { get; set; } = "Wort";

    public override void Calculate()
    {
      ComplexityValues = new Dictionary<Guid, double>();

      var block = Selection.CreateBlock<DocumentFrequencyDictionaryBlock>();
      block.LayerDisplayname = LayerDisplayname;
      block.Calculate();

      var @lock = new object();

      Parallel.ForEach(
        block.DocumentDictionaries,
        Configuration.ParallelOptions,
        doc =>
        {
          var value = ComplexityAlgorithm.CalculateValue(doc.Value);
          lock (@lock)
          {
            ComplexityValues.Add(doc.Key, value);
          }
        });
    }
  }
}