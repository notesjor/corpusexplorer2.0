namespace CorpusExplorer.Terminal.WinForm.View.Frequency
{
  partial class CompareFrequency
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
      if (disposing && (this.components != null))
      {
        this.components.Dispose();
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompareFrequency));
      Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
      this.radCommandBar1 = new Telerik.WinControls.UI.RadCommandBar();
      this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
      this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
      this.btn_calc = new Telerik.WinControls.UI.CommandBarButton();
      this.btn_filterlist = new Telerik.WinControls.UI.CommandBarButton();
      this.btn_filtereditor = new Telerik.WinControls.UI.CommandBarButton();
      this.btn_regex = new Telerik.WinControls.UI.CommandBarButton();
      this.btn_layer = new Telerik.WinControls.UI.CommandBarButton();
      this.commandBarSeparator1 = new Telerik.WinControls.UI.CommandBarSeparator();
      this.btn_csvExport = new Telerik.WinControls.UI.CommandBarButton();
      this.btn_print = new Telerik.WinControls.UI.CommandBarButton();
      this.commandBarRowElement2 = new Telerik.WinControls.UI.CommandBarRowElement();
      this.commandBarStripElement2 = new Telerik.WinControls.UI.CommandBarStripElement();
      this.commandBarLabel2 = new Telerik.WinControls.UI.CommandBarLabel();
      this.commandBarHostItem1 = new Telerik.WinControls.UI.CommandBarHostItem();
      this.btn_ok = new Telerik.WinControls.UI.CommandBarButton();
      this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
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
            this.commandBarRowElement1,
            this.commandBarRowElement2});
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
      resources.ApplyResources(this.commandBarStripElement1, "commandBarStripElement1");
      // 
      // 
      // 
      this.commandBarStripElement1.Grip.Visibility = Telerik.WinControls.ElementVisibility.Visible;
      this.commandBarStripElement1.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.btn_calc,
            this.btn_filterlist,
            this.btn_filtereditor,
            this.btn_regex,
            this.btn_layer,
            this.commandBarSeparator1,
            this.btn_csvExport,
            this.btn_print});
      this.commandBarStripElement1.Name = "commandBarStripElement1";
      // 
      // 
      // 
      this.commandBarStripElement1.OverflowButton.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
      ((Telerik.WinControls.UI.RadCommandBarGrip)(this.commandBarStripElement1.GetChildAt(0))).Visibility = Telerik.WinControls.ElementVisibility.Visible;
      ((Telerik.WinControls.UI.RadCommandBarOverflowButton)(this.commandBarStripElement1.GetChildAt(2))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
      // 
      // btn_calc
      // 
      resources.ApplyResources(this.btn_calc, "btn_calc");
      this.btn_calc.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.calculator;
      this.btn_calc.AutoToolTip = true;
      this.btn_calc.Name = "btn_calc";
      this.btn_calc.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.EigeneFunktionenBerechnungen;
      this.btn_calc.ToolTipText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.EigeneFunktionenBerechnungen;
      this.btn_calc.Click += new System.EventHandler(this.btn_calc_Click);
      // 
      // btn_filterlist
      // 
      resources.ApplyResources(this.btn_filterlist, "btn_filterlist");
      this.btn_filterlist.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.filter_list;
      this.btn_filterlist.AutoToolTip = true;
      this.btn_filterlist.Name = "btn_filterlist";
      this.btn_filterlist.Click += new System.EventHandler(this.btn_filterlist_Click);
      // 
      // btn_filtereditor
      // 
      resources.ApplyResources(this.btn_filtereditor, "btn_filtereditor");
      this.btn_filtereditor.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.filter_settings;
      this.btn_filtereditor.AutoToolTip = true;
      this.btn_filtereditor.Name = "btn_filtereditor";
      this.btn_filtereditor.Click += new System.EventHandler(this.btn_filtereditor_Click);
      // 
      // btn_regex
      // 
      resources.ApplyResources(this.btn_regex, "btn_regex");
      this.btn_regex.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.filter_regex;
      this.btn_regex.AutoToolTip = true;
      this.btn_regex.Name = "btn_regex";
      this.btn_regex.Click += new System.EventHandler(this.btn_regex_Click);
      // 
      // btn_layer
      // 
      resources.ApplyResources(this.btn_layer, "btn_layer");
      this.btn_layer.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.layers;
      this.btn_layer.AutoToolTip = true;
      this.btn_layer.Name = "btn_layer";
      this.btn_layer.Click += new System.EventHandler(this.btn_layer_Click);
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
            this.commandBarLabel2,
            this.commandBarHostItem1,
            this.btn_ok});
      this.commandBarStripElement2.Name = "commandBarStripElement2";
      // 
      // commandBarLabel2
      // 
      resources.ApplyResources(this.commandBarLabel2, "commandBarLabel2");
      this.commandBarLabel2.Name = "commandBarLabel2";
      // 
      // commandBarHostItem1
      // 
      this.commandBarHostItem1.AutoSize = false;
      this.commandBarHostItem1.Bounds = new System.Drawing.Rectangle(0, 0, 253, 38);
      this.commandBarHostItem1.MinSize = new System.Drawing.Size(250, 36);
      this.commandBarHostItem1.Name = "commandBarHostItem1";
      resources.ApplyResources(this.commandBarHostItem1, "commandBarHostItem1");
      // 
      // btn_ok
      // 
      resources.ApplyResources(this.btn_ok, "btn_ok");
      this.btn_ok.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.button_circle_right;
      this.btn_ok.AutoToolTip = true;
      this.btn_ok.Name = "btn_ok";
      this.btn_ok.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.VergleichStarten;
      this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
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
      // CompareFrequency
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.Controls.Add(this.radGridView1);
      this.Controls.Add(this.radCommandBar1);
      this.Name = "CompareFrequency";
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Telerik.WinControls.UI.RadCommandBar radCommandBar1;
    private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
    private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement1;
    private Telerik.WinControls.UI.CommandBarButton btn_calc;
    private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator1;
    private Telerik.WinControls.UI.CommandBarButton btn_csvExport;
    private Telerik.WinControls.UI.CommandBarButton btn_print;
    private Telerik.WinControls.UI.RadGridView radGridView1;
    private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement2;
    private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement2;
    private Telerik.WinControls.UI.CommandBarLabel commandBarLabel2;
    private Telerik.WinControls.UI.CommandBarButton btn_ok;
    private Telerik.WinControls.UI.CommandBarButton btn_filterlist;
    private Telerik.WinControls.UI.CommandBarButton btn_filtereditor;
    private Telerik.WinControls.UI.CommandBarButton btn_layer;
    private Telerik.WinControls.UI.CommandBarHostItem commandBarHostItem1;
    private Telerik.WinControls.UI.CommandBarButton btn_regex;
  }
}
