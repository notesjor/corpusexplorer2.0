using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Addon;
using CorpusExplorer.Sdk.Extern.MachineLearning.Configuration.Lda;
using CorpusExplorer.Sdk.Extern.MachineLearning.ViewModel;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;

namespace CorpusExplorer.Sdk.Extern.MachineLearning.Action
{
  public class LdaTopicAction : IAction
  {
    public string Action => 
      "lda-topics";

    public string Description =>
      "lda-topics [CONFIG] - [CONFIG] must be a JSON-Config file. If the file don't exists a new file will be created.";

    public void Execute(Selection selection, string[] args, AbstractTableWriter writer)
    {
      var config = new LdaTopicListConfiguration().Load(args[0]);
      var vm = new LdaTopicListViewModel
      {
        Selection = selection,
        Treshold = config.Treshold,
        MaximumNgramsCount = config.MaximumNgramsCount,
        UseAllLengths = config.UseAllLengths,
        SkipLength = config.SkipLength,
        NgramLength = config.NgramLength,
        MaximumNumberOfKeys = config.MaximumNumberOfKeys,
        KeepNumbers = config.KeepNumbers,
        KeepPunctuations = config.KeepPunctuations,
        KeepDiacritics = config.KeepDiacritics,
        LayerDisplayname = config.LayerDisplayname,
        CaseMode = config.CaseMode,
        Language = config.Language,
        WeightingCriteria = config.WeightingCriteria,
        NumberOfBurninIterations = config.NumberOfBurninIterations,
        NumberOfSummaryTermsPerTopic = config.NumberOfSummaryTermsPerTopic,
        MaximumTokenCountPerDocument = config.MaximumTokenCountPerDocument,
        LikelihoodInterval = config.LikelihoodInterval,
        MaximumNumberOfIterations = config.MaximumNumberOfIterations,
        SamplingStepCount = config.SamplingStepCount,
        Beta = config.Beta,
        AlphaSum = config.AlphaSum,
        NumberOfTopics = config.NumberOfTopics
      };
      vm.Execute();

      writer.WriteTable(vm.GetDataTable());
    }
  }
}
