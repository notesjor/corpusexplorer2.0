using CorpusExplorer.Terminal.WinForm.Properties;
using CorpusExplorer.Terminal.WinForm.Controls.WinForm;
using System;
using Telerik.WinControls.UI;

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
      Telerik.WinControls.UI.ListViewDataItem listViewDataItem1 = new Telerik.WinControls.UI.ListViewDataItem("<html><strong>Hinweis:</strong> \"Aktuelles und Neuigkeiten\" können nur bei besteh" +
        "ender Internetverbindung angeziegt werden.</html>");
      this.radScrollablePanel9 = new Telerik.WinControls.UI.RadScrollablePanel();
      this.snapshot_edit_queries = new Telerik.WinControls.UI.RadScrollablePanel();
      this.radScrollablePanel1 = new Telerik.WinControls.UI.RadScrollablePanel();
      this.radScrollablePanel4 = new Telerik.WinControls.UI.RadScrollablePanel();
      this.helpPanel4 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.HelpPanel();
      this.betafunction_thirdpartyPanel = new Telerik.WinControls.UI.RadPanel();
      this.modul_panel_betafunction_thirdparty = new Telerik.WinControls.UI.RadPanorama();
      this.header9 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.Header();
      this.modul_panel_analytics = new Telerik.WinControls.UI.RadPanorama();
      this.header8 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.Header();
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
      this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
      this.settings_drop_signifikanz = new Telerik.WinControls.UI.RadDropDownList();
      this.infoButton1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.InfoButton();
      this.splitPanel4 = new Telerik.WinControls.UI.SplitPanel();
      this.radSplitContainer3 = new Telerik.WinControls.UI.RadSplitContainer();
      this.splitPanel5 = new Telerik.WinControls.UI.SplitPanel();
      this.radGroupBox4 = new Telerik.WinControls.UI.RadGroupBox();
      this.radScrollablePanel5 = new Telerik.WinControls.UI.RadScrollablePanel();
      this.settings_tool_totalReset = new Telerik.WinControls.UI.RadButton();
      this.settings_tool_scriptEditor = new Telerik.WinControls.UI.RadButton();
      this.settings_tool_errorconsole = new Telerik.WinControls.UI.RadButton();
      this.settings_tool_upgrade = new Telerik.WinControls.UI.RadButton();
      this.settings_tool_eraseCache = new Telerik.WinControls.UI.RadButton();
      this.settings_tool_xpath = new Telerik.WinControls.UI.RadButton();
      this.settings_tool_testCorpus = new Telerik.WinControls.UI.RadButton();
      this.settings_tool_drmUsers = new Telerik.WinControls.UI.RadButton();
      this.settings_tool_additionalTagger = new Telerik.WinControls.UI.RadButton();
      this.settings_tool_exportCorpus = new Telerik.WinControls.UI.RadButton();
      this.settings_tool_mergeCorpora = new Telerik.WinControls.UI.RadButton();
      this.splitPanel6 = new Telerik.WinControls.UI.SplitPanel();
      this.radGroupBox9 = new Telerik.WinControls.UI.RadGroupBox();
      this.settings_list_favorites = new Telerik.WinControls.UI.RadCheckedListBox();
      this.header10 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.Header();
      this.radScrollablePanel8 = new Telerik.WinControls.UI.RadScrollablePanel();
      this.radScrollablePanel10 = new Telerik.WinControls.UI.RadScrollablePanel();
      this.header13 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.Header();
      this.radListView1 = new Telerik.WinControls.UI.RadListView();
      this.header6 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.Header();
      this.helpPanel1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.HelpPanel();
      this.radScrollablePanel11 = new Telerik.WinControls.UI.RadScrollablePanel();
      this.page_welcome_btn_analytics = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.RadButtonWithCheckmark();
      this.page_welcome_btn_snapshot = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.RadButtonWithCheckmark();
      this.page_welcome_btn_corpus = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.RadButtonWithCheckmark();
      this.page_welcome_btn_projectname = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.RadButtonWithCheckmark();
      this.header2 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.Header();
      this.header1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.Header();
      this.radScrollablePanel7 = new Telerik.WinControls.UI.RadScrollablePanel();
      this.header14 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.Header();
      this.helpPanel2 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.HelpPanel();
      this.infoPanel_korpora = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.InfoPanel();
      this.header4 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.Header();
      this.radScrollablePanel12 = new Telerik.WinControls.UI.RadScrollablePanel();
      this.corpus_start_korap = new Telerik.WinControls.UI.RadButton();
      this.corpus_start_dpxc = new Telerik.WinControls.UI.RadButton();
      this.corpus_start_online = new Telerik.WinControls.UI.RadButton();
      this.corpus_start_import = new Telerik.WinControls.UI.RadButton();
      this.corpus_start_local = new Telerik.WinControls.UI.RadButton();
      this.corpus_start_add = new Telerik.WinControls.UI.RadDropDownButton();
      this.header3 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.Header();
      this.radScrollablePanel3 = new Telerik.WinControls.UI.RadScrollablePanel();
      this.clearPanel1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.ClearPanel();
      this.panel_bridge = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.ClearPanel();
      this.clearPanel11 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.ClearPanel();
      this.btn_bridge_reload = new Telerik.WinControls.UI.RadButton();
      this.lbl_bridge_status = new Telerik.WinControls.UI.RadLabel();
      this.radLabel7 = new Telerik.WinControls.UI.RadLabel();
      this.txt_bridge_port = new Telerik.WinControls.UI.RadTextBox();
      this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
      this.txt_bridge_ip = new Telerik.WinControls.UI.RadMaskedEditBox();
      this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
      this.clearPanel10 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.ClearPanel();
      this.radLabel9 = new Telerik.WinControls.UI.RadLabel();
      this.clearPanel2 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.ClearPanel();
      this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
      this.switch_bridge = new Telerik.WinControls.UI.RadToggleSwitch();
      this.header15 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.Header();
      this.helpPanel3 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.HelpPanel();
      this.infoPanel_snapshot = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.InfoPanel();
      this.header12 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.Header();
      this.radPanel8 = new Telerik.WinControls.UI.RadPanel();
      this.page_analytics_snapshot_list_snapshots = new Telerik.WinControls.UI.RadTreeView();
      this.clearPanel13 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.ClearPanel();
      this.page_analytics_snapshot_btn_snapshot_export = new Telerik.WinControls.UI.RadButton();
      this.page_analytics_snapshot_btn_snapshot_load = new Telerik.WinControls.UI.RadButton();
      this.page_analytics_snapshot_btn_snapshot_remove = new Telerik.WinControls.UI.RadButton();
      this.page_analytics_snapshot_btn_snapshot_edit = new Telerik.WinControls.UI.RadButton();
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
      this.clearPanel14 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.ClearPanel();
      this.page_analytics_snapshot_btn_snapshot_publish = new Telerik.WinControls.UI.RadButton();
      this.page_analytics_snapshot_btn_snapshot_invert = new Telerik.WinControls.UI.RadButton();
      this.page_analytics_snapshot_btn_snapshot_reduceBfromA = new Telerik.WinControls.UI.RadButton();
      this.page_analytics_snapshot_btn_snapshot_join = new Telerik.WinControls.UI.RadButton();
      this.page_analytics_snapshot_btn_snapshot_union = new Telerik.WinControls.UI.RadButton();
      this.page_analytics_snapshot_btn_snapshot_diff = new Telerik.WinControls.UI.RadButton();
      this.header7 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.Header();
      this.page_analytics_snapshot_noexport = new Telerik.WinControls.UI.RadPanel();
      this.pages_main = new Telerik.WinControls.UI.RadPageView();
      this.page_welcome = new Telerik.WinControls.UI.RadPageViewPage();
      this.page_corpus = new Telerik.WinControls.UI.RadPageViewPage();
      this.pages_corpora = new Telerik.WinControls.UI.RadPageView();
      this.page_corpus_start = new Telerik.WinControls.UI.RadPageViewPage();
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
      this.page_snapshot_edit = new Telerik.WinControls.UI.RadPageViewPage();
      this.radGroupBox6 = new Telerik.WinControls.UI.RadGroupBox();
      this.clearPanel7 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.ClearPanel();
      this.snapshot_edit_dropdown_meta = new Telerik.WinControls.UI.RadButton();
      this.snapshot_edit_dropdown_fulltext = new Telerik.WinControls.UI.RadButton();
      this.snapshot_edit_dropdown_corpus = new Telerik.WinControls.UI.RadButton();
      this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
      this.warnBox1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.WarnBox();
      this.snapshot_edit_displayname = new Telerik.WinControls.UI.RadTextBox();
      this.header11 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.Header();
      this.clearPanel3 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.ClearPanel();
      this.snapshot_edit_abort = new Telerik.WinControls.UI.RadButton();
      this.snapshot_edit_ok = new Telerik.WinControls.UI.RadButton();
      this.page_analytics = new Telerik.WinControls.UI.RadPageViewPage();
      this.pages_analytics = new Telerik.WinControls.UI.RadPageView();
      this.page_analytics_start = new Telerik.WinControls.UI.RadPageViewPage();
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
      this.main_mainmenu_corpus_dpxc = new Telerik.WinControls.UI.RadMenuItem();
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
      ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel9)).BeginInit();
      this.radScrollablePanel9.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.snapshot_edit_queries)).BeginInit();
      this.snapshot_edit_queries.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel1)).BeginInit();
      this.radScrollablePanel1.PanelContainer.SuspendLayout();
      this.radScrollablePanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel4)).BeginInit();
      this.radScrollablePanel4.PanelContainer.SuspendLayout();
      this.radScrollablePanel4.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.betafunction_thirdpartyPanel)).BeginInit();
      this.betafunction_thirdpartyPanel.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.modul_panel_betafunction_thirdparty)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.header9)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.modul_panel_analytics)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.header8)).BeginInit();
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
      ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.settings_drop_signifikanz)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.infoButton1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel4)).BeginInit();
      this.splitPanel4.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer3)).BeginInit();
      this.radSplitContainer3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel5)).BeginInit();
      this.splitPanel5.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox4)).BeginInit();
      this.radGroupBox4.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel5)).BeginInit();
      this.radScrollablePanel5.PanelContainer.SuspendLayout();
      this.radScrollablePanel5.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.settings_tool_totalReset)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.settings_tool_scriptEditor)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.settings_tool_errorconsole)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.settings_tool_upgrade)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.settings_tool_eraseCache)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.settings_tool_xpath)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.settings_tool_testCorpus)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.settings_tool_drmUsers)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.settings_tool_additionalTagger)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.settings_tool_exportCorpus)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.settings_tool_mergeCorpora)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel6)).BeginInit();
      this.splitPanel6.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox9)).BeginInit();
      this.radGroupBox9.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.settings_list_favorites)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.header10)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel8)).BeginInit();
      this.radScrollablePanel8.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel10)).BeginInit();
      this.radScrollablePanel10.PanelContainer.SuspendLayout();
      this.radScrollablePanel10.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.header13)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radListView1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.header6)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel11)).BeginInit();
      this.radScrollablePanel11.PanelContainer.SuspendLayout();
      this.radScrollablePanel11.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.header2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.header1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel7)).BeginInit();
      this.radScrollablePanel7.PanelContainer.SuspendLayout();
      this.radScrollablePanel7.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.header14)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.header4)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel12)).BeginInit();
      this.radScrollablePanel12.PanelContainer.SuspendLayout();
      this.radScrollablePanel12.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.corpus_start_korap)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.corpus_start_dpxc)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.corpus_start_online)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.corpus_start_import)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.corpus_start_local)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.corpus_start_add)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.header3)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel3)).BeginInit();
      this.radScrollablePanel3.PanelContainer.SuspendLayout();
      this.radScrollablePanel3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel1)).BeginInit();
      this.clearPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.panel_bridge)).BeginInit();
      this.panel_bridge.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel11)).BeginInit();
      this.clearPanel11.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.btn_bridge_reload)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.lbl_bridge_status)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_bridge_port)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_bridge_ip)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel10)).BeginInit();
      this.clearPanel10.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel2)).BeginInit();
      this.clearPanel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.switch_bridge)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.header15)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.header12)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radPanel8)).BeginInit();
      this.radPanel8.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.page_analytics_snapshot_list_snapshots)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel13)).BeginInit();
      this.clearPanel13.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.page_analytics_snapshot_btn_snapshot_export)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.page_analytics_snapshot_btn_snapshot_load)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.page_analytics_snapshot_btn_snapshot_remove)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.page_analytics_snapshot_btn_snapshot_edit)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.page_analytics_snapshot_btn_snapshot_clonedetection)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel5)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.page_analytics_snapshot_btn_snapshot_mask)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.page_analytics_snapshot_btn_snapshot_add)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel14)).BeginInit();
      this.clearPanel14.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.page_analytics_snapshot_btn_snapshot_publish)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.page_analytics_snapshot_btn_snapshot_invert)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.page_analytics_snapshot_btn_snapshot_reduceBfromA)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.page_analytics_snapshot_btn_snapshot_join)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.page_analytics_snapshot_btn_snapshot_union)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.page_analytics_snapshot_btn_snapshot_diff)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.header7)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.page_analytics_snapshot_noexport)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pages_main)).BeginInit();
      this.pages_main.SuspendLayout();
      this.page_welcome.SuspendLayout();
      this.page_corpus.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pages_corpora)).BeginInit();
      this.pages_corpora.SuspendLayout();
      this.page_corpus_start.SuspendLayout();
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
      ((System.ComponentModel.ISupportInitialize)(this.header5)).BeginInit();
      this.page_snapshot.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pages_snapshot)).BeginInit();
      this.pages_snapshot.SuspendLayout();
      this.page_snapshot_home.SuspendLayout();
      this.page_snapshot_edit.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox6)).BeginInit();
      this.radGroupBox6.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel7)).BeginInit();
      this.clearPanel7.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.snapshot_edit_dropdown_meta)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.snapshot_edit_dropdown_fulltext)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.snapshot_edit_dropdown_corpus)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
      this.radGroupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.snapshot_edit_displayname)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.header11)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel3)).BeginInit();
      this.clearPanel3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.snapshot_edit_abort)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.snapshot_edit_ok)).BeginInit();
      this.page_analytics.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pages_analytics)).BeginInit();
      this.pages_analytics.SuspendLayout();
      this.page_analytics_start.SuspendLayout();
      this.page_analytics_view.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pages_standardanalytics)).BeginInit();
      this.pages_standardanalytics.SuspendLayout();
      this.page_analytics_thirdparty.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pages_3rdParty)).BeginInit();
      this.page_settings.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // radScrollablePanel9
      // 
      resources.ApplyResources(this.radScrollablePanel9, "radScrollablePanel9");
      this.radScrollablePanel9.Name = "radScrollablePanel9";
      // 
      // radScrollablePanel9.PanelContainer
      // 
      resources.ApplyResources(this.radScrollablePanel9.PanelContainer, "radScrollablePanel9.PanelContainer");
      // 
      // snapshot_edit_queries
      // 
      resources.ApplyResources(this.snapshot_edit_queries, "snapshot_edit_queries");
      this.snapshot_edit_queries.Name = "snapshot_edit_queries";
      // 
      // snapshot_edit_queries.PanelContainer
      // 
      resources.ApplyResources(this.snapshot_edit_queries.PanelContainer, "snapshot_edit_queries.PanelContainer");
      // 
      // radScrollablePanel1
      // 
      resources.ApplyResources(this.radScrollablePanel1, "radScrollablePanel1");
      this.radScrollablePanel1.Name = "radScrollablePanel1";
      // 
      // radScrollablePanel1.PanelContainer
      // 
      this.radScrollablePanel1.PanelContainer.Controls.Add(this.radScrollablePanel4);
      resources.ApplyResources(this.radScrollablePanel1.PanelContainer, "radScrollablePanel1.PanelContainer");
      // 
      // radScrollablePanel4
      // 
      resources.ApplyResources(this.radScrollablePanel4, "radScrollablePanel4");
      this.radScrollablePanel4.Name = "radScrollablePanel4";
      // 
      // radScrollablePanel4.PanelContainer
      // 
      this.radScrollablePanel4.PanelContainer.Controls.Add(this.helpPanel4);
      this.radScrollablePanel4.PanelContainer.Controls.Add(this.betafunction_thirdpartyPanel);
      this.radScrollablePanel4.PanelContainer.Controls.Add(this.modul_panel_analytics);
      this.radScrollablePanel4.PanelContainer.Controls.Add(this.header8);
      resources.ApplyResources(this.radScrollablePanel4.PanelContainer, "radScrollablePanel4.PanelContainer");
      // 
      // helpPanel4
      // 
      this.helpPanel4.BackColor = System.Drawing.Color.White;
      resources.ApplyResources(this.helpPanel4, "helpPanel4");
      this.helpPanel4.HelpHandbookText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.InteraktivesHandbuch;
      this.helpPanel4.HelpHandbookUrl = "http://www.bitcutstudios.com/products/corpusexplorer/help/analysen.html";
      this.helpPanel4.HelpHandsonlabText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.PraktischeÜbungen;
      this.helpPanel4.HelpHandsonlabUrl = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Help_Static_HandsOnLab;
      this.helpPanel4.HelpLabelDescription = "Die Module repräsentieren die einzelnen Analysen. Die Module verfügen über unters" +
    "chiedliche Darstellungs-/Auswertungsmodi.";
      this.helpPanel4.HelpLabelHeader = "Hilfe zu den verfügbaren Modulen - Allgemeine Einführung";
      this.helpPanel4.HelpOnlineText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.WeitereInformationen;
      this.helpPanel4.HelpOnlineUrl = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Help_Static_AdditionalInformation;
      this.helpPanel4.HelpVideoText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.KurzesEinstiegsvideo;
      this.helpPanel4.HelpVideoUrl = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Help_Static_YoutubeChannel;
      this.helpPanel4.Name = "helpPanel4";
      // 
      // betafunction_thirdpartyPanel
      // 
      this.betafunction_thirdpartyPanel.Controls.Add(this.modul_panel_betafunction_thirdparty);
      this.betafunction_thirdpartyPanel.Controls.Add(this.header9);
      resources.ApplyResources(this.betafunction_thirdpartyPanel, "betafunction_thirdpartyPanel");
      this.betafunction_thirdpartyPanel.Name = "betafunction_thirdpartyPanel";
      // 
      // 
      // 
      this.betafunction_thirdpartyPanel.RootElement.MinSize = new System.Drawing.Size(518, 169);
      ((Telerik.WinControls.Primitives.BorderPrimitive)(this.betafunction_thirdpartyPanel.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Hidden;
      // 
      // modul_panel_betafunction_thirdparty
      // 
      this.modul_panel_betafunction_thirdparty.CellSize = new System.Drawing.Size(125, 100);
      resources.ApplyResources(this.modul_panel_betafunction_thirdparty, "modul_panel_betafunction_thirdparty");
      this.modul_panel_betafunction_thirdparty.Name = "modul_panel_betafunction_thirdparty";
      this.modul_panel_betafunction_thirdparty.ScrollBarThickness = 20;
      this.modul_panel_betafunction_thirdparty.ScrollingBackground = true;
      // 
      // header9
      // 
      resources.ApplyResources(this.header9, "header9");
      this.header9.BackColor = System.Drawing.Color.White;
      this.header9.HeaderDescription = resources.GetString("header9.HeaderDescription");
      this.header9.HeaderHead = "Erweiterungen von Drittanbietern";
      this.header9.Name = "header9";
      // 
      // modul_panel_analytics
      // 
      this.modul_panel_analytics.CellSize = new System.Drawing.Size(125, 100);
      resources.ApplyResources(this.modul_panel_analytics, "modul_panel_analytics");
      this.modul_panel_analytics.Name = "modul_panel_analytics";
      this.modul_panel_analytics.RowsCount = 2;
      this.modul_panel_analytics.ScrollBarThickness = 20;
      this.modul_panel_analytics.ScrollingBackground = true;
      // 
      // header8
      // 
      resources.ApplyResources(this.header8, "header8");
      this.header8.BackColor = System.Drawing.Color.White;
      this.header8.HeaderDescription = resources.GetString("header8.HeaderDescription");
      this.header8.HeaderHead = "Verfügbare Analysemodule";
      this.header8.Name = "header8";
      // 
      // radScrollablePanel2
      // 
      resources.ApplyResources(this.radScrollablePanel2, "radScrollablePanel2");
      this.radScrollablePanel2.HorizontalScrollBarState = Telerik.WinControls.UI.ScrollState.AlwaysHide;
      this.radScrollablePanel2.Name = "radScrollablePanel2";
      // 
      // radScrollablePanel2.PanelContainer
      // 
      this.radScrollablePanel2.PanelContainer.Controls.Add(this.radSplitContainer2);
      this.radScrollablePanel2.PanelContainer.Controls.Add(this.header10);
      resources.ApplyResources(this.radScrollablePanel2.PanelContainer, "radScrollablePanel2.PanelContainer");
      // 
      // 
      // 
      this.radScrollablePanel2.RootElement.MaxSize = new System.Drawing.Size(0, 0);
      // 
      // radSplitContainer2
      // 
      this.radSplitContainer2.Controls.Add(this.splitPanel3);
      this.radSplitContainer2.Controls.Add(this.splitPanel4);
      resources.ApplyResources(this.radSplitContainer2, "radSplitContainer2");
      this.radSplitContainer2.Name = "radSplitContainer2";
      // 
      // 
      // 
      this.radSplitContainer2.RootElement.MinSize = new System.Drawing.Size(0, 0);
      this.radSplitContainer2.SplitterWidth = 5;
      this.radSplitContainer2.TabStop = false;
      // 
      // splitPanel3
      // 
      this.splitPanel3.Controls.Add(this.radGroupBox7);
      this.splitPanel3.Controls.Add(this.settings_group_parameter);
      resources.ApplyResources(this.splitPanel3, "splitPanel3");
      this.splitPanel3.Name = "splitPanel3";
      // 
      // 
      // 
      this.splitPanel3.RootElement.MinSize = new System.Drawing.Size(0, 0);
      this.splitPanel3.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(-0.03995156F, 0F);
      this.splitPanel3.SizeInfo.SplitterCorrection = new System.Drawing.Size(-33, 0);
      this.splitPanel3.TabStop = false;
      // 
      // radGroupBox7
      // 
      this.radGroupBox7.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox7.Controls.Add(this.property_meta);
      this.radGroupBox7.Controls.Add(this.radCommandBar1);
      resources.ApplyResources(this.radGroupBox7, "radGroupBox7");
      this.radGroupBox7.Name = "radGroupBox7";
      // 
      // property_meta
      // 
      resources.ApplyResources(this.property_meta, "property_meta");
      this.property_meta.EnableGrouping = false;
      this.property_meta.HelpBarHeight = 0F;
      this.property_meta.HelpVisible = false;
      this.property_meta.ItemHeight = 50;
      this.property_meta.ItemIndent = 50;
      this.property_meta.Name = "property_meta";
      this.property_meta.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
      this.property_meta.ShowItemToolTips = false;
      this.property_meta.SortOrder = System.Windows.Forms.SortOrder.Ascending;
      // 
      // radCommandBar1
      // 
      resources.ApplyResources(this.radCommandBar1, "radCommandBar1");
      this.radCommandBar1.Name = "radCommandBar1";
      this.radCommandBar1.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement1});
      // 
      // commandBarRowElement1
      // 
      this.commandBarRowElement1.MinSize = new System.Drawing.Size(31, 31);
      this.commandBarRowElement1.Name = "commandBarRowElement1";
      this.commandBarRowElement1.Strips.AddRange(new Telerik.WinControls.UI.CommandBarStripElement[] {
            this.commandBarStripElement1});
      // 
      // commandBarStripElement1
      // 
      resources.ApplyResources(this.commandBarStripElement1, "commandBarStripElement1");
      this.commandBarStripElement1.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.btn_settings_load,
            this.btn_settings_save,
            this.btn_settings_saveas});
      this.commandBarStripElement1.Name = "commandBarStripElement1";
      this.commandBarStripElement1.OverflowMenuMaxSize = new System.Drawing.Size(338, 0);
      this.commandBarStripElement1.OverflowMenuMinSize = new System.Drawing.Size(62, 31);
      // 
      // btn_settings_load
      // 
      resources.ApplyResources(this.btn_settings_load, "btn_settings_load");
      this.btn_settings_load.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.folder_open;
      this.btn_settings_load.Name = "btn_settings_load";
      this.btn_settings_load.Click += new System.EventHandler(this.btn_settings_load_Click);
      // 
      // btn_settings_save
      // 
      resources.ApplyResources(this.btn_settings_save, "btn_settings_save");
      this.btn_settings_save.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.save;
      this.btn_settings_save.Name = "btn_settings_save";
      this.btn_settings_save.Click += new System.EventHandler(this.btn_settings_save_Click);
      // 
      // btn_settings_saveas
      // 
      resources.ApplyResources(this.btn_settings_saveas, "btn_settings_saveas");
      this.btn_settings_saveas.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.save_all;
      this.btn_settings_saveas.Name = "btn_settings_saveas";
      this.btn_settings_saveas.Click += new System.EventHandler(this.btn_settings_saveas_Click);
      // 
      // settings_group_parameter
      // 
      this.settings_group_parameter.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.settings_group_parameter.Controls.Add(this.clearPanel9);
      this.settings_group_parameter.Controls.Add(this.clearPanel8);
      this.settings_group_parameter.Controls.Add(this.clearPanel4);
      resources.ApplyResources(this.settings_group_parameter, "settings_group_parameter");
      this.settings_group_parameter.Name = "settings_group_parameter";
      // 
      // 
      // 
      this.settings_group_parameter.RootElement.MaxSize = new System.Drawing.Size(0, 0);
      // 
      // clearPanel9
      // 
      this.clearPanel9.Controls.Add(this.settings_frequenz_min);
      this.clearPanel9.Controls.Add(this.radLabel5);
      this.clearPanel9.Controls.Add(this.infoButton3);
      resources.ApplyResources(this.clearPanel9, "clearPanel9");
      this.clearPanel9.Name = "clearPanel9";
      // 
      // settings_frequenz_min
      // 
      resources.ApplyResources(this.settings_frequenz_min, "settings_frequenz_min");
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
      this.settings_frequenz_min.RootElement.MinSize = new System.Drawing.Size(0, 41);
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
      resources.ApplyResources(this.radLabel5, "radLabel5");
      this.radLabel5.Name = "radLabel5";
      // 
      // infoButton3
      // 
      resources.ApplyResources(this.infoButton3, "infoButton3");
      this.infoButton3.InfoDescription = resources.GetString("infoButton3.InfoDescription");
      this.infoButton3.InfoHeader = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.MinimumFilterFrequenz;
      this.infoButton3.InfoImage = null;
      this.infoButton3.Name = "infoButton3";
      // 
      // 
      // 
      this.infoButton3.RootElement.MaxSize = new System.Drawing.Size(41, 41);
      this.infoButton3.RootElement.MinSize = new System.Drawing.Size(41, 41);
      // 
      // clearPanel8
      // 
      this.clearPanel8.Controls.Add(this.settings_signifikanz_min);
      this.clearPanel8.Controls.Add(this.radLabel3);
      this.clearPanel8.Controls.Add(this.infoButton2);
      resources.ApplyResources(this.clearPanel8, "clearPanel8");
      this.clearPanel8.Name = "clearPanel8";
      // 
      // settings_signifikanz_min
      // 
      resources.ApplyResources(this.settings_signifikanz_min, "settings_signifikanz_min");
      this.settings_signifikanz_min.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
      this.settings_signifikanz_min.Name = "settings_signifikanz_min";
      // 
      // 
      // 
      this.settings_signifikanz_min.RootElement.MaxSize = new System.Drawing.Size(0, 0);
      this.settings_signifikanz_min.RootElement.MinSize = new System.Drawing.Size(138, 41);
      this.settings_signifikanz_min.TabStop = false;
      this.settings_signifikanz_min.ValueChanged += new System.EventHandler(this.settings_signifikanz_min_ValueChanged);
      // 
      // radLabel3
      // 
      resources.ApplyResources(this.radLabel3, "radLabel3");
      this.radLabel3.Name = "radLabel3";
      // 
      // infoButton2
      // 
      resources.ApplyResources(this.infoButton2, "infoButton2");
      this.infoButton2.InfoDescription = resources.GetString("infoButton2.InfoDescription");
      this.infoButton2.InfoHeader = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.MinimumFilterSignifikanz;
      this.infoButton2.InfoImage = null;
      this.infoButton2.Name = "infoButton2";
      // 
      // 
      // 
      this.infoButton2.RootElement.MaxSize = new System.Drawing.Size(41, 41);
      this.infoButton2.RootElement.MinSize = new System.Drawing.Size(41, 41);
      // 
      // clearPanel4
      // 
      this.clearPanel4.Controls.Add(this.radLabel2);
      this.clearPanel4.Controls.Add(this.settings_drop_signifikanz);
      this.clearPanel4.Controls.Add(this.infoButton1);
      resources.ApplyResources(this.clearPanel4, "clearPanel4");
      this.clearPanel4.Name = "clearPanel4";
      // 
      // radLabel2
      // 
      resources.ApplyResources(this.radLabel2, "radLabel2");
      this.radLabel2.Name = "radLabel2";
      // 
      // settings_drop_signifikanz
      // 
      this.settings_drop_signifikanz.AutoCompleteDisplayMember = null;
      this.settings_drop_signifikanz.AutoCompleteValueMember = null;
      resources.ApplyResources(this.settings_drop_signifikanz, "settings_drop_signifikanz");
      this.settings_drop_signifikanz.DropDownAnimationEnabled = true;
      this.settings_drop_signifikanz.DropDownHeight = 133;
      this.settings_drop_signifikanz.ItemHeight = 45;
      this.settings_drop_signifikanz.Name = "settings_drop_signifikanz";
      this.settings_drop_signifikanz.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.settings_drop_signifikanz_SelectedIndexChanged);
      // 
      // infoButton1
      // 
      resources.ApplyResources(this.infoButton1, "infoButton1");
      this.infoButton1.InfoDescription = resources.GetString("infoButton1.InfoDescription");
      this.infoButton1.InfoHeader = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Signifikanzmaß;
      this.infoButton1.InfoImage = null;
      this.infoButton1.Name = "infoButton1";
      // 
      // 
      // 
      this.infoButton1.RootElement.MaxSize = new System.Drawing.Size(41, 41);
      this.infoButton1.RootElement.MinSize = new System.Drawing.Size(41, 41);
      // 
      // splitPanel4
      // 
      this.splitPanel4.Controls.Add(this.radSplitContainer3);
      resources.ApplyResources(this.splitPanel4, "splitPanel4");
      this.splitPanel4.Name = "splitPanel4";
      // 
      // 
      // 
      this.splitPanel4.RootElement.MinSize = new System.Drawing.Size(0, 0);
      this.splitPanel4.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(0.03995156F, 0F);
      this.splitPanel4.SizeInfo.SplitterCorrection = new System.Drawing.Size(33, 0);
      this.splitPanel4.TabStop = false;
      // 
      // radSplitContainer3
      // 
      this.radSplitContainer3.Controls.Add(this.splitPanel5);
      this.radSplitContainer3.Controls.Add(this.splitPanel6);
      resources.ApplyResources(this.radSplitContainer3, "radSplitContainer3");
      this.radSplitContainer3.Name = "radSplitContainer3";
      // 
      // 
      // 
      this.radSplitContainer3.RootElement.MinSize = new System.Drawing.Size(0, 0);
      this.radSplitContainer3.SplitterWidth = 5;
      this.radSplitContainer3.TabStop = false;
      // 
      // splitPanel5
      // 
      this.splitPanel5.Controls.Add(this.radGroupBox4);
      resources.ApplyResources(this.splitPanel5, "splitPanel5");
      this.splitPanel5.Name = "splitPanel5";
      // 
      // 
      // 
      this.splitPanel5.RootElement.MinSize = new System.Drawing.Size(0, 0);
      this.splitPanel5.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(-0.01693001F, 0F);
      this.splitPanel5.TabStop = false;
      // 
      // radGroupBox4
      // 
      this.radGroupBox4.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox4.Controls.Add(this.radScrollablePanel5);
      resources.ApplyResources(this.radGroupBox4, "radGroupBox4");
      this.radGroupBox4.HeaderText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Werkzeuge;
      this.radGroupBox4.Name = "radGroupBox4";
      this.radGroupBox4.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Werkzeuge;
      // 
      // radScrollablePanel5
      // 
      resources.ApplyResources(this.radScrollablePanel5, "radScrollablePanel5");
      this.radScrollablePanel5.Name = "radScrollablePanel5";
      // 
      // radScrollablePanel5.PanelContainer
      // 
      this.radScrollablePanel5.PanelContainer.Controls.Add(this.settings_tool_totalReset);
      this.radScrollablePanel5.PanelContainer.Controls.Add(this.settings_tool_scriptEditor);
      this.radScrollablePanel5.PanelContainer.Controls.Add(this.settings_tool_errorconsole);
      this.radScrollablePanel5.PanelContainer.Controls.Add(this.settings_tool_upgrade);
      this.radScrollablePanel5.PanelContainer.Controls.Add(this.settings_tool_eraseCache);
      this.radScrollablePanel5.PanelContainer.Controls.Add(this.settings_tool_xpath);
      this.radScrollablePanel5.PanelContainer.Controls.Add(this.settings_tool_testCorpus);
      this.radScrollablePanel5.PanelContainer.Controls.Add(this.settings_tool_drmUsers);
      this.radScrollablePanel5.PanelContainer.Controls.Add(this.settings_tool_additionalTagger);
      this.radScrollablePanel5.PanelContainer.Controls.Add(this.settings_tool_exportCorpus);
      this.radScrollablePanel5.PanelContainer.Controls.Add(this.settings_tool_mergeCorpora);
      resources.ApplyResources(this.radScrollablePanel5.PanelContainer, "radScrollablePanel5.PanelContainer");
      // 
      // settings_tool_totalReset
      // 
      resources.ApplyResources(this.settings_tool_totalReset, "settings_tool_totalReset");
      this.settings_tool_totalReset.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.reload_rotate1;
      this.settings_tool_totalReset.Name = "settings_tool_totalReset";
      this.settings_tool_totalReset.TextWrap = true;
      this.settings_tool_totalReset.Click += new System.EventHandler(this.settings_tool_totalReset_Click);
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_totalReset.GetChildAt(0))).Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.reload_rotate1;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_totalReset.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_totalReset.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_totalReset.GetChildAt(0))).TextAlignment = ((System.Drawing.ContentAlignment)(resources.GetObject("resource.TextAlignment")));
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_totalReset.GetChildAt(0))).Text = resources.GetString("resource.Text");
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_totalReset.GetChildAt(0))).Font = new System.Drawing.Font("Segoe UI", 9F);
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_totalReset.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextWrap = ((bool)(resources.GetObject("resource.TextWrap")));
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_totalReset.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = true;
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_totalReset.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Segoe UI", 9F);
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_totalReset.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = ((System.Drawing.ContentAlignment)(resources.GetObject("resource.Alignment")));
      // 
      // settings_tool_scriptEditor
      // 
      resources.ApplyResources(this.settings_tool_scriptEditor, "settings_tool_scriptEditor");
      this.settings_tool_scriptEditor.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.execute1;
      this.settings_tool_scriptEditor.Name = "settings_tool_scriptEditor";
      this.settings_tool_scriptEditor.TextWrap = true;
      this.settings_tool_scriptEditor.Click += new System.EventHandler(this.settings_tool_scriptEditor_Click);
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_scriptEditor.GetChildAt(0))).Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.execute1;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_scriptEditor.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_scriptEditor.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_scriptEditor.GetChildAt(0))).TextAlignment = ((System.Drawing.ContentAlignment)(resources.GetObject("resource.TextAlignment1")));
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_scriptEditor.GetChildAt(0))).Text = resources.GetString("resource.Text1");
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_scriptEditor.GetChildAt(0))).Font = new System.Drawing.Font("Segoe UI", 9F);
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_scriptEditor.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextWrap = ((bool)(resources.GetObject("resource.TextWrap1")));
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_scriptEditor.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = true;
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_scriptEditor.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Segoe UI", 9F);
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_scriptEditor.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = ((System.Drawing.ContentAlignment)(resources.GetObject("resource.Alignment1")));
      // 
      // settings_tool_errorconsole
      // 
      resources.ApplyResources(this.settings_tool_errorconsole, "settings_tool_errorconsole");
      this.settings_tool_errorconsole.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.worker;
      this.settings_tool_errorconsole.Name = "settings_tool_errorconsole";
      this.settings_tool_errorconsole.TextWrap = true;
      this.settings_tool_errorconsole.Click += new System.EventHandler(this.settings_tool_errorconsole_Click);
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_errorconsole.GetChildAt(0))).Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.worker;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_errorconsole.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_errorconsole.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_errorconsole.GetChildAt(0))).TextAlignment = ((System.Drawing.ContentAlignment)(resources.GetObject("resource.TextAlignment2")));
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_errorconsole.GetChildAt(0))).Text = resources.GetString("resource.Text2");
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_errorconsole.GetChildAt(0))).Font = new System.Drawing.Font("Segoe UI", 9F);
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_errorconsole.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextWrap = ((bool)(resources.GetObject("resource.TextWrap2")));
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_errorconsole.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = true;
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_errorconsole.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Segoe UI", 9F);
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_errorconsole.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = ((System.Drawing.ContentAlignment)(resources.GetObject("resource.Alignment2")));
      // 
      // settings_tool_upgrade
      // 
      resources.ApplyResources(this.settings_tool_upgrade, "settings_tool_upgrade");
      this.settings_tool_upgrade.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.upload;
      this.settings_tool_upgrade.Name = "settings_tool_upgrade";
      this.settings_tool_upgrade.TextWrap = true;
      this.settings_tool_upgrade.Click += new System.EventHandler(this.settings_upgrade_btn_Click);
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_upgrade.GetChildAt(0))).Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.upload;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_upgrade.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_upgrade.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_upgrade.GetChildAt(0))).Text = resources.GetString("resource.Text3");
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_upgrade.GetChildAt(0))).Font = new System.Drawing.Font("Segoe UI", 9F);
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_upgrade.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextWrap = ((bool)(resources.GetObject("resource.TextWrap3")));
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_upgrade.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = true;
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_upgrade.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Segoe UI", 9F);
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_upgrade.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = ((System.Drawing.ContentAlignment)(resources.GetObject("resource.Alignment3")));
      // 
      // settings_tool_eraseCache
      // 
      resources.ApplyResources(this.settings_tool_eraseCache, "settings_tool_eraseCache");
      this.settings_tool_eraseCache.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.erase;
      this.settings_tool_eraseCache.Name = "settings_tool_eraseCache";
      this.settings_tool_eraseCache.TextWrap = true;
      this.settings_tool_eraseCache.Click += new System.EventHandler(this.settings_tool_eraseCache_Click);
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_eraseCache.GetChildAt(0))).Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.erase;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_eraseCache.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_eraseCache.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_eraseCache.GetChildAt(0))).TextAlignment = ((System.Drawing.ContentAlignment)(resources.GetObject("resource.TextAlignment3")));
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_eraseCache.GetChildAt(0))).Text = resources.GetString("resource.Text4");
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_eraseCache.GetChildAt(0))).Font = new System.Drawing.Font("Segoe UI", 9F);
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_eraseCache.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextWrap = ((bool)(resources.GetObject("resource.TextWrap4")));
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_eraseCache.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = true;
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_eraseCache.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Segoe UI", 9F);
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_eraseCache.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = ((System.Drawing.ContentAlignment)(resources.GetObject("resource.Alignment4")));
      // 
      // settings_tool_xpath
      // 
      resources.ApplyResources(this.settings_tool_xpath, "settings_tool_xpath");
      this.settings_tool_xpath.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.xml_root;
      this.settings_tool_xpath.Name = "settings_tool_xpath";
      this.settings_tool_xpath.TextWrap = true;
      this.settings_tool_xpath.Click += new System.EventHandler(this.settings_tool_xpath_Click);
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_xpath.GetChildAt(0))).Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.xml_root;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_xpath.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_xpath.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_xpath.GetChildAt(0))).TextAlignment = ((System.Drawing.ContentAlignment)(resources.GetObject("resource.TextAlignment4")));
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_xpath.GetChildAt(0))).Text = resources.GetString("resource.Text5");
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_xpath.GetChildAt(0))).Font = new System.Drawing.Font("Segoe UI", 9F);
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_xpath.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextWrap = ((bool)(resources.GetObject("resource.TextWrap5")));
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_xpath.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = true;
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_xpath.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Segoe UI", 9F);
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_xpath.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = ((System.Drawing.ContentAlignment)(resources.GetObject("resource.Alignment5")));
      // 
      // settings_tool_testCorpus
      // 
      resources.ApplyResources(this.settings_tool_testCorpus, "settings_tool_testCorpus");
      this.settings_tool_testCorpus.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.test_properties;
      this.settings_tool_testCorpus.Name = "settings_tool_testCorpus";
      this.settings_tool_testCorpus.TextWrap = true;
      this.settings_tool_testCorpus.Click += new System.EventHandler(this.settings_tool_testCorpus_Click);
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_testCorpus.GetChildAt(0))).Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.test_properties;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_testCorpus.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_testCorpus.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_testCorpus.GetChildAt(0))).TextAlignment = ((System.Drawing.ContentAlignment)(resources.GetObject("resource.TextAlignment5")));
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_testCorpus.GetChildAt(0))).Text = resources.GetString("resource.Text6");
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_testCorpus.GetChildAt(0))).Font = new System.Drawing.Font("Segoe UI", 9F);
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_testCorpus.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextWrap = ((bool)(resources.GetObject("resource.TextWrap6")));
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_testCorpus.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = true;
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_testCorpus.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Segoe UI", 9F);
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_testCorpus.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = ((System.Drawing.ContentAlignment)(resources.GetObject("resource.Alignment6")));
      // 
      // settings_tool_drmUsers
      // 
      resources.ApplyResources(this.settings_tool_drmUsers, "settings_tool_drmUsers");
      this.settings_tool_drmUsers.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.padlock_round;
      this.settings_tool_drmUsers.Name = "settings_tool_drmUsers";
      this.settings_tool_drmUsers.TextWrap = true;
      this.settings_tool_drmUsers.Click += new System.EventHandler(this.settings_tool_drmUsers_Click);
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_drmUsers.GetChildAt(0))).Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.padlock_round;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_drmUsers.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_drmUsers.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_drmUsers.GetChildAt(0))).TextAlignment = ((System.Drawing.ContentAlignment)(resources.GetObject("resource.TextAlignment6")));
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_drmUsers.GetChildAt(0))).Text = resources.GetString("resource.Text7");
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_drmUsers.GetChildAt(0))).Font = new System.Drawing.Font("Segoe UI", 9F);
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_drmUsers.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextWrap = ((bool)(resources.GetObject("resource.TextWrap7")));
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_drmUsers.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = true;
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_drmUsers.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Segoe UI", 9F);
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_drmUsers.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = ((System.Drawing.ContentAlignment)(resources.GetObject("resource.Alignment7")));
      // 
      // settings_tool_additionalTagger
      // 
      resources.ApplyResources(this.settings_tool_additionalTagger, "settings_tool_additionalTagger");
      this.settings_tool_additionalTagger.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.tag_green1;
      this.settings_tool_additionalTagger.Name = "settings_tool_additionalTagger";
      this.settings_tool_additionalTagger.TextWrap = true;
      this.settings_tool_additionalTagger.Click += new System.EventHandler(this.settings_tool_additionalTagger_Click);
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_additionalTagger.GetChildAt(0))).Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.tag_green1;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_additionalTagger.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_additionalTagger.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_additionalTagger.GetChildAt(0))).TextAlignment = ((System.Drawing.ContentAlignment)(resources.GetObject("resource.TextAlignment7")));
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_additionalTagger.GetChildAt(0))).Text = resources.GetString("resource.Text8");
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_additionalTagger.GetChildAt(0))).Font = new System.Drawing.Font("Segoe UI", 9F);
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_additionalTagger.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextWrap = ((bool)(resources.GetObject("resource.TextWrap8")));
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_additionalTagger.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = true;
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_additionalTagger.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Segoe UI", 9F);
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_additionalTagger.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = ((System.Drawing.ContentAlignment)(resources.GetObject("resource.Alignment8")));
      // 
      // settings_tool_exportCorpus
      // 
      resources.ApplyResources(this.settings_tool_exportCorpus, "settings_tool_exportCorpus");
      this.settings_tool_exportCorpus.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.export_to_database;
      this.settings_tool_exportCorpus.Name = "settings_tool_exportCorpus";
      this.settings_tool_exportCorpus.TextWrap = true;
      this.settings_tool_exportCorpus.Click += new System.EventHandler(this.settings_tool_exportCorpus_Click);
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_exportCorpus.GetChildAt(0))).Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.export_to_database;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_exportCorpus.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_exportCorpus.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_exportCorpus.GetChildAt(0))).TextAlignment = ((System.Drawing.ContentAlignment)(resources.GetObject("resource.TextAlignment8")));
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_exportCorpus.GetChildAt(0))).Text = resources.GetString("resource.Text9");
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_exportCorpus.GetChildAt(0))).Font = new System.Drawing.Font("Segoe UI", 9F);
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_exportCorpus.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextWrap = ((bool)(resources.GetObject("resource.TextWrap9")));
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_exportCorpus.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = true;
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_exportCorpus.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Segoe UI", 9F);
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_exportCorpus.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = ((System.Drawing.ContentAlignment)(resources.GetObject("resource.Alignment9")));
      // 
      // settings_tool_mergeCorpora
      // 
      resources.ApplyResources(this.settings_tool_mergeCorpora, "settings_tool_mergeCorpora");
      this.settings_tool_mergeCorpora.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.table_merge_columns1;
      this.settings_tool_mergeCorpora.Name = "settings_tool_mergeCorpora";
      this.settings_tool_mergeCorpora.TextWrap = true;
      this.settings_tool_mergeCorpora.Click += new System.EventHandler(this.settings_tool_mergeCorpora_Click);
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_mergeCorpora.GetChildAt(0))).Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.table_merge_columns1;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_mergeCorpora.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_mergeCorpora.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_mergeCorpora.GetChildAt(0))).TextAlignment = ((System.Drawing.ContentAlignment)(resources.GetObject("resource.TextAlignment9")));
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_mergeCorpora.GetChildAt(0))).Text = resources.GetString("resource.Text10");
      ((Telerik.WinControls.UI.RadButtonElement)(this.settings_tool_mergeCorpora.GetChildAt(0))).Font = new System.Drawing.Font("Segoe UI", 9F);
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_mergeCorpora.GetChildAt(0).GetChildAt(1).GetChildAt(1))).TextWrap = ((bool)(resources.GetObject("resource.TextWrap10")));
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_mergeCorpora.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = true;
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_mergeCorpora.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Segoe UI", 9F);
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.settings_tool_mergeCorpora.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = ((System.Drawing.ContentAlignment)(resources.GetObject("resource.Alignment10")));
      // 
      // splitPanel6
      // 
      this.splitPanel6.Controls.Add(this.radGroupBox9);
      resources.ApplyResources(this.splitPanel6, "splitPanel6");
      this.splitPanel6.Name = "splitPanel6";
      // 
      // 
      // 
      this.splitPanel6.RootElement.MinSize = new System.Drawing.Size(0, 0);
      this.splitPanel6.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(0.01693004F, 0F);
      this.splitPanel6.TabStop = false;
      // 
      // radGroupBox9
      // 
      this.radGroupBox9.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox9.Controls.Add(this.settings_list_favorites);
      resources.ApplyResources(this.radGroupBox9, "radGroupBox9");
      this.radGroupBox9.Name = "radGroupBox9";
      // 
      // settings_list_favorites
      // 
      resources.ApplyResources(this.settings_list_favorites, "settings_list_favorites");
      this.settings_list_favorites.GroupIndent = 31;
      this.settings_list_favorites.GroupItemSize = new System.Drawing.Size(250, 50);
      this.settings_list_favorites.HeaderHeight = 43.75F;
      this.settings_list_favorites.ItemSize = new System.Drawing.Size(250, 50);
      this.settings_list_favorites.Name = "settings_list_favorites";
      this.settings_list_favorites.ItemCheckedChanged += new Telerik.WinControls.UI.ListViewItemEventHandler(this.settings_list_favorites_ItemCheckedChanged);
      // 
      // header10
      // 
      resources.ApplyResources(this.header10, "header10");
      this.header10.BackColor = System.Drawing.Color.White;
      this.header10.HeaderDescription = "Diese Einstellungen sind für das gesamte Projekt gültig und werden in der Projekt" +
    "datei gespeichert. Einige Einstellungen haben einen direkten Einfluss auf das An" +
    "alyseergebnis.";
      this.header10.HeaderHead = "Projekteinstellungen";
      this.header10.Name = "header10";
      // 
      // radScrollablePanel8
      // 
      resources.ApplyResources(this.radScrollablePanel8, "radScrollablePanel8");
      this.radScrollablePanel8.Name = "radScrollablePanel8";
      // 
      // radScrollablePanel8.PanelContainer
      // 
      resources.ApplyResources(this.radScrollablePanel8.PanelContainer, "radScrollablePanel8.PanelContainer");
      // 
      // radScrollablePanel10
      // 
      resources.ApplyResources(this.radScrollablePanel10, "radScrollablePanel10");
      this.radScrollablePanel10.Name = "radScrollablePanel10";
      // 
      // radScrollablePanel10.PanelContainer
      // 
      this.radScrollablePanel10.PanelContainer.Controls.Add(this.radScrollablePanel8);
      this.radScrollablePanel10.PanelContainer.Controls.Add(this.header13);
      this.radScrollablePanel10.PanelContainer.Controls.Add(this.radListView1);
      this.radScrollablePanel10.PanelContainer.Controls.Add(this.header6);
      this.radScrollablePanel10.PanelContainer.Controls.Add(this.helpPanel1);
      this.radScrollablePanel10.PanelContainer.Controls.Add(this.radScrollablePanel11);
      this.radScrollablePanel10.PanelContainer.Controls.Add(this.header2);
      this.radScrollablePanel10.PanelContainer.Controls.Add(this.header1);
      resources.ApplyResources(this.radScrollablePanel10.PanelContainer, "radScrollablePanel10.PanelContainer");
      // 
      // header13
      // 
      resources.ApplyResources(this.header13, "header13");
      this.header13.BackColor = System.Drawing.Color.White;
      this.header13.HeaderDescription = "Folgende Add-ons können Sie installieren, um den Funktionsumfang des CorpusExplor" +
    "ers zu erweitern.";
      this.header13.HeaderHead = "Verfügbare Add-ons";
      this.header13.Name = "header13";
      // 
      // radListView1
      // 
      this.radListView1.AllowEdit = false;
      this.radListView1.AllowRemove = false;
      resources.ApplyResources(this.radListView1, "radListView1");
      this.radListView1.GroupIndent = 95;
      this.radListView1.GroupItemSize = new System.Drawing.Size(764, 155);
      this.radListView1.HeaderHeight = 133.5144F;
      resources.ApplyResources(listViewDataItem1, "listViewDataItem1");
      this.radListView1.Items.AddRange(new Telerik.WinControls.UI.ListViewDataItem[] {
            listViewDataItem1});
      this.radListView1.ItemSize = new System.Drawing.Size(764, 155);
      this.radListView1.Name = "radListView1";
      this.radListView1.VerticalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
      this.radListView1.ItemMouseClick += new Telerik.WinControls.UI.ListViewItemEventHandler(this.OpenRssFeedItemClick);
      // 
      // header6
      // 
      resources.ApplyResources(this.header6, "header6");
      this.header6.BackColor = System.Drawing.Color.White;
      this.header6.HeaderDescription = "Per Klick auf einen Eintrag gelangen Sie zur aktuellen Infos rund um den CorpusEx" +
    "plorer - Workshops, Infos zu Updates, uvm.";
      this.header6.HeaderHead = "Aktuelles und Neuigkeiten";
      this.header6.Name = "header6";
      // 
      // helpPanel1
      // 
      this.helpPanel1.BackColor = System.Drawing.Color.White;
      resources.ApplyResources(this.helpPanel1, "helpPanel1");
      this.helpPanel1.HelpHandbookText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.InteraktivesHandbuch;
      this.helpPanel1.HelpHandbookUrl = "http://www.bitcutstudios.com/products/corpusexplorer/help/nutzerhandbuch.html";
      this.helpPanel1.HelpHandsonlabText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.PraktischeÜbungen;
      this.helpPanel1.HelpHandsonlabUrl = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Help_Static_HandsOnLab;
      this.helpPanel1.HelpLabelDescription = "Diese Hilfe bietet Ihnen praktische Tipps und ist interaktiv gestaltet (setzt ein" +
    "e Internetverbindung voraus).";
      this.helpPanel1.HelpLabelHeader = "Erste Schritte mit dem CorpusExplorer";
      this.helpPanel1.HelpOnlineText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.WeitereInformationen;
      this.helpPanel1.HelpOnlineUrl = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Help_Static_AdditionalInformation;
      this.helpPanel1.HelpVideoText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.KurzesEinstiegsvideo;
      this.helpPanel1.HelpVideoUrl = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Help_Static_YoutubeChannel;
      this.helpPanel1.Name = "helpPanel1";
      // 
      // radScrollablePanel11
      // 
      resources.ApplyResources(this.radScrollablePanel11, "radScrollablePanel11");
      this.radScrollablePanel11.Name = "radScrollablePanel11";
      // 
      // radScrollablePanel11.PanelContainer
      // 
      this.radScrollablePanel11.PanelContainer.Controls.Add(this.page_welcome_btn_analytics);
      this.radScrollablePanel11.PanelContainer.Controls.Add(this.page_welcome_btn_snapshot);
      this.radScrollablePanel11.PanelContainer.Controls.Add(this.page_welcome_btn_corpus);
      this.radScrollablePanel11.PanelContainer.Controls.Add(this.page_welcome_btn_projectname);
      resources.ApplyResources(this.radScrollablePanel11.PanelContainer, "radScrollablePanel11.PanelContainer");
      this.radScrollablePanel11.VerticalScrollBarState = Telerik.WinControls.UI.ScrollState.AlwaysHide;
      ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radScrollablePanel11.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
      // 
      // page_welcome_btn_analytics
      // 
      this.page_welcome_btn_analytics.BackColor = System.Drawing.Color.White;
      resources.ApplyResources(this.page_welcome_btn_analytics, "page_welcome_btn_analytics");
      this.page_welcome_btn_analytics.Image = ((System.Drawing.Image)(resources.GetObject("page_welcome_btn_analytics.Image")));
      this.page_welcome_btn_analytics.ImageCheckmark = ((System.Drawing.Image)(resources.GetObject("page_welcome_btn_analytics.ImageCheckmark")));
      this.page_welcome_btn_analytics.Label = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.NeueAnalyseStarten;
      this.page_welcome_btn_analytics.Name = "page_welcome_btn_analytics";
      this.page_welcome_btn_analytics.ShowCheckmark = false;
      this.page_welcome_btn_analytics.Click += new System.EventHandler(this.main_mainmenu_analytics_Click);
      // 
      // page_welcome_btn_snapshot
      // 
      this.page_welcome_btn_snapshot.BackColor = System.Drawing.Color.White;
      resources.ApplyResources(this.page_welcome_btn_snapshot, "page_welcome_btn_snapshot");
      this.page_welcome_btn_snapshot.Image = ((System.Drawing.Image)(resources.GetObject("page_welcome_btn_snapshot.Image")));
      this.page_welcome_btn_snapshot.ImageCheckmark = ((System.Drawing.Image)(resources.GetObject("page_welcome_btn_snapshot.ImageCheckmark")));
      this.page_welcome_btn_snapshot.Label = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.SchnappschussErstellen;
      this.page_welcome_btn_snapshot.Name = "page_welcome_btn_snapshot";
      this.page_welcome_btn_snapshot.ShowCheckmark = false;
      this.page_welcome_btn_snapshot.Click += new System.EventHandler(this.main_mainmenu_snapshot_Click);
      // 
      // page_welcome_btn_corpus
      // 
      this.page_welcome_btn_corpus.BackColor = System.Drawing.Color.White;
      resources.ApplyResources(this.page_welcome_btn_corpus, "page_welcome_btn_corpus");
      this.page_welcome_btn_corpus.Image = ((System.Drawing.Image)(resources.GetObject("page_welcome_btn_corpus.Image")));
      this.page_welcome_btn_corpus.ImageCheckmark = ((System.Drawing.Image)(resources.GetObject("page_welcome_btn_corpus.ImageCheckmark")));
      this.page_welcome_btn_corpus.Label = "<html>Mindestens ein<br/>Korpus laden</html>";
      this.page_welcome_btn_corpus.Name = "page_welcome_btn_corpus";
      this.page_welcome_btn_corpus.ShowCheckmark = false;
      this.page_welcome_btn_corpus.Click += new System.EventHandler(this.main_mainmenu_corpus_Click);
      // 
      // page_welcome_btn_projectname
      // 
      this.page_welcome_btn_projectname.BackColor = System.Drawing.Color.White;
      resources.ApplyResources(this.page_welcome_btn_projectname, "page_welcome_btn_projectname");
      this.page_welcome_btn_projectname.Image = ((System.Drawing.Image)(resources.GetObject("page_welcome_btn_projectname.Image")));
      this.page_welcome_btn_projectname.ImageCheckmark = ((System.Drawing.Image)(resources.GetObject("page_welcome_btn_projectname.ImageCheckmark")));
      this.page_welcome_btn_projectname.Label = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.ProjektnamenVergeben;
      this.page_welcome_btn_projectname.Name = "page_welcome_btn_projectname";
      this.page_welcome_btn_projectname.ShowCheckmark = false;
      this.page_welcome_btn_projectname.Click += new System.EventHandler(this.page_welcome_btn_projectname_Click);
      // 
      // header2
      // 
      resources.ApplyResources(this.header2, "header2");
      this.header2.BackColor = System.Drawing.Color.White;
      this.header2.HeaderDescription = "Diese Liste führt alle Schritte auf und geleitet Sie durch den Analyseprozess.";
      this.header2.HeaderHead = "Die Checkliste für eine gelungene Analyse:";
      this.header2.Name = "header2";
      // 
      // header1
      // 
      resources.ApplyResources(this.header1, "header1");
      this.header1.BackColor = System.Drawing.Color.White;
      this.header1.HeaderDescription = resources.GetString("header1.HeaderDescription");
      this.header1.HeaderHead = "Herzlich willkommen!";
      this.header1.Name = "header1";
      // 
      // radScrollablePanel7
      // 
      resources.ApplyResources(this.radScrollablePanel7, "radScrollablePanel7");
      this.radScrollablePanel7.Name = "radScrollablePanel7";
      // 
      // radScrollablePanel7.PanelContainer
      // 
      this.radScrollablePanel7.PanelContainer.Controls.Add(this.radScrollablePanel9);
      this.radScrollablePanel7.PanelContainer.Controls.Add(this.header14);
      this.radScrollablePanel7.PanelContainer.Controls.Add(this.helpPanel2);
      this.radScrollablePanel7.PanelContainer.Controls.Add(this.infoPanel_korpora);
      this.radScrollablePanel7.PanelContainer.Controls.Add(this.header4);
      this.radScrollablePanel7.PanelContainer.Controls.Add(this.radScrollablePanel12);
      this.radScrollablePanel7.PanelContainer.Controls.Add(this.header3);
      resources.ApplyResources(this.radScrollablePanel7.PanelContainer, "radScrollablePanel7.PanelContainer");
      // 
      // header14
      // 
      resources.ApplyResources(this.header14, "header14");
      this.header14.BackColor = System.Drawing.Color.White;
      this.header14.HeaderDescription = "Folgende Korpora können Sie abonnieren und frei verwenden - z. B. als Referenzkor" +
    "pus oder zu Übungszwecken...";
      this.header14.HeaderHead = "Frei verfügbare Korpora";
      this.header14.Name = "header14";
      // 
      // helpPanel2
      // 
      this.helpPanel2.BackColor = System.Drawing.Color.White;
      resources.ApplyResources(this.helpPanel2, "helpPanel2");
      this.helpPanel2.HelpHandbookText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.InteraktivesHandbuch;
      this.helpPanel2.HelpHandbookUrl = "http://www.bitcutstudios.com/products/corpusexplorer/help/korpora.html";
      this.helpPanel2.HelpHandsonlabText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.PraktischeÜbungen;
      this.helpPanel2.HelpHandsonlabUrl = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Help_Static_HandsOnLab;
      this.helpPanel2.HelpLabelDescription = "Diese Hilfe zeigt Schritt für Schritt wie Sie ganz schnell und einfach Korpusmate" +
    "rial sammeln und aufbereiten.";
      this.helpPanel2.HelpLabelHeader = "Hilfe bei der Materialakquise - Wie erstelle/nutze ich Korpora?";
      this.helpPanel2.HelpOnlineText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.WeitereInformationen;
      this.helpPanel2.HelpOnlineUrl = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Help_Static_AdditionalInformation;
      this.helpPanel2.HelpVideoText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.KurzesEinstiegsvideo;
      this.helpPanel2.HelpVideoUrl = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Help_Static_YoutubeChannel;
      this.helpPanel2.Name = "helpPanel2";
      // 
      // infoPanel_korpora
      // 
      this.infoPanel_korpora.BackColor = System.Drawing.Color.White;
      this.infoPanel_korpora.CountCorpora = ((long)(0));
      this.infoPanel_korpora.CountDocuments = ((long)(0));
      this.infoPanel_korpora.CountLayers = ((long)(0));
      this.infoPanel_korpora.CountTokens = ((long)(0));
      resources.ApplyResources(this.infoPanel_korpora, "infoPanel_korpora");
      this.infoPanel_korpora.Name = "infoPanel_korpora";
      // 
      // header4
      // 
      resources.ApplyResources(this.header4, "header4");
      this.header4.BackColor = System.Drawing.Color.White;
      this.header4.HeaderDescription = "Das aktuelle Projekt umfasst folgende Datenbestände:";
      this.header4.HeaderHead = "QuickInfo: Alle Korpora im aktuellen Projekt";
      this.header4.Name = "header4";
      // 
      // radScrollablePanel12
      // 
      resources.ApplyResources(this.radScrollablePanel12, "radScrollablePanel12");
      this.radScrollablePanel12.Name = "radScrollablePanel12";
      // 
      // radScrollablePanel12.PanelContainer
      // 
      this.radScrollablePanel12.PanelContainer.Controls.Add(this.corpus_start_korap);
      this.radScrollablePanel12.PanelContainer.Controls.Add(this.corpus_start_dpxc);
      this.radScrollablePanel12.PanelContainer.Controls.Add(this.corpus_start_online);
      this.radScrollablePanel12.PanelContainer.Controls.Add(this.corpus_start_import);
      this.radScrollablePanel12.PanelContainer.Controls.Add(this.corpus_start_local);
      this.radScrollablePanel12.PanelContainer.Controls.Add(this.corpus_start_add);
      resources.ApplyResources(this.radScrollablePanel12.PanelContainer, "radScrollablePanel12.PanelContainer");
      this.radScrollablePanel12.VerticalScrollBarState = Telerik.WinControls.UI.ScrollState.AlwaysHide;
      ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radScrollablePanel12.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
      // 
      // corpus_start_korap
      // 
      this.corpus_start_korap.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.cabinet_korap_48;
      resources.ApplyResources(this.corpus_start_korap, "corpus_start_korap");
      this.corpus_start_korap.Name = "corpus_start_korap";
      this.corpus_start_korap.TextWrap = true;
      this.corpus_start_korap.Click += new System.EventHandler(this.corpus_start_korap_Click);
      // 
      // corpus_start_dpxc
      // 
      this.corpus_start_dpxc.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.corpus_dpxc48;
      resources.ApplyResources(this.corpus_start_dpxc, "corpus_start_dpxc");
      this.corpus_start_dpxc.Name = "corpus_start_dpxc";
      this.corpus_start_dpxc.TextWrap = true;
      this.corpus_start_dpxc.Click += new System.EventHandler(this.corpus_start_dpxc_Click);
      // 
      // corpus_start_online
      // 
      this.corpus_start_online.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.corpus_online;
      resources.ApplyResources(this.corpus_start_online, "corpus_start_online");
      this.corpus_start_online.Name = "corpus_start_online";
      this.corpus_start_online.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.OnlineKorpusAkquirieren;
      this.corpus_start_online.TextWrap = true;
      this.corpus_start_online.Click += new System.EventHandler(this.corpus_start_online_Click);
      // 
      // corpus_start_import
      // 
      this.corpus_start_import.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.corpus_extern;
      resources.ApplyResources(this.corpus_start_import, "corpus_start_import");
      this.corpus_start_import.Name = "corpus_start_import";
      this.corpus_start_import.TextWrap = true;
      this.corpus_start_import.Click += new System.EventHandler(this.corpus_start_import_Click);
      // 
      // corpus_start_local
      // 
      this.corpus_start_local.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.corpus_local;
      resources.ApplyResources(this.corpus_start_local, "corpus_start_local");
      this.corpus_start_local.Name = "corpus_start_local";
      this.corpus_start_local.TextWrap = true;
      this.corpus_start_local.Click += new System.EventHandler(this.corpus_start_local_Click);
      // 
      // corpus_start_add
      // 
      this.corpus_start_add.DropDownDirection = Telerik.WinControls.UI.RadDirection.Right;
      this.corpus_start_add.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.cabinet;
      this.corpus_start_add.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
      resources.ApplyResources(this.corpus_start_add, "corpus_start_add");
      this.corpus_start_add.Name = "corpus_start_add";
      this.corpus_start_add.ShowArrow = false;
      this.corpus_start_add.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
      this.corpus_start_add.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      // 
      // header3
      // 
      resources.ApplyResources(this.header3, "header3");
      this.header3.BackColor = System.Drawing.Color.White;
      this.header3.HeaderDescription = resources.GetString("header3.HeaderDescription");
      this.header3.HeaderHead = "Korpus hinzufügen";
      this.header3.Name = "header3";
      // 
      // radScrollablePanel3
      // 
      resources.ApplyResources(this.radScrollablePanel3, "radScrollablePanel3");
      this.radScrollablePanel3.Name = "radScrollablePanel3";
      // 
      // radScrollablePanel3.PanelContainer
      // 
      this.radScrollablePanel3.PanelContainer.Controls.Add(this.clearPanel1);
      this.radScrollablePanel3.PanelContainer.Controls.Add(this.helpPanel3);
      this.radScrollablePanel3.PanelContainer.Controls.Add(this.infoPanel_snapshot);
      this.radScrollablePanel3.PanelContainer.Controls.Add(this.header12);
      this.radScrollablePanel3.PanelContainer.Controls.Add(this.radPanel8);
      this.radScrollablePanel3.PanelContainer.Controls.Add(this.header7);
      this.radScrollablePanel3.PanelContainer.Controls.Add(this.page_analytics_snapshot_noexport);
      resources.ApplyResources(this.radScrollablePanel3.PanelContainer, "radScrollablePanel3.PanelContainer");
      // 
      // clearPanel1
      // 
      this.clearPanel1.Controls.Add(this.panel_bridge);
      this.clearPanel1.Controls.Add(this.clearPanel2);
      this.clearPanel1.Controls.Add(this.header15);
      resources.ApplyResources(this.clearPanel1, "clearPanel1");
      this.clearPanel1.Name = "clearPanel1";
      // 
      // panel_bridge
      // 
      this.panel_bridge.Controls.Add(this.clearPanel11);
      this.panel_bridge.Controls.Add(this.lbl_bridge_status);
      this.panel_bridge.Controls.Add(this.radLabel7);
      this.panel_bridge.Controls.Add(this.txt_bridge_port);
      this.panel_bridge.Controls.Add(this.radLabel6);
      this.panel_bridge.Controls.Add(this.txt_bridge_ip);
      this.panel_bridge.Controls.Add(this.radLabel4);
      this.panel_bridge.Controls.Add(this.clearPanel10);
      resources.ApplyResources(this.panel_bridge, "panel_bridge");
      this.panel_bridge.Name = "panel_bridge";
      // 
      // clearPanel11
      // 
      this.clearPanel11.Controls.Add(this.btn_bridge_reload);
      resources.ApplyResources(this.clearPanel11, "clearPanel11");
      this.clearPanel11.Name = "clearPanel11";
      // 
      // btn_bridge_reload
      // 
      resources.ApplyResources(this.btn_bridge_reload, "btn_bridge_reload");
      this.btn_bridge_reload.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.refresh;
      this.btn_bridge_reload.Name = "btn_bridge_reload";
      // 
      // 
      // 
      this.btn_bridge_reload.RootElement.MaxSize = new System.Drawing.Size(190, 34);
      this.btn_bridge_reload.RootElement.MinSize = new System.Drawing.Size(190, 34);
      this.btn_bridge_reload.Click += new System.EventHandler(this.btn_bridge_reload_Click);
      // 
      // lbl_bridge_status
      // 
      resources.ApplyResources(this.lbl_bridge_status, "lbl_bridge_status");
      this.lbl_bridge_status.ForeColor = System.Drawing.Color.Red;
      this.lbl_bridge_status.Name = "lbl_bridge_status";
      // 
      // radLabel7
      // 
      resources.ApplyResources(this.radLabel7, "radLabel7");
      this.radLabel7.Name = "radLabel7";
      // 
      // txt_bridge_port
      // 
      resources.ApplyResources(this.txt_bridge_port, "txt_bridge_port");
      this.txt_bridge_port.MaxLength = 5;
      this.txt_bridge_port.Name = "txt_bridge_port";
      this.txt_bridge_port.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // radLabel6
      // 
      resources.ApplyResources(this.radLabel6, "radLabel6");
      this.radLabel6.Name = "radLabel6";
      // 
      // txt_bridge_ip
      // 
      resources.ApplyResources(this.txt_bridge_ip, "txt_bridge_ip");
      this.txt_bridge_ip.Name = "txt_bridge_ip";
      this.txt_bridge_ip.TabStop = false;
      this.txt_bridge_ip.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // radLabel4
      // 
      resources.ApplyResources(this.radLabel4, "radLabel4");
      this.radLabel4.Name = "radLabel4";
      // 
      // clearPanel10
      // 
      this.clearPanel10.Controls.Add(this.radLabel9);
      resources.ApplyResources(this.clearPanel10, "clearPanel10");
      this.clearPanel10.Name = "clearPanel10";
      // 
      // radLabel9
      // 
      resources.ApplyResources(this.radLabel9, "radLabel9");
      this.radLabel9.Name = "radLabel9";
      // 
      // clearPanel2
      // 
      this.clearPanel2.Controls.Add(this.radLabel1);
      this.clearPanel2.Controls.Add(this.switch_bridge);
      resources.ApplyResources(this.clearPanel2, "clearPanel2");
      this.clearPanel2.Name = "clearPanel2";
      // 
      // radLabel1
      // 
      resources.ApplyResources(this.radLabel1, "radLabel1");
      this.radLabel1.Name = "radLabel1";
      // 
      // switch_bridge
      // 
      resources.ApplyResources(this.switch_bridge, "switch_bridge");
      this.switch_bridge.Name = "switch_bridge";
      // 
      // 
      // 
      this.switch_bridge.RootElement.MaxSize = new System.Drawing.Size(60, 32);
      this.switch_bridge.RootElement.MinSize = new System.Drawing.Size(60, 32);
      this.switch_bridge.ThumbTickness = 30;
      this.switch_bridge.Value = false;
      this.switch_bridge.ValueChanged += new System.EventHandler(this.switch_bridge_ValueChanged);
      // 
      // header15
      // 
      resources.ApplyResources(this.header15, "header15");
      this.header15.BackColor = System.Drawing.Color.White;
      this.header15.HeaderDescription = resources.GetString("header15.HeaderDescription");
      this.header15.HeaderHead = "CorpusExplorer-BRIDGE";
      this.header15.Name = "header15";
      // 
      // helpPanel3
      // 
      this.helpPanel3.BackColor = System.Drawing.Color.White;
      resources.ApplyResources(this.helpPanel3, "helpPanel3");
      this.helpPanel3.HelpHandbookText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.InteraktivesHandbuch;
      this.helpPanel3.HelpHandbookUrl = "http://www.bitcutstudios.com/products/corpusexplorer/help/schnappschusse.html";
      this.helpPanel3.HelpHandsonlabText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.PraktischeÜbungen;
      this.helpPanel3.HelpHandsonlabUrl = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Help_Static_HandsOnLab;
      this.helpPanel3.HelpLabelDescription = "Lernen Sie, wie Sie mit Schnappschüssen Ihre Forschung organisieren können.";
      this.helpPanel3.HelpLabelHeader = "Wie funktionieren Schnappschüsse - Eine Hilfe!";
      this.helpPanel3.HelpOnlineText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.WeitereInformationen;
      this.helpPanel3.HelpOnlineUrl = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Help_Static_AdditionalInformation;
      this.helpPanel3.HelpVideoText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.KurzesEinstiegsvideo;
      this.helpPanel3.HelpVideoUrl = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Help_Static_YoutubeChannel;
      this.helpPanel3.Name = "helpPanel3";
      // 
      // infoPanel_snapshot
      // 
      this.infoPanel_snapshot.BackColor = System.Drawing.Color.White;
      this.infoPanel_snapshot.CountCorpora = ((long)(0));
      this.infoPanel_snapshot.CountDocuments = ((long)(0));
      this.infoPanel_snapshot.CountLayers = ((long)(0));
      this.infoPanel_snapshot.CountTokens = ((long)(0));
      resources.ApplyResources(this.infoPanel_snapshot, "infoPanel_snapshot");
      this.infoPanel_snapshot.Name = "infoPanel_snapshot";
      // 
      // header12
      // 
      resources.ApplyResources(this.header12, "header12");
      this.header12.BackColor = System.Drawing.Color.White;
      this.header12.HeaderDescription = "Hier sehen Sie, welchen Umfang der von ihnen aktuell gewählte Schnappschuss hat.";
      this.header12.HeaderHead = "QuickInfo: Aktuell gewählter Schnappschuss";
      this.header12.Name = "header12";
      // 
      // radPanel8
      // 
      this.radPanel8.Controls.Add(this.page_analytics_snapshot_list_snapshots);
      this.radPanel8.Controls.Add(this.clearPanel13);
      this.radPanel8.Controls.Add(this.clearPanel14);
      resources.ApplyResources(this.radPanel8, "radPanel8");
      this.radPanel8.Name = "radPanel8";
      // 
      // 
      // 
      this.radPanel8.RootElement.MinSize = new System.Drawing.Size(0, 245);
      // 
      // page_analytics_snapshot_list_snapshots
      // 
      resources.ApplyResources(this.page_analytics_snapshot_list_snapshots, "page_analytics_snapshot_list_snapshots");
      this.page_analytics_snapshot_list_snapshots.ItemHeight = 40;
      this.page_analytics_snapshot_list_snapshots.Name = "page_analytics_snapshot_list_snapshots";
      this.page_analytics_snapshot_list_snapshots.SpacingBetweenNodes = -1;
      this.page_analytics_snapshot_list_snapshots.SelectedNodeChanged += new Telerik.WinControls.UI.RadTreeView.RadTreeViewEventHandler(this.page_analytics_snapshot_list_snapshots_SelectedNodeChanged);
      // 
      // clearPanel13
      // 
      this.clearPanel13.Controls.Add(this.page_analytics_snapshot_btn_snapshot_export);
      this.clearPanel13.Controls.Add(this.page_analytics_snapshot_btn_snapshot_load);
      this.clearPanel13.Controls.Add(this.page_analytics_snapshot_btn_snapshot_remove);
      this.clearPanel13.Controls.Add(this.page_analytics_snapshot_btn_snapshot_edit);
      this.clearPanel13.Controls.Add(this.page_analytics_snapshot_btn_snapshot_clonedetection);
      this.clearPanel13.Controls.Add(this.clearPanel5);
      this.clearPanel13.Controls.Add(this.page_analytics_snapshot_btn_snapshot_mask);
      this.clearPanel13.Controls.Add(this.page_analytics_snapshot_btn_snapshot_add);
      resources.ApplyResources(this.clearPanel13, "clearPanel13");
      this.clearPanel13.Name = "clearPanel13";
      // 
      // page_analytics_snapshot_btn_snapshot_export
      // 
      resources.ApplyResources(this.page_analytics_snapshot_btn_snapshot_export, "page_analytics_snapshot_btn_snapshot_export");
      this.page_analytics_snapshot_btn_snapshot_export.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.export_text;
      this.page_analytics_snapshot_btn_snapshot_export.Name = "page_analytics_snapshot_btn_snapshot_export";
      this.page_analytics_snapshot_btn_snapshot_export.Click += new System.EventHandler(this.page_analytics_snapshot_btn_snapshot_export_Click);
      // 
      // page_analytics_snapshot_btn_snapshot_load
      // 
      resources.ApplyResources(this.page_analytics_snapshot_btn_snapshot_load, "page_analytics_snapshot_btn_snapshot_load");
      this.page_analytics_snapshot_btn_snapshot_load.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.import_from_text;
      this.page_analytics_snapshot_btn_snapshot_load.Name = "page_analytics_snapshot_btn_snapshot_load";
      this.page_analytics_snapshot_btn_snapshot_load.Click += new System.EventHandler(this.page_analytics_snapshot_btn_snapshot_load_Click);
      // 
      // page_analytics_snapshot_btn_snapshot_remove
      // 
      resources.ApplyResources(this.page_analytics_snapshot_btn_snapshot_remove, "page_analytics_snapshot_btn_snapshot_remove");
      this.page_analytics_snapshot_btn_snapshot_remove.Name = "page_analytics_snapshot_btn_snapshot_remove";
      this.page_analytics_snapshot_btn_snapshot_remove.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Löschen;
      this.page_analytics_snapshot_btn_snapshot_remove.Click += new System.EventHandler(this.page_analytics_snapshot_btn_snapshot_remove_Click);
      // 
      // page_analytics_snapshot_btn_snapshot_edit
      // 
      resources.ApplyResources(this.page_analytics_snapshot_btn_snapshot_edit, "page_analytics_snapshot_btn_snapshot_edit");
      this.page_analytics_snapshot_btn_snapshot_edit.Name = "page_analytics_snapshot_btn_snapshot_edit";
      this.page_analytics_snapshot_btn_snapshot_edit.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Bearbeiten;
      this.page_analytics_snapshot_btn_snapshot_edit.Click += new System.EventHandler(this.page_analytics_snapshot_btn_snapshot_edit_Click);
      // 
      // page_analytics_snapshot_btn_snapshot_clonedetection
      // 
      resources.ApplyResources(this.page_analytics_snapshot_btn_snapshot_clonedetection, "page_analytics_snapshot_btn_snapshot_clonedetection");
      this.page_analytics_snapshot_btn_snapshot_clonedetection.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.module_warn;
      this.page_analytics_snapshot_btn_snapshot_clonedetection.Name = "page_analytics_snapshot_btn_snapshot_clonedetection";
      this.page_analytics_snapshot_btn_snapshot_clonedetection.Click += new System.EventHandler(this.page_analytics_snapshot_btn_snapshot_clonedetection_Click);
      // 
      // clearPanel5
      // 
      resources.ApplyResources(this.clearPanel5, "clearPanel5");
      this.clearPanel5.Name = "clearPanel5";
      // 
      // page_analytics_snapshot_btn_snapshot_mask
      // 
      resources.ApplyResources(this.page_analytics_snapshot_btn_snapshot_mask, "page_analytics_snapshot_btn_snapshot_mask");
      this.page_analytics_snapshot_btn_snapshot_mask.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.button_green_record;
      this.page_analytics_snapshot_btn_snapshot_mask.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.page_analytics_snapshot_btn_snapshot_mask_individual,
            this.page_analytics_snapshot_btn_snapshot_mask_metasplit,
            this.page_analytics_snapshot_btn_snapshot_mask_random});
      this.page_analytics_snapshot_btn_snapshot_mask.Name = "page_analytics_snapshot_btn_snapshot_mask";
      this.page_analytics_snapshot_btn_snapshot_mask.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Eingrenzen;
      this.page_analytics_snapshot_btn_snapshot_mask.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
      this.page_analytics_snapshot_btn_snapshot_mask.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      ((Telerik.WinControls.UI.RadDropDownButtonElement)(this.page_analytics_snapshot_btn_snapshot_mask.GetChildAt(0))).Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.button_green_record;
      ((Telerik.WinControls.UI.RadDropDownButtonElement)(this.page_analytics_snapshot_btn_snapshot_mask.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      ((Telerik.WinControls.UI.RadDropDownButtonElement)(this.page_analytics_snapshot_btn_snapshot_mask.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
      ((Telerik.WinControls.UI.RadDropDownButtonElement)(this.page_analytics_snapshot_btn_snapshot_mask.GetChildAt(0))).Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Eingrenzen;
      ((Telerik.WinControls.UI.RadDropDownButtonElement)(this.page_analytics_snapshot_btn_snapshot_mask.GetChildAt(0))).Padding = ((System.Windows.Forms.Padding)(resources.GetObject("resource.Padding")));
      ((Telerik.WinControls.UI.RadDropDownButtonElement)(this.page_analytics_snapshot_btn_snapshot_mask.GetChildAt(0))).CanFocus = true;
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
      resources.ApplyResources(this.page_analytics_snapshot_btn_snapshot_add, "page_analytics_snapshot_btn_snapshot_add");
      this.page_analytics_snapshot_btn_snapshot_add.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.add_button;
      this.page_analytics_snapshot_btn_snapshot_add.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.page_analytics_snapshot_btn_snapshot_add_individual,
            this.page_analytics_snapshot_btn_snapshot_add_metasplit,
            this.page_analytics_snapshot_btn_snapshot_add_random});
      this.page_analytics_snapshot_btn_snapshot_add.Name = "page_analytics_snapshot_btn_snapshot_add";
      this.page_analytics_snapshot_btn_snapshot_add.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Neu;
      this.page_analytics_snapshot_btn_snapshot_add.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
      this.page_analytics_snapshot_btn_snapshot_add.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      ((Telerik.WinControls.UI.RadDropDownButtonElement)(this.page_analytics_snapshot_btn_snapshot_add.GetChildAt(0))).Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.add_button;
      ((Telerik.WinControls.UI.RadDropDownButtonElement)(this.page_analytics_snapshot_btn_snapshot_add.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      ((Telerik.WinControls.UI.RadDropDownButtonElement)(this.page_analytics_snapshot_btn_snapshot_add.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
      ((Telerik.WinControls.UI.RadDropDownButtonElement)(this.page_analytics_snapshot_btn_snapshot_add.GetChildAt(0))).Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Neu;
      ((Telerik.WinControls.UI.RadDropDownButtonElement)(this.page_analytics_snapshot_btn_snapshot_add.GetChildAt(0))).Padding = ((System.Windows.Forms.Padding)(resources.GetObject("resource.Padding1")));
      ((Telerik.WinControls.UI.RadDropDownButtonElement)(this.page_analytics_snapshot_btn_snapshot_add.GetChildAt(0))).CanFocus = true;
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
      // clearPanel14
      // 
      this.clearPanel14.Controls.Add(this.page_analytics_snapshot_btn_snapshot_publish);
      this.clearPanel14.Controls.Add(this.page_analytics_snapshot_btn_snapshot_invert);
      this.clearPanel14.Controls.Add(this.page_analytics_snapshot_btn_snapshot_reduceBfromA);
      this.clearPanel14.Controls.Add(this.page_analytics_snapshot_btn_snapshot_join);
      this.clearPanel14.Controls.Add(this.page_analytics_snapshot_btn_snapshot_union);
      this.clearPanel14.Controls.Add(this.page_analytics_snapshot_btn_snapshot_diff);
      resources.ApplyResources(this.clearPanel14, "clearPanel14");
      this.clearPanel14.Name = "clearPanel14";
      // 
      // page_analytics_snapshot_btn_snapshot_publish
      // 
      resources.ApplyResources(this.page_analytics_snapshot_btn_snapshot_publish, "page_analytics_snapshot_btn_snapshot_publish");
      this.page_analytics_snapshot_btn_snapshot_publish.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.archive_download_24px;
      this.page_analytics_snapshot_btn_snapshot_publish.Name = "page_analytics_snapshot_btn_snapshot_publish";
      this.page_analytics_snapshot_btn_snapshot_publish.Click += new System.EventHandler(this.page_analytics_snapshot_btn_snapshot_publish_Click);
      // 
      // page_analytics_snapshot_btn_snapshot_invert
      // 
      resources.ApplyResources(this.page_analytics_snapshot_btn_snapshot_invert, "page_analytics_snapshot_btn_snapshot_invert");
      this.page_analytics_snapshot_btn_snapshot_invert.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.button_green_stop;
      this.page_analytics_snapshot_btn_snapshot_invert.Name = "page_analytics_snapshot_btn_snapshot_invert";
      this.page_analytics_snapshot_btn_snapshot_invert.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Invertieren;
      this.page_analytics_snapshot_btn_snapshot_invert.Click += new System.EventHandler(this.page_analytics_snapshot_btn_snapshot_invert_Click);
      // 
      // page_analytics_snapshot_btn_snapshot_reduceBfromA
      // 
      resources.ApplyResources(this.page_analytics_snapshot_btn_snapshot_reduceBfromA, "page_analytics_snapshot_btn_snapshot_reduceBfromA");
      this.page_analytics_snapshot_btn_snapshot_reduceBfromA.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.settheory_awithoutb;
      this.page_analytics_snapshot_btn_snapshot_reduceBfromA.Name = "page_analytics_snapshot_btn_snapshot_reduceBfromA";
      this.page_analytics_snapshot_btn_snapshot_reduceBfromA.Click += new System.EventHandler(this.page_analytics_snapshot_btn_snapshot_reduceBfromA_Click);
      // 
      // page_analytics_snapshot_btn_snapshot_join
      // 
      resources.ApplyResources(this.page_analytics_snapshot_btn_snapshot_join, "page_analytics_snapshot_btn_snapshot_join");
      this.page_analytics_snapshot_btn_snapshot_join.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.settheory_join;
      this.page_analytics_snapshot_btn_snapshot_join.Name = "page_analytics_snapshot_btn_snapshot_join";
      this.page_analytics_snapshot_btn_snapshot_join.Click += new System.EventHandler(this.page_analytics_snapshot_btn_snapshot_join_Click);
      // 
      // page_analytics_snapshot_btn_snapshot_union
      // 
      resources.ApplyResources(this.page_analytics_snapshot_btn_snapshot_union, "page_analytics_snapshot_btn_snapshot_union");
      this.page_analytics_snapshot_btn_snapshot_union.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.settheory_intersection;
      this.page_analytics_snapshot_btn_snapshot_union.Name = "page_analytics_snapshot_btn_snapshot_union";
      this.page_analytics_snapshot_btn_snapshot_union.Click += new System.EventHandler(this.page_analytics_snapshot_btn_snapshot_union_Click);
      // 
      // page_analytics_snapshot_btn_snapshot_diff
      // 
      resources.ApplyResources(this.page_analytics_snapshot_btn_snapshot_diff, "page_analytics_snapshot_btn_snapshot_diff");
      this.page_analytics_snapshot_btn_snapshot_diff.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.settheory_difference;
      this.page_analytics_snapshot_btn_snapshot_diff.Name = "page_analytics_snapshot_btn_snapshot_diff";
      this.page_analytics_snapshot_btn_snapshot_diff.Click += new System.EventHandler(this.page_analytics_snapshot_btn_snapshot_diff_Click);
      // 
      // header7
      // 
      resources.ApplyResources(this.header7, "header7");
      this.header7.BackColor = System.Drawing.Color.White;
      this.header7.HeaderDescription = resources.GetString("header7.HeaderDescription");
      this.header7.HeaderHead = "Schnappschüsse verwalten";
      this.header7.Name = "header7";
      // 
      // page_analytics_snapshot_noexport
      // 
      this.page_analytics_snapshot_noexport.BackColor = System.Drawing.Color.MistyRose;
      resources.ApplyResources(this.page_analytics_snapshot_noexport, "page_analytics_snapshot_noexport");
      this.page_analytics_snapshot_noexport.Name = "page_analytics_snapshot_noexport";
      // 
      // pages_main
      // 
      this.pages_main.Controls.Add(this.page_welcome);
      this.pages_main.Controls.Add(this.page_corpus);
      this.pages_main.Controls.Add(this.page_snapshot);
      this.pages_main.Controls.Add(this.page_analytics);
      this.pages_main.Controls.Add(this.page_settings);
      resources.ApplyResources(this.pages_main, "pages_main");
      this.pages_main.ItemSizeMode = ((Telerik.WinControls.UI.PageViewItemSizeMode)((Telerik.WinControls.UI.PageViewItemSizeMode.EqualWidth | Telerik.WinControls.UI.PageViewItemSizeMode.EqualHeight)));
      this.pages_main.Name = "pages_main";
      // 
      // 
      // 
      this.pages_main.RootElement.MinSize = new System.Drawing.Size(0, 0);
      this.pages_main.SelectedPage = this.page_welcome;
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
      ((Telerik.WinControls.UI.RadPageViewContentAreaElement)(this.pages_main.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Visible;
      // 
      // page_welcome
      // 
      this.page_welcome.Controls.Add(this.radScrollablePanel10);
      this.page_welcome.ItemSize = new System.Drawing.SizeF(164F, 29F);
      resources.ApplyResources(this.page_welcome, "page_welcome");
      this.page_welcome.Name = "page_welcome";
      // 
      // page_corpus
      // 
      this.page_corpus.Controls.Add(this.pages_corpora);
      this.page_corpus.ItemSize = new System.Drawing.SizeF(164F, 29F);
      resources.ApplyResources(this.page_corpus, "page_corpus");
      this.page_corpus.Name = "page_corpus";
      // 
      // pages_corpora
      // 
      this.pages_corpora.Controls.Add(this.page_corpus_start);
      this.pages_corpora.Controls.Add(this.page_corpus_online);
      resources.ApplyResources(this.pages_corpora, "pages_corpora");
      this.pages_corpora.ItemSizeMode = Telerik.WinControls.UI.PageViewItemSizeMode.EqualWidth;
      this.pages_corpora.Name = "pages_corpora";
      this.pages_corpora.SelectedPage = this.page_corpus_start;
      ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pages_corpora.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.Scroll;
      ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pages_corpora.GetChildAt(0))).ItemFitMode = Telerik.WinControls.UI.StripViewItemFitMode.None;
      ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pages_corpora.GetChildAt(0))).ItemSizeMode = Telerik.WinControls.UI.PageViewItemSizeMode.EqualWidth;
      ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pages_corpora.GetChildAt(0))).Visibility = Telerik.WinControls.ElementVisibility.Visible;
      ((Telerik.WinControls.UI.RadPageViewLabelElement)(this.pages_corpora.GetChildAt(0).GetChildAt(2))).Text = resources.GetString("resource.Text11");
      ((Telerik.WinControls.UI.RadPageViewLabelElement)(this.pages_corpora.GetChildAt(0).GetChildAt(2))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
      // 
      // page_corpus_start
      // 
      this.page_corpus_start.Controls.Add(this.radScrollablePanel7);
      this.page_corpus_start.ItemSize = new System.Drawing.SizeF(97F, 29F);
      resources.ApplyResources(this.page_corpus_start, "page_corpus_start");
      this.page_corpus_start.Name = "page_corpus_start";
      // 
      // page_corpus_online
      // 
      this.page_corpus_online.Controls.Add(this.radSplitContainer1);
      this.page_corpus_online.Controls.Add(this.header5);
      this.page_corpus_online.ItemSize = new System.Drawing.SizeF(97F, 29F);
      resources.ApplyResources(this.page_corpus_online, "page_corpus_online");
      this.page_corpus_online.Name = "page_corpus_online";
      // 
      // radSplitContainer1
      // 
      this.radSplitContainer1.Controls.Add(this.splitPanel1);
      this.radSplitContainer1.Controls.Add(this.splitPanel2);
      resources.ApplyResources(this.radSplitContainer1, "radSplitContainer1");
      this.radSplitContainer1.Name = "radSplitContainer1";
      // 
      // 
      // 
      this.radSplitContainer1.RootElement.MinSize = new System.Drawing.Size(0, 0);
      this.radSplitContainer1.SplitterWidth = 13;
      this.radSplitContainer1.TabStop = false;
      // 
      // splitPanel1
      // 
      this.splitPanel1.Controls.Add(this.radGroupBox2);
      resources.ApplyResources(this.splitPanel1, "splitPanel1");
      this.splitPanel1.Name = "splitPanel1";
      // 
      // 
      // 
      this.splitPanel1.RootElement.MinSize = new System.Drawing.Size(0, 0);
      this.splitPanel1.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(-0.1821516F, 0F);
      this.splitPanel1.SizeInfo.SplitterCorrection = new System.Drawing.Size(-149, 0);
      this.splitPanel1.TabStop = false;
      // 
      // radGroupBox2
      // 
      this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox2.Controls.Add(this.corpus_online_crawler_list);
      this.radGroupBox2.Controls.Add(this.corpus_online_crawler_create);
      resources.ApplyResources(this.radGroupBox2, "radGroupBox2");
      this.radGroupBox2.HeaderText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources._1VerfügbareCrawler;
      this.radGroupBox2.Name = "radGroupBox2";
      this.radGroupBox2.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources._1VerfügbareCrawler;
      // 
      // corpus_online_crawler_list
      // 
      resources.ApplyResources(this.corpus_online_crawler_list, "corpus_online_crawler_list");
      this.corpus_online_crawler_list.GroupIndent = 76;
      this.corpus_online_crawler_list.GroupItemSize = new System.Drawing.Size(611, 124);
      this.corpus_online_crawler_list.HeaderHeight = 106.8115F;
      this.corpus_online_crawler_list.ItemSize = new System.Drawing.Size(611, 124);
      this.corpus_online_crawler_list.Name = "corpus_online_crawler_list";
      this.corpus_online_crawler_list.ShowCheckBoxes = true;
      ((Telerik.WinControls.UI.RadListViewElement)(this.corpus_online_crawler_list.GetChildAt(0))).BorderWidth = 0F;
      ((Telerik.WinControls.UI.RadListViewElement)(this.corpus_online_crawler_list.GetChildAt(0))).BorderLeftWidth = 0F;
      ((Telerik.WinControls.UI.RadListViewElement)(this.corpus_online_crawler_list.GetChildAt(0))).BorderTopWidth = 0F;
      ((Telerik.WinControls.UI.RadListViewElement)(this.corpus_online_crawler_list.GetChildAt(0))).BorderRightWidth = 0F;
      ((Telerik.WinControls.UI.RadListViewElement)(this.corpus_online_crawler_list.GetChildAt(0))).BorderBottomWidth = 0F;
      ((Telerik.WinControls.UI.SimpleListViewElement)(this.corpus_online_crawler_list.GetChildAt(0).GetChildAt(0))).ItemSize = new System.Drawing.Size(611, 124);
      ((Telerik.WinControls.UI.SimpleListViewElement)(this.corpus_online_crawler_list.GetChildAt(0).GetChildAt(0))).GroupItemSize = new System.Drawing.Size(611, 124);
      ((Telerik.WinControls.UI.SimpleListViewElement)(this.corpus_online_crawler_list.GetChildAt(0).GetChildAt(0))).GroupIndent = 76;
      ((Telerik.WinControls.UI.SimpleListViewElement)(this.corpus_online_crawler_list.GetChildAt(0).GetChildAt(0))).BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
      // 
      // corpus_online_crawler_create
      // 
      resources.ApplyResources(this.corpus_online_crawler_create, "corpus_online_crawler_create");
      this.corpus_online_crawler_create.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.tools;
      this.corpus_online_crawler_create.Name = "corpus_online_crawler_create";
      this.corpus_online_crawler_create.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.EigenenWebCrawlerErstellen;
      this.corpus_online_crawler_create.TextWrap = true;
      this.corpus_online_crawler_create.Click += new System.EventHandler(this.corpus_online_crawler_create_Click);
      // 
      // splitPanel2
      // 
      this.splitPanel2.Controls.Add(this.radGroupBox3);
      this.splitPanel2.Controls.Add(this.radGroupBox5);
      resources.ApplyResources(this.splitPanel2, "splitPanel2");
      this.splitPanel2.Name = "splitPanel2";
      // 
      // 
      // 
      this.splitPanel2.RootElement.MinSize = new System.Drawing.Size(0, 0);
      this.splitPanel2.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(0.1821516F, 0F);
      this.splitPanel2.SizeInfo.SplitterCorrection = new System.Drawing.Size(149, 0);
      this.splitPanel2.TabStop = false;
      // 
      // radGroupBox3
      // 
      this.radGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox3.Controls.Add(this.corpus_online_crawler_queries);
      resources.ApplyResources(this.radGroupBox3, "radGroupBox3");
      this.radGroupBox3.HeaderText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources._2Suchbegriffe;
      this.radGroupBox3.Name = "radGroupBox3";
      this.radGroupBox3.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources._2Suchbegriffe;
      // 
      // corpus_online_crawler_queries
      // 
      this.corpus_online_crawler_queries.AcceptsReturn = true;
      resources.ApplyResources(this.corpus_online_crawler_queries, "corpus_online_crawler_queries");
      this.corpus_online_crawler_queries.Multiline = true;
      this.corpus_online_crawler_queries.Name = "corpus_online_crawler_queries";
      // 
      // radGroupBox5
      // 
      this.radGroupBox5.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox5.Controls.Add(this.corpus_online_crawler_start_compile);
      this.radGroupBox5.Controls.Add(this.corpus_online_crawler_start);
      resources.ApplyResources(this.radGroupBox5, "radGroupBox5");
      this.radGroupBox5.HeaderText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources._3KorpusakquiseKonfigurierenUndStarten;
      this.radGroupBox5.Name = "radGroupBox5";
      this.radGroupBox5.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources._3KorpusakquiseKonfigurierenUndStarten;
      // 
      // corpus_online_crawler_start_compile
      // 
      resources.ApplyResources(this.corpus_online_crawler_start_compile, "corpus_online_crawler_start_compile");
      this.corpus_online_crawler_start_compile.Name = "corpus_online_crawler_start_compile";
      this.corpus_online_crawler_start_compile.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.FürDieKorpusakquiseSollEinExtraProgrammErstelltWerdenDamitKannDerAkquiseprozessAufAnderePCsServerAusgelagertWerden;
      // 
      // corpus_online_crawler_start
      // 
      resources.ApplyResources(this.corpus_online_crawler_start, "corpus_online_crawler_start");
      this.corpus_online_crawler_start.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.dll_internet;
      this.corpus_online_crawler_start.Name = "corpus_online_crawler_start";
      this.corpus_online_crawler_start.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.StarteDieKorpusakquise;
      this.corpus_online_crawler_start.Click += new System.EventHandler(this.corpus_online_crawler_start_Click);
      // 
      // header5
      // 
      resources.ApplyResources(this.header5, "header5");
      this.header5.BackColor = System.Drawing.Color.White;
      this.header5.HeaderDescription = resources.GetString("header5.HeaderDescription");
      this.header5.HeaderHead = "Online-Korpus akquirieren";
      this.header5.Name = "header5";
      // 
      // page_snapshot
      // 
      this.page_snapshot.Controls.Add(this.pages_snapshot);
      this.page_snapshot.ItemSize = new System.Drawing.SizeF(164F, 29F);
      resources.ApplyResources(this.page_snapshot, "page_snapshot");
      this.page_snapshot.Name = "page_snapshot";
      // 
      // pages_snapshot
      // 
      this.pages_snapshot.Controls.Add(this.page_snapshot_home);
      this.pages_snapshot.Controls.Add(this.page_snapshot_edit);
      resources.ApplyResources(this.pages_snapshot, "pages_snapshot");
      this.pages_snapshot.ItemSizeMode = Telerik.WinControls.UI.PageViewItemSizeMode.EqualWidth;
      this.pages_snapshot.Name = "pages_snapshot";
      this.pages_snapshot.SelectedPage = this.page_snapshot_home;
      ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pages_snapshot.GetChildAt(0))).ItemSizeMode = Telerik.WinControls.UI.PageViewItemSizeMode.EqualWidth;
      // 
      // page_snapshot_home
      // 
      this.page_snapshot_home.Controls.Add(this.radScrollablePanel3);
      this.page_snapshot_home.ItemSize = new System.Drawing.SizeF(85F, 29F);
      resources.ApplyResources(this.page_snapshot_home, "page_snapshot_home");
      this.page_snapshot_home.Name = "page_snapshot_home";
      // 
      // page_snapshot_edit
      // 
      this.page_snapshot_edit.Controls.Add(this.radGroupBox6);
      this.page_snapshot_edit.Controls.Add(this.radGroupBox1);
      this.page_snapshot_edit.Controls.Add(this.header11);
      this.page_snapshot_edit.Controls.Add(this.clearPanel3);
      this.page_snapshot_edit.ItemSize = new System.Drawing.SizeF(85F, 29F);
      resources.ApplyResources(this.page_snapshot_edit, "page_snapshot_edit");
      this.page_snapshot_edit.Name = "page_snapshot_edit";
      // 
      // radGroupBox6
      // 
      this.radGroupBox6.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox6.Controls.Add(this.snapshot_edit_queries);
      this.radGroupBox6.Controls.Add(this.clearPanel7);
      resources.ApplyResources(this.radGroupBox6, "radGroupBox6");
      this.radGroupBox6.Name = "radGroupBox6";
      // 
      // clearPanel7
      // 
      this.clearPanel7.Controls.Add(this.snapshot_edit_dropdown_meta);
      this.clearPanel7.Controls.Add(this.snapshot_edit_dropdown_fulltext);
      this.clearPanel7.Controls.Add(this.snapshot_edit_dropdown_corpus);
      resources.ApplyResources(this.clearPanel7, "clearPanel7");
      this.clearPanel7.Name = "clearPanel7";
      // 
      // snapshot_edit_dropdown_meta
      // 
      resources.ApplyResources(this.snapshot_edit_dropdown_meta, "snapshot_edit_dropdown_meta");
      this.snapshot_edit_dropdown_meta.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.tag_horizontal;
      this.snapshot_edit_dropdown_meta.Name = "snapshot_edit_dropdown_meta";
      this.snapshot_edit_dropdown_meta.Click += new System.EventHandler(this.snapshot_edit_dropdown_meta_Click);
      // 
      // snapshot_edit_dropdown_fulltext
      // 
      resources.ApplyResources(this.snapshot_edit_dropdown_fulltext, "snapshot_edit_dropdown_fulltext");
      this.snapshot_edit_dropdown_fulltext.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.text_box;
      this.snapshot_edit_dropdown_fulltext.Name = "snapshot_edit_dropdown_fulltext";
      this.snapshot_edit_dropdown_fulltext.Click += new System.EventHandler(this.snapshot_edit_dropdown_fulltext_Click);
      // 
      // snapshot_edit_dropdown_corpus
      // 
      resources.ApplyResources(this.snapshot_edit_dropdown_corpus, "snapshot_edit_dropdown_corpus");
      this.snapshot_edit_dropdown_corpus.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.cabinet1;
      this.snapshot_edit_dropdown_corpus.Name = "snapshot_edit_dropdown_corpus";
      this.snapshot_edit_dropdown_corpus.Click += new System.EventHandler(this.snapshot_edit_dropdown_corpus_Click);
      // 
      // radGroupBox1
      // 
      this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox1.Controls.Add(this.warnBox1);
      this.radGroupBox1.Controls.Add(this.snapshot_edit_displayname);
      resources.ApplyResources(this.radGroupBox1, "radGroupBox1");
      this.radGroupBox1.Name = "radGroupBox1";
      // 
      // warnBox1
      // 
      this.warnBox1.BackColor = System.Drawing.Color.White;
      resources.ApplyResources(this.warnBox1, "warnBox1");
      this.warnBox1.Name = "warnBox1";
      // 
      // snapshot_edit_displayname
      // 
      resources.ApplyResources(this.snapshot_edit_displayname, "snapshot_edit_displayname");
      this.snapshot_edit_displayname.Name = "snapshot_edit_displayname";
      this.snapshot_edit_displayname.NullText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.GebenSieHierEinenSinnvollenNamenFürDenSchnappschussEin;
      this.snapshot_edit_displayname.TextChanged += new System.EventHandler(this.snapshot_edit_displayname_TextChanged);
      // 
      // header11
      // 
      resources.ApplyResources(this.header11, "header11");
      this.header11.BackColor = System.Drawing.Color.White;
      this.header11.HeaderDescription = resources.GetString("header11.HeaderDescription");
      this.header11.HeaderHead = "Schnappschuss definieren";
      this.header11.Name = "header11";
      // 
      // clearPanel3
      // 
      this.clearPanel3.Controls.Add(this.snapshot_edit_abort);
      this.clearPanel3.Controls.Add(this.snapshot_edit_ok);
      resources.ApplyResources(this.clearPanel3, "clearPanel3");
      this.clearPanel3.Name = "clearPanel3";
      // 
      // snapshot_edit_abort
      // 
      resources.ApplyResources(this.snapshot_edit_abort, "snapshot_edit_abort");
      this.snapshot_edit_abort.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.remove_button;
      this.snapshot_edit_abort.Name = "snapshot_edit_abort";
      this.snapshot_edit_abort.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.ErstellenAbbrechen;
      this.snapshot_edit_abort.Click += new System.EventHandler(this.snapshot_edit_abort_Click);
      // 
      // snapshot_edit_ok
      // 
      resources.ApplyResources(this.snapshot_edit_ok, "snapshot_edit_ok");
      this.snapshot_edit_ok.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.camera1;
      this.snapshot_edit_ok.Name = "snapshot_edit_ok";
      this.snapshot_edit_ok.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.SchnappschussErstellen;
      this.snapshot_edit_ok.Click += new System.EventHandler(this.snapshot_edit_ok_Click);
      // 
      // page_analytics
      // 
      this.page_analytics.Controls.Add(this.pages_analytics);
      this.page_analytics.ItemSize = new System.Drawing.SizeF(164F, 29F);
      resources.ApplyResources(this.page_analytics, "page_analytics");
      this.page_analytics.Name = "page_analytics";
      // 
      // pages_analytics
      // 
      this.pages_analytics.Controls.Add(this.page_analytics_start);
      this.pages_analytics.Controls.Add(this.page_analytics_view);
      this.pages_analytics.Controls.Add(this.page_analytics_thirdparty);
      resources.ApplyResources(this.pages_analytics, "pages_analytics");
      this.pages_analytics.ItemSizeMode = ((Telerik.WinControls.UI.PageViewItemSizeMode)((Telerik.WinControls.UI.PageViewItemSizeMode.EqualWidth | Telerik.WinControls.UI.PageViewItemSizeMode.EqualHeight)));
      this.pages_analytics.Name = "pages_analytics";
      this.pages_analytics.SelectedPage = this.page_analytics_start;
      ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pages_analytics.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.Scroll;
      ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pages_analytics.GetChildAt(0))).ItemFitMode = Telerik.WinControls.UI.StripViewItemFitMode.Fill;
      ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pages_analytics.GetChildAt(0))).ItemSizeMode = ((Telerik.WinControls.UI.PageViewItemSizeMode)((Telerik.WinControls.UI.PageViewItemSizeMode.EqualWidth | Telerik.WinControls.UI.PageViewItemSizeMode.EqualHeight)));
      // 
      // page_analytics_start
      // 
      this.page_analytics_start.Controls.Add(this.radScrollablePanel1);
      resources.ApplyResources(this.page_analytics_start, "page_analytics_start");
      this.page_analytics_start.Name = "page_analytics_start";
      // 
      // page_analytics_view
      // 
      this.page_analytics_view.Controls.Add(this.pages_standardanalytics);
      resources.ApplyResources(this.page_analytics_view, "page_analytics_view");
      this.page_analytics_view.Name = "page_analytics_view";
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
      resources.ApplyResources(this.pages_standardanalytics, "pages_standardanalytics");
      this.pages_standardanalytics.Name = "pages_standardanalytics";
      this.pages_standardanalytics.SelectedPage = this.page_standardanalytics_weight;
      ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pages_standardanalytics.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.Scroll;
      ((Telerik.WinControls.UI.RadPageViewContentAreaElement)(this.pages_standardanalytics.GetChildAt(0).GetChildAt(1))).Padding = ((System.Windows.Forms.Padding)(resources.GetObject("resource.Padding2")));
      // 
      // page_standardanalytics_search
      // 
      resources.ApplyResources(this.page_standardanalytics_search, "page_standardanalytics_search");
      this.page_standardanalytics_search.Name = "page_standardanalytics_search";
      // 
      // page_standardanalytics_frequency
      // 
      resources.ApplyResources(this.page_standardanalytics_frequency, "page_standardanalytics_frequency");
      this.page_standardanalytics_frequency.Name = "page_standardanalytics_frequency";
      // 
      // page_standardanalytics_ngram
      // 
      resources.ApplyResources(this.page_standardanalytics_ngram, "page_standardanalytics_ngram");
      this.page_standardanalytics_ngram.Name = "page_standardanalytics_ngram";
      // 
      // page_standardanalytics_cooccurrence
      // 
      resources.ApplyResources(this.page_standardanalytics_cooccurrence, "page_standardanalytics_cooccurrence");
      this.page_standardanalytics_cooccurrence.Name = "page_standardanalytics_cooccurrence";
      // 
      // page_standardanalytics_disambiguation
      // 
      resources.ApplyResources(this.page_standardanalytics_disambiguation, "page_standardanalytics_disambiguation");
      this.page_standardanalytics_disambiguation.Name = "page_standardanalytics_disambiguation";
      // 
      // page_standardanalytics_weight
      // 
      resources.ApplyResources(this.page_standardanalytics_weight, "page_standardanalytics_weight");
      this.page_standardanalytics_weight.Name = "page_standardanalytics_weight";
      // 
      // page_standardanalytics_complexety
      // 
      resources.ApplyResources(this.page_standardanalytics_complexety, "page_standardanalytics_complexety");
      this.page_standardanalytics_complexety.Name = "page_standardanalytics_complexety";
      // 
      // page_standardanalytics_beta
      // 
      resources.ApplyResources(this.page_standardanalytics_beta, "page_standardanalytics_beta");
      this.page_standardanalytics_beta.Name = "page_standardanalytics_beta";
      // 
      // page_rawanalytics_annotation
      // 
      resources.ApplyResources(this.page_rawanalytics_annotation, "page_rawanalytics_annotation");
      this.page_rawanalytics_annotation.Name = "page_rawanalytics_annotation";
      // 
      // page_rawanalytics_edition
      // 
      resources.ApplyResources(this.page_rawanalytics_edition, "page_rawanalytics_edition");
      this.page_rawanalytics_edition.Name = "page_rawanalytics_edition";
      // 
      // page_styleMetrics
      // 
      resources.ApplyResources(this.page_styleMetrics, "page_styleMetrics");
      this.page_styleMetrics.Name = "page_styleMetrics";
      // 
      // page_specialFeatures
      // 
      resources.ApplyResources(this.page_specialFeatures, "page_specialFeatures");
      this.page_specialFeatures.Name = "page_specialFeatures";
      // 
      // page_analytics_thirdparty
      // 
      this.page_analytics_thirdparty.Controls.Add(this.pages_3rdParty);
      resources.ApplyResources(this.page_analytics_thirdparty, "page_analytics_thirdparty");
      this.page_analytics_thirdparty.Name = "page_analytics_thirdparty";
      // 
      // pages_3rdParty
      // 
      resources.ApplyResources(this.pages_3rdParty, "pages_3rdParty");
      this.pages_3rdParty.Name = "pages_3rdParty";
      // 
      // page_settings
      // 
      this.page_settings.Controls.Add(this.radScrollablePanel2);
      this.page_settings.ItemSize = new System.Drawing.SizeF(164F, 29F);
      resources.ApplyResources(this.page_settings, "page_settings");
      this.page_settings.Name = "page_settings";
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
      resources.ApplyResources(this.main_mainmenu_app, "main_mainmenu_app");
      this.main_mainmenu_app.Name = "main_mainmenu_app";
      this.main_mainmenu_app.ShowArrow = false;
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
      resources.ApplyResources(this.main_mainmenu_project_saveas, "main_mainmenu_project_saveas");
      this.main_mainmenu_project_saveas.Click += new System.EventHandler(this.main_mainmenu_project_saveas_Click);
      // 
      // radMenuSeparatorItem6
      // 
      this.radMenuSeparatorItem6.Name = "radMenuSeparatorItem6";
      resources.ApplyResources(this.radMenuSeparatorItem6, "radMenuSeparatorItem6");
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
      resources.ApplyResources(this.radMenuSeparatorItem1, "radMenuSeparatorItem1");
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
      resources.ApplyResources(this.main_mainmenu_home, "main_mainmenu_home");
      this.main_mainmenu_home.Name = "main_mainmenu_home";
      this.main_mainmenu_home.ToolTipText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.StartseiteZeigtDieStartseiteAn;
      this.main_mainmenu_home.Click += new System.EventHandler(this.main_mainmenu_home_Click);
      // 
      // main_mainmenu_corpus
      // 
      this.main_mainmenu_corpus.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.cabinet1;
      this.main_mainmenu_corpus.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.main_mainmenu_corpus_overview,
            this.radMenuSeparatorItem3,
            this.main_mainmenu_corpus_load,
            this.main_mainmenu_corpus_files,
            this.main_mainmenu_corpus_import,
            this.main_mainmenu_corpus_online,
            this.main_mainmenu_corpus_dpxc});
      resources.ApplyResources(this.main_mainmenu_corpus, "main_mainmenu_corpus");
      this.main_mainmenu_corpus.Name = "main_mainmenu_corpus";
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
      resources.ApplyResources(this.radMenuSeparatorItem3, "radMenuSeparatorItem3");
      // 
      // main_mainmenu_corpus_load
      // 
      this.main_mainmenu_corpus_load.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.cabinet1;
      this.main_mainmenu_corpus_load.Name = "main_mainmenu_corpus_load";
      resources.ApplyResources(this.main_mainmenu_corpus_load, "main_mainmenu_corpus_load");
      // 
      // main_mainmenu_corpus_files
      // 
      this.main_mainmenu_corpus_files.AccessibleDescription = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.KorpusErstellen;
      this.main_mainmenu_corpus_files.AccessibleName = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.KorpusErstellen;
      this.main_mainmenu_corpus_files.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.folder_open;
      this.main_mainmenu_corpus_files.Name = "main_mainmenu_corpus_files";
      resources.ApplyResources(this.main_mainmenu_corpus_files, "main_mainmenu_corpus_files");
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
      // main_mainmenu_corpus_dpxc
      // 
      this.main_mainmenu_corpus_dpxc.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.design;
      this.main_mainmenu_corpus_dpxc.Name = "main_mainmenu_corpus_dpxc";
      resources.ApplyResources(this.main_mainmenu_corpus_dpxc, "main_mainmenu_corpus_dpxc");
      this.main_mainmenu_corpus_dpxc.Click += new System.EventHandler(this.corpus_start_dpxc_Click);
      // 
      // main_mainmenu_snapshot
      // 
      resources.ApplyResources(this.main_mainmenu_snapshot, "main_mainmenu_snapshot");
      this.main_mainmenu_snapshot.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.main_mainmenu_snapshot_overview,
            this.radMenuSeparatorItem4,
            this.main_mainmenu_snapshot_availabel,
            this.main_mainmenu_snapshot_new,
            this.main_mainmenu_snapshot_addsub});
      this.main_mainmenu_snapshot.Name = "main_mainmenu_snapshot";
      // 
      // main_mainmenu_snapshot_overview
      // 
      this.main_mainmenu_snapshot_overview.AccessibleDescription = "radMenuItem1";
      resources.ApplyResources(this.main_mainmenu_snapshot_overview, "main_mainmenu_snapshot_overview");
      this.main_mainmenu_snapshot_overview.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.eye;
      this.main_mainmenu_snapshot_overview.Name = "main_mainmenu_snapshot_overview";
      this.main_mainmenu_snapshot_overview.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.SchnappschussÜbersicht;
      this.main_mainmenu_snapshot_overview.Click += new System.EventHandler(this.main_mainmenu_snapshot_Click);
      // 
      // radMenuSeparatorItem4
      // 
      this.radMenuSeparatorItem4.Name = "radMenuSeparatorItem4";
      resources.ApplyResources(this.radMenuSeparatorItem4, "radMenuSeparatorItem4");
      // 
      // main_mainmenu_snapshot_availabel
      // 
      this.main_mainmenu_snapshot_availabel.AccessibleDescription = "radMenuItem2";
      resources.ApplyResources(this.main_mainmenu_snapshot_availabel, "main_mainmenu_snapshot_availabel");
      this.main_mainmenu_snapshot_availabel.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.camera1;
      this.main_mainmenu_snapshot_availabel.Name = "main_mainmenu_snapshot_availabel";
      this.main_mainmenu_snapshot_availabel.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.VerfügbareSchnappschüsse;
      // 
      // main_mainmenu_snapshot_new
      // 
      this.main_mainmenu_snapshot_new.AccessibleDescription = "radMenuItem4";
      resources.ApplyResources(this.main_mainmenu_snapshot_new, "main_mainmenu_snapshot_new");
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
      resources.ApplyResources(this.main_mainmenu_analytics, "main_mainmenu_analytics");
      this.main_mainmenu_analytics.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.main_mainmenu_analytics_overview,
            this.radMenuSeparatorItem5,
            this.main_mainmenu_analytics_favorite});
      this.main_mainmenu_analytics.Name = "main_mainmenu_analytics";
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
      resources.ApplyResources(this.radMenuSeparatorItem5, "radMenuSeparatorItem5");
      // 
      // main_mainmenu_analytics_favorite
      // 
      this.main_mainmenu_analytics_favorite.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.favorite;
      this.main_mainmenu_analytics_favorite.Name = "main_mainmenu_analytics_favorite";
      resources.ApplyResources(this.main_mainmenu_analytics_favorite, "main_mainmenu_analytics_favorite");
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
      resources.ApplyResources(this.radMenu1, "radMenu1");
      this.radMenu1.Name = "radMenu1";
      this.radMenu1.ThemeName = "TelerikMetroTouch";
      // 
      // Dashboard
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      resources.ApplyResources(this, "$this");
      this.Controls.Add(this.pages_main);
      this.Controls.Add(this.radMenu1);
      this.Name = "Dashboard";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Dashboard_FormClosing);
      this.Load += new System.EventHandler(this.Dashboard_Load);
      this.SizeChanged += new System.EventHandler(this.Dashboard_SizeChanged);
      ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel9)).EndInit();
      this.radScrollablePanel9.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.snapshot_edit_queries)).EndInit();
      this.snapshot_edit_queries.ResumeLayout(false);
      this.radScrollablePanel1.PanelContainer.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel1)).EndInit();
      this.radScrollablePanel1.ResumeLayout(false);
      this.radScrollablePanel4.PanelContainer.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel4)).EndInit();
      this.radScrollablePanel4.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.betafunction_thirdpartyPanel)).EndInit();
      this.betafunction_thirdpartyPanel.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.modul_panel_betafunction_thirdparty)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.header9)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.modul_panel_analytics)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.header8)).EndInit();
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
      ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.settings_drop_signifikanz)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.infoButton1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel4)).EndInit();
      this.splitPanel4.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer3)).EndInit();
      this.radSplitContainer3.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel5)).EndInit();
      this.splitPanel5.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox4)).EndInit();
      this.radGroupBox4.ResumeLayout(false);
      this.radScrollablePanel5.PanelContainer.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel5)).EndInit();
      this.radScrollablePanel5.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.settings_tool_totalReset)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.settings_tool_scriptEditor)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.settings_tool_errorconsole)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.settings_tool_upgrade)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.settings_tool_eraseCache)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.settings_tool_xpath)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.settings_tool_testCorpus)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.settings_tool_drmUsers)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.settings_tool_additionalTagger)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.settings_tool_exportCorpus)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.settings_tool_mergeCorpora)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel6)).EndInit();
      this.splitPanel6.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox9)).EndInit();
      this.radGroupBox9.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.settings_list_favorites)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.header10)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel8)).EndInit();
      this.radScrollablePanel8.ResumeLayout(false);
      this.radScrollablePanel10.PanelContainer.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel10)).EndInit();
      this.radScrollablePanel10.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.header13)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radListView1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.header6)).EndInit();
      this.radScrollablePanel11.PanelContainer.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel11)).EndInit();
      this.radScrollablePanel11.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.header2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.header1)).EndInit();
      this.radScrollablePanel7.PanelContainer.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel7)).EndInit();
      this.radScrollablePanel7.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.header14)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.header4)).EndInit();
      this.radScrollablePanel12.PanelContainer.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel12)).EndInit();
      this.radScrollablePanel12.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.corpus_start_korap)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.corpus_start_dpxc)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.corpus_start_online)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.corpus_start_import)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.corpus_start_local)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.corpus_start_add)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.header3)).EndInit();
      this.radScrollablePanel3.PanelContainer.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel3)).EndInit();
      this.radScrollablePanel3.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel1)).EndInit();
      this.clearPanel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.panel_bridge)).EndInit();
      this.panel_bridge.ResumeLayout(false);
      this.panel_bridge.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel11)).EndInit();
      this.clearPanel11.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.btn_bridge_reload)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.lbl_bridge_status)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_bridge_port)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_bridge_ip)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel10)).EndInit();
      this.clearPanel10.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel2)).EndInit();
      this.clearPanel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.switch_bridge)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.header15)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.header12)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radPanel8)).EndInit();
      this.radPanel8.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.page_analytics_snapshot_list_snapshots)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel13)).EndInit();
      this.clearPanel13.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.page_analytics_snapshot_btn_snapshot_export)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.page_analytics_snapshot_btn_snapshot_load)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.page_analytics_snapshot_btn_snapshot_remove)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.page_analytics_snapshot_btn_snapshot_edit)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.page_analytics_snapshot_btn_snapshot_clonedetection)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel5)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.page_analytics_snapshot_btn_snapshot_mask)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.page_analytics_snapshot_btn_snapshot_add)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel14)).EndInit();
      this.clearPanel14.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.page_analytics_snapshot_btn_snapshot_publish)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.page_analytics_snapshot_btn_snapshot_invert)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.page_analytics_snapshot_btn_snapshot_reduceBfromA)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.page_analytics_snapshot_btn_snapshot_join)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.page_analytics_snapshot_btn_snapshot_union)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.page_analytics_snapshot_btn_snapshot_diff)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.header7)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.page_analytics_snapshot_noexport)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pages_main)).EndInit();
      this.pages_main.ResumeLayout(false);
      this.page_welcome.ResumeLayout(false);
      this.page_corpus.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.pages_corpora)).EndInit();
      this.pages_corpora.ResumeLayout(false);
      this.page_corpus_start.ResumeLayout(false);
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
      ((System.ComponentModel.ISupportInitialize)(this.header5)).EndInit();
      this.page_snapshot.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.pages_snapshot)).EndInit();
      this.pages_snapshot.ResumeLayout(false);
      this.page_snapshot_home.ResumeLayout(false);
      this.page_snapshot_edit.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox6)).EndInit();
      this.radGroupBox6.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel7)).EndInit();
      this.clearPanel7.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.snapshot_edit_dropdown_meta)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.snapshot_edit_dropdown_fulltext)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.snapshot_edit_dropdown_corpus)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
      this.radGroupBox1.ResumeLayout(false);
      this.radGroupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.snapshot_edit_displayname)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.header11)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel3)).EndInit();
      this.clearPanel3.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.snapshot_edit_abort)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.snapshot_edit_ok)).EndInit();
      this.page_analytics.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.pages_analytics)).EndInit();
      this.pages_analytics.ResumeLayout(false);
      this.page_analytics_start.ResumeLayout(false);
      this.page_analytics_view.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.pages_standardanalytics)).EndInit();
      this.pages_standardanalytics.ResumeLayout(false);
      this.page_analytics_thirdparty.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.pages_3rdParty)).EndInit();
      this.page_settings.ResumeLayout(false);
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
    private Telerik.WinControls.UI.RadMenuItem main_mainmenu_home;
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
    private Header header4;
    private Header header3;
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
    private Telerik.WinControls.UI.RadGroupBox radGroupBox6;
    private ClearPanel clearPanel7;
    private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
    private Telerik.WinControls.UI.RadButton snapshot_edit_dropdown_meta;
    private Telerik.WinControls.UI.RadButton snapshot_edit_dropdown_fulltext;
    private Telerik.WinControls.UI.RadButton snapshot_edit_dropdown_corpus;
    private Telerik.WinControls.UI.RadMenuItem main_mainmenu_project_saveas;
    private Telerik.WinControls.UI.RadMenuSeparatorItem radMenuSeparatorItem6;
    private Telerik.WinControls.UI.RadMenu radMenu1;
    private Telerik.WinControls.UI.RadButton page_analytics_snapshot_btn_snapshot_export;
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
    private Telerik.WinControls.UI.RadGroupBox radGroupBox7;
    private Telerik.WinControls.UI.RadPropertyGrid property_meta;
    private Telerik.WinControls.UI.RadCommandBar radCommandBar1;
    private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
    private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement1;
    private Telerik.WinControls.UI.CommandBarButton btn_settings_load;
    private Telerik.WinControls.UI.CommandBarButton btn_settings_save;
    private Telerik.WinControls.UI.CommandBarButton btn_settings_saveas;
    private Telerik.WinControls.UI.RadButton settings_tool_totalReset;
    private Telerik.WinControls.UI.RadMenuItem main_mainmenu_analytics_favorite;
    private Telerik.WinControls.UI.RadSplitContainer radSplitContainer3;
    private Telerik.WinControls.UI.SplitPanel splitPanel5;
    private Telerik.WinControls.UI.SplitPanel splitPanel6;
    private Telerik.WinControls.UI.RadGroupBox radGroupBox9;
    private Telerik.WinControls.UI.RadCheckedListBox settings_list_favorites;
    private Header header6;
    private Telerik.WinControls.UI.RadListView radListView1;
    private Header header13;
    private Telerik.WinControls.UI.RadScrollablePanel radScrollablePanel8;
    private RadScrollablePanel radScrollablePanel9;
    private Header header14;
        private WarnBox warnBox1;
    private RadButton corpus_start_dpxc;
    private RadMenuItem main_mainmenu_corpus_dpxc;
    private RadButton settings_tool_scriptEditor;
        private RadScrollablePanel radScrollablePanel10;
        private RadScrollablePanel radScrollablePanel11;
        private RadScrollablePanel radScrollablePanel7;
        private RadScrollablePanel radScrollablePanel12;
        private InfoPanel infoPanel_korpora;
        private ClearPanel clearPanel13;
        private ClearPanel clearPanel14;
        private RadScrollablePanel radScrollablePanel3;
        private InfoPanel infoPanel_snapshot;
        private RadScrollablePanel radScrollablePanel5;
    private ClearPanel clearPanel1;
    private RadToggleSwitch switch_bridge;
    private Header header15;
    private ClearPanel panel_bridge;
    private ClearPanel clearPanel2;
    private RadLabel radLabel1;
    private RadLabel lbl_bridge_status;
    private RadLabel radLabel7;
    private RadTextBox txt_bridge_port;
    private RadLabel radLabel6;
    private RadMaskedEditBox txt_bridge_ip;
    private RadLabel radLabel4;
    private ClearPanel clearPanel10;
    private ClearPanel clearPanel11;
    private RadButton btn_bridge_reload;
    private RadLabel radLabel9;
    private RadButton page_analytics_snapshot_btn_snapshot_publish;
    private RadButton settings_tool_drmUsers;
    private RadButton corpus_start_korap;
    private RadPanel page_analytics_snapshot_noexport;
  }
}