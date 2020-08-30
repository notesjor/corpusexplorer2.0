using System.Collections.Generic;
using System.Data;
using CorpusExplorer.Sdk.Extern.MachineLearning.Blocks;
using CorpusExplorer.Sdk.Extern.MachineLearning.ViewModel.Abstract;

namespace CorpusExplorer.Sdk.Extern.MachineLearning.ViewModel
{
  public class LdaTopicListViewModel : AbstractLdaViewModel
  {
    public Dictionary<string, float>[] Topics { get; private set; }

    public float Treshold { get; set; } = 1;

    protected override void ExecuteAnalyse()
    {
      var block = Selection.CreateBlock<LdaTopicListBlock>();
      block.Treshold = Treshold;
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

      Topics = block.Topics;
    }

    protected override bool Validate() => true;

    public override DataTable GetDataTable()
    {
      var dt = new DataTable();
      dt.Columns.Add("DIM", typeof(int));
      dt.Columns.Add(LayerDisplayname, typeof(string));
      dt.Columns.Add("Likelihood", typeof(double));

      dt.BeginLoadData();
      for (var i = 0; i < Topics.Length; i++)
        foreach (var x in Topics[i])
          dt.Rows.Add(i, x.Key, x.Value);
      dt.EndLoadData();

      return dt;
    }
  }
}