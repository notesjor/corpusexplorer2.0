using System;
using System.Diagnostics;
using System.IO;
using Bcs.IO;
using CorpusExplorer.Sdk.Diagnostic;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.TreeTagger.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.TreeTagger.LocatorStrategy;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.TreeTagger.LocatorStrategy.Abstract;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.TreeTagger
{
  public class ClassicTreeTagger : AbstractTreeTagger
  {
    public ClassicTreeTagger()
    {
      AddValueLayer("Wort", 0);
      AddValueLayer("POS", 1);
      AddValueLayer("Lemma", 2);

      var phrase = AddRangeLayer("Phrase");
      phrase.AddRange(x => x == "<NC>", x => "NC", x => x == "</NC>");
      phrase.AddRange(x => x == "<VC>", x => "VC", x => x == "</VC>");
      phrase.AddRange(x => x == "<PC>", x => "PC", x => x == "</PC>");

      Tokenizer = new NoTokenizer(); // Wird durch das Batch-Skript erledigt
    }

    public override string DisplayName => "TreeTagger";

    protected override string ExecuteTagger(string text)
    {
      try
      {
        using (var fileOutput = new TemporaryFile(Configuration.TempPath))
        using (var fileBatch = new TemporaryFile(Configuration.TempPath, ".bat"))
        using (var fileInput = new TemporaryFile(Configuration.TempPath))
        {
          FileIO.Write(fileInput.Path, text);
          LocatorStrategy.ApplyLanguage(LanguageSelected, fileBatch.Path);

          var process = new Process
          {
            StartInfo =
            {
              FileName = fileBatch.Path,
              Arguments = $"\"{Path.GetFileName(fileInput.Path)}\" \"{Path.GetFileName(fileOutput.Path)}\"",
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
      }
      catch (Exception ex)
      {
        InMemoryErrorConsole.Log(ex);
        return string.Empty;
      }
    }

    protected override AbstractLocatorStrategy LocatorStrategy => new LocatorStrategyBatchFile();
  }
}