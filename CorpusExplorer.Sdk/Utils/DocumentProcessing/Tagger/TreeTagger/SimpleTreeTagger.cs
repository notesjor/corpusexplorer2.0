using System;
using System.Diagnostics;
using System.IO;
using Bcs.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.TreeTagger.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.TreeTagger.LocatorStrategy;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.TreeTagger.LocatorStrategy.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tokenizer;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tokenizer.Abstract;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.TreeTagger
{
  public sealed class SimpleTreeTagger : AbstractTreeTagger
  {
    public SimpleTreeTagger()
    {
      Tokenizer = new HighSpeedSpaceTokenizer();

      AddValueLayer("Wort", 0);
      AddValueLayer("POS", 1);
      AddValueLayer("Lemma", 2);
    }

    public override string DisplayName => "TreeTagger (ohne Phrasen / höhere Performance)";

    protected override AbstractLocatorStrategy LocatorStrategy => new LocatorStrategyParFile();

    public override string LanguageSelected
    {
      get => base.LanguageSelected;
      set
      {
        base.LanguageSelected = value;
        Tokenizer = value == "Deutsch"
                      ? (AbstractTokenizer) new HighSpeedGermanTokenizer()
                      : new HighSpeedSpaceTokenizer();
      }
    }

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
              FileName = Path.Combine(LocatorStrategy.TreeTaggerRootDirectory, @"bin/tree-tagger.exe").Replace("\\", "/"),
              Arguments =
                $"-quiet -token -lemma -sgml -no-unknown \"{LocatorStrategy.ApplyLanguage(LanguageSelected)}\" \"{fileInput.Path}\" \"{fileOutput.Path}\"",
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
  }
}