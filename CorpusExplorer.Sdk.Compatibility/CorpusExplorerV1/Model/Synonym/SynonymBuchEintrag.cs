#region usings

using System;
using System.Collections.Generic;

#endregion

namespace CorpusExplorer.Sdk.Data.Model.Synonym
{
  /// <summary>
  ///   Class <see cref="SynonymBuchEintrag" />
  /// </summary>
  [Serializable]
  public class SynonymBuchEintrag
  {
    /// <summary>
    ///   Gets or sets a value indicating whether this instance is acronym.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is acronym; otherwise, <c>false</c> .
    /// </value>
    public bool IsAcronym { get; set; }

    /// <summary>
    ///   Gets or sets a value indicating whether this instance is shortform.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is shortform; otherwise, <c>false</c> .
    /// </value>
    public bool IsShortform { get; set; }

    /// <summary>
    ///   Gets or sets the synonyme.
    /// </summary>
    /// <value>
    ///   The synonyme.
    /// </value>
    public List<SynonymBuchEintrag> Synonyme { get; set; }

    /// <summary>
    ///   Gets or sets the wertigkeit.
    /// </summary>
    /// <value>
    ///   The wertigkeit.
    /// </value>
    public SynonymBuchEintragWertigkeit Wertigkeit { get; set; }

    /// <summary>
    ///   Gets or sets the zeichenkette.
    /// </summary>
    /// <value>
    ///   The zeichenkette.
    /// </value>
    public string Zeichenkette { get; set; }

    /// <summary>
    ///   Returns a <see cref="string" /> that represents this instance.
    /// </summary>
    /// <returns>
    ///   A <see cref="string" /> that represents this instance.
    /// </returns>
    public override string ToString()
    {
      return string.Format("{0} {1}", Zeichenkette, Wertigkeit);
    }
  }
}