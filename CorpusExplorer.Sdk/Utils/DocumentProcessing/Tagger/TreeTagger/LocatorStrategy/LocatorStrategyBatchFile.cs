using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bcs.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.TreeTagger.LocatorStrategy.Abstract;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.TreeTagger.LocatorStrategy
{
  public class LocatorStrategyBatchFile : AbstractLocatorStrategy
  {
    private Dictionary<string, string> _languages
      = new Dictionary<string, string>
      {
        {"Deutsch", "chunk-german.bat"},
        {"Englisch", "chunk-english.bat"},
        {"Französisch", "chunk-french.bat"},
        {"Italienisch", "tag-italian.bat"},
        {"Niederländisch", "tag-dutch.bat"},
        {"Spanisch", "tag-spanish.bat"},
        {"Polnisch", "tag-polish.bat"},
        // {"Deutsch (Mittelhochdeutsch)", "tag-middle-high-german.bat"} -> DTA::CAB
      };

    public override IEnumerable<string> AvailableLanguages
      => _languages.Where(x => File.Exists(Path.Combine(TreeTaggerRootDirectory, "bin", x.Value))).Select(x => x.Key);

    public override string ApplyLanguage(string language, string temporaryFile)
    {
      var path = Path.Combine(TreeTaggerRootDirectory, @"bin");
      var perl = $"\"{Configuration.GetDependencyPath(@"Perl\perl\bin\perl.exe").ShortPath()}\"";
      var input = FileIO.ReadLines(Path.Combine(path, _languages[language]));
      var lines = new List<string>();

      foreach (var line in input)
        if (line == @"set TAGDIR=C:\TreeTagger")
          lines.Add("set TAGDIR=" + TreeTaggerRootDirectory.ShortPath());
        else if (line.StartsWith("perl"))
          lines.Add(perl + line.Substring(4).Replace(" perl ", $" {perl} "));
        else
          lines.Add(line);

      FileIO.Write(temporaryFile, lines.ToArray());
      return temporaryFile;
    }

    public override bool ValidateLanguageSelection(string language)
      => _languages.ContainsKey(language);
  }
}
