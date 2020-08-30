using System.Linq;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Extern.MachineLearning.Blocks.Lda;
using CorpusExplorer.Sdk.Extern.MachineLearning.Interface;
using CorpusExplorer.Sdk.Helper;
using Microsoft.ML;
using Microsoft.ML.Transforms.Text;

namespace CorpusExplorer.Sdk.Extern.MachineLearning.Blocks.Abstract
{
  public abstract class AbstractLdaBlock : AbstractBlock, ILda
  {
    public int MaximumNgramsCount { get; set; } = 10000000;

    public bool UseAllLengths { get; set; } = true;

    public int SkipLength { get; set; } = 0;

    public int NgramLength { get; set; } = 2;

    public int MaximumNumberOfKeys { get; set; } = 1000000;

    public bool KeepNumbers { get; set; } = false;

    public bool KeepPunctuations { get; set; } = true;

    public bool KeepDiacritics { get; set; } = true;

    public string LayerDisplayname { get; set; } = "Lemma";

    public CaseMode CaseMode { get; set; } = CaseMode.None;

    public Language Language { get; set; } = Language.German;

    public WeightingCriteria WeightingCriteria { get; set; } = WeightingCriteria.Tf;

    private PredictionEngine<TextData, TransformedTextData> Model { get; set; }

    private class TextData
    {
      public string Text { get; set; }
    }

    private class TransformedTextData : TextData
    {
      public float[] Features { get; set; }
    }

    public override void Calculate()
    {
      var mlContext = new MLContext();

      var pipeline = mlContext.Transforms.Text
                              .NormalizeText("NormalizedText", "Text", GetCaseMode(), KeepDiacritics,
                                             KeepPunctuations, KeepNumbers)
                              .Append(mlContext.Transforms.Text.TokenizeIntoWords("Tokens", "NormalizedText"))
                              .Append(mlContext.Transforms.Text.RemoveDefaultStopWords("Tokens",
                                                                                       language: GetLanguage()))
                              .Append(mlContext.Transforms.Conversion.MapValueToKey("Tokens",
                                                                                    maximumNumberOfKeys:
                                                                                    MaximumNumberOfKeys))
                              .Append(mlContext.Transforms.Text.ProduceNgrams("Tokens", ngramLength: NgramLength,
                                                                              skipLength: SkipLength,
                                                                              useAllLengths: UseAllLengths,
                                                                              maximumNgramsCount: MaximumNgramsCount,
                                                                              weighting: GetWeightingCriteria()))
                              .Append(mlContext.Transforms.Text.LatentDirichletAllocation("Features", "Tokens",
                                                                                          NumberOfTopics, AlphaSum,
                                                                                          Beta, SamplingStepCount,
                                                                                          MaximumNumberOfIterations,
                                                                                          LikelihoodInterval, 0,
                                                                                          MaximumTokenCountPerDocument,
                                                                                          NumberOfSummaryTermsPerTopic,
                                                                                          NumberOfBurninIterations));

      var data = mlContext.Data.LoadFromEnumerable(Selection.DocumentGuids.Select(dsel => new TextData
      {
        Text = Selection.GetReadableDocument(dsel, LayerDisplayname).ReduceDocumentToText()
      }));
      var transformer = pipeline.Fit(data);
      Model = mlContext.Model.CreatePredictionEngine<TextData, TransformedTextData>(transformer);
      
      PostCalculate();
    }

    protected abstract void PostCalculate();

    public int NumberOfBurninIterations { get; set; } = 10;

    public int NumberOfSummaryTermsPerTopic { get; set; } = 10;

    public int MaximumTokenCountPerDocument { get; set; } = 512;

    public int LikelihoodInterval { get; set; } = 5;

    public int MaximumNumberOfIterations { get; set; } = 200;

    public int SamplingStepCount { get; set; } = 4;

    public float Beta { get; set; } = 0.01f;

    public float AlphaSum { get; set; } = 100;

    public int NumberOfTopics { get; set; } = 5;

    public float[] Predict(string text)
      => Model.Predict(new TextData { Text = text }).Features;

    private NgramExtractingEstimator.WeightingCriteria GetWeightingCriteria()
    {
      switch (WeightingCriteria)
      {
        case WeightingCriteria.Idf:
          return NgramExtractingEstimator.WeightingCriteria.Idf;
        case WeightingCriteria.TfIdf:
          return NgramExtractingEstimator.WeightingCriteria.TfIdf;
        default:
          return NgramExtractingEstimator.WeightingCriteria.Tf;
      }
    }

    private StopWordsRemovingEstimator.Language GetLanguage()
    {
      switch (Language)
      {
        case Language.English:
          return StopWordsRemovingEstimator.Language.English;
        case Language.French:
          return StopWordsRemovingEstimator.Language.French;
        default:
          return StopWordsRemovingEstimator.Language.German;
        case Language.Dutch:
          return StopWordsRemovingEstimator.Language.Dutch;
        case Language.Danish:
          return StopWordsRemovingEstimator.Language.Danish;
        case Language.Swedish:
          return StopWordsRemovingEstimator.Language.Swedish;
        case Language.Italian:
          return StopWordsRemovingEstimator.Language.Italian;
        case Language.Spanish:
          return StopWordsRemovingEstimator.Language.Spanish;
        case Language.Portuguese:
          return StopWordsRemovingEstimator.Language.Portuguese;
        case Language.Brazilian:
          return StopWordsRemovingEstimator.Language.Portuguese_Brazilian;
        case Language.Norwegian:
          return StopWordsRemovingEstimator.Language.Norwegian_Bokmal;
        case Language.Russian:
          return StopWordsRemovingEstimator.Language.Russian;
        case Language.Polish:
          return StopWordsRemovingEstimator.Language.Polish;
        case Language.Czech:
          return StopWordsRemovingEstimator.Language.Czech;
        case Language.Arabic:
          return StopWordsRemovingEstimator.Language.Arabic;
        case Language.Japanese:
          return StopWordsRemovingEstimator.Language.Japanese;
      }
    }

    private TextNormalizingEstimator.CaseMode GetCaseMode()
    {
      switch (CaseMode)
      {
        case CaseMode.Lower:
          return TextNormalizingEstimator.CaseMode.Lower;
        case CaseMode.Upper:
          return TextNormalizingEstimator.CaseMode.Upper;
        default:
          return TextNormalizingEstimator.CaseMode.None;
      }
    }
  }
}
