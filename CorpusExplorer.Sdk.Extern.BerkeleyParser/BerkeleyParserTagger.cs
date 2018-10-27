using System.Collections.Generic;
using System.Diagnostics;
using Bcs.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.ConllTagger.Abstract;

namespace CorpusExplorer.Sdk.Extern.BerkeleyParser
{
  public class BerkeleyParserTagger : AbstractConllStyleTagger
  {
    private bool _chinese;

    private readonly Dictionary<string, string> _languagesAvailable = new Dictionary<string, string>
    {
      {"Bulgarisch", "bul_sm5.gr"},
      {"Chinesisch", "chn_sm5.gr"},
      {"Deutsch", "ger_sm5.gr"},
      {"Englisch", "eng_sm6.gr"},
      {"Französisch", "fra_sm5.gr"}
    };

    private string _languageSelected;
    private string _model;

    public BerkeleyParserTagger()
    {
      AddValueLayer("Wort", 1);
      AddValueLayer("Lemma", 2);
      AddValueLayer("POS", 4);
    }

    public override string DisplayName => "BerkeleyParser";

    public override string InstallationPath { get; set; } = null;

    public override IEnumerable<string> LanguagesAvailabel => _languagesAvailable.Keys;

    public override string LanguageSelected
    {
      get => _languageSelected;
      set
      {
        if (value == _languageSelected)
          return;

        _languageSelected = value;
        _chinese = _languageSelected == "Chinesisch";
        _model = Configuration.GetDependencyPath($"BerkeleyParser/{_languagesAvailable[_languageSelected]}");
      }
    }

    protected override string ExecuteTagger(string text)
    {
      using (var fileInput = new TemporaryFile(Configuration.TempPath))
      {
        FileIO.Write(fileInput.Path, text);

        try
        {
          var process = new Process
          {
            StartInfo =
            {
              FileName = Configuration.GetDependencyPath(@"Java\bin\java.exe"),
              Arguments =
                $"-jar \"{Configuration.GetDependencyPath($"BerkeleyParser/BerkeleyParser-1.7.jar")}\" -gr \"{_model}\" -tokenize {(_chinese ? "-chinese" : "")} -inputFile \"{fileInput.Path}\"",
              CreateNoWindow = true,
              UseShellExecute = false,
              StandardOutputEncoding = Configuration.Encoding,
              RedirectStandardOutput = true,
              WindowStyle = ProcessWindowStyle.Hidden
            }
          };
          process.Start();

          var res = process.StandardOutput.ReadToEnd();
          process.WaitForExit();

          return res;
        }
        catch
        {
          return string.Empty;
        }
      }
    }
  }
}