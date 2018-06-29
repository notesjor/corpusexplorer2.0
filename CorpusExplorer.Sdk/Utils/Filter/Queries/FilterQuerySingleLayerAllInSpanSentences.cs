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
  public class FilterQuerySingleLayerAllInSpanSentences : AbstractFilterQuerySingleLayer
  {
    [XmlAttribute("span")] private int _sentenceSpan;

    [XmlIgnore]
    public int SentenceSpan
    {
      get => _sentenceSpan;
      set => _sentenceSpan = value;
    }

    /// <summary>
    ///   Gibt eine automatisch generierte Zusammenfassung des Inhalts/Bedeutung zur�ck.
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
        return string.Format(Resources.AllValuesWithSentenceSpace, values, SentenceSpan);
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
      return new FilterQuerySingleLayerAllInSpanSentences
      {
        Inverse = Inverse,
        LayerDisplayname = LayerDisplayname,
        LayerQueries = LayerQueries,
        SentenceSpan = SentenceSpan,
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

      var marker = -1;
      for (var i = 0; i < document.Length; i++)
        foreach (var word in document[i])
        {
          if (!indices.Contains(word))
            continue;

          if (marker > -1 &&
              i - marker < SentenceSpan)
          {
            res.Add(i);
            break;
          }

          marker = i;
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
      var marker = -1;
      for (var i = 0; i < document.Length; i++)
        foreach (var word in document[i])
        {
          if (!indices.Contains(word))
            continue;

          if (marker > -1 &&
              i - marker < SentenceSpan)
            return true;

          marker = i;
        }

      return false;
    }
  }
}