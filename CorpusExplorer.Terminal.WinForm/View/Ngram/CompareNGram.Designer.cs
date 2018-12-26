namespace CorpusExplorer.Terminal.WinForm.View.Ngram
{
  partial class CompareNGram
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompareNGram));
      Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
      this.radCommandBar1 = new Telerik.WinControls.UI.RadCommandBar();
      this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
      this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
      this.btn_calc = new Telerik.WinControls.UI.CommandBarButton();
      this.btn_filterlist = new Telerik.WinControls.UI.CommandBarButton();
      this.btn_filtereditor = new Telerik.WinControls.UI.CommandBarButton();
      this.btn_regex = new Telerik.WinControls.UI.CommandBarButton();
      this.commandBarSeparator1 = new Telerik.WinControls.UI.CommandBarSeparator();
      this.btn_csvExport = new Telerik.WinControls.UI.CommandBarButton();
      this.btn_print = new Telerik.WinControls.UI.CommandBarButton();
      this.commandBarRowElement2 = new Telerik.WinControls.UI.CommandBarRowElement();
      this.commandBarStripElement3 = new Telerik.WinControls.UI.CommandBarStripElement();
      this.btn_layer = new Telerik.WinControls.UI.CommandBarButton();
      this.commandBarLabel2 = new Telerik.WinControls.UI.CommandBarLabel();
      this.txt_size = new Telerik.WinControls.UI.CommandBarTextBox();
      this.commandBarLabel3 = new Telerik.WinControls.UI.CommandBarLabel();
      this.txt_patternSize = new Telerik.WinControls.UI.CommandBarTextBox();
      this.commandBarRowElement3 = new Telerik.WinControls.UI.CommandBarRowElement();
      this.commandBarStripElement2 = new Telerik.WinControls.UI.CommandBarStripElement();
      this.commandBarLabel5 = new Telerik.WinControls.UI.CommandBarLabel();
      this.commandBarHostItem1 = new Telerik.WinControls.UI.CommandBarHostItem();
      this.btn_go = new Telerik.WinControls.UI.CommandBarButton();
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
            this.commandBarRowElement2,
            this.commandBarRowElement3});
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
      this.commandBarStripElement1.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.btn_calc,
            this.btn_filterlist,
            this.btn_filtereditor,
            this.btn_regex,
            this.commandBarSeparator1,
            this.btn_csvExport,
            this.btn_print});
      this.commandBarStripElement1.Name = "commandBarStripElement1";
      // 
      // btn_calc
      // 
      resources.ApplyResources(this.btn_calc, "btn_calc");
      this.btn_calc.Image = ((System.Drawing.Image)(resources.GetObject("btn_calc.Image")));
      this.btn_calc.AutoToolTip = true;
      this.btn_calc.Name = "btn_calc";
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
      this.btn_csvExport.Image = ((System.Drawing.Image)(resources.GetObject("btn_csvExport.Image")));
      this.btn_csvExport.AutoToolTip = true;
      this.btn_csvExport.Name = "btn_csvExport";
      this.btn_csvExport.Click += new System.EventHandler(this.btn_csvExport_Click);
      // 
      // btn_print
      // 
      resources.ApplyResources(this.btn_print, "btn_print");
      this.btn_print.Image = ((System.Drawing.Image)(resources.GetObject("btn_print.Image")));
      this.btn_print.AutoToolTip = true;
      this.btn_print.Name = "btn_print";
      this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
      // 
      // commandBarRowElement2
      // 
      this.commandBarRowElement2.MinSize = new System.Drawing.Size(25, 25);
      this.commandBarRowElement2.Name = "commandBarRowElement2";
      this.commandBarRowElement2.Strips.AddRange(new Telerik.WinControls.UI.CommandBarStripElement[] {
            this.commandBarStripElement3});
      // 
      // commandBarStripElement3
      // 
      resources.ApplyResources(this.commandBarStripElement3, "commandBarStripElement3");
      this.commandBarStripElement3.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.btn_layer,
            this.commandBarLabel2,
            this.txt_size,
            this.commandBarLabel3,
            this.txt_patternSize});
      this.commandBarStripElement3.Name = "commandBarStripElement3";
      // 
      // btn_layer
      // 
      resources.ApplyResources(this.btn_layer, "btn_layer");
      this.btn_layer.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.layers;
      this.btn_layer.AutoToolTip = true;
      this.btn_layer.Name = "btn_layer";
      this.btn_layer.Click += new System.EventHandler(this.btn_layer_Click);
      // 
      // commandBarLabel2
      // 
      resources.ApplyResources(this.commandBarLabel2, "commandBarLabel2");
      this.commandBarLabel2.Name = "commandBarLabel2";
      // 
      // txt_size
      // 
      this.txt_size.AccessibleDescription = "3";
      this.txt_size.AccessibleName = "3";
      resources.ApplyResources(this.txt_size, "txt_size");
      this.txt_size.Name = "txt_size";
      // 
      // commandBarLabel3
      // 
      resources.ApplyResources(this.commandBarLabel3, "commandBarLabel3");
      this.commandBarLabel3.Name = "commandBarLabel3";
      // 
      // txt_patternSize
      // 
      resources.ApplyResources(this.txt_patternSize, "txt_patternSize");
      this.txt_patternSize.Name = "txt_patternSize";
      // 
      // commandBarRowElement3
      // 
      this.commandBarRowElement3.MinSize = new System.Drawing.Size(25, 25);
      this.commandBarRowElement3.Name = "commandBarRowElement3";
      this.commandBarRowElement3.Strips.AddRange(new Telerik.WinControls.UI.CommandBarStripElement[] {
            this.commandBarStripElement2});
      // 
      // commandBarStripElement2
      // 
      resources.ApplyResources(this.commandBarStripElement2, "commandBarStripElement2");
      this.commandBarStripElement2.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.commandBarLabel5,
            this.commandBarHostItem1,
            this.btn_go});
      this.commandBarStripElement2.Name = "commandBarStripElement2";
      // 
      // commandBarLabel5
      // 
      resources.ApplyResources(this.commandBarLabel5, "commandBarLabel5");
      this.commandBarLabel5.Name = "commandBarLabel5";
      // 
      // commandBarHostItem1
      // 
      this.commandBarHostItem1.AutoSize = false;
      this.commandBarHostItem1.Bounds = new System.Drawing.Rectangle(0, 0, 253, 38);
      this.commandBarHostItem1.MinSize = new System.Drawing.Size(250, 36);
      this.commandBarHostItem1.Name = "commandBarHostItem1";
      resources.ApplyResources(this.commandBarHostItem1, "commandBarHostItem1");
      // 
      // btn_go
      // 
      resources.ApplyResources(this.btn_go, "btn_go");
      this.btn_go.Image = ((System.Drawing.Image)(resources.GetObject("btn_go.Image")));
      this.btn_go.AutoToolTip = true;
      this.btn_go.Name = "btn_go";
      this.btn_go.Click += new System.EventHandler(this.btn_go_Click);
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
      // CompareNGram
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.Controls.Add(this.radGridView1);
      this.Controls.Add(this.radCommandBar1);
      this.Name = "CompareNGram";
      this.ShowView += new System.EventHandler(this.GridNGramVisualisation_ShowVisualisation);
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
    private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement3;
    private Telerik.WinControls.UI.CommandBarLabel commandBarLabel2;
    private Telerik.WinControls.UI.CommandBarTextBox txt_size;
    private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement3;
    private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement2;
    private Telerik.WinControls.UI.CommandBarLabel commandBarLabel5;
    private Telerik.WinControls.UI.CommandBarButton btn_go;
    private Telerik.WinControls.UI.CommandBarButton btn_filterlist;
    private Telerik.WinControls.UI.CommandBarButton btn_filtereditor;
    private Telerik.WinControls.UI.CommandBarLabel commandBarLabel3;
    private Telerik.WinControls.UI.CommandBarTextBox txt_patternSize;
    private Telerik.WinControls.UI.CommandBarButton btn_layer;
    private Telerik.WinControls.UI.CommandBarHostItem commandBarHostItem1;
    private Telerik.WinControls.UI.CommandBarButton btn_regex;
  }
}
