using CorpusExplorer.Sdk.Addon;
using CorpusExplorer.Sdk.Extern.MachineLearning.Configuration.Lda;
using CorpusExplorer.Sdk.Extern.MachineLearning.ViewModel;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;

namespace CorpusExplorer.Sdk.Extern.MachineLearning.Action
{
  public class LdaDocumentTopicAction : IAction
  {
    public string Action =>
      "lda-doc-cluster";

    public string Description =>
      "lda-doc-cluster [CONFIG] - [CONFIG] must be a JSON-Config file. If the file don't exists a new file will be created.";

    public void Execute(Selection selection, string[] args, AbstractTableWriter writer)
    {
      var config = new LdaConfiguration().Load(args[0]);
      var vm = new LdaDocumentTopicViewModel
      {
        Selection = selection,
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