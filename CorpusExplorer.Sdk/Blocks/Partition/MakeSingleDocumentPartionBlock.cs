using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Blocks.Partition.Delegates;
using CorpusExplorer.Sdk.Diagnostic;
using CorpusExplorer.Sdk.Ecosystem.Model;

namespace CorpusExplorer.Sdk.Blocks.Partition
{
  /// <summary>
  ///   Durchläuft eine partitionierte Auflistung von Dokumenten und führt für alle die gleichen Analysen durch.
  ///   Die Dokumente werden getrennt (pro Partion) berechnet.
  /// </summary>
  /// <typeparam name="TV">Wert der Outputpartion</typeparam>
  /// <typeparam name="TB">Block der zur Analyse verwendet wird.</typeparam>
  [Serializable]
  public sealed class MakeSingleDocumentPartionBlock<TV, TB> : AbstractBlock
    where TB : AbstractBlock
  {
    public PartitionBlockMappingDelegate<TB, TV> MappingDelegate { get; set; }
    public Dictionary<Guid, TV> OutputPartition { get; set; }

    /// <summary>
    ///   Funktion die aufgerufen wird, wenn eine Berechnung durchgeführt werden soll.
    /// </summary>
    public override void Calculate()
    {
      var dic = new ConcurrentDictionary<Guid, TV>();

      Parallel.ForEach(
                       Selection.DocumentGuids,
                       Configuration.ParallelOptions,
                       part =>
                       {
                         try
                         {
                           var block = Selection.CreateTemporary(new[] {part}).CreateBlock<TB>();
                           if (OnConfiguration != null)
                             block = OnConfiguration(block);
                           block.Calculate();
                           dic.TryAdd(part, MappingDelegate(block));
                         }
                         catch (Exception ex)
                         {
                           InMemoryErrorConsole.Log(ex);
                         }
                       });

      OutputPartition = dic.ToDictionary(x => x.Key, x => x.Value);
    }

    public event PartitionBlockConfiguration<TB> OnConfiguration;
  }
}