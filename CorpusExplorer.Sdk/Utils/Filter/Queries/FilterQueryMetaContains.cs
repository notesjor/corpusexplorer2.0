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
  ///   The meta contains filter query.
  /// </summary>
  [XmlRoot]
  [Serializable]
  public class FilterQueryMetaContains : AbstractFilterQueryMeta
  {
    [XmlArray] private HashSet<string> _values;

    /// <summary>
    ///   Gibt eine automatisch generierte Zusammenfassung des Inhalts/Bedeutung zurück.
    /// </summary>
    /// <value>The verbal.</value>
    [XmlIgnore]
    public override string Verbal => string.Format(
      Resources.DokumentMetadaten01,
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
      return new FilterQueryMetaContains
      {
        Inverse = Inverse,
        MetaLabel = MetaLabel,
        MetaValues = MetaValues,
        OrFilterQueries = OrFilterQueries.Select(q => q.Clone() as AbstractFilterQuery)
      };
    }

    protected override void TransformMetaValues(IEnumerable<object> metaValues)
    {
      _values = new HashSet<string>(metaValues.Select(x => x?.ToString().ToLowerInvariant() ?? ""));
    }

    protected override bool ValidateCallCall(string value)
    {
      return _values.Any(query => value.ToLowerInvariant().Contains(query));
    }
  }
}