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
      this.btn_regex = new Telerik.WinControls.UI.CommandBarButton();
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
      this.SuspendLayout();
      // 
      // radCommandBar1
      // 
      this.radCommandBar1.Dock = System.Windows.Forms.DockStyle.Top;
      this.radCommandBar1.Location = new System.Drawing.Point(0, 0);
      this.radCommandBar1.Name = "radCommandBar1";
      this.radCommandBar1.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement1,
            this.commandBarRowElement2,
            this.commandBarRowElement3});
      this.radCommandBar1.Size = new System.Drawing.Size(780, 152);
      this.radCommandBar1.TabIndex = 0;
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
      this.btn_calc.DisplayName = "commandBarButton2";
      this.btn_calc.Image = ((System.Drawing.Image)(resources.GetObject("btn_calc.Image")));
      this.btn_calc.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
      this.btn_calc.Name = "btn_calc";
      this.btn_calc.Text = "Eigene Funktionen/Berechnungen";
      this.btn_calc.ToolTipText = "Eigene Funktionen/Berechnungen";
      this.btn_calc.Click += new System.EventHandler(this.btn_calc_Click);
      // 
      // btn_filterlist
      // 
      this.btn_filterlist.DisplayName = "commandBarButton1";
      this.btn_filterlist.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.filter_list;
      this.btn_filterlist.Name = "btn_filterlist";
      this.btn_filterlist.Text = "Filterliste";
      this.btn_filterlist.Click += new System.EventHandler(this.btn_filterlist_Click);
      // 
      // btn_filtereditor
      // 
      this.btn_filtereditor.DisplayName = "commandBarButton1";
      this.btn_filtereditor.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.filter_settings;
      this.btn_filtereditor.Name = "btn_filtereditor";
      this.btn_filtereditor.Text = "Filtereditor";
      this.btn_filtereditor.Click += new System.EventHandler(this.btn_filtereditor_Click);
      // 
      // commandBarSeparator1
      // 
      this.commandBarSeparator1.AccessibleDescription = "commandBarSeparator1";
      this.commandBarSeparator1.AccessibleName = "commandBarSeparator1";
      this.commandBarSeparator1.DisplayName = "commandBarSeparator1";
      this.commandBarSeparator1.Name = "commandBarSeparator1";
      this.commandBarSeparator1.VisibleInOverflowMenu = false;
      // 
      // btn_csvExport
      // 
      this.btn_csvExport.DisplayName = "commandBarButton3";
      this.btn_csvExport.Image = ((System.Drawing.Image)(resources.GetObject("btn_csvExport.Image")));
      this.btn_csvExport.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
      this.btn_csvExport.Name = "btn_csvExport";
      this.btn_csvExport.Text = "CSV-Export";
      this.btn_csvExport.ToolTipText = "CSV-Export";
      this.btn_csvExport.Click += new System.EventHandler(this.btn_csvExport_Click);
      // 
      // btn_print
      // 
      this.btn_print.DisplayName = "commandBarButton4";
      this.btn_print.Image = ((System.Drawing.Image)(resources.GetObject("btn_print.Image")));
      this.btn_print.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
      this.btn_print.Name = "btn_print";
      this.btn_print.Text = "Drucken";
      this.btn_print.ToolTipText = "Drucken";
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
      this.commandBarStripElement3.DisplayName = "commandBarStripElement3";
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
      this.btn_layer.DisplayName = "commandBarButton1";
      this.btn_layer.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.layers;
      this.btn_layer.Name = "btn_layer";
      this.btn_layer.Text = "Layer auswählen";
      this.btn_layer.Click += new System.EventHandler(this.btn_layer_Click);
      // 
      // commandBarLabel2
      // 
      this.commandBarLabel2.DisplayName = "commandBarLabel2";
      this.commandBarLabel2.Name = "commandBarLabel2";
      this.commandBarLabel2.Text = "NGram-Größe:";
      // 
      // txt_size
      // 
      this.txt_size.AccessibleDescription = "3";
      this.txt_size.AccessibleName = "3";
      this.txt_size.DisplayName = "commandBarTextBox1";
      this.txt_size.Name = "txt_size";
      this.txt_size.Text = "5";
      // 
      // commandBarLabel3
      // 
      this.commandBarLabel3.DisplayName = "commandBarLabel3";
      this.commandBarLabel3.Name = "commandBarLabel3";
      this.commandBarLabel3.Text = "Musteranzahl:";
      // 
      // txt_patternSize
      // 
      this.txt_patternSize.DisplayName = "commandBarTextBox1";
      this.txt_patternSize.Name = "txt_patternSize";
      this.txt_patternSize.Text = "0";
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
      this.commandBarStripElement2.DisplayName = "commandBarStripElement2";
      this.commandBarStripElement2.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.commandBarLabel5,
            this.commandBarHostItem1,
            this.btn_go});
      this.commandBarStripElement2.Name = "commandBarStripElement2";
      // 
      // commandBarLabel5
      // 
      this.commandBarLabel5.DisplayName = "commandBarLabel5";
      this.commandBarLabel5.Name = "commandBarLabel5";
      this.commandBarLabel5.Text = "Vergleiche mit Schnappschuss (2):";
      // 
      // commandBarHostItem1
      // 
      this.commandBarHostItem1.AutoSize = false;
      this.commandBarHostItem1.Bounds = new System.Drawing.Rectangle(0, 0, 253, 38);
      this.commandBarHostItem1.MinSize = new System.Drawing.Size(250, 36);
      this.commandBarHostItem1.Name = "commandBarHostItem1";
      this.commandBarHostItem1.Text = "";
      // 
      // btn_go
      // 
      this.btn_go.DisplayName = "commandBarButton1";
      this.btn_go.Image = ((System.Drawing.Image)(resources.GetObject("btn_go.Image")));
      this.btn_go.Name = "btn_go";
      this.btn_go.Text = "Vergleich starten";
      this.btn_go.Click += new System.EventHandler(this.btn_go_Click);
      // 
      // radGridView1
      // 
      this.radGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radGridView1.Location = new System.Drawing.Point(0, 152);
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
      this.radGridView1.Size = new System.Drawing.Size(780, 248);
      this.radGridView1.TabIndex = 1;
      // 
      // btn_regex
      // 
      this.btn_regex.DisplayName = "commandBarButton1";
      this.btn_regex.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.filter_regex;
      this.btn_regex.Name = "btn_regex";
      this.btn_regex.Text = "RegEx-Suche";
      this.btn_regex.Click += new System.EventHandler(this.btn_regex_Click);
      // 
      // CompareNGram
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
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
