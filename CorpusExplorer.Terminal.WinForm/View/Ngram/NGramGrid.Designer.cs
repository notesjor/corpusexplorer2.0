namespace CorpusExplorer.Terminal.WinForm.View.Ngram
{
  partial class NGramGrid
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NGramGrid));
      Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
      this.radCommandBar1 = new Telerik.WinControls.UI.RadCommandBar();
      this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
      this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
      this.btn_function = new Telerik.WinControls.UI.CommandBarButton();
      this.btn_calc = new Telerik.WinControls.UI.CommandBarButton();
      this.btn_filterlist = new Telerik.WinControls.UI.CommandBarButton();
      this.btn_filtereditor = new Telerik.WinControls.UI.CommandBarButton();
      this.commandBarSeparator1 = new Telerik.WinControls.UI.CommandBarSeparator();
      this.btn_csvExport = new Telerik.WinControls.UI.CommandBarButton();
      this.btn_print = new Telerik.WinControls.UI.CommandBarButton();
      this.commandBarSeparator2 = new Telerik.WinControls.UI.CommandBarSeparator();
      this.btn_snapshot_create = new Telerik.WinControls.UI.CommandBarButton();
      this.commandBarRowElement2 = new Telerik.WinControls.UI.CommandBarRowElement();
      this.commandBarStripElement3 = new Telerik.WinControls.UI.CommandBarStripElement();
      this.commandBarLabel2 = new Telerik.WinControls.UI.CommandBarLabel();
      this.txt_size = new Telerik.WinControls.UI.CommandBarTextBox();
      this.commandBarLabel3 = new Telerik.WinControls.UI.CommandBarLabel();
      this.txt_pattern = new Telerik.WinControls.UI.CommandBarTextBox();
      this.btn_run = new Telerik.WinControls.UI.CommandBarButton();
      this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
      this.btn_layer = new Telerik.WinControls.UI.CommandBarButton();
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
            this.commandBarRowElement2});
      this.radCommandBar1.Size = new System.Drawing.Size(780, 110);
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
            this.btn_function,
            this.btn_calc,
            this.btn_filterlist,
            this.btn_filtereditor,
            this.commandBarSeparator1,
            this.btn_csvExport,
            this.btn_print,
            this.commandBarSeparator2,
            this.btn_snapshot_create});
      this.commandBarStripElement1.Name = "commandBarStripElement1";
      // 
      // btn_function
      // 
      this.btn_function.DisplayName = "commandBarButton1";
      this.btn_function.Image = ((System.Drawing.Image)(resources.GetObject("btn_function.Image")));
      this.btn_function.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
      this.btn_function.Name = "btn_function";
      this.btn_function.Text = "Vordefinierte Funktionen";
      this.btn_function.ToolTipText = "Vordefinierte Funktionen";
      this.btn_function.Click += new System.EventHandler(this.btn_function_Click);
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
      this.btn_filterlist.Image = ((System.Drawing.Image)(resources.GetObject("btn_filterlist.Image")));
      this.btn_filterlist.Name = "btn_filterlist";
      this.btn_filterlist.Text = "Filterliste";
      this.btn_filterlist.Click += new System.EventHandler(this.btn_filterlist_Click);
      // 
      // btn_filtereditor
      // 
      this.btn_filtereditor.DisplayName = "commandBarButton1";
      this.btn_filtereditor.Image = ((System.Drawing.Image)(resources.GetObject("btn_filtereditor.Image")));
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
      // commandBarSeparator2
      // 
      this.commandBarSeparator2.AccessibleDescription = "commandBarSeparator2";
      this.commandBarSeparator2.AccessibleName = "commandBarSeparator2";
      this.commandBarSeparator2.DisplayName = "commandBarSeparator2";
      this.commandBarSeparator2.Name = "commandBarSeparator2";
      this.commandBarSeparator2.VisibleInOverflowMenu = false;
      // 
      // btn_snapshot_create
      // 
      this.btn_snapshot_create.DisplayName = "commandBarButton1";
      this.btn_snapshot_create.Image = ((System.Drawing.Image)(resources.GetObject("btn_snapshot_create.Image")));
      this.btn_snapshot_create.Name = "btn_snapshot_create";
      this.btn_snapshot_create.Text = "Schnappschuss erstellen";
      this.btn_snapshot_create.ToolTipText = "Schnappschuss erstellen";
      this.btn_snapshot_create.Click += new System.EventHandler(this.btn_snapshot_create_Click);
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
            this.txt_pattern,
            this.btn_run});
      this.commandBarStripElement3.Name = "commandBarStripElement3";
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
      // txt_pattern
      // 
      this.txt_pattern.DisplayName = "commandBarTextBox2";
      this.txt_pattern.Name = "txt_pattern";
      this.txt_pattern.Text = "0";
      // 
      // btn_run
      // 
      this.btn_run.AccessibleDescription = "commandBarButton1";
      this.btn_run.AccessibleName = "commandBarButton1";
      this.btn_run.DisplayName = "commandBarButton1";
      this.btn_run.Image = ((System.Drawing.Image)(resources.GetObject("btn_run.Image")));
      this.btn_run.Name = "btn_run";
      this.btn_run.Text = "Analyse ausführen";
      this.btn_run.ToolTipText = "Analyse ausführen";
      this.btn_run.Click += new System.EventHandler(this.btn_execute_Click);
      // 
      // radGridView1
      // 
      this.radGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radGridView1.Location = new System.Drawing.Point(0, 110);
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
      this.radGridView1.Size = new System.Drawing.Size(780, 290);
      this.radGridView1.TabIndex = 1;
      // 
      // btn_layer
      // 
      this.btn_layer.DisplayName = "commandBarButton1";
      this.btn_layer.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.layers;
      this.btn_layer.Name = "btn_layer";
      this.btn_layer.Text = "Layer auswählen";
      this.btn_layer.Click += new System.EventHandler(this.btn_layer_Click);
      // 
      // NGramGrid
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.radGridView1);
      this.Controls.Add(this.radCommandBar1);
      this.Name = "NGramGrid";
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
    private Telerik.WinControls.UI.CommandBarButton btn_function;
    private Telerik.WinControls.UI.CommandBarButton btn_calc;
    private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator1;
    private Telerik.WinControls.UI.CommandBarButton btn_csvExport;
    private Telerik.WinControls.UI.CommandBarButton btn_print;
    private Telerik.WinControls.UI.RadGridView radGridView1;
    private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement2;
    private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement3;
    private Telerik.WinControls.UI.CommandBarLabel commandBarLabel2;
    private Telerik.WinControls.UI.CommandBarTextBox txt_size;
    private Telerik.WinControls.UI.CommandBarLabel commandBarLabel3;
    private Telerik.WinControls.UI.CommandBarTextBox txt_pattern;
    private Telerik.WinControls.UI.CommandBarButton btn_run;
    private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator2;
    private Telerik.WinControls.UI.CommandBarButton btn_snapshot_create;
    private Telerik.WinControls.UI.CommandBarButton btn_filterlist;
    private Telerik.WinControls.UI.CommandBarButton btn_filtereditor;
    private Telerik.WinControls.UI.CommandBarButton btn_layer;
  }
}
