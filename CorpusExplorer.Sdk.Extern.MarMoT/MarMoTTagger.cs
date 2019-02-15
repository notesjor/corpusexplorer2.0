using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Bcs.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.ConllTagger.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tokenizer.Abstract;

namespace CorpusExplorer.Sdk.Extern.MarMoT
{
  public class MarMoTTagger : AbstractConllStyleTagger
  {
    private readonly string[] _endings =
    {
      ".",
      "!",
      "?",
      "؟"
    };

    private readonly Dictionary<string, string> _languagesAvailable = new Dictionary<string, string>
    {
      {"Deutsch", "SPMRL\\de.marmot"},
      {"Arabisch", "SPMRL\\ar.marmot"},
      {"Baskisch", "SPMRL\\eu.marmot"},
      {"Bulgarisch", "MultExt\\bg.marmot"},
      {"Englisch", "MultExt\\en.marmot"},
      {"Estnisch", "MultExt\\et.marmot"},
      {"Französisch", "SPMRL\\fr.marmot"},
      {"Hebräisch", "SPMRL\\he.marmot"},
      {"Koreanisch", "SPMRL\\ko.marmot"},
      {"Persisch", "MultExt\\fa.marmot"},
      {"Polnisch (MultExt)", "MultExt\\pl.marmot"},
      {"Polnisch (SPMRL)", "SPMRL\\pl.marmot"},
      {"Rumänisch", "MultExt\\ro.marmot"},
      {"Schwedisch", "SPMRL\\sv.marmot"},
      {"Serbisch", "MultExt\\sr.marmot"},
      {"Slowakisch", "MultExt\\sk.marmot"},
      {"Slowenisch", "MultExt\\sl.marmot"},
      {"Tschechisch", "MultExt\\cs.marmot"},
      {"Ungarisch (MultExt)", "MultExt\\hu.marmot"},
      {"Ungarisch (SPMRL)", "SPMRL\\hu.marmot"}
    };

    private string _languageSelected;
    private string _model;

    public MarMoTTagger()
    {
      AddValueLayer("Wort", 1);
      // AddValueLayer("Lemma", 2);
      AddValueLayer("POS", 5);
    }

    public override string DisplayName => "MarMoT";

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
        _model = Configuration.GetDependencyPath($"MarMoT\\model\\{_languagesAvailable[_languageSelected]}");
      }
    }

    public AbstractTokenizer Tokenizer { get; set; } = new HighSpeedSpaceTokenizer();

    protected override string ExecuteTagger(string text)
    {
      using (var fileOutput = new TemporaryFile(Configuration.TempPath))
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
                $"-Xms512M -cp \"{Configuration.GetDependencyPath(@"MarMoT\marmot.jar")}\" marmot.morph.cmd.Annotator --model-file \"{_model}\" --test-file form-index=0,\"{fileInput.Path}\" --pred-file \"{fileOutput.Path}\"",
              CreateNoWindow = true,
              UseShellExecute = false,
              WorkingDirectory = Configuration.TempPath,
              WindowStyle = ProcessWindowStyle.Hidden
            }
          };

          process.Start();
          process.WaitForExit();

          return FileIO.ReadText(fileOutput.Path, Configuration.Encoding);
        }
        catch
        {
          return string.Empty;
        }
      }
    }

    protected override string TextPostTaggerCleanup(string text)
    {
      return base.TextPostTaggerCleanup(text.Replace("\n", "\r\n"));
    }

    protected override string TextPreTaggerCleanup(string text)
    {
      return DetectSentence(Tokenizer.Execute(text));
    }

    private string DetectSentence(string text)
    {
      return _endings.Aggregate(text,
                                (current, ending) => current.Replace($"\r\n{ending}\r\n", $"\r\n{ending}\r\n\r\n"));
    }
  }
}