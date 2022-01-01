#region

using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Bcs.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.RawText;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.TreeTagger.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.TreeTagger.LocatorStrategy.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tokenizer;

#endregion

namespace CorpusExplorer.Sdk.Extern.DtaCAB
{
  public class DtaCabTreeTagger : AbstractTagger
  {
    public override string DisplayName => "DTA::CAB + TreeTagger";

    public override string InstallationPath
    {
      get => "(NICHT WÄHLBAR - OPTIMIERTE VERSION)";
      set { }
    }

    public override IEnumerable<string> LanguagesAvailabel => new[] { "Deutsch (Mittelhochdeutsch)" };
    public override string LanguageSelected { get; set; } = "Deutsch (Mittelhochdeutsch)";

    private void DisplayError(string message)
    {
      MessageBox.Show(string.Format(DtaCabValidator.ErrorTemplate, message), "Fehler", MessageBoxButtons.OK);
    }

    public override void Execute()
    {
      // Tokenisiere
      var tagRaw = new RawTextTagger();
      tagRaw.Input = Input;
      tagRaw.DefineEndOfSentence(new[] { ".", "<s/>", "<s />", "!", ":", "?" });
      tagRaw.Execute();

      if (!tagRaw.Output.TryDequeue(out var corpus))
        return;

      // Überprüfe DTA::CAB-Bedingungen
      if (!DtaCabValidator.RuleCorpus(corpus.CountDocuments))
      {
        DisplayError(DtaCabValidator.ErrorRuleCorpus);
        return;
      }

      var testL = corpus.GetLayers("Wort").FirstOrDefault();
      if (testL == null)
        return;

      var sum = 0;
      foreach (var dsel in corpus.DocumentGuids)
      {
        var text = testL.GetReadableDocumentByGuid(dsel).ReduceDocumentToText();

        if (!DtaCabValidator.RuleSingleTextLength(text.Length))
        {
          DisplayError(DtaCabValidator.ErrorRuleSingleTextLength);
          return;
        }

        sum += text.Length;
        if (!DtaCabValidator.RuleCorpusLength(sum))
        {
          DisplayError(DtaCabValidator.ErrorRuleCorpusLength);
          return;
        }
      }

      // Sende an DTA::CAB
      var tagCab = new DtaCabAdditionalTagger();
      tagCab.Input.Enqueue(corpus);
      tagCab.Execute();

      if (!tagCab.Output.TryDequeue(out corpus))
        return;

      // Verwende die Ausgabe von DTA::CAB, um die Texte mit TreeTagger zu annotieren
      var origL = corpus.GetLayers("Wort").FirstOrDefault()?.ToLayerState(valueIndex: 3);
      if (origL == null)
        return;

      origL.Displayname = "Original";

      var layer = corpus.GetLayers("DTA::CAB").FirstOrDefault();
      if (layer == null)
        return;

      var docs = new List<Dictionary<string, object>>();
      foreach (var dsel in corpus.DocumentGuids)
      {
        var dic = new Dictionary<string, object>
        {
          { "GUID", dsel },
          { "Text", layer.GetReadableDocumentByGuid(dsel).ReduceDocumentToText() }
        };
        var met = corpus.GetDocumentMetadata(dsel);
        foreach (var x in met)
          if (!dic.ContainsKey(x.Key))
            dic.Add(x.Key, x.Value);
        docs.Add(dic);
      }

      var tagIntTt = new SimpleInternalTreeTagger();
      tagIntTt.Input.Enqueue(docs);
      tagIntTt.Execute();

      if (!tagIntTt.Output.TryDequeue(out corpus))
        return;

      // Füge die Orignaldaten wieder an
      Output.Enqueue(CorpusBuilder.Append(corpus, new[] { origL }));
    }

    private sealed class SimpleInternalTreeTagger : AbstractTreeTagger
    {
      public SimpleInternalTreeTagger()
      {
        Tokenizer = new HighSpeedSpaceTokenizer();

        AddValueLayer("Wort", 0);
        AddValueLayer("POS", 1);
        AddValueLayer("Lemma", 2);
      }

      public override string DisplayName => "TreeTagger (INTERN)";

      public override string LanguageSelected
      {
        get => base.LanguageSelected;
        set
        {
          base.LanguageSelected = value;
          Tokenizer = new HighSpeedSpaceTokenizer();
        }
      }

      protected override AbstractLocatorStrategy LocatorStrategy => null; // muss null sein

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
                FileName = Path.Combine(Configuration.GetDependencyPath(@"TreeTagger"), @"bin\tree-tagger.exe"),
                Arguments =
                  $"-quiet -token -lemma -sgml -no-unknown \"{Configuration.GetDependencyPath(@"TreeTagger/lib/middle-high-german.par")}\" \"{fileInput.Path}\"",
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
    }
  }
}