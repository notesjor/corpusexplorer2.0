using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using Bcs.IO;
using CorpusExplorer.Core.DocumentProcessing.Tagger.TreeTagger.Abstract;
using CorpusExplorer.Core.DocumentProcessing.Tagger.TreeTagger.Parameter;
using CorpusExplorer.Core.DocumentProcessing.Tokenizer;
using CorpusExplorer.Sdk.Diagnostic;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract.Model.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tokenizer.Abstract;

namespace CorpusExplorer.Sdk.Extern.Heideltime
{
  /*
  public class HeideltimeTreeTagger : AbstractTaggerOneWordPerLine
  {
    private Dictionary<string, string> _hdLanguages = new Dictionary<string, string>
    {
      {"Deutsch", "german"},
      {"Englisch", "english"},
      {"Französisch", "french"},
      {"Italienisch", "italian"},
      {"Niederländisch", "dutch"},
      {"Spanisch", "spanish"},
    };

    private string _languageSelected;

    public HeideltimeTreeTagger()
    {
      var phrase = AddRangeLayer("Zeit");
      phrase.AddRange(x => x == "<TIMEX3", 
        x =>
        {
          const string marker = "value=\"";
          var s = x.IndexOf(marker, StringComparison.CurrentCulture) + marker.Length;
          var e = x.IndexOf("\"", s + 1, StringComparison.CurrentCulture);
          return x.Substring(s, e - s);
        }, 
        x => x == "</TIMEX3>");

      Tokenizer = new HighSpeedSpaceTokenizer();
    }

    public override string DisplayName => "HeidelTime";

    public override string InstallationPath { get; set; }

    public override IEnumerable<string> LanguagesAvailabel => _hdLanguages.Keys;

    public override string LanguageSelected
    {
      get => _languageSelected;
      set
      {
        _languageSelected = value;
        Tokenizer = value == "Deutsch" ? (AbstractTokenizer) new HighSpeedGermanTokenizer() : new HighSpeedSpaceTokenizer();
      }
    }

    protected override string TextPreMergerCleanup(string text, ref Dictionary<string, object> doc)
    {
      using (var fileInput = new TemporaryFile(Configuration.TempPath))
      {
        FileIO.Write(fileInput.Path, text);

        var dct = doc.ContainsKey("Datum") &&
                  doc["Datum"] is DateTime &&
                  (DateTime) doc["Datum"] > DateTime.MinValue
          ? $"-t news -dct {(DateTime) doc["Datum"]:yyyy-MM-dd}"
          : "-t narratives";
        
        try
        {
          var process = new Process
          {
            StartInfo =
            {
              FileName = Configuration.GetDependencyPath(@"Java\bin\java.exe"),
              Arguments = $"-jar de.unihd.dbs.heideltime.standalone.jar -e utf8 -l {_hdLanguages[LanguageSelected]} {dct} -pos no {fileInput}",
              CreateNoWindow = true,
              UseShellExecute = false,
              StandardOutputEncoding = Configuration.Encoding,
              RedirectStandardOutput = true,
              WindowStyle = ProcessWindowStyle.Hidden
            }
          };
          process.Start();

          var res = process.StandardOutput.ReadToEnd().Replace("<?xml version=\"1.0\"?>\r\n<!DOCTYPE TimeML SYSTEM \"TimeML.dtd\">\r\n<TimeML>","").Replace("</TimeML>", "");
          process.WaitForExit();

          return base.TextPreTokenizerCleanup(res);
        }
        catch
        {
          return string.Empty;
        }
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
              FileName = Path.Combine(TreeTaggerLocator.TreeTaggerRootDirectory, @"bin\tree-tagger.exe"),
              Arguments = $"-quiet -token -lemma -sgml -no-unknown \"{TreeTaggerLocator.ParFile(LanguageSelected)}\" \"{fileInput.Path}\"",
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

    protected override bool IsEndOfSentence(string[] data)
    {
      throw new NotImplementedException();
    }
  }

  public class HeideltimeTagger : AbstractAdditionalTagger
  {
    private Dictionary<string, string> _hdLanguages = new Dictionary<string, string>
    {
      {"Deutsch", "german"},
      {"Englisch", "english"},
      {"Französisch", "french"},
      {"Italienisch", "italian"},
      {"Niederländisch", "dutch"},
      {"Spanisch", "spanish"},
      {"Polnisch", ""}
    };
    
    public override string DisplayName => "HeidelTime";

    public string LanguageSelected{get;set;}

    protected override string TextPreMergerCleanup(string text, ref Dictionary<string, object> doc)
    {
      using (var fileInput = new TemporaryFile(Configuration.TempPath))
      {
        FileIO.Write(fileInput.Path, text);

        var dct = doc.ContainsKey("Datum") &&
                  doc["Datum"] is DateTime &&
                  (DateTime) doc["Datum"] > DateTime.MinValue
          ? $"-t news -dct {(DateTime) doc["Datum"]:yyyy-MM-dd}"
          : "-t narratives";
        
        try
        {
          var process = new Process
          {
            StartInfo =
            {
              FileName = Configuration.GetDependencyPath(@"Java\bin\java.exe"),
              Arguments = $"-jar de.unihd.dbs.heideltime.standalone.jar -e utf8 -l {_hdLanguages[LanguageSelected]} {dct} -pos no {fileInput}",
              CreateNoWindow = true,
              UseShellExecute = false,
              StandardOutputEncoding = Configuration.Encoding,
              RedirectStandardOutput = true,
              WindowStyle = ProcessWindowStyle.Hidden
            }
          };
          process.Start();

          var res = process.StandardOutput.ReadToEnd().Replace("<?xml version=\"1.0\"?>\r\n<!DOCTYPE TimeML SYSTEM \"TimeML.dtd\">\r\n<TimeML>","").Replace("</TimeML>", "");
          process.WaitForExit();

          return base.TextPreTokenizerCleanup(res);
        }
        catch
        {
          return string.Empty;
        }
      }           
    }

    protected override void Cleanup()
    {
    }

    protected override IEnumerable<AbstractLayerState> ExecuteCall(ref AbstractCorpusAdapter corpus)
    {
      throw new NotImplementedException();
    }

    protected override void Initialize()
    {
    }
  }
  */
  /*
  public class HeideltimeTagger : AbstractTaggerOneWordPerLine
  {
    private Dictionary<string, string > _languagesAvailable = new Dictionary<string, string>
    {
      {"Deutsch", "german"},
      {"Englisch", "english"},
      {"Französisch", "french"},
      {"Italienisch", "italian"},
      {"Niederländisch", "dutch"},
      {"Spanisch", "spanish"},
      {"Polnisch", ""}
    };

    private string _languageSelected;

    public HeideltimeTagger()
    {
      AddValueLayer("Wort", 0);
      AddValueLayer("POS", 1);
      AddValueLayer("Lemma", 2);

      var phrase = AddRangeLayer("Zeit");
      phrase.AddRange(x => x == "<TIMEX3", 
        x =>
        {
          const string marker = "value=\"";
          var s = x.IndexOf(marker, StringComparison.CurrentCulture) + marker.Length;
          var e = x.IndexOf("\"", s + 1, StringComparison.CurrentCulture);
          return x.Substring(s, e - s);
        }, 
        x => x == "</TIMEX3>");

      Tokenizer = new NoTokenizer(); // Wird durch das Batch-Skript erledigt
    }

    public override string DisplayName => "TreeTagger (ohne Phrasen / höhere Performance)";

    public override string InstallationPath { get; set; }

    public override IEnumerable<string> LanguagesAvailabel => _languagesAvailable.Keys;

    public override string LanguageSelected
    {
      get => _languageSelected;
      set
      {
        _languageSelected = value;
        Tokenizer = value == "Deutsch" ? (AbstractTokenizer) new HighSpeedGermanTokenizer() : new HighSpeedSpaceTokenizer();
      }
    }

    protected override string Process(string text, ref Dictionary<string, object> doc)
    {
      using (var fileInput = new TemporaryFile(Configuration.TempPath))
      {
        FileIO.Write(fileInput.Path, text);

        var dct = doc.ContainsKey("Datum") &&
                  doc["Datum"] is DateTime &&
                  (DateTime) doc["Datum"] > DateTime.MinValue
          ? $"-t news -dct {(DateTime) doc["Datum"]:yyyy-MM-dd}"
          : "-t narratives";
        
        try
        {
          var process = new Process
          {
            StartInfo =
            {
              FileName = Configuration.GetDependencyPath(@"Java\bin\java.exe"),
              Arguments = $"-jar de.unihd.dbs.heideltime.standalone.jar -e utf8 -l {_languagesAvailable[LanguageSelected]} {dct} -pos no {fileInput}",
              CreateNoWindow = true,
              UseShellExecute = false,
              StandardOutputEncoding = Configuration.Encoding,
              RedirectStandardOutput = true,
              WindowStyle = ProcessWindowStyle.Hidden
            }
          };
          process.Start();

          var res = process.StandardOutput.ReadToEnd().Replace("<?xml version=\"1.0\"?>\r\n<!DOCTYPE TimeML SYSTEM \"TimeML.dtd\">\r\n<TimeML>","").Replace("</TimeML>", "");
          process.WaitForExit();

          return base.TextPreTokenizerCleanup(res);
        }
        catch
        {
          return string.Empty;
        }
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
              FileName = Path.Combine(TreeTaggerLocator.TreeTaggerRootDirectory, @"bin\tree-tagger.exe"),
              Arguments = $"-quiet -token -lemma -sgml -no-unknown \"{TreeTaggerLocator.ParFile(LanguageSelected)}\" \"{fileInput.Path}\"",
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

    protected override bool IsEndOfSentence(string[] data)
    {
      throw new NotImplementedException();
    }
  }
  */
}