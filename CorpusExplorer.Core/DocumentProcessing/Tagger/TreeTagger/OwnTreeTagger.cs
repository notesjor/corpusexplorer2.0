using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Bcs.IO;
using CorpusExplorer.Core.DocumentProcessing.Tagger.TreeTagger.Abstract;
using CorpusExplorer.Core.DocumentProcessing.Tokenizer;
using CorpusExplorer.Sdk.Diagnostic;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger;

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

    public override IEnumerable<string> LanguagesAvailabel => new[] {"Durch Skript definiert."};

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
        var config = FileIO.ReadLines(InstallationPath)[1];
        var split = config.Split(new[] {"|"}, StringSplitOptions.None);
        if (split[0].Trim() != "REM CorpusExplorer" || split.Length != 3)
          throw new Exception();

        _sentenceMark = new HashSet<string> {split[1].Trim()};
        if (string.IsNullOrEmpty(split[2]))
          return;

        var phrases = split[2].Trim().Split(new[] {",", " ", "<", ">", "/"}, StringSplitOptions.RemoveEmptyEntries);
        var phrase = AddRangeLayer("Phrase");
        foreach (var p in phrases)
        {
          var tag = p.Trim();
          phrase.AddRange(x => x == $"<{tag}>", x => p, x => x == $"</{tag}>");
        }
      }
      catch
      {
        // ignore
      }
    }
  }
}