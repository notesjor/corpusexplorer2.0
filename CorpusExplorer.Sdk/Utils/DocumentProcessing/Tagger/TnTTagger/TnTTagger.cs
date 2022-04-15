using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Bcs.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tokenizer;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.TnTTagger
{
  public sealed class TnTTagger : AbstractTaggerOneWordPerLine
  {
    private readonly HashSet<string> _languageses = new HashSet<string>
    {
      "Deutsch",
      "Englisch"
    };

    private string _languageSelected;

    public TnTTagger()
    {
      Tokenizer = new HighSpeedGermanTokenizer();

      AddValueLayer("Wort", 0);
      AddValueLayer("POS", 1);
    }

    public override string DisplayName => "TnT-Tagger";

    public override string InstallationPath
    {
      get => "(NICHT WÄHLBAR - OPTIMIERTE VERSION)";
      set { }
    }

    public override IEnumerable<string> LanguagesAvailabel => _languageses;

    public override string LanguageSelected
    {
      get => _languageSelected;
      set
      {
        if (!_languageses.Contains(value))
          throw new NotSupportedException("LanguageSelected-value is not in List of LanguagesAvailabel");
        _languageSelected = value;
      }
    }

    protected override string Foundry => "TnT-Tagger";
    protected override string FoundryLayerInfo => "pos";

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
              FileName = Path.Combine(TnTLocator.RootDirectory, @"tnt.exe"),
              Arguments = $"-H  -u2 -Z0 \"{TnTLocator.GetModelFile(LanguageSelected)}\" \"{fileInput.Path}\"",
              RedirectStandardError = true,
              RedirectStandardOutput = true,
              StandardOutputEncoding = Configuration.Encoding,
              StandardErrorEncoding = Configuration.Encoding,
              CreateNoWindow = true,
              UseShellExecute = false,
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

    protected override bool IsEndOfSentence(string[] data)
    {
      return data.Length > 1 && data[1] == "$.";
    }

    protected override string TextPostTaggerCleanup(string text)
    {
      var lines =
        new Queue<string>(
                          text.Replace("\r>", ">")
                              .Split(new[] {"\r\n", "\n\r", "\r", "\n"}, StringSplitOptions.RemoveEmptyEntries));
      var clean = new List<string>();
      var level = 0;

      while (lines.Count > 0)
      {
        var line = lines.Dequeue();
        if (level == 0)
        {
          if (line.StartsWith("%%"))
            continue;
          level++;
        }

        if (line.StartsWith(TaggerFileSeparator) && line.Contains("%%"))
        {
          clean.Add(TaggerFileSeparator);
          break;
        }

        clean.Add(line);
      }

      var endSeperator = TaggerFileSeparator.Replace("\r\n", "");

      var i = clean.Count - 1;
      for (; i > -1; i--)
      {
        if (!clean[i].StartsWith(endSeperator))
          continue;
        for (var j = clean.Count - 1; j >= i; j--)
          clean.RemoveAt(j);
        clean.Add(TaggerFileSeparator);
        break;
      }

      return string.Join("\r\n", clean);
    }
  }
}