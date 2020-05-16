using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tokenizer.Abstract;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Tokenizer
{
  public sealed class NoTokenizer : AbstractTokenizer
  {
    public override string DisplayName => "Keine Tokenizer";

    public override string Language
    {
      get => "Universal";
      set { }
    }

    public override string Execute(string input)
    {
      return input;
    }
  }
}