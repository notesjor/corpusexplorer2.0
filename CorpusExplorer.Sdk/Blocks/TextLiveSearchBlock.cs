#region

using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Model.CorpusExplorer;
using CorpusExplorer.Sdk.Utils.Filter;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Blocks
{
  [Serializable]
  public class TextLiveSearchBlock : AbstractBlock
  {
    [NonSerialized] private IEnumerable<AbstractFilterQuery> _layerQueries;

    public IEnumerable<AbstractFilterQuery> LayerQueries
    {
      get => _layerQueries;
      set => _layerQueries = value;
    }

    public enum SearchMode
    {
      And,
      Or
    }

    public SearchMode Mode { get; set; } = SearchMode.Or;

    public Selection ResultSelection { get; set; }
    public Dictionary<Guid, Dictionary<Guid, Dictionary<int, HashSet<CeRange>>>> SearchResults { get; set; }
    public Dictionary<Guid, int[]> SearchResultsSimpleDocumentSentence
      => SearchResults.SelectMany(c => c.Value).ToDictionary(d => d.Key, d => d.Value.Keys.ToArray());

    /// <summary>
    ///   Funktion die aufgerufen wird, wenn eine Berechnung durchgeführt werden soll.
    /// </summary>
    public override void Calculate()
    {
      SearchResults = 
        Mode == SearchMode.And 
          ? QuickQuery.AndSearchOnWordLevel(Selection, LayerQueries) 
          : QuickQuery.OrSearchOnWordLevel(Selection, LayerQueries);

      ResultSelection =
        Selection.CreateTemporary(
                                  SearchResults.ToDictionary(
                                                             x => x.Key,
                                                             x => new HashSet<Guid>(x.Value.Select(y => y.Key))));
    }
  }
}