namespace CorpusExplorer.Terminal.WinForm.View.CorpusDistribution
{
  partial class CorpusDistributionOverTime
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CorpusDistributionOverTime));
      Telerik.WinControls.UI.CartesianArea cartesianArea1 = new Telerik.WinControls.UI.CartesianArea();
      Telerik.WinControls.UI.CategoricalAxis categoricalAxis1 = new Telerik.WinControls.UI.CategoricalAxis();
      Telerik.WinControls.UI.LinearAxis linearAxis1 = new Telerik.WinControls.UI.LinearAxis();
      this.radCommandBar1 = new Telerik.WinControls.UI.RadCommandBar();
      this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
      this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
      this.commandBarLabel1 = new Telerik.WinControls.UI.CommandBarLabel();
      this.commandBarDropDownList1 = new Telerik.WinControls.UI.CommandBarDropDownList();
      this.commandBarSeparator1 = new Telerik.WinControls.UI.CommandBarSeparator();
      this.commandBarLabel2 = new Telerik.WinControls.UI.CommandBarLabel();
      this.commandBarTextBox1 = new Telerik.WinControls.UI.CommandBarTextBox();
      this.commandBarRowElement2 = new Telerik.WinControls.UI.CommandBarRowElement();
      this.commandBarStripElement2 = new Telerik.WinControls.UI.CommandBarStripElement();
      this.commandBarLabel3 = new Telerik.WinControls.UI.CommandBarLabel();
      this.commandBarDropDownList2 = new Telerik.WinControls.UI.CommandBarDropDownList();
      this.commandBarSeparator3 = new Telerik.WinControls.UI.CommandBarSeparator();
      this.commandBarLabel4 = new Telerik.WinControls.UI.CommandBarLabel();
      this.commandBarDropDownList3 = new Telerik.WinControls.UI.CommandBarDropDownList();
      this.commandBarSeparator2 = new Telerik.WinControls.UI.CommandBarSeparator();
      this.btn_export = new Telerik.WinControls.UI.CommandBarButton();
      this.chart_view = new Telerik.WinControls.UI.RadChartView();
      this.drop_select = new Telerik.WinControls.UI.RadCheckedDropDownList();
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.chart_view)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.drop_select)).BeginInit();
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
      this.commandBarStripElement1.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.commandBarLabel1,
            this.commandBarDropDownList1,
            this.commandBarSeparator1,
            this.commandBarLabel2,
            this.commandBarTextBox1});
      this.commandBarStripElement1.Name = "commandBarStripElement1";
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
            this.commandBarLabel3,
            this.commandBarDropDownList2,
            this.commandBarSeparator3,
            this.commandBarLabel4,
            this.commandBarDropDownList3,
            this.commandBarSeparator2,
            this.btn_export});
      this.commandBarStripElement2.Name = "commandBarStripElement2";
      // 
      // commandBarLabel3
      // 
      resources.ApplyResources(this.commandBarLabel3, "commandBarLabel3");
      this.commandBarLabel3.Name = "commandBarLabel3";
      // 
      // commandBarDropDownList2
      // 
      resources.ApplyResources(this.commandBarDropDownList2, "commandBarDropDownList2");
      this.commandBarDropDownList2.DropDownAnimationEnabled = true;
      this.commandBarDropDownList2.MaxDropDownItems = 0;
      this.commandBarDropDownList2.MinSize = new System.Drawing.Size(200, 22);
      this.commandBarDropDownList2.Name = "commandBarDropDownList2";
      this.commandBarDropDownList2.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.commandBarDropDownList2_SelectedIndexChanged);
      // 
      // commandBarSeparator3
      // 
      resources.ApplyResources(this.commandBarSeparator3, "commandBarSeparator3");
      this.commandBarSeparator3.Name = "commandBarSeparator3";
      this.commandBarSeparator3.VisibleInOverflowMenu = false;
      // 
      // commandBarLabel4
      // 
      resources.ApplyResources(this.commandBarLabel4, "commandBarLabel4");
      this.commandBarLabel4.Name = "commandBarLabel4";
      // 
      // commandBarDropDownList3
      // 
      resources.ApplyResources(this.commandBarDropDownList3, "commandBarDropDownList3");
      this.commandBarDropDownList3.DropDownAnimationEnabled = true;
      this.commandBarDropDownList3.MaxDropDownItems = 0;
      this.commandBarDropDownList3.MinSize = new System.Drawing.Size(150, 22);
      this.commandBarDropDownList3.Name = "commandBarDropDownList3";
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
      // chart_view
      // 
      this.chart_view.AreaDesign = cartesianArea1;
      categoricalAxis1.IsPrimary = true;
      categoricalAxis1.LabelRotationAngle = 300D;
      categoricalAxis1.Title = "";
      linearAxis1.AxisType = Telerik.Charting.AxisType.Second;
      linearAxis1.IsPrimary = true;
      linearAxis1.LabelRotationAngle = 300D;
      linearAxis1.TickOrigin = null;
      linearAxis1.Title = "";
      this.chart_view.Axes.AddRange(new Telerik.WinControls.UI.Axis[] {
            categoricalAxis1,
            linearAxis1});
      resources.ApplyResources(this.chart_view, "chart_view");
      this.chart_view.Name = "chart_view";
      this.chart_view.ShowGrid = false;
      this.chart_view.ShowLegend = true;
      this.chart_view.ShowPanZoom = true;
      this.chart_view.ShowToolTip = true;
      this.chart_view.ShowTrackBall = true;
      // 
      // drop_select
      // 
      resources.ApplyResources(this.drop_select, "drop_select");
      this.drop_select.Name = "drop_select";
      this.drop_select.ItemCheckedChanged += new Telerik.WinControls.UI.RadCheckedListDataItemEventHandler(this.drop_select_ItemCheckedChanged);
      // 
      // CorpusDistributionOverTime
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.Controls.Add(this.chart_view);
      this.Controls.Add(this.drop_select);
      this.Controls.Add(this.radCommandBar1);
      this.Name = "CorpusDistributionOverTime";
      resources.ApplyResources(this, "$this");
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.chart_view)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.drop_select)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Telerik.WinControls.UI.RadCommandBar radCommandBar1;
    private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
    private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement1;
    private Telerik.WinControls.UI.CommandBarLabel commandBarLabel1;
    private Telerik.WinControls.UI.CommandBarDropDownList commandBarDropDownList1;
    private Telerik.WinControls.UI.RadChartView chart_view;
    private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator1;
    private Telerik.WinControls.UI.CommandBarLabel commandBarLabel2;
    private Telerik.WinControls.UI.CommandBarTextBox commandBarTextBox1;
    private Telerik.WinControls.UI.RadCheckedDropDownList drop_select;
    private Telerik.WinControls.UI.CommandBarLabel commandBarLabel3;
    private Telerik.WinControls.UI.CommandBarDropDownList commandBarDropDownList2;
    private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator3;
    private Telerik.WinControls.UI.CommandBarLabel commandBarLabel4;
    private Telerik.WinControls.UI.CommandBarDropDownList commandBarDropDownList3;
    private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement2;
    private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement2;
    private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator2;
    private Telerik.WinControls.UI.CommandBarButton btn_export;
  }
}
