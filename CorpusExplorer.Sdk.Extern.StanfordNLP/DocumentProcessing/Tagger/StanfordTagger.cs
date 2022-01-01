#region

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Bcs.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Extern.StanfordNLP.DocumentProcessing.Tagger
{
  // ReSharper disable once MemberCanBeInternal
  public sealed class StanfordTagger : AbstractTaggerWithUnderscore
  {
    private readonly Dictionary<string, string> _languages = new Dictionary<string, string>
    {
      { "Arabisch", "arabic.tagger" },
      { "Chinesisch (distsim)", "chinese-distsim.tagger" },
      { "Chinesisch (nodistsim)", "chinese-nodistsim.tagger" },
      { "Englisch (english-bidirectional-distsim)", "english-bidirectional-distsim.tagger" },
      { "Englisch (english-caseless-left3words-distsim)", "english-caseless-left3words-distsim.tagger" },
      { "Englisch (english-left3words-distsim)", "english-left3words-distsim.tagger" },
      { "Englisch (wsj-0-18-bidirectional-distsim)", "wsj-0-18-bidirectional-distsim.tagger" },
      { "Englisch (wsj-0-18-bidirectional-nodistsim)", "wsj-0-18-bidirectional-nodistsim.tagger" },
      { "Englisch (wsj-0-18-caseless-left3words-distsim)", "wsj-0-18-caseless-left3words-distsim.tagger" },
      { "Englisch (wsj-0-18-left3words-distsim)", "wsj-0-18-left3words-distsim.tagger" },
      { "Englisch (wsj-0-18-left3words-nodistsim)", "wsj-0-18-left3words-nodistsim.tagger" },
      { "Französisch", "french.tagger" },
      { "Deutsch (german-dewac)", "german-dewac.tagger" },
      { "Deutsch (german-fast)", "german-fast.tagger" },
      { "Deutsch (german-fast-caseless)", "german-fast-caseless.tagger" },
      { "Deutsch (german-hgc)", "german-hgc.tagger" }
    };

    private string _languageSelected;

    // ReSharper disable once MemberCanBeInternal
    public StanfordTagger()
    {
      AddValueLayer("Wort", 0);
      AddValueLayer("POS", 1);
    }

    public override string DisplayName => "Stanford Maxent POS-Tagger";

    public override string InstallationPath
    {
      get => "(NICHT WÄHLBAR - OPTIMIERTE VERSION)";
      set { }
    }

    private string JavaLocation
    {
      get
      {
        var bin = LocateJava(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles));
        return !string.IsNullOrEmpty(bin)
                 ? bin
                 : LocateJava(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86));
      }
    }

    public override IEnumerable<string> LanguagesAvailabel
    {
      get { return _languages.Select(x => x.Key); }
    }

    public override string LanguageSelected
    {
      get => _languageSelected;
      set
      {
        if (!_languages.ContainsKey(value))
          throw new NotSupportedException("LanguageSelected-value is not in List of LanguagesAvailabel");
        _languageSelected = value;
      }
    }

    protected override string ExecuteTagger(string text)
    {
      using (var fileInput = new TemporaryFile(Configuration.TempPath))
      {
        FileIO.Write(fileInput.Path, text);

        var bpath = Configuration.GetDependencyPath("stanfordPOS");
        var jar = Path.Combine(bpath, "stanford-postagger-3.5.2.jar");
        var model = Path.Combine(Path.Combine(bpath, "models"), _languages[_languageSelected]);

        try
        {
          var process = new Process
          {
            StartInfo =
            {
              FileName = "\"" + JavaLocation + "\"",
              Arguments =
                string.Format(
                              "-mx300m -classpath \"{2}\" edu.stanford.nlp.tagger.maxent.MaxentTagger -model \"{0}\" -encoding UTF-8 -textFile \"{1}\"",
                              model,
                              fileInput.Path,
                              jar),
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

    protected override bool IsEndOfSentence(string[] data) => data.Length > 1 && data[1] == "$.";

    private static string LocateJava(string getFolderPath)
    {
      var paths = Directory.GetDirectories(getFolderPath, "Java");
      return paths.Length == 0
               ? null
               : paths.Select(path => Directory.GetDirectories(path, "jre*"))
                      .Select(versions => versions.Length == 0 ? null : Path.Combine(versions[0], @"bin\java.exe"))
                      .FirstOrDefault();
    }

    protected override string TextPostTaggerCleanup(string text)
    {
      if (string.IsNullOrEmpty(text))
        return text;

      var splits =
        text.Replace("._$.", "._$. ")
            .Replace("\t", " ")
            .Replace("  ", " ")
            .Replace("  ", " ")
            .Replace("  ", " ")
            .Split(new[] { "<ENDOFCORPUSEXPLORERFILE>" }, StringSplitOptions.RemoveEmptyEntries);

      if (splits.Length == 0)
        return text;

      var res = new List<string> { splits[0] };

      for (var i = 1; i < splits.Length; i++)
      {
        var idx = splits[i].IndexOf(" ", StringComparison.Ordinal);
        res.Add(splits[i].Substring(idx + 1));
      }

      return base.TextPostTaggerCleanup(string.Join(TaggerFileSeparator, res) + TaggerFileSeparator);
    }
  }
}