using System;
using System.Collections.Generic;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Blocks.Partition.Delegates;

namespace CorpusExplorer.Sdk.Blocks.Partition
{
  /// <summary>
  ///   Durchläuft eine partitionierte Auflistung von Dokumenten und führt für alle die gleichen Analysen durch.
  ///   Die Partionen werden ansteigend aggregiert.
  /// </summary>
  /// <typeparam name="TK">Schlüssel der Input/Output-Partition</typeparam>
  /// <typeparam name="TV">Wert der Outputpartion</typeparam>
  /// <typeparam name="TB">Block der zur Analyse verwendet wird.</typeparam>
  [Serializable]
  public sealed class MakeAggregatedPartionBlock<TK, TV, TB> : AbstractBlock
    where TB : AbstractBlock
  {
    public PartitionBlockAggregatioDelegate<TV> AggregationDelegate { get; set; }

    public Dictionary<TK, IEnumerable<Guid>> InputPartition { get; set; }
    public PartitionBlockMappingDelegate<TB, TV> MappingDelegate { get; set; }
    public Dictionary<TK, TV> OutputPartition { get; set; }

    /// <summary>
    ///   Funktion die aufgerufen wird, wenn eine Berechnung durchgeführt werden soll.
    /// </summary>
    public override void Calculate()
    {
      var res = new Dictionary<TK, TV>();
      var memory = Activator.CreateInstance<TV>();

      foreach (var part in InputPartition)
        try
        {
          var v = MappingDelegate(Selection.CreateTemporary(part.Value).CreateBlock<TB>());
          if (v == null)
            continue;

          AggregationDelegate(ref memory, ref v);
          res.Add(part.Key, v);
        }
        catch
        {
          res.Add(part.Key, default(TV));
        }

      OutputPartition = res;
    }
  }
}