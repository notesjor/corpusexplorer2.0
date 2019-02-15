using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Blocks.Partition.Delegates;
using CorpusExplorer.Sdk.Ecosystem.Model;

namespace CorpusExplorer.Sdk.Blocks.Partition
{
  public sealed class MakeMetadataDocumentPartionBlock<TV, TB> : AbstractBlock
    where TB : AbstractBlock
  {
    public PartitionBlockAggregatioDelegate<TV> AggregationDelegate { get; set; }

    public PartitionBlockMappingDelegate<TB, TV> MappingDelegate { get; set; }

    public Dictionary<string, Dictionary<string, Guid[]>> OutputPartition { get; set; }

    public Dictionary<Guid, TV> OutputPartitionValue { get; set; }

    /// <summary>
    ///   Funktion die aufgerufen wird, wenn eine Berechnung durchgeführt werden soll.
    /// </summary>
    public override void Calculate()
    {
      var block = Selection.CreateBlock<MakeSingleDocumentPartionBlock<TV, TB>>();
      block.MappingDelegate = MappingDelegate;
      if (OnConfiguration != null)
        block.OnConfiguration += OnConfiguration;
      block.Calculate();

      OutputPartitionValue = block.OutputPartition;
      OutputPartition = new Dictionary<string, Dictionary<string, Guid[]>>();

      var metas = Selection.GetDocumentMetadataPrototype();
      var @lock = new object();

      Parallel.ForEach(
                       metas,
                       Configuration.ParallelOptions,
                       meta =>
                       {
                         lock (@lock)
                         {
                           OutputPartition.Add(meta.Key, new Dictionary<string, Guid[]>());
                         }

                         Parallel.ForEach(
                                          meta.Value,
                                          Configuration.ParallelOptions,
                                          obj =>
                                          {
                                            Guid[] guids;

                                            try
                                            {
                                              guids = Selection.FindDocumentByMetadata(meta.Key, obj).ToArray();
                                            }
                                            catch
                                            {
                                              return;
                                            }

                                            // ReSharper disable once MergeConditionalExpression
                                            var key = obj == null
                                                        ? ""
                                                        : obj
                                                         .ToString(); // obj?.ToString() führt hier nicht zum gewünschten Ergebnis!

                                            lock (@lock)
                                            {
                                              if (OutputPartition[meta.Key].ContainsKey(key))
                                              {
                                                var temp = new HashSet<Guid>(OutputPartition[meta.Key][key]);
                                                foreach (var guid in guids)
                                                  temp.Add(guid);
                                                OutputPartition[meta.Key][key] = temp.ToArray();
                                              }
                                              else
                                              {
                                                OutputPartition[meta.Key].Add(key, guids);
                                              }
                                            }
                                          });
                       });
    }

    public event PartitionBlockConfiguration<TB> OnConfiguration;
  }
}