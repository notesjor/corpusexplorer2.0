#region usings

using System;

#endregion

namespace CorpusExplorer.Sdk.Data.Model.Synonym
{
  /// <summary>
  ///   Class <see cref="SynonymBuchEintragWertigkeit" />
  /// </summary>
  [Serializable]
  public class SynonymBuchEintragWertigkeit
  {
    /// <summary>
    ///   Gets or sets the abkürzung.
    /// </summary>
    /// <value>
    ///   The abkürzung.
    /// </value>
    public string Abkürzung { get; set; }

    /// <summary>
    ///   Gets or sets the bezeichnung.
    /// </summary>
    /// <value>
    ///   The bezeichnung.
    /// </value>
    public string Bezeichnung { get; set; }

    /// <summary>
    ///   Returns a <see cref="string" /> that represents this instance.
    /// </summary>
    /// <returns>
    ///   A <see cref="string" /> that represents this instance.
    /// </returns>
    public override string ToString()
    {
      return "(" + Abkürzung + ")";
    }
  }
}