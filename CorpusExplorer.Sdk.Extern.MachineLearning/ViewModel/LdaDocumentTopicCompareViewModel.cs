using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CorpusExplorer.Sdk.Extern.MachineLearning.Blocks;
using CorpusExplorer.Sdk.Extern.MachineLearning.ViewModel.Abstract;
using CorpusExplorer.Sdk.Model;

namespace CorpusExplorer.Sdk.Extern.MachineLearning.ViewModel
{
  public class LdaDocumentTopicCompareViewModel : AbstractLdaViewModel
  {
    public Dictionary<Guid, float[]> DocumentPredictions { get; set; }

    public Selection SelectionToCompare { get; set; }

    protected override void ExecuteAnalyse()
    {
      var block = Selection.CreateBlock<LdaDocumentTopicCompareBlock>();
      block.SelectionToCompare = SelectionToCompare;
      block.MaximumNgramsCount = MaximumNgramsCount;
      block.UseAllLengths = UseAllLengths;
      block.SkipLength = SkipLength;
      block.NgramLength = NgramLength;
      block.MaximumNumberOfKeys = MaximumNumberOfKeys;
      block.KeepNumbers = KeepNumbers;
      block.KeepPunctuations = KeepPunctuations;
      block.KeepDiacritics = KeepDiacritics;
      block.LayerDisplayname = LayerDisplayname;
      block.CaseMode = CaseMode;
      block.Language = Language;
      block.WeightingCriteria = WeightingCriteria;
      block.NumberOfBurninIterations = NumberOfBurninIterations;
      block.NumberOfSummaryTermsPerTopic = NumberOfSummaryTermsPerTopic;
      block.MaximumTokenCountPerDocument = MaximumTokenCountPerDocument;
      block.LikelihoodInterval = LikelihoodInterval;
      block.MaximumNumberOfIterations = MaximumNumberOfIterations;
      block.SamplingStepCount = SamplingStepCount;
      block.Beta = Beta;
      block.AlphaSum = AlphaSum;
      block.NumberOfTopics = NumberOfTopics;
      block.Calculate();

      DocumentPredictions = block.DocumentPredictions;
    }

    protected override bool Validate() => true;

    public override DataTable GetDataTable()
    {
      var dt = new DataTable();
      dt.Columns.Add("GUID", typeof(string));
      var max = DocumentPredictions.First().Value.Length;
      for (var i = 0; i < max; i++)
        dt.Columns.Add($"DIM ({i + 1})", typeof(float));

      dt.BeginLoadData();
      foreach (var x in DocumentPredictions)
      {
        var row = new List<object> { x.Key.ToString() };
        row.AddRange(x.Value.Cast<object>());
        dt.Rows.Add(row.ToArray());
      }
      dt.EndLoadData();

      return dt;
    }
  }
}