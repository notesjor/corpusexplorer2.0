namespace CorpusExplorer.Terminal.WinForm.View.Frequency
{
  partial class CollocateFrequency
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CollocateFrequency));
      Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
      this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
      this.radCommandBar1 = new Telerik.WinControls.UI.RadCommandBar();
      this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
      this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
      this.btn_function = new Telerik.WinControls.UI.CommandBarButton();
      this.btn_calc = new Telerik.WinControls.UI.CommandBarButton();
      this.btn_filterlist = new Telerik.WinControls.UI.CommandBarButton();
      this.btn_filtereditor = new Telerik.WinControls.UI.CommandBarButton();
      this.btn_regex = new Telerik.WinControls.UI.CommandBarButton();
      this.commandBarSeparator1 = new Telerik.WinControls.UI.CommandBarSeparator();
      this.btn_csvExport = new Telerik.WinControls.UI.CommandBarButton();
      this.btn_print = new Telerik.WinControls.UI.CommandBarButton();
      this.commandBarSeparator2 = new Telerik.WinControls.UI.CommandBarSeparator();
      this.btn_snapshot_new = new Telerik.WinControls.UI.CommandBarButton();
      this.wordBag1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.WordBag();
      this.btn_posFilter = new Telerik.WinControls.UI.CommandBarButton();
      ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
      this.SuspendLayout();
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
      this.radGridView1.MasterTemplate.MultiSelect = true;
      this.radGridView1.MasterTemplate.ViewDefinition = tableViewDefinition1;
      this.radGridView1.Name = "radGridView1";
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
      this.commandBarRowElement1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
      this.commandBarRowElement1.MinSize = new System.Drawing.Size(25, 25);
      this.commandBarRowElement1.Name = "commandBarRowElement1";
      this.commandBarRowElement1.Strips.AddRange(new Telerik.WinControls.UI.CommandBarStripElement[] {
            this.commandBarStripElement1});
      this.commandBarRowElement1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
      this.commandBarRowElement1.UseCompatibleTextRendering = false;
      // 
      // commandBarStripElement1
      // 
      this.commandBarStripElement1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
      resources.ApplyResources(this.commandBarStripElement1, "commandBarStripElement1");
      // 
      // 
      // 
      this.commandBarStripElement1.Grip.Visibility = Telerik.WinControls.ElementVisibility.Visible;
      this.commandBarStripElement1.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.btn_function,
            this.btn_calc,
            this.btn_filterlist,
            this.btn_filtereditor,
            this.btn_regex,
            this.btn_posFilter,
            this.commandBarSeparator1,
            this.btn_csvExport,
            this.btn_print,
            this.commandBarSeparator2,
            this.btn_snapshot_new});
      this.commandBarStripElement1.Name = "commandBarStripElement1";
      // 
      // 
      // 
      this.commandBarStripElement1.OverflowButton.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
      this.commandBarStripElement1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
      this.commandBarStripElement1.UseCompatibleTextRendering = false;
      ((Telerik.WinControls.UI.RadCommandBarGrip)(this.commandBarStripElement1.GetChildAt(0))).Visibility = Telerik.WinControls.ElementVisibility.Visible;
      ((Telerik.WinControls.UI.RadCommandBarOverflowButton)(this.commandBarStripElement1.GetChildAt(2))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
      // 
      // btn_function
      // 
      this.btn_function.AutoToolTip = true;
      this.btn_function.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
      resources.ApplyResources(this.btn_function, "btn_function");
      this.btn_function.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.magic_wand;
      this.btn_function.Name = "btn_function";
      this.btn_function.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.VordefinierteFunktionen;
      this.btn_function.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
      this.btn_function.ToolTipText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.VordefinierteFunktionen;
      this.btn_function.UseCompatibleTextRendering = false;
      this.btn_function.Click += new System.EventHandler(this.btn_function_Click);
      // 
      // btn_calc
      // 
      this.btn_calc.AutoToolTip = true;
      this.btn_calc.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
      resources.ApplyResources(this.btn_calc, "btn_calc");
      this.btn_calc.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.calculator;
      this.btn_calc.Name = "btn_calc";
      this.btn_calc.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.EigeneFunktionenBerechnungen;
      this.btn_calc.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
      this.btn_calc.ToolTipText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.EigeneFunktionenBerechnungen;
      this.btn_calc.UseCompatibleTextRendering = false;
      this.btn_calc.Click += new System.EventHandler(this.btn_calc_Click);
      // 
      // btn_filterlist
      // 
      this.btn_filterlist.AutoToolTip = true;
      this.btn_filterlist.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
      resources.ApplyResources(this.btn_filterlist, "btn_filterlist");
      this.btn_filterlist.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.filter_list;
      this.btn_filterlist.Name = "btn_filterlist";
      this.btn_filterlist.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
      this.btn_filterlist.UseCompatibleTextRendering = false;
      this.btn_filterlist.Click += new System.EventHandler(this.btn_filterlist_Click);
      // 
      // btn_filtereditor
      // 
      this.btn_filtereditor.AutoToolTip = true;
      this.btn_filtereditor.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
      resources.ApplyResources(this.btn_filtereditor, "btn_filtereditor");
      this.btn_filtereditor.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.filter_settings;
      this.btn_filtereditor.Name = "btn_filtereditor";
      this.btn_filtereditor.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
      this.btn_filtereditor.UseCompatibleTextRendering = false;
      this.btn_filtereditor.Click += new System.EventHandler(this.btn_filtereditor_Click);
      // 
      // btn_regex
      // 
      this.btn_regex.AutoToolTip = true;
      resources.ApplyResources(this.btn_regex, "btn_regex");
      this.btn_regex.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.filter_regex;
      this.btn_regex.Name = "btn_regex";
      this.btn_regex.Click += new System.EventHandler(this.btn_regex_Click);
      // 
      // commandBarSeparator1
      // 
      this.commandBarSeparator1.AccessibleDescription = "commandBarSeparator1";
      this.commandBarSeparator1.AccessibleName = "commandBarSeparator1";
      this.commandBarSeparator1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
      resources.ApplyResources(this.commandBarSeparator1, "commandBarSeparator1");
      this.commandBarSeparator1.Name = "commandBarSeparator1";
      this.commandBarSeparator1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
      this.commandBarSeparator1.UseCompatibleTextRendering = false;
      this.commandBarSeparator1.VisibleInOverflowMenu = false;
      // 
      // btn_csvExport
      // 
      this.btn_csvExport.AutoToolTip = true;
      this.btn_csvExport.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
      resources.ApplyResources(this.btn_csvExport, "btn_csvExport");
      this.btn_csvExport.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.export_text;
      this.btn_csvExport.Name = "btn_csvExport";
      this.btn_csvExport.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.CSVExport;
      this.btn_csvExport.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
      this.btn_csvExport.ToolTipText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.CSVExport;
      this.btn_csvExport.UseCompatibleTextRendering = false;
      this.btn_csvExport.Click += new System.EventHandler(this.btn_csvExport_Click);
      // 
      // btn_print
      // 
      this.btn_print.AutoToolTip = true;
      this.btn_print.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
      resources.ApplyResources(this.btn_print, "btn_print");
      this.btn_print.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.print;
      this.btn_print.Name = "btn_print";
      this.btn_print.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Drucken;
      this.btn_print.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
      this.btn_print.ToolTipText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Drucken;
      this.btn_print.UseCompatibleTextRendering = false;
      this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
      // 
      // commandBarSeparator2
      // 
      resources.ApplyResources(this.commandBarSeparator2, "commandBarSeparator2");
      this.commandBarSeparator2.Name = "commandBarSeparator2";
      this.commandBarSeparator2.VisibleInOverflowMenu = false;
      // 
      // btn_snapshot_new
      // 
      this.btn_snapshot_new.AutoToolTip = true;
      resources.ApplyResources(this.btn_snapshot_new, "btn_snapshot_new");
      this.btn_snapshot_new.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.camera_add;
      this.btn_snapshot_new.Name = "btn_snapshot_new";
      this.btn_snapshot_new.Click += new System.EventHandler(this.btn_snapshot_new_Click);
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
      // btn_posFilter
      // 
      resources.ApplyResources(this.btn_posFilter, "btn_posFilter");
      this.btn_posFilter.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.filter_pos;
      this.btn_posFilter.Name = "btn_posFilter";
      this.btn_posFilter.Click += new System.EventHandler(this.btn_posFilter_Click);
      // 
      // CollocateFrequency
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.Controls.Add(this.radGridView1);
      this.Controls.Add(this.wordBag1);
      this.Controls.Add(this.radCommandBar1);
      this.Name = "CollocateFrequency";
      ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Telerik.WinControls.UI.RadGridView radGridView1;
    private Telerik.WinControls.UI.RadCommandBar radCommandBar1;
    private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
    private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement1;
    private Telerik.WinControls.UI.CommandBarButton btn_function;
    private Telerik.WinControls.UI.CommandBarButton btn_calc;
    private Telerik.WinControls.UI.CommandBarButton btn_filterlist;
    private Telerik.WinControls.UI.CommandBarButton btn_filtereditor;
    private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator1;
    private Telerik.WinControls.UI.CommandBarButton btn_csvExport;
    private Telerik.WinControls.UI.CommandBarButton btn_print;
    private Controls.WinForm.WordBag wordBag1;
    private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator2;
    private Telerik.WinControls.UI.CommandBarButton btn_snapshot_new;
    private Telerik.WinControls.UI.CommandBarButton btn_regex;
    private Telerik.WinControls.UI.CommandBarButton btn_posFilter;
  }
}
