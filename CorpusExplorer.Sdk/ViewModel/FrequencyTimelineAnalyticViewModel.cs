﻿#region

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
  public class FrequencyTimelineAnalyticViewModel : AbstractViewModel
  {
    public FrequencyTimelineAnalyticViewModel()
    {
      DateClusters = 100;
      DateClusterAuto = true;
    }

    public bool DateClusterAuto { get; set; }
    public DateTime DateClusterMax { get; set; }
    public DateTime DateClusterMin { get; set; }
    public int DateClusters { get; set; }
    public Dictionary<DateTime, IEnumerable<Guid>> DateTimeRangeDocuments { get; set; }
    public Dictionary<DateTime, Dictionary<string, double>> DateTimeRanges { get; set; }

    public IEnumerable<string> DocumentMetadata => Selection.GetDocumentMetadataPrototypeOnlyProperties();

    public string MetadataKey { get; set; }

    protected override void ExecuteAnalyse()
    {
      var blockGroup = Selection.CreateBlock<SelectionClusterBlock>();
      blockGroup.ClusterGenerator = new SelectionClusterGeneratorByDateTimeRange().Configure(
        DateClusters,
        DateClusterMin,
        DateClusterMax);
      blockGroup.MetadataKey = MetadataKey;
      blockGroup.Calculate();

      DateTimeRangeDocuments = blockGroup.Cluster.ToDictionary(x => (DateTime) x.CentralValue, x => x.DocumentGuids);

      var blockCalc =
        Selection
          .CreateBlock<MakeSeparatedPartionBlock<DateTime, Dictionary<string, double>, Frequency1LayerBlock>>();
      blockCalc.InputPartition = DateTimeRangeDocuments;
      blockCalc.MappingDelegate = block =>
      {
        block.Calculate();
        return block.FrequencyRelative;
      };

      blockCalc.Calculate();

      DateTimeRanges = blockCalc.OutputPartition;
    }

    public IEnumerable<Guid> GetDocuments(DateTime date)
    {
      return DateTimeRangeDocuments.ContainsKey(date) ? DateTimeRangeDocuments[date] : new Guid[0];
    }

    public IEnumerable<KeyValuePair<DateTime, double>> GetSpecificRange(IEnumerable<string> values)
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

      return dictionary.Select(x => x).OrderBy(x => x.Key);
    }

    public string GetText(Guid documentGuid, string layerDisplayname = null)
    {
      if (string.IsNullOrEmpty(layerDisplayname))
        layerDisplayname = "Wort";
      return Selection.GetReadableDocument(documentGuid, layerDisplayname).ConvertToText();
    }

    protected override bool Validate() { return !string.IsNullOrEmpty(MetadataKey); }
  }
}