using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Bcs.IO;
using CorpusExplorer.Core.DocumentProcessing.Tagger.TreeTagger.Abstract;
using CorpusExplorer.Core.DocumentProcessing.Tagger.TreeTagger.Parameter;
using CorpusExplorer.Core.DocumentProcessing.Tokenizer;
using CorpusExplorer.Sdk.Diagnostic;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;

namespace CorpusExplorer.Core.DocumentProcessing.Tagger.TreeTagger
{
  public class OwnTreeTagger : AbstractTreeTagger
  {
    public OwnTreeTagger()
    {
      AddValueLayer("Wort", 0);
      AddValueLayer("POS", 1);
      AddValueLayer("Lemma", 2);

      Tokenizer = new NoTokenizer(); // Wird durch das Batch-Skript erledigt

      _sentenceMark = null;
    }

    public override string DisplayName => "TreeTagger (eigenes Skript)";

    public override string InstallationPath
    {
      get => Configuration.GetSetting("TreeTagger", "") as string;
      set => Configuration.SetSetting("TreeTagger", value);
    }

    protected override string ExecuteTagger(string text)
    {
      if (_sentenceMark == null)
        ReadScriptConfiguration();

      try
      {
        using (var fileOutput = new TemporaryFile(Path.GetDirectoryName(InstallationPath)))
        using (var fileInput = new TemporaryFile(Path.GetDirectoryName(InstallationPath)))
        {
          FileIO.Write(fileInput.Path, text);

          var process = new Process
          {
            StartInfo =
            {
              FileName = InstallationPath,
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

    private void ReadScriptConfiguration()
    {
      try
      {
        var config = FileIO.ReadLines(InstallationPath).FirstOrDefault();
        var split = config.Split(new[] { "|" }, StringSplitOptions.None);
        if (split[0].Trim() != "REM CorpusExplorer" || split.Length != 3)
          throw new Exception();

        _sentenceMark = split[1];
        if (string.IsNullOrEmpty(split[2]))
          return;

        var phrases = split[2].Split(new[] { ",", " ", "<", ">", "/" }, StringSplitOptions.RemoveEmptyEntries);
        var phrase = AddRangeLayer("Phrase");
        foreach (var p in phrases)
          phrase.AddRange(x => x == $"<{p}>", x => p, x => x == $"</{p}>");
      }
      catch
      {
        _sentenceMark = "$.";
      }
    }
  }
}