using System.Collections.Generic;
using System.Xml.Serialization;
using CorpusExplorer.Sdk.Properties;

#region

using System;
using System.Linq;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Utils.Filter.Queries
{
  /// <summary>
  ///   The meta contains case sensitive filter query.
  /// </summary>
  [XmlRoot]
  [Serializable]
  public class FilterQueryMetaContainsCaseSensitive : AbstractFilterQueryMeta
  {
    [XmlArray]
    private HashSet<string> _values;

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
      return new FilterQueryMetaContainsCaseSensitive
      {
        Inverse = Inverse,
        MetaLabel = MetaLabel,
        MetaValues = MetaValues,
        OrFilterQueries = OrFilterQueries.Select(q => q.Clone() as AbstractFilterQuery)
      };
    }

    protected override void TransformMetaValues(IEnumerable<object> metaObjects)
    {
      _values = new HashSet<string>(metaObjects.Select(x => x?.ToString() ?? ""));
    }

    protected override bool ValidateCallCall(string value) { return _values.Any(query => query.Contains(value)); }
  }
}