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
      this.commandBarLabel2 = new Telerik.WinControls.UI.CommandBarLabel();
      this.txt_size = new Telerik.WinControls.UI.CommandBarTextBox();
      this.commandBarLabel1 = new Telerik.WinControls.UI.CommandBarLabel();
      this.combo_layer = new Telerik.WinControls.UI.CommandBarDropDownList();
      this.commandBarRowElement3 = new Telerik.WinControls.UI.CommandBarRowElement();
      this.commandBarStripElement2 = new Telerik.WinControls.UI.CommandBarStripElement();
      this.commandBarLabel5 = new Telerik.WinControls.UI.CommandBarLabel();
      this.drop_snapshot2 = new Telerik.WinControls.UI.CommandBarDropDownList();
      this.btn_go = new Telerik.WinControls.UI.CommandBarButton();
      this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
      this.commandBarLabel3 = new Telerik.WinControls.UI.CommandBarLabel();
      this.txt_patternSize = new Telerik.WinControls.UI.CommandBarTextBox();
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
      this.radCommandBar1.Size = new System.Drawing.Size(780, 126);
      this.radCommandBar1.TabIndex = 0;
      this.radCommandBar1.Text = "radCommandBar1";
      // 
      // commandBarRowElement1
      // 
      this.commandBarRowElement1.MinSize = new System.Drawing.Size(25, 25);
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
            this.commandBarSeparator1,
            this.btn_csvExport,
            this.btn_print});
      this.commandBarStripElement1.Name = "commandBarStripElement1";
      // 
      // btn_calc
      // 
      this.btn_calc.DisplayName = "commandBarButton2";
      this.btn_calc.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.calculator;
      this.btn_calc.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
      this.btn_calc.Name = "btn_calc";
      this.btn_calc.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.EigeneFunktionenBerechnungen;
      this.btn_calc.ToolTipText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.EigeneFunktionenBerechnungen;
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
      this.btn_filtereditor.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.grid_list;
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
      this.btn_csvExport.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.export_text;
      this.btn_csvExport.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
      this.btn_csvExport.Name = "btn_csvExport";
      this.btn_csvExport.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.CSVExport;
      this.btn_csvExport.ToolTipText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.CSVExport;
      this.btn_csvExport.Click += new System.EventHandler(this.btn_csvExport_Click);
      // 
      // btn_print
      // 
      this.btn_print.DisplayName = "commandBarButton4";
      this.btn_print.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.print;
      this.btn_print.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
      this.btn_print.Name = "btn_print";
      this.btn_print.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Drucken;
      this.btn_print.ToolTipText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Drucken;
      this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
      // 
      // commandBarRowElement2
      // 
      this.commandBarRowElement2.MinSize = new System.Drawing.Size(25, 25);
      this.commandBarRowElement2.Strips.AddRange(new Telerik.WinControls.UI.CommandBarStripElement[] {
            this.commandBarStripElement3});
      // 
      // commandBarStripElement3
      // 
      this.commandBarStripElement3.DisplayName = "commandBarStripElement3";
      this.commandBarStripElement3.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.commandBarLabel2,
            this.txt_size,
            this.commandBarLabel3,
            this.txt_patternSize,
            this.commandBarLabel1,
            this.combo_layer});
      this.commandBarStripElement3.Name = "commandBarStripElement3";
      // 
      // commandBarLabel2
      // 
      this.commandBarLabel2.DisplayName = "commandBarLabel2";
      this.commandBarLabel2.Name = "commandBarLabel2";
      this.commandBarLabel2.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.NGramGröße;
      // 
      // txt_size
      // 
      this.txt_size.AccessibleDescription = "3";
      this.txt_size.AccessibleName = "3";
      this.txt_size.DisplayName = "commandBarTextBox1";
      this.txt_size.Name = "txt_size";
      this.txt_size.Text = "5";
      // 
      // commandBarLabel1
      // 
      this.commandBarLabel1.DisplayName = "commandBarLabel1";
      this.commandBarLabel1.Name = "commandBarLabel1";
      this.commandBarLabel1.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.LayerDP;
      // 
      // combo_layer
      // 
      this.combo_layer.DisplayName = "commandBarDropDownList1";
      this.combo_layer.DropDownAnimationEnabled = true;
      this.combo_layer.MaxDropDownItems = 0;
      this.combo_layer.MinSize = new System.Drawing.Size(200, 22);
      this.combo_layer.Name = "combo_layer";
      this.combo_layer.NullText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.BitteAuswählen;
      this.combo_layer.Text = "";
      // 
      // commandBarRowElement3
      // 
      this.commandBarRowElement3.MinSize = new System.Drawing.Size(25, 25);
      this.commandBarRowElement3.Strips.AddRange(new Telerik.WinControls.UI.CommandBarStripElement[] {
            this.commandBarStripElement2});
      // 
      // commandBarStripElement2
      // 
      this.commandBarStripElement2.DisplayName = "commandBarStripElement2";
      this.commandBarStripElement2.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.commandBarLabel5,
            this.drop_snapshot2,
            this.btn_go});
      this.commandBarStripElement2.Name = "commandBarStripElement2";
      // 
      // commandBarLabel5
      // 
      this.commandBarLabel5.DisplayName = "commandBarLabel5";
      this.commandBarLabel5.Name = "commandBarLabel5";
      this.commandBarLabel5.Text = "Vergleiche mit Schnappschuss (2):";
      // 
      // drop_snapshot2
      // 
      this.drop_snapshot2.DisplayName = "commandBarDropDownList2";
      this.drop_snapshot2.DropDownAnimationEnabled = true;
      this.drop_snapshot2.MaxDropDownItems = 0;
      this.drop_snapshot2.MinSize = new System.Drawing.Size(200, 22);
      this.drop_snapshot2.Name = "drop_snapshot2";
      this.drop_snapshot2.NullText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.BitteAuswählen;
      this.drop_snapshot2.Text = "";
      // 
      // btn_go
      // 
      this.btn_go.DisplayName = "commandBarButton1";
      this.btn_go.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.button_circle_right;
      this.btn_go.Name = "btn_go";
      this.btn_go.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.VergleichStarten;
      this.btn_go.Click += new System.EventHandler(this.btn_go_Click);
      // 
      // radGridView1
      // 
      this.radGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radGridView1.Location = new System.Drawing.Point(0, 126);
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
      this.radGridView1.Size = new System.Drawing.Size(780, 274);
      this.radGridView1.TabIndex = 1;
      this.radGridView1.Text = "radGridView1";
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
      // CompareNGram
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
    private Telerik.WinControls.UI.CommandBarLabel commandBarLabel1;
    private Telerik.WinControls.UI.CommandBarDropDownList combo_layer;
    private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement3;
    private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement2;
    private Telerik.WinControls.UI.CommandBarLabel commandBarLabel5;
    private Telerik.WinControls.UI.CommandBarDropDownList drop_snapshot2;
    private Telerik.WinControls.UI.CommandBarButton btn_go;
    private Telerik.WinControls.UI.CommandBarButton btn_filterlist;
    private Telerik.WinControls.UI.CommandBarButton btn_filtereditor;
    private Telerik.WinControls.UI.CommandBarLabel commandBarLabel3;
    private Telerik.WinControls.UI.CommandBarTextBox txt_patternSize;
  }
}
