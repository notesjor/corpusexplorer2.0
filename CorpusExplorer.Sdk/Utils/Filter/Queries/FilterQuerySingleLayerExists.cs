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
  /// <summary>
  ///   The any single layer filter query.
  /// </summary>
  [XmlRoot]
  [Serializable]
  public class FilterQuerySingleLayerExists : AbstractFilterQueryCompleteDocumentIndexing
  {
    public string LayerDisplayname { get; set; } = "Wort";

    /// <summary>
    ///   Gibt eine automatisch generierte Zusammenfassung des Inhalts/Bedeutung zurück.
    /// </summary>
    /// <value>The verbal.</value>
    [XmlIgnore]
    public override string Verbal
    {
      get
      {
        return $"Verfügt das Dokument über den Layer: {LayerDisplayname}?";
      }
    }

    private Dictionary<Guid, Guid> _cache = new Dictionary<Guid, Guid>();

    protected override bool ValidateCall(AbstractCorpusAdapter corpus, Guid documentGuid)
    {
      try
      {
        if (!_cache.ContainsKey(corpus.CorpusGuid))
        {
          var tmp = corpus.LayerGuidAndDisplaynames.ToDictionary(x => x.Key, x => x.Value);
          _cache.Add(corpus.CorpusGuid, tmp.FirstOrDefault(x => x.Value == LayerDisplayname).Key);
        }

        return _cache[corpus.CorpusGuid] != Guid.Empty && corpus.GetLayer(_cache[corpus.CorpusGuid]).ContainsDocument(documentGuid);
      }
      catch
      {
        return false;
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
      return new FilterQuerySingleLayerExists
      {
        Inverse = Inverse,
        LayerDisplayname = LayerDisplayname,
        OrFilterQueries = OrFilterQueries.Select(q => q.Clone() as AbstractFilterQuery),
      };
    }
  }
}