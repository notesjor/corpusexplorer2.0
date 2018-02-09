using CorpusExplorer.Sdk.Extern.SentimentDetection.Model;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.Abstract;

namespace CorpusExplorer.Sdk.Extern.SentimentDetection.Tagger.Abstract
{
  public abstract class AbstractSentimentTagger : AbstractAdditionalTagger
  {
    protected SentimentDetectionTagModel Model => SentimentDetectionTagModel.Load(ModelPath);
  }
}