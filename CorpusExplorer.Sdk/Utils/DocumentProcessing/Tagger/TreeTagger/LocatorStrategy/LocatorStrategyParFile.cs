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
        {"Deutsch (gesprochene Sprache)", "german-spoken.par" },

        {"Albanisch", "albanian.par"},
        {"Belarussisch", "belarusian.par"},
        {"Bulgarisch", "bulgarian.par"},
        {"Katalanisch", "catalan.par"},
        {"Tschechisch", "czech.par"},
        {"Dänisch", "danish.par"},
        {"Niederländisch (ISO)", "dutch.par"},
        {"Niederländisch (ISO 2)", "dutch2.par"},
        {"Englisch (ISO)", "english.par"},
        {"Englisch (BNC)", "english-bnc.par"},
        {"Estnisch", "estonian.par"},
        {"Finnisch", "finnish.par"},
        {"Französisch (ISO)", "french.par"},
        {"Französisch (gesprochene Sprache)", "french-spoken.par"},
        {"Französisch (alt)", "old-french.par"},
        {"Galicische", "galician.par"},
        {"Deutsch (ISO)", "german.par"},
        {"Deutsch (Mittelhochdeutsch)", "middle-high-german.par"},
        {"Griechisch", "greek.par"},
        {"Griechisch (alt/antik)", "ancient-greek.par"},
        {"Griechisch (alt/antik - beta)", "ancient-greek-beta.par"},
        {"Ungarisch", "hungarian.par"},
        {"Indonesisch", "indonesian.par"},
        {"Italienisch (ISO)", "italian.par"},
        {"Italienisch (ISO 2)", "italian2.par"},
        {"Koreanisch", "korean.par"},
        {"Latein", "latin.par"},
        {"Latein (IT)", "latinIT.par"},
        {"Monoglisch", "mongolian.par"},
        {"Norwegisch", "norwegian.par"},
        {"Persisch", "persian.par"},
        {"Persisch (grob)", "persian-coarse.par"},
        {"Polnisch (ISO)", "polish.par"},
        {"Portugiesisch", "portuguese.par"},
        {"Portugiesisch (fein)", "portuguese-finegrained.par"},
        {"Portugiesisch (2)", "portuguese2.par"},
        {"Rumänisch", "romanian.par"},
        {"Russisch", "russian.par"},
        {"Slovakisch", "slovak.par"},
        {"Slovakisch (2)", "slovak2.par"},
        {"Slovenisch", "slovenian.par"},
        {"Spanisch (ISO)", "spanish.par"},
        {"Spanisch (ancora)", "spanish-ancora.par"},
        {"Swahili", "swahili.par"},
        {"Schwedisch", "swedish.par"},
        {"Ukrainisch", "ukrainian.par"}
      };

    public override IEnumerable<string> AvailableLanguages
      => _languages.Where(x => File.Exists(Path.Combine(TreeTaggerRootDirectory, "lib", x.Value))).Select(x => x.Key);

    public override string ApplyLanguage(string language, string temporaryFile) 
      => Path.Combine(TreeTaggerRootDirectory, "lib", _languages[language]);

    public override bool ValidateLanguageSelection(string language)
      => _languages.ContainsKey(language);
  }
}