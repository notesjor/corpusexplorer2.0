using System.Collections.Generic;
using System.IO;
using System.Linq;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.TreeTagger.LocatorStrategy.Abstract;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.TreeTagger.LocatorStrategy
{
  public class LocatorStrategyParFile : AbstractLocatorStrategy
  {
    private Dictionary<string, string> _languages
      = new Dictionary<string, string>
      {
        {"Deutsch", "german-utf8.par"},
        {"Englisch", "english-utf8.par"},
        {"Französisch", "french.par"},
        {"Italienisch", "italian-utf8.par"},
        {"Niederländisch", "dutch-utf8.par"},
        {"Spanisch", "spanish-utf8.par"},
        {"Polnisch", "polish-utf8.par"},
        // {"Deutsch (Mittelhochdeutsch)", "middle-high-german.par"} -> DTA::CAB
        {"Deutsch (gesprochene Sprache)", "german-spoken.par" }
      };

    public override IEnumerable<string> AvailableLanguages
      => _languages.Where(x => File.Exists(Path.Combine(TreeTaggerRootDirectory, "lib", x.Value))).Select(x => x.Key);

    public override string ApplyLanguage(string language, string temporaryFile) 
      => Path.Combine(TreeTaggerRootDirectory, "lib", _languages[language]);

    public override bool ValidateLanguageSelection(string language)
      => _languages.ContainsKey(language);
  }
}