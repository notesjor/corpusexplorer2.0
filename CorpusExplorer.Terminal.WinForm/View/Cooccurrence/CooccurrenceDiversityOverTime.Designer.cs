namespace CorpusExplorer.Terminal.WinForm.View.Cooccurrence
{
  partial class CooccurrenceDiversityOverTime
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CooccurrenceDiversityOverTime));
      Telerik.WinControls.UI.CartesianArea cartesianArea1 = new Telerik.WinControls.UI.CartesianArea();
      Telerik.WinControls.UI.CategoricalAxis categoricalAxis1 = new Telerik.WinControls.UI.CategoricalAxis();
      Telerik.WinControls.UI.LinearAxis linearAxis1 = new Telerik.WinControls.UI.LinearAxis();
      this.radCommandBar1 = new Telerik.WinControls.UI.RadCommandBar();
      this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
      this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
      this.btn_layer = new Telerik.WinControls.UI.CommandBarButton();
      this.commandBarLabel1 = new Telerik.WinControls.UI.CommandBarLabel();
      this.commandBarDropDownList1 = new Telerik.WinControls.UI.CommandBarDropDownList();
      this.commandBarSeparator1 = new Telerik.WinControls.UI.CommandBarSeparator();
      this.commandBarLabel2 = new Telerik.WinControls.UI.CommandBarLabel();
      this.commandBarTextBox1 = new Telerik.WinControls.UI.CommandBarTextBox();
      this.commandBarSeparator2 = new Telerik.WinControls.UI.CommandBarSeparator();
      this.btn_export = new Telerik.WinControls.UI.CommandBarButton();
      this.radAutoCompleteBox1 = new Telerik.WinControls.UI.RadAutoCompleteBox();
      this.btn_go = new Telerik.WinControls.UI.RadButton();
      this.radSplitContainer1 = new Telerik.WinControls.UI.RadSplitContainer();
      this.splitPanel1 = new Telerik.WinControls.UI.SplitPanel();
      this.splitPanel2 = new Telerik.WinControls.UI.SplitPanel();
      this.drop_select = new Telerik.WinControls.UI.RadCheckedDropDownList();
      this.chart_view = new Telerik.WinControls.UI.RadChartView();
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radAutoCompleteBox1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_go)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).BeginInit();
      this.radSplitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).BeginInit();
      this.splitPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).BeginInit();
      this.splitPanel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.drop_select)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.chart_view)).BeginInit();
      this.SuspendLayout();
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
      this.commandBarRowElement1.MinSize = new System.Drawing.Size(25, 25);
      this.commandBarRowElement1.Name = "commandBarRowElement1";
      this.commandBarRowElement1.Strips.AddRange(new Telerik.WinControls.UI.CommandBarStripElement[] {
            this.commandBarStripElement1});
      // 
      // commandBarStripElement1
      // 
      resources.ApplyResources(this.commandBarStripElement1, "commandBarStripElement1");
      this.commandBarStripElement1.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.btn_layer,
            this.commandBarLabel1,
            this.commandBarDropDownList1,
            this.commandBarSeparator1,
            this.commandBarLabel2,
            this.commandBarTextBox1,
            this.commandBarSeparator2,
            this.btn_export});
      this.commandBarStripElement1.Name = "commandBarStripElement1";
      // 
      // btn_layer
      // 
      resources.ApplyResources(this.btn_layer, "btn_layer");
      this.btn_layer.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.layers;
      this.btn_layer.AutoToolTip = true;
      this.btn_layer.Name = "btn_layer";
      this.btn_layer.Click += new System.EventHandler(this.btn_layer_Click);
      // 
      // commandBarLabel1
      // 
      resources.ApplyResources(this.commandBarLabel1, "commandBarLabel1");
      this.commandBarLabel1.Name = "commandBarLabel1";
      this.commandBarLabel1.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.DatumsID;
      // 
      // commandBarDropDownList1
      // 
      resources.ApplyResources(this.commandBarDropDownList1, "commandBarDropDownList1");
      this.commandBarDropDownList1.DropDownAnimationEnabled = true;
      this.commandBarDropDownList1.MaxDropDownItems = 0;
      this.commandBarDropDownList1.MinSize = new System.Drawing.Size(200, 22);
      this.commandBarDropDownList1.Name = "commandBarDropDownList1";
      this.commandBarDropDownList1.NullText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.BitteAuswählen;
      // 
      // commandBarSeparator1
      // 
      resources.ApplyResources(this.commandBarSeparator1, "commandBarSeparator1");
      this.commandBarSeparator1.Name = "commandBarSeparator1";
      this.commandBarSeparator1.VisibleInOverflowMenu = false;
      // 
      // commandBarLabel2
      // 
      resources.ApplyResources(this.commandBarLabel2, "commandBarLabel2");
      this.commandBarLabel2.Name = "commandBarLabel2";
      // 
      // commandBarTextBox1
      // 
      resources.ApplyResources(this.commandBarTextBox1, "commandBarTextBox1");
      this.commandBarTextBox1.Name = "commandBarTextBox1";
      // 
      // commandBarSeparator2
      // 
      resources.ApplyResources(this.commandBarSeparator2, "commandBarSeparator2");
      this.commandBarSeparator2.Name = "commandBarSeparator2";
      this.commandBarSeparator2.VisibleInOverflowMenu = false;
      // 
      // btn_export
      // 
      resources.ApplyResources(this.btn_export, "btn_export");
      this.btn_export.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.export_text;
      this.btn_export.AutoToolTip = true;
      this.btn_export.Name = "btn_export";
      this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
      // 
      // radAutoCompleteBox1
      // 
      resources.ApplyResources(this.radAutoCompleteBox1, "radAutoCompleteBox1");
      this.radAutoCompleteBox1.Name = "radAutoCompleteBox1";
      // 
      // btn_go
      // 
      resources.ApplyResources(this.btn_go, "btn_go");
      this.btn_go.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.button_circle_right;
      this.btn_go.Name = "btn_go";
      this.btn_go.Click += new System.EventHandler(this.btn_go_Click);
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
      this.radSplitContainer1.TabStop = false;
      // 
      // splitPanel1
      // 
      this.splitPanel1.Controls.Add(this.radAutoCompleteBox1);
      this.splitPanel1.Controls.Add(this.btn_go);
      resources.ApplyResources(this.splitPanel1, "splitPanel1");
      this.splitPanel1.Name = "splitPanel1";
      // 
      // 
      // 
      this.splitPanel1.RootElement.MinSize = new System.Drawing.Size(0, 0);
      this.splitPanel1.TabStop = false;
      // 
      // splitPanel2
      // 
      this.splitPanel2.Controls.Add(this.drop_select);
      resources.ApplyResources(this.splitPanel2, "splitPanel2");
      this.splitPanel2.Name = "splitPanel2";
      // 
      // 
      // 
      this.splitPanel2.RootElement.MinSize = new System.Drawing.Size(0, 0);
      this.splitPanel2.TabStop = false;
      // 
      // drop_select
      // 
      resources.ApplyResources(this.drop_select, "drop_select");
      this.drop_select.Name = "drop_select";
      this.drop_select.ItemCheckedChanged += new Telerik.WinControls.UI.RadCheckedListDataItemEventHandler(this.drop_select_ItemCheckedChanged);
      // 
      // chart_view
      // 
      this.chart_view.AreaDesign = cartesianArea1;
      categoricalAxis1.IsPrimary = true;
      linearAxis1.AxisType = Telerik.Charting.AxisType.Second;
      linearAxis1.IsPrimary = true;
      linearAxis1.TickOrigin = null;
      this.chart_view.Axes.AddRange(new Telerik.WinControls.UI.Axis[] {
            categoricalAxis1,
            linearAxis1});
      resources.ApplyResources(this.chart_view, "chart_view");
      this.chart_view.Name = "chart_view";
      this.chart_view.ShowGrid = false;
      // 
      // CooccurrenceDiversityOverTime
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.Controls.Add(this.chart_view);
      this.Controls.Add(this.radSplitContainer1);
      this.Controls.Add(this.radCommandBar1);
      this.Name = "CooccurrenceDiversityOverTime";
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radAutoCompleteBox1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_go)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).EndInit();
      this.radSplitContainer1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).EndInit();
      this.splitPanel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).EndInit();
      this.splitPanel2.ResumeLayout(false);
      this.splitPanel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.drop_select)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.chart_view)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Telerik.WinControls.UI.RadCommandBar radCommandBar1;
    private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
    private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement1;
    private Telerik.WinControls.UI.CommandBarLabel commandBarLabel1;
    private Telerik.WinControls.UI.CommandBarDropDownList commandBarDropDownList1;
    private Telerik.WinControls.UI.RadButton btn_go;
    private Telerik.WinControls.UI.RadAutoCompleteBox radAutoCompleteBox1;
    private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator1;
    private Telerik.WinControls.UI.CommandBarLabel commandBarLabel2;
    private Telerik.WinControls.UI.CommandBarTextBox commandBarTextBox1;
    private Telerik.WinControls.UI.RadSplitContainer radSplitContainer1;
    private Telerik.WinControls.UI.SplitPanel splitPanel1;
    private Telerik.WinControls.UI.SplitPanel splitPanel2;
    private Telerik.WinControls.UI.RadCheckedDropDownList drop_select;
    private Telerik.WinControls.UI.RadChartView chart_view;
    private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator2;
    private Telerik.WinControls.UI.CommandBarButton btn_export;
    private Telerik.WinControls.UI.CommandBarButton btn_layer;
  }
}
