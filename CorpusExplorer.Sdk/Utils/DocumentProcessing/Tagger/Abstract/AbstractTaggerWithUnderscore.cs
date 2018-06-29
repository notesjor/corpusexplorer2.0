namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.Abstract
{
  public abstract class AbstractTaggerWithUnderscore : AbstractTaggerOneWordPerLine
  {
    protected override string TextPostTaggerCleanup(string text)
    {
      return text.Replace(" ", "\r\n").Replace("_", "\t");
    }

    protected override string TextPostTokenizerPreTaggerCleanup(string text)
    {
      return text.Replace("_", "-");
    }
  }
}