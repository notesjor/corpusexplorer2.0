using CorpusExplorer.Terminal.WinForm.Properties;
using CorpusExplorer.Terminal.WinForm.Controls.WinForm;

namespace CorpusExplorer.Terminal.WinForm.Forms.Dashboard
{
  partial class Dashboard
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (this.components != null))
      {
        this.components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
      this.pages_main = new Telerik.WinControls.UI.RadPageView();
      this.page_welcome = new Telerik.WinControls.UI.RadPageViewPage();
      this.helpPanel1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.HelpPanel();
      this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
      this.page_welcome_btn_projectname = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.RadButtonWithCheckmark();
      this.page_welcome_btn_corpus = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.RadButtonWithCheckmark();
      this.page_welcome_btn_snapshot = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.RadButtonWithCheckmark();
      this.page_welcome_btn_analytics = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.RadButtonWithCheckmark();
      this.header2 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.Header();
      this.header1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.Header();
      this.page_corpus = new Telerik.WinControls.UI.RadPageViewPage();
      this.pages_corpora = new Telerik.WinControls.UI.RadPageView();
      this.page_corpus_start = new Telerik.WinControls.UI.RadPageViewPage();
      this.radScrollablePanel3 = new Telerik.WinControls.UI.RadScrollablePanel();
      this.helpPanel2 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.HelpPanel();
      this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
      this.page_corpus_start_quickinfo_corpora = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.BigNumber();
      this.page_corpus_start_quickinfo_texts = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.BigNumber();
      this.page_corpus_start_quickinfo_layers = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.BigNumber();
      this.page_corpus_start_quickinfo_tokens = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.BigNumber();
      this.header4 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.Header();
      this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
      this.corpus_start_add = new Telerik.WinControls.UI.RadDropDownButton();
      this.corpus_start_local = new Telerik.WinControls.UI.RadButton();
      this.corpus_start_import = new Telerik.WinControls.UI.RadButton();
      this.corpus_start_online = new Telerik.WinControls.UI.RadButton();
      this.header3 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.Header();
      this.page_corpus_online = new Telerik.WinControls.UI.RadPageViewPage();
      this.radSplitContainer1 = new Telerik.WinControls.UI.RadSplitContainer();
      this.splitPanel1 = new Telerik.WinControls.UI.SplitPanel();
      this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
      this.corpus_online_crawler_list = new Telerik.WinControls.UI.RadListView();
      this.corpus_online_crawler_create = new Telerik.WinControls.UI.RadButton();
      this.splitPanel2 = new Telerik.WinControls.UI.SplitPanel();
      this.radGroupBox3 = new Telerik.WinControls.UI.RadGroupBox();
      this.corpus_online_crawler_queries = new Telerik.WinControls.UI.RadTextBox();
      this.radGroupBox5 = new Telerik.WinControls.UI.RadGroupBox();
      this.corpus_online_crawler_start_compile = new Telerik.WinControls.UI.RadCheckBox();
      this.corpus_online_crawler_start = new Telerik.WinControls.UI.RadButton();
      this.header5 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.Header();
      this.page_snapshot = new Telerik.WinControls.UI.RadPageViewPage();
      this.pages_snapshot = new Telerik.WinControls.UI.RadPageView();
      this.page_snapshot_home = new Telerik.WinControls.UI.RadPageViewPage();
      this.radScrollablePanel5 = new Telerik.WinControls.UI.RadScrollablePanel();
      this.helpPanel3 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.HelpPanel();
      this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
      this.page_snapshot_start_quickinfo_corpora = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.BigNumber();
      this.page_snapshot_start_quickinfo_texts = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.BigNumber();
      this.page_snapshot_start_quickinfo_layers = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.BigNumber();
      this.page_snapshot_start_quickinfo_tokens = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.BigNumber();
      this.header12 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.Header();
      this.radPanel8 = new Telerik.WinControls.UI.RadPanel();
      this.page_analytics_snapshot_list_snapshots = new Telerik.WinControls.UI.RadTreeView();
      this.radPanel10 = new Telerik.WinControls.UI.RadPanel();
      this.clearPanel6 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.ClearPanel();
      this.page_analytics_snapshot_btn_snapshot_invert = new Telerik.WinControls.UI.RadButton();
      this.clearPanel1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.ClearPanel();
      this.page_analytics_snapshot_btn_snapshot_reduceBfromA = new Telerik.WinControls.UI.RadButton();
      this.page_analytics_snapshot_btn_snapshot_join = new Telerik.WinControls.UI.RadButton();
      this.clearPanel2 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.ClearPanel();
      this.page_analytics_snapshot_btn_snapshot_union = new Telerik.WinControls.UI.RadButton();
      this.page_analytics_snapshot_btn_snapshot_diff = new Telerik.WinControls.UI.RadButton();
      this.panel1 = new System.Windows.Forms.Panel();
      this.page_analytics_snapshot_btn_snapshot_export = new Telerik.WinControls.UI.RadButton();
      this.page_analytics_snapshot_btn_snapshot_load = new Telerik.WinControls.UI.RadButton();
      this.clearPanel11 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.ClearPanel();
      this.page_analytics_snapshot_btn_snapshot_remove = new Telerik.WinControls.UI.RadButton();
      this.page_analytics_snapshot_btn_snapshot_edit = new Telerik.WinControls.UI.RadButton();
      this.clearPanel10 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.ClearPanel();
      this.page_analytics_snapshot_btn_snapshot_clonedetection = new Telerik.WinControls.UI.RadButton();
      this.clearPanel5 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.ClearPanel();
      this.page_analytics_snapshot_btn_snapshot_mask = new Telerik.WinControls.UI.RadDropDownButton();
      this.page_analytics_snapshot_btn_snapshot_mask_individual = new Telerik.WinControls.UI.RadMenuItem();
      this.page_analytics_snapshot_btn_snapshot_mask_metasplit = new Telerik.WinControls.UI.RadMenuItem();
      this.page_analytics_snapshot_btn_snapshot_mask_random = new Telerik.WinControls.UI.RadMenuItem();
      this.page_analytics_snapshot_btn_snapshot_add = new Telerik.WinControls.UI.RadDropDownButton();
      this.page_analytics_snapshot_btn_snapshot_add_individual = new Telerik.WinControls.UI.RadMenuItem();
      this.page_analytics_snapshot_btn_snapshot_add_metasplit = new Telerik.WinControls.UI.RadMenuItem();
      this.page_analytics_snapshot_btn_snapshot_add_random = new Telerik.WinControls.UI.RadMenuItem();
      this.header7 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.Header();
      this.page_snapshot_edit = new Telerik.WinControls.UI.RadPageViewPage();
      this.radGroupBox6 = new Telerik.WinControls.UI.RadGroupBox();
      this.snapshot_edit_queries = new Telerik.WinControls.UI.RadScrollablePanel();
      this.clearPanel7 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.ClearPanel();
      this.snapshot_edit_dropdown_meta = new Telerik.WinControls.UI.RadButton();
      this.snapshot_edit_dropdown_fulltext = new Telerik.WinControls.UI.RadButton();
      this.snapshot_edit_dropdown_corpus = new Telerik.WinControls.UI.RadButton();
      this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
      this.snapshot_edit_displayname = new Telerik.WinControls.UI.RadTextBox();
      this.header11 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.Header();
      this.clearPanel3 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.ClearPanel();
      this.snapshot_edit_abort = new Telerik.WinControls.UI.RadButton();
      this.snapshot_edit_ok = new Telerik.WinControls.UI.RadButton();
      this.page_analytics = new Telerik.WinControls.UI.RadPageViewPage();
      this.pages_analytics = new Telerik.WinControls.UI.RadPageView();
      this.page_analytics_start = new Telerik.WinControls.UI.RadPageViewPage();
      this.radScrollablePanel1 = new Telerik.WinControls.UI.RadScrollablePanel();
      this.radScrollablePanel4 = new Telerik.WinControls.UI.RadScrollablePanel();
      this.helpPanel4 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.HelpPanel();
      this.betafunction_thirdpartyPanel = new Telerik.WinControls.UI.RadPanel();
      this.modul_panel_betafunction_thirdparty = new Telerik.WinControls.UI.RadPanorama();
      this.header9 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.Header();
      this.modul_panel_analytics = new Telerik.WinControls.UI.RadPanorama();
      this.header8 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.Header();
      this.page_analytics_view = new Telerik.WinControls.UI.RadPageViewPage();
      this.pages_standardanalytics = new Telerik.WinControls.UI.RadPageView();
      this.page_standardanalytics_search = new Telerik.WinControls.UI.RadPageViewPage();
      this.page_standardanalytics_frequency = new Telerik.WinControls.UI.RadPageViewPage();
      this.page_standardanalytics_ngram = new Telerik.WinControls.UI.RadPageViewPage();
      this.page_standardanalytics_cooccurrence = new Telerik.WinControls.UI.RadPageViewPage();
      this.page_standardanalytics_disambiguation = new Telerik.WinControls.UI.RadPageViewPage();
      this.page_standardanalytics_weight = new Telerik.WinControls.UI.RadPageViewPage();
      this.page_standardanalytics_complexety = new Telerik.WinControls.UI.RadPageViewPage();
      this.page_standardanalytics_beta = new Telerik.WinControls.UI.RadPageViewPage();
      this.page_rawanalytics_annotation = new Telerik.WinControls.UI.RadPageViewPage();
      this.page_rawanalytics_edition = new Telerik.WinControls.UI.RadPageViewPage();
      this.page_styleMetrics = new Telerik.WinControls.UI.RadPageViewPage();
      this.page_specialFeatures = new Telerik.WinControls.UI.RadPageViewPage();
      this.page_analytics_thirdparty = new Telerik.WinControls.UI.RadPageViewPage();
      this.pages_3rdParty = new Telerik.WinControls.UI.RadPageView();
      this.page_settings = new Telerik.WinControls.UI.RadPageViewPage();
      this.radScrollablePanel2 = new Telerik.WinControls.UI.RadScrollablePanel();
      this.radSplitContainer2 = new Telerik.WinControls.UI.RadSplitContainer();
      this.splitPanel3 = new Telerik.WinControls.UI.SplitPanel();
      this.radGroupBox7 = new Telerik.WinControls.UI.RadGroupBox();
      this.property_meta = new Telerik.WinControls.UI.RadPropertyGrid();
      this.radCommandBar1 = new Telerik.WinControls.UI.RadCommandBar();
      this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
      this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
      this.btn_settings_load = new Telerik.WinControls.UI.CommandBarButton();
      this.btn_settings_save = new Telerik.WinControls.UI.CommandBarButton();
      this.btn_settings_saveas = new Telerik.WinControls.UI.CommandBarButton();
      this.settings_group_parameter = new Telerik.WinControls.UI.RadGroupBox();
      this.clearPanel9 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.ClearPanel();
      this.settings_frequenz_min = new Telerik.WinControls.UI.RadSpinEditor();
      this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
      this.infoButton3 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.InfoButton();
      this.clearPanel8 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.ClearPanel();
      this.settings_signifikanz_min = new Telerik.WinControls.UI.RadSpinEditor();
      this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
      this.infoButton2 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.InfoButton();
      this.clearPanel4 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.ClearPanel();
      this.settings_drop_signifikanz = new Telerik.WinControls.UI.RadDropDownList();
      this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
      this.infoButton1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.InfoButton();
      this.splitPanel4 = new Telerik.WinControls.UI.SplitPanel();
      this.radSplitContainer3 = new Telerik.WinControls.UI.RadSplitContainer();
      this.splitPanel5 = new Telerik.WinControls.UI.SplitPanel();
      this.radGroupBox4 = new Telerik.WinControls.UI.RadGroupBox();
      this.radScrollablePanel6 = new Telerik.WinControls.UI.RadScrollablePanel();
      this.settings_tool_totalReset = new Telerik.WinControls.UI.RadButton();
      this.settings_tool_upgrade = new Telerik.WinControls.UI.RadButton();
      this.settings_tool_xpath = new Telerik.WinControls.UI.RadButton();
      this.settings_tool_mergeCorpora = new Telerik.WinControls.UI.RadButton();
      this.settings_tool_additionalTagger = new Telerik.WinControls.UI.RadButton();
      this.settings_tool_exportCorpus = new Telerik.WinControls.UI.RadButton();
      this.settings_tool_testCorpus = new Telerik.WinControls.UI.RadButton();
      this.settings_tool_eraseCache = new Telerik.WinControls.UI.RadButton();
      this.settings_tool_errorconsole = new Telerik.WinControls.UI.RadButton();
      this.splitPanel6 = new Telerik.WinControls.UI.SplitPanel();
      this.radGroupBox9 = new Telerik.WinControls.UI.RadGroupBox();
      this.settings_list_favorites = new Telerik.WinControls.UI.RadCheckedListBox();
      this.radGroupBox8 = new Telerik.WinControls.UI.RadGroupBox();
      this.settings_insigt_id = new Telerik.WinControls.UI.RadTextBox();
      this.clearPanel12 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.ClearPanel();
      this.settings_insight_info = new Telerik.WinControls.UI.RadButton();
      this.settings_insight_renew = new Telerik.WinControls.UI.RadButton();
      this.settings_insight_disable = new Telerik.WinControls.UI.RadButton();
      this.settings_insight_enable = new Telerik.WinControls.UI.RadButton();
      this.header10 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.Header();
      this.customShape1 = new Telerik.WinControls.OldShapeEditor.CustomShape();
      this.main_mainmenu_app = new Telerik.WinControls.UI.RadMenuItem();
      this.main_mainmenu_project_new = new Telerik.WinControls.UI.RadMenuItem();
      this.main_mainmenu_project_load = new Telerik.WinControls.UI.RadMenuItem();
      this.main_mainmenu_project_save = new Telerik.WinControls.UI.RadMenuItem();
      this.main_mainmenu_project_saveas = new Telerik.WinControls.UI.RadMenuItem();
      this.radMenuSeparatorItem6 = new Telerik.WinControls.UI.RadMenuSeparatorItem();
      this.main_mainmenu_project_settings = new Telerik.WinControls.UI.RadMenuItem();
      this.radMenuSeparatorItem1 = new Telerik.WinControls.UI.RadMenuSeparatorItem();
      this.main_mainmenu_exit = new Telerik.WinControls.UI.RadMenuItem();
      this.main_mainmenu_home = new Telerik.WinControls.UI.RadMenuItem();
      this.main_mainmenu_corpus = new Telerik.WinControls.UI.RadMenuItem();
      this.main_mainmenu_corpus_overview = new Telerik.WinControls.UI.RadMenuItem();
      this.radMenuSeparatorItem3 = new Telerik.WinControls.UI.RadMenuSeparatorItem();
      this.main_mainmenu_corpus_load = new Telerik.WinControls.UI.RadMenuItem();
      this.main_mainmenu_corpus_files = new Telerik.WinControls.UI.RadMenuItem();
      this.main_mainmenu_corpus_import = new Telerik.WinControls.UI.RadMenuItem();
      this.main_mainmenu_corpus_online = new Telerik.WinControls.UI.RadMenuItem();
      this.main_mainmenu_snapshot = new Telerik.WinControls.UI.RadMenuItem();
      this.main_mainmenu_snapshot_overview = new Telerik.WinControls.UI.RadMenuItem();
      this.radMenuSeparatorItem4 = new Telerik.WinControls.UI.RadMenuSeparatorItem();
      this.main_mainmenu_snapshot_availabel = new Telerik.WinControls.UI.RadMenuItem();
      this.main_mainmenu_snapshot_new = new Telerik.WinControls.UI.RadMenuItem();
      this.main_mainmenu_snapshot_new_custom = new Telerik.WinControls.UI.RadMenuItem();
      this.main_mainmenu_snapshot_new_autosplit = new Telerik.WinControls.UI.RadMenuItem();
      this.main_mainmenu_snapshot_new_random = new Telerik.WinControls.UI.RadMenuItem();
      this.main_mainmenu_snapshot_addsub = new Telerik.WinControls.UI.RadMenuItem();
      this.main_mainmenu_snapshot_addsub_custom = new Telerik.WinControls.UI.RadMenuItem();
      this.main_mainmenu_snapshot_addsub_autosplit = new Telerik.WinControls.UI.RadMenuItem();
      this.main_mainmenu_snapshot_addsub_random = new Telerik.WinControls.UI.RadMenuItem();
      this.main_mainmenu_analytics = new Telerik.WinControls.UI.RadMenuItem();
      this.main_mainmenu_analytics_overview = new Telerik.WinControls.UI.RadMenuItem();
      this.radMenuSeparatorItem5 = new Telerik.WinControls.UI.RadMenuSeparatorItem();
      this.main_mainmenu_analytics_favorite = new Telerik.WinControls.UI.RadMenuItem();
      this.radMenu1 = new Telerik.WinControls.UI.RadMenu();
      ((System.ComponentModel.ISupportInitialize)(this.pages_main)).BeginInit();
      this.pages_main.SuspendLayout();
      this.page_welcome.SuspendLayout();
      this.flowLayoutPanel3.SuspendLayout();
      this.page_corpus.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pages_corpora)).BeginInit();
      this.pages_corpora.SuspendLayout();
      this.page_corpus_start.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel3)).BeginInit();
      this.radScrollablePanel3.PanelContainer.SuspendLayout();
      this.radScrollablePanel3.SuspendLayout();
      this.flowLayoutPanel1.SuspendLayout();
      this.flowLayoutPanel5.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.corpus_start_add)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.corpus_start_local)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.corpus_start_import)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.corpus_start_online)).BeginInit();
      this.page_corpus_online.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).BeginInit();
      this.radSplitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).BeginInit();
      this.splitPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
      this.radGroupBox2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.corpus_online_crawler_list)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.corpus_online_crawler_create)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).BeginInit();
      this.splitPanel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).BeginInit();
      this.radGroupBox3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.corpus_online_crawler_queries)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox5)).BeginInit();
      this.radGroupBox5.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.corpus_online_crawler_start_compile)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.corpus_online_crawler_start)).BeginInit();
      this.page_snapshot.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pages_snapshot)).BeginInit();
      this.pages_snapshot.SuspendLayout();
      this.page_snapshot_home.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel5)).BeginInit();
      this.radScrollablePanel5.PanelContainer.SuspendLayout();
      this.radScrollablePanel5.SuspendLayout();
      this.flowLayoutPanel4.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radPanel8)).BeginInit();
      this.radPanel8.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.page_analytics_snapshot_list_snapshots)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radPanel10)).BeginInit();
      this.radPanel10.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel6)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.page_analytics_snapshot_btn_snapshot_invert)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.page_analytics_snapshot_btn_snapshot_reduceBfromA)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.page_analytics_snapshot_btn_snapshot_join)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.page_analytics_snapshot_btn_snapshot_union)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.page_analytics_snapshot_btn_snapshot_diff)).BeginInit();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.page_analytics_snapshot_btn_snapshot_export)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.page_analytics_snapshot_btn_snapshot_load)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel11)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.page_analytics_snapshot_btn_snapshot_remove)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.page_analytics_snapshot_btn_snapshot_edit)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel10)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.page_analytics_snapshot_btn_snapshot_clonedetection)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel5)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.page_analytics_snapshot_btn_snapshot_mask)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.page_analytics_snapshot_btn_snapshot_add)).BeginInit();
      this.page_snapshot_edit.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox6)).BeginInit();
      this.radGroupBox6.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.snapshot_edit_queries)).BeginInit();
      this.snapshot_edit_queries.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel7)).BeginInit();
      this.clearPanel7.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.snapshot_edit_dropdown_meta)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.snapshot_edit_dropdown_fulltext)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.snapshot_edit_dropdown_corpus)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
      this.radGroupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.snapshot_edit_displayname)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel3)).BeginInit();
      this.clearPanel3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.snapshot_edit_abort)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.snapshot_edit_ok)).BeginInit();
      this.page_analytics.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pages_analytics)).BeginInit();
      this.pages_analytics.SuspendLayout();
      this.page_analytics_start.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel1)).BeginInit();
      this.radScrollablePanel1.PanelContainer.SuspendLayout();
      this.radScrollablePanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel4)).BeginInit();
      this.radScrollablePanel4.PanelContainer.SuspendLayout();
      this.radScrollablePanel4.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.betafunction_thirdpartyPanel)).BeginInit();
      this.betafunction_thirdpartyPanel.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.modul_panel_betafunction_thirdparty)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.modul_panel_analytics)).BeginInit();
      this.page_analytics_view.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pages_standardanalytics)).BeginInit();
      this.pages_standardanalytics.SuspendLayout();
      this.page_analytics_thirdparty.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pages_3rdParty)).BeginInit();
      this.page_settings.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel2)).BeginInit();
      this.radScrollablePanel2.PanelContainer.SuspendLayout();
      this.radScrollablePanel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer2)).BeginInit();
      this.radSplitContainer2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel3)).BeginInit();
      this.splitPanel3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox7)).BeginInit();
      this.radGroupBox7.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.property_meta)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.settings_group_parameter)).BeginInit();
      this.settings_group_parameter.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel9)).BeginInit();
      this.clearPanel9.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.settings_frequenz_min)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.infoButton3)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel8)).BeginInit();
      this.clearPanel8.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.settings_signifikanz_min)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.infoButton2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel4)).BeginInit();
      this.clearPanel4.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.settings_drop_signifikanz)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.infoButton1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel4)).BeginInit();
      this.splitPanel4.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer3)).BeginInit();
      this.radSplitContainer3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel5)).BeginInit();
      this.splitPanel5.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox4)).BeginInit();
      this.radGroupBox4.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel6)).BeginInit();
      this.radScrollablePanel6.PanelContainer.SuspendLayout();
      this.radScrollablePanel6.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.settings_tool_totalReset)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.settings_tool_upgrade)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.settings_tool_xpath)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.settings_tool_mergeCorpora)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.settings_tool_additionalTagger)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.settings_tool_exportCorpus)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.settings_tool_testCorpus)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.settings_tool_eraseCache)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.settings_tool_errorconsole)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel6)).BeginInit();
      this.splitPanel6.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox9)).BeginInit();
      this.radGroupBox9.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.settings_list_favorites)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox8)).BeginInit();
      this.radGroupBox8.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.settings_insigt_id)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel12)).BeginInit();
      this.clearPanel12.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.settings_insight_info)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.settings_insight_renew)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.settings_insight_disable)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.settings_insight_enable)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // pages_main
      // 
      this.pages_main.Controls.Add(this.page_welcome);
      this.pages_main.Controls.Add(this.page_corpus);
      this.pages_main.Controls.Add(this.page_snapshot);
      this.pages_main.Controls.Add(this.page_analytics);
      this.pages_main.Controls.Add(this.page_settings);
      this.pages_main.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pages_main.ItemSizeMode = ((Telerik.WinControls.UI.PageViewItemSizeMode)((Telerik.WinControls.UI.PageViewItemSizeMode.EqualWidth | Telerik.WinControls.UI.PageViewItemSizeMode.EqualHeight)));
      this.pages_main.Location = new System.Drawing.Point(0, 56);
      this.pages_main.MinimumSize = new System.Drawing.Size(576, 445);
      this.pages_main.Name = "pages_main";
      // 
      // 
      // 
      this.pages_main.RootElement.MinSize = new System.Drawing.Size(576, 445);
      this.pages_main.SelectedPage = this.page_settings;
      this.pages_main.Size = new System.Drawing.Size(832, 525);
      this.pages_main.TabIndex = 0;
      ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pages_main.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.Scroll;
      ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pages_main.GetChildAt(0))).ItemFitMode = Telerik.WinControls.UI.StripViewItemFitMode.Fill;
      ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pages_main.GetChildAt(0))).ItemSizeMode = ((Telerik.WinControls.UI.PageViewItemSizeMode)((Telerik.WinControls.UI.PageViewItemSizeMode.EqualWidth | Telerik.WinControls.UI.PageViewItemSizeMode.EqualHeight)));
      ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pages_main.GetChildAt(0))).Visibility = Telerik.WinControls.ElementVisibility.Visible;
      ((Telerik.WinControls.UI.StripViewItemContainer)(this.pages_main.GetChildAt(0).GetChildAt(0))).Visibility = Telerik.WinControls.ElementVisibility.Visible;
      ((Telerik.WinControls.UI.StripViewButtonsPanel)(this.pages_main.GetChildAt(0).GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Visible;
      ((Telerik.WinControls.UI.RadPageViewContentAreaElement)(this.pages_main.GetChildAt(0).GetChildAt(1))).BorderWidth = 0F;
      ((Telerik.WinControls.UI.RadPageViewContentAreaElement)(this.pages_main.GetChildAt(0).GetChildAt(1))).BorderLeftWidth = 0F;
      ((Telerik.WinControls.UI.RadPageViewContentAreaElement)(this.pages_main.GetChildAt(0).GetChildAt(1))).BorderRightWidth = 0F;
      ((Telerik.WinControls.UI.RadPageViewContentAreaElement)(this.pages_main.GetChildAt(0).GetChildAt(1))).BorderBottomWidth = 0F;
      ((Telerik.WinControls.UI.RadPageViewContentAreaElement)(this.pages_main.GetChildAt(0).GetChildAt(1))).Padding = new System.Windows.Forms.Padding(0);
      ((Telerik.WinControls.UI.RadPageViewContentAreaElement)(this.pages_main.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Visible;
      // 
      // page_welcome
      // 
      this.page_welcome.Controls.Add(this.helpPanel1);
      this.page_welcome.Controls.Add(this.flowLayoutPanel3);
      this.page_welcome.Controls.Add(this.header2);
      this.page_welcome.Controls.Add(this.header1);
      this.page_welcome.ItemSize = new System.Drawing.SizeF(153F, 29F);
      this.page_welcome.Location = new System.Drawing.Point(0, 35);
      this.page_welcome.Name = "page_welcome";
      this.page_welcome.Size = new System.Drawing.Size(832, 490);
      this.page_welcome.Text = "Willkommen";
      // 
      // helpPanel1
      // 
      this.helpPanel1.BackColor = System.Drawing.Color.White;
      this.helpPanel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.helpPanel1.Font = new System.Drawing.Font("Segoe UI", 11F);
      this.helpPanel1.HelpHandbookText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.InteraktivesHandbuch;
      this.helpPanel1.HelpHandbookUrl = "http://www.bitcutstudios.com/products/corpusexplorer/help/nutzerhandbuch.html";
      this.helpPanel1.HelpHandsonlabText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.PraktischeÜbungen;
      this.helpPanel1.HelpHandsonlabUrl = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Help_Static_HandsOnLab;
      this.helpPanel1.HelpLabelDescribtion = "Diese Hilfe bietet Ihnen praktische Tipps und ist interaktiv gestaltet (setzt ein" +
    "e Internetverbindung voraus).";
      this.helpPanel1.HelpLabelHeader = "Erste Schritte mit dem CorpusExplorer";
      this.helpPanel1.HelpOnlineText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.WeitereInformationen;
      this.helpPanel1.HelpOnlineUrl = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Help_Static_AdditionalInformation;
      this.helpPanel1.HelpVideoText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.KurzesEinstiegsvideo;
      this.helpPanel1.HelpVideoUrl = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Help_Static_YoutubeChannel;
      this.helpPanel1.Location = new System.Drawing.Point(0, 253);
      this.helpPanel1.MinimumSize = new System.Drawing.Size(0, 165);
      this.helpPanel1.Name = "helpPanel1";
      this.helpPanel1.Size = new System.Drawing.Size(832, 165);
      this.helpPanel1.TabIndex = 31;
      // 
      // flowLayoutPanel3
      // 
      this.flowLayoutPanel3.Controls.Add(this.page_welcome_btn_projectname);
      this.flowLayoutPanel3.Controls.Add(this.page_welcome_btn_corpus);
      this.flowLayoutPanel3.Controls.Add(this.page_welcome_btn_snapshot);
      this.flowLayoutPanel3.Controls.Add(this.page_welcome_btn_analytics);
      this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
      this.flowLayoutPanel3.Location = new System.Drawing.Point(0, 133);
      this.flowLayoutPanel3.Name = "flowLayoutPanel3";
      this.flowLayoutPanel3.Size = new System.Drawing.Size(832, 120);
      this.flowLayoutPanel3.TabIndex = 27;
      // 
      // page_welcome_btn_projectname
      // 
      this.page_welcome_btn_projectname.BackColor = System.Drawing.Color.White;
      this.page_welcome_btn_projectname.Font = new System.Drawing.Font("Segoe UI", 11F);
      this.page_welcome_btn_projectname.Image = ((System.Drawing.Image)(resources.GetObject("page_welcome_btn_projectname.Image")));
      this.page_welcome_btn_projectname.ImageCheckmark = ((System.Drawing.Image)(resources.GetObject("page_welcome_btn_projectname.ImageCheckmark")));
      this.page_welcome_btn_projectname.Label = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.ProjektnamenVergeben;
      this.page_welcome_btn_projectname.Location = new System.Drawing.Point(1, 5);
      this.page_welcome_btn_projectname.Margin = new System.Windows.Forms.Padding(1, 5, 4, 5);
      this.page_welcome_btn_projectname.Name = "page_welcome_btn_projectname";
      this.page_welcome_btn_projectname.ShowCheckmark = false;
      this.page_welcome_btn_projectname.Size = new System.Drawing.Size(125, 100);
      this.page_welcome_btn_projectname.TabIndex = 4;
      this.page_welcome_btn_projectname.Click += new System.EventHandler(this.page_welcome_btn_projectname_Click);
      // 
      // page_welcome_btn_corpus
      // 
      this.page_welcome_btn_corpus.BackColor = System.Drawing.Color.White;
      this.page_welcome_btn_corpus.Font = new System.Drawing.Font("Segoe UI", 11F);
      this.page_welcome_btn_corpus.Image = ((System.Drawing.Image)(resources.GetObject("page_welcome_btn_corpus.Image")));
      this.page_welcome_btn_corpus.ImageCheckmark = ((System.Drawing.Image)(resources.GetObject("page_welcome_btn_corpus.ImageCheckmark")));
      this.page_welcome_btn_corpus.Label = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.MindestensEinKorpusLaden;
      this.page_welcome_btn_corpus.Location = new System.Drawing.Point(134, 5);
      this.page_welcome_btn_corpus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.page_welcome_btn_corpus.Name = "page_welcome_btn_corpus";
      this.page_welcome_btn_corpus.ShowCheckmark = false;
      this.page_welcome_btn_corpus.Size = new System.Drawing.Size(125, 100);
      this.page_welcome_btn_corpus.TabIndex = 5;
      this.page_welcome_btn_corpus.Click += new System.EventHandler(this.main_mainmenu_corpus_Click);
      // 
      // page_welcome_btn_snapshot
      // 
      this.page_welcome_btn_snapshot.BackColor = System.Drawing.Color.White;
      this.page_welcome_btn_snapshot.Font = new System.Drawing.Font("Segoe UI", 11F);
      this.page_welcome_btn_snapshot.Image = ((System.Drawing.Image)(resources.GetObject("page_welcome_btn_snapshot.Image")));
      this.page_welcome_btn_snapshot.ImageCheckmark = ((System.Drawing.Image)(resources.GetObject("page_welcome_btn_snapshot.ImageCheckmark")));
      this.page_welcome_btn_snapshot.Label = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.SchnappschussErstellen;
      this.page_welcome_btn_snapshot.Location = new System.Drawing.Point(267, 5);
      this.page_welcome_btn_snapshot.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.page_welcome_btn_snapshot.Name = "page_welcome_btn_snapshot";
      this.page_welcome_btn_snapshot.ShowCheckmark = false;
      this.page_welcome_btn_snapshot.Size = new System.Drawing.Size(125, 100);
      this.page_welcome_btn_snapshot.TabIndex = 6;
      this.page_welcome_btn_snapshot.Click += new System.EventHandler(this.main_mainmenu_snapshot_Click);
      // 
      // page_welcome_btn_analytics
      // 
      this.page_welcome_btn_analytics.BackColor = System.Drawing.Color.White;
      this.page_welcome_btn_analytics.Font = new System.Drawing.Font("Segoe UI", 11F);
      this.page_welcome_btn_analytics.Image = ((System.Drawing.Image)(resources.GetObject("page_welcome_btn_analytics.Image")));
      this.page_welcome_btn_analytics.ImageCheckmark = ((System.Drawing.Image)(resources.GetObject("page_welcome_btn_analytics.ImageCheckmark")));
      this.page_welcome_btn_analytics.Label = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.NeueAnalyseStarten;
      this.page_welcome_btn_analytics.Location = new System.Drawing.Point(400, 5);
      this.page_welcome_btn_analytics.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.page_welcome_btn_analytics.Name = "page_welcome_btn_analytics";
      this.page_welcome_btn_analytics.ShowCheckmark = false;
      this.page_welcome_btn_analytics.Size = new System.Drawing.Size(125, 100);
      this.page_welcome_btn_analytics.TabIndex = 7;
      this.page_welcome_btn_analytics.Click += new System.EventHandler(this.main_mainmenu_analytics_Click);
      // 
      // header2
      // 
      this.header2.BackColor = System.Drawing.Color.White;
      this.header2.Dock = System.Windows.Forms.DockStyle.Top;
      this.header2.Font = new System.Drawing.Font("Segoe UI", 11F);
      this.header2.HeaderDescribtion = "Diese Liste führt alle Schritte auf und geleitet Sie durch den Analyseprozess.";
      this.header2.HeaderHead = "Die Checkliste für eine gelungene Analyse:";
      this.header2.Location = new System.Drawing.Point(0, 79);
      this.header2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.header2.Name = "header2";
      this.header2.Size = new System.Drawing.Size(832, 54);
      this.header2.TabIndex = 30;
      // 
      // header1
      // 
      this.header1.BackColor = System.Drawing.Color.White;
      this.header1.Dock = System.Windows.Forms.DockStyle.Top;
      this.header1.Font = new System.Drawing.Font("Segoe UI", 11F);
      this.header1.HeaderDescribtion = resources.GetString("header1.HeaderDescribtion");
      this.header1.HeaderHead = "Herzlich willkommen!";
      this.header1.Location = new System.Drawing.Point(0, 0);
      this.header1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.header1.Name = "header1";
      this.header1.Size = new System.Drawing.Size(832, 79);
      this.header1.TabIndex = 29;
      // 
      // page_corpus
      // 
      this.page_corpus.Controls.Add(this.pages_corpora);
      this.page_corpus.ItemSize = new System.Drawing.SizeF(153F, 29F);
      this.page_corpus.Location = new System.Drawing.Point(0, 35);
      this.page_corpus.Name = "page_corpus";
      this.page_corpus.Size = new System.Drawing.Size(832, 490);
      this.page_corpus.Text = "Korpora";
      // 
      // pages_corpora
      // 
      this.pages_corpora.Controls.Add(this.page_corpus_start);
      this.pages_corpora.Controls.Add(this.page_corpus_online);
      this.pages_corpora.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pages_corpora.ItemSizeMode = Telerik.WinControls.UI.PageViewItemSizeMode.EqualWidth;
      this.pages_corpora.Location = new System.Drawing.Point(0, 0);
      this.pages_corpora.Name = "pages_corpora";
      this.pages_corpora.SelectedPage = this.page_corpus_online;
      this.pages_corpora.Size = new System.Drawing.Size(832, 490);
      this.pages_corpora.TabIndex = 0;
      ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pages_corpora.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.Scroll;
      ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pages_corpora.GetChildAt(0))).ItemFitMode = Telerik.WinControls.UI.StripViewItemFitMode.None;
      ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pages_corpora.GetChildAt(0))).ItemSizeMode = Telerik.WinControls.UI.PageViewItemSizeMode.EqualWidth;
      ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pages_corpora.GetChildAt(0))).Visibility = Telerik.WinControls.ElementVisibility.Visible;
      ((Telerik.WinControls.UI.RadPageViewLabelElement)(this.pages_corpora.GetChildAt(0).GetChildAt(2))).Text = "HungryBetty";
      ((Telerik.WinControls.UI.RadPageViewLabelElement)(this.pages_corpora.GetChildAt(0).GetChildAt(2))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
      // 
      // page_corpus_start
      // 
      this.page_corpus_start.Controls.Add(this.radScrollablePanel3);
      this.page_corpus_start.Location = new System.Drawing.Point(5, 40);
      this.page_corpus_start.Name = "page_corpus_start";
      this.page_corpus_start.Size = new System.Drawing.Size(822, 445);
      this.page_corpus_start.Text = "Home";
      // 
      // radScrollablePanel3
      // 
      this.radScrollablePanel3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radScrollablePanel3.Location = new System.Drawing.Point(0, 0);
      this.radScrollablePanel3.Name = "radScrollablePanel3";
      // 
      // radScrollablePanel3.PanelContainer
      // 
      this.radScrollablePanel3.PanelContainer.Controls.Add(this.helpPanel2);
      this.radScrollablePanel3.PanelContainer.Controls.Add(this.flowLayoutPanel1);
      this.radScrollablePanel3.PanelContainer.Controls.Add(this.header4);
      this.radScrollablePanel3.PanelContainer.Controls.Add(this.flowLayoutPanel5);
      this.radScrollablePanel3.PanelContainer.Controls.Add(this.header3);
      this.radScrollablePanel3.PanelContainer.Size = new System.Drawing.Size(784, 443);
      this.radScrollablePanel3.Size = new System.Drawing.Size(822, 445);
      this.radScrollablePanel3.TabIndex = 35;
      // 
      // helpPanel2
      // 
      this.helpPanel2.BackColor = System.Drawing.Color.White;
      this.helpPanel2.Dock = System.Windows.Forms.DockStyle.Top;
      this.helpPanel2.Font = new System.Drawing.Font("Segoe UI", 11F);
      this.helpPanel2.HelpHandbookText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.InteraktivesHandbuch;
      this.helpPanel2.HelpHandbookUrl = "http://www.bitcutstudios.com/products/corpusexplorer/help/korpora.html";
      this.helpPanel2.HelpHandsonlabText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.PraktischeÜbungen;
      this.helpPanel2.HelpHandsonlabUrl = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Help_Static_HandsOnLab;
      this.helpPanel2.HelpLabelDescribtion = "Diese Hilfe zeigt Schritt für Schritt wie Sie ganz schnell und einfach Korpusmate" +
    "rial sammeln und aufbereiten.";
      this.helpPanel2.HelpLabelHeader = "Hilfe bei der Materialakquise - Wie erstelle/nutze ich Korpora?";
      this.helpPanel2.HelpOnlineText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.WeitereInformationen;
      this.helpPanel2.HelpOnlineUrl = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Help_Static_AdditionalInformation;
      this.helpPanel2.HelpVideoText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.KurzesEinstiegsvideo;
      this.helpPanel2.HelpVideoUrl = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Help_Static_YoutubeChannel;
      this.helpPanel2.Location = new System.Drawing.Point(0, 397);
      this.helpPanel2.MinimumSize = new System.Drawing.Size(0, 165);
      this.helpPanel2.Name = "helpPanel2";
      this.helpPanel2.Size = new System.Drawing.Size(784, 165);
      this.helpPanel2.TabIndex = 35;
      // 
      // flowLayoutPanel1
      // 
      this.flowLayoutPanel1.Controls.Add(this.page_corpus_start_quickinfo_corpora);
      this.flowLayoutPanel1.Controls.Add(this.page_corpus_start_quickinfo_texts);
      this.flowLayoutPanel1.Controls.Add(this.page_corpus_start_quickinfo_layers);
      this.flowLayoutPanel1.Controls.Add(this.page_corpus_start_quickinfo_tokens);
      this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 245);
      this.flowLayoutPanel1.Name = "flowLayoutPanel1";
      this.flowLayoutPanel1.Size = new System.Drawing.Size(784, 152);
      this.flowLayoutPanel1.TabIndex = 33;
      // 
      // page_corpus_start_quickinfo_corpora
      // 
      this.page_corpus_start_quickinfo_corpora.BackColor = System.Drawing.Color.White;
      this.page_corpus_start_quickinfo_corpora.Font = new System.Drawing.Font("Segoe UI", 11F);
      this.page_corpus_start_quickinfo_corpora.Label = "Korpora";
      this.page_corpus_start_quickinfo_corpora.Location = new System.Drawing.Point(3, 3);
      this.page_corpus_start_quickinfo_corpora.Name = "page_corpus_start_quickinfo_corpora";
      this.page_corpus_start_quickinfo_corpora.Size = new System.Drawing.Size(135, 135);
      this.page_corpus_start_quickinfo_corpora.TabIndex = 0;
      this.page_corpus_start_quickinfo_corpora.Value = "0";
      // 
      // page_corpus_start_quickinfo_texts
      // 
      this.page_corpus_start_quickinfo_texts.BackColor = System.Drawing.Color.White;
      this.page_corpus_start_quickinfo_texts.Font = new System.Drawing.Font("Segoe UI", 11F);
      this.page_corpus_start_quickinfo_texts.Label = "Dokumente";
      this.page_corpus_start_quickinfo_texts.Location = new System.Drawing.Point(144, 3);
      this.page_corpus_start_quickinfo_texts.Name = "page_corpus_start_quickinfo_texts";
      this.page_corpus_start_quickinfo_texts.Size = new System.Drawing.Size(220, 135);
      this.page_corpus_start_quickinfo_texts.TabIndex = 2;
      this.page_corpus_start_quickinfo_texts.Value = "0";
      // 
      // page_corpus_start_quickinfo_layers
      // 
      this.page_corpus_start_quickinfo_layers.BackColor = System.Drawing.Color.White;
      this.page_corpus_start_quickinfo_layers.Font = new System.Drawing.Font("Segoe UI", 11F);
      this.page_corpus_start_quickinfo_layers.Label = "Layer";
      this.page_corpus_start_quickinfo_layers.Location = new System.Drawing.Point(370, 3);
      this.page_corpus_start_quickinfo_layers.Name = "page_corpus_start_quickinfo_layers";
      this.page_corpus_start_quickinfo_layers.Size = new System.Drawing.Size(135, 135);
      this.page_corpus_start_quickinfo_layers.TabIndex = 3;
      this.page_corpus_start_quickinfo_layers.Value = "0";
      // 
      // page_corpus_start_quickinfo_tokens
      // 
      this.page_corpus_start_quickinfo_tokens.BackColor = System.Drawing.Color.White;
      this.page_corpus_start_quickinfo_tokens.Font = new System.Drawing.Font("Segoe UI", 11F);
      this.page_corpus_start_quickinfo_tokens.Label = "Token (Mio.)";
      this.page_corpus_start_quickinfo_tokens.Location = new System.Drawing.Point(511, 3);
      this.page_corpus_start_quickinfo_tokens.Name = "page_corpus_start_quickinfo_tokens";
      this.page_corpus_start_quickinfo_tokens.Size = new System.Drawing.Size(220, 135);
      this.page_corpus_start_quickinfo_tokens.TabIndex = 4;
      this.page_corpus_start_quickinfo_tokens.Value = "0";
      // 
      // header4
      // 
      this.header4.BackColor = System.Drawing.Color.White;
      this.header4.Dock = System.Windows.Forms.DockStyle.Top;
      this.header4.Font = new System.Drawing.Font("Segoe UI", 11F);
      this.header4.HeaderDescribtion = "Das aktuelle Projekt umfasst folgende Datenbestände:";
      this.header4.HeaderHead = "QuickInfo: Alle Korpora im aktuellen Projekt";
      this.header4.Location = new System.Drawing.Point(0, 184);
      this.header4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.header4.Name = "header4";
      this.header4.Size = new System.Drawing.Size(784, 61);
      this.header4.TabIndex = 34;
      // 
      // flowLayoutPanel5
      // 
      this.flowLayoutPanel5.Controls.Add(this.corpus_start_add);
      this.flowLayoutPanel5.Controls.Add(this.corpus_start_local);
      this.flowLayoutPanel5.Controls.Add(this.corpus_start_import);
      this.flowLayoutPanel5.Controls.Add(this.corpus_start_online);
      this.flowLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Top;
      this.flowLayoutPanel5.Location = new System.Drawing.Point(0, 69);
      this.flowLayoutPanel5.Name = "flowLayoutPanel5";
      this.flowLayoutPanel5.Size = new System.Drawing.Size(784, 115);
      this.flowLayoutPanel5.TabIndex = 30;
      // 
      // corpus_start_add
      // 
      this.corpus_start_add.DropDownDirection = Telerik.WinControls.UI.RadDirection.Right;
      this.corpus_start_add.Image = ((System.Drawing.Image)(resources.GetObject("corpus_start_add.Image")));
      this.corpus_start_add.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
      this.corpus_start_add.Location = new System.Drawing.Point(5, 3);
      this.corpus_start_add.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
      this.corpus_start_add.Name = "corpus_start_add";
      this.corpus_start_add.ShowArrow = false;
      this.corpus_start_add.Size = new System.Drawing.Size(120, 100);
      this.corpus_start_add.TabIndex = 6;
      this.corpus_start_add.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.ExistierendesKorpusLaden;
      this.corpus_start_add.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
      this.corpus_start_add.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      // 
      // corpus_start_local
      // 
      this.corpus_start_local.Image = ((System.Drawing.Image)(resources.GetObject("corpus_start_local.Image")));
      this.corpus_start_local.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
      this.corpus_start_local.Location = new System.Drawing.Point(131, 3);
      this.corpus_start_local.Name = "corpus_start_local";
      this.corpus_start_local.Size = new System.Drawing.Size(120, 100);
      this.corpus_start_local.TabIndex = 2;
      this.corpus_start_local.Text = "Dokumente annotieren";
      this.corpus_start_local.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
      this.corpus_start_local.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.corpus_start_local.TextWrap = true;
      this.corpus_start_local.Click += new System.EventHandler(this.corpus_start_local_Click);
      // 
      // corpus_start_import
      // 
      this.corpus_start_import.Image = ((System.Drawing.Image)(resources.GetObject("corpus_start_import.Image")));
      this.corpus_start_import.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
      this.corpus_start_import.Location = new System.Drawing.Point(257, 3);
      this.corpus_start_import.Name = "corpus_start_import";
      this.corpus_start_import.Size = new System.Drawing.Size(120, 100);
      this.corpus_start_import.TabIndex = 1;
      this.corpus_start_import.Text = "Korpus importieren";
      this.corpus_start_import.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
      this.corpus_start_import.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.corpus_start_import.TextWrap = true;
      this.corpus_start_import.Click += new System.EventHandler(this.corpus_start_import_Click);
      // 
      // corpus_start_online
      // 
      this.corpus_start_online.Image = ((System.Drawing.Image)(resources.GetObject("corpus_start_online.Image")));
      this.corpus_start_online.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
      this.corpus_start_online.Location = new System.Drawing.Point(383, 3);
      this.corpus_start_online.Name = "corpus_start_online";
      this.corpus_start_online.Size = new System.Drawing.Size(120, 100);
      this.corpus_start_online.TabIndex = 0;
      this.corpus_start_online.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.OnlineKorpusAkquirieren;
      this.corpus_start_online.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
      this.corpus_start_online.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.corpus_start_online.TextWrap = true;
      this.corpus_start_online.Click += new System.EventHandler(this.corpus_start_online_Click);
      // 
      // header3
      // 
      this.header3.BackColor = System.Drawing.Color.White;
      this.header3.Dock = System.Windows.Forms.DockStyle.Top;
      this.header3.Font = new System.Drawing.Font("Segoe UI", 11F);
      this.header3.HeaderDescribtion = resources.GetString("header3.HeaderDescribtion");
      this.header3.HeaderHead = "Korpus hinzufügen";
      this.header3.Location = new System.Drawing.Point(0, 0);
      this.header3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.header3.Name = "header3";
      this.header3.Size = new System.Drawing.Size(784, 69);
      this.header3.TabIndex = 32;
      // 
      // page_corpus_online
      // 
      this.page_corpus_online.Controls.Add(this.radSplitContainer1);
      this.page_corpus_online.Controls.Add(this.header5);
      this.page_corpus_online.Location = new System.Drawing.Point(5, 40);
      this.page_corpus_online.Name = "page_corpus_online";
      this.page_corpus_online.Size = new System.Drawing.Size(822, 445);
      this.page_corpus_online.Text = "HungryBetty";
      // 
      // radSplitContainer1
      // 
      this.radSplitContainer1.Controls.Add(this.splitPanel1);
      this.radSplitContainer1.Controls.Add(this.splitPanel2);
      this.radSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radSplitContainer1.Location = new System.Drawing.Point(0, 93);
      this.radSplitContainer1.Name = "radSplitContainer1";
      // 
      // 
      // 
      this.radSplitContainer1.RootElement.MinSize = new System.Drawing.Size(0, 0);
      this.radSplitContainer1.Size = new System.Drawing.Size(822, 352);
      this.radSplitContainer1.TabIndex = 41;
      this.radSplitContainer1.TabStop = false;
      // 
      // splitPanel1
      // 
      this.splitPanel1.Controls.Add(this.radGroupBox2);
      this.splitPanel1.Location = new System.Drawing.Point(0, 0);
      this.splitPanel1.Name = "splitPanel1";
      // 
      // 
      // 
      this.splitPanel1.RootElement.MinSize = new System.Drawing.Size(0, 0);
      this.splitPanel1.Size = new System.Drawing.Size(260, 352);
      this.splitPanel1.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(-0.1821516F, 0F);
      this.splitPanel1.SizeInfo.SplitterCorrection = new System.Drawing.Size(-149, 0);
      this.splitPanel1.TabIndex = 0;
      this.splitPanel1.TabStop = false;
      this.splitPanel1.Text = "splitPanel1";
      // 
      // radGroupBox2
      // 
      this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox2.Controls.Add(this.corpus_online_crawler_list);
      this.radGroupBox2.Controls.Add(this.corpus_online_crawler_create);
      this.radGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radGroupBox2.HeaderText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources._1VerfügbareCrawler;
      this.radGroupBox2.Location = new System.Drawing.Point(0, 0);
      this.radGroupBox2.Name = "radGroupBox2";
      this.radGroupBox2.Padding = new System.Windows.Forms.Padding(5, 25, 5, 5);
      this.radGroupBox2.Size = new System.Drawing.Size(260, 352);
      this.radGroupBox2.TabIndex = 38;
      this.radGroupBox2.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources._1VerfügbareCrawler;
      // 
      // corpus_online_crawler_list
      // 
      this.corpus_online_crawler_list.Dock = System.Windows.Forms.DockStyle.Fill;
      this.corpus_online_crawler_list.GroupItemSize = new System.Drawing.Size(200, 40);
      this.corpus_online_crawler_list.ItemSize = new System.Drawing.Size(200, 40);
      this.corpus_online_crawler_list.Location = new System.Drawing.Point(5, 25);
      this.corpus_online_crawler_list.Name = "corpus_online_crawler_list";
      this.corpus_online_crawler_list.ShowCheckBoxes = true;
      this.corpus_online_crawler_list.Size = new System.Drawing.Size(250, 290);
      this.corpus_online_crawler_list.TabIndex = 33;
      ((Telerik.WinControls.UI.RadListViewElement)(this.corpus_online_crawler_list.GetChildAt(0))).BorderWidth = 0F;
      ((Telerik.WinControls.UI.RadListViewElement)(this.corpus_online_crawler_list.GetChildAt(0))).BorderLeftWidth = 0F;
      ((Telerik.WinControls.UI.RadListViewElement)(this.corpus_online_crawler_list.GetChildAt(0))).BorderTopWidth = 0F;
      ((Telerik.WinControls.UI.RadListViewElement)(this.corpus_online_crawler_list.GetChildAt(0))).BorderRightWidth = 0F;
      ((Telerik.WinControls.UI.RadListViewElement)(this.corpus_online_crawler_list.GetChildAt(0))).BorderBottomWidth = 0F;
      ((Telerik.WinControls.UI.SimpleListViewElement)(this.corpus_online_crawler_list.GetChildAt(0).GetChildAt(0))).ItemSize = new System.Drawing.Size(200, 40);
      ((Telerik.WinControls.UI.SimpleListViewElement)(this.corpus_online_crawler_list.GetChildAt(0).GetChildAt(0))).GroupItemSize = new System.Drawing.Size(200, 40);
      ((Telerik.WinControls.UI.SimpleListViewElement)(this.corpus_online_crawler_list.GetChildAt(0).GetChildAt(0))).BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
      // 
      // corpus_online_crawler_create
      // 
      this.corpus_online_crawler_create.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.corpus_online_crawler_create.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.tools;
      this.corpus_online_crawler_create.ImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
      this.corpus_online_crawler_create.Location = new System.Drawing.Point(5, 315);
      this.corpus_online_crawler_create.Name = "corpus_online_crawler_create";
      this.corpus_online_crawler_create.Size = new System.Drawing.Size(250, 32);
      this.corpus_online_crawler_create.TabIndex = 34;
      this.corpus_online_crawler_create.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.EigenenWebCrawlerErstellen;
      this.corpus_online_crawler_create.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
      this.corpus_online_crawler_create.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.corpus_online_crawler_create.Click += new System.EventHandler(this.corpus_online_crawler_create_Click);
      // 
      // splitPanel2
      // 
      this.splitPanel2.Controls.Add(this.radGroupBox3);
      this.splitPanel2.Controls.Add(this.radGroupBox5);
      this.splitPanel2.Location = new System.Drawing.Point(264, 0);
      this.splitPanel2.Name = "splitPanel2";
      // 
      // 
      // 
      this.splitPanel2.RootElement.MinSize = new System.Drawing.Size(0, 0);
      this.splitPanel2.Size = new System.Drawing.Size(558, 352);
      this.splitPanel2.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(0.1821516F, 0F);
      this.splitPanel2.SizeInfo.SplitterCorrection = new System.Drawing.Size(149, 0);
      this.splitPanel2.TabIndex = 1;
      this.splitPanel2.TabStop = false;
      this.splitPanel2.Text = "splitPanel2";
      // 
      // radGroupBox3
      // 
      this.radGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox3.Controls.Add(this.corpus_online_crawler_queries);
      this.radGroupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radGroupBox3.HeaderText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources._2Suchbegriffe;
      this.radGroupBox3.Location = new System.Drawing.Point(0, 0);
      this.radGroupBox3.Name = "radGroupBox3";
      this.radGroupBox3.Padding = new System.Windows.Forms.Padding(5, 25, 5, 5);
      this.radGroupBox3.Size = new System.Drawing.Size(558, 252);
      this.radGroupBox3.TabIndex = 39;
      this.radGroupBox3.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources._2Suchbegriffe;
      // 
      // corpus_online_crawler_queries
      // 
      this.corpus_online_crawler_queries.AcceptsReturn = true;
      this.corpus_online_crawler_queries.AutoSize = false;
      this.corpus_online_crawler_queries.Dock = System.Windows.Forms.DockStyle.Fill;
      this.corpus_online_crawler_queries.Location = new System.Drawing.Point(5, 25);
      this.corpus_online_crawler_queries.Multiline = true;
      this.corpus_online_crawler_queries.Name = "corpus_online_crawler_queries";
      this.corpus_online_crawler_queries.Size = new System.Drawing.Size(548, 222);
      this.corpus_online_crawler_queries.TabIndex = 0;
      // 
      // radGroupBox5
      // 
      this.radGroupBox5.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox5.Controls.Add(this.corpus_online_crawler_start_compile);
      this.radGroupBox5.Controls.Add(this.corpus_online_crawler_start);
      this.radGroupBox5.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.radGroupBox5.HeaderText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources._3KorpusakquiseKonfigurierenUndStarten;
      this.radGroupBox5.Location = new System.Drawing.Point(0, 252);
      this.radGroupBox5.Name = "radGroupBox5";
      this.radGroupBox5.Padding = new System.Windows.Forms.Padding(5, 25, 5, 5);
      this.radGroupBox5.Size = new System.Drawing.Size(558, 100);
      this.radGroupBox5.TabIndex = 40;
      this.radGroupBox5.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources._3KorpusakquiseKonfigurierenUndStarten;
      // 
      // corpus_online_crawler_start_compile
      // 
      this.corpus_online_crawler_start_compile.AutoSize = false;
      this.corpus_online_crawler_start_compile.Dock = System.Windows.Forms.DockStyle.Fill;
      this.corpus_online_crawler_start_compile.Location = new System.Drawing.Point(5, 25);
      this.corpus_online_crawler_start_compile.Name = "corpus_online_crawler_start_compile";
      this.corpus_online_crawler_start_compile.Size = new System.Drawing.Size(394, 70);
      this.corpus_online_crawler_start_compile.TabIndex = 9;
      this.corpus_online_crawler_start_compile.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.FürDieKorpusakquiseSollEinExtraProgrammErstelltWerdenDamitKannDerAkquiseprozessAufAnderePCsServerAusgelagertWerden;
      // 
      // corpus_online_crawler_start
      // 
      this.corpus_online_crawler_start.Dock = System.Windows.Forms.DockStyle.Right;
      this.corpus_online_crawler_start.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.dll_internet;
      this.corpus_online_crawler_start.ImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
      this.corpus_online_crawler_start.Location = new System.Drawing.Point(399, 25);
      this.corpus_online_crawler_start.Name = "corpus_online_crawler_start";
      this.corpus_online_crawler_start.Size = new System.Drawing.Size(154, 70);
      this.corpus_online_crawler_start.TabIndex = 8;
      this.corpus_online_crawler_start.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.StarteDieKorpusakquise;
      this.corpus_online_crawler_start.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
      this.corpus_online_crawler_start.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.corpus_online_crawler_start.Click += new System.EventHandler(this.corpus_online_crawler_start_Click);
      // 
      // header5
      // 
      this.header5.BackColor = System.Drawing.Color.White;
      this.header5.Dock = System.Windows.Forms.DockStyle.Top;
      this.header5.Font = new System.Drawing.Font("Segoe UI", 11F);
      this.header5.HeaderDescribtion = resources.GetString("header5.HeaderDescribtion");
      this.header5.HeaderHead = "Online-Korpus akquirieren";
      this.header5.Location = new System.Drawing.Point(0, 0);
      this.header5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.header5.Name = "header5";
      this.header5.Size = new System.Drawing.Size(822, 93);
      this.header5.TabIndex = 40;
      // 
      // page_snapshot
      // 
      this.page_snapshot.Controls.Add(this.pages_snapshot);
      this.page_snapshot.ItemSize = new System.Drawing.SizeF(153F, 29F);
      this.page_snapshot.Location = new System.Drawing.Point(0, 35);
      this.page_snapshot.Name = "page_snapshot";
      this.page_snapshot.Size = new System.Drawing.Size(832, 490);
      this.page_snapshot.Text = "Snapshot";
      // 
      // pages_snapshot
      // 
      this.pages_snapshot.Controls.Add(this.page_snapshot_home);
      this.pages_snapshot.Controls.Add(this.page_snapshot_edit);
      this.pages_snapshot.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pages_snapshot.ItemSizeMode = Telerik.WinControls.UI.PageViewItemSizeMode.EqualWidth;
      this.pages_snapshot.Location = new System.Drawing.Point(0, 0);
      this.pages_snapshot.Name = "pages_snapshot";
      this.pages_snapshot.SelectedPage = this.page_snapshot_home;
      this.pages_snapshot.Size = new System.Drawing.Size(832, 490);
      this.pages_snapshot.TabIndex = 20;
      ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pages_snapshot.GetChildAt(0))).ItemSizeMode = Telerik.WinControls.UI.PageViewItemSizeMode.EqualWidth;
      // 
      // page_snapshot_home
      // 
      this.page_snapshot_home.Controls.Add(this.radScrollablePanel5);
      this.page_snapshot_home.Location = new System.Drawing.Point(5, 40);
      this.page_snapshot_home.Name = "page_snapshot_home";
      this.page_snapshot_home.Size = new System.Drawing.Size(822, 445);
      this.page_snapshot_home.Text = "HOME";
      // 
      // radScrollablePanel5
      // 
      this.radScrollablePanel5.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radScrollablePanel5.Location = new System.Drawing.Point(0, 0);
      this.radScrollablePanel5.Name = "radScrollablePanel5";
      // 
      // radScrollablePanel5.PanelContainer
      // 
      this.radScrollablePanel5.PanelContainer.Controls.Add(this.helpPanel3);
      this.radScrollablePanel5.PanelContainer.Controls.Add(this.flowLayoutPanel4);
      this.radScrollablePanel5.PanelContainer.Controls.Add(this.header12);
      this.radScrollablePanel5.PanelContainer.Controls.Add(this.radPanel8);
      this.radScrollablePanel5.PanelContainer.Controls.Add(this.header7);
      this.radScrollablePanel5.PanelContainer.Size = new System.Drawing.Size(784, 443);
      this.radScrollablePanel5.Size = new System.Drawing.Size(822, 445);
      this.radScrollablePanel5.TabIndex = 20;
      // 
      // helpPanel3
      // 
      this.helpPanel3.BackColor = System.Drawing.Color.White;
      this.helpPanel3.Dock = System.Windows.Forms.DockStyle.Top;
      this.helpPanel3.Font = new System.Drawing.Font("Segoe UI", 11F);
      this.helpPanel3.HelpHandbookText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.InteraktivesHandbuch;
      this.helpPanel3.HelpHandbookUrl = "http://www.bitcutstudios.com/products/corpusexplorer/help/schnappschusse.html";
      this.helpPanel3.HelpHandsonlabText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.PraktischeÜbungen;
      this.helpPanel3.HelpHandsonlabUrl = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Help_Static_HandsOnLab;
      this.helpPanel3.HelpLabelDescribtion = "Lernen Sie, wie Sie mit Schnappschüssen Ihre Forschung organisieren können.";
      this.helpPanel3.HelpLabelHeader = "Wie funktionieren Schnappschüsse - Eine Hilfe!";
      this.helpPanel3.HelpOnlineText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.WeitereInformationen;
      this.helpPanel3.HelpOnlineUrl = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Help_Static_AdditionalInformation;
      this.helpPanel3.HelpVideoText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.KurzesEinstiegsvideo;
      this.helpPanel3.HelpVideoUrl = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Help_Static_YoutubeChannel;
      this.helpPanel3.Location = new System.Drawing.Point(0, 527);
      this.helpPanel3.MinimumSize = new System.Drawing.Size(0, 165);
      this.helpPanel3.Name = "helpPanel3";
      this.helpPanel3.Size = new System.Drawing.Size(784, 165);
      this.helpPanel3.TabIndex = 19;
      // 
      // flowLayoutPanel4
      // 
      this.flowLayoutPanel4.Controls.Add(this.page_snapshot_start_quickinfo_corpora);
      this.flowLayoutPanel4.Controls.Add(this.page_snapshot_start_quickinfo_texts);
      this.flowLayoutPanel4.Controls.Add(this.page_snapshot_start_quickinfo_layers);
      this.flowLayoutPanel4.Controls.Add(this.page_snapshot_start_quickinfo_tokens);
      this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top;
      this.flowLayoutPanel4.Location = new System.Drawing.Point(0, 375);
      this.flowLayoutPanel4.Name = "flowLayoutPanel4";
      this.flowLayoutPanel4.Size = new System.Drawing.Size(784, 152);
      this.flowLayoutPanel4.TabIndex = 35;
      // 
      // page_snapshot_start_quickinfo_corpora
      // 
      this.page_snapshot_start_quickinfo_corpora.BackColor = System.Drawing.Color.White;
      this.page_snapshot_start_quickinfo_corpora.Font = new System.Drawing.Font("Segoe UI", 11F);
      this.page_snapshot_start_quickinfo_corpora.Label = "Korpora";
      this.page_snapshot_start_quickinfo_corpora.Location = new System.Drawing.Point(3, 3);
      this.page_snapshot_start_quickinfo_corpora.Name = "page_snapshot_start_quickinfo_corpora";
      this.page_snapshot_start_quickinfo_corpora.Size = new System.Drawing.Size(135, 135);
      this.page_snapshot_start_quickinfo_corpora.TabIndex = 0;
      this.page_snapshot_start_quickinfo_corpora.Value = "0";
      // 
      // page_snapshot_start_quickinfo_texts
      // 
      this.page_snapshot_start_quickinfo_texts.BackColor = System.Drawing.Color.White;
      this.page_snapshot_start_quickinfo_texts.Font = new System.Drawing.Font("Segoe UI", 11F);
      this.page_snapshot_start_quickinfo_texts.Label = "Dokumente";
      this.page_snapshot_start_quickinfo_texts.Location = new System.Drawing.Point(144, 3);
      this.page_snapshot_start_quickinfo_texts.Name = "page_snapshot_start_quickinfo_texts";
      this.page_snapshot_start_quickinfo_texts.Size = new System.Drawing.Size(220, 135);
      this.page_snapshot_start_quickinfo_texts.TabIndex = 2;
      this.page_snapshot_start_quickinfo_texts.Value = "0";
      // 
      // page_snapshot_start_quickinfo_layers
      // 
      this.page_snapshot_start_quickinfo_layers.BackColor = System.Drawing.Color.White;
      this.page_snapshot_start_quickinfo_layers.Font = new System.Drawing.Font("Segoe UI", 11F);
      this.page_snapshot_start_quickinfo_layers.Label = "Layer";
      this.page_snapshot_start_quickinfo_layers.Location = new System.Drawing.Point(370, 3);
      this.page_snapshot_start_quickinfo_layers.Name = "page_snapshot_start_quickinfo_layers";
      this.page_snapshot_start_quickinfo_layers.Size = new System.Drawing.Size(135, 135);
      this.page_snapshot_start_quickinfo_layers.TabIndex = 3;
      this.page_snapshot_start_quickinfo_layers.Value = "0";
      // 
      // page_snapshot_start_quickinfo_tokens
      // 
      this.page_snapshot_start_quickinfo_tokens.BackColor = System.Drawing.Color.White;
      this.page_snapshot_start_quickinfo_tokens.Font = new System.Drawing.Font("Segoe UI", 11F);
      this.page_snapshot_start_quickinfo_tokens.Label = "Token (Mio.)";
      this.page_snapshot_start_quickinfo_tokens.Location = new System.Drawing.Point(511, 3);
      this.page_snapshot_start_quickinfo_tokens.Name = "page_snapshot_start_quickinfo_tokens";
      this.page_snapshot_start_quickinfo_tokens.Size = new System.Drawing.Size(220, 135);
      this.page_snapshot_start_quickinfo_tokens.TabIndex = 4;
      this.page_snapshot_start_quickinfo_tokens.Value = "0";
      // 
      // header12
      // 
      this.header12.BackColor = System.Drawing.Color.White;
      this.header12.Dock = System.Windows.Forms.DockStyle.Top;
      this.header12.Font = new System.Drawing.Font("Segoe UI", 11F);
      this.header12.HeaderDescribtion = "Hier sehen Sie, welchen Umfang der von ihnen aktuell gewählte Schnappschuss hat.";
      this.header12.HeaderHead = "QuickInfo: Aktuell gewählter Schnappschuss";
      this.header12.Location = new System.Drawing.Point(0, 314);
      this.header12.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.header12.Name = "header12";
      this.header12.Size = new System.Drawing.Size(784, 61);
      this.header12.TabIndex = 36;
      // 
      // radPanel8
      // 
      this.radPanel8.Controls.Add(this.page_analytics_snapshot_list_snapshots);
      this.radPanel8.Controls.Add(this.radPanel10);
      this.radPanel8.Dock = System.Windows.Forms.DockStyle.Top;
      this.radPanel8.Location = new System.Drawing.Point(0, 69);
      this.radPanel8.MinimumSize = new System.Drawing.Size(0, 245);
      this.radPanel8.Name = "radPanel8";
      // 
      // 
      // 
      this.radPanel8.RootElement.MinSize = new System.Drawing.Size(0, 245);
      this.radPanel8.Size = new System.Drawing.Size(784, 245);
      this.radPanel8.TabIndex = 17;
      // 
      // page_analytics_snapshot_list_snapshots
      // 
      this.page_analytics_snapshot_list_snapshots.Dock = System.Windows.Forms.DockStyle.Fill;
      this.page_analytics_snapshot_list_snapshots.ItemHeight = 40;
      this.page_analytics_snapshot_list_snapshots.Location = new System.Drawing.Point(0, 0);
      this.page_analytics_snapshot_list_snapshots.Name = "page_analytics_snapshot_list_snapshots";
      this.page_analytics_snapshot_list_snapshots.Size = new System.Drawing.Size(484, 245);
      this.page_analytics_snapshot_list_snapshots.SpacingBetweenNodes = -1;
      this.page_analytics_snapshot_list_snapshots.TabIndex = 1;
      this.page_analytics_snapshot_list_snapshots.TreeIndent = 40;
      this.page_analytics_snapshot_list_snapshots.SelectedNodeChanged += new Telerik.WinControls.UI.RadTreeView.RadTreeViewEventHandler(this.page_analytics_snapshot_list_snapshots_SelectedNodeChanged);
      // 
      // radPanel10
      // 
      this.radPanel10.Controls.Add(this.clearPanel6);
      this.radPanel10.Controls.Add(this.page_analytics_snapshot_btn_snapshot_invert);
      this.radPanel10.Controls.Add(this.clearPanel1);
      this.radPanel10.Controls.Add(this.page_analytics_snapshot_btn_snapshot_reduceBfromA);
      this.radPanel10.Controls.Add(this.page_analytics_snapshot_btn_snapshot_join);
      this.radPanel10.Controls.Add(this.clearPanel2);
      this.radPanel10.Controls.Add(this.page_analytics_snapshot_btn_snapshot_union);
      this.radPanel10.Controls.Add(this.page_analytics_snapshot_btn_snapshot_diff);
      this.radPanel10.Controls.Add(this.panel1);
      this.radPanel10.Dock = System.Windows.Forms.DockStyle.Right;
      this.radPanel10.Location = new System.Drawing.Point(484, 0);
      this.radPanel10.Name = "radPanel10";
      this.radPanel10.Padding = new System.Windows.Forms.Padding(3);
      this.radPanel10.Size = new System.Drawing.Size(300, 245);
      this.radPanel10.TabIndex = 0;
      // 
      // clearPanel6
      // 
      this.clearPanel6.Dock = System.Windows.Forms.DockStyle.Top;
      this.clearPanel6.Location = new System.Drawing.Point(154, 169);
      this.clearPanel6.Name = "clearPanel6";
      this.clearPanel6.Size = new System.Drawing.Size(143, 3);
      this.clearPanel6.TabIndex = 20;
      // 
      // page_analytics_snapshot_btn_snapshot_invert
      // 
      this.page_analytics_snapshot_btn_snapshot_invert.Dock = System.Windows.Forms.DockStyle.Top;
      this.page_analytics_snapshot_btn_snapshot_invert.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.page_analytics_snapshot_btn_snapshot_invert.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.button_green_stop;
      this.page_analytics_snapshot_btn_snapshot_invert.Location = new System.Drawing.Point(154, 137);
      this.page_analytics_snapshot_btn_snapshot_invert.Name = "page_analytics_snapshot_btn_snapshot_invert";
      this.page_analytics_snapshot_btn_snapshot_invert.Size = new System.Drawing.Size(143, 32);
      this.page_analytics_snapshot_btn_snapshot_invert.TabIndex = 10;
      this.page_analytics_snapshot_btn_snapshot_invert.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Invertieren;
      this.page_analytics_snapshot_btn_snapshot_invert.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
      this.page_analytics_snapshot_btn_snapshot_invert.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.page_analytics_snapshot_btn_snapshot_invert.Click += new System.EventHandler(this.page_analytics_snapshot_btn_snapshot_invert_Click);
      // 
      // clearPanel1
      // 
      this.clearPanel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.clearPanel1.Location = new System.Drawing.Point(154, 134);
      this.clearPanel1.Name = "clearPanel1";
      this.clearPanel1.Size = new System.Drawing.Size(143, 3);
      this.clearPanel1.TabIndex = 21;
      // 
      // page_analytics_snapshot_btn_snapshot_reduceBfromA
      // 
      this.page_analytics_snapshot_btn_snapshot_reduceBfromA.Dock = System.Windows.Forms.DockStyle.Top;
      this.page_analytics_snapshot_btn_snapshot_reduceBfromA.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.page_analytics_snapshot_btn_snapshot_reduceBfromA.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.settheory_awithoutb;
      this.page_analytics_snapshot_btn_snapshot_reduceBfromA.Location = new System.Drawing.Point(154, 102);
      this.page_analytics_snapshot_btn_snapshot_reduceBfromA.Name = "page_analytics_snapshot_btn_snapshot_reduceBfromA";
      this.page_analytics_snapshot_btn_snapshot_reduceBfromA.Size = new System.Drawing.Size(143, 32);
      this.page_analytics_snapshot_btn_snapshot_reduceBfromA.TabIndex = 16;
      this.page_analytics_snapshot_btn_snapshot_reduceBfromA.Text = "Abziehen";
      this.page_analytics_snapshot_btn_snapshot_reduceBfromA.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
      this.page_analytics_snapshot_btn_snapshot_reduceBfromA.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.page_analytics_snapshot_btn_snapshot_reduceBfromA.Click += new System.EventHandler(this.page_analytics_snapshot_btn_snapshot_reduceBfromA_Click);
      // 
      // page_analytics_snapshot_btn_snapshot_join
      // 
      this.page_analytics_snapshot_btn_snapshot_join.Dock = System.Windows.Forms.DockStyle.Top;
      this.page_analytics_snapshot_btn_snapshot_join.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.page_analytics_snapshot_btn_snapshot_join.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.settheory_join;
      this.page_analytics_snapshot_btn_snapshot_join.Location = new System.Drawing.Point(154, 70);
      this.page_analytics_snapshot_btn_snapshot_join.Name = "page_analytics_snapshot_btn_snapshot_join";
      this.page_analytics_snapshot_btn_snapshot_join.Size = new System.Drawing.Size(143, 32);
      this.page_analytics_snapshot_btn_snapshot_join.TabIndex = 13;
      this.page_analytics_snapshot_btn_snapshot_join.Text = "Vereinigen";
      this.page_analytics_snapshot_btn_snapshot_join.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
      this.page_analytics_snapshot_btn_snapshot_join.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.page_analytics_snapshot_btn_snapshot_join.Click += new System.EventHandler(this.page_analytics_snapshot_btn_snapshot_join_Click);
      // 
      // clearPanel2
      // 
      this.clearPanel2.Dock = System.Windows.Forms.DockStyle.Top;
      this.clearPanel2.Location = new System.Drawing.Point(154, 67);
      this.clearPanel2.Name = "clearPanel2";
      this.clearPanel2.Size = new System.Drawing.Size(143, 3);
      this.clearPanel2.TabIndex = 24;
      // 
      // page_analytics_snapshot_btn_snapshot_union
      // 
      this.page_analytics_snapshot_btn_snapshot_union.Dock = System.Windows.Forms.DockStyle.Top;
      this.page_analytics_snapshot_btn_snapshot_union.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.page_analytics_snapshot_btn_snapshot_union.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.settheory_intersection;
      this.page_analytics_snapshot_btn_snapshot_union.Location = new System.Drawing.Point(154, 35);
      this.page_analytics_snapshot_btn_snapshot_union.Name = "page_analytics_snapshot_btn_snapshot_union";
      this.page_analytics_snapshot_btn_snapshot_union.Size = new System.Drawing.Size(143, 32);
      this.page_analytics_snapshot_btn_snapshot_union.TabIndex = 15;
      this.page_analytics_snapshot_btn_snapshot_union.Text = "Gemeinsamkeit";
      this.page_analytics_snapshot_btn_snapshot_union.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
      this.page_analytics_snapshot_btn_snapshot_union.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.page_analytics_snapshot_btn_snapshot_union.Click += new System.EventHandler(this.page_analytics_snapshot_btn_snapshot_union_Click);
      // 
      // page_analytics_snapshot_btn_snapshot_diff
      // 
      this.page_analytics_snapshot_btn_snapshot_diff.Dock = System.Windows.Forms.DockStyle.Top;
      this.page_analytics_snapshot_btn_snapshot_diff.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.page_analytics_snapshot_btn_snapshot_diff.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.settheory_difference;
      this.page_analytics_snapshot_btn_snapshot_diff.Location = new System.Drawing.Point(154, 3);
      this.page_analytics_snapshot_btn_snapshot_diff.Name = "page_analytics_snapshot_btn_snapshot_diff";
      this.page_analytics_snapshot_btn_snapshot_diff.Size = new System.Drawing.Size(143, 32);
      this.page_analytics_snapshot_btn_snapshot_diff.TabIndex = 14;
      this.page_analytics_snapshot_btn_snapshot_diff.Text = "Differenz";
      this.page_analytics_snapshot_btn_snapshot_diff.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
      this.page_analytics_snapshot_btn_snapshot_diff.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.page_analytics_snapshot_btn_snapshot_diff.Click += new System.EventHandler(this.page_analytics_snapshot_btn_snapshot_diff_Click);
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.page_analytics_snapshot_btn_snapshot_export);
      this.panel1.Controls.Add(this.page_analytics_snapshot_btn_snapshot_load);
      this.panel1.Controls.Add(this.clearPanel11);
      this.panel1.Controls.Add(this.page_analytics_snapshot_btn_snapshot_remove);
      this.panel1.Controls.Add(this.page_analytics_snapshot_btn_snapshot_edit);
      this.panel1.Controls.Add(this.clearPanel10);
      this.panel1.Controls.Add(this.page_analytics_snapshot_btn_snapshot_clonedetection);
      this.panel1.Controls.Add(this.clearPanel5);
      this.panel1.Controls.Add(this.page_analytics_snapshot_btn_snapshot_mask);
      this.panel1.Controls.Add(this.page_analytics_snapshot_btn_snapshot_add);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
      this.panel1.Location = new System.Drawing.Point(3, 3);
      this.panel1.Name = "panel1";
      this.panel1.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
      this.panel1.Size = new System.Drawing.Size(151, 239);
      this.panel1.TabIndex = 22;
      // 
      // page_analytics_snapshot_btn_snapshot_export
      // 
      this.page_analytics_snapshot_btn_snapshot_export.Dock = System.Windows.Forms.DockStyle.Top;
      this.page_analytics_snapshot_btn_snapshot_export.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.page_analytics_snapshot_btn_snapshot_export.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.export_text;
      this.page_analytics_snapshot_btn_snapshot_export.Location = new System.Drawing.Point(0, 201);
      this.page_analytics_snapshot_btn_snapshot_export.Name = "page_analytics_snapshot_btn_snapshot_export";
      this.page_analytics_snapshot_btn_snapshot_export.Size = new System.Drawing.Size(148, 32);
      this.page_analytics_snapshot_btn_snapshot_export.TabIndex = 25;
      this.page_analytics_snapshot_btn_snapshot_export.Text = "Exportieren";
      this.page_analytics_snapshot_btn_snapshot_export.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
      this.page_analytics_snapshot_btn_snapshot_export.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.page_analytics_snapshot_btn_snapshot_export.Click += new System.EventHandler(this.page_analytics_snapshot_btn_snapshot_export_Click);
      // 
      // page_analytics_snapshot_btn_snapshot_load
      // 
      this.page_analytics_snapshot_btn_snapshot_load.Dock = System.Windows.Forms.DockStyle.Top;
      this.page_analytics_snapshot_btn_snapshot_load.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.page_analytics_snapshot_btn_snapshot_load.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.import_from_text;
      this.page_analytics_snapshot_btn_snapshot_load.Location = new System.Drawing.Point(0, 169);
      this.page_analytics_snapshot_btn_snapshot_load.Name = "page_analytics_snapshot_btn_snapshot_load";
      this.page_analytics_snapshot_btn_snapshot_load.Size = new System.Drawing.Size(148, 32);
      this.page_analytics_snapshot_btn_snapshot_load.TabIndex = 21;
      this.page_analytics_snapshot_btn_snapshot_load.Text = "Importieren";
      this.page_analytics_snapshot_btn_snapshot_load.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
      this.page_analytics_snapshot_btn_snapshot_load.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.page_analytics_snapshot_btn_snapshot_load.Click += new System.EventHandler(this.page_analytics_snapshot_btn_snapshot_load_Click);
      // 
      // clearPanel11
      // 
      this.clearPanel11.Dock = System.Windows.Forms.DockStyle.Top;
      this.clearPanel11.Location = new System.Drawing.Point(0, 166);
      this.clearPanel11.Name = "clearPanel11";
      this.clearPanel11.Size = new System.Drawing.Size(148, 3);
      this.clearPanel11.TabIndex = 27;
      // 
      // page_analytics_snapshot_btn_snapshot_remove
      // 
      this.page_analytics_snapshot_btn_snapshot_remove.Dock = System.Windows.Forms.DockStyle.Top;
      this.page_analytics_snapshot_btn_snapshot_remove.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.page_analytics_snapshot_btn_snapshot_remove.Image = ((System.Drawing.Image)(resources.GetObject("page_analytics_snapshot_btn_snapshot_remove.Image")));
      this.page_analytics_snapshot_btn_snapshot_remove.Location = new System.Drawing.Point(0, 134);
      this.page_analytics_snapshot_btn_snapshot_remove.Name = "page_analytics_snapshot_btn_snapshot_remove";
      this.page_analytics_snapshot_btn_snapshot_remove.Size = new System.Drawing.Size(148, 32);
      this.page_analytics_snapshot_btn_snapshot_remove.TabIndex = 0;
      this.page_analytics_snapshot_btn_snapshot_remove.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Löschen;
      this.page_analytics_snapshot_btn_snapshot_remove.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
      this.page_analytics_snapshot_btn_snapshot_remove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.page_analytics_snapshot_btn_snapshot_remove.Click += new System.EventHandler(this.page_analytics_snapshot_btn_snapshot_remove_Click);
      // 
      // page_analytics_snapshot_btn_snapshot_edit
      // 
      this.page_analytics_snapshot_btn_snapshot_edit.Dock = System.Windows.Forms.DockStyle.Top;
      this.page_analytics_snapshot_btn_snapshot_edit.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.page_analytics_snapshot_btn_snapshot_edit.Image = ((System.Drawing.Image)(resources.GetObject("page_analytics_snapshot_btn_snapshot_edit.Image")));
      this.page_analytics_snapshot_btn_snapshot_edit.Location = new System.Drawing.Point(0, 102);
      this.page_analytics_snapshot_btn_snapshot_edit.Name = "page_analytics_snapshot_btn_snapshot_edit";
      this.page_analytics_snapshot_btn_snapshot_edit.Size = new System.Drawing.Size(148, 32);
      this.page_analytics_snapshot_btn_snapshot_edit.TabIndex = 5;
      this.page_analytics_snapshot_btn_snapshot_edit.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Bearbeiten;
      this.page_analytics_snapshot_btn_snapshot_edit.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
      this.page_analytics_snapshot_btn_snapshot_edit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.page_analytics_snapshot_btn_snapshot_edit.Click += new System.EventHandler(this.page_analytics_snapshot_btn_snapshot_edit_Click);
      // 
      // clearPanel10
      // 
      this.clearPanel10.Dock = System.Windows.Forms.DockStyle.Top;
      this.clearPanel10.Location = new System.Drawing.Point(0, 99);
      this.clearPanel10.Name = "clearPanel10";
      this.clearPanel10.Size = new System.Drawing.Size(148, 3);
      this.clearPanel10.TabIndex = 26;
      // 
      // page_analytics_snapshot_btn_snapshot_clonedetection
      // 
      this.page_analytics_snapshot_btn_snapshot_clonedetection.Dock = System.Windows.Forms.DockStyle.Top;
      this.page_analytics_snapshot_btn_snapshot_clonedetection.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.page_analytics_snapshot_btn_snapshot_clonedetection.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.module_warn;
      this.page_analytics_snapshot_btn_snapshot_clonedetection.Location = new System.Drawing.Point(0, 67);
      this.page_analytics_snapshot_btn_snapshot_clonedetection.Name = "page_analytics_snapshot_btn_snapshot_clonedetection";
      this.page_analytics_snapshot_btn_snapshot_clonedetection.Size = new System.Drawing.Size(148, 32);
      this.page_analytics_snapshot_btn_snapshot_clonedetection.TabIndex = 19;
      this.page_analytics_snapshot_btn_snapshot_clonedetection.Text = "AntiClone";
      this.page_analytics_snapshot_btn_snapshot_clonedetection.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
      this.page_analytics_snapshot_btn_snapshot_clonedetection.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.page_analytics_snapshot_btn_snapshot_clonedetection.Click += new System.EventHandler(this.page_analytics_snapshot_btn_snapshot_clonedetection_Click);
      // 
      // clearPanel5
      // 
      this.clearPanel5.Dock = System.Windows.Forms.DockStyle.Top;
      this.clearPanel5.Location = new System.Drawing.Point(0, 64);
      this.clearPanel5.Name = "clearPanel5";
      this.clearPanel5.Size = new System.Drawing.Size(148, 3);
      this.clearPanel5.TabIndex = 18;
      // 
      // page_analytics_snapshot_btn_snapshot_mask
      // 
      this.page_analytics_snapshot_btn_snapshot_mask.Dock = System.Windows.Forms.DockStyle.Top;
      this.page_analytics_snapshot_btn_snapshot_mask.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.button_green_record;
      this.page_analytics_snapshot_btn_snapshot_mask.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.page_analytics_snapshot_btn_snapshot_mask_individual,
            this.page_analytics_snapshot_btn_snapshot_mask_metasplit,
            this.page_analytics_snapshot_btn_snapshot_mask_random});
      this.page_analytics_snapshot_btn_snapshot_mask.Location = new System.Drawing.Point(0, 32);
      this.page_analytics_snapshot_btn_snapshot_mask.Name = "page_analytics_snapshot_btn_snapshot_mask";
      this.page_analytics_snapshot_btn_snapshot_mask.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
      this.page_analytics_snapshot_btn_snapshot_mask.Size = new System.Drawing.Size(148, 32);
      this.page_analytics_snapshot_btn_snapshot_mask.TabIndex = 12;
      this.page_analytics_snapshot_btn_snapshot_mask.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Eingrenzen;
      this.page_analytics_snapshot_btn_snapshot_mask.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
      this.page_analytics_snapshot_btn_snapshot_mask.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      ((Telerik.WinControls.UI.RadDropDownButtonElement)(this.page_analytics_snapshot_btn_snapshot_mask.GetChildAt(0))).Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.button_green_record;
      ((Telerik.WinControls.UI.RadDropDownButtonElement)(this.page_analytics_snapshot_btn_snapshot_mask.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      ((Telerik.WinControls.UI.RadDropDownButtonElement)(this.page_analytics_snapshot_btn_snapshot_mask.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
      ((Telerik.WinControls.UI.RadDropDownButtonElement)(this.page_analytics_snapshot_btn_snapshot_mask.GetChildAt(0))).Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Eingrenzen;
      ((Telerik.WinControls.UI.RadDropDownButtonElement)(this.page_analytics_snapshot_btn_snapshot_mask.GetChildAt(0))).Padding = new System.Windows.Forms.Padding(0);
      ((Telerik.WinControls.UI.RadDropDownButtonElement)(this.page_analytics_snapshot_btn_snapshot_mask.GetChildAt(0))).CanFocus = true;
      ((Telerik.WinControls.UI.RadArrowButtonElement)(this.page_analytics_snapshot_btn_snapshot_mask.GetChildAt(0).GetChildAt(1).GetChildAt(0))).Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
      ((Telerik.WinControls.Primitives.ImagePrimitive)(this.page_analytics_snapshot_btn_snapshot_mask.GetChildAt(0).GetChildAt(1).GetChildAt(0).GetChildAt(4))).Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
      ((Telerik.WinControls.Primitives.ImagePrimitive)(this.page_analytics_snapshot_btn_snapshot_mask.GetChildAt(0).GetChildAt(1).GetChildAt(0).GetChildAt(4))).Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
      ((Telerik.WinControls.Primitives.ImagePrimitive)(this.page_analytics_snapshot_btn_snapshot_mask.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(1).GetChildAt(0))).Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
      // 
      // page_analytics_snapshot_btn_snapshot_mask_individual
      // 
      this.page_analytics_snapshot_btn_snapshot_mask_individual.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.button_green_record;
      this.page_analytics_snapshot_btn_snapshot_mask_individual.Name = "page_analytics_snapshot_btn_snapshot_mask_individual";
      this.page_analytics_snapshot_btn_snapshot_mask_individual.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Individuell;
      this.page_analytics_snapshot_btn_snapshot_mask_individual.Click += new System.EventHandler(this.page_analytics_snapshot_btn_snapshot_mask_individual_Click);
      // 
      // page_analytics_snapshot_btn_snapshot_mask_metasplit
      // 
      this.page_analytics_snapshot_btn_snapshot_mask_metasplit.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.button_green_record;
      this.page_analytics_snapshot_btn_snapshot_mask_metasplit.Name = "page_analytics_snapshot_btn_snapshot_mask_metasplit";
      this.page_analytics_snapshot_btn_snapshot_mask_metasplit.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Autosplit;
      this.page_analytics_snapshot_btn_snapshot_mask_metasplit.Click += new System.EventHandler(this.page_analytics_snapshot_btn_snapshot_mask_metasplit_Click);
      // 
      // page_analytics_snapshot_btn_snapshot_mask_random
      // 
      this.page_analytics_snapshot_btn_snapshot_mask_random.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.button_green_record;
      this.page_analytics_snapshot_btn_snapshot_mask_random.Name = "page_analytics_snapshot_btn_snapshot_mask_random";
      this.page_analytics_snapshot_btn_snapshot_mask_random.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Zufällig;
      this.page_analytics_snapshot_btn_snapshot_mask_random.Click += new System.EventHandler(this.page_analytics_snapshot_btn_snapshot_mask_random_Click);
      // 
      // page_analytics_snapshot_btn_snapshot_add
      // 
      this.page_analytics_snapshot_btn_snapshot_add.Dock = System.Windows.Forms.DockStyle.Top;
      this.page_analytics_snapshot_btn_snapshot_add.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.add_button;
      this.page_analytics_snapshot_btn_snapshot_add.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.page_analytics_snapshot_btn_snapshot_add_individual,
            this.page_analytics_snapshot_btn_snapshot_add_metasplit,
            this.page_analytics_snapshot_btn_snapshot_add_random});
      this.page_analytics_snapshot_btn_snapshot_add.Location = new System.Drawing.Point(0, 0);
      this.page_analytics_snapshot_btn_snapshot_add.Name = "page_analytics_snapshot_btn_snapshot_add";
      this.page_analytics_snapshot_btn_snapshot_add.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
      this.page_analytics_snapshot_btn_snapshot_add.Size = new System.Drawing.Size(148, 32);
      this.page_analytics_snapshot_btn_snapshot_add.TabIndex = 11;
      this.page_analytics_snapshot_btn_snapshot_add.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Neu;
      this.page_analytics_snapshot_btn_snapshot_add.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
      this.page_analytics_snapshot_btn_snapshot_add.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      ((Telerik.WinControls.UI.RadDropDownButtonElement)(this.page_analytics_snapshot_btn_snapshot_add.GetChildAt(0))).Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.add_button;
      ((Telerik.WinControls.UI.RadDropDownButtonElement)(this.page_analytics_snapshot_btn_snapshot_add.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      ((Telerik.WinControls.UI.RadDropDownButtonElement)(this.page_analytics_snapshot_btn_snapshot_add.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
      ((Telerik.WinControls.UI.RadDropDownButtonElement)(this.page_analytics_snapshot_btn_snapshot_add.GetChildAt(0))).Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Neu;
      ((Telerik.WinControls.UI.RadDropDownButtonElement)(this.page_analytics_snapshot_btn_snapshot_add.GetChildAt(0))).Padding = new System.Windows.Forms.Padding(0);
      ((Telerik.WinControls.UI.RadDropDownButtonElement)(this.page_analytics_snapshot_btn_snapshot_add.GetChildAt(0))).CanFocus = true;
      ((Telerik.WinControls.UI.RadArrowButtonElement)(this.page_analytics_snapshot_btn_snapshot_add.GetChildAt(0).GetChildAt(1).GetChildAt(0))).Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
      ((Telerik.WinControls.Primitives.ImagePrimitive)(this.page_analytics_snapshot_btn_snapshot_add.GetChildAt(0).GetChildAt(1).GetChildAt(0).GetChildAt(4))).Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
      ((Telerik.WinControls.Primitives.ImagePrimitive)(this.page_analytics_snapshot_btn_snapshot_add.GetChildAt(0).GetChildAt(1).GetChildAt(0).GetChildAt(4))).Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
      ((Telerik.WinControls.Primitives.ImagePrimitive)(this.page_analytics_snapshot_btn_snapshot_add.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(1).GetChildAt(0))).Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
      // 
      // page_analytics_snapshot_btn_snapshot_add_individual
      // 
      this.page_analytics_snapshot_btn_snapshot_add_individual.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.add_button;
      this.page_analytics_snapshot_btn_snapshot_add_individual.Name = "page_analytics_snapshot_btn_snapshot_add_individual";
      this.page_analytics_snapshot_btn_snapshot_add_individual.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Individuell;
      this.page_analytics_snapshot_btn_snapshot_add_individual.Click += new System.EventHandler(this.page_analytics_snapshot_btn_snapshot_add_individual_Click);
      // 
      // page_analytics_snapshot_btn_snapshot_add_metasplit
      // 
      this.page_analytics_snapshot_btn_snapshot_add_metasplit.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.add_button;
      this.page_analytics_snapshot_btn_snapshot_add_metasplit.Name = "page_analytics_snapshot_btn_snapshot_add_metasplit";
      this.page_analytics_snapshot_btn_snapshot_add_metasplit.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Autosplit;
      this.page_analytics_snapshot_btn_snapshot_add_metasplit.Click += new System.EventHandler(this.page_analytics_snapshot_btn_snapshot_add_metasplit_Click);
      // 
      // page_analytics_snapshot_btn_snapshot_add_random
      // 
      this.page_analytics_snapshot_btn_snapshot_add_random.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.add_button;
      this.page_analytics_snapshot_btn_snapshot_add_random.Name = "page_analytics_snapshot_btn_snapshot_add_random";
      this.page_analytics_snapshot_btn_snapshot_add_random.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Zufällig;
      this.page_analytics_snapshot_btn_snapshot_add_random.Click += new System.EventHandler(this.page_analytics_snapshot_btn_snapshot_add_random_Click);
      // 
      // header7
      // 
      this.header7.BackColor = System.Drawing.Color.White;
      this.header7.Dock = System.Windows.Forms.DockStyle.Top;
      this.header7.Font = new System.Drawing.Font("Segoe UI", 11F);
      this.header7.HeaderDescribtion = resources.GetString("header7.HeaderDescribtion");
      this.header7.HeaderHead = "Schnappschüsse verwalten";
      this.header7.Location = new System.Drawing.Point(0, 0);
      this.header7.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.header7.Name = "header7";
      this.header7.Size = new System.Drawing.Size(784, 69);
      this.header7.TabIndex = 18;
      // 
      // page_snapshot_edit
      // 
      this.page_snapshot_edit.Controls.Add(this.radGroupBox6);
      this.page_snapshot_edit.Controls.Add(this.radGroupBox1);
      this.page_snapshot_edit.Controls.Add(this.header11);
      this.page_snapshot_edit.Controls.Add(this.clearPanel3);
      this.page_snapshot_edit.Location = new System.Drawing.Point(5, 40);
      this.page_snapshot_edit.Name = "page_snapshot_edit";
      this.page_snapshot_edit.Size = new System.Drawing.Size(822, 445);
      this.page_snapshot_edit.Text = "Bearbeiten";
      // 
      // radGroupBox6
      // 
      this.radGroupBox6.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox6.Controls.Add(this.snapshot_edit_queries);
      this.radGroupBox6.Controls.Add(this.clearPanel7);
      this.radGroupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radGroupBox6.HeaderText = "2. Abfragen definieren";
      this.radGroupBox6.Location = new System.Drawing.Point(0, 137);
      this.radGroupBox6.Name = "radGroupBox6";
      this.radGroupBox6.Padding = new System.Windows.Forms.Padding(5, 25, 5, 5);
      this.radGroupBox6.Size = new System.Drawing.Size(822, 265);
      this.radGroupBox6.TabIndex = 25;
      this.radGroupBox6.Text = "2. Abfragen definieren";
      // 
      // snapshot_edit_queries
      // 
      this.snapshot_edit_queries.Dock = System.Windows.Forms.DockStyle.Fill;
      this.snapshot_edit_queries.Location = new System.Drawing.Point(180, 25);
      this.snapshot_edit_queries.Name = "snapshot_edit_queries";
      // 
      // snapshot_edit_queries.PanelContainer
      // 
      this.snapshot_edit_queries.PanelContainer.Size = new System.Drawing.Size(635, 233);
      this.snapshot_edit_queries.Size = new System.Drawing.Size(637, 235);
      this.snapshot_edit_queries.TabIndex = 21;
      // 
      // clearPanel7
      // 
      this.clearPanel7.Controls.Add(this.snapshot_edit_dropdown_meta);
      this.clearPanel7.Controls.Add(this.snapshot_edit_dropdown_fulltext);
      this.clearPanel7.Controls.Add(this.snapshot_edit_dropdown_corpus);
      this.clearPanel7.Dock = System.Windows.Forms.DockStyle.Left;
      this.clearPanel7.Location = new System.Drawing.Point(5, 25);
      this.clearPanel7.Name = "clearPanel7";
      this.clearPanel7.Size = new System.Drawing.Size(175, 235);
      this.clearPanel7.TabIndex = 0;
      // 
      // snapshot_edit_dropdown_meta
      // 
      this.snapshot_edit_dropdown_meta.Dock = System.Windows.Forms.DockStyle.Top;
      this.snapshot_edit_dropdown_meta.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.tag_horizontal;
      this.snapshot_edit_dropdown_meta.Location = new System.Drawing.Point(0, 66);
      this.snapshot_edit_dropdown_meta.Name = "snapshot_edit_dropdown_meta";
      this.snapshot_edit_dropdown_meta.Size = new System.Drawing.Size(175, 33);
      this.snapshot_edit_dropdown_meta.TabIndex = 2;
      this.snapshot_edit_dropdown_meta.Text = "Meta-Bedingung";
      this.snapshot_edit_dropdown_meta.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
      this.snapshot_edit_dropdown_meta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.snapshot_edit_dropdown_meta.Click += new System.EventHandler(this.snapshot_edit_dropdown_meta_Click);
      // 
      // snapshot_edit_dropdown_fulltext
      // 
      this.snapshot_edit_dropdown_fulltext.Dock = System.Windows.Forms.DockStyle.Top;
      this.snapshot_edit_dropdown_fulltext.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.text_box;
      this.snapshot_edit_dropdown_fulltext.Location = new System.Drawing.Point(0, 33);
      this.snapshot_edit_dropdown_fulltext.Name = "snapshot_edit_dropdown_fulltext";
      this.snapshot_edit_dropdown_fulltext.Size = new System.Drawing.Size(175, 33);
      this.snapshot_edit_dropdown_fulltext.TabIndex = 1;
      this.snapshot_edit_dropdown_fulltext.Text = "Volltext-Bedingung";
      this.snapshot_edit_dropdown_fulltext.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
      this.snapshot_edit_dropdown_fulltext.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.snapshot_edit_dropdown_fulltext.Click += new System.EventHandler(this.snapshot_edit_dropdown_fulltext_Click);
      // 
      // snapshot_edit_dropdown_corpus
      // 
      this.snapshot_edit_dropdown_corpus.Dock = System.Windows.Forms.DockStyle.Top;
      this.snapshot_edit_dropdown_corpus.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.cabinet1;
      this.snapshot_edit_dropdown_corpus.Location = new System.Drawing.Point(0, 0);
      this.snapshot_edit_dropdown_corpus.Name = "snapshot_edit_dropdown_corpus";
      this.snapshot_edit_dropdown_corpus.Size = new System.Drawing.Size(175, 33);
      this.snapshot_edit_dropdown_corpus.TabIndex = 0;
      this.snapshot_edit_dropdown_corpus.Text = "Korpus vollständig";
      this.snapshot_edit_dropdown_corpus.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
      this.snapshot_edit_dropdown_corpus.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.snapshot_edit_dropdown_corpus.Click += new System.EventHandler(this.snapshot_edit_dropdown_corpus_Click);
      // 
      // radGroupBox1
      // 
      this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox1.Controls.Add(this.snapshot_edit_displayname);
      this.radGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
      this.radGroupBox1.HeaderText = "1. Schnappschuss benennen";
      this.radGroupBox1.Location = new System.Drawing.Point(0, 76);
      this.radGroupBox1.Name = "radGroupBox1";
      this.radGroupBox1.Padding = new System.Windows.Forms.Padding(5, 25, 5, 5);
      this.radGroupBox1.Size = new System.Drawing.Size(822, 61);
      this.radGroupBox1.TabIndex = 24;
      this.radGroupBox1.Text = "1. Schnappschuss benennen";
      // 
      // snapshot_edit_displayname
      // 
      this.snapshot_edit_displayname.Dock = System.Windows.Forms.DockStyle.Fill;
      this.snapshot_edit_displayname.Location = new System.Drawing.Point(5, 25);
      this.snapshot_edit_displayname.Name = "snapshot_edit_displayname";
      this.snapshot_edit_displayname.NullText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.GebenSieHierEinenSinnvollenNamenFürDenSchnappschussEin;
      this.snapshot_edit_displayname.Size = new System.Drawing.Size(812, 31);
      this.snapshot_edit_displayname.TabIndex = 23;
      // 
      // header11
      // 
      this.header11.BackColor = System.Drawing.Color.White;
      this.header11.Dock = System.Windows.Forms.DockStyle.Top;
      this.header11.Font = new System.Drawing.Font("Segoe UI", 11F);
      this.header11.HeaderDescribtion = resources.GetString("header11.HeaderDescribtion");
      this.header11.HeaderHead = "Schnappschuss definieren";
      this.header11.Location = new System.Drawing.Point(0, 0);
      this.header11.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.header11.Name = "header11";
      this.header11.Size = new System.Drawing.Size(822, 76);
      this.header11.TabIndex = 19;
      // 
      // clearPanel3
      // 
      this.clearPanel3.Controls.Add(this.snapshot_edit_abort);
      this.clearPanel3.Controls.Add(this.snapshot_edit_ok);
      this.clearPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.clearPanel3.Location = new System.Drawing.Point(0, 402);
      this.clearPanel3.Name = "clearPanel3";
      this.clearPanel3.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
      this.clearPanel3.Size = new System.Drawing.Size(822, 43);
      this.clearPanel3.TabIndex = 22;
      // 
      // snapshot_edit_abort
      // 
      this.snapshot_edit_abort.Dock = System.Windows.Forms.DockStyle.Left;
      this.snapshot_edit_abort.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.remove_button;
      this.snapshot_edit_abort.Location = new System.Drawing.Point(0, 10);
      this.snapshot_edit_abort.Name = "snapshot_edit_abort";
      this.snapshot_edit_abort.Size = new System.Drawing.Size(210, 33);
      this.snapshot_edit_abort.TabIndex = 1;
      this.snapshot_edit_abort.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.ErstellenAbbrechen;
      this.snapshot_edit_abort.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
      this.snapshot_edit_abort.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.snapshot_edit_abort.Click += new System.EventHandler(this.snapshot_edit_abort_Click);
      // 
      // snapshot_edit_ok
      // 
      this.snapshot_edit_ok.Dock = System.Windows.Forms.DockStyle.Right;
      this.snapshot_edit_ok.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.camera1;
      this.snapshot_edit_ok.Location = new System.Drawing.Point(612, 10);
      this.snapshot_edit_ok.Name = "snapshot_edit_ok";
      this.snapshot_edit_ok.Size = new System.Drawing.Size(210, 33);
      this.snapshot_edit_ok.TabIndex = 0;
      this.snapshot_edit_ok.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.SchnappschussErstellen;
      this.snapshot_edit_ok.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.snapshot_edit_ok.Click += new System.EventHandler(this.snapshot_edit_ok_Click);
      // 
      // page_analytics
      // 
      this.page_analytics.Controls.Add(this.pages_analytics);
      this.page_analytics.ItemSize = new System.Drawing.SizeF(153F, 29F);
      this.page_analytics.Location = new System.Drawing.Point(0, 35);
      this.page_analytics.Name = "page_analytics";
      this.page_analytics.Size = new System.Drawing.Size(832, 490);
      this.page_analytics.Text = "Analyse";
      // 
      // pages_analytics
      // 
      this.pages_analytics.Controls.Add(this.page_analytics_start);
      this.pages_analytics.Controls.Add(this.page_analytics_view);
      this.pages_analytics.Controls.Add(this.page_analytics_thirdparty);
      this.pages_analytics.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pages_analytics.ItemSizeMode = ((Telerik.WinControls.UI.PageViewItemSizeMode)((Telerik.WinControls.UI.PageViewItemSizeMode.EqualWidth | Telerik.WinControls.UI.PageViewItemSizeMode.EqualHeight)));
      this.pages_analytics.Location = new System.Drawing.Point(0, 0);
      this.pages_analytics.Name = "pages_analytics";
      this.pages_analytics.SelectedPage = this.page_analytics_start;
      this.pages_analytics.Size = new System.Drawing.Size(832, 490);
      this.pages_analytics.TabIndex = 0;
      ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pages_analytics.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.Scroll;
      ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pages_analytics.GetChildAt(0))).ItemFitMode = Telerik.WinControls.UI.StripViewItemFitMode.Fill;
      ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pages_analytics.GetChildAt(0))).ItemSizeMode = ((Telerik.WinControls.UI.PageViewItemSizeMode)((Telerik.WinControls.UI.PageViewItemSizeMode.EqualWidth | Telerik.WinControls.UI.PageViewItemSizeMode.EqualHeight)));
      // 
      // page_analytics_start
      // 
      this.page_analytics_start.Controls.Add(this.radScrollablePanel1);
      this.page_analytics_start.Location = new System.Drawing.Point(5, 40);
      this.page_analytics_start.Name = "page_analytics_start";
      this.page_analytics_start.Size = new System.Drawing.Size(822, 445);
      this.page_analytics_start.Text = "Übersicht";
      // 
      // radScrollablePanel1
      // 
      this.radScrollablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radScrollablePanel1.Location = new System.Drawing.Point(0, 0);
      this.radScrollablePanel1.Name = "radScrollablePanel1";
      // 
      // radScrollablePanel1.PanelContainer
      // 
      this.radScrollablePanel1.PanelContainer.Controls.Add(this.radScrollablePanel4);
      this.radScrollablePanel1.PanelContainer.Size = new System.Drawing.Size(820, 443);
      this.radScrollablePanel1.Size = new System.Drawing.Size(822, 445);
      this.radScrollablePanel1.TabIndex = 0;
      // 
      // radScrollablePanel4
      // 
      this.radScrollablePanel4.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radScrollablePanel4.Location = new System.Drawing.Point(0, 0);
      this.radScrollablePanel4.Name = "radScrollablePanel4";
      // 
      // radScrollablePanel4.PanelContainer
      // 
      this.radScrollablePanel4.PanelContainer.Controls.Add(this.helpPanel4);
      this.radScrollablePanel4.PanelContainer.Controls.Add(this.betafunction_thirdpartyPanel);
      this.radScrollablePanel4.PanelContainer.Controls.Add(this.modul_panel_analytics);
      this.radScrollablePanel4.PanelContainer.Controls.Add(this.header8);
      this.radScrollablePanel4.PanelContainer.Size = new System.Drawing.Size(782, 441);
      this.radScrollablePanel4.Size = new System.Drawing.Size(820, 443);
      this.radScrollablePanel4.TabIndex = 34;
      // 
      // helpPanel4
      // 
      this.helpPanel4.BackColor = System.Drawing.Color.White;
      this.helpPanel4.Dock = System.Windows.Forms.DockStyle.Top;
      this.helpPanel4.Font = new System.Drawing.Font("Segoe UI", 11F);
      this.helpPanel4.HelpHandbookText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.InteraktivesHandbuch;
      this.helpPanel4.HelpHandbookUrl = "http://www.bitcutstudios.com/products/corpusexplorer/help/analysen.html";
      this.helpPanel4.HelpHandsonlabText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.PraktischeÜbungen;
      this.helpPanel4.HelpHandsonlabUrl = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Help_Static_HandsOnLab;
      this.helpPanel4.HelpLabelDescribtion = "Die Module repräsentieren die einzelnen Analysen. Die Module verfügen über unters" +
    "chiedliche Darstellungs-/Auswertungsmodi.";
      this.helpPanel4.HelpLabelHeader = "Hilfe zu den verfügbaren Modulen - Allgemeine Einführung";
      this.helpPanel4.HelpOnlineText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.WeitereInformationen;
      this.helpPanel4.HelpOnlineUrl = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Help_Static_AdditionalInformation;
      this.helpPanel4.HelpVideoText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.KurzesEinstiegsvideo;
      this.helpPanel4.HelpVideoUrl = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Help_Static_YoutubeChannel;
      this.helpPanel4.Location = new System.Drawing.Point(0, 458);
      this.helpPanel4.MinimumSize = new System.Drawing.Size(0, 165);
      this.helpPanel4.Name = "helpPanel4";
      this.helpPanel4.Size = new System.Drawing.Size(782, 165);
      this.helpPanel4.TabIndex = 34;
      // 
      // betafunction_thirdpartyPanel
      // 
      this.betafunction_thirdpartyPanel.Controls.Add(this.modul_panel_betafunction_thirdparty);
      this.betafunction_thirdpartyPanel.Controls.Add(this.header9);
      this.betafunction_thirdpartyPanel.Dock = System.Windows.Forms.DockStyle.Top;
      this.betafunction_thirdpartyPanel.Location = new System.Drawing.Point(0, 289);
      this.betafunction_thirdpartyPanel.MinimumSize = new System.Drawing.Size(518, 169);
      this.betafunction_thirdpartyPanel.Name = "betafunction_thirdpartyPanel";
      // 
      // 
      // 
      this.betafunction_thirdpartyPanel.RootElement.MinSize = new System.Drawing.Size(518, 169);
      this.betafunction_thirdpartyPanel.Size = new System.Drawing.Size(782, 169);
      this.betafunction_thirdpartyPanel.TabIndex = 33;
      ((Telerik.WinControls.Primitives.BorderPrimitive)(this.betafunction_thirdpartyPanel.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Hidden;
      // 
      // modul_panel_betafunction_thirdparty
      // 
      this.modul_panel_betafunction_thirdparty.CellSize = new System.Drawing.Size(125, 100);
      this.modul_panel_betafunction_thirdparty.Dock = System.Windows.Forms.DockStyle.Fill;
      this.modul_panel_betafunction_thirdparty.Location = new System.Drawing.Point(0, 69);
      this.modul_panel_betafunction_thirdparty.Name = "modul_panel_betafunction_thirdparty";
      this.modul_panel_betafunction_thirdparty.ScrollBarThickness = 20;
      this.modul_panel_betafunction_thirdparty.ScrollingBackground = true;
      this.modul_panel_betafunction_thirdparty.Size = new System.Drawing.Size(782, 100);
      this.modul_panel_betafunction_thirdparty.TabIndex = 36;
      // 
      // header9
      // 
      this.header9.BackColor = System.Drawing.Color.White;
      this.header9.Dock = System.Windows.Forms.DockStyle.Top;
      this.header9.Font = new System.Drawing.Font("Segoe UI", 11F);
      this.header9.HeaderDescribtion = resources.GetString("header9.HeaderDescribtion");
      this.header9.HeaderHead = "Erweiterungen von Drittanbietern";
      this.header9.Location = new System.Drawing.Point(0, 0);
      this.header9.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.header9.Name = "header9";
      this.header9.Size = new System.Drawing.Size(782, 69);
      this.header9.TabIndex = 0;
      // 
      // modul_panel_analytics
      // 
      this.modul_panel_analytics.CellSize = new System.Drawing.Size(125, 100);
      this.modul_panel_analytics.Dock = System.Windows.Forms.DockStyle.Top;
      this.modul_panel_analytics.Location = new System.Drawing.Point(0, 69);
      this.modul_panel_analytics.Name = "modul_panel_analytics";
      this.modul_panel_analytics.RowsCount = 2;
      this.modul_panel_analytics.ScrollBarThickness = 20;
      this.modul_panel_analytics.ScrollingBackground = true;
      this.modul_panel_analytics.Size = new System.Drawing.Size(782, 220);
      this.modul_panel_analytics.TabIndex = 32;
      // 
      // header8
      // 
      this.header8.BackColor = System.Drawing.Color.White;
      this.header8.Dock = System.Windows.Forms.DockStyle.Top;
      this.header8.Font = new System.Drawing.Font("Segoe UI", 11F);
      this.header8.HeaderDescribtion = resources.GetString("header8.HeaderDescribtion");
      this.header8.HeaderHead = "Verfügbare Analysemodule";
      this.header8.Location = new System.Drawing.Point(0, 0);
      this.header8.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.header8.Name = "header8";
      this.header8.Size = new System.Drawing.Size(782, 69);
      this.header8.TabIndex = 0;
      // 
      // page_analytics_view
      // 
      this.page_analytics_view.Controls.Add(this.pages_standardanalytics);
      this.page_analytics_view.Location = new System.Drawing.Point(5, 40);
      this.page_analytics_view.Name = "page_analytics_view";
      this.page_analytics_view.Size = new System.Drawing.Size(822, 445);
      this.page_analytics_view.Text = "Auswertung";
      // 
      // pages_standardanalytics
      // 
      this.pages_standardanalytics.Controls.Add(this.page_standardanalytics_search);
      this.pages_standardanalytics.Controls.Add(this.page_standardanalytics_frequency);
      this.pages_standardanalytics.Controls.Add(this.page_standardanalytics_ngram);
      this.pages_standardanalytics.Controls.Add(this.page_standardanalytics_cooccurrence);
      this.pages_standardanalytics.Controls.Add(this.page_standardanalytics_disambiguation);
      this.pages_standardanalytics.Controls.Add(this.page_standardanalytics_weight);
      this.pages_standardanalytics.Controls.Add(this.page_standardanalytics_complexety);
      this.pages_standardanalytics.Controls.Add(this.page_standardanalytics_beta);
      this.pages_standardanalytics.Controls.Add(this.page_rawanalytics_annotation);
      this.pages_standardanalytics.Controls.Add(this.page_rawanalytics_edition);
      this.pages_standardanalytics.Controls.Add(this.page_styleMetrics);
      this.pages_standardanalytics.Controls.Add(this.page_specialFeatures);
      this.pages_standardanalytics.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pages_standardanalytics.Location = new System.Drawing.Point(0, 0);
      this.pages_standardanalytics.Name = "pages_standardanalytics";
      this.pages_standardanalytics.SelectedPage = this.page_standardanalytics_weight;
      this.pages_standardanalytics.Size = new System.Drawing.Size(822, 445);
      this.pages_standardanalytics.TabIndex = 0;
      ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pages_standardanalytics.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.Scroll;
      ((Telerik.WinControls.UI.RadPageViewContentAreaElement)(this.pages_standardanalytics.GetChildAt(0).GetChildAt(1))).Padding = new System.Windows.Forms.Padding(0);
      // 
      // page_standardanalytics_search
      // 
      this.page_standardanalytics_search.Location = new System.Drawing.Point(1, 36);
      this.page_standardanalytics_search.Name = "page_standardanalytics_search";
      this.page_standardanalytics_search.Size = new System.Drawing.Size(820, 418);
      this.page_standardanalytics_search.Text = "Fundstellen";
      // 
      // page_standardanalytics_frequency
      // 
      this.page_standardanalytics_frequency.Location = new System.Drawing.Point(1, 36);
      this.page_standardanalytics_frequency.Name = "page_standardanalytics_frequency";
      this.page_standardanalytics_frequency.Size = new System.Drawing.Size(820, 418);
      this.page_standardanalytics_frequency.Text = "Frequenz";
      // 
      // page_standardanalytics_ngram
      // 
      this.page_standardanalytics_ngram.Location = new System.Drawing.Point(1, 36);
      this.page_standardanalytics_ngram.Name = "page_standardanalytics_ngram";
      this.page_standardanalytics_ngram.Size = new System.Drawing.Size(820, 418);
      this.page_standardanalytics_ngram.Text = "NGram";
      // 
      // page_standardanalytics_cooccurrence
      // 
      this.page_standardanalytics_cooccurrence.Location = new System.Drawing.Point(1, 36);
      this.page_standardanalytics_cooccurrence.Name = "page_standardanalytics_cooccurrence";
      this.page_standardanalytics_cooccurrence.Size = new System.Drawing.Size(820, 418);
      this.page_standardanalytics_cooccurrence.Text = "Kollokatoren";
      // 
      // page_standardanalytics_disambiguation
      // 
      this.page_standardanalytics_disambiguation.Location = new System.Drawing.Point(1, 36);
      this.page_standardanalytics_disambiguation.Name = "page_standardanalytics_disambiguation";
      this.page_standardanalytics_disambiguation.Size = new System.Drawing.Size(820, 418);
      this.page_standardanalytics_disambiguation.Text = "Disambiguierung";
      // 
      // page_standardanalytics_weight
      // 
      this.page_standardanalytics_weight.Location = new System.Drawing.Point(1, 36);
      this.page_standardanalytics_weight.Name = "page_standardanalytics_weight";
      this.page_standardanalytics_weight.Size = new System.Drawing.Size(820, 408);
      this.page_standardanalytics_weight.Text = "Gewichtung";
      // 
      // page_standardanalytics_complexety
      // 
      this.page_standardanalytics_complexety.Location = new System.Drawing.Point(1, 36);
      this.page_standardanalytics_complexety.Name = "page_standardanalytics_complexety";
      this.page_standardanalytics_complexety.Size = new System.Drawing.Size(820, 418);
      this.page_standardanalytics_complexety.Text = "Komplexität";
      // 
      // page_standardanalytics_beta
      // 
      this.page_standardanalytics_beta.Location = new System.Drawing.Point(1, 36);
      this.page_standardanalytics_beta.Name = "page_standardanalytics_beta";
      this.page_standardanalytics_beta.Size = new System.Drawing.Size(820, 418);
      this.page_standardanalytics_beta.Text = "Betamodule";
      // 
      // page_rawanalytics_annotation
      // 
      this.page_rawanalytics_annotation.Location = new System.Drawing.Point(1, 36);
      this.page_rawanalytics_annotation.Name = "page_rawanalytics_annotation";
      this.page_rawanalytics_annotation.Size = new System.Drawing.Size(820, 418);
      this.page_rawanalytics_annotation.Text = "Annotation";
      // 
      // page_rawanalytics_edition
      // 
      this.page_rawanalytics_edition.Location = new System.Drawing.Point(1, 36);
      this.page_rawanalytics_edition.Name = "page_rawanalytics_edition";
      this.page_rawanalytics_edition.Size = new System.Drawing.Size(820, 418);
      this.page_rawanalytics_edition.Text = "Edition";
      // 
      // page_styleMetrics
      // 
      this.page_styleMetrics.Location = new System.Drawing.Point(0, 0);
      this.page_styleMetrics.Name = "page_styleMetrics";
      this.page_styleMetrics.Size = new System.Drawing.Size(200, 100);
      this.page_styleMetrics.Text = "Stilmetriken";
      // 
      // page_specialFeatures
      // 
      this.page_specialFeatures.Location = new System.Drawing.Point(1, 36);
      this.page_specialFeatures.Name = "page_specialFeatures";
      this.page_specialFeatures.Size = new System.Drawing.Size(820, 418);
      this.page_specialFeatures.Text = "Spezialfunktionen";
      // 
      // page_analytics_thirdparty
      // 
      this.page_analytics_thirdparty.Controls.Add(this.pages_3rdParty);
      this.page_analytics_thirdparty.Location = new System.Drawing.Point(5, 40);
      this.page_analytics_thirdparty.Name = "page_analytics_thirdparty";
      this.page_analytics_thirdparty.Size = new System.Drawing.Size(822, 445);
      this.page_analytics_thirdparty.Text = "3rdParty";
      // 
      // pages_3rdParty
      // 
      this.pages_3rdParty.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pages_3rdParty.Location = new System.Drawing.Point(0, 0);
      this.pages_3rdParty.Name = "pages_3rdParty";
      this.pages_3rdParty.Size = new System.Drawing.Size(822, 445);
      this.pages_3rdParty.TabIndex = 0;
      // 
      // page_settings
      // 
      this.page_settings.Controls.Add(this.radScrollablePanel2);
      this.page_settings.ItemSize = new System.Drawing.SizeF(153F, 29F);
      this.page_settings.Location = new System.Drawing.Point(0, 35);
      this.page_settings.Name = "page_settings";
      this.page_settings.Size = new System.Drawing.Size(832, 490);
      this.page_settings.Text = "Einstellungen";
      // 
      // radScrollablePanel2
      // 
      this.radScrollablePanel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radScrollablePanel2.HorizontalScrollBarState = Telerik.WinControls.UI.ScrollState.AlwaysHide;
      this.radScrollablePanel2.Location = new System.Drawing.Point(0, 0);
      this.radScrollablePanel2.Name = "radScrollablePanel2";
      // 
      // radScrollablePanel2.PanelContainer
      // 
      this.radScrollablePanel2.PanelContainer.Controls.Add(this.radSplitContainer2);
      this.radScrollablePanel2.PanelContainer.Controls.Add(this.header10);
      this.radScrollablePanel2.PanelContainer.Size = new System.Drawing.Size(830, 488);
      // 
      // 
      // 
      this.radScrollablePanel2.RootElement.MaxSize = new System.Drawing.Size(0, 0);
      this.radScrollablePanel2.Size = new System.Drawing.Size(832, 490);
      this.radScrollablePanel2.TabIndex = 30;
      // 
      // radSplitContainer2
      // 
      this.radSplitContainer2.Controls.Add(this.splitPanel3);
      this.radSplitContainer2.Controls.Add(this.splitPanel4);
      this.radSplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radSplitContainer2.Location = new System.Drawing.Point(0, 74);
      this.radSplitContainer2.Name = "radSplitContainer2";
      // 
      // 
      // 
      this.radSplitContainer2.RootElement.MinSize = new System.Drawing.Size(0, 0);
      this.radSplitContainer2.Size = new System.Drawing.Size(830, 414);
      this.radSplitContainer2.TabIndex = 31;
      this.radSplitContainer2.TabStop = false;
      // 
      // splitPanel3
      // 
      this.splitPanel3.Controls.Add(this.radGroupBox7);
      this.splitPanel3.Controls.Add(this.settings_group_parameter);
      this.splitPanel3.Location = new System.Drawing.Point(0, 0);
      this.splitPanel3.Name = "splitPanel3";
      // 
      // 
      // 
      this.splitPanel3.RootElement.MinSize = new System.Drawing.Size(0, 0);
      this.splitPanel3.Size = new System.Drawing.Size(380, 414);
      this.splitPanel3.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(-0.03995156F, 0F);
      this.splitPanel3.SizeInfo.SplitterCorrection = new System.Drawing.Size(-33, 0);
      this.splitPanel3.TabIndex = 0;
      this.splitPanel3.TabStop = false;
      this.splitPanel3.Text = "splitPanel3";
      // 
      // radGroupBox7
      // 
      this.radGroupBox7.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox7.Controls.Add(this.property_meta);
      this.radGroupBox7.Controls.Add(this.radCommandBar1);
      this.radGroupBox7.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radGroupBox7.HeaderText = "Feature-Toggles & Einstellungen";
      this.radGroupBox7.Location = new System.Drawing.Point(0, 142);
      this.radGroupBox7.Name = "radGroupBox7";
      this.radGroupBox7.Padding = new System.Windows.Forms.Padding(5, 25, 5, 5);
      this.radGroupBox7.Size = new System.Drawing.Size(380, 272);
      this.radGroupBox7.TabIndex = 20;
      this.radGroupBox7.Text = "Feature-Toggles & Einstellungen";
      this.radGroupBox7.UseMnemonic = false;
      // 
      // property_meta
      // 
      this.property_meta.Dock = System.Windows.Forms.DockStyle.Fill;
      this.property_meta.EnableGrouping = false;
      this.property_meta.HelpBarHeight = 0F;
      this.property_meta.HelpVisible = false;
      this.property_meta.ItemHeight = 40;
      this.property_meta.ItemIndent = 40;
      this.property_meta.Location = new System.Drawing.Point(5, 69);
      this.property_meta.Name = "property_meta";
      this.property_meta.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
      this.property_meta.ShowItemToolTips = false;
      this.property_meta.Size = new System.Drawing.Size(370, 198);
      this.property_meta.SortOrder = System.Windows.Forms.SortOrder.Ascending;
      this.property_meta.TabIndex = 2;
      // 
      // radCommandBar1
      // 
      this.radCommandBar1.Dock = System.Windows.Forms.DockStyle.Top;
      this.radCommandBar1.Location = new System.Drawing.Point(5, 25);
      this.radCommandBar1.Name = "radCommandBar1";
      this.radCommandBar1.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement1});
      this.radCommandBar1.Size = new System.Drawing.Size(370, 44);
      this.radCommandBar1.TabIndex = 3;
      // 
      // commandBarRowElement1
      // 
      this.commandBarRowElement1.MinSize = new System.Drawing.Size(25, 25);
      this.commandBarRowElement1.Name = "commandBarRowElement1";
      this.commandBarRowElement1.Strips.AddRange(new Telerik.WinControls.UI.CommandBarStripElement[] {
            this.commandBarStripElement1});
      // 
      // commandBarStripElement1
      // 
      this.commandBarStripElement1.DisplayName = "commandBarStripElement1";
      this.commandBarStripElement1.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.btn_settings_load,
            this.btn_settings_save,
            this.btn_settings_saveas});
      this.commandBarStripElement1.Name = "commandBarStripElement1";
      // 
      // btn_settings_load
      // 
      this.btn_settings_load.DisplayName = "commandBarButton1";
      this.btn_settings_load.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.folder_open;
      this.btn_settings_load.Name = "btn_settings_load";
      this.btn_settings_load.Text = "Laden";
      this.btn_settings_load.Click += new System.EventHandler(this.btn_settings_load_Click);
      // 
      // btn_settings_save
      // 
      this.btn_settings_save.DisplayName = "commandBarButton2";
      this.btn_settings_save.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.save;
      this.btn_settings_save.Name = "btn_settings_save";
      this.btn_settings_save.Text = "Speichern";
      this.btn_settings_save.Click += new System.EventHandler(this.btn_settings_save_Click);
      // 
      // btn_settings_saveas
      // 
      this.btn_settings_saveas.DisplayName = "commandBarButton1";
      this.btn_settings_saveas.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.save_all;
      this.btn_settings_saveas.Name = "btn_settings_saveas";
      this.btn_settings_saveas.Text = "Speichern unter...";
      this.btn_settings_saveas.Click += new System.EventHandler(this.btn_settings_saveas_Click);
      // 
      // settings_group_parameter
      // 
      this.settings_group_parameter.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.settings_group_parameter.Controls.Add(this.clearPanel9);
      this.settings_group_parameter.Controls.Add(this.clearPanel8);
      this.settings_group_parameter.Controls.Add(this.clearPanel4);
      this.settings_group_parameter.Dock = System.Windows.Forms.DockStyle.Top;
      this.settings_group_parameter.HeaderText = "Parameter";
      this.settings_group_parameter.Location = new System.Drawing.Point(0, 0);
      this.settings_group_parameter.Name = "settings_group_parameter";
      this.settings_group_parameter.Padding = new System.Windows.Forms.Padding(10, 25, 10, 10);
      // 
      // 
      // 
      this.settings_group_parameter.RootElement.MaxSize = new System.Drawing.Size(0, 0);
      this.settings_group_parameter.Size = new System.Drawing.Size(380, 142);
      this.settings_group_parameter.TabIndex = 19;
      this.settings_group_parameter.Text = "Parameter";
      // 
      // clearPanel9
      // 
      this.clearPanel9.Controls.Add(this.settings_frequenz_min);
      this.clearPanel9.Controls.Add(this.radLabel5);
      this.clearPanel9.Controls.Add(this.infoButton3);
      this.clearPanel9.Dock = System.Windows.Forms.DockStyle.Top;
      this.clearPanel9.Location = new System.Drawing.Point(10, 97);
      this.clearPanel9.Name = "clearPanel9";
      this.clearPanel9.Size = new System.Drawing.Size(360, 36);
      this.clearPanel9.TabIndex = 24;
      // 
      // settings_frequenz_min
      // 
      this.settings_frequenz_min.Dock = System.Windows.Forms.DockStyle.Fill;
      this.settings_frequenz_min.Location = new System.Drawing.Point(92, 0);
      this.settings_frequenz_min.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
      this.settings_frequenz_min.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.settings_frequenz_min.MinimumSize = new System.Drawing.Size(0, 33);
      this.settings_frequenz_min.Name = "settings_frequenz_min";
      this.settings_frequenz_min.NullableValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
      // 
      // 
      // 
      this.settings_frequenz_min.RootElement.MaxSize = new System.Drawing.Size(0, 0);
      this.settings_frequenz_min.RootElement.MinSize = new System.Drawing.Size(0, 33);
      this.settings_frequenz_min.Size = new System.Drawing.Size(235, 33);
      this.settings_frequenz_min.TabIndex = 13;
      this.settings_frequenz_min.TabStop = false;
      this.settings_frequenz_min.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.settings_frequenz_min.ValueChanged += new System.EventHandler(this.settings_frequenz_min_ValueChanged);
      // 
      // radLabel5
      // 
      this.radLabel5.AutoSize = false;
      this.radLabel5.Dock = System.Windows.Forms.DockStyle.Left;
      this.radLabel5.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.radLabel5.Location = new System.Drawing.Point(0, 0);
      this.radLabel5.Name = "radLabel5";
      this.radLabel5.Size = new System.Drawing.Size(92, 36);
      this.radLabel5.TabIndex = 20;
      this.radLabel5.Text = "Frequenz (Minimum):";
      this.radLabel5.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
      // 
      // infoButton3
      // 
      this.infoButton3.Dock = System.Windows.Forms.DockStyle.Right;
      this.infoButton3.Image = ((System.Drawing.Image)(resources.GetObject("infoButton3.Image")));
      this.infoButton3.InfoDescribtion = resources.GetString("infoButton3.InfoDescribtion");
      this.infoButton3.InfoHeader = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.MinimumFilterFrequenz;
      this.infoButton3.InfoImage = null;
      this.infoButton3.Location = new System.Drawing.Point(327, 0);
      this.infoButton3.MaximumSize = new System.Drawing.Size(33, 33);
      this.infoButton3.MinimumSize = new System.Drawing.Size(33, 33);
      this.infoButton3.Name = "infoButton3";
      // 
      // 
      // 
      this.infoButton3.RootElement.MaxSize = new System.Drawing.Size(33, 33);
      this.infoButton3.RootElement.MinSize = new System.Drawing.Size(33, 33);
      this.infoButton3.Size = new System.Drawing.Size(33, 33);
      this.infoButton3.TabIndex = 14;
      // 
      // clearPanel8
      // 
      this.clearPanel8.Controls.Add(this.settings_signifikanz_min);
      this.clearPanel8.Controls.Add(this.radLabel3);
      this.clearPanel8.Controls.Add(this.infoButton2);
      this.clearPanel8.Dock = System.Windows.Forms.DockStyle.Top;
      this.clearPanel8.Location = new System.Drawing.Point(10, 61);
      this.clearPanel8.Name = "clearPanel8";
      this.clearPanel8.Size = new System.Drawing.Size(360, 36);
      this.clearPanel8.TabIndex = 23;
      // 
      // settings_signifikanz_min
      // 
      this.settings_signifikanz_min.DecimalPlaces = 2;
      this.settings_signifikanz_min.Dock = System.Windows.Forms.DockStyle.Fill;
      this.settings_signifikanz_min.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
      this.settings_signifikanz_min.Location = new System.Drawing.Point(92, 0);
      this.settings_signifikanz_min.MinimumSize = new System.Drawing.Size(110, 33);
      this.settings_signifikanz_min.Name = "settings_signifikanz_min";
      // 
      // 
      // 
      this.settings_signifikanz_min.RootElement.MaxSize = new System.Drawing.Size(0, 0);
      this.settings_signifikanz_min.RootElement.MinSize = new System.Drawing.Size(110, 33);
      this.settings_signifikanz_min.Size = new System.Drawing.Size(235, 33);
      this.settings_signifikanz_min.TabIndex = 20;
      this.settings_signifikanz_min.TabStop = false;
      this.settings_signifikanz_min.ValueChanged += new System.EventHandler(this.settings_signifikanz_min_ValueChanged);
      // 
      // radLabel3
      // 
      this.radLabel3.AutoSize = false;
      this.radLabel3.Dock = System.Windows.Forms.DockStyle.Left;
      this.radLabel3.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.radLabel3.Location = new System.Drawing.Point(0, 0);
      this.radLabel3.Name = "radLabel3";
      this.radLabel3.Size = new System.Drawing.Size(92, 36);
      this.radLabel3.TabIndex = 19;
      this.radLabel3.Text = "Signifikanz (Minimum):";
      this.radLabel3.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
      // 
      // infoButton2
      // 
      this.infoButton2.Dock = System.Windows.Forms.DockStyle.Right;
      this.infoButton2.Image = ((System.Drawing.Image)(resources.GetObject("infoButton2.Image")));
      this.infoButton2.InfoDescribtion = resources.GetString("infoButton2.InfoDescribtion");
      this.infoButton2.InfoHeader = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.MinimumFilterSignifikanz;
      this.infoButton2.InfoImage = null;
      this.infoButton2.Location = new System.Drawing.Point(327, 0);
      this.infoButton2.MaximumSize = new System.Drawing.Size(33, 33);
      this.infoButton2.MinimumSize = new System.Drawing.Size(33, 33);
      this.infoButton2.Name = "infoButton2";
      // 
      // 
      // 
      this.infoButton2.RootElement.MaxSize = new System.Drawing.Size(33, 33);
      this.infoButton2.RootElement.MinSize = new System.Drawing.Size(33, 33);
      this.infoButton2.Size = new System.Drawing.Size(33, 33);
      this.infoButton2.TabIndex = 21;
      // 
      // clearPanel4
      // 
      this.clearPanel4.Controls.Add(this.settings_drop_signifikanz);
      this.clearPanel4.Controls.Add(this.radLabel2);
      this.clearPanel4.Controls.Add(this.infoButton1);
      this.clearPanel4.Dock = System.Windows.Forms.DockStyle.Top;
      this.clearPanel4.Location = new System.Drawing.Point(10, 25);
      this.clearPanel4.Name = "clearPanel4";
      this.clearPanel4.Size = new System.Drawing.Size(360, 36);
      this.clearPanel4.TabIndex = 22;
      // 
      // settings_drop_signifikanz
      // 
      this.settings_drop_signifikanz.AutoCompleteDisplayMember = null;
      this.settings_drop_signifikanz.AutoCompleteValueMember = null;
      this.settings_drop_signifikanz.Dock = System.Windows.Forms.DockStyle.Fill;
      this.settings_drop_signifikanz.Location = new System.Drawing.Point(92, 0);
      this.settings_drop_signifikanz.MinimumSize = new System.Drawing.Size(200, 33);
      this.settings_drop_signifikanz.Name = "settings_drop_signifikanz";
      this.settings_drop_signifikanz.NullText = "Signifikanzmaß auswählen...";
      this.settings_drop_signifikanz.Size = new System.Drawing.Size(235, 33);
      this.settings_drop_signifikanz.TabIndex = 11;
      this.settings_drop_signifikanz.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.settings_drop_signifikanz_SelectedIndexChanged);
      // 
      // radLabel2
      // 
      this.radLabel2.AutoSize = false;
      this.radLabel2.Dock = System.Windows.Forms.DockStyle.Left;
      this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.radLabel2.Location = new System.Drawing.Point(0, 0);
      this.radLabel2.Name = "radLabel2";
      this.radLabel2.Size = new System.Drawing.Size(92, 36);
      this.radLabel2.TabIndex = 18;
      this.radLabel2.Text = "Signifikanzmaß:";
      // 
      // infoButton1
      // 
      this.infoButton1.Dock = System.Windows.Forms.DockStyle.Right;
      this.infoButton1.Image = ((System.Drawing.Image)(resources.GetObject("infoButton1.Image")));
      this.infoButton1.InfoDescribtion = resources.GetString("infoButton1.InfoDescribtion");
      this.infoButton1.InfoHeader = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Signifikanzmaß;
      this.infoButton1.InfoImage = null;
      this.infoButton1.Location = new System.Drawing.Point(327, 0);
      this.infoButton1.MaximumSize = new System.Drawing.Size(33, 33);
      this.infoButton1.MinimumSize = new System.Drawing.Size(33, 33);
      this.infoButton1.Name = "infoButton1";
      // 
      // 
      // 
      this.infoButton1.RootElement.MaxSize = new System.Drawing.Size(33, 33);
      this.infoButton1.RootElement.MinSize = new System.Drawing.Size(33, 33);
      this.infoButton1.Size = new System.Drawing.Size(33, 33);
      this.infoButton1.TabIndex = 12;
      // 
      // splitPanel4
      // 
      this.splitPanel4.Controls.Add(this.radSplitContainer3);
      this.splitPanel4.Controls.Add(this.radGroupBox8);
      this.splitPanel4.Location = new System.Drawing.Point(384, 0);
      this.splitPanel4.Name = "splitPanel4";
      // 
      // 
      // 
      this.splitPanel4.RootElement.MinSize = new System.Drawing.Size(0, 0);
      this.splitPanel4.Size = new System.Drawing.Size(446, 414);
      this.splitPanel4.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(0.03995156F, 0F);
      this.splitPanel4.SizeInfo.SplitterCorrection = new System.Drawing.Size(33, 0);
      this.splitPanel4.TabIndex = 1;
      this.splitPanel4.TabStop = false;
      this.splitPanel4.Text = "splitPanel4";
      // 
      // radSplitContainer3
      // 
      this.radSplitContainer3.Controls.Add(this.splitPanel5);
      this.radSplitContainer3.Controls.Add(this.splitPanel6);
      this.radSplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radSplitContainer3.Location = new System.Drawing.Point(0, 0);
      this.radSplitContainer3.Name = "radSplitContainer3";
      // 
      // 
      // 
      this.radSplitContainer3.RootElement.MinSize = new System.Drawing.Size(25, 25);
      this.radSplitContainer3.Size = new System.Drawing.Size(446, 314);
      this.radSplitContainer3.TabIndex = 32;
      this.radSplitContainer3.TabStop = false;
      // 
      // splitPanel5
      // 
      this.splitPanel5.Controls.Add(this.radGroupBox4);
      this.splitPanel5.Location = new System.Drawing.Point(0, 0);
      this.splitPanel5.Name = "splitPanel5";
      // 
      // 
      // 
      this.splitPanel5.RootElement.MinSize = new System.Drawing.Size(25, 25);
      this.splitPanel5.Size = new System.Drawing.Size(154, 314);
      this.splitPanel5.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(-0.1515837F, 0F);
      this.splitPanel5.SizeInfo.SplitterCorrection = new System.Drawing.Size(-60, 0);
      this.splitPanel5.TabIndex = 0;
      this.splitPanel5.TabStop = false;
      this.splitPanel5.Text = "splitPanel5";
      // 
      // radGroupBox4
      // 
      this.radGroupBox4.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox4.Controls.Add(this.radScrollablePanel6);
      this.radGroupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radGroupBox4.HeaderText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Werkzeuge;
      this.radGroupBox4.Location = new System.Drawing.Point(0, 0);
      this.radGroupBox4.Name = "radGroupBox4";
      this.radGroupBox4.Padding = new System.Windows.Forms.Padding(5, 25, 5, 5);
      this.radGroupBox4.Size = new System.Drawing.Size(154, 314);
      this.radGroupBox4.TabIndex = 30;
      this.radGroupBox4.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Werkzeuge;
      // 
      // radScrollablePanel6
      // 
      this.radScrollablePanel6.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radScrollablePanel6.Location = new System.Drawing.Point(5, 25);
      this.radScrollablePanel6.Name = "radScrollablePanel6";
      // 
      // radScrollablePanel6.PanelContainer
      // 
      this.radScrollablePanel6.PanelContainer.Controls.Add(this.settings_tool_totalReset);
      this.radScrollablePanel6.PanelContainer.Controls.Add(this.settings_tool_upgrade);
      this.radScrollablePanel6.PanelContainer.Controls.Add(this.settings_tool_xpath);
      this.radScrollablePanel6.PanelContainer.Controls.Add(this.settings_tool_mergeCorpora);
      this.radScrollablePanel6.PanelContainer.Controls.Add(this.settings_tool_additionalTagger);
      this.radScrollablePanel6.PanelContainer.Controls.Add(this.settings_tool_exportCorpus);
      this.radScrollablePanel6.PanelContainer.Controls.Add(this.settings_tool_testCorpus);
      this.radScrollablePanel6.PanelContainer.Controls.Add(this.settings_tool_eraseCache);
      this.radScrollablePanel6.PanelContainer.Controls.Add(this.settings_tool_errorconsole);
      this.radScrollablePanel6.PanelContainer.Padding = new System.Windows.Forms.Padding(5);
      this.radScrollablePanel6.PanelContainer.Size = new System.Drawing.Size(106, 282);
      this.radScrollablePanel6.Size = new System.Drawing.Size(144, 284);
      this.radScrollablePanel6.TabIndex = 3;
      // 
      // settings_tool_totalReset
      // 
      this.settings_tool_totalReset.Dock = System.Windows.Forms.DockStyle.Top;
      this.settings_tool_totalReset.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.settings_tool_totalReset.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.reload_rotate1;
      this.settings_tool_totalReset.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
      this.settings_tool_totalReset.Location = new System.Drawing.Point(5, 709);
      this.settings_tool_totalReset.Name = "settings_tool_totalReset";
      this.settings_tool_totalReset.Size = new System.Drawing.Size(96, 88);
      this.settings_tool_totalReset.TabIndex = 9;
      this.settings_tool_totalReset.Text = "<html>CorpusExplorer<br />zurücksetzen</html>";
      this.settings_tool_totalReset.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
      this.settings_tool_totalReset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.settings_tool_totalReset.TextWrap = true;
      this.settings_tool_totalReset.Click += new System.EventHandler(this.settings_tool_totalReset_Click);
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_totalReset.GetChildAt(0))).Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.reload_rotate1;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_totalReset.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_totalReset.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_totalReset.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_totalReset.GetChildAt(0))).Text = "<html>CorpusExplorer<br />zurücksetzen</html>";
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_totalReset.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextWrap = true;
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_totalReset.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = true;
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_totalReset.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Segoe UI", 9F);
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_totalReset.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.BottomCenter;
      // 
      // settings_tool_upgrade
      // 
      this.settings_tool_upgrade.Dock = System.Windows.Forms.DockStyle.Top;
      this.settings_tool_upgrade.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.settings_tool_upgrade.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.upload;
      this.settings_tool_upgrade.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
      this.settings_tool_upgrade.Location = new System.Drawing.Point(5, 621);
      this.settings_tool_upgrade.Name = "settings_tool_upgrade";
      this.settings_tool_upgrade.Size = new System.Drawing.Size(96, 88);
      this.settings_tool_upgrade.TabIndex = 0;
      this.settings_tool_upgrade.Text = "Alte Korpora upgraden";
      this.settings_tool_upgrade.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.settings_tool_upgrade.TextWrap = true;
      this.settings_tool_upgrade.Click += new System.EventHandler(this.settings_upgrade_btn_Click);
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_upgrade.GetChildAt(0))).Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.upload;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_upgrade.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_upgrade.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_upgrade.GetChildAt(0))).Text = "Alte Korpora upgraden";
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_upgrade.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextWrap = true;
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_upgrade.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = true;
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_upgrade.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Segoe UI", 9F);
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_upgrade.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // settings_tool_xpath
      // 
      this.settings_tool_xpath.Dock = System.Windows.Forms.DockStyle.Top;
      this.settings_tool_xpath.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.settings_tool_xpath.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.xml_root;
      this.settings_tool_xpath.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
      this.settings_tool_xpath.Location = new System.Drawing.Point(5, 533);
      this.settings_tool_xpath.Name = "settings_tool_xpath";
      this.settings_tool_xpath.Size = new System.Drawing.Size(96, 88);
      this.settings_tool_xpath.TabIndex = 8;
      this.settings_tool_xpath.Text = "<html>XPath<br />Browser</html>";
      this.settings_tool_xpath.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
      this.settings_tool_xpath.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.settings_tool_xpath.TextWrap = true;
      this.settings_tool_xpath.Click += new System.EventHandler(this.settings_tool_xpath_Click);
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_xpath.GetChildAt(0))).Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.xml_root;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_xpath.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_xpath.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_xpath.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_xpath.GetChildAt(0))).Text = "<html>XPath<br />Browser</html>";
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_xpath.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextWrap = true;
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_xpath.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = true;
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_xpath.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Segoe UI", 9F);
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_xpath.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.BottomCenter;
      // 
      // settings_tool_mergeCorpora
      // 
      this.settings_tool_mergeCorpora.Dock = System.Windows.Forms.DockStyle.Top;
      this.settings_tool_mergeCorpora.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.settings_tool_mergeCorpora.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.table_merge_columns1;
      this.settings_tool_mergeCorpora.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
      this.settings_tool_mergeCorpora.Location = new System.Drawing.Point(5, 445);
      this.settings_tool_mergeCorpora.Name = "settings_tool_mergeCorpora";
      this.settings_tool_mergeCorpora.Size = new System.Drawing.Size(96, 88);
      this.settings_tool_mergeCorpora.TabIndex = 4;
      this.settings_tool_mergeCorpora.Text = "Korpora vereinen";
      this.settings_tool_mergeCorpora.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
      this.settings_tool_mergeCorpora.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.settings_tool_mergeCorpora.TextWrap = true;
      this.settings_tool_mergeCorpora.Click += new System.EventHandler(this.settings_tool_mergeCorpora_Click);
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_mergeCorpora.GetChildAt(0))).Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.table_merge_columns1;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_mergeCorpora.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_mergeCorpora.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_mergeCorpora.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_mergeCorpora.GetChildAt(0))).Text = "Korpora vereinen";
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_mergeCorpora.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextWrap = true;
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_mergeCorpora.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = true;
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_mergeCorpora.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Segoe UI", 9F);
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_mergeCorpora.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.BottomCenter;
      // 
      // settings_tool_additionalTagger
      // 
      this.settings_tool_additionalTagger.Dock = System.Windows.Forms.DockStyle.Top;
      this.settings_tool_additionalTagger.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.settings_tool_additionalTagger.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.tag_green1;
      this.settings_tool_additionalTagger.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
      this.settings_tool_additionalTagger.Location = new System.Drawing.Point(5, 357);
      this.settings_tool_additionalTagger.Name = "settings_tool_additionalTagger";
      this.settings_tool_additionalTagger.Size = new System.Drawing.Size(96, 88);
      this.settings_tool_additionalTagger.TabIndex = 7;
      this.settings_tool_additionalTagger.Text = "Zusätzliche Annotation";
      this.settings_tool_additionalTagger.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
      this.settings_tool_additionalTagger.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.settings_tool_additionalTagger.TextWrap = true;
      this.settings_tool_additionalTagger.Click += new System.EventHandler(this.settings_tool_additionalTagger_Click);
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_additionalTagger.GetChildAt(0))).Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.tag_green1;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_additionalTagger.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_additionalTagger.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_additionalTagger.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_additionalTagger.GetChildAt(0))).Text = "Zusätzliche Annotation";
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_additionalTagger.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextWrap = true;
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_additionalTagger.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = true;
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_additionalTagger.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Segoe UI", 9F);
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_additionalTagger.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.BottomCenter;
      // 
      // settings_tool_exportCorpus
      // 
      this.settings_tool_exportCorpus.Dock = System.Windows.Forms.DockStyle.Top;
      this.settings_tool_exportCorpus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.settings_tool_exportCorpus.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.export_to_database;
      this.settings_tool_exportCorpus.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
      this.settings_tool_exportCorpus.Location = new System.Drawing.Point(5, 269);
      this.settings_tool_exportCorpus.Name = "settings_tool_exportCorpus";
      this.settings_tool_exportCorpus.Size = new System.Drawing.Size(96, 88);
      this.settings_tool_exportCorpus.TabIndex = 5;
      this.settings_tool_exportCorpus.Text = "Korpus exportieren";
      this.settings_tool_exportCorpus.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
      this.settings_tool_exportCorpus.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.settings_tool_exportCorpus.TextWrap = true;
      this.settings_tool_exportCorpus.Click += new System.EventHandler(this.settings_tool_exportCorpus_Click);
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_exportCorpus.GetChildAt(0))).Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.export_to_database;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_exportCorpus.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_exportCorpus.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_exportCorpus.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_exportCorpus.GetChildAt(0))).Text = "Korpus exportieren";
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_exportCorpus.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextWrap = true;
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_exportCorpus.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = true;
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_exportCorpus.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Segoe UI", 9F);
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_exportCorpus.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.BottomCenter;
      // 
      // settings_tool_testCorpus
      // 
      this.settings_tool_testCorpus.Dock = System.Windows.Forms.DockStyle.Top;
      this.settings_tool_testCorpus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.settings_tool_testCorpus.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.test_properties;
      this.settings_tool_testCorpus.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
      this.settings_tool_testCorpus.Location = new System.Drawing.Point(5, 181);
      this.settings_tool_testCorpus.Name = "settings_tool_testCorpus";
      this.settings_tool_testCorpus.Size = new System.Drawing.Size(96, 88);
      this.settings_tool_testCorpus.TabIndex = 6;
      this.settings_tool_testCorpus.Text = "Test-Korpus erzeugen";
      this.settings_tool_testCorpus.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
      this.settings_tool_testCorpus.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.settings_tool_testCorpus.TextWrap = true;
      this.settings_tool_testCorpus.Click += new System.EventHandler(this.settings_tool_testCorpus_Click);
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_testCorpus.GetChildAt(0))).Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.test_properties;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_testCorpus.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_testCorpus.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_testCorpus.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_testCorpus.GetChildAt(0))).Text = "Test-Korpus erzeugen";
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_testCorpus.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextWrap = true;
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_testCorpus.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = true;
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_testCorpus.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Segoe UI", 9F);
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_testCorpus.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.BottomCenter;
      // 
      // settings_tool_eraseCache
      // 
      this.settings_tool_eraseCache.Dock = System.Windows.Forms.DockStyle.Top;
      this.settings_tool_eraseCache.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.settings_tool_eraseCache.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.erase;
      this.settings_tool_eraseCache.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
      this.settings_tool_eraseCache.Location = new System.Drawing.Point(5, 93);
      this.settings_tool_eraseCache.Name = "settings_tool_eraseCache";
      this.settings_tool_eraseCache.Size = new System.Drawing.Size(96, 88);
      this.settings_tool_eraseCache.TabIndex = 3;
      this.settings_tool_eraseCache.Text = "Lösche Cachedaten";
      this.settings_tool_eraseCache.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
      this.settings_tool_eraseCache.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.settings_tool_eraseCache.TextWrap = true;
      this.settings_tool_eraseCache.Click += new System.EventHandler(this.settings_tool_eraseCache_Click);
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_eraseCache.GetChildAt(0))).Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.erase;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_eraseCache.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_eraseCache.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_eraseCache.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_eraseCache.GetChildAt(0))).Text = "Lösche Cachedaten";
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_eraseCache.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextWrap = true;
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_eraseCache.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = true;
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_eraseCache.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Segoe UI", 9F);
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_eraseCache.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.BottomCenter;
      // 
      // settings_tool_errorconsole
      // 
      this.settings_tool_errorconsole.Dock = System.Windows.Forms.DockStyle.Top;
      this.settings_tool_errorconsole.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.settings_tool_errorconsole.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.worker;
      this.settings_tool_errorconsole.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
      this.settings_tool_errorconsole.Location = new System.Drawing.Point(5, 5);
      this.settings_tool_errorconsole.Name = "settings_tool_errorconsole";
      this.settings_tool_errorconsole.Size = new System.Drawing.Size(96, 88);
      this.settings_tool_errorconsole.TabIndex = 2;
      this.settings_tool_errorconsole.Text = "Zeige Fehlerbericht";
      this.settings_tool_errorconsole.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
      this.settings_tool_errorconsole.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.settings_tool_errorconsole.TextWrap = true;
      this.settings_tool_errorconsole.Click += new System.EventHandler(this.settings_tool_errorconsole_Click);
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_errorconsole.GetChildAt(0))).Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.worker;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_errorconsole.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_errorconsole.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_errorconsole.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_errorconsole.GetChildAt(0))).Text = "Zeige Fehlerbericht";
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_errorconsole.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextWrap = true;
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_errorconsole.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = true;
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_errorconsole.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Segoe UI", 9F);
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_errorconsole.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.BottomCenter;
      // 
      // splitPanel6
      // 
      this.splitPanel6.Controls.Add(this.radGroupBox9);
      this.splitPanel6.Location = new System.Drawing.Point(158, 0);
      this.splitPanel6.Name = "splitPanel6";
      // 
      // 
      // 
      this.splitPanel6.RootElement.MinSize = new System.Drawing.Size(25, 25);
      this.splitPanel6.Size = new System.Drawing.Size(288, 314);
      this.splitPanel6.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(0.1515837F, 0F);
      this.splitPanel6.SizeInfo.SplitterCorrection = new System.Drawing.Size(60, 0);
      this.splitPanel6.TabIndex = 1;
      this.splitPanel6.TabStop = false;
      this.splitPanel6.Text = "splitPanel6";
      // 
      // radGroupBox9
      // 
      this.radGroupBox9.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox9.Controls.Add(this.settings_list_favorites);
      this.radGroupBox9.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radGroupBox9.HeaderText = "Favoriten";
      this.radGroupBox9.Location = new System.Drawing.Point(0, 0);
      this.radGroupBox9.Name = "radGroupBox9";
      this.radGroupBox9.Padding = new System.Windows.Forms.Padding(5, 25, 5, 5);
      this.radGroupBox9.Size = new System.Drawing.Size(288, 314);
      this.radGroupBox9.TabIndex = 0;
      this.radGroupBox9.Text = "Favoriten";
      // 
      // settings_list_favorites
      // 
      this.settings_list_favorites.Dock = System.Windows.Forms.DockStyle.Fill;
      this.settings_list_favorites.GroupItemSize = new System.Drawing.Size(200, 40);
      this.settings_list_favorites.ItemSize = new System.Drawing.Size(200, 40);
      this.settings_list_favorites.Location = new System.Drawing.Point(5, 25);
      this.settings_list_favorites.Name = "settings_list_favorites";
      this.settings_list_favorites.Size = new System.Drawing.Size(278, 284);
      this.settings_list_favorites.TabIndex = 0;
      this.settings_list_favorites.ItemCheckedChanged += new Telerik.WinControls.UI.ListViewItemEventHandler(this.settings_list_favorites_ItemCheckedChanged);
      // 
      // radGroupBox8
      // 
      this.radGroupBox8.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox8.Controls.Add(this.settings_insigt_id);
      this.radGroupBox8.Controls.Add(this.clearPanel12);
      this.radGroupBox8.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.radGroupBox8.HeaderText = "CorpusExplorer - Telemetrie";
      this.radGroupBox8.Location = new System.Drawing.Point(0, 314);
      this.radGroupBox8.Name = "radGroupBox8";
      this.radGroupBox8.Padding = new System.Windows.Forms.Padding(2, 25, 2, 2);
      this.radGroupBox8.Size = new System.Drawing.Size(446, 100);
      this.radGroupBox8.TabIndex = 31;
      this.radGroupBox8.Text = "CorpusExplorer - Telemetrie";
      // 
      // settings_insigt_id
      // 
      this.settings_insigt_id.Dock = System.Windows.Forms.DockStyle.Fill;
      this.settings_insigt_id.Location = new System.Drawing.Point(2, 25);
      this.settings_insigt_id.Name = "settings_insigt_id";
      this.settings_insigt_id.NullText = ".. :: Telemetrie deaktiviert :: ..";
      this.settings_insigt_id.ReadOnly = true;
      this.settings_insigt_id.Size = new System.Drawing.Size(442, 32);
      this.settings_insigt_id.TabIndex = 1;
      this.settings_insigt_id.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // clearPanel12
      // 
      this.clearPanel12.Controls.Add(this.settings_insight_info);
      this.clearPanel12.Controls.Add(this.settings_insight_renew);
      this.clearPanel12.Controls.Add(this.settings_insight_disable);
      this.clearPanel12.Controls.Add(this.settings_insight_enable);
      this.clearPanel12.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.clearPanel12.Location = new System.Drawing.Point(2, 60);
      this.clearPanel12.Name = "clearPanel12";
      this.clearPanel12.Size = new System.Drawing.Size(442, 38);
      this.clearPanel12.TabIndex = 0;
      // 
      // settings_insight_info
      // 
      this.settings_insight_info.Dock = System.Windows.Forms.DockStyle.Right;
      this.settings_insight_info.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.info;
      this.settings_insight_info.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
      this.settings_insight_info.Location = new System.Drawing.Point(74, 0);
      this.settings_insight_info.Name = "settings_insight_info";
      this.settings_insight_info.Size = new System.Drawing.Size(38, 38);
      this.settings_insight_info.TabIndex = 3;
      this.settings_insight_info.Click += new System.EventHandler(this.settings_insight_info_Click);
      // 
      // settings_insight_renew
      // 
      this.settings_insight_renew.Dock = System.Windows.Forms.DockStyle.Right;
      this.settings_insight_renew.Location = new System.Drawing.Point(112, 0);
      this.settings_insight_renew.Name = "settings_insight_renew";
      this.settings_insight_renew.Size = new System.Drawing.Size(110, 38);
      this.settings_insight_renew.TabIndex = 2;
      this.settings_insight_renew.Text = "Neue ID";
      this.settings_insight_renew.Click += new System.EventHandler(this.settings_insight_renew_Click);
      // 
      // settings_insight_disable
      // 
      this.settings_insight_disable.Dock = System.Windows.Forms.DockStyle.Right;
      this.settings_insight_disable.Location = new System.Drawing.Point(222, 0);
      this.settings_insight_disable.Name = "settings_insight_disable";
      this.settings_insight_disable.Size = new System.Drawing.Size(110, 38);
      this.settings_insight_disable.TabIndex = 1;
      this.settings_insight_disable.Text = "Deaktivieren";
      this.settings_insight_disable.Click += new System.EventHandler(this.settings_insight_disable_Click);
      // 
      // settings_insight_enable
      // 
      this.settings_insight_enable.Dock = System.Windows.Forms.DockStyle.Right;
      this.settings_insight_enable.Location = new System.Drawing.Point(332, 0);
      this.settings_insight_enable.Name = "settings_insight_enable";
      this.settings_insight_enable.Size = new System.Drawing.Size(110, 38);
      this.settings_insight_enable.TabIndex = 0;
      this.settings_insight_enable.Text = "Aktivieren";
      this.settings_insight_enable.Click += new System.EventHandler(this.settings_insight_enable_Click);
      // 
      // header10
      // 
      this.header10.BackColor = System.Drawing.Color.White;
      this.header10.Dock = System.Windows.Forms.DockStyle.Top;
      this.header10.Font = new System.Drawing.Font("Segoe UI", 11F);
      this.header10.HeaderDescribtion = resources.GetString("header10.HeaderDescribtion");
      this.header10.HeaderHead = "Projekteinstellungen";
      this.header10.Location = new System.Drawing.Point(0, 0);
      this.header10.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.header10.Name = "header10";
      this.header10.Size = new System.Drawing.Size(830, 74);
      this.header10.TabIndex = 28;
      // 
      // customShape1
      // 
      this.customShape1.Dimension = new System.Drawing.Rectangle(0, 0, 0, 0);
      // 
      // main_mainmenu_app
      // 
      this.main_mainmenu_app.AccessibleDescription = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Projekt;
      this.main_mainmenu_app.AccessibleName = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Projekt;
      this.main_mainmenu_app.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.CorpusExplorer1;
      this.main_mainmenu_app.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.main_mainmenu_project_new,
            this.main_mainmenu_project_load,
            this.main_mainmenu_project_save,
            this.main_mainmenu_project_saveas,
            this.radMenuSeparatorItem6,
            this.main_mainmenu_project_settings,
            this.radMenuSeparatorItem1,
            this.main_mainmenu_exit});
      this.main_mainmenu_app.Margin = new System.Windows.Forms.Padding(10, 0, 25, 0);
      this.main_mainmenu_app.Name = "main_mainmenu_app";
      this.main_mainmenu_app.Padding = new System.Windows.Forms.Padding(7);
      this.main_mainmenu_app.ShowArrow = false;
      this.main_mainmenu_app.Text = "";
      this.main_mainmenu_app.ToolTipText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.CorpusExplorerHauptmenü;
      // 
      // main_mainmenu_project_new
      // 
      this.main_mainmenu_project_new.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.document;
      this.main_mainmenu_project_new.Name = "main_mainmenu_project_new";
      this.main_mainmenu_project_new.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.NeuesProjekt;
      this.main_mainmenu_project_new.Click += new System.EventHandler(this.main_mainmenu_project_new_Click);
      // 
      // main_mainmenu_project_load
      // 
      this.main_mainmenu_project_load.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.folder_open;
      this.main_mainmenu_project_load.Name = "main_mainmenu_project_load";
      this.main_mainmenu_project_load.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.ProjektLaden;
      this.main_mainmenu_project_load.Click += new System.EventHandler(this.main_mainmenu_project_load_Click);
      // 
      // main_mainmenu_project_save
      // 
      this.main_mainmenu_project_save.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.save;
      this.main_mainmenu_project_save.Name = "main_mainmenu_project_save";
      this.main_mainmenu_project_save.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.ProjektSpeichern;
      this.main_mainmenu_project_save.Click += new System.EventHandler(this.main_mainmenu_project_save_Click);
      // 
      // main_mainmenu_project_saveas
      // 
      this.main_mainmenu_project_saveas.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.save_all;
      this.main_mainmenu_project_saveas.Name = "main_mainmenu_project_saveas";
      this.main_mainmenu_project_saveas.Text = "Projekt speichern unter";
      this.main_mainmenu_project_saveas.Click += new System.EventHandler(this.main_mainmenu_project_saveas_Click);
      // 
      // radMenuSeparatorItem6
      // 
      this.radMenuSeparatorItem6.Name = "radMenuSeparatorItem6";
      this.radMenuSeparatorItem6.Text = "radMenuSeparatorItem6";
      this.radMenuSeparatorItem6.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // main_mainmenu_project_settings
      // 
      this.main_mainmenu_project_settings.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.gear;
      this.main_mainmenu_project_settings.Name = "main_mainmenu_project_settings";
      this.main_mainmenu_project_settings.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Projekteinstellungen;
      this.main_mainmenu_project_settings.Click += new System.EventHandler(this.main_mainmenu_project_settings_Click);
      // 
      // radMenuSeparatorItem1
      // 
      this.radMenuSeparatorItem1.Name = "radMenuSeparatorItem1";
      this.radMenuSeparatorItem1.Text = "radMenuSeparatorItem1";
      this.radMenuSeparatorItem1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // main_mainmenu_exit
      // 
      this.main_mainmenu_exit.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.close_window;
      this.main_mainmenu_exit.Name = "main_mainmenu_exit";
      this.main_mainmenu_exit.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Beenden;
      this.main_mainmenu_exit.Click += new System.EventHandler(this.main_mainmenu_exit_Click);
      // 
      // main_mainmenu_home
      // 
      this.main_mainmenu_home.Image = ((System.Drawing.Image)(resources.GetObject("main_mainmenu_home.Image")));
      this.main_mainmenu_home.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
      this.main_mainmenu_home.Name = "main_mainmenu_home";
      this.main_mainmenu_home.Padding = new System.Windows.Forms.Padding(7);
      this.main_mainmenu_home.Text = "";
      this.main_mainmenu_home.ToolTipText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.StartseiteZeigtDieStartseiteAn;
      this.main_mainmenu_home.Click += new System.EventHandler(this.main_mainmenu_home_Click);
      // 
      // main_mainmenu_corpus
      // 
      this.main_mainmenu_corpus.Image = ((System.Drawing.Image)(resources.GetObject("main_mainmenu_corpus.Image")));
      this.main_mainmenu_corpus.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.main_mainmenu_corpus_overview,
            this.radMenuSeparatorItem3,
            this.main_mainmenu_corpus_load,
            this.main_mainmenu_corpus_files,
            this.main_mainmenu_corpus_import,
            this.main_mainmenu_corpus_online});
      this.main_mainmenu_corpus.Margin = new System.Windows.Forms.Padding(0);
      this.main_mainmenu_corpus.Name = "main_mainmenu_corpus";
      this.main_mainmenu_corpus.Padding = new System.Windows.Forms.Padding(7);
      this.main_mainmenu_corpus.Text = "";
      this.main_mainmenu_corpus.ToolTipText = "Korpora";
      // 
      // main_mainmenu_corpus_overview
      // 
      this.main_mainmenu_corpus_overview.AccessibleDescription = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.KorporaHauptseite;
      this.main_mainmenu_corpus_overview.AccessibleName = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.KorporaHauptseite;
      this.main_mainmenu_corpus_overview.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.eye;
      this.main_mainmenu_corpus_overview.Name = "main_mainmenu_corpus_overview";
      this.main_mainmenu_corpus_overview.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.KorporaÜbersicht;
      this.main_mainmenu_corpus_overview.Click += new System.EventHandler(this.main_mainmenu_corpus_Click);
      // 
      // radMenuSeparatorItem3
      // 
      this.radMenuSeparatorItem3.Name = "radMenuSeparatorItem3";
      this.radMenuSeparatorItem3.Text = "radMenuSeparatorItem3";
      this.radMenuSeparatorItem3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // main_mainmenu_corpus_load
      // 
      this.main_mainmenu_corpus_load.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.cabinet1;
      this.main_mainmenu_corpus_load.Name = "main_mainmenu_corpus_load";
      this.main_mainmenu_corpus_load.Text = "Existierendes Korpus laden";
      // 
      // main_mainmenu_corpus_files
      // 
      this.main_mainmenu_corpus_files.AccessibleDescription = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.KorpusErstellen;
      this.main_mainmenu_corpus_files.AccessibleName = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.KorpusErstellen;
      this.main_mainmenu_corpus_files.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.folder_open;
      this.main_mainmenu_corpus_files.Name = "main_mainmenu_corpus_files";
      this.main_mainmenu_corpus_files.Text = "Dokumente annotieren";
      this.main_mainmenu_corpus_files.Click += new System.EventHandler(this.corpus_start_local_Click);
      // 
      // main_mainmenu_corpus_import
      // 
      this.main_mainmenu_corpus_import.AccessibleDescription = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.ImpotiereKorpus;
      this.main_mainmenu_corpus_import.AccessibleName = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.ImpotiereKorpus;
      this.main_mainmenu_corpus_import.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.shipment1;
      this.main_mainmenu_corpus_import.Name = "main_mainmenu_corpus_import";
      this.main_mainmenu_corpus_import.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.KorpusImportieren;
      this.main_mainmenu_corpus_import.Click += new System.EventHandler(this.corpus_start_import_Click);
      // 
      // main_mainmenu_corpus_online
      // 
      this.main_mainmenu_corpus_online.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.internet;
      this.main_mainmenu_corpus_online.Name = "main_mainmenu_corpus_online";
      this.main_mainmenu_corpus_online.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.OnlineKorpusAkquirieren;
      this.main_mainmenu_corpus_online.Click += new System.EventHandler(this.corpus_start_online_Click);
      // 
      // main_mainmenu_snapshot
      // 
      this.main_mainmenu_snapshot.Image = ((System.Drawing.Image)(resources.GetObject("main_mainmenu_snapshot.Image")));
      this.main_mainmenu_snapshot.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.main_mainmenu_snapshot_overview,
            this.radMenuSeparatorItem4,
            this.main_mainmenu_snapshot_availabel,
            this.main_mainmenu_snapshot_new,
            this.main_mainmenu_snapshot_addsub});
      this.main_mainmenu_snapshot.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
      this.main_mainmenu_snapshot.Name = "main_mainmenu_snapshot";
      this.main_mainmenu_snapshot.Padding = new System.Windows.Forms.Padding(7);
      this.main_mainmenu_snapshot.Text = "";
      this.main_mainmenu_snapshot.ToolTipText = "Schnappschüsse";
      // 
      // main_mainmenu_snapshot_overview
      // 
      this.main_mainmenu_snapshot_overview.AccessibleDescription = "radMenuItem1";
      this.main_mainmenu_snapshot_overview.AccessibleName = "radMenuItem1";
      this.main_mainmenu_snapshot_overview.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.eye;
      this.main_mainmenu_snapshot_overview.Name = "main_mainmenu_snapshot_overview";
      this.main_mainmenu_snapshot_overview.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.SchnappschussÜbersicht;
      this.main_mainmenu_snapshot_overview.Click += new System.EventHandler(this.main_mainmenu_snapshot_Click);
      // 
      // radMenuSeparatorItem4
      // 
      this.radMenuSeparatorItem4.Name = "radMenuSeparatorItem4";
      this.radMenuSeparatorItem4.Text = "radMenuSeparatorItem4";
      this.radMenuSeparatorItem4.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // main_mainmenu_snapshot_availabel
      // 
      this.main_mainmenu_snapshot_availabel.AccessibleDescription = "radMenuItem2";
      this.main_mainmenu_snapshot_availabel.AccessibleName = "radMenuItem2";
      this.main_mainmenu_snapshot_availabel.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.camera1;
      this.main_mainmenu_snapshot_availabel.Name = "main_mainmenu_snapshot_availabel";
      this.main_mainmenu_snapshot_availabel.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.VerfügbareSchnappschüsse;
      // 
      // main_mainmenu_snapshot_new
      // 
      this.main_mainmenu_snapshot_new.AccessibleDescription = "radMenuItem4";
      this.main_mainmenu_snapshot_new.AccessibleName = "radMenuItem4";
      this.main_mainmenu_snapshot_new.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.add_button;
      this.main_mainmenu_snapshot_new.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.main_mainmenu_snapshot_new_custom,
            this.main_mainmenu_snapshot_new_autosplit,
            this.main_mainmenu_snapshot_new_random});
      this.main_mainmenu_snapshot_new.Name = "main_mainmenu_snapshot_new";
      this.main_mainmenu_snapshot_new.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.NeuenSchnappschussErstellen;
      // 
      // main_mainmenu_snapshot_new_custom
      // 
      this.main_mainmenu_snapshot_new_custom.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.add_button;
      this.main_mainmenu_snapshot_new_custom.Name = "main_mainmenu_snapshot_new_custom";
      this.main_mainmenu_snapshot_new_custom.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Individuell;
      this.main_mainmenu_snapshot_new_custom.Click += new System.EventHandler(this.page_analytics_snapshot_btn_snapshot_add_individual_Click);
      // 
      // main_mainmenu_snapshot_new_autosplit
      // 
      this.main_mainmenu_snapshot_new_autosplit.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.add_button;
      this.main_mainmenu_snapshot_new_autosplit.Name = "main_mainmenu_snapshot_new_autosplit";
      this.main_mainmenu_snapshot_new_autosplit.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Autosplit;
      this.main_mainmenu_snapshot_new_autosplit.Click += new System.EventHandler(this.page_analytics_snapshot_btn_snapshot_add_metasplit_Click);
      // 
      // main_mainmenu_snapshot_new_random
      // 
      this.main_mainmenu_snapshot_new_random.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.add_button;
      this.main_mainmenu_snapshot_new_random.Name = "main_mainmenu_snapshot_new_random";
      this.main_mainmenu_snapshot_new_random.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Zufällig;
      this.main_mainmenu_snapshot_new_random.Click += new System.EventHandler(this.page_analytics_snapshot_btn_snapshot_add_random_Click);
      // 
      // main_mainmenu_snapshot_addsub
      // 
      this.main_mainmenu_snapshot_addsub.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.button_green_record;
      this.main_mainmenu_snapshot_addsub.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.main_mainmenu_snapshot_addsub_custom,
            this.main_mainmenu_snapshot_addsub_autosplit,
            this.main_mainmenu_snapshot_addsub_random});
      this.main_mainmenu_snapshot_addsub.Name = "main_mainmenu_snapshot_addsub";
      this.main_mainmenu_snapshot_addsub.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.AktuellenSchnappschussEingrenzen;
      // 
      // main_mainmenu_snapshot_addsub_custom
      // 
      this.main_mainmenu_snapshot_addsub_custom.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.button_green_record;
      this.main_mainmenu_snapshot_addsub_custom.Name = "main_mainmenu_snapshot_addsub_custom";
      this.main_mainmenu_snapshot_addsub_custom.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Individuell;
      this.main_mainmenu_snapshot_addsub_custom.Click += new System.EventHandler(this.page_analytics_snapshot_btn_snapshot_mask_individual_Click);
      // 
      // main_mainmenu_snapshot_addsub_autosplit
      // 
      this.main_mainmenu_snapshot_addsub_autosplit.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.button_green_record;
      this.main_mainmenu_snapshot_addsub_autosplit.Name = "main_mainmenu_snapshot_addsub_autosplit";
      this.main_mainmenu_snapshot_addsub_autosplit.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Autosplit;
      this.main_mainmenu_snapshot_addsub_autosplit.Click += new System.EventHandler(this.page_analytics_snapshot_btn_snapshot_mask_metasplit_Click);
      // 
      // main_mainmenu_snapshot_addsub_random
      // 
      this.main_mainmenu_snapshot_addsub_random.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.button_green_record;
      this.main_mainmenu_snapshot_addsub_random.Name = "main_mainmenu_snapshot_addsub_random";
      this.main_mainmenu_snapshot_addsub_random.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Zufällig;
      this.main_mainmenu_snapshot_addsub_random.Click += new System.EventHandler(this.page_analytics_snapshot_btn_snapshot_mask_random_Click);
      // 
      // main_mainmenu_analytics
      // 
      this.main_mainmenu_analytics.AccessibleDescription = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.NeueAnalyse;
      this.main_mainmenu_analytics.AccessibleName = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.NeueAnalyse;
      this.main_mainmenu_analytics.Image = ((System.Drawing.Image)(resources.GetObject("main_mainmenu_analytics.Image")));
      this.main_mainmenu_analytics.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.main_mainmenu_analytics_overview,
            this.radMenuSeparatorItem5,
            this.main_mainmenu_analytics_favorite});
      this.main_mainmenu_analytics.Margin = new System.Windows.Forms.Padding(0);
      this.main_mainmenu_analytics.Name = "main_mainmenu_analytics";
      this.main_mainmenu_analytics.Padding = new System.Windows.Forms.Padding(7);
      this.main_mainmenu_analytics.RightToLeft = false;
      this.main_mainmenu_analytics.Text = "";
      this.main_mainmenu_analytics.ToolTipText = "Analysen";
      // 
      // main_mainmenu_analytics_overview
      // 
      this.main_mainmenu_analytics_overview.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.eye;
      this.main_mainmenu_analytics_overview.Name = "main_mainmenu_analytics_overview";
      this.main_mainmenu_analytics_overview.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.AnalysenÜbersicht;
      this.main_mainmenu_analytics_overview.Click += new System.EventHandler(this.main_mainmenu_analytics_Click);
      // 
      // radMenuSeparatorItem5
      // 
      this.radMenuSeparatorItem5.Name = "radMenuSeparatorItem5";
      this.radMenuSeparatorItem5.Text = "radMenuSeparatorItem5";
      this.radMenuSeparatorItem5.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // main_mainmenu_analytics_favorite
      // 
      this.main_mainmenu_analytics_favorite.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.favorite;
      this.main_mainmenu_analytics_favorite.Name = "main_mainmenu_analytics_favorite";
      this.main_mainmenu_analytics_favorite.Text = "Favoriten";
      // 
      // radMenu1
      // 
      this.radMenu1.AllowShowFocusCues = true;
      this.radMenu1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.main_mainmenu_app,
            this.main_mainmenu_home,
            this.main_mainmenu_corpus,
            this.main_mainmenu_snapshot,
            this.main_mainmenu_analytics});
      this.radMenu1.Location = new System.Drawing.Point(0, 0);
      this.radMenu1.Name = "radMenu1";
      this.radMenu1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 1);
      this.radMenu1.Size = new System.Drawing.Size(832, 56);
      this.radMenu1.TabIndex = 2;
      this.radMenu1.ThemeName = "TelerikMetroTouch";
      // 
      // Dashboard
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(832, 581);
      this.Controls.Add(this.pages_main);
      this.Controls.Add(this.radMenu1);
      this.MinimumSize = new System.Drawing.Size(840, 630);
      this.Name = "Dashboard";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.Text = " CorpusExplorer";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Dashboard_FormClosing);
      this.Load += new System.EventHandler(this.Dashboard_Load);
      this.SizeChanged += new System.EventHandler(this.Dashboard_SizeChanged);
      ((System.ComponentModel.ISupportInitialize)(this.pages_main)).EndInit();
      this.pages_main.ResumeLayout(false);
      this.page_welcome.ResumeLayout(false);
      this.flowLayoutPanel3.ResumeLayout(false);
      this.page_corpus.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.pages_corpora)).EndInit();
      this.pages_corpora.ResumeLayout(false);
      this.page_corpus_start.ResumeLayout(false);
      this.radScrollablePanel3.PanelContainer.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel3)).EndInit();
      this.radScrollablePanel3.ResumeLayout(false);
      this.flowLayoutPanel1.ResumeLayout(false);
      this.flowLayoutPanel5.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.corpus_start_add)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.corpus_start_local)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.corpus_start_import)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.corpus_start_online)).EndInit();
      this.page_corpus_online.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).EndInit();
      this.radSplitContainer1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).EndInit();
      this.splitPanel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
      this.radGroupBox2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.corpus_online_crawler_list)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.corpus_online_crawler_create)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).EndInit();
      this.splitPanel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).EndInit();
      this.radGroupBox3.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.corpus_online_crawler_queries)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox5)).EndInit();
      this.radGroupBox5.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.corpus_online_crawler_start_compile)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.corpus_online_crawler_start)).EndInit();
      this.page_snapshot.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.pages_snapshot)).EndInit();
      this.pages_snapshot.ResumeLayout(false);
      this.page_snapshot_home.ResumeLayout(false);
      this.radScrollablePanel5.PanelContainer.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel5)).EndInit();
      this.radScrollablePanel5.ResumeLayout(false);
      this.flowLayoutPanel4.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radPanel8)).EndInit();
      this.radPanel8.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.page_analytics_snapshot_list_snapshots)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radPanel10)).EndInit();
      this.radPanel10.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel6)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.page_analytics_snapshot_btn_snapshot_invert)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.page_analytics_snapshot_btn_snapshot_reduceBfromA)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.page_analytics_snapshot_btn_snapshot_join)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.page_analytics_snapshot_btn_snapshot_union)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.page_analytics_snapshot_btn_snapshot_diff)).EndInit();
      this.panel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.page_analytics_snapshot_btn_snapshot_export)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.page_analytics_snapshot_btn_snapshot_load)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel11)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.page_analytics_snapshot_btn_snapshot_remove)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.page_analytics_snapshot_btn_snapshot_edit)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel10)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.page_analytics_snapshot_btn_snapshot_clonedetection)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel5)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.page_analytics_snapshot_btn_snapshot_mask)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.page_analytics_snapshot_btn_snapshot_add)).EndInit();
      this.page_snapshot_edit.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox6)).EndInit();
      this.radGroupBox6.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.snapshot_edit_queries)).EndInit();
      this.snapshot_edit_queries.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel7)).EndInit();
      this.clearPanel7.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.snapshot_edit_dropdown_meta)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.snapshot_edit_dropdown_fulltext)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.snapshot_edit_dropdown_corpus)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
      this.radGroupBox1.ResumeLayout(false);
      this.radGroupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.snapshot_edit_displayname)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel3)).EndInit();
      this.clearPanel3.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.snapshot_edit_abort)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.snapshot_edit_ok)).EndInit();
      this.page_analytics.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.pages_analytics)).EndInit();
      this.pages_analytics.ResumeLayout(false);
      this.page_analytics_start.ResumeLayout(false);
      this.radScrollablePanel1.PanelContainer.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel1)).EndInit();
      this.radScrollablePanel1.ResumeLayout(false);
      this.radScrollablePanel4.PanelContainer.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel4)).EndInit();
      this.radScrollablePanel4.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.betafunction_thirdpartyPanel)).EndInit();
      this.betafunction_thirdpartyPanel.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.modul_panel_betafunction_thirdparty)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.modul_panel_analytics)).EndInit();
      this.page_analytics_view.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.pages_standardanalytics)).EndInit();
      this.pages_standardanalytics.ResumeLayout(false);
      this.page_analytics_thirdparty.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.pages_3rdParty)).EndInit();
      this.page_settings.ResumeLayout(false);
      this.radScrollablePanel2.PanelContainer.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel2)).EndInit();
      this.radScrollablePanel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer2)).EndInit();
      this.radSplitContainer2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel3)).EndInit();
      this.splitPanel3.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox7)).EndInit();
      this.radGroupBox7.ResumeLayout(false);
      this.radGroupBox7.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.property_meta)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.settings_group_parameter)).EndInit();
      this.settings_group_parameter.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel9)).EndInit();
      this.clearPanel9.ResumeLayout(false);
      this.clearPanel9.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.settings_frequenz_min)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.infoButton3)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel8)).EndInit();
      this.clearPanel8.ResumeLayout(false);
      this.clearPanel8.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.settings_signifikanz_min)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.infoButton2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel4)).EndInit();
      this.clearPanel4.ResumeLayout(false);
      this.clearPanel4.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.settings_drop_signifikanz)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.infoButton1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel4)).EndInit();
      this.splitPanel4.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer3)).EndInit();
      this.radSplitContainer3.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel5)).EndInit();
      this.splitPanel5.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox4)).EndInit();
      this.radGroupBox4.ResumeLayout(false);
      this.radScrollablePanel6.PanelContainer.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel6)).EndInit();
      this.radScrollablePanel6.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.settings_tool_totalReset)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.settings_tool_upgrade)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.settings_tool_xpath)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.settings_tool_mergeCorpora)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.settings_tool_additionalTagger)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.settings_tool_exportCorpus)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.settings_tool_testCorpus)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.settings_tool_eraseCache)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.settings_tool_errorconsole)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel6)).EndInit();
      this.splitPanel6.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox9)).EndInit();
      this.radGroupBox9.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.settings_list_favorites)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox8)).EndInit();
      this.radGroupBox8.ResumeLayout(false);
      this.radGroupBox8.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.settings_insigt_id)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel12)).EndInit();
      this.clearPanel12.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.settings_insight_info)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.settings_insight_renew)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.settings_insight_disable)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.settings_insight_enable)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Telerik.WinControls.UI.RadMenuItem main_mainmenu_app;
    private Telerik.WinControls.UI.RadMenuItem main_mainmenu_project_new;
    private Telerik.WinControls.UI.RadMenuItem main_mainmenu_project_load;
    private Telerik.WinControls.UI.RadMenuItem main_mainmenu_project_save;
    private Telerik.WinControls.UI.RadMenuSeparatorItem radMenuSeparatorItem1;
    private Telerik.WinControls.UI.RadMenuItem main_mainmenu_exit;
    private Telerik.WinControls.UI.RadPageView pages_main;
    private Telerik.WinControls.UI.RadPageViewPage page_welcome;
    private Telerik.WinControls.UI.RadPageViewPage page_corpus;
    private Telerik.WinControls.UI.RadPageView pages_corpora;
    private Telerik.WinControls.UI.RadPageViewPage page_corpus_start;
    private Telerik.WinControls.UI.RadPageViewPage page_corpus_online;
    private Telerik.WinControls.UI.RadPageViewPage page_analytics;
    private Telerik.WinControls.UI.RadPageView pages_analytics;
    private Telerik.WinControls.UI.RadPageViewPage page_analytics_start;
    private Telerik.WinControls.UI.RadPageViewPage page_snapshot;
    private Telerik.WinControls.UI.RadPageViewPage page_analytics_view;
    private Telerik.WinControls.UI.RadMenuItem main_mainmenu_analytics;
    private Telerik.WinControls.UI.RadDropDownList settings_drop_signifikanz;
    private Telerik.WinControls.OldShapeEditor.CustomShape customShape1;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
    private Telerik.WinControls.UI.RadMenuItem main_mainmenu_home;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
    private Telerik.WinControls.UI.RadButton corpus_start_online;
    private Telerik.WinControls.UI.RadButton corpus_start_local;
    private Telerik.WinControls.UI.RadButton corpus_start_import;
    private Telerik.WinControls.UI.RadGroupBox radGroupBox3;
    private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
    private Telerik.WinControls.UI.RadListView corpus_online_crawler_list;
    private Telerik.WinControls.UI.RadScrollablePanel radScrollablePanel1;
    private Telerik.WinControls.UI.RadPanorama modul_panel_analytics;
    private Telerik.WinControls.UI.RadPanel betafunction_thirdpartyPanel;
    private Telerik.WinControls.UI.RadPanorama modul_panel_betafunction_thirdparty;
    private Telerik.WinControls.UI.RadPageViewPage page_analytics_thirdparty;
    private Telerik.WinControls.UI.RadPanel radPanel8;
    private Telerik.WinControls.UI.RadPanel radPanel10;
    private Telerik.WinControls.UI.RadButton page_analytics_snapshot_btn_snapshot_remove;
    private Telerik.WinControls.UI.RadPageView pages_standardanalytics;
    private Telerik.WinControls.UI.RadPageViewPage page_standardanalytics_search;
    private Telerik.WinControls.UI.RadPageViewPage page_standardanalytics_frequency;
    private Telerik.WinControls.UI.RadPageViewPage page_standardanalytics_ngram;
    private Telerik.WinControls.UI.RadPageViewPage page_standardanalytics_cooccurrence;
    private Telerik.WinControls.UI.RadPageViewPage page_standardanalytics_disambiguation;
    private Telerik.WinControls.UI.RadPageViewPage page_standardanalytics_weight;
    private Telerik.WinControls.UI.RadPageViewPage page_standardanalytics_complexety;
    private Telerik.WinControls.UI.RadSpinEditor settings_frequenz_min;
    private Telerik.WinControls.UI.RadGroupBox settings_group_parameter;
    private InfoButton infoButton1;
    private InfoButton infoButton3;
    private Telerik.WinControls.UI.RadLabel radLabel5;
    private InfoButton infoButton2;
    private Telerik.WinControls.UI.RadSpinEditor settings_signifikanz_min;
    private Telerik.WinControls.UI.RadLabel radLabel3;
    private Telerik.WinControls.UI.RadLabel radLabel2;
    private Telerik.WinControls.UI.RadMenuItem main_mainmenu_snapshot;
    private Telerik.WinControls.UI.RadMenuItem main_mainmenu_corpus;
    private Telerik.WinControls.UI.RadButton page_analytics_snapshot_btn_snapshot_edit;
    private Telerik.WinControls.UI.RadTreeView page_analytics_snapshot_list_snapshots;
    private Telerik.WinControls.UI.RadScrollablePanel radScrollablePanel2;
    private RadButtonWithCheckmark page_welcome_btn_projectname;
    private RadButtonWithCheckmark page_welcome_btn_corpus;
    private RadButtonWithCheckmark page_welcome_btn_snapshot;
    private RadButtonWithCheckmark page_welcome_btn_analytics;
    private Telerik.WinControls.UI.RadDropDownButton corpus_start_add;
    private Telerik.WinControls.UI.RadPageViewPage page_settings;
    private Telerik.WinControls.UI.RadMenuItem main_mainmenu_project_settings;
    private Telerik.WinControls.UI.RadMenuItem main_mainmenu_corpus_overview;
    private Telerik.WinControls.UI.RadMenuSeparatorItem radMenuSeparatorItem3;
    private Telerik.WinControls.UI.RadMenuItem main_mainmenu_corpus_load;
    private Telerik.WinControls.UI.RadMenuItem main_mainmenu_corpus_files;
    private Telerik.WinControls.UI.RadMenuItem main_mainmenu_corpus_import;
    private Telerik.WinControls.UI.RadMenuItem main_mainmenu_corpus_online;
    private Telerik.WinControls.UI.RadMenuItem main_mainmenu_snapshot_overview;
    private Telerik.WinControls.UI.RadMenuSeparatorItem radMenuSeparatorItem4;
    private Telerik.WinControls.UI.RadMenuItem main_mainmenu_snapshot_availabel;
    private Telerik.WinControls.UI.RadMenuItem main_mainmenu_snapshot_new;
    private Telerik.WinControls.UI.RadMenuItem main_mainmenu_snapshot_addsub;
    private Header header2;
    private Header header1;
    private Telerik.WinControls.UI.RadScrollablePanel radScrollablePanel3;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    private BigNumber page_corpus_start_quickinfo_corpora;
    private Header header4;
    private Header header3;
    private BigNumber page_corpus_start_quickinfo_texts;
    private BigNumber page_corpus_start_quickinfo_layers;
    private BigNumber page_corpus_start_quickinfo_tokens;
    private HelpPanel helpPanel1;
    private HelpPanel helpPanel2;
    private Header header5;
    private Header header7;
    private Telerik.WinControls.UI.RadScrollablePanel radScrollablePanel4;
    private Header header9;
    private Header header8;
    private Header header10;
    private HelpPanel helpPanel3;
    private Telerik.WinControls.UI.RadMenuItem main_mainmenu_analytics_overview;
    private Telerik.WinControls.UI.RadMenuSeparatorItem radMenuSeparatorItem5;
    private HelpPanel helpPanel4;
    private Telerik.WinControls.UI.RadPageView pages_snapshot;
    private Telerik.WinControls.UI.RadPageViewPage page_snapshot_home;
    private Telerik.WinControls.UI.RadPageViewPage page_snapshot_edit;
    private Header header11;
    private Telerik.WinControls.UI.RadScrollablePanel radScrollablePanel5;
    private Telerik.WinControls.UI.RadScrollablePanel snapshot_edit_queries;
    private ClearPanel clearPanel3;
    private Telerik.WinControls.UI.RadButton snapshot_edit_abort;
    private Telerik.WinControls.UI.RadButton snapshot_edit_ok;
    private Telerik.WinControls.UI.RadTextBox snapshot_edit_displayname;
    private Telerik.WinControls.UI.RadButton page_analytics_snapshot_btn_snapshot_invert;
    private Telerik.WinControls.UI.RadGroupBox radGroupBox4;
    private Telerik.WinControls.UI.RadButton settings_tool_upgrade;
    private Telerik.WinControls.UI.RadDropDownButton page_analytics_snapshot_btn_snapshot_add;
    private Telerik.WinControls.UI.RadButton settings_tool_errorconsole;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
    private BigNumber page_snapshot_start_quickinfo_corpora;
    private BigNumber page_snapshot_start_quickinfo_texts;
    private BigNumber page_snapshot_start_quickinfo_layers;
    private BigNumber page_snapshot_start_quickinfo_tokens;
    private Header header12;
    private Telerik.WinControls.UI.RadDropDownButton page_analytics_snapshot_btn_snapshot_mask;
    private Telerik.WinControls.UI.RadMenuItem page_analytics_snapshot_btn_snapshot_mask_individual;
    private Telerik.WinControls.UI.RadMenuItem page_analytics_snapshot_btn_snapshot_mask_random;
    private Telerik.WinControls.UI.RadMenuItem page_analytics_snapshot_btn_snapshot_add_individual;
    private Telerik.WinControls.UI.RadMenuItem page_analytics_snapshot_btn_snapshot_add_random;
    private Telerik.WinControls.UI.RadButton settings_tool_eraseCache;
    private Telerik.WinControls.UI.RadButton corpus_online_crawler_start;
    private Telerik.WinControls.UI.RadPageViewPage page_standardanalytics_beta;
    private Telerik.WinControls.UI.RadMenuItem main_mainmenu_snapshot_addsub_custom;
    private Telerik.WinControls.UI.RadMenuItem main_mainmenu_snapshot_addsub_random;
    private Telerik.WinControls.UI.RadMenuItem main_mainmenu_snapshot_new_custom;
    private Telerik.WinControls.UI.RadMenuItem main_mainmenu_snapshot_new_random;
    private Telerik.WinControls.UI.RadPageViewPage page_rawanalytics_annotation;
    private Telerik.WinControls.UI.RadPageViewPage page_rawanalytics_edition;
    private Telerik.WinControls.UI.RadSplitContainer radSplitContainer1;
    private Telerik.WinControls.UI.SplitPanel splitPanel1;
    private Telerik.WinControls.UI.SplitPanel splitPanel2;
    private Telerik.WinControls.UI.RadButton corpus_online_crawler_create;
    private Telerik.WinControls.UI.RadGroupBox radGroupBox5;
    private Telerik.WinControls.UI.RadCheckBox corpus_online_crawler_start_compile;
    private Telerik.WinControls.UI.RadPageViewPage page_specialFeatures;
    private Telerik.WinControls.UI.RadMenuItem page_analytics_snapshot_btn_snapshot_mask_metasplit;
    private Telerik.WinControls.UI.RadMenuItem page_analytics_snapshot_btn_snapshot_add_metasplit;
    private Telerik.WinControls.UI.RadMenuItem main_mainmenu_snapshot_addsub_autosplit;
    private Telerik.WinControls.UI.RadMenuItem main_mainmenu_snapshot_new_autosplit;
    private Telerik.WinControls.UI.RadButton page_analytics_snapshot_btn_snapshot_reduceBfromA;
    private Telerik.WinControls.UI.RadButton page_analytics_snapshot_btn_snapshot_union;
    private Telerik.WinControls.UI.RadButton page_analytics_snapshot_btn_snapshot_diff;
    private Telerik.WinControls.UI.RadButton page_analytics_snapshot_btn_snapshot_join;
    private ClearPanel clearPanel5;
    private Telerik.WinControls.UI.RadButton settings_tool_mergeCorpora;
    private Telerik.WinControls.UI.RadButton settings_tool_exportCorpus;
    private Telerik.WinControls.UI.RadButton page_analytics_snapshot_btn_snapshot_clonedetection;
    private Telerik.WinControls.UI.RadPageViewPage page_styleMetrics;
    private Telerik.WinControls.UI.RadButton page_analytics_snapshot_btn_snapshot_load;
    private ClearPanel clearPanel6;
    private Telerik.WinControls.UI.RadGroupBox radGroupBox6;
    private ClearPanel clearPanel7;
    private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
    private Telerik.WinControls.UI.RadButton snapshot_edit_dropdown_meta;
    private Telerik.WinControls.UI.RadButton snapshot_edit_dropdown_fulltext;
    private Telerik.WinControls.UI.RadButton snapshot_edit_dropdown_corpus;
    private Telerik.WinControls.UI.RadMenuItem main_mainmenu_project_saveas;
    private Telerik.WinControls.UI.RadMenuSeparatorItem radMenuSeparatorItem6;
    private Telerik.WinControls.UI.RadMenu radMenu1;
    private ClearPanel clearPanel2;
    private Telerik.WinControls.UI.RadButton page_analytics_snapshot_btn_snapshot_export;
    private System.Windows.Forms.Panel panel1;
    private ClearPanel clearPanel1;
    private Telerik.WinControls.UI.RadTextBox corpus_online_crawler_queries;
    private Telerik.WinControls.UI.RadButton settings_tool_testCorpus;
    private Telerik.WinControls.UI.RadPageView pages_3rdParty;
    private Telerik.WinControls.UI.RadSplitContainer radSplitContainer2;
    private Telerik.WinControls.UI.SplitPanel splitPanel3;
    private Telerik.WinControls.UI.SplitPanel splitPanel4;
    private ClearPanel clearPanel8;
    private ClearPanel clearPanel4;
    private ClearPanel clearPanel9;
    private Telerik.WinControls.UI.RadButton settings_tool_additionalTagger;
    private Telerik.WinControls.UI.RadButton settings_tool_xpath;
    private ClearPanel clearPanel11;
    private ClearPanel clearPanel10;
    private Telerik.WinControls.UI.RadGroupBox radGroupBox7;
    private Telerik.WinControls.UI.RadPropertyGrid property_meta;
    private Telerik.WinControls.UI.RadCommandBar radCommandBar1;
    private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
    private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement1;
    private Telerik.WinControls.UI.CommandBarButton btn_settings_load;
    private Telerik.WinControls.UI.CommandBarButton btn_settings_save;
    private Telerik.WinControls.UI.CommandBarButton btn_settings_saveas;
    private Telerik.WinControls.UI.RadButton settings_tool_totalReset;
    private Telerik.WinControls.UI.RadGroupBox radGroupBox8;
    private Telerik.WinControls.UI.RadTextBox settings_insigt_id;
    private ClearPanel clearPanel12;
    private Telerik.WinControls.UI.RadButton settings_insight_renew;
    private Telerik.WinControls.UI.RadButton settings_insight_disable;
    private Telerik.WinControls.UI.RadButton settings_insight_enable;
    private Telerik.WinControls.UI.RadButton settings_insight_info;
    private Telerik.WinControls.UI.RadMenuItem main_mainmenu_analytics_favorite;
    private Telerik.WinControls.UI.RadSplitContainer radSplitContainer3;
    private Telerik.WinControls.UI.SplitPanel splitPanel5;
    private Telerik.WinControls.UI.SplitPanel splitPanel6;
    private Telerik.WinControls.UI.RadGroupBox radGroupBox9;
    private Telerik.WinControls.UI.RadCheckedListBox settings_list_favorites;
    private Telerik.WinControls.UI.RadScrollablePanel radScrollablePanel6;
  }
}