using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Properties;
using CorpusExplorer.Sdk.ViewModel.Abstract;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class CorpusFiniteStateMachineViewModel : AbstractViewModel
  {
    public IEnumerable<string> AvailableMetadata => Selection.GetDocumentMetadataPrototypeOnlyProperties();

    public Dictionary<string, HashSet<string>> ConnectionsAggregated
      => FiniteStates.ToDictionary(state => state.Key, state => new HashSet<string>(state.Value.Select(x => x.Item1)));

    public IEnumerable<List<string>> ConnectionsFlow
    {
      get
      {
        var res = new List<List<string>>();
        foreach (var state in FiniteStates)
        {
          var n = new List<string> {state.Key};
          n.AddRange(state.Value.Select(t => t.Item1));
          res.Add(n);
        }
        return res;
      }
    }

    public IEnumerable<string> Entities => FiniteStates.Keys;

    public Dictionary<string, List<Tuple<string, HashSet<Guid>>>> FiniteStates { get; set; }

    public IEnumerable<string> Levels => new HashSet<string>(from x in FiniteStates from y in x.Value select y.Item1);

    public string MetadataKeyEntity { get; set; } = "Autor";

    public string MetadataKeyLevel { get; set; } = Resources.Newspaper;

    public string MetadataKeyTimestamp { get; set; } = "Datum";

    protected override void ExecuteAnalyse()
    {
      var block = Selection.CreateBlock<DocumentMetadataFiniteStateMachineBlock>();
      block.MetadataKeyTimestamp = MetadataKeyTimestamp;
      block.MetadataKeyEntity = MetadataKeyEntity;
      block.MetadataKeyLevel = MetadataKeyLevel;
      block.Calculate();

      FiniteStates = block.FiniteStates;
    }

    protected override bool Validate() { return true; }
  }
}