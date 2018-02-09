using System;

namespace CorpusExplorer.Sdk.Extern.Plaintext.ClanChildes.Model
{
  [Serializable]
  public class ClanChildesRule
  {
    /// <summary>
    ///   Gets or sets the meta Label.
    /// </summary>
    /// <value>The metalabel.</value>
    public string MetaLabel { get; set; }

    /// <summary>
    ///   Gets or sets the meta value.
    /// </summary>
    /// <value>The meta value.</value>
    public object MetaValue { get; set; }

    /// <summary>
    ///   Gets or sets the sentence index end.
    /// </summary>
    /// <value>The sentence index end.</value>
    public int SentenceIndexEnd { get; set; }

    /// <summary>
    ///   Gets or sets the sentence index start.
    /// </summary>
    /// <value>The sentence index start.</value>
    public int SentenceIndexStart { get; set; }
  }
}