using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Extern.SentimentDetection.Tagger.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract.Model;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract.Model.Abstract;

namespace CorpusExplorer.Sdk.Extern.SentimentDetection.Tagger
{
  public class SentimentLevelTagger : AbstractSentimentTagger
  {
    public override string DisplayName => "Sentiment-Triple-Tagger";

    protected override IEnumerable<AbstractLayerState> ExecuteCall(ref AbstractCorpusAdapter corpus)
    {
      var layer = corpus.GetLayers("Wort").Single();
      var res = new List<AbstractLayerState>();

      foreach (var dim in Model.Data)
      {
        var nlayer = new LayerValueState("Sentiment", corpus.Layers.Count());

        foreach (var dsel in layer.DocumentGuids)
        {
          var rdoc = layer.GetReadableDocumentByGuid(dsel);
          var ndoc =
            rdoc.Select(
                  s =>
                    s.Select(
                      w => dim.Value.ContainsKey(w)
                             ? (dim.Value[w] < LowLevelValue
                                  ? LowLevelLabel
                                  : dim.Value[w] > HighLevelValue
                                    ? HighLevelLabel
                                    : string.Empty)
                             : string.Empty).ToArray())
                .ToArray();
          nlayer.AddCompleteDocument(dsel, ndoc);
        }

        res.Add(nlayer);
      }

      return res;
    }

    protected override void Cleanup() { }
    protected override void Initialize() { }
    public double LowLevelValue { get; set; } = -0.6;
    public double HighLevelValue { get; set; } = 0.6;
    public string LowLevelLabel { get; set; } = "Negativ";
    public string HighLevelLabel { get; set; } = "Positiv";
  }
}