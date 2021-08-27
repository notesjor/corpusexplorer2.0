#region usings

using System;
using System.Collections.Generic;

#endregion

namespace CorpusExplorer.Sdk.Data.Model.Profil
{
  /// <summary>
  ///   Class <see cref="KiItem" />
  /// </summary>
  [Serializable]
  public class KiItem
  {
    /// <summary>
    ///   Initializes a new instance of the <see cref="KiItem" /> class.
    /// </summary>
    /// <param name="bezeichnung">The bezeichnung.</param>
    /// <param name="items">The items.</param>
    public KiItem(string bezeichnung, List<KiItem> items = null)
    {
      Bezeichnung = bezeichnung;
      Items = items ?? new List<KiItem>();
    }

    /// <summary>
    ///   Prevents a default instance of the <see cref="KiItem" /> class from
    ///   being created.
    /// </summary>
    private KiItem()
    {
    }

    /// <summary>
    ///   Gets or sets the bezeichnung.
    /// </summary>
    /// <value>
    ///   The bezeichnung.
    /// </value>
    public string Bezeichnung { get; set; }

    /// <summary>
    ///   Gets or sets the items.
    /// </summary>
    /// <value>
    ///   The items.
    /// </value>
    public List<KiItem> Items { get; set; }
  }
}