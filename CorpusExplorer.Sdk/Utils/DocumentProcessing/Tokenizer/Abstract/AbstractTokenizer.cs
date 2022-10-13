using System;
using CorpusExplorer.Sdk.Helper;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Tokenizer.Abstract
{
  public abstract class AbstractTokenizer
  {
    public abstract string DisplayName { get; }
    public abstract string Language { get; set; }
    public abstract string Execute(string input);

    public string[] ExecuteToArray(string input)
    {
      return Execute(input).Split(Splitter.LineBreaks, StringSplitOptions.RemoveEmptyEntries);
    }
  }
}