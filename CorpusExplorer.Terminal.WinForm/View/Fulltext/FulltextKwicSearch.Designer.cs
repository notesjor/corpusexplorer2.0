namespace CorpusExplorer.Terminal.WinForm.View.Fulltext
{
  partial class FulltextKwicSearch
  {
    /// <summary> 
    /// Erforderliche Designervariable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Verwendete Ressourcen bereinigen.
    /// </summary>
    /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Vom Komponenten-Designer generierter Code

    /// <summary> 
    /// Erforderliche Methode für die Designerunterstützung. 
    /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FulltextKwicSearch));
      Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
      this.radCommandBar1 = new Telerik.WinControls.UI.RadCommandBar();
      this.commandBarRowElement2 = new Telerik.WinControls.UI.CommandBarRowElement();
      this.commandBarStripElement2 = new Telerik.WinControls.UI.CommandBarStripElement();
      this.btn_filter = new Telerik.WinControls.UI.CommandBarButton();
      this.btn_filterEditor = new Telerik.WinControls.UI.CommandBarButton();
      this.btn_regex = new Telerik.WinControls.UI.CommandBarButton();
      this.commandBarSeparator1 = new Telerik.WinControls.UI.CommandBarSeparator();
      this.btn_csvExport = new Telerik.WinControls.UI.CommandBarButton();
      this.btn_print = new Telerik.WinControls.UI.CommandBarButton();
      this.commandBarSeparator2 = new Telerik.WinControls.UI.CommandBarSeparator();
      this.btn_snapshot_create = new Telerik.WinControls.UI.CommandBarButton();
      this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
      this.wordBag1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.WordBag();
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
      this.SuspendLayout();
      // 
      // radCommandBar1
      // 
      resources.ApplyResources(this.radCommandBar1, "radCommandBar1");
      this.radCommandBar1.Name = "radCommandBar1";
      this.radCommandBar1.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement2});
      // 
      // commandBarRowElement2
      // 
      this.commandBarRowElement2.MinSize = new System.Drawing.Size(25, 25);
      this.commandBarRowElement2.Name = "commandBarRowElement2";
      this.commandBarRowElement2.Strips.AddRange(new Telerik.WinControls.UI.CommandBarStripElement[] {
            this.commandBarStripElement2});
      // 
      // commandBarStripElement2
      // 
      resources.ApplyResources(this.commandBarStripElement2, "commandBarStripElement2");
      this.commandBarStripElement2.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.btn_filter,
            this.btn_filterEditor,
            this.btn_regex,
            this.commandBarSeparator1,
            this.btn_csvExport,
            this.btn_print,
            this.commandBarSeparator2,
            this.btn_snapshot_create});
      this.commandBarStripElement2.Name = "commandBarStripElement2";
      // 
      // btn_filter
      // 
      resources.ApplyResources(this.btn_filter, "btn_filter");
      this.btn_filter.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.filter_list;
      this.btn_filter.AutoToolTip = true;
      this.btn_filter.Name = "btn_filter";
      this.btn_filter.Click += new System.EventHandler(this.btn_filter_Click);
      // 
      // btn_filterEditor
      // 
      resources.ApplyResources(this.btn_filterEditor, "btn_filterEditor");
      this.btn_filterEditor.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.filter_settings;
      this.btn_filterEditor.AutoToolTip = true;
      this.btn_filterEditor.Name = "btn_filterEditor";
      this.btn_filterEditor.Click += new System.EventHandler(this.btn_filterEditor_Click);
      // 
      // btn_regex
      // 
      resources.ApplyResources(this.btn_regex, "btn_regex");
      this.btn_regex.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.filter_regex;
      this.btn_regex.AutoToolTip = true;
      this.btn_regex.Name = "btn_regex";
      this.btn_regex.Click += new System.EventHandler(this.btn_regex_Click);
      // 
      // commandBarSeparator1
      // 
      this.commandBarSeparator1.AccessibleDescription = "commandBarSeparator1";
      this.commandBarSeparator1.AccessibleName = "commandBarSeparator1";
      resources.ApplyResources(this.commandBarSeparator1, "commandBarSeparator1");
      this.commandBarSeparator1.Name = "commandBarSeparator1";
      this.commandBarSeparator1.VisibleInOverflowMenu = false;
      // 
      // btn_csvExport
      // 
      resources.ApplyResources(this.btn_csvExport, "btn_csvExport");
      this.btn_csvExport.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.export_text;
      this.btn_csvExport.AutoToolTip = true;
      this.btn_csvExport.Name = "btn_csvExport";
      this.btn_csvExport.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.CSVExport;
      this.btn_csvExport.ToolTipText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.CSVExport;
      this.btn_csvExport.Click += new System.EventHandler(this.btn_csvExport_Click);
      // 
      // btn_print
      // 
      resources.ApplyResources(this.btn_print, "btn_print");
      this.btn_print.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.print;
      this.btn_print.AutoToolTip = true;
      this.btn_print.Name = "btn_print";
      this.btn_print.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Drucken;
      this.btn_print.ToolTipText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Drucken;
      this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
      // 
      // commandBarSeparator2
      // 
      this.commandBarSeparator2.AccessibleDescription = "commandBarSeparator2";
      this.commandBarSeparator2.AccessibleName = "commandBarSeparator2";
      resources.ApplyResources(this.commandBarSeparator2, "commandBarSeparator2");
      this.commandBarSeparator2.Name = "commandBarSeparator2";
      this.commandBarSeparator2.VisibleInOverflowMenu = false;
      // 
      // btn_snapshot_create
      // 
      resources.ApplyResources(this.btn_snapshot_create, "btn_snapshot_create");
      this.btn_snapshot_create.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.camera_add;
      this.btn_snapshot_create.AutoToolTip = true;
      this.btn_snapshot_create.Name = "btn_snapshot_create";
      this.btn_snapshot_create.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.SchnappschussErstellen;
      this.btn_snapshot_create.ToolTipText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.SchnappschussErstellen;
      this.btn_snapshot_create.Click += new System.EventHandler(this.btn_snapshot_create_Click);
      // 
      // radGridView1
      // 
      resources.ApplyResources(this.radGridView1, "radGridView1");
      // 
      // 
      // 
      this.radGridView1.MasterTemplate.AllowAddNewRow = false;
      this.radGridView1.MasterTemplate.AllowDeleteRow = false;
      this.radGridView1.MasterTemplate.AllowEditRow = false;
      this.radGridView1.MasterTemplate.EnableFiltering = true;
      this.radGridView1.MasterTemplate.ViewDefinition = tableViewDefinition1;
      this.radGridView1.Name = "radGridView1";
      // 
      // wordBag1
      // 
      this.wordBag1.BackColor = System.Drawing.Color.White;
      resources.ApplyResources(this.wordBag1, "wordBag1");
      this.wordBag1.Name = "wordBag1";
      this.wordBag1.ResultQueries = new string[0];
      this.wordBag1.ResultSelectedLayerDisplayname = null;
      this.wordBag1.ExecuteButtonClicked += new System.EventHandler(this.wordBag1_ExecuteButtonClicked);
      // 
      // FulltextKwicSearch
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.Controls.Add(this.radGridView1);
      this.Controls.Add(this.wordBag1);
      this.Controls.Add(this.radCommandBar1);
      this.Name = "FulltextKwicSearch";
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Telerik.WinControls.UI.RadCommandBar radCommandBar1;
    private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement2;
    private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement2;
    private Telerik.WinControls.UI.CommandBarButton btn_filterEditor;
    private Telerik.WinControls.UI.CommandBarButton btn_filter;
    private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator1;
    private Telerik.WinControls.UI.CommandBarButton btn_csvExport;
    private Telerik.WinControls.UI.CommandBarButton btn_print;
    private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator2;
    private Telerik.WinControls.UI.CommandBarButton btn_snapshot_create;
    private Telerik.WinControls.UI.RadGridView radGridView1;
    private Controls.WinForm.WordBag wordBag1;
    private Telerik.WinControls.UI.CommandBarButton btn_regex;
  }
}
