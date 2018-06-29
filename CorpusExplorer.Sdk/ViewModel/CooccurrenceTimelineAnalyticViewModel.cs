#region

using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Blocks.Partition;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.ViewModel.Abstract;

#endregion

namespace CorpusExplorer.Sdk.ViewModel
{
  /// <summary>
  ///   Zusammenfassungsbeschreibung für FrequencyTimelineAnalyticViewModel
  /// </summary>
  public class CooccurrenceTimelineAnalyticViewModel : AbstractViewModel
  {
    public CooccurrenceTimelineAnalyticViewModel()
    {
      DateClusters = 100;
    }

    public bool AutoDetectDateClusterMinMax { get; set; } = true;
    public DateTime DateClusterMax { get; set; }
    public DateTime DateClusterMin { get; set; }
    public int DateClusters { get; set; }
    public Dictionary<DateTime, IEnumerable<Guid>> DateTimeRangeDocuments { get; set; }
    public Dictionary<DateTime, Dictionary<string, Dictionary<string, double>>> DateTimeRanges { get; set; }

    public IEnumerable<string> DocumentMetadata => Selection.GetDocumentMetadataPrototypeOnlyProperties();

    public string MetadataKey { get; set; }

    public IEnumerable<Guid> GetDocuments(DateTime date)
    {
      return DateTimeRangeDocuments.ContainsKey(date) ? DateTimeRangeDocuments[date] : new Guid[0];
    }

    public IEnumerable<KeyValuePair<DateTime, double>> GetSpecificRange(string wordA, string wordB)
    {
      return DateTimeRanges?.ToDictionary(
        range => range.Key,
        range => range.Value.ContainsKey(wordA) && range.Value[wordA].ContainsKey(wordB)
          ? range.Value[wordA][wordB]
          : 0);
    }

    public string GetText(Guid documentGuid, string layerDisplayname = null)
    {
      if (string.IsNullOrEmpty(layerDisplayname))
        layerDisplayname = "Wort";
      return Selection.GetReadableDocument(documentGuid, layerDisplayname).ConvertToText();
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
          .CreateBlock
            <MakeSeparatedPartionBlock<DateTime, Dictionary<string, Dictionary<string, double>>, CooccurrenceBlock>>();
      blockCalc.InputPartition = DateTimeRangeDocuments;
      blockCalc.MappingDelegate = block =>
      {
        block.Calculate();
        return block.CooccurrenceSignificance.CompleteDictionaryToFullDictionary();
      };
      blockCalc.Calculate();

      DateTimeRanges = blockCalc.OutputPartition;
    }

    protected override bool Validate()
    {
      return !string.IsNullOrEmpty(MetadataKey);
    }
  }
}