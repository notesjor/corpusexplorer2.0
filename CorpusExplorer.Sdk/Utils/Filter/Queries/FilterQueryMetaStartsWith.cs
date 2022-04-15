using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;

namespace CorpusExplorer.Sdk.Utils.Filter.Queries
{
  /// <summary>
  ///   The meta contains case sensitive filter query.
  /// </summary>
  [XmlRoot]
  [Serializable]
  public class FilterQueryMetaStartsWith : AbstractFilterQueryMeta
  {
    [XmlArray] private string _value;

    /// <summary>
    ///   Gibt eine automatisch generierte Zusammenfassung des Inhalts/Bedeutung zurück.
    /// </summary>
    /// <value>The verbal.</value>
    [XmlIgnore]
    public override string Verbal => $"{MetaLabel} beginnt mit {string.Join(" ", MetaValues)}";

    /// <summary>
    ///   Erstellt ein neues Objekt, das eine Kopie der aktuellen Instanz darstellt.
    /// </summary>
    /// <returns>
    ///   Ein neues Objekt, das eine Kopie dieser Instanz darstellt.
    /// </returns>
    public override object Clone()
    {
      return new FilterQueryMetaStartsWith
      {
        Inverse = Inverse,
        MetaLabel = MetaLabel,
        MetaValues = MetaValues,
        OrFilterQueries = OrFilterQueries.Select(q => q.Clone() as AbstractFilterQuery)
      };
    }

    protected override void TransformMetaValues(IEnumerable<object> metaObjects)
    {
      _value = string.Join(" ", metaObjects.Select(x => x?.ToString() ?? ""));
    }

    protected override bool ValidateCallCall(string value)
    {
      return value.StartsWith(_value);
    }
  }
}