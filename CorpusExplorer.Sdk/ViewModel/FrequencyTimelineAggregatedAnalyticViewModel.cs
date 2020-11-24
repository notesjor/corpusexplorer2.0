using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Blocks.Partition;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.ViewModel.Abstract;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class FrequencyTimelineAggregatedAnalyticViewModel : AbstractViewModel
  {
    public bool AutoDetectDateClusterMinMax { get; set; } = true;
    public DateTime DateClusterMax { get; set; }
    public DateTime DateClusterMin { get; set; }
    public int DateClusters { get; set; } = 100;
    public Dictionary<DateTime, IEnumerable<Guid>> DateTimeRangeDocuments { get; set; }
    public Dictionary<DateTime, Dictionary<string, double>> DateTimeRanges { get; set; }

    public IEnumerable<string> DocumentMetadata => Selection.GetDocumentMetadataPrototypeOnlyProperties();

    public string MetadataKey { get; set; }

    public IEnumerable<Guid> GetDocuments(DateTime date)
    {
      return DateTimeRangeDocuments.ContainsKey(date) ? DateTimeRangeDocuments[date] : new Guid[0];
    }

    public Dictionary<DateTime, double> GetSpecificRange(IEnumerable<string> values)
    {
      if (DateTimeRanges == null)
        return null;

      var dictionary = new Dictionary<DateTime, double>();

      foreach (var value in values)
      foreach (var range in DateTimeRanges.Where(range => range.Value.ContainsKey(value)))
      {
        var key = new DateTime(range.Key.Year, range.Key.Month, range.Key.Day);

        if (dictionary.ContainsKey(key))
          dictionary[key] += range.Value[value];
        else
          dictionary.Add(key, range.Value[value]);
      }

      return dictionary;
    }

    public string GetText(Guid documentGuid, string layerDisplayname = null)
    {
      if (string.IsNullOrEmpty(layerDisplayname))
        layerDisplayname = "Wort";
      return Selection.GetReadableDocument(documentGuid, layerDisplayname).ReduceDocumentToText();
    }

    protected override void ExecuteAnalyse()
    {
      var blockGroup = Selection.CreateBlock<SelectionClusterBlock>();
      blockGroup.ClusterGenerator = new SelectionClusterGeneratorDateTimeRange
      {
        Ranges = DateClusters,
        Min = DateClusterMin,
        Max = DateClusterMax,
        AutoDetectMinMax = AutoDetectDateClusterMinMax
      };
      blockGroup.MetadataKey = MetadataKey;
      blockGroup.Calculate();

      DateTimeRangeDocuments = blockGroup.Cluster.ToDictionary(x => (DateTime) x.CentralValue, x => x.DocumentGuids);

      var blockCalc =
        Selection
         .CreateBlock<MakeAggregatedPartionBlock<DateTime, Dictionary<string, double>, Frequency1LayerBlock>>();
      blockCalc.InputPartition = DateTimeRangeDocuments;
      blockCalc.MappingDelegate = block =>
      {
        block.Calculate();
        return block.FrequencyRelative;
      };
      blockCalc.AggregationDelegate = Aggregate;
      blockCalc.Calculate();

      DateTimeRanges = blockCalc.OutputPartition;
    }

    protected override bool Validate()
    {
      return !string.IsNullOrEmpty(MetadataKey);
    }

    private void Aggregate(ref Dictionary<string, double> memory, ref Dictionary<string, double> v)
    {
      if (memory == null)
        memory = new Dictionary<string, double>();

      var keys = v.Keys.ToArray();
      foreach (var x in keys)
        if (memory.ContainsKey(x))
        {
          v[x] += memory[x];
          memory[x] = v[x];
        }
        else
        {
          memory.Add(x, v[x]);
        }
    }
  }
}