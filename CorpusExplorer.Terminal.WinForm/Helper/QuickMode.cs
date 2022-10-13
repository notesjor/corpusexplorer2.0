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
using CorpusExplorer.Sdk.Model.Adapter.Corpus;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Extension;
using CorpusExplorer.Sdk.Utils.CorpusManipulation;
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
    /// <summary>
    /// Erzeugt ein neues Projekt
    /// </summary>
    /// <returns></returns>
    public static Project Initialize()
    {
      return CorpusExplorerEcosystem.Initialize().Project;
    }

    /// <summary>
    /// Annotiert beliebige Dokumente. Ein Dialog zur Auswahl von Dateien und Dateitypen wird angezeigt.
    /// </summary>
    /// <param name="project">Prijekt (kann mittels QuickMode.Initialize() erzeugt werden)</param>
    /// <param name="showSaveFileDialog">Soll ein Dialog zum Speichern des Korpus angezeigt werden?</param>
    /// <param name="checkErrors">Soll das annotierte Korpus auf Fehler geprüft werden?</param>
    public static void Annotate(Project project, bool showSaveFileDialog, bool checkErrors = true)
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

      AnnotatePreProcessing(project, dic[ofd.FilterIndex - 1].Value, ofd.FileNames, checkErrors);

      if (showSaveFileDialog)
        Export(project);
    }

    /// <summary>
    /// Annotiert beliebige Dokumente.
    /// </summary>
    /// <param name="project">Projekt (kann mittels QuickMode.Initialize() erzeugt werden)</param>
    /// <param name="knownScraperName">Name des Scrapers (Dateiformat)</param>
    /// <param name="files">Liste mit Dateien.</param>
    /// <param name="showSaveFileDialog">Soll ein Dialog zum Speichern des Korpus angezeigt werden?</param>
    /// <param name="checkErrors">Soll das annotierte Korpus auf Fehler geprüft werden?</param>
    public static void Annotate(Project project, string knownScraperName, string[] files, bool showSaveFileDialog, bool checkErrors = true)
    {
      var scraper = Configuration.AddonScrapers.GetReflectedType(knownScraperName, "Scraper");
      if (scraper == null)
        return;

      AnnotatePreProcessing(project, scraper, files, checkErrors);

      if (showSaveFileDialog)
        Export(project);
    }

    private static void AnnotatePreProcessing(Project project, AbstractScraper scraper, IEnumerable<string> files, bool checkErrors)
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

      Tagging(project, cleaner2?.Output, checkErrors);
    }

    /// <summary>
    /// Taggt bereits extrahierte und bereinigte Dokumente
    /// </summary>
    /// <param name="project">Prijekt (kann mittels QuickMode.Initialize() erzeugt werden)</param>
    /// <param name="docs">Bereits extrahierte und bereinigte Dokumente</param>
    /// <param name="checkErrors">Soll das annotierte Korpus auf Fehler geprüft werden?</param>
    public static void Tagging(Project project, ConcurrentQueue<Dictionary<string, object>> docs, bool checkErrors = true)
    {
      var formScraper = new ShowScraperResults(docs);
      if (formScraper.ShowDialog() != DialogResult.OK)
        return;

      var formTagger = new SelectTagger(new ClassicTreeTagger { LanguageSelected = Resources.German });
      if (formTagger.ShowDialog() != DialogResult.OK)
        return;

      var formName = new SimpleTextInputValidation(
                                         Resources.Dashboard_EnterCorpusNameHead,
                                         Resources.Dashboard_EnterCorpusNameDescription,
                                         Resources.cabinet,
                                         Resources.Dashboard_EnterCorpusNameNullText,
                                         CorpusNameCheck);
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

                            SaveCorpus(corpus, formName.Result);
                            AddCorpusToProject(project, corpus, checkErrors);
                          }
                        });
    }

    private static void SaveCorpus(AbstractCorpusAdapter corpus, string name)
    {
      corpus.CorpusDisplayname = name;

      try
      {
        corpus.Save(Path.Combine(Configuration.MyCorpora, name.EnsureFileName() + ".cec6.lz4"), true);
      }
      catch (FileNotFoundException)
      {
        try
        {
          MessageBox.Show("Der CorpusExplorer hat festgestellt, dass der Windows Defender die Korpusverarbeitung blockiert.\nLösungen:\n1) Deaktivieren Sie den 'Überwachten Ordnerzugriff' ganz oder selektiv für den Ordner 'Dokumente\\CorpusExplorer'.\n2) Im folgenden Schritt können Sie das Korpus außerhalb (in einem anderen Ordner) speichern.");
          Export(corpus.ToSelection());
        }
        catch
        {
          // ignore
        }
      }
    }

    private static string CorpusNameCheck(string arg)
    {
      if (string.IsNullOrWhiteSpace(arg))
        return Resources.QuickMode_CorpusNameCheck_Warn_NoName;

      var chars = Path.GetInvalidFileNameChars();
      return chars.Any(arg.Contains)
               ? Resources.InvalidPathChars
               : File.Exists(Path.Combine(Configuration.MyCorpora, arg + ".cec6"))
                 ? Resources.QuickMode_CorpusNameCheck_Warn_AlreadyExsits
                 : null;
    }

    /// <summary>
    /// Fügt einem Projekt ein neues Korpus hinzu.
    /// </summary>
    /// <param name="project">Prijekt (kann mittels QuickMode.Initialize() erzeugt werden)</param>
    /// <param name="corpus"></param>
    /// <param name="checkErrors">Soll das annotierte Korpus auf Fehler geprüft werden?</param>
    public static void AddCorpusToProject(Project project, AbstractCorpusAdapter corpus, bool checkErrors)
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

      var name = corpus.CorpusDisplayname;
      var selection = corpus.ToSelection();

      if (checkErrors)
      {
        var vm = new ValidateSelectionIntegrityViewModel { Selection = selection };
        vm.Execute();
        if (vm.HasError)
        {
          Processing.SplashClose();
          var form = new CorpusErrorForm(vm);
          form.ShowDialog();

          if (form.ResultSelection != null)
          {
            Processing.SplashClose();
            if (MessageBox.Show("Möchten Sie das bereinigte Korpus speichern?", "Änderungen speichern?",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
              Export(form.ResultSelection);
            Processing.SplashShow("Korpus wird überarbeitet...");
          }
        }
      }

      project.Add(corpus);
    }

    /// <summary>
    /// Konvertiert Korpora in ein neues Korpus
    /// </summary>
    /// <param name="project">Prijekt (kann mittels QuickMode.Initialize() erzeugt werden)</param>
    /// <param name="checkErrors">Soll das annotierte Korpus auf Fehler geprüft werden?</param>
    public static void Convert(Project project, bool checkErrors)
    {
      Import(project, checkErrors);
      Export(project);
    }

    /// <summary>
    /// Konvertiert Korpora in ein neues Korpus
    /// </summary>
    /// <param name="project">Prijekt (kann mittels QuickMode.Initialize() erzeugt werden)</param>
    /// <param name="knownImporterName">Name des Importers (Dateiformat)</param>
    /// <param name="files">Liste mit Dateien.</param>
    /// <param name="checkErrors">Soll das annotierte Korpus auf Fehler geprüft werden?</param>
    public static void Convert(Project project, string knownImporterName, string[] files, bool checkErrors)
    {
      var importer = Configuration.AddonImporters.GetReflectedType(knownImporterName, "Importer");
      if (importer == null)
        return;

      Import(project, importer, files, checkErrors);

      Export(project);
    }

    /// <summary>
    /// Importiert bestehende Korpora in das Projekt
    /// </summary>
    /// <param name="project">Prijekt (kann mittels QuickMode.Initialize() erzeugt werden)</param>
    /// <param name="checkErrors">Soll das annotierte Korpus auf Fehler geprüft werden?</param>
    public static void Import(Project project, bool checkErrors)
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

      Import(project, dic[ofd.FilterIndex - 1].Value, ofd.FileNames, checkErrors);
    }

    /// <summary>
    /// Importiert bestehende Korpora in das Projekt
    /// </summary>
    /// <param name="project">Prijekt (kann mittels QuickMode.Initialize() erzeugt werden)</param>
    /// <param name="importer"></param>
    /// <param name="files">Liste mit Dateien.</param>
    /// <param name="checkErrors">Soll das annotierte Korpus auf Fehler geprüft werden?</param>
    private static void Import(Project project, AbstractImporter importer, IEnumerable<string> files, bool checkErrors)
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

      // z. B. wenn CEC6 importiert wird
      if (importer.HasStaticGuids)
      {
        Processing.Invoke(
                         Resources.Corpus_Loading,
                         () =>
                         {
                           if (corpora != null)
                             foreach (var corpus in corpora)
                               AddCorpusToProject(project, corpus, checkErrors);
                         });
        return;
      }

      // Alle anderen Fälle
      var formName = new SimpleTextInputValidation(
                                                   Resources.Dashboard_EnterCorpusNameHead,
                                                   Resources.Dashboard_EnterCorpusNameDescription,
                                                   Resources.cabinet,
                                                   Resources.Dashboard_EnterCorpusNameNullText,
                                                   CorpusNameCheck);
      if (formName.ShowDialog() != DialogResult.OK)
        return;

      var merged = CorpusMerger.Merge(corpora);
      foreach (var corpus in corpora)
        corpus.Dispose();

      SaveCorpus(merged, formName.Result);
      AddCorpusToProject(project, merged, checkErrors);
    }

    /// <summary>
    /// Exportiert alle Korpora eines Projekts in ein neues Korpus.
    /// </summary>
    /// <param name="project">Projekt</param>
    public static void Export(Project project) => Export(project.SelectAll);

    /// <summary>
    /// Exportiert einen Schnappschuss.
    /// </summary>
    /// <param name="selection">Schnappschuss</param>
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
    }

    /// <summary>
    /// Setzt den CorpusExplorer weich zurück.
    /// Löscht nur die Anwendungsdaten.
    /// </summary>
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

    /// <summary>
    /// Setzt den CorpusExplorer hart zurück.
    /// Löscht dabei die Anwendungsdaten und alle Add-ons.
    /// </summary>
    public static void HardReset()
    {
      try
      {
        File.Delete(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "update.info"));

        var dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "CorpusExplorer\\Meine Erweiterungen");
        if (Directory.Exists(dir))
          Directory.Delete(dir, true);
        Directory.CreateDirectory(dir);

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

    /// <summary>
    /// Zeigt die Hilfe zum QuickMode an.
    /// </summary>
    public static void DisplayHelp()
    {
      var message = string.Join("\n", new[]
      {
        "--help\t-\tZeigt diese Hilfe an.",
        "--anno\t-\tAutomatische Annotation mittels GUI.",
        "--conv\t-\tKonvertiert bestehende Korpora.",
        "--sreset\t-\tSetzt den CorpusExplorer zurück (soft reset).",
        "--hreset\t-\tSetzt den CorpusExplorer zurück (hard reset).",
        "--no-browser\t-\tNutzt den systemeigenen Web-Browser (Linux/MacOS).",
        "--lang:CODE\t-\tSetzt die Sprache des CorpusExplorers z. B. en_UK",
      });

      MessageBox.Show(message, "..:: CorpusExplorer - QuickMode ::..", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }


    /// <summary>
    /// Liest Kommandozeilenargumente ab der 2-Position aus.
    /// Prüft ob es sich um eine Datei oder eine 
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    public static string[] GetFilesHelper(string[] args)
    {
      var res = new List<string>();
      for (var i = 2; i < args.Length; i++)
      {
        try
        {
          var attr = File.GetAttributes(args[i]);
          if (attr.HasFlag(FileAttributes.Directory))
            res.AddRange(Directory.GetFiles(args[i], "*.*", SearchOption.TopDirectoryOnly));
          else
            res.Add(args[i]);
        }
        catch
        {
          // ignore
        }
      }

      return res.ToArray();
    }
  }
}
