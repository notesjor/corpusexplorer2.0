using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Properties;

namespace CorpusExplorer.Sdk.Blocks
{
  public class DocumentMetadataFiniteStateMachineBlock : AbstractBlock
  {
    public Dictionary<string, List<Tuple<string, HashSet<Guid>>>> FiniteStates { get; set; }

    public string MetadataKeyEntity { get; set; } = "Autor";

    public string MetadataKeyLevel { get; set; } = Resources.Newspaper;
    public string MetadataKeyTimestamp { get; set; } = "Datum";

    public override void Calculate()
    {
      FiniteStates = new Dictionary<string, List<Tuple<string, HashSet<Guid>>>>();

      var meta = Selection.DocumentMetadata.ToDictionary(x => x.Key, x => x.Value);

      var block = Selection.CreateBlock<SortDocuments>();
      block.MetadataKey = MetadataKeyTimestamp;
      block.Calculate();

      foreach (var dsel in block.DocumentGuids)
      {
        var dmeta = meta[dsel];
        if (!dmeta.ContainsKey(MetadataKeyEntity) || !dmeta.ContainsKey(MetadataKeyLevel))
          continue;

        var entity = dmeta[MetadataKeyEntity]?.ToString() ?? "";
        var level = dmeta[MetadataKeyLevel]?.ToString() ?? "";

        if (FiniteStates.ContainsKey(entity))
          if (FiniteStates[entity].Last().Item1 == level)
            FiniteStates[entity].Last().Item2.Add(dsel);
          else
            FiniteStates[entity].Add(new Tuple<string, HashSet<Guid>>(level, new HashSet<Guid> {dsel}));
        else
          FiniteStates.Add(
            entity,
            new List<Tuple<string, HashSet<Guid>>> {new Tuple<string, HashSet<Guid>>(level, new HashSet<Guid> {dsel})});
      }
    }
  }
}