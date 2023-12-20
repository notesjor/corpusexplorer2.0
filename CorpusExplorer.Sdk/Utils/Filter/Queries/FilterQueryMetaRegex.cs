using System.Xml.Serialization;
using CorpusExplorer.Sdk.Properties;

#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Utils.Filter.Queries
{
  /// <summary>
  ///   The meta contains case sensitive filter query.
  /// </summary>
  [XmlRoot]
  [Serializable]
  public class FilterQueryMetaRegex : AbstractFilterQueryMeta
  {
    private List<Regex> _values;

    /// <summary>
    ///   Gibt eine automatisch generierte Zusammenfassung des Inhalts/Bedeutung zurück.
    /// </summary>
    /// <value>The verbal.</value>
    [XmlIgnore]
    public override string Verbal => string.Format(
                                                   Resources.DokumentMetadatenExakt01,
                                                   MetaLabel,
                                                   string.Join(", ", MetaValues));

    /// <summary>
    ///   Erstellt ein neues Objekt, das eine Kopie der aktuellen Instanz darstellt.
    /// </summary>
    /// <returns>
    ///   Ein neues Objekt, das eine Kopie dieser Instanz darstellt.
    /// </returns>
    public override object Clone()
    {
      return new FilterQueryMetaRegex
      {
        Inverse = Inverse,
        MetaLabel = MetaLabel,
        MetaValues = MetaValues,
        OrFilterQueries = OrFilterQueries.Select(q => q.Clone() as AbstractFilterQuery)
      };
    }

    protected override void TransformMetaValues(IEnumerable<object> metaValues)
    {
      _values?.Clear();

      _values = new List<Regex>();
      foreach (var o in metaValues)
      {
        switch (o)
        {
          case Regex regex:
            _values.Add(regex);
            break;
          case string s:
            _values.Add(new Regex(s, RegexOptions.Compiled));
            break;
        }
      }
    }

    protected override bool ValidateCallCall(string value)
    {
      return !string.IsNullOrEmpty(value) && MetaValues.Any(x => ((Regex) x).IsMatch(value));
    }
  }
}