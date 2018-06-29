using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Extern.SentimentDetection.Tagger.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract.Model;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract.Model.Abstract;

namespace CorpusExplorer.Sdk.Extern.SentimentDetection.Tagger
{
  public class SentimentValueTagger : AbstractSentimentTagger
  {
    public override string DisplayName => "Sentiment-Werte-Tagger";

    protected override void Cleanup()
    {
    }

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
                      ? dim.Value[w].ToString()
                      : string.Empty).ToArray())
              .ToArray();
          nlayer.AddCompleteDocument(dsel, ndoc);
        }

        res.Add(nlayer);
      }

      return res;
    }

    protected override void Initialize()
    {
    }
  }
}