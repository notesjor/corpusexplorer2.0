#region

using System.Collections.Generic;
using System.Diagnostics;
using Bcs.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tokenizer;

#endregion

namespace CorpusExplorer.Sdk.Extern.RFTagger.Tagger
{
  public class RFTagger : AbstractTaggerOneWordPerLine
  {
    private string _languageSelected;
    private string _modelPath;

    public RFTagger()
    {
      Tokenizer = new HighSpeedGermanTokenizer();

      AddValueLayer("Wort", 0);
      AddValueLayer("POS", 1);
    }

    private Dictionary<string, string> _languagesAvailable => new Dictionary<string, string>
    {
      { "Deutsch", "german" },
      { "Tschechisch", "czech" },
      { "Slowenisch", "slovene" },
      { "Slowakisch", "slovak" },
      { "Ungarisch", "hungarian" },
    };

    public override string DisplayName => "RFTagger";

    public override string InstallationPath { get; set; }

    public override IEnumerable<string> LanguagesAvailabel => _languagesAvailable.Keys;

    public override string LanguageSelected
    {
      get => _languageSelected;
      set
      {
        if (value == _languageSelected)
          return;

        _languageSelected = value;
        _modelPath = Configuration.GetDependencyPath($"RFTagger/lib/{_languagesAvailable[_languageSelected]}.par");
      }
    }

    protected override string Foundry => "RFTagger";
    protected override string FoundryLayerInfo => "pos";

    protected override string ExecuteTagger(string text)
    {
      using (var fileOutput = new TemporaryFile(Configuration.TempPath))
      using (var fileInput = new TemporaryFile(Configuration.TempPath))
      {
        FileIO.Write(fileInput.Path, Tokenizer.ExecuteToArray(text));

        try
        {
          var process = new Process
          {
            StartInfo =
            {
              FileName = Configuration.GetDependencyPath("RFTagger/bin/rft-annotate"),
              Arguments = $"{_modelPath} {fileInput.Path} {fileOutput.Path}",
              CreateNoWindow = true,
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

    protected override bool IsEndOfSentence(string[] data) =>
      data != null && data.Length == 2 && data[1] == "SYM.Pun.Sent";
  }
}