#region

using System;

#endregion

namespace CorpusExplorer.Sdk.Addon.Example.WordCloudOwnRendering.Wordcloud.Model
{
  public class WordCloudItem : IComparable<WordCloudItem>
  {
    public string Label { get; set; }
    public int Occurrences { get; set; }

    /// <summary>
    ///   Vergleicht das aktuelle Objekt mit einem anderen Objekt desselben Typs.
    /// </summary>
    /// <returns>
    ///   Ein Wert, der die relative Reihenfolge der verglichenen Objekte angibt. Der Rückgabewert hat folgende Bedeutung: Wert
    ///   Bedeutung  Kleiner als 0  Dieses Objekt ist kleiner als der <paramref name="other" />-Parameter. Zero  Dieses Objekt
    ///   ist gleich <paramref name="other" />.  Größer als 0 (null)  Dieses Objekt ist größer als <paramref name="other" />.
    /// </returns>
    /// <param name="other">Ein Objekt, das mit diesem Objekt verglichen werden soll.</param>
    public int CompareTo(WordCloudItem other)
    {
      return string.Compare(Label, other.Label, StringComparison.Ordinal);
    }
  }
}