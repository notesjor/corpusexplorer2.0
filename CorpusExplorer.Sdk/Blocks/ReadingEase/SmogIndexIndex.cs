#region

using System;

#endregion

namespace CorpusExplorer.Sdk.Blocks.ReadingEase
{
  /// <summary>
  ///   The smog index index.
  /// </summary>
  [Serializable]
  public class SmogIndexIndex : AbstractReadingEaseIndex
  {
    public override string Displayname => "SMOG-Index";

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
      return 0.0430 * Math.Sqrt(hypenCount3More * averageSentenceLength + 3.1291);
    }
  }
}