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
  [XmlRoot]
  [Serializable]
  public class FilterQuerySingleLayerAllInSpanWords : AbstractFilterQuerySingleLayer
  {
    [XmlAttribute("span")] private int _wordSpan;

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
        return string.Format(Resources.AlLValuesWithWordSpace, values, WordSpan);
      }
    }

    [XmlIgnore]
    public int WordSpan
    {
      get => _wordSpan;
      set => _wordSpan = value;
    }

    /// <summary>
    ///   Erstellt ein neues Objekt, das eine Kopie der aktuellen Instanz darstellt.
    /// </summary>
    /// <returns>
    ///   Ein neues Objekt, das eine Kopie dieser Instanz darstellt.
    /// </returns>
    public override object Clone()
    {
      return new FilterQuerySingleLayerAllInSpanWords
      {
        Inverse = Inverse,
        LayerDisplayname = LayerDisplayname,
        LayerQueries = LayerQueries,
        WordSpan = WordSpan,
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
    ///   The <see cref="IEnumerable{T}" />.
    /// </returns>
    protected override IEnumerable<int> GetSentencesCall(int[][] document, HashSet<int> indices)
    {
      var res = new List<int>();

      for (var i = 0; i < document.Length; i++)
      {
        var marker = -1;
        for (var j = 0; j < document[i].Length; j++)
        {
          if (!indices.Contains(document[i][j]))
            continue;

          if (marker > -1 &&
              j - marker < WordSpan)
          {
            res.Add(i);
            break;
          }

          marker = j;
        }
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
      foreach (var sentence in document)
      {
        var marker = -1;
        for (var i = 0; i < sentence.Length; i++)
        {
          if (!indices.Contains(sentence[i]))
            continue;

          if (marker > -1 &&
              i - marker < WordSpan)
            return true;

          marker = i;
        }
      }

      return false;
    }
  }
}