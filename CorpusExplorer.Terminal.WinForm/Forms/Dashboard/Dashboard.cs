#region

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using Bcs.IO;
using CorpusExplorer.Sdk.Addon;
using CorpusExplorer.Sdk.Aspect;
using CorpusExplorer.Sdk.Blocks.Cooccurrence;
using CorpusExplorer.Sdk.Compatibility;
using CorpusExplorer.Sdk.Diagnostic;
using CorpusExplorer.Sdk.Ecosystem;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Extern.FuzzyCloneDetection.ViewModel;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Extension;
using CorpusExplorer.Sdk.Model.Interface;
using CorpusExplorer.Sdk.Terminal;
using CorpusExplorer.Sdk.Utils.CorpusManipulation;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Builder;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Cleanup;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Crawler;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.TreeTagger;
using CorpusExplorer.Sdk.Utils.Filter;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;
using CorpusExplorer.Sdk.Utils.Filter.Queries;
using CorpusExplorer.Sdk.ViewModel;
using CorpusExplorer.Terminal.WinForm.Controls.WinForm;
using CorpusExplorer.Terminal.WinForm.Controls.WinForm.Snapshot;
using CorpusExplorer.Terminal.WinForm.Controls.WinForm.Webbrowser;
using CorpusExplorer.Terminal.WinForm.Forms.Abstract;
using CorpusExplorer.Terminal.WinForm.Forms.CloneDetection;
using CorpusExplorer.Terminal.WinForm.Forms.CorpusError;
using CorpusExplorer.Terminal.WinForm.Forms.Error;
using CorpusExplorer.Terminal.WinForm.Forms.Insight;
using CorpusExplorer.Terminal.WinForm.Forms.Interfaces;
using CorpusExplorer.Terminal.WinForm.Forms.Scraper;
using CorpusExplorer.Terminal.WinForm.Forms.Simple;
using CorpusExplorer.Terminal.WinForm.Forms.Snapshot;
using CorpusExplorer.Terminal.WinForm.Forms.Splash;
using CorpusExplorer.Terminal.WinForm.Forms.Tagger;
using CorpusExplorer.Terminal.WinForm.Forms.ValidationCorpus;
using CorpusExplorer.Terminal.WinForm.Forms.WebCrawler;
using CorpusExplorer.Terminal.WinForm.Helper;
using CorpusExplorer.Terminal.WinForm.Helper.UiFramework;
using CorpusExplorer.Terminal.WinForm.Localizer.GridView;
using CorpusExplorer.Terminal.WinForm.Localizer.PivotGrid;
using CorpusExplorer.Terminal.WinForm.Properties;
using CorpusExplorer.Terminal.WinForm.View.Cooccurrence;
using CorpusExplorer.Terminal.WinForm.View.CorpusDistribution;
using CorpusExplorer.Terminal.WinForm.View.Disambigution;
using CorpusExplorer.Terminal.WinForm.View.EditionTools;
using CorpusExplorer.Terminal.WinForm.View.Frequency;
using CorpusExplorer.Terminal.WinForm.View.Fulltext;
using CorpusExplorer.Terminal.WinForm.View.Ngram;
using CorpusExplorer.Terminal.WinForm.View.Special;
using CorpusExplorer.Terminal.WinForm.View.StyleMetrics;
using ICSharpCode.SharpZipLib.Zip;
using Telerik.WinControls;
using Telerik.WinControls.Enumerations;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;
using ArrowDirection = Telerik.WinControls.ArrowDirection;
using PositionChangedEventArgs = Telerik.WinControls.UI.Data.PositionChangedEventArgs;
using CompareBasedOnNgrams = CorpusExplorer.Terminal.WinForm.View.StyleMetrics.CompareBasedOnNgrams;
using CompareBasedOnCooccurrences = CorpusExplorer.Terminal.WinForm.View.StyleMetrics.CompareBasedOnCooccurrences;
using CompareBasedOnBurrowsDelta = CorpusExplorer.Terminal.WinForm.View.StyleMetrics.CompareBasedOnBurrowsDelta;

#endregion

namespace CorpusExplorer.Terminal.WinForm.Forms.Dashboard
{
  /// <summary>
  ///   The dashboard.
  /// </summary>
  public partial class Dashboard : AbstractForm, IMainForm
  {
    private readonly RadMenuItem _addonMenuItem = new RadMenuItem { Image = Resources.addin, Text = "Erweiterungen" };
    private readonly DisposingContainer _snapshotEditDisposingContainer = new DisposingContainer();
    private readonly string _snapshotFileExtension = "Universale Schnappschuss-Definition (*.ceusd)|*.ceusd";

    /// <summary>
    ///   The _terminal.
    /// </summary>
    private readonly TerminalController _terminal;

    private readonly Label txt_snapshot_infoHeader;

    private AbstractView _currentView;
    private Selection _selectionEditCurrentSelection;
    private Selection _selectionEditParentSelection;

    private List<AbstractFilterQuery> _selectionEditQueries;
    private KeyValuePair<string, ISignificance>[] _significanceMessures;

    /// <summary>
    ///   Initializes a new instance of the <see cref="Dashboard" /> class.
    /// </summary>
    public Dashboard(string[] args)
      : base(null)
    {
      Serializer.LogErrors = false;
      _terminal = CorpusExplorerEcosystem.Initialize();
      ProjectNew();

      InitializeComponent();

      #region 3rdPpartyPanel

      if (_addonMenuItem.Children[2].Children[0].Children[1].Children[0] is TextPrimitive tp)
        tp.UseMnemonic = false;
      _addonMenuItem.Click += (o, e) => SetAnalyticModul(page_analytics);

      #endregion

      #region UI Improvements

      FormElement.TitleBar.IconPrimitive.Visibility = ElementVisibility.Collapsed;
      page_welcome_btn_analytics.ImageCheckmark = Resources.image_brightness;
      ((RadDropDownButtonElement)corpus_start_add.RootElement.Children[0]).ActionButton.TextWrap = true;

      pages_main.MakeHeaderInvisible();
      pages_corpora.MakeHeaderInvisible();
      pages_analytics.MakeHeaderInvisible();
      pages_standardanalytics.MakeHeaderInvisible();
      pages_snapshot.MakeHeaderInvisible();
      pages_3rdParty.MakeHeaderInvisible();

      main_mainmenu_corpus.Layout.ArrowPrimitive.Direction = ArrowDirection.Down;
      main_mainmenu_analytics.Layout.ArrowPrimitive.Direction = ArrowDirection.Down;
      main_mainmenu_snapshot.Layout.ArrowPrimitive.Direction = ArrowDirection.Down;

      LoadGuiModules(); // Muss hier stehen

      #endregion

      #region Settings

      Settings_Initialize();
      Settings_ReLoad();

      #endregion

      #region GO:Home

      // Aktiviert die Startseite
      SetPageMain(page_welcome);

      #endregion

      #region Snapshot Info

      txt_snapshot_infoHeader = new Label
      {
        Text = "",
        Dock = DockStyle.Right,
        TextAlign = ContentAlignment.MiddleRight,
        Size = new Size(550, 45),
        AutoSize = false,
        Font = new Font(Font.FontFamily, 11, FontStyle.Regular),
        ForeColor = Color.Gray,
        UseMnemonic = false
      };

      radMenu1.Controls.Add(txt_snapshot_infoHeader);

      #endregion

      #region Lokalisationen

      RadGridLocalizationProvider.CurrentProvider = new GridViewGermanLocalizer();
      PivotGridLocalizationProvider.CurrentProvider = new PivotGridViewGermanLocalizer();

      #endregion

      ParseArguments(args);

      LoadSettings();

      RealoadInsightSettings();

      Corpus_LaodAvailabelCorpora();
      Serializer.LogErrors = true;
      Welcome.SplashClose();
    }

    public AbstractView CurrentView
    {
      get => _currentView;
      set
      {
        _currentView?.ViewModelClear();
        _currentView = value;
      }
    }

    private void AddCorpusToProject(AbstractCorpusAdapter corpus, bool autoReload)
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

      if (Project.ContainsCorpus(corpus.CorpusGuid))
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
          {
            ExportSelectionAsCorpus(selection);
          }
          Processing.SplashShow("Korpus wird überarbeitet...");
        }
      }

      Project.Add(corpus);

      if (!autoReload)
        return;

      ReloadAll();
    }

    private void ReloadAll()
    {
      Selection_ReLoad();
      Corpora_ReLoad();
      Processing.SplashClose();
    }

    private string AskForSelectionDisplayname()
    {
      var form = new SimpleTextInput(
        Resources.SchnappschussErstellen,
        Resources.GebenSieDemNeuenSchnappschussEinenNamen,
        Resources.camera,
        Resources.NameHierEintragen);
      return form.ShowDialog() != DialogResult.OK ? "" : form.Result;
    }

    private void btn_settings_load_Click(object sender, EventArgs e)
    {
      var ofd = new OpenFileDialog { Filter = "Einstellungen (*.cesettings)|*.cesettings", CheckFileExists = true };
      if (ofd.ShowDialog() != DialogResult.OK)
        return;
      var current = Configuration.GetSettings();
      var load = Configuration.GetSettings(ofd.FileName);

      foreach (var x in load)
        if (current.ContainsKey(x.Key))
          current[x.Key] = x.Value;
        else
          current.Add(x.Key, x.Value);

      Configuration.SetSettings(current);
    }

    private void btn_settings_save_Click(object sender, EventArgs e)
    {
      Configuration.SetSettings(((RadPropertyStore)property_meta.SelectedObject)
        .ToDictionary(x => x.PropertyName,
          x => x.Value));
    }

    private void btn_settings_saveas_Click(object sender, EventArgs e)
    {
      var sfd = new SaveFileDialog { Filter = "Einstellungen (*.cesettings)|*.cesettings" };
      if (sfd.ShowDialog() != DialogResult.OK)
        return;
      Configuration.SetSettings(((RadPropertyStore)property_meta.SelectedObject)
        .ToDictionary(x => x.PropertyName,
          x => x.Value), sfd.FileName);
    }

    private void ControlOnQueryRemove(object sender, EventArgs eventArgs)
    {
      SelectionSaveQueries();
      var control = (AbstractSnapshotControl)sender;
      var guid = control.Query.Guid;
      if (guid == Guid.Empty)
        return;
      var item = _selectionEditQueries.Where(x => x.Guid == guid).Select(x => x).FirstOrDefault();
      if (item == null)
        return;

      _selectionEditQueries.Remove(item);
      SelectionReloadQueries();
    }

    private void Corpora_ReLoad()
    {
      // Erneuere Korpusliste
      if (Project?.CurrentSelection == null)
        return;

      // QuickInfo
      var vm = new QuickInfoViewModel { Selection = Project.SelectAll };
      vm.Execute();

      page_corpus_start_quickinfo_corpora.Value = vm.CounterCorpora.ToString();
      page_corpus_start_quickinfo_layers.Value = vm.CounterLayers.ToString();
      page_corpus_start_quickinfo_texts.Value = vm.CounterDocuments.ToString();
      page_corpus_start_quickinfo_tokens.Value = string.Format(
        Resources.Dashboard_NumberFormat,
        vm.CounterTokens / 1000000.0d);

      page_welcome_btn_corpus.ShowCheckmark = vm.CounterCorpora > 0;
    }

    private void Corpus_LaodAvailabelCorpora()
    {
      var files = new List<string>();
      files.AddRange(Directory.GetFiles(Configuration.MyCorpora, Resources.Filter_CEC5));
      files.AddRange(Directory.GetFiles(Configuration.MyCorpora, Resources.Filter_CEC6));

      if (files.Count == 0)
      {
        corpus_start_add.Visible = false;
        main_mainmenu_corpus_load.Visibility = ElementVisibility.Collapsed;
      }
      else
      {
        corpus_start_add.Visible = true;
        main_mainmenu_corpus_load.Visibility = ElementVisibility.Visible;

        var dic = files.ToDictionary(file => file, Path.GetFileNameWithoutExtension);

        var cefss = Directory.GetFiles(Configuration.MyCorpora, "ROOT", SearchOption.AllDirectories);
        if (cefss.Length != 0)
          foreach (var cefs in cefss)
            dic.Add(cefs, new DirectoryInfo(Path.GetDirectoryName(cefs)).Name);

        DictionaryBindingHelper.BindDictionary(dic, corpus_start_add, LoadAvailableCorpus);
        DictionaryBindingHelper.BindDictionary(dic, main_mainmenu_corpus_load, LoadAvailableCorpus);
      }
    }

    private void corpus_online_crawler_create_Click(object sender, EventArgs e)
    {
      var form = new WebCrawlerWizard();
      form.ShowDialog();
      RefreshWebCrawlers();
    }

    private void corpus_online_crawler_start_Click(object sender, EventArgs e)
    {
      if (corpus_online_crawler_start_compile.Checked)
        CrawlerStartExtern();
      else
        CrawlerStartIntern();
    }

    private void corpus_start_import_Click(object sender, EventArgs e)
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

      IEnumerable<AbstractCorpusAdapter> corpora = null;

      Processing.Invoke(
        Resources.Corpus_ImportIsRunning,
        () =>
        {
          var importer = dic[ofd.FilterIndex - 1].Value;
          corpora = importer.Execute(ofd.FileNames);
        });

      if (corpora == null &&
          ofd.FileNames.Length == 1)
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
              AddCorpusToProject(corpus, false); // da false -> ReloadAll();
          ReloadAll();
        });
    }

    private void corpus_start_local_Click(object sender, EventArgs e)
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

      Processing.Invoke(
        Resources.Corpus_Reading,
        () =>
        {
          // Warum auch immer der FilterIndex ist NICHT nullbasiert, daher -1
          var scraper = dic[ofd.FilterIndex - 1].Value;
          foreach (var x in ofd.FileNames)
            scraper.Input.Enqueue(x);
          scraper.Execute();
          ScrapDocumentsToCorpus(scraper.Output);
        });
    }

    private void corpus_start_online_Click(object sender, EventArgs e)
    {
      RefreshWebCrawlers();

      SetPageCorpora(page_corpus_online);
    }

    private void CrawlerStartExtern()
    {
      var fbd = new FolderBrowserDialog
      {
        Description =
          Resources.WebCrawler_Output
      };
      if (fbd.ShowDialog() != DialogResult.OK)
        return;

      var zip = new FastZip();
      zip.ExtractZip("WebCrawler.zip", fbd.SelectedPath, null);

      foreach (var item in corpus_online_crawler_list.Items.Where(item => item.CheckState == ToggleState.On))
      {
        var c = (XpathWebCrawler)item.Tag;
        c.Save(Path.Combine(fbd.SelectedPath, c.DisplayName + ".cml"));
      }

      FileIO.Write(Path.Combine(fbd.SelectedPath, "queries.txt"), corpus_online_crawler_queries.Lines);
    }

    private void CrawlerStartIntern()
    {
      var crawlers =
        corpus_online_crawler_list.Items.Where(item => item.CheckState == ToggleState.On)
          .Select(item => (XpathWebCrawler)item.Tag)
          .ToArray();

      var res = new List<Dictionary<string, object>>();

      var i = 0;
      var l = new object();

      Processing.SplashShow("Websuche beginnt...");
      Parallel.ForEach(
        crawlers,
        Configuration.ParallelOptions,
        c =>
        {
          c.Execute();
          lock (l)
          {
            i++;
            Processing.Message = $"Webseite {i} von {crawlers.Length} abgerufen...";
            res.AddRange(c.Output);
          }
        });
      Processing.SplashClose();

      if (res.Count == 0)
        return;

      ScrapDocumentsToCorpus(new ConcurrentQueue<Dictionary<string, object>>(res));
    }

    private void CurrentSelectionChanged()
    {
      CurrentView?.OnShowVisualisation();

      if (Project.CurrentSelection != null)
        txt_snapshot_infoHeader.Text =
          Project.CurrentSelection.Displayname.Replace("<html>", "")
            .Replace("</html>", "")
            .Replace("<strong>", "")
            .Replace("</strong>", "")
            .Replace("&nbsp;", "");

      page_analytics_snapshot_list_snapshots.ExpandAll();
    }

    private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
    {
      FavoriteManager.Save();

      var res = MessageBox.Show(
        "Möchten Sie das Projekt vor dem Verlassen speichern?",
        "Projekt speichern?",
        MessageBoxButtons.YesNoCancel,
        MessageBoxIcon.Question);
      if (res == DialogResult.Cancel)
      {
        e.Cancel = true;
        return;
      }

      if (res == DialogResult.Yes)
        Processing.Invoke("Projekt wird gespeichert", () => main_mainmenu_project_save_Click(sender, e));

      StaticBrowserHandler.Clear();
    }

    private void Dashboard_Load(object sender, EventArgs e)
    {
      if (DesignMode)
        return;

      FormElement.TitleBar.IconPrimitive.Visibility = ElementVisibility.Collapsed;
      FormElement.TitleBar.IconPrimitive.Image = null;
    }

    private void Dashboard_SizeChanged(object sender, EventArgs e)
    {
    }

    private void LoadAvailableCorpus(object o, EventArgs e)
    {
      var entry = o as RadMenuItem;
      if (!(entry?.Tag is string))
        return;

      Processing.Invoke(
        Resources.Corpus_ExsistingLoading,
        () =>
        {
          var path = entry.Tag as string;
          var ext = Path.GetFileName(path).Replace(Path.GetFileNameWithoutExtension(path), string.Empty).ToLower();

          switch (ext)
          {
            case ".cec5":
              AddCorpusToProject(CorpusAdapterSingleFile.Create(path), true);
              break;
            case ".cec6":
              AddCorpusToProject(CorpusAdapterWriteDirect.Create(path), true);
              break;
          }
        });
    }

    // ReSharper disable once FunctionComplexityOverflow
    private void LoadGuiModules()
    {
      // WICHTIG
      FavoriteManager.InitializeFavoriteManager(this);
      GuiModuleBuilder.InitializeGuiModuleBuilder(this, () => Project);

      // ab hier: modul_panel_rawdata

      GuiModuleBuilder.InitializePage(
          modul_panel_analytics,
          main_mainmenu_analytics,
          (o, e) => SetAnalyticModul(page_rawanalytics_annotation),
          page_rawanalytics_annotation,
          Resources.character_font_highlight_color_1,
          Resources.character_font_highlight_color,
          Resources.Fulltext,
          Resources.Fulltext_Describtion,
          "http://www.bitcutstudios.com/products/corpusexplorer/help/volltextzugriff.html",
          // Handbook
          Resources.Help_Static_HandsOnLab,
          // Hand-on Lab
          Resources.Help_Static_YoutubeChannel,
          // Video
          Resources.Help_Static_AdditionalInformation) // Weitere Informationen
        .AddView(
          new FulltextAnnotation(),
          Resources.layers1,
          Resources.layers,
          Resources.Fulltext_Annotate)
        .AddView(
          new FulltextAnnotationSpeedup(),
          Resources.layers1,
          Resources.layers,
          Resources.Fulltext_SpeedAnnotate)
        .AddView(
          new FulltextKwicSearch(),
          Resources.find1,
          Resources.find,
          "Texte suchen (KWIC)")
        .AddView(
          new FulltextKwicTree(),
          Resources.find1,
          Resources.find,
          "Texte suchen (KWIT)");

      GuiModuleBuilder.InitializePage(
          modul_panel_analytics,
          main_mainmenu_analytics,
          (o, e) => SetAnalyticModul(page_rawanalytics_edition),
          page_rawanalytics_edition,
          Resources.history1,
          Resources.history,
          Resources.Textedition,
          Resources.Textedition_Describtion,
          "http://www.bitcutstudios.com/products/corpusexplorer/help/textedition.html",
          // Handbook
          Resources.Help_Static_HandsOnLab,
          // Hand-on Lab
          Resources.Help_Static_YoutubeChannel,
          // Video
          Resources.Help_Static_AdditionalInformation) // Weitere Informationen
        .AddView(
          new TextCompare(),
          Resources.history1,
          Resources.history,
          Resources.Textedition_CompareTexts)
        .AddView(
          new TextSimilarity(),
          Resources.documents1,
          Resources.documents,
          Resources.Textedition_TextSimilarity);

      // ab hier: modul_panel_analytics

      GuiModuleBuilder.InitializePage(
          modul_panel_analytics,
          main_mainmenu_analytics,
          (o, e) => SetAnalyticModul(page_standardanalytics_frequency),
          page_standardanalytics_frequency,
          Resources.table_1,
          Resources.table,
          Resources.FrequncyAnalytics,
          Resources.FrequncyAnalytics_Describtion,
          "http://www.bitcutstudios.com/products/corpusexplorer/help/frequenzanalyse.html",
          // Handbook
          Resources.Help_Static_HandsOnLab,
          // Hand-on Lab
          Resources.Help_Static_YoutubeChannel,
          // Video
          Resources.Help_Static_AdditionalInformation) // Weitere Informationen
        .AddView(
          new FrequencyGrid(),
          Resources.sheet_calculate_1,
          Resources.sheet_calculate,
          Resources.FrequncyAnalytics_Table)
        .AddView(
          new FrequencyPivotGrid(),
          Resources.table_pivot_1,
          Resources.table_pivot,
          Resources.FrequncyAnalytics_PivotTable)
        .AddView(
          new CrossFrequencyGrid(),
          Resources.table_show_hide,
          Resources.table_show_hide1,
          Resources.Frequency_Cross)
        /* OBSOLETE
        .AddView(
          new LeftRightFrequency(),
          Resources.table_split_columns,
          Resources.table_split_columns1,
          Resources.Frequency_LeftRight)
        */
        .AddView(
          new CollocateFrequency(),
          Resources.table_split_columns,
          Resources.table_split_columns1,
          Resources.Frequency_LeftRight)
        .AddView(
          new FrequencySegments(),
          Resources.documents1,
          Resources.documents,
          Resources.FrequncyAnalytics_Distribution)
        .AddView(
          new KeywordGrid(),
          Resources.table_key1,
          Resources.table_key,
          Resources.Keywordanalitics)
        .AddView(
          new FrequencyOverTime(),
          Resources.charts_color_3d,
          Resources.charts_color,
          Resources.SpcialFunctions_TimeFrequency)
        .AddView(
          new CompareFrequency(),
          Resources.camera_find,
          Resources.camera_find1,
          Resources.FrequncyAnalytics_CompareSnapshot);

      GuiModuleBuilder.InitializePage(
          modul_panel_analytics,
          main_mainmenu_analytics,
          (o, e) => SetAnalyticModul(page_standardanalytics_ngram),
          page_standardanalytics_ngram,
          Resources.dashes_1,
          Resources.dashes,
          Resources.Phrases,
          Resources.Phrases_Describtion,
          "http://www.bitcutstudios.com/products/corpusexplorer/help/phrasen___muster.html",
          // Handbook
          Resources.Help_Static_HandsOnLab,
          // Hand-on Lab
          Resources.Help_Static_YoutubeChannel,
          // Video
          Resources.Help_Static_AdditionalInformation) // Weitere Informationen
        .AddView(
          new NGramGrid(),
          Resources.sheet_calculate_1,
          Resources.sheet_calculate,
          Resources.Phrases_NgramTable)
        .AddView(
          new NGramDiagram(),
          Resources.diagram,
          Resources.diagram1,
          Resources.Phrases_NgramMindmap)
        .AddView(
          new SkipgramGrid(),
          Resources.sheet_calculate_1,
          Resources.sheet_calculate,
          "Skipgram-Tabelle")
        .AddView(
          new PhrasesLaboratory(),
          Resources.component1,
          Resources.component,
          Resources.Phrases_StrucGrammar,
          true)
        .AddView(
          new CooccurrenceMultiwordGrid(),
          Resources.sheet_calculate_1,
          Resources.sheet_calculate,
          "Signifikante-NGramme")
        .AddView(
          new PhrasesGrid(),
          Resources.sheet_calculate_1,
          Resources.sheet_calculate,
          Resources.Phrases_PhraseTable)
        .AddView(
          new CompareNGram(),
          Resources.camera_find,
          Resources.camera_find1,
          Resources.Phrases_CompareSnapshot);

      GuiModuleBuilder.InitializePage(
          modul_panel_analytics,
          main_mainmenu_analytics,
          (o, e) => SetAnalyticModul(page_standardanalytics_cooccurrence),
          page_standardanalytics_cooccurrence,
          Resources.logo_firewire,
          Resources.logo_firewire_1,
          Resources.Cooccurrences,
          Resources.Cooccurrences_Describtion,
          "http://www.bitcutstudios.com/products/corpusexplorer/help/kookkurrenzen.html",
          // Handbook
          Resources.Help_Static_HandsOnLab,
          // Hand-on Lab
          Resources.Help_Static_YoutubeChannel,
          // Video
          Resources.Help_Static_AdditionalInformation) // Weitere Informationen
        .AddView(
          new CooccurrenceGridSearch(),
          Resources.find1,
          Resources.find,
          "Abfrage")
        .AddView(
          new CooccurrenceGrid(),
          Resources.sheet_calculate_1,
          Resources.sheet_calculate,
          Resources.Cooccurrences_Table)
        .AddView(
          new CooccurrenceTagPie(),
          Resources.cloud1,
          Resources.cloud2,
          Resources.Cooccurrences_Cloud)
        .AddView(
          new CooccurrenceOverlappingGrid(),
          Resources.select_table1,
          Resources.select_table,
          "Multi-Kookkurrenz")
        .AddView(
          new CooccurrenceDiversity(),
          Resources.table_split_rows_arrows,
          Resources.table_split_rows_arrows1,
          Resources.Cooccurrences_CompareTable)
        .AddView(
          new CooccurrenceDiagram(),
          Resources.diagram,
          Resources.diagram1,
          Resources.Cooccurrences_Mindmap)
        .AddView(
          new CooccurrenceOverTime(),
          Resources.charts_color_3d,
          Resources.charts_color,
          Resources.SpcialFunctions_TimeFrequency)
        .AddView(
          new CooccurrenceDiversityOverTime(),
          Resources.chart_column_2d_stacked_1001,
          Resources.chart_column_2d_stacked_100,
          "Zeitliche Kontrastierung")
        .AddView(
          new CompareCooccurrence(),
          Resources.camera_find,
          Resources.camera_find1,
          Resources.Cooccurrences_CompareSnapshot);

      GuiModuleBuilder.InitializePage(
          modul_panel_analytics,
          main_mainmenu_analytics,
          (o, e) => SetAnalyticModul(page_standardanalytics_disambiguation),
          page_standardanalytics_disambiguation,
          Resources.image_size_width,
          Resources.image_size_width_1,
          Resources.Disambigution,
          Resources.Disambigution_Describtion,
          "http://www.bitcutstudios.com/products/corpusexplorer/help/disambiguieren.html",
          // Handbook
          Resources.Help_Static_HandsOnLab,
          // Hand-on Lab
          Resources.Help_Static_YoutubeChannel,
          // Video
          Resources.Help_Static_AdditionalInformation) // Weitere Informationen
        .AddView(
          new DisambigutionGrid(),
          Resources.sheet_calculate_1,
          Resources.sheet_calculate,
          Resources.Disambigution_Table)
        .AddView(
          new DisambigutionTree(),
          Resources.tree,
          Resources.tree1,
          Resources.Disambigution_Tree)
        .AddView(
          new DisambigutionProfile(),
          Resources.colors,
          Resources.colors1,
          Resources.Disambigution_Profile);

      GuiModuleBuilder.InitializePage(
          modul_panel_analytics,
          main_mainmenu_analytics,
          (o, e) => SetAnalyticModul(page_styleMetrics),
          page_styleMetrics,
          Resources.thermometer_user,
          Resources.thermometer_user1,
          Resources.Stylemetrics,
          Resources.Stylemetrics_Describtion,
          "http://www.bitcutstudios.com/products/corpusexplorer/help/stilmetriken.html",
          // Handbook
          Resources.Help_Static_HandsOnLab,
          // Hand-on Lab
          Resources.Help_Static_YoutubeChannel,
          // Video
          Resources.Help_Static_AdditionalInformation) // Weitere Informationen
        .AddView(
          new CharacterNGramGrid(),
          Resources.sheet_calculate_1,
          Resources.sheet_calculate,
          Resources.NgramCharakter)
        .AddView(
          new HyphenPivotGrid(),
          Resources.table_pivot_1,
          Resources.table_pivot,
          Resources.HyphenFrequency)
        .AddView(
          new ReadingEasePivotGrid(),
          Resources.table_pivot_1,
          Resources.table_pivot,
          Resources.ComplexityReadingEase)
        .AddView(
          new VocabularyComplexityPivotGrid(),
          Resources.table_pivot_1,
          Resources.table_pivot,
          Resources.ComplexityVocabular)
                      .AddView(
                               new CompareBasedOnBurrowsDelta(),
                               Resources.table_pivot_1,
                               Resources.table_pivot,
                               "Burrows-Delta");

      /* DODO: Vorbereitet für Release
      .AddView(
        new CompareBasedOnCooccurrences(),
        Resources.logo_firewire,
        Resources.logo_firewire_1,
        "Kookkurrenz-Meta-Cluster")
      .AddView(
        new CompareBasedOnNgrams(),
        Resources.dashes_1,
        Resources.dashes,
        "NGram-Meta-Cluster");
    */

      GuiModuleBuilder.InitializePage(
          modul_panel_analytics,
          main_mainmenu_analytics,
          (o, e) => SetAnalyticModul(page_standardanalytics_weight),
          page_standardanalytics_weight,
          Resources.picture_flip_horizontal2,
          Resources.picture_flip_horizontal2_1,
          Resources.CorpusDistribution,
          Resources.CorpusDistribution_Describtion,
          "http://www.bitcutstudios.com/products/corpusexplorer/help/korpusverteilung.html",
          // Handbook
          Resources.Help_Static_HandsOnLab,
          // Hand-on Lab
          Resources.Help_Static_YoutubeChannel,
          // Video
          Resources.Help_Static_AdditionalInformation) // Weitere Informationen
        .AddView(
          new CorpusDistributionGrid(),
          Resources.sheet_calculate_1,
          Resources.sheet_calculate,
          Resources.CorpusDistribution_Table)
        .AddView(
          new CorpusDistributionPivotGrid(),
          Resources.table_pivot_1,
          Resources.table_pivot,
          Resources.CorpusDistribution_PivotTable)
        .AddView(
          new CorpusDistributionHeatmap(),
          Resources.colors,
          Resources.colors1,
          Resources.CorpusDistribution_Heatmap)
        .AddView(
          new EditMetadata(),
          Resources.tool_pencil,
          Resources.tool_pencil,
          Resources.CorpusDistribution_Edit)
        .AddView(
          new CorpusFiniteStateMachine(),
          Resources.diagram,
          Resources.diagram1,
          "Zustandsanalyse")
        .AddView(
          new CorpusDistributionOverTime(),
          Resources.charts_color_3d,
          Resources.charts_color,
          Resources.SpcialFunctions_TimeFrequency)
        .AddView(
          new CompareCorpusDistribution(),
          Resources.camera_find,
          Resources.camera_find1,
          Resources.CorpusDistribution_CompareSnapshot);

      GuiModuleBuilder.InitializePage(
          modul_panel_analytics,
          main_mainmenu_analytics,
          (o, e) => SetAnalyticModul(page_specialFeatures),
          page_specialFeatures,
          Resources.snipet_internet,
          Resources.snipet_internet1,
          Resources.SpcialFunctions,
          Resources.SpcialFunctions_Describtion,
          "http://www.bitcutstudios.com/products/corpusexplorer/help/spezialfunktionen.html",
          // Handbook
          Resources.Help_Static_HandsOnLab,
          // Hand-on Lab
          Resources.Help_Static_YoutubeChannel,
          // Video
          Resources.Help_Static_AdditionalInformation) // Weitere Informationen
        .AddView(
          new Html5DevLab(),
          Resources.html_page_gear1,
          Resources.html_page_gear,
          "HTML5-Labor")
        .AddView(
          new SentimentPivotGrid(),
          Resources.structure1,
          Resources.structure,
          "Sentiment Detection")
        /*
        .AddView(
          new NamedEntityGrid(),
          Resources.user_group1,
          Resources.user_group,
          "Named Entity Recognition")
        */
        .AddView(
          new ChatView(),
          Resources.chat,
          Resources.chat1,
          Resources.SpcialFunctions_ChatView)
        .AddView(
          new FrequencyMap(),
          Resources.place,
          Resources.place,
          "Karte")
        .AddView(
          new PaperLinguist(),
          Resources.print1,
          Resources.print,
          "PaperLinguist")
        .AddView(
          new TreeTaggerTrainerView(),
          Resources.database_access,
          Resources.database_access1,
          Resources.SpcialFunctions_TreeTaggerTrainer);

      // Notwendig um abschließend die 3rd-Party Views im Menü anzuzeigen.
      main_mainmenu_analytics.Items.Add(_addonMenuItem);

      // Ab hier werden die 3rd-Party Views geladen
      LoadGuiModules3rdParty();

      if (_addonMenuItem.Items.Count == 0)
      {
        _addonMenuItem.Visibility = ElementVisibility.Collapsed;
        betafunction_thirdpartyPanel.Visible = false;
      }

      // Lade Favoriten
      RefreshFavorites();
    }

    private void RefreshFavorites()
    {
      main_mainmenu_analytics_favorite.Items.Clear();

      main_mainmenu_analytics_favorite.Items.AddRange(FavoriteManager.PinnedItems);
      main_mainmenu_analytics_favorite.Items.Add(new RadMenuSeparatorItem());
      main_mainmenu_analytics_favorite.Items.AddRange(FavoriteManager.MostFrequentItems);

      settings_list_favorites_lock = true;
      settings_list_favorites.Items.Clear();
      settings_list_favorites.Items.AddRange(FavoriteManager.PinnedConfiguration);
      settings_list_favorites_lock = false;
    }

    private void LoadGuiModules3rdParty()
    {
      modul_panel_betafunction_thirdparty.Items.Clear();
      _addonMenuItem.Items.Clear();

      pages_3rdParty.AutoScroll = false;
      pages_3rdParty.HorizontalScroll.Visible = false;
      pages_3rdParty.VerticalScroll.Visible = false;

      foreach (var view in Configuration.AddonViews)
        try
        {
          // PAGE
          var page = new RadPageViewPage
          {
            BorderStyle = BorderStyle.None,
            Tag = view, // notwendig um die View zu aktualisieren            
            AutoScroll = false
          };
          page.HorizontalScroll.Visible = false;
          page.HorizontalScroll.Visible = false;

          var panel = new Addon3rdPartyPanel
          {
            Dock = DockStyle.Fill,
            Location = new Point(0, 0),
            Size = page.Size
          };
          page.Controls.Add(panel);
          view.Initialize(panel);
          pages_3rdParty.Pages.Add(page);

          // TILE
          var tile = new RadTileElement
          {
            Font = new Font("Segoe UI Light", 10),
            TextAlignment = ContentAlignment.BottomCenter,
            BackColor = Color.White,
            BorderColor = Color.DarkSeaGreen,
            ForeColor = Color.Black,
            TextWrap = true,
            Text = view.Label,
            ToolTipText = view.Label,
            Image = view.Image48X48,
            Tag = page // Notwendig, um die PAGE zu lokalisieren
          };
          tile.Click += (sender, args) => Processing.Invoke(
            Resources.ThirdPartyModules_Loading,
            () =>
            {
              SuspendLayout();
              ((IAddonView)((RadPageViewPage)((RadTileElement)sender).Tag).Tag).Refresh(Project.CurrentSelection);
              pages_3rdParty.SelectedPage = (RadPageViewPage)((RadTileElement)sender).Tag;
              pages_analytics.SelectedPage = page_analytics_thirdparty;
              pages_main.SelectedPage = page_analytics;
              InMemoryErrorConsole.TrackPageView($"page_thirdparty_{pages_3rdParty.Name}");
              ResumeLayout();
            });

          modul_panel_betafunction_thirdparty.Items.Add(tile);

          // MENU
          var item = new RadMenuItem
          {
            Text = view.Label,
            Image = view.Image24X24,
            TextImageRelation = TextImageRelation.ImageBeforeText,
            Tag = page // Notwendig, um die PAGE zu lokalisieren
          };
          item.Click += (sender, args) => Processing.Invoke(
            Resources.ThirdPartyModules_Loading,
            () =>
            {
              SuspendLayout();
              ((IAddonView)((RadPageViewPage)((RadMenuItem)sender).Tag).Tag).Refresh(Project.CurrentSelection);
              pages_3rdParty.SelectedPage = (RadPageViewPage)((RadMenuItem)sender).Tag;
              pages_analytics.SelectedPage = page_analytics_thirdparty;
              pages_main.SelectedPage = page_analytics;
              InMemoryErrorConsole.TrackPageView($"page_thirdparty_{pages_3rdParty.Name}");
              ResumeLayout();
            });

          _addonMenuItem.Items.Add(item);
        }
        catch (Exception ex)
        {
          InMemoryErrorConsole.Log(ex);
        }
    }

    private void LoadSettings()
    {
      Configuration.GetSetting("PC-Poolraum?", false);

      var settings = Configuration.GetSettings();

      var store = new RadPropertyStore();
      foreach (var x in settings)
        try
        {
          var item = new PropertyStoreItem(x.Value.GetType(),
            x.Key,
            x.Value ?? Activator.CreateInstance(x.Value.GetType()));

          store.Add(item);
        }
        catch
        {
          // ignore
        }

      property_meta.SelectedObject = store;
    }

    /// <summary>
    ///   The main_mainmenu_analytics_ click.
    /// </summary>
    /// <param name="sender">
    ///   The sender.
    /// </param>
    /// <param name="e">
    ///   The e.
    /// </param>
    private void main_mainmenu_analytics_Click(object sender, EventArgs e)
    {
      SetPageAnalytics(page_analytics_start);
    }

    /// <summary>
    ///   The main_mainmenu_corpus_ click.
    /// </summary>
    /// <param name="sender">
    ///   The sender.
    /// </param>
    /// <param name="e">
    ///   The e.
    /// </param>
    private void main_mainmenu_corpus_Click(object sender, EventArgs e)
    {
      SetPageCorpora(page_corpus_start);
    }

    /// <summary>
    ///   The main_mainmenu_exit_ click.
    /// </summary>
    /// <param name="sender">
    ///   The sender.
    /// </param>
    /// <param name="e">
    ///   The e.
    /// </param>
    private void main_mainmenu_exit_Click(object sender, EventArgs e)
    {
      if (_terminal.HasProjectStoredToHarddisk)
        _terminal.ProjectSave();
      Close();
    }

    /// <summary>
    ///   The main_mainmenu_home_ click.
    /// </summary>
    /// <param name="sender">
    ///   The sender.
    /// </param>
    /// <param name="e">
    ///   The e.
    /// </param>
    private void main_mainmenu_home_Click(object sender, EventArgs e)
    {
      SetPageMain(page_welcome);
    }

    /// <summary>
    ///   The main_mainmenu_project_load_ click.
    /// </summary>
    /// <param name="sender">
    ///   The sender.
    /// </param>
    /// <param name="e">
    ///   The e.
    /// </param>
    private void main_mainmenu_project_load_Click(object sender, EventArgs e)
    {
      var ofd = new OpenFileDialog
      {
        CheckFileExists = true,
        CheckPathExists = true,
        InitialDirectory = Configuration.MyProjects,
        Filter = Resources.FileExtension_PROJ5
      };
      if (ofd.ShowDialog() != DialogResult.OK)
        return;
      ProjectLoad(ofd.FileName);
    }

    /// <summary>
    ///   The main_mainmenu_project_new_ click.
    /// </summary>
    /// <param name="sender">
    ///   The sender.
    /// </param>
    /// <param name="e">
    ///   The e.
    /// </param>
    private void main_mainmenu_project_new_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show(
            Resources.Project_CreateNew,
            Resources.Project_CreateNewHead,
            MessageBoxButtons.YesNo) != DialogResult.Yes)
        return;
      if (_terminal.HasProjectStoredToHarddisk)
        _terminal.ProjectSave();
      ProjectNew();

      page_corpus_start_quickinfo_corpora.Value = "0";
      page_corpus_start_quickinfo_layers.Value = "0";
      page_corpus_start_quickinfo_texts.Value = "0";
      page_corpus_start_quickinfo_tokens.Value = "0";

      page_welcome_btn_projectname.ShowCheckmark = false;
      page_welcome_btn_analytics.ShowCheckmark = false;
      page_welcome_btn_corpus.ShowCheckmark = false;
      page_welcome_btn_snapshot.ShowCheckmark = false;

      Settings_ReLoad();
    }

    /// <summary>
    ///   The main_mainmenu_project_save_ click.
    /// </summary>
    /// <param name="sender">
    ///   The sender.
    /// </param>
    /// <param name="e">
    ///   The e.
    /// </param>
    private void main_mainmenu_project_save_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(_terminal.ProjectPath))
      {
        if (string.IsNullOrEmpty(_terminal.Project.Displayname))
          main_mainmenu_project_saveas_Click(sender, e);
        else
          _terminal.ProjectSave(Path.Combine(Configuration.MyProjects, _terminal.Project.Displayname + ".proj5"));
      }
      else
      {
        _terminal.ProjectSave();
      }
    }

    private void main_mainmenu_project_saveas_Click(object sender, EventArgs e)
    {
      var sfd = new SaveFileDialog
      {
        Filter = "CorpusExplorer-Projekt (*.proj5)|*.proj5",
        CheckPathExists = true
      };

      if (sfd.ShowDialog() != DialogResult.OK)
        return;
      _terminal.ProjectSave(sfd.FileName);
    }

    private void main_mainmenu_project_settings_Click(object sender, EventArgs e)
    {
      SetPageMain(page_settings);
    }

    private void main_mainmenu_snapshot_availabel_item_Click(object sender, EventArgs eventArgs)
    {
      var rmi = sender as RadMenuItem;
      var sel = rmi?.Tag as Selection;
      if (sel == null)
        return;

      Project.CurrentSelection = sel;
      Selection_ReLoad();
    }

    /// <summary>
    ///   The main_mainmenu_snapshot_ click.
    /// </summary>
    /// <param name="sender">
    ///   The sender.
    /// </param>
    /// <param name="e">
    ///   The e.
    /// </param>
    private void main_mainmenu_snapshot_Click(object sender, EventArgs e)
    {
      SetPageSnapshot(page_snapshot_home);
    }

    private void page_analytics_snapshot_btn_snapshot_add_individual_Click(object sender, EventArgs e)
    {
      SelectionEdit(null, null, true);
    }

    private void page_analytics_snapshot_btn_snapshot_add_metasplit_Click(object sender, EventArgs e)
    {
      SelectionEditAddMetasplit();
    }

    private void page_analytics_snapshot_btn_snapshot_add_random_Click(object sender, EventArgs e)
    {
      SelectionEditAddRandom();
    }

    private void page_analytics_snapshot_btn_snapshot_addsub_Click(object sender, EventArgs e)
    {
      SelectionEdit(Project.CurrentSelection, null, true);
    }

    private void page_analytics_snapshot_btn_snapshot_clonedetection_Click(object sender, EventArgs e)
    {
      var form = new CloneDetectionAlgorithm();
      if (form.ShowDialog() != DialogResult.OK)
        return;

      Processing.Invoke(
        "Suche nach bösen Klonen...",
        () =>
        {
          switch (form.SelectedOption)
          {
            case 1:
              var vmSHA = new DocumentCloneDetectionViewModel
              {
                Selection = Project.CurrentSelection,
                UseSpeedDetection = true
              };
              vmSHA.Execute();
              vmSHA.GenerateCleanSelection();
              break;
            case 2:
              var vmVF = new DocumentCloneDetectionViewModel
              {
                Selection = Project.CurrentSelection,
                UseSpeedDetection = false
              };
              vmVF.Execute();
              vmVF.GenerateCleanSelection();
              break;
            case 3:
              var vmFUZ = new DocumentFuzzyCloneDetectionViewModel
              {
                Selection = Project.CurrentSelection
              };
              vmFUZ.Execute();
              vmFUZ.GenerateCleanSelection();
              break;
          }
        });
    }

    private void page_analytics_snapshot_btn_snapshot_diff_Click(object sender, EventArgs e)
    {
      var selectionB = page_analytics_snapshot_btn_snapshot_settheory_GetSelectionB(
        "Schnappschuss Gemeinsamkeiten",
        "Der neu erstellte Schnappschuss enthält nur die Unterschiede des gewählten und des aktuellen Schnappschusses.");
      if (selectionB == null)
        return;

      var displayName = AskForSelectionDisplayname();
      if (string.IsNullOrEmpty(displayName))
        return;

      Project.CurrentSelection.JoinOuter(selectionB, displayName);
    }

    private void page_analytics_snapshot_btn_snapshot_edit_Click(object sender, EventArgs e)
    {
      SelectionEdit(null, Project.CurrentSelection, true, predefineDisplayname: Project.CurrentSelection.Displayname);
    }

    private void page_analytics_snapshot_btn_snapshot_export_Click(object sender, EventArgs e)
    {
      ExportSelectionAsCorpus(Project.CurrentSelection);
    }

    private static void ExportSelectionAsCorpus(Selection selection)
    {
      var dic = Configuration.AddonExporters.ToArray();
      var sfd = new SaveFileDialog
      {
        CheckPathExists = true,
        Filter = string.Join("|", dic.Select(x => x.Key))
      };
      if (sfd.ShowDialog() != DialogResult.OK)
        return;

      var exporter = dic[sfd.FilterIndex - 1].Value;

      Processing.Invoke(Resources.GutDingWillWeileHaben, () => exporter.Export(selection, sfd.FileName));
    }

    private void page_analytics_snapshot_btn_snapshot_invert_Click(object sender, EventArgs e)
    {
      if (
        MessageBox.Show(
          string.Format(
            Resources.Snapshot_CreateInvertSnapshot,
            Project.CurrentSelection.Displayname),
          Resources.Snapshot_CreateInvertSnapshotHead,
          MessageBoxButtons.YesNo,
          MessageBoxIcon.Question) != DialogResult.Yes)
        return;

      if (Project.CurrentSelection.Queries != null && Project.CurrentSelection.Queries.Any())
      {
        var queries = new List<AbstractFilterQuery>();

        foreach (
          var nquery in Project.CurrentSelection.Queries.Select(query => query.Clone()).OfType<AbstractFilterQuery>())
        {
          nquery.Inverse = !nquery.Inverse;
          queries.Add(nquery);
        }

        SelectionEdit(
          null,
          null,
          false,
          queries,
          Resources.Snapshot_CreateInvertSnapshotExtension + Project.CurrentSelection.Displayname);
      }
      else
      {
        var parent = Project.CurrentSelection.GetParentSelection();
        if (parent == null)
          return;

        var dont = new HashSet<Guid>(Project.CurrentSelection.DocumentGuids);
        var sele = parent.DocumentGuids.Where(dsel => !dont.Contains(dsel));
        var name = Resources.Snapshot_CreateInvertSnapshotExtension + Project.CurrentSelection.Displayname;

        parent.Create(sele, name);
        Selection_ReLoad();
      }
    }

    private void page_analytics_snapshot_btn_snapshot_join_Click(object sender, EventArgs e)
    {
      var selectionB = page_analytics_snapshot_btn_snapshot_settheory_GetSelectionB(
        "Schnappschüsse vereinigen",
        "Fügen Sie dem aktuellen Schnappschuss, die Texte aus dem gewählten Schnappschuss, hinzu.");
      if (selectionB == null)
        return;

      var displayName = AskForSelectionDisplayname();
      if (string.IsNullOrEmpty(displayName))
        return;

      Project.CurrentSelection.JoinFull(selectionB, displayName);
    }

    private void page_analytics_snapshot_btn_snapshot_load_Click(object sender, EventArgs e)
    {
      var ofd = new OpenFileDialog
      {
        CheckFileExists = true,
        Filter = _snapshotFileExtension
      };
      if (ofd.ShowDialog() != DialogResult.OK)
        return;

      var form = new SimpleTextInput(
        Resources.SchnappschussErstellen,
        Resources.GebenSieDemNeuenSchnappschussEinenNamen,
        Resources.camera,
        Resources.NameHierEintragen);
      if (form.ShowDialog() != DialogResult.OK)
        return;

      var queries = FileIO.ReadLines(
          ofd.FileName,
          Configuration.Encoding,
          stringSplitOptions: StringSplitOptions.RemoveEmptyEntries)?
        .Select(QueryParser.Parse)
        .ToArray();

      if (queries == null)
      {
        MessageBox.Show(
          Resources.ErrorFileFileReading,
          Resources.Dateifehler,
          MessageBoxButtons.OK,
          MessageBoxIcon.Stop);
        return;
      }

      Project.CreateSelection(queries, form.Result);
    }

    private void page_analytics_snapshot_btn_snapshot_mask_individual_Click(object sender, EventArgs e)
    {
      SelectionEdit(Project.CurrentSelection, null, true);
    }

    private void page_analytics_snapshot_btn_snapshot_mask_metasplit_Click(object sender, EventArgs e)
    {
      SelectionEditAddMetasplit(Project.CurrentSelection);
    }

    private void page_analytics_snapshot_btn_snapshot_mask_random_Click(object sender, EventArgs e)
    {
      SelectionEditAddRandom(Project.CurrentSelection);
    }

    private void page_analytics_snapshot_btn_snapshot_reduceBfromA_Click(object sender, EventArgs e)
    {
      var selectionB = page_analytics_snapshot_btn_snapshot_settheory_GetSelectionB(
        "Schnappschuss abziehen",
        "Wählen Sie einen Schnappschuss aus, den Sie vom aktuellen Schnappschuss abziehen möchten.");
      if (selectionB == null)
        return;

      var displayName = AskForSelectionDisplayname();
      if (string.IsNullOrEmpty(displayName))
        return;

      Project.CurrentSelection.JoinLeft(selectionB, displayName);
    }

    private void page_analytics_snapshot_btn_snapshot_remove_Click(object sender, EventArgs e)
    {
      var selection = Project.CurrentSelection;
      var queue =
        new Queue<KeyValuePair<Selection, Selection>>(
          Project.Selections.Select(x => new KeyValuePair<Selection, Selection>(null, x)));

      while (queue.Count > 0)
      {
        var entry = queue.Dequeue();
        if (entry.Value.Equals(selection))
        {
          if (entry.Key == null)
            Project.RemoveSelection(selection);
          else
            entry.Key.RemoveSelection(selection);
          break;
        }

        foreach (var subSelection in entry.Value.SubSelections)
          queue.Enqueue(new KeyValuePair<Selection, Selection>(entry.Value, subSelection));
      }

      Selection_ReLoad();
    }

    private void page_analytics_snapshot_btn_snapshot_save_Click(object sender, EventArgs e)
    {
      var sfd = new SaveFileDialog
      {
        CheckPathExists = true,
        Filter = _snapshotFileExtension
      };
      if (sfd.ShowDialog() != DialogResult.OK)
        return;

      var model = Project.CurrentSelection.Queries.Where(query => !(query is FilterQueryCorpusComplete)).ToArray();
      Serializer.SerializeXmlWithDotNet(model, sfd.FileName.Replace(".ceusd", "2.ceusd"));
    }

    private Selection page_analytics_snapshot_btn_snapshot_settheory_GetSelectionB(string head, string describtion)
    {
      var available = Project.SelectionsRecursive;
      var selections =
        available.Where(sel => sel.Guid != Project.CurrentSelection.Guid)
          .ToDictionary(selection => selection.Guid, selection => selection.Displayname);

      var form = new SetTheorySelectSnapshot(head, describtion, selections);
      form.ShowDialog();

      return form.DialogResult == DialogResult.OK
        ? available.FirstOrDefault(selection => selection.Guid == form.Result)
        : null;
    }

    private void page_analytics_snapshot_btn_snapshot_union_Click(object sender, EventArgs e)
    {
      var selectionB = page_analytics_snapshot_btn_snapshot_settheory_GetSelectionB(
        "Schnappschuss Gemeinsamkeiten",
        "Der neu erstellte Schnappschuss enthält nur die Gemeinsamkeiten des gewählten und des aktuellen Schnappschusses.");
      if (selectionB == null)
        return;

      var displayName = AskForSelectionDisplayname();
      if (string.IsNullOrEmpty(displayName))
        return;

      Project.CurrentSelection.JoinInner(selectionB, displayName);
    }

    [NamedSynchronizedLock("Snapshot")]
    private void page_analytics_snapshot_list_snapshots_SelectedNodeChanged(object sender, RadTreeViewEventArgs e)
    {
      if (!(e.Node?.Tag is Selection))
        return;

      Project.CurrentSelection = (Selection)e.Node.Tag;
      Selection_ReLoad();
    }

    private void page_snapshot_context_edit_Click(object sender, EventArgs e)
    {
      page_analytics_snapshot_btn_snapshot_edit_Click(sender, e);
    }

    private void page_snapshot_context_remove_Click(object sender, EventArgs e)
    {
      page_analytics_snapshot_btn_snapshot_remove_Click(sender, e);
    }

    private void page_snapshot_context_sub_Click(object sender, EventArgs e)
    {
      page_analytics_snapshot_btn_snapshot_addsub_Click(sender, e);
    }

    private void page_welcome_btn_projectname_Click(object sender, EventArgs e)
    {
      ProjectRename();
    }

    private void ParseArguments(string[] args)
    {
      if (args == null || args.Length == 0)
        return;

      var files =
        (from s in args where s.StartsWith("file:///") select HttpUtility.UrlDecode(s.Replace("file:///", "")))
        .ToArray();

      var proj = files.FirstOrDefault(file => file.ToLower().EndsWith(".proj5"));
      if (!string.IsNullOrEmpty(proj))
      {
        ProjectLoad(proj);
        return;
      }

      ProjectNew();
      foreach (var corpus in files.Where(x => x.ToLower().EndsWith(".cec5")))
        AddCorpusToProject(CorpusAdapterSingleFile.Create(corpus), false);

      foreach (var corpus in files.Where(x => x.ToLower().EndsWith(".cec6")))
        AddCorpusToProject(CorpusAdapterWriteDirect.Create(corpus), false);

      ReloadAll();

      foreach (var setting in files.Where(x => x.ToLower().EndsWith(".cesettings")))
      {
        var lines = FileIO.ReadLines(setting);
        foreach (var line in lines)
        {
          if (string.IsNullOrEmpty(line))
            continue;

          var idx = line.IndexOf(":>", StringComparison.Ordinal);
          if (idx == -1)
            continue;

          var key = line.Substring(0, idx).Trim();
          var val = line.Substring(idx + 2).Trim();

          Configuration.SetSetting(key, val);
        }
      }
    }

    private void ProjectLoad(string path)
    {
      _terminal.ProjectLoad(path);
      Project = _terminal.Project;
      Project.SelectionCreated += ProjectModelChanges;
      Project.SelectionChanged += CurrentSelectionChanged;
      Project.SelectAllNew();
      Corpora_ReLoad();
      Selection_ReLoad();
      Settings_ReLoad();
      page_welcome_btn_projectname.ShowCheckmark = true;
    }

    private void ProjectModelChanges()
    {
      Selection_ReLoad();
    }

    private void ProjectNew()
    {
      _terminal.ProjectNew();
      Project = _terminal.Project;
      Project.SelectionCreated += ProjectModelChanges;
      Project.SelectionChanged += CurrentSelectionChanged;
    }

    private bool ProjectRename()
    {
      var form = new SimpleTextInput(
        Resources.ProjectName,
        Resources.ProjectNameSet,
        Resources.rename,
        Resources.ProjectNameSetHead);
      if (form.ShowDialog() != DialogResult.OK)
        return false;
      if (string.IsNullOrEmpty(form.Result))
        return false;
      Project.Displayname = form.Result;
      page_welcome_btn_projectname.ShowCheckmark = true;
      return true;
    }

    private void RealoadInsightSettings()
    {
      var insightEnable = InsightController.IsInsightActive;
      settings_insight_enable.Visible = !insightEnable;
      settings_insight_disable.Visible = insightEnable;
      settings_insight_renew.Visible = insightEnable;

      settings_insigt_id.Text = insightEnable ? InsightController.InsightId : null;
    }

    private void RefreshWebCrawlers()
    {
      Processing.Invoke("Durchsuche Ordner \"Meine Datenquellen\"...", () =>
      {
        Configuration.Reload3rdPartyAddons();
        corpus_online_crawler_list.Items.Clear();
        foreach (var c in Configuration.AddonCrawlers)
          corpus_online_crawler_list.Items.Add(new ListViewDataItem(c.DisplayName) { Tag = c });
      });
    }

    private void ScrapDocumentProcessing(ConcurrentQueue<Dictionary<string, object>> docs)
    {
      var formScraper = new ShowScraperResults(docs);
      if (formScraper.ShowDialog() != DialogResult.OK)
        return;

      var formTagger = new SelectTagger(new ClassicTreeTagger { LanguageSelected = Resources.German });
      if (formTagger.ShowDialog() != DialogResult.OK)
        return;

      var formName = new SimpleTextInput(
        Resources.Dashboard_EnterCorpusNameHead,
        Resources.Dashboard_EnterCorpusNameDescribtion,
        Resources.cabinet,
        Resources.Dashboard_EnterCorpusNameNullText);
      if (formName.ShowDialog() != DialogResult.OK)
        return;

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

            AddCorpusToProject(corpus, true);
            corpus.Save(Path.Combine(Configuration.MyCorpora, formName.Result.EnsureFileName()));
          }
        });
    }

    private void ScrapDocumentsToCorpus(ConcurrentQueue<Dictionary<string, object>> docs)
    {
      Processing.Invoke(
        "Bereinige Dokumente...",
        () =>
        {
          var cleaner1 = new StandardCleanup { Input = docs };
          cleaner1.Execute();
          var cleaner2 = new RegexXmlMarkupCleanup { Input = cleaner1.Output };
          cleaner2.Execute();
          ScrapDocumentProcessing(cleaner2.Output);
        });
    }

    private void Selection_ReLoad()
    {
      page_welcome_btn_analytics.ShowCheckmark = page_welcome_btn_snapshot.ShowCheckmark = Project.Selections.Any();

      // Bereinigen
      page_analytics_snapshot_list_snapshots.Nodes.Clear();
      main_mainmenu_snapshot_availabel.Items.Clear();

      foreach (var selection in Project.Selections)
      {
        var font = new Font(
          page_analytics_snapshot_list_snapshots.Font,
          Project.CurrentSelection.Equals(selection)
            ? FontStyle.Bold
            : FontStyle.Regular);

        //page_analytics_snapshot_list_snapshots 
        var node = new RadTreeNode(selection.Displayname)
        {
          Tag = selection,
          Font = font
        };
        page_analytics_snapshot_list_snapshots.Nodes.Add(Selection_ReLoad(node, selection));

        //main_mainmenu_snapshot_availabel
        var item = new RadMenuItem(selection.Displayname)
        {
          Tag = selection,
          Font = font
        };
        item.Click += main_mainmenu_snapshot_availabel_item_Click;
        main_mainmenu_snapshot_availabel.Items.Add(Selection_ReLoad(item, selection));
      }

      if (Project.CurrentSelection == null)
        return;

      // QuickInfo
      var vm = new QuickInfoViewModel { Selection = Project.CurrentSelection };
      vm.Execute();

      page_snapshot_start_quickinfo_corpora.Value = vm.CounterCorpora.ToString();
      page_snapshot_start_quickinfo_layers.Value = vm.CounterLayers.ToString();
      page_snapshot_start_quickinfo_texts.Value = vm.CounterDocuments.ToString();
      page_snapshot_start_quickinfo_tokens.Value = string.Format(
        Resources.DashboardPatternNumber,
        vm.CounterTokens / 1000000.0d);

      InMemoryErrorConsole.TrackEvent("CurrentSelectionChanged", metrics: new Dictionary<string, double>
      {
        {"cnt_CORPORA", vm.CounterCorpora},
        {"cnt_LAYERS", vm.CounterLayers},
        {"cnt_DOCUMENTS", vm.CounterDocuments},
        {"cnt_TOKENS", vm.CounterTokens}
      });

      page_analytics_snapshot_list_snapshots.ExpandAll();
    }

    private RadMenuItem Selection_ReLoad(RadMenuItem node, Selection selection)
    {
      foreach (var sub in selection.SubSelections)
      {
        var tn = new RadMenuItem(sub.Displayname)
        {
          Tag = sub,
          Font =
            new Font(
              page_analytics_snapshot_list_snapshots.Font,
              Project.CurrentSelection.Equals(sub)
                ? FontStyle.Bold
                : FontStyle.Regular)
        };
        tn.Click += main_mainmenu_snapshot_availabel_item_Click;
        node.Items.Add(Selection_ReLoad(tn, sub));
      }

      return node;
    }

    private RadTreeNode Selection_ReLoad(RadTreeNode node, Selection selection)
    {
      foreach (var sub in selection.SubSelections)
      {
        var tn = new RadTreeNode(sub.Displayname)
        {
          Tag = sub,
          Font =
            new Font(
              page_analytics_snapshot_list_snapshots.Font,
              Project.CurrentSelection.Equals(sub)
                ? FontStyle.Bold
                : FontStyle.Regular)
        };
        node.Nodes.Add(Selection_ReLoad(tn, sub));
      }

      return node;
    }

    private Selection SelectionBuildFromQueries()
    {
      if (_selectionEditParentSelection != null)
        return Project.CreateSelection(
          _selectionEditQueries,
          snapshot_edit_displayname.Text,
          _selectionEditParentSelection);
      if (_selectionEditCurrentSelection != null)
      {
        if (
          MessageBox.Show(
            Resources.Dashboard_ChangeSnapshotWarning,
            Resources.Dashboard_ChangeSnapshotWarningHead,
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning) != DialogResult.Yes)
          return null;
        _selectionEditCurrentSelection.Reselect(_selectionEditQueries);
      }
      else
      {
        return Project.CreateSelection(_selectionEditQueries, snapshot_edit_displayname.Text);
      }

      return null;
    }

    private void SelectionCheck(Selection selection)
    {
      if (selection != null &&
          selection.CountDocuments > 0)
      {
        Selection_ReLoad();
        return;
      }

      MessageBox.Show(
        Resources.Dashboard_SnapshotErrorNoDocuments,
        Resources.Dashboard_SnapshotErrorNoDocumentsHead,
        MessageBoxButtons.OK,
        MessageBoxIcon.Information);
      Project.RemoveSelection(selection);
      Selection_ReLoad();
    }

    /// <summary>
    ///   Funktion die aufgerufen wird um eine Selection mittels ResultQueries zu erstellen.
    /// </summary>
    /// <param name="parentSelection">Übergeordnete Selection (falls gewünscht)</param>
    /// <param name="currentSelection">Zu bearbeitende Selection (wenn null wird eine neue Selection erstellt)</param>
    /// <param name="predefinedQueries">ResultQueries die für die neue Selection vordefiniert wurden (z. B. durch ein Modul)</param>
    /// <param name="predefineDisplayname">Wert der als Anzeigename verwendet wird</param>
    private void SelectionEdit(
      Selection parentSelection,
      Selection currentSelection,
      bool showEditor,
      IEnumerable<AbstractFilterQuery> predefinedQueries = null,
      string predefineDisplayname = null)
    {
      _selectionEditCurrentSelection = currentSelection;
      _selectionEditParentSelection = parentSelection;
      if (predefinedQueries == null)
        if (currentSelection == null)
        {
          _selectionEditQueries = new List<AbstractFilterQuery>();
        }
        else
        {
          if (currentSelection.Queries == null)
          {
            MessageBox.Show(
              Resources.Dashboard_SelectionEdit_Error,
              Resources.Dashboard_SelectionEdit_ErrorHead,
              MessageBoxButtons.OK,
              MessageBoxIcon.Stop);
            return;
          }

          _selectionEditQueries = new List<AbstractFilterQuery>(currentSelection.Queries);
        }
      else
        _selectionEditQueries = predefinedQueries.ToList();

      SelectionReloadQueries();
      snapshot_edit_displayname.Text = predefineDisplayname;

      if (!showEditor)
      {
        snapshot_edit_ok_Click(null, null);
        return;
      }

      pages_snapshot.SelectedPage = page_snapshot_edit;
      pages_main.SelectedPage = page_snapshot;

      InMemoryErrorConsole.TrackPageView($"page_snapshot_{page_snapshot_edit.Name}");
    }

    private void SelectionEditAddMetasplit(Selection parentSelection = null)
    {
      var form = new AddMetasplitSnapshot(Project, parentSelection ?? Project.CurrentSelection);
      if (form.ShowDialog() != DialogResult.OK)
        return;
      Project.CurrentSelection = form.Result;
      Selection_ReLoad();
    }

    private void SelectionEditAddRandom(Selection parentSelection = null)
    {
      var form = new AddRandomSnapshot(Project, parentSelection ?? Project.CurrentSelection);
      if (form.ShowDialog() != DialogResult.OK)
        return;
      Project.CurrentSelection = form.Selection;
      Selection_ReLoad();
    }

    private void SelectionReloadQueries()
    {
      var selection = _selectionEditParentSelection ?? (_selectionEditCurrentSelection ?? Project.SelectAll);

      _snapshotEditDisposingContainer.Dispose<AbstractSnapshotControl>(
        x =>
        {
          snapshot_edit_queries.Controls.Remove(x);
          x.Dispose();
        });

      foreach (var query in _selectionEditQueries)
      {
        AbstractSnapshotControl control = null;

        if (query is AbstractFilterQueryMeta)
          control = new MetadataSnapshotControl(selection, query as AbstractFilterQueryMeta);
        if (query is AbstractFilterQuerySingleLayer ||
            query is FilterQuerySingleLayerExactPhrase)
          control = new FulltextSnapshotControl(selection, query);
        if (query is FilterQueryCorpusComplete)
          control = new FullCorpusSnapshotControl(selection, query as FilterQueryCorpusComplete);

        if (control == null)
          continue;
        control.Dock = DockStyle.Top;
        control.QueryRemove += ControlOnQueryRemove;
        snapshot_edit_queries.PanelContainer.Controls.Add(control);
        _snapshotEditDisposingContainer.Add(control);
      }
    }

    private void SelectionSaveQueries()
    {
      _selectionEditQueries =
        snapshot_edit_queries.PanelContainer.Controls.OfType<AbstractSnapshotControl>()
          .Select(asc => asc.Query)
          .ToList();
    }

    /// <summary>
    ///   The set page analytice standard.
    /// </summary>
    /// <param name="page">
    ///   The page.
    /// </param>
    private void SetAnalyticModul(RadPageViewPage page)
    {
      // Redirect bei leerer Projektmappe
      if (Project.CurrentSelection == null ||
          Project.CurrentSelection.CountCorpora == 0)
      {
        MessageBox.Show(Resources.Msg_YouNeedToLoadACorpus);
        SetPageCorpora(page_corpus_start);
        return;
      }

      pages_standardanalytics.SelectedPage = page;

      var prototype = page.Controls[0] as GuiModulePrototype;
      prototype?.StartModule();

      pages_analytics.SelectedPage = page_analytics_view;
      pages_main.SelectedPage = page_analytics;

      InMemoryErrorConsole.TrackPageView($"page_analytics_{page.Name}");
    }

    /// <summary>
    ///   The set page analytice.
    /// </summary>
    /// <param name="page">
    ///   The page.
    /// </param>
    private void SetPageAnalytics(RadPageViewPage page)
    {
      if (page_analytics == pages_main.SelectedPage &&
          pages_analytics.SelectedPage == page)
        return;

      // Redirect bei leerer Projektmappe
      if (Project.CurrentSelection == null ||
          Project.CurrentSelection.CountCorpora == 0)
      {
        MessageBox.Show(Resources.Msg_YouNeedToLoadACorpus);
        SetPageCorpora(page_corpus_start);
        return;
      }

      pages_analytics.SelectedPage = page;
      pages_main.SelectedPage = page_analytics;

      InMemoryErrorConsole.TrackPageView($"page_analytics_{page.Name}");
    }

    /// <summary>
    ///   The set page corpora.
    /// </summary>
    /// <param name="page">
    ///   The page.
    /// </param>
    private void SetPageCorpora(RadPageViewPage page)
    {
      if (page_corpus == pages_main.SelectedPage &&
          pages_corpora.SelectedPage == page)
        return;

      pages_corpora.SelectedPage = page;
      pages_main.SelectedPage = page_corpus;
      InMemoryErrorConsole.TrackPageView($"page_corpus_{page.Name}");

      if (page_corpus_start == page)
        Corpus_LaodAvailabelCorpora();
    }

    /// <summary>
    ///   The set page main.
    /// </summary>
    /// <param name="page">
    ///   The page.
    /// </param>
    private void SetPageMain(RadPageViewPage page)
    {
      // ReSharper disable once RedundantCheckBeforeAssignment
      if (pages_main.SelectedPage == page)
        return;

      if (page == page_welcome)
        RefreshFavorites();

      pages_main.SelectedPage = page;
      InMemoryErrorConsole.TrackPageView($"page_main_{page.Name}");
    }

    private void SetPageSnapshot(RadPageViewPage page)
    {
      if (page_snapshot == pages_main.SelectedPage &&
          pages_snapshot.SelectedPage == page)
        return;

      // Redirect bei leerer Projektmappe
      if (Project.CurrentSelection == null ||
          Project.CurrentSelection.CountCorpora == 0)
      {
        MessageBox.Show(Resources.Msg_YouNeedToLoadACorpus);
        SetPageCorpora(page_corpus_start);
        return;
      }

      pages_snapshot.SelectedPage = page;
      SetPageMain(page_snapshot);
    }

    [NamedSynchronizedLock("Settings")]
    private void settings_drop_signifikanz_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
    {
      if (e.Position == -1)
        return;
      Configuration.SetSignificance(_significanceMessures[e.Position].Value);
    }

    [NamedSynchronizedLock("Settings")]
    private void settings_frequenz_min_ValueChanged(object sender, EventArgs e)
    {
      Configuration.MinimumFrequency = (int)settings_frequenz_min.Value;
    }

    [NamedSynchronizedLock("Settings")]
    private void Settings_Initialize()
    {
      _significanceMessures =
        Configuration.GetSideloadFeature<ISignificance>().ToDictionary(x => x.Label, x => x).ToArray();

      settings_drop_signifikanz.Items.Clear();
      foreach (var x in _significanceMessures)
        settings_drop_signifikanz.Items.Add(new RadListDataItem(x.Key, x.Value));
    }

    private void settings_insight_disable_Click(object sender, EventArgs e)
    {
      InsightController.SetInsightStatus(false);
      RealoadInsightSettings();
    }

    private void settings_insight_enable_Click(object sender, EventArgs e)
    {
      InsightController.SetInsightStatus(true);
      RealoadInsightSettings();
    }

    private void settings_insight_info_Click(object sender, EventArgs e)
    {
      Process.Start("https://notes.jan-oliver-ruediger.de/software/corpusexplorer-overview/telemetrie/");
    }

    private void settings_insight_renew_Click(object sender, EventArgs e)
    {
      InsightController.NewInstallationId();
      RealoadInsightSettings();
    }

    [NamedSynchronizedLock("Settings")]
    private void Settings_ReLoad()
    {
      settings_frequenz_min.Value = Configuration.MinimumFrequency >= settings_frequenz_min.Minimum
        ? Configuration.MinimumFrequency
        : settings_frequenz_min.Minimum;
      settings_signifikanz_min.Value = (decimal)Configuration.MinimumSignificance >= settings_signifikanz_min.Minimum
        ? (decimal)Configuration.MinimumSignificance
        : settings_signifikanz_min.Minimum;

      try
      {
        var type = Configuration.GetSignificanceType();
        for (var i = 0; i < _significanceMessures.Length; i++)
        {
          if (_significanceMessures[i].GetType() != type)
            continue;
          settings_drop_signifikanz.SelectedIndex = i;
        }
      }
      catch
      {
        // ignore
      }
    }

    [NamedSynchronizedLock("Settings")]
    private void settings_signifikanz_min_ValueChanged(object sender, EventArgs e)
    {
      Configuration.MinimumSignificance = (double)settings_signifikanz_min.Value;
    }

    private void settings_tool_additionalTagger_Click(object sender, EventArgs e)
    {
      var form = new AdditionalTagger();
      if (form.ShowDialog() != DialogResult.OK)
        return;

      foreach (var csel in Project.CorporaGuids)
      {
        var corpus = Project.GetCorpus(csel);
        form.Result.CorpusBuilder = corpus.GetCorpusBuilder();
        form.Result.Input.Enqueue(corpus);
        form.Result.Execute();
      }
    }

    private void settings_tool_eraseCache_Click(object sender, EventArgs e)
    {
      Configuration.Cache.Clear();
      MessageBox.Show(Resources.Dashboard_RamCleanup);
    }

    private void settings_tool_errorconsole_Click(object sender, EventArgs e)
    {
      try
      {
        var form = new ErrorConsole();
        form.ShowDialog();
      }
      catch
      {
        // ignore
      }
    }

    private void settings_tool_exportCorpus_Click(object sender, EventArgs e)
    {
      var ofd = new OpenFileDialog
      {
        Filter = Resources.FileExteions_CEC6_CEC5_and_PROJ5,
        CheckFileExists = true,
        Multiselect = false
      };

      if (ofd.ShowDialog() != DialogResult.OK)
        return;

      var hydra = ofd.FilterIndex == 1
        ? CorpusAdapterWriteDirect.Create(ofd.FileName)
        : ofd.FilterIndex == 2
          ? CorpusAdapterSingleFile.Create(ofd.FileName)
          : (IHydra)Project.Load(ofd.FileName);

      var dic = Configuration.AddonExporters.ToArray();
      var sfd = new SaveFileDialog
      {
        CheckPathExists = true,
        Filter = string.Join("|", dic.Select(x => x.Key))
      };
      if (sfd.ShowDialog() != DialogResult.OK)
        return;

      var exporter = dic[sfd.FilterIndex - 1].Value;

      Processing.Invoke(Resources.GutDingWillWeileHaben, () => exporter.Export(hydra, sfd.FileName));
    }

    private void settings_tool_mergeCorpora_Click(object sender, EventArgs e)
    {
      var ofd = new OpenFileDialog
      {
        Filter = Resources.FileExteions_CEC5,
        CheckFileExists = true,
        Multiselect = true
      };

      if (ofd.ShowDialog() != DialogResult.OK ||
          ofd.FileNames.Length < 2)
        return;

      var sfd = new SaveFileDialog
      {
        Filter = Resources.FileExteions_CEC6,
        CheckPathExists = true
      };

      if (sfd.ShowDialog() != DialogResult.OK)
        return;

      Processing.Invoke(
        Resources.GutDingWillWeileHaben,
        () =>
        {
          CorpusMerger.Merge(ofd.FileNames.Select(CorpusAdapterWriteDirect.Create), new CorpusBuilderWriteDirect())
            ?.Save(sfd.FileName);
        });
    }

    private void settings_tool_testCorpus_Click(object sender, EventArgs e)
    {
      var form = new GenerateValidationCorpus();
      form.ShowDialog();
    }

    private void settings_tool_totalReset_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show(
            "Diese Option setzt das komplette CorpusExplorer-Ökosystem zurück. Führen Sie diese Funktion nur aus, wenn es schwerwiegende Probleme mit dem CorpusExplorer gibt. Sind Sie sicher, dass Sie den CorpusExplorer zurücksetzen möchten?",
            "CorpusExplorer zurücksetzen?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
        return;

      try
      {
        File.Delete(Path.Combine(Configuration.AppPath, "update.info"));
      }
      catch
      {

      }

      try
      {
        Directory.Delete(Path.Combine(Configuration.AppPath, "XDependencies"), true);
      }
      catch
      {
        // ignore
      }

      MessageBox.Show("Der CorpusExplorer wird nun beendet. Bitte starten Sie den CorpusExplorer danach erneut.");
      Close();
    }

    private void settings_tool_xpath_Click(object sender, EventArgs e)
    {
      var browser = new XpathBrowser();
      browser.Show();
    }

    private void settings_upgrade_btn_Click(object sender, EventArgs e)
    {
      if (
        MessageBox.Show(
          Resources.Dashboard_CorpusUpgrade,
          Resources.Dashboard_CorpusUpgradeHead,
          MessageBoxButtons.YesNo,
          MessageBoxIcon.Question) != DialogResult.Yes)
        return;

      Processing.Invoke(
        "Upgrade alter Korpora wird durchgeführt...",
        () =>
        {
          var dirs = Directory.GetDirectories(Configuration.MyCorpora);
          foreach (var dir in dirs)
            try
            {
              Ce1CompatibilityControler.Upgrade(dir);
            }
            catch
            {
              // ignore
            }
        });
    }

    private void snapshot_edit_abort_Click(object sender, EventArgs e)
    {
      pages_snapshot.SelectedPage = page_snapshot_home;
    }

    private void snapshot_edit_dropdown_corpus_Click(object sender, EventArgs e)
    {
      SelectionSaveQueries();
      _selectionEditQueries.Add(new FilterQueryCorpusComplete());
      SelectionReloadQueries();
    }

    private void snapshot_edit_dropdown_fulltext_Click(object sender, EventArgs e)
    {
      SelectionSaveQueries();
      _selectionEditQueries.Add(new FilterQuerySingleLayerAnyMatch());
      SelectionReloadQueries();
    }

    private void snapshot_edit_dropdown_meta_Click(object sender, EventArgs e)
    {
      SelectionSaveQueries();
      _selectionEditQueries.Add(new FilterQueryMetaContains());
      SelectionReloadQueries();
    }

    private void snapshot_edit_ok_Click(object sender, EventArgs e)
    {
      SelectionSaveQueries();
      var selection = SelectionBuildFromQueries();
      if (selection != null)
        SelectionCheck(selection);
      pages_snapshot.SelectedPage = page_snapshot_home;
    }

    private bool settings_list_favorites_lock = false;

    private void settings_list_favorites_ItemCheckedChanged(object sender, ListViewItemEventArgs e)
    {
      if (settings_list_favorites_lock)
        return;
      settings_list_favorites_lock = true;

      FavoriteManager.PinnedConfiguration = settings_list_favorites.Items.ToArray();
      RefreshFavorites();

      settings_list_favorites_lock = false;
    }
  }
}