using System.Collections.Generic;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.TreeTagger.LocatorStrategy.Abstract;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.TreeTagger.LocatorStrategy
{
  public class LocatorStrategyNull : AbstractLocatorStrategy
  {
    public override IEnumerable<string> AvailableLanguages => new string[0];

    public override string ApplyLanguage(string language, string temporaryFile) => "";

    public override bool ValidateLanguageSelection(string language) => true;
  }
}