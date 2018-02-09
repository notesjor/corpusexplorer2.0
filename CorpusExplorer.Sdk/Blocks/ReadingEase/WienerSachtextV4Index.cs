#region

using System;

#endregion

namespace CorpusExplorer.Sdk.Blocks.ReadingEase
{
  /// <summary>
  ///   The wiener sachtext v 4 index.
  /// </summary>
  [Serializable]
  public class WienerSachtextV4Index : AbstractReadingEaseIndex
  {
    public override string Displayname => "Wiener Sachtext Index (v4)";

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
      return 0.2744 * ms + 0.2656 * averageSentenceLength - 1.693;
    }
  }
}