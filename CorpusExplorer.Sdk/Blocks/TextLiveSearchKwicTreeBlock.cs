using System;
using System.Collections.Generic;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Utils.Filter;
using CorpusExplorer.Sdk.Utils.Filter.Queries;

namespace CorpusExplorer.Sdk.Blocks
{
  [Serializable]
  public class TextLiveSearchKwicTreeBlock : AbstractBlock
  {
    [NonSerialized]
    private IEnumerable<string> _layerQueries;

    public IEnumerable<string> LayerQueries { get => _layerQueries; set => _layerQueries = value; }

    public Dictionary<Guid, Dictionary<Guid, Dictionary<int, HashSet<int>>>> SearchResults { get; set; }

    /// <summary>
    ///   Funktion die aufgerufen wird, wenn eine Berechnung durchgeführt werden soll.
    /// </summary>
    public override void Calculate()
    {
      SearchResults = QueryFilter.SearchOnWordLevel(
        Selection,
        new[] {new FilterQuerySingleLayerExactPhrase {LayerQueries = LayerQueries}});
    }
  }
}