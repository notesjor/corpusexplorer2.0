using System.Xml.Serialization;
using CorpusExplorer.Sdk.Properties;

#region

using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Utils.Filter.Queries
{
  /// <summary>
  ///   The all in one single layer filter query.
  /// </summary>
  [XmlRoot]
  [Serializable]
  public class FilterQuerySingleLayerAllInOneSentence : AbstractFilterQuerySingleLayer
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
        return string.Format(Resources.AllValuesInOneSentence, values);
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
      return new FilterQuerySingleLayerAllInOneSentence
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
      {
        var done = new HashSet<int>();
        var found = 0;

        foreach (var w in document[i].Where(indices.Contains).Where(w => !done.Contains(w)))
        {
          done.Add(w);
          found++;
          if (found == indices.Count)
            break;
        }

        if (found == indices.Count)
          res.Add(i);
      }

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
      foreach (var s in document)
      {
        var temp = new List<int>(indices.ToArray());
        foreach (var w in s.Where(temp.Contains))
        {
          temp.Remove(w);
          if (temp.Count == 0)
            return true;
        }
      }

      return false;
    }
  }
}