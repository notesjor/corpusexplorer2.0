using System;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Blocks.VocabularyComplaxity;

namespace CorpusExplorer.Sdk.Blocks
{
  /// <summary>
  ///   The vocabulary complexity block (selection based).
  /// </summary>
  [Serializable]
  public class VocabularyComplexitySelectionBasedBlock : AbstractBlock
  {
    /// <summary>
    ///   Gets or sets the complexity algorithm.
    /// </summary>
    public AbstractVocabularyComplexity ComplexityAlgorithm { get; set; } = new VocabularyComplexityByYule1938();

    /// <summary>
    ///   DokumentGUID/Komplexität-Wörterbuch
    /// </summary>
    public double ComplexityValue { get; private set; }

    public string LayerDisplayname { get; set; } = "Wort";

    public override void Calculate()
    {
      var block = Selection.CreateBlock<Frequency1LayerBlock>();
      block.LayerDisplayname = LayerDisplayname;
      block.Calculate();

      ComplexityValue = ComplexityAlgorithm.CalculateValue(block.Frequency);
    }
  }
}