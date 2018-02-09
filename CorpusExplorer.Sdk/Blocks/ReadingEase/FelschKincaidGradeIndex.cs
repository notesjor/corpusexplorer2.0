#region

using System;

#endregion

namespace CorpusExplorer.Sdk.Blocks.ReadingEase
{
  /// <summary>
  ///   The felsch kincaid grade index.
  /// </summary>
  [Serializable]
  public class FelschKincaidGradeIndex : AbstractReadingEaseIndex
  {
    public override string Displayname => "Felsch-Kincaid";

    /// <summary>
    ///   The calculate index.
    /// </summary>
    /// <param name="averageSentenceLength">
    ///   The average sentence length.
    /// </param>
    /// <param name="averageNumberOfSyllablesPerWord">
    ///   The average number of syllables per word.
    /// </param>
    /// <param name="ms">
    ///   The ms.
    /// </param>
    /// <param name="iw">
    ///   The iw.
    /// </param>
    /// <param name="es">
    ///   The es.
    /// </param>
    /// <param name="hypenCount3More">
    ///   The hypen count 3 more.
    /// </param>
    /// <returns>
    ///   The <see cref="double" />.
    /// </returns>
    public override double CalculateIndex(
      double averageSentenceLength,
      double averageNumberOfSyllablesPerWord,
      double ms,
      double iw,
      double es,
      double hypenCount3More)
    {
      return 0.39 * averageSentenceLength + 11.8 * averageNumberOfSyllablesPerWord - 15.59;
    }
  }
}