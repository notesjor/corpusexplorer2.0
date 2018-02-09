#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Utils.Filter.Queries
{
  /// <summary>
  ///   The any single layer filter query.
  /// </summary>
  [XmlRoot]
  [Serializable]
  public class FilterQuerySingleLayerAnyMatch : AbstractFilterQuerySingleLayer
  {
    /// <summary>
    ///   Gibt eine automatisch generierte Zusammenfassung des Inhalts/Bedeutung zurück.
    /// </summary>
    /// <value>The verbal.</value>
    [XmlIgnore]
    public override string Verbal
    {
      get
      {
        var values = string.Join(", ", LayerQueries);
        if (values.Length > 50)
          values = values.Substring(0, 47) + "...";
        return $"Min. ein Wert im Dokument ({values}).";
      }
    }

    /// <summary>
    ///   Erstellt ein neues Objekt, das eine Kopie der aktuellen Instanz darstellt.
    /// </summary>
    /// <returns>
    ///   Ein neues Objekt, das eine Kopie dieser Instanz darstellt.
    /// </returns>
    public override object Clone()
    {
      return new FilterQuerySingleLayerAnyMatch
      {
        Inverse = Inverse,
        LayerDisplayname = LayerDisplayname,
        LayerQueries = LayerQueries,
        OrFilterQueries = OrFilterQueries.Select(q => q.Clone() as AbstractFilterQuery)
      };
    }

    /// <summary>
    ///   The get sentences call.
    /// </summary>
    /// <param name="document">
    ///   The document.
    /// </param>
    /// <param name="indices">
    ///   The indices.
    /// </param>
    /// <returns>
    ///   Alle Sätze, die die Indices enthalten.
    /// </returns>
    protected override IEnumerable<int> GetSentencesCall(int[][] document, HashSet<int> indices)
    {
      var res = new List<int>();
      for (var i = 0; i < document.Length; i++)
        res.AddRange(from w in document[i] where indices.Contains(w) select i);

      return res;
    }

    /// <summary>
    ///   The validate call call.
    /// </summary>
    /// <param name="document">
    ///   The document.
    /// </param>
    /// <param name="indices">
    ///   The indices.
    /// </param>
    /// <returns>
    ///   The <see cref="bool" />.
    /// </returns>
    protected override bool ValidateCallCall(int[][] document, HashSet<int> indices)
    {
      return document.SelectMany(s => s).Any(indices.Contains);
    }
  }
}