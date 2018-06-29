#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Utils.Filter.Queries
{
  [XmlRoot]
  [Serializable]
  public class FilterQueryCorpusComplete : AbstractFilterQueryCompleteDocumentIndexing
  {
    [XmlArray] public IEnumerable<Guid> SelectedCorpora { get; set; }

    /// <summary>
    ///   Gibt eine automatisch generierte Zusammenfassung des Inhalts/Bedeutung zurück.
    /// </summary>
    /// <value>The verbal.</value>
    [XmlIgnore]
    public override string Verbal => "Wähle das gesamte Korpus";

    /// <summary>
    ///   Erstellt ein neues Objekt, das eine Kopie der aktuellen Instanz darstellt.
    /// </summary>
    /// <returns>
    ///   Ein neues Objekt, das eine Kopie dieser Instanz darstellt.
    /// </returns>
    public override object Clone()
    {
      return new FilterQueryCorpusComplete
      {
        Inverse = Inverse,
        SelectedCorpora = SelectedCorpora,
        OrFilterQueries = OrFilterQueries.Select(q => q.Clone() as AbstractFilterQuery)
      };
    }

    /// <summary>
    ///   The validate call.
    /// </summary>
    /// <param name="corpus">
    ///   The corpus.
    /// </param>
    /// <param name="documentGuid">
    ///   The document guid.
    /// </param>
    /// <returns>
    ///   The <see cref="bool" />.
    /// </returns>
    protected override bool ValidateCall(AbstractCorpusAdapter corpus, Guid documentGuid)
    {
      return SelectedCorpora != null && SelectedCorpora.Any(guid => corpus.CorpusGuid == guid);
    }
  }
}