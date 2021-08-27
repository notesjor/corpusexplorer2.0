#region usings

using System;
using System.Collections.Generic;

#endregion

namespace CorpusExplorer.Sdk.Data.Model.Synonym
{
  /// <summary>
  ///   Class <see cref="SynonymBuch" />
  /// </summary>
  [Serializable]
  public class SynonymBuch
  {
    /// <summary>
    ///   Gets or sets the synonyme.
    /// </summary>
    /// <value>
    ///   The synonyme.
    /// </value>
    public List<SynonymBuchEintrag> Synonyme { get; set; }

    /// <summary>
    ///   Gets or sets the wertigkeiten.
    /// </summary>
    /// <value>
    ///   The wertigkeiten.
    /// </value>
    public List<SynonymBuchEintragWertigkeit> Wertigkeiten { get; set; }
  }
}