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
  public class FilterQueryMetaIsEmpty : AbstractFilterQueryMeta
  {
    /// <summary>
    ///   Gibt eine automatisch generierte Zusammenfassung des Inhalts/Bedeutung zurück.
    /// </summary>
    /// <value>The verbal.</value>
    [XmlIgnore]
    public override string Verbal => "Dokument-Metadaten sind leer";

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

    protected override void TransformMetaValues(IEnumerable<object> metaValues)
    {
    }

    protected override bool ValidateCallCall(string value)
    {
      return string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value);
    }
  }
}