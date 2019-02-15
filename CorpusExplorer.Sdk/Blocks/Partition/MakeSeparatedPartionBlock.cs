#region

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Blocks.Partition.Delegates;
using CorpusExplorer.Sdk.Ecosystem.Model;

#endregion

namespace CorpusExplorer.Sdk.Blocks.Partition
{
  /// <summary>
  ///   Durchläuft eine partitionierte Auflistung von Dokumenten und führt für alle die gleichen Analysen durch.
  ///   Die Dokumente werden getrennt (pro Partion) berechnet.
  /// </summary>
  /// <typeparam name="TK">Schlüssel der Input/Output-Partition</typeparam>
  /// <typeparam name="TV">Wert der Outputpartion</typeparam>
  /// <typeparam name="TB">Block der zur Analyse verwendet wird.</typeparam>
  [Serializable]
  public sealed class MakeSeparatedPartionBlock<TK, TV, TB> : AbstractBlock
    where TB : AbstractBlock
  {
    public Dictionary<TK, IEnumerable<Guid>> InputPartition { get; set; }
    public PartitionBlockMappingDelegate<TB, TV> MappingDelegate { get; set; }
    public Dictionary<TK, TV> OutputPartition { get; set; }

    /// <summary>
    ///   Funktion die aufgerufen wird, wenn eine Berechnung durchgeführt werden soll.
    /// </summary>
    public override void Calculate()
    {
      var dic = new ConcurrentDictionary<TK, TV>();

      Parallel.ForEach(
                       InputPartition,
                       Configuration.ParallelOptions,
                       part =>
                         dic.TryAdd(part.Key,
                                    MappingDelegate(Selection.CreateTemporary(part.Value).CreateBlock<TB>())));

      OutputPartition = dic.ToDictionary(x => x.Key, x => x.Value);
    }
  }
}