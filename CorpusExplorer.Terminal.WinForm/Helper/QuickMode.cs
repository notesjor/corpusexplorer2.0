using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Bcs.IO;
using CorpusExplorer.Sdk.Diagnostic;
using CorpusExplorer.Sdk.Ecosystem;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Extension;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Cleanup;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.TreeTagger;
using CorpusExplorer.Sdk.ViewModel;
using CorpusExplorer.Terminal.WinForm.Forms.CorpusError;
using CorpusExplorer.Terminal.WinForm.Forms.Scraper;
using CorpusExplorer.Terminal.WinForm.Forms.Simple;
using CorpusExplorer.Terminal.WinForm.Forms.Splash;
using CorpusExplorer.Terminal.WinForm.Forms.Tagger;
using CorpusExplorer.Terminal.WinForm.Properties;

namespace CorpusExplorer.Terminal.WinForm.Helper
{
  public static class QuickMode
  {
    public static Project Initialize()
    {
      return CorpusExplorerEcosystem.Initialize().Project;
    }

    public static void Annotate(Project project, bool showSaveFileDialog)
    {
      var dic = Configuration.AddonScrapers.ToArray();
      var ofd = new OpenFileDialog
      {
        CheckFileExists = true,
        CheckPathExists = true,
        Multiselect = true,
        Filter = string.Join("|", dic.Select(x => x.Key))
      };
      if (ofd.ShowDialog() != DialogResult.OK)
        return;

      AnnotatePreProcessing(project, dic[ofd.FilterIndex - 1].Value, ofd.FileNames);

      if (showSaveFileDialog)
        Export(project);
    }

    public static void Annotate(Project project, string knownScraperName, string[] files, bool showSaveFileDialog)
    {
      var scraper = Configuration.AddonScrapers.GetReflectedTypeNameDictionary()
                                 .Where(x => x.Key == knownScraperName)
                                 .Select(x => x.Value)
                                 .FirstOrDefault();
      if (scraper == null)
        return;

      AnnotatePreProcessing(project, scraper, files);

      if (showSaveFileDialog)
        Export(project);
    }

    public static void AnnotatePreProcessing(Project project, AbstractScraper scraper, IEnumerable<string> files)
    {
      var time = DateTime.Now;

      Processing.Invoke(Resources.Corpus_Reading,
                        () =>
                        {
                          scraper.Input.Enqueue(files);
                          scraper.Execute();
                        });

      RegexXmlMarkupCleanup cleaner2 = null;
      Processing.Invoke(Resources.CleanDocuments,
                        () =>
                        {
                          var cleaner1 = new StandardCleanup { Input = scraper.Output };
                          cleaner1.Execute();
                          cleaner2 = new RegexXmlMarkupCleanup { Input = cleaner1.Output };
                          cleaner2.Execute();
                        });

      InMemoryErrorConsole.TrackEvent(new Dictionary<string, double>
      {
        {$"SCRAPE (format): {scraper.GetType().FullName}", 0 },
        { "SCRAPE (ms)", (DateTime.Now - time).Milliseconds },
        { "SCRAPE (files)", files.Count() }
      });

      AnnotateProcessing(project, cleaner2?.Output);
    }

    public static void AnnotateProcessing(Project project, ConcurrentQueue<Dictionary<string, object>> docs)
    {
      var formScraper = new ShowScraperResults(docs);
      if (formScraper.ShowDialog() != DialogResult.OK)
        return;

      var formTagger = new SelectTagger(new ClassicTreeTagger { LanguageSelected = Resources.German });
      if (formTagger.ShowDialog() != DialogResult.OK)
        return;

      var formName = new SimpleTextInput(
                                         Resources.Dashboard_EnterCorpusNameHead,
                                         Resources.Dashboard_EnterCorpusNameDescription,
                                         Resources.cabinet,
                                         Resources.Dashboard_EnterCorpusNameNullText);
      if (formName.ShowDialog() != DialogResult.OK)
        return;

      var time = DateTime.Now;
      var input = formScraper.Documets.Count;
      var output = 0;

      var tagger = formTagger.Tagger;
      tagger.Input = formScraper.Documets;

      Processing.Invoke(
                        Resources.AnnotiereDokumente,
                        () =>
                        {
                          tagger.Execute();
                          while (tagger.Output.Count > 0)
                          {
                            if (!tagger.Output.TryDequeue(out var corpus))
                              continue;

                            output = corpus.CountDocuments;

                            corpus.CorpusDisplayname = formName.Result;
                            corpus.Save(Path.Combine(Configuration.MyCorpora, formName.Result.EnsureFileName()));
                            AddCorpusToProject(project, corpus);
                          }
                        });

      InMemoryErrorConsole.TrackEvent(new Dictionary<string, double>
      {
        { "TAGGING (ms)", (DateTime.Now - time).Milliseconds },
        { $"TAGGING (Tagger): {tagger.GetType().FullName}", 0 },
        { $"TAGGING (Tagger - Language): {tagger.LanguageSelected}", 0 },
        { "TAGGING (docs - IN)", input },
        { "TAGGING (docs - OUT)", output }
      });
    }

    public static void AddCorpusToProject(Project project, AbstractCorpusAdapter corpus)
    {
      if (corpus == null ||
          corpus.CountDocuments == 0)
      {
        MessageBox.Show(
                        Resources.Corpus_LoadingError,
                        Resources.Corpus_LoadingErrorHead,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
        return;
      }

      if (project.ContainsCorpus(corpus.CorpusGuid))
        return;

      var selection = corpus.ToSelection();
      var vm = new ValidateSelectionIntegrityViewModel { Selection = selection };
      vm.Execute();

      if (vm.HasError)
      {
        Processing.SplashClose();
        var form = new CorpusErrorForm(vm);
        form.ShowDialog();

        if (form.ResultSelection != null)
        {
          corpus = form.ResultSelection.ToCorpus();
          Processing.SplashClose();
          if (MessageBox.Show("Möchten Sie das bereinigte Korpus speichern?", "Änderungen speichern?",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            Export(selection);
          Processing.SplashShow("Korpus wird überarbeitet...");
        }
      }

      project.Add(corpus);
    }

    public static void Convert(Project project)
    {
      Import(project);
      Export(project);
    }

    public static void Convert(Project project, string knownImporterName, string[] files)
    {
      var importer = Configuration.AddonImporters.GetReflectedTypeNameDictionary()
                                  .Where(x => x.Key == knownImporterName)
                                  .Select(x => x.Value)
                                  .FirstOrDefault();
      if (importer == null)
        return;

      Import(project, importer, files);

      Export(project);
    }

    public static void Import(Project project)
    {
      var dic = Configuration.AddonImporters.ToArray();
      var ofd = new OpenFileDialog
      {
        CheckFileExists = true,
        CheckPathExists = true,
        Multiselect = true,
        Filter = string.Join("|", dic.Select(x => x.Key))
      };
      if (ofd.ShowDialog() != DialogResult.OK)
        return;

      Import(project, dic[ofd.FilterIndex - 1].Value, ofd.FileNames);
    }

    public static void Import(Project project, AbstractImporter importer, IEnumerable<string> files)
    {
      var time = DateTime.Now;
      IEnumerable<AbstractCorpusAdapter> corpora = null;
      Processing.Invoke(Resources.Corpus_ImportIsRunning,
                        () => { corpora = importer.Execute(files); });

      if (corpora == null && files.Count() == 1)
      {
        MessageBox.Show(Resources.Corpus_ImportError);
        return;
      }

      Processing.Invoke(
                        Resources.Corpus_Loading,
                        () =>
                        {
                          if (corpora != null)
                            foreach (var corpus in corpora)
                              AddCorpusToProject(project, corpus);
                        });

      InMemoryErrorConsole.TrackEvent(new Dictionary<string, double>
      {
        {$"IMPORT (format): {importer.GetType().FullName}", 0 },
        { "IMPORT (ms)", (DateTime.Now - time).Milliseconds },
        { "IMPORT (files)", files.Count() }
      });
    }

    public static void Export(Project project) => Export(project.SelectAll);

    public static void Export(Selection selection)
    {
      var dic = Configuration.AddonExporters.ToArray();
      var sfd = new SaveFileDialog
      {
        CheckPathExists = true,
        Filter = string.Join("|", dic.Select(x => x.Key))
      };
      if (sfd.ShowDialog() != DialogResult.OK)
        return;

      var time = DateTime.Now;
      var exporter = dic[sfd.FilterIndex - 1].Value;

      Processing.Invoke(Resources.GutDingWillWeileHaben, () => exporter.Export(selection, sfd.FileName));

      InMemoryErrorConsole.TrackEvent(new Dictionary<string, double>
      {
        {$"EXPORT (format): {exporter.GetType().FullName}", 0 },
        { "EXPORT (ms)", (DateTime.Now - time).Milliseconds }
      });
    }

    public static void SoftReset()
    {
      try
      {
        var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "update.info");
        var lines = FileIO.ReadLines(path, Encoding.UTF8);
        Thread.Sleep(200);
        FileIO.Write(path, lines.Where(line => !line.ToLower().Contains("corpusexplorer/app.zip|")).ToArray(), Encoding.UTF8);
        MessageBox.Show("Der CorpusExplorer wurde erfolgreich zurückgesetzt (soft reset). Bitte starten Sie den CorpusExplorer erneut und installieren Sie das Update.",
                        "..:: CorpusExplorer - QuickMode ::..", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Information);
      }
      catch
      {
        // ignore
      }
    }

    public static void HardReset()
    {
      try
      {
        File.Delete(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "update.info"));
        MessageBox.Show("Der CorpusExplorer wurde erfolgreich zurückgesetzt (hard reset). Bitte starten Sie den CorpusExplorer erneut und installieren Sie das Update.",
                        "..:: CorpusExplorer - QuickMode ::..",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
      }
      catch
      {
        // ignore
      }
    }

    public static void DisplayHelp()
    {
      var message = string.Join("\n", new[]
      {
        "--help\t-  Zeigt diese Hilfe an.",
        "--anno\t-  Automatische Annotation mittels GUI.",
        "--conv\t-  Konvertiert bestehende Korpora.",
        "--sreset\t-  Setzt den CorpusExplorer zurück (soft reset).",
        "--hreset\t-  Setzt den CorpusExplorer zurück (hard reset)."
      });

      MessageBox.Show(message, "..:: CorpusExplorer - QuickMode ::..", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
  }
}
