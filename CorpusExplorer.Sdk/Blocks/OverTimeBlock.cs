using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Blocks.OverTime;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator;
using CorpusExplorer.Sdk.Ecosystem.Model;

namespace CorpusExplorer.Sdk.Blocks
{
  public class OverTimeBlock<T> : AbstractBlock
  {
    private Dictionary<DateTime, IEnumerable<Guid>> _dtp;

    public IEnumerable<KeyValuePair<DateTime, IEnumerable<Guid>>> DateTimePoints => _dtp;

    public Dictionary<DateTime, T> DateTimeValues { get; set; }
    public OverTimeCalculateDelegate<T> Function { get; set; }
    public string MetadataKey { get; set; } = "Datum";

    public override void Calculate()
    {
      var block = Selection.CreateBlock<SelectionClusterBlock>();
      block.ClusterGenerator = new SelectionClusterGeneratorDateTimeYearMonthDay();
      block.MetadataKey = MetadataKey;
      block.Calculate();

      _dtp = block.Cluster.OfType<DateTimeCluster>()
                  .ToDictionary(cluster => (DateTime) cluster.CentralValue, cluster => cluster.DocumentGuids);

      DateTimeValues = new Dictionary<DateTime, T>();
      var @lock = new object();

      Parallel.ForEach(
                       DateTimePoints,
                       Configuration.ParallelOptions,
                       point =>
                       {
                         var values = CalculateValues(point.Value);
                         lock (@lock)
                         {
                           DateTimeValues.Add(point.Key, values);
                         }
                       });
    }

    public T CalculateValues(IEnumerable<DateTime> dateTimePoints)
    {
      return
        CalculateValues(
                        new HashSet<Guid>(from point in dateTimePoints
                                          where _dtp.ContainsKey(point)
                                          from x in _dtp[point]
                                          select x));
    }

    private T CalculateValues(IEnumerable<Guid> hashSet)
    {
      try
      {
        return Function(Selection.CreateTemporary(hashSet));
      }
      catch
      {
        return default(T);
      }
    }
  }
}