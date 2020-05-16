#region

using System;
using System.Collections.Generic;
using System.Diagnostics;
using Bcs.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Extern.OpenNLP.DocumentProcessing.Tagger.Parameter;
using CorpusExplorer.Sdk.Extern.OpenNLP.DocumentProcessing.Tokenizer;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Extern.OpenNLP.DocumentProcessing.Tagger
{
  // ReSharper disable once MemberCanBeInternal
  public sealed class OpenNlpMaxentTagger : AbstractTaggerWithUnderscore
  {
    private readonly List<string> _languages = new List<string>
    {
      "Deutsch",
      "Englisch",
      "Niederländisch",
      "Portugiesisch",
      "Sami"
    };

    private string _languageSelected;

    // ReSharper disable once MemberCanBeInternal
    public OpenNlpMaxentTagger()
    {
      Tokenizer = new OpenNlpTokenizer();

      AddValueLayer("Wort", 0);
      AddValueLayer("POS", 1);
    }

    public override string DisplayName => "OpenNLP-Maxent-Tagger";

    public override string InstallationPath
    {
      get => "(NICHT WÄHLBAR - OPTIMIERTE VERSION)";
      set { }
    }

    public override IEnumerable<string> LanguagesAvailabel => _languages;

    public override string LanguageSelected
    {
      get => _languageSelected;
      set
      {
        if (!_languages.Contains(value))
          throw new NotSupportedException("LanguageSelected-value is not in List of LanguagesAvailabel");
        _languageSelected = value;
      }
    }

    protected override string ExecuteTagger(string text)
    {
      using (var fileOutput = new TemporaryFile(Configuration.TempPath))
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
                FileName = OpenNlpLocator.BatchFile,
                Arguments =
                  $"POSTagger {OpenNlpLocator.GetMaxentModel(LanguageSelected)} < {fileInput.Path} > {fileOutput.Path}",
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
    }

    protected override
      bool IsEndOfSentence(string[] data)
    {
      return data.Length > 1 && data[1] == "$.";
    }

    protected override string TextPostTaggerCleanup(string text)
    {
      return base.TextPostTaggerCleanup(text.Replace("<ENDOFCORPUSEXPLORERFILE>_NE", "<ENDOFCORPUSEXPLORERFILE>"));
    }
  }
}