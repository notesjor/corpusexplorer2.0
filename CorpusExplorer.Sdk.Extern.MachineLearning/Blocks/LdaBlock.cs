using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Diagnostic;
using CorpusExplorer.Sdk.Extern.MachineLearning.Blocks.Lda;
using CorpusExplorer.Sdk.Extern.MachineLearning.Configuration.Lda;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Transforms.Text;

namespace CorpusExplorer.Sdk.Extern.MachineLearning.Blocks
{
  public class LdaBlock : AbstractBlock 
  {
    private Dictionary<Guid, float[]> _documentPredictions;
    private Dictionary<string, float>[] _topics;
    protected PredictionEngine<TextData, TransformedTextData> Model { get; set; }

    protected class TextData
    {
      public string Text { get; set; }
    }

    protected class TransformedTextData : TextData
    {
      public float[] Features { get; set; }
    }

    public LdaConfiguration Configuration { get; set; } = new LdaConfiguration();

    public override void Calculate()
    {
      try
      {
        Context = new MLContext();

        Transformer = GetPipeline().Fit(Context.Data.LoadFromEnumerable(Selection.DocumentGuids
                                                                         .Select(dsel => Selection
                                                                           .GetReadableDocument(dsel,
                                                                             Configuration.LayerDisplayname)
                                                                           .ReduceDocumentToText())
                                                                         .Where(x => !string.IsNullOrWhiteSpace(x))
                                                                         .Select(x => new TextData
                                                                          {
                                                                            Text = x
                                                                          }).ToArray()));
        Model = Context.Model.CreatePredictionEngine<TextData, TransformedTextData>(Transformer);
        Schema = Model.OutputSchema;
      }
      catch (Exception ex)
      {
        InMemoryErrorConsole.Log(ex);
      }
    }

    public Dictionary<Guid, float[]> DocumentPredictions
      => _documentPredictions ?? (_documentPredictions = CalcDocumentPredictions(Selection));

    public Dictionary<Guid, float[]> CalcDocumentPredictions(Selection selection)
    {
      var res = new Dictionary<Guid, float[]>();
      var @lock = new object();

      Parallel.ForEach(selection.DocumentGuids, dsel =>
      {
        try
        {
          var text = selection.GetReadableDocument(dsel, Configuration.LayerDisplayname).ReduceDocumentToText();
          var predict = Predict(text);
          if (predict == null)
          {
            predict = new float[Configuration.NumberOfTopics];
            predict.Initialize();
          }

          lock (@lock)
            res.Add(dsel, predict);
        }
        catch
        {
          // ignore
        }
      });

      return res;
    }

    public Dictionary<string, float>[] Topics
      => _topics ?? (_topics = CalcTopics());

    private Dictionary<string, float>[] CalcTopics()
    {
      Transformer.LastTransformer.GetLdaDetails(0);

      var res = new Dictionary<string, float>[Configuration.NumberOfTopics];
      var scores = Transformer.LastTransformer.GetLdaDetails(0);

      var i = 0;
      foreach (IReadOnlyList<LatentDirichletAllocationTransformer.ModelParameters.WordItemScore> w in scores.WordScoresPerTopic)
        res[i++] = w.ToDictionary(score => score.Word, score => score.Score);

      return res;
    }

    private EstimatorChain<LatentDirichletAllocationTransformer> GetPipeline()
    {
      return Configuration.Language == Language.None
               ? Context.Transforms.Text
                        .NormalizeText("NormalizedText", "Text", GetCaseMode(), Configuration.KeepDiacritics,
                                       Configuration.KeepPunctuations, Configuration.KeepNumbers)
                        .Append(Context.Transforms.Text.TokenizeIntoWords("Tokens", "NormalizedText"))
                        .Append(Context.Transforms.Conversion.MapValueToKey("Tokens",
                                                                            maximumNumberOfKeys:
                                                                            Configuration.MaximumNumberOfKeys))
                        .Append(Context.Transforms.Text.ProduceNgrams("Tokens", ngramLength: Configuration.NgramLength,
                                                                      skipLength: Configuration.SkipLength,
                                                                      useAllLengths: Configuration.UseAllLengths,
                                                                      maximumNgramsCount: Configuration.MaximumNgramsCount,
                                                                      weighting: NgramExtractingEstimator.WeightingCriteria.Tf))
                        .Append(Context.Transforms.Text.LatentDirichletAllocation("Features", "Tokens",
                                 Configuration.NumberOfTopics, Configuration.AlphaSum,
                                 Configuration.Beta, Configuration.SamplingStepCount,
                                 Configuration.MaximumNumberOfIterations,
                                 Configuration.LikelihoodInterval, Ecosystem.Model.Configuration.ParallelOptions.MaxDegreeOfParallelism,
                                 Configuration.MaximumTokenCountPerDocument,
                                 Configuration.NumberOfSummaryTermsPerTopic,
                                 Configuration.NumberOfBurninIterations))
               : Context.Transforms.Text
                        .NormalizeText("NormalizedText", "Text", GetCaseMode(), Configuration.KeepDiacritics,
                                       Configuration.KeepPunctuations, Configuration.KeepNumbers)
                        .Append(Context.Transforms.Text.TokenizeIntoWords("Tokens", "NormalizedText"))
                        .Append(Context.Transforms.Text.RemoveDefaultStopWords("Tokens",
                                                                               language: GetLanguage()))
                        .Append(Context.Transforms.Conversion.MapValueToKey("Tokens",
                                                                            maximumNumberOfKeys:
                                                                            Configuration.MaximumNumberOfKeys))
                        .Append(Context.Transforms.Text.ProduceNgrams("Tokens", ngramLength: Configuration.NgramLength,
                                                                      skipLength: Configuration.SkipLength,
                                                                      useAllLengths: Configuration.UseAllLengths,
                                                                      maximumNgramsCount: Configuration.MaximumNgramsCount,
                                                                      weighting: NgramExtractingEstimator.WeightingCriteria.Tf))
                        .Append(Context.Transforms.Text.LatentDirichletAllocation("Features", "Tokens",
                                 Configuration.NumberOfTopics, Configuration.AlphaSum,
                                 Configuration.Beta, Configuration.SamplingStepCount,
                                 Configuration.MaximumNumberOfIterations,
                                 Configuration.LikelihoodInterval, Ecosystem.Model.Configuration.ParallelOptions.MaxDegreeOfParallelism,
                                 Configuration.MaximumTokenCountPerDocument,
                                 Configuration.NumberOfSummaryTermsPerTopic,
                                 Configuration.NumberOfBurninIterations));
    }

    private TransformerChain<LatentDirichletAllocationTransformer> Transformer { get; set; }

    private DataViewSchema Schema { get; set; }

    private MLContext Context { get; set; }

    public void ModelSave(string path)
    {
      Context.Model.Save(Transformer, Model.OutputSchema, path);
    }

    public void ModelLoad(string path)
    {
      Transformer = Context.Model.Load(path, out var schema) as TransformerChain<LatentDirichletAllocationTransformer>;
      Schema = schema;

      _documentPredictions = null;
    }

    private object _predictLock = new object();

    public float[] Predict(string text)
    {
      try
      {
        lock(_predictLock)
          return Model.Predict(new TextData { Text = text }).Features;
      }
      catch
      {
        return null;
      }
    }

    private StopWordsRemovingEstimator.Language GetLanguage()
    {
      switch (Configuration.Language)
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
      switch (Configuration.CaseMode)
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
