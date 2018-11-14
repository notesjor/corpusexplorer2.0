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
      Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
      this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
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
      this.btn_snapshot_new = new Telerik.WinControls.UI.CommandBarButton();
      this.wordBag1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.WordBag();
      this.btn_regex = new Telerik.WinControls.UI.CommandBarButton();
      ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
      this.SuspendLayout();
      // 
      // radGridView1
      // 
      this.radGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radGridView1.Location = new System.Drawing.Point(0, 105);
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
      this.radGridView1.Size = new System.Drawing.Size(780, 295);
      this.radGridView1.TabIndex = 4;
      // 
      // radCommandBar1
      // 
      this.radCommandBar1.Dock = System.Windows.Forms.DockStyle.Top;
      this.radCommandBar1.Location = new System.Drawing.Point(0, 0);
      this.radCommandBar1.Name = "radCommandBar1";
      this.radCommandBar1.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement1});
      this.radCommandBar1.Size = new System.Drawing.Size(780, 69);
      this.radCommandBar1.TabIndex = 3;
      // 
      // commandBarRowElement1
      // 
      this.commandBarRowElement1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
      this.commandBarRowElement1.MinSize = new System.Drawing.Size(25, 25);
      this.commandBarRowElement1.Name = "commandBarRowElement1";
      this.commandBarRowElement1.Strips.AddRange(new Telerik.WinControls.UI.CommandBarStripElement[] {
            this.commandBarStripElement1});
      this.commandBarRowElement1.Text = "";
      this.commandBarRowElement1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
      this.commandBarRowElement1.UseCompatibleTextRendering = false;
      // 
      // commandBarStripElement1
      // 
      this.commandBarStripElement1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
      this.commandBarStripElement1.DisplayName = "commandBarStripElement1";
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
      this.btn_function.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
      this.btn_function.DisplayName = "commandBarButton1";
      this.btn_function.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.magic_wand;
      this.btn_function.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
      this.btn_function.Name = "btn_function";
      this.btn_function.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.VordefinierteFunktionen;
      this.btn_function.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
      this.btn_function.ToolTipText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.VordefinierteFunktionen;
      this.btn_function.UseCompatibleTextRendering = false;
      this.btn_function.Click += new System.EventHandler(this.btn_function_Click);
      // 
      // btn_calc
      // 
      this.btn_calc.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
      this.btn_calc.DisplayName = "commandBarButton2";
      this.btn_calc.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.calculator;
      this.btn_calc.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
      this.btn_calc.Name = "btn_calc";
      this.btn_calc.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.EigeneFunktionenBerechnungen;
      this.btn_calc.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
      this.btn_calc.ToolTipText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.EigeneFunktionenBerechnungen;
      this.btn_calc.UseCompatibleTextRendering = false;
      this.btn_calc.Click += new System.EventHandler(this.btn_calc_Click);
      // 
      // btn_filterlist
      // 
      this.btn_filterlist.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
      this.btn_filterlist.DisplayName = "commandBarButton1";
      this.btn_filterlist.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.filter_list;
      this.btn_filterlist.Name = "btn_filterlist";
      this.btn_filterlist.Text = "Filterliste";
      this.btn_filterlist.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
      this.btn_filterlist.UseCompatibleTextRendering = false;
      this.btn_filterlist.Click += new System.EventHandler(this.btn_filterlist_Click);
      // 
      // btn_filtereditor
      // 
      this.btn_filtereditor.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
      this.btn_filtereditor.DisplayName = "commandBarButton1";
      this.btn_filtereditor.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.filter_settings;
      this.btn_filtereditor.Name = "btn_filtereditor";
      this.btn_filtereditor.Text = "Filtereditor";
      this.btn_filtereditor.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
      this.btn_filtereditor.UseCompatibleTextRendering = false;
      this.btn_filtereditor.Click += new System.EventHandler(this.btn_filtereditor_Click);
      // 
      // commandBarSeparator1
      // 
      this.commandBarSeparator1.AccessibleDescription = "commandBarSeparator1";
      this.commandBarSeparator1.AccessibleName = "commandBarSeparator1";
      this.commandBarSeparator1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
      this.commandBarSeparator1.DisplayName = "commandBarSeparator1";
      this.commandBarSeparator1.Name = "commandBarSeparator1";
      this.commandBarSeparator1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
      this.commandBarSeparator1.UseCompatibleTextRendering = false;
      this.commandBarSeparator1.VisibleInOverflowMenu = false;
      // 
      // btn_csvExport
      // 
      this.btn_csvExport.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
      this.btn_csvExport.DisplayName = "commandBarButton3";
      this.btn_csvExport.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.export_text;
      this.btn_csvExport.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
      this.btn_csvExport.Name = "btn_csvExport";
      this.btn_csvExport.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.CSVExport;
      this.btn_csvExport.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
      this.btn_csvExport.ToolTipText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.CSVExport;
      this.btn_csvExport.UseCompatibleTextRendering = false;
      this.btn_csvExport.Click += new System.EventHandler(this.btn_csvExport_Click);
      // 
      // btn_print
      // 
      this.btn_print.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
      this.btn_print.DisplayName = "commandBarButton4";
      this.btn_print.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.print;
      this.btn_print.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
      this.btn_print.Name = "btn_print";
      this.btn_print.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Drucken;
      this.btn_print.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
      this.btn_print.ToolTipText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Drucken;
      this.btn_print.UseCompatibleTextRendering = false;
      this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
      // 
      // commandBarSeparator2
      // 
      this.commandBarSeparator2.DisplayName = "commandBarSeparator2";
      this.commandBarSeparator2.Name = "commandBarSeparator2";
      this.commandBarSeparator2.VisibleInOverflowMenu = false;
      // 
      // btn_snapshot_new
      // 
      this.btn_snapshot_new.DisplayName = "commandBarButton1";
      this.btn_snapshot_new.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.camera_add;
      this.btn_snapshot_new.Name = "btn_snapshot_new";
      this.btn_snapshot_new.Text = "Schnappschuss erstellen";
      this.btn_snapshot_new.Click += new System.EventHandler(this.btn_snapshot_new_Click);
      // 
      // wordBag1
      // 
      this.wordBag1.BackColor = System.Drawing.Color.White;
      this.wordBag1.Dock = System.Windows.Forms.DockStyle.Top;
      this.wordBag1.Font = new System.Drawing.Font("Segoe UI", 11F);
      this.wordBag1.Location = new System.Drawing.Point(0, 69);
      this.wordBag1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
      this.wordBag1.Name = "wordBag1";
      this.wordBag1.ResultQueries = new string[0];
      this.wordBag1.ResultSelectedLayerDisplayname = null;
      this.wordBag1.Size = new System.Drawing.Size(780, 36);
      this.wordBag1.TabIndex = 5;
      this.wordBag1.ExecuteButtonClicked += new System.EventHandler(this.wordBag1_ExecuteButtonClicked);
      // 
      // btn_regex
      // 
      this.btn_regex.DisplayName = "commandBarButton1";
      this.btn_regex.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.filter_regex;
      this.btn_regex.Name = "btn_regex";
      this.btn_regex.Text = "RegEx-Suche";
      this.btn_regex.Click += new System.EventHandler(this.btn_regex_Click);
      // 
      // CollocateFrequency
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
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
  }
}
