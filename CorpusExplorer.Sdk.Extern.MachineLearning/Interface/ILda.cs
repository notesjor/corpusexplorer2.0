using CorpusExplorer.Sdk.Extern.MachineLearning.Blocks.Lda;

namespace CorpusExplorer.Sdk.Extern.MachineLearning.Interface
{
  public interface ILda
  {
    int MaximumNgramsCount { get; set; }
    bool UseAllLengths { get; set; }
    int SkipLength { get; set; }
    int NgramLength { get; set; }
    int MaximumNumberOfKeys { get; set; }
    bool KeepNumbers { get; set; }
    bool KeepPunctuations { get; set; }
    bool KeepDiacritics { get; set; }
    string LayerDisplayname { get; set; }
    CaseMode CaseMode { get; set; }
    Language Language { get; set; }
    WeightingCriteria WeightingCriteria { get; set; }
    int NumberOfBurninIterations { get; set; }
    int NumberOfSummaryTermsPerTopic { get; set; }
    int MaximumTokenCountPerDocument { get; set; }
    int LikelihoodInterval { get; set; }
    int MaximumNumberOfIterations { get; set; }
    int SamplingStepCount { get; set; }
    float Beta { get; set; }
    float AlphaSum { get; set; }
    int NumberOfTopics { get; set; }
  }
}