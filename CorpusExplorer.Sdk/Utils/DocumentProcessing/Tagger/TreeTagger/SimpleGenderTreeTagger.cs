using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tokenizer;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.TreeTagger
{
  public sealed class SimpleGenderTreeTagger : SimpleTreeTagger
  {
    public SimpleGenderTreeTagger()
    {
      Tokenizer = new HighSpeedGermanGenderTokenizer();
    }

    public override string DisplayName => "TreeTagger (ohne Phrasen / Genderzeichen)";
  }
}