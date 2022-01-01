#region

using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Model;
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

    public Selection ResultSelection { get; set; }
    public Dictionary<Guid, Dictionary<Guid, Dictionary<int, HashSet<int>>>> SearchResults { get; set; }

    /// <summary>
    ///   Funktion die aufgerufen wird, wenn eine Berechnung durchgeführt werden soll.
    /// </summary>
    public override void Calculate()
    {
      SearchResults = QuickQuery.SearchOnWordLevel(Selection, LayerQueries);
      ResultSelection =
        Selection.CreateTemporary(
                                  SearchResults.ToDictionary(
                                                             x => x.Key,
                                                             x => new HashSet<Guid>(x.Value.Select(y => y.Key))));
    }
  }
}