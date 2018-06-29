namespace CorpusExplorer.Terminal.WinForm.View.Ngram
{
  partial class NGramOverTimeView
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NGramOverTimeView));
      Telerik.WinControls.UI.CartesianArea cartesianArea1 = new Telerik.WinControls.UI.CartesianArea();
      Telerik.WinControls.UI.CategoricalAxis categoricalAxis1 = new Telerik.WinControls.UI.CategoricalAxis();
      Telerik.WinControls.UI.LinearAxis linearAxis1 = new Telerik.WinControls.UI.LinearAxis();
      this.radCommandBar1 = new Telerik.WinControls.UI.RadCommandBar();
      this.commandBarRowElement2 = new Telerik.WinControls.UI.CommandBarRowElement();
      this.commandBarStripElement3 = new Telerik.WinControls.UI.CommandBarStripElement();
      this.commandBarLabel4 = new Telerik.WinControls.UI.CommandBarLabel();
      this.commandBarDropDownList1 = new Telerik.WinControls.UI.CommandBarDropDownList();
      this.commandBarLabel2 = new Telerik.WinControls.UI.CommandBarLabel();
      this.txt_size = new Telerik.WinControls.UI.CommandBarTextBox();
      this.btn_run = new Telerik.WinControls.UI.CommandBarButton();
      this.commandBarSeparator1 = new Telerik.WinControls.UI.CommandBarSeparator();
      this.btn_export = new Telerik.WinControls.UI.CommandBarButton();
      this.radListView1 = new Telerik.WinControls.UI.RadListView();
      this.radSplitContainer1 = new Telerik.WinControls.UI.RadSplitContainer();
      this.splitPanel1 = new Telerik.WinControls.UI.SplitPanel();
      this.splitPanel2 = new Telerik.WinControls.UI.SplitPanel();
      this.chart_view = new Telerik.WinControls.UI.RadChartView();
      this.btn_layer = new Telerik.WinControls.UI.CommandBarButton();
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radListView1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).BeginInit();
      this.radSplitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).BeginInit();
      this.splitPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).BeginInit();
      this.splitPanel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.chart_view)).BeginInit();
      this.SuspendLayout();
      // 
      // radCommandBar1
      // 
      this.radCommandBar1.Dock = System.Windows.Forms.DockStyle.Top;
      this.radCommandBar1.Location = new System.Drawing.Point(0, 0);
      this.radCommandBar1.Name = "radCommandBar1";
      this.radCommandBar1.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement2});
      this.radCommandBar1.Size = new System.Drawing.Size(780, 69);
      this.radCommandBar1.TabIndex = 0;
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
            this.commandBarLabel4,
            this.commandBarDropDownList1,
            this.commandBarLabel2,
            this.txt_size,
            this.btn_run,
            this.commandBarSeparator1,
            this.btn_export});
      this.commandBarStripElement3.Name = "commandBarStripElement3";
      // 
      // commandBarLabel4
      // 
      this.commandBarLabel4.DisplayName = "commandBarLabel4";
      this.commandBarLabel4.Name = "commandBarLabel4";
      this.commandBarLabel4.Text = "Datums-ID:";
      // 
      // commandBarDropDownList1
      // 
      this.commandBarDropDownList1.DisplayName = "commandBarDropDownList1";
      this.commandBarDropDownList1.DropDownAnimationEnabled = true;
      this.commandBarDropDownList1.MaxDropDownItems = 0;
      this.commandBarDropDownList1.MinSize = new System.Drawing.Size(200, 22);
      this.commandBarDropDownList1.Name = "commandBarDropDownList1";
      this.commandBarDropDownList1.NullText = "Bitte auswählen...";
      this.commandBarDropDownList1.Text = "";
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
      // commandBarSeparator1
      // 
      this.commandBarSeparator1.DisplayName = "commandBarSeparator1";
      this.commandBarSeparator1.Name = "commandBarSeparator1";
      this.commandBarSeparator1.VisibleInOverflowMenu = false;
      // 
      // btn_export
      // 
      this.btn_export.DisplayName = "commandBarButton1";
      this.btn_export.Image = ((System.Drawing.Image)(resources.GetObject("btn_export.Image")));
      this.btn_export.Name = "btn_export";
      this.btn_export.Text = "Exportieren";
      this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
      // 
      // radListView1
      // 
      this.radListView1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radListView1.GroupItemSize = new System.Drawing.Size(200, 40);
      this.radListView1.ItemSize = new System.Drawing.Size(200, 40);
      this.radListView1.Location = new System.Drawing.Point(0, 0);
      this.radListView1.Name = "radListView1";
      this.radListView1.Size = new System.Drawing.Size(241, 331);
      this.radListView1.TabIndex = 1;
      // 
      // radSplitContainer1
      // 
      this.radSplitContainer1.Controls.Add(this.splitPanel1);
      this.radSplitContainer1.Controls.Add(this.splitPanel2);
      this.radSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radSplitContainer1.Location = new System.Drawing.Point(0, 69);
      this.radSplitContainer1.Name = "radSplitContainer1";
      // 
      // 
      // 
      this.radSplitContainer1.RootElement.MinSize = new System.Drawing.Size(25, 25);
      this.radSplitContainer1.Size = new System.Drawing.Size(780, 331);
      this.radSplitContainer1.TabIndex = 2;
      this.radSplitContainer1.TabStop = false;
      // 
      // splitPanel1
      // 
      this.splitPanel1.Controls.Add(this.radListView1);
      this.splitPanel1.Location = new System.Drawing.Point(0, 0);
      this.splitPanel1.Name = "splitPanel1";
      // 
      // 
      // 
      this.splitPanel1.RootElement.MinSize = new System.Drawing.Size(25, 25);
      this.splitPanel1.Size = new System.Drawing.Size(241, 331);
      this.splitPanel1.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(-0.189433F, 0F);
      this.splitPanel1.SizeInfo.SplitterCorrection = new System.Drawing.Size(-147, 0);
      this.splitPanel1.TabIndex = 0;
      this.splitPanel1.TabStop = false;
      this.splitPanel1.Text = "splitPanel1";
      // 
      // splitPanel2
      // 
      this.splitPanel2.Controls.Add(this.chart_view);
      this.splitPanel2.Location = new System.Drawing.Point(245, 0);
      this.splitPanel2.Name = "splitPanel2";
      // 
      // 
      // 
      this.splitPanel2.RootElement.MinSize = new System.Drawing.Size(25, 25);
      this.splitPanel2.Size = new System.Drawing.Size(535, 331);
      this.splitPanel2.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(0.189433F, 0F);
      this.splitPanel2.SizeInfo.SplitterCorrection = new System.Drawing.Size(147, 0);
      this.splitPanel2.TabIndex = 1;
      this.splitPanel2.TabStop = false;
      this.splitPanel2.Text = "splitPanel2";
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
      this.chart_view.Dock = System.Windows.Forms.DockStyle.Fill;
      this.chart_view.Location = new System.Drawing.Point(0, 0);
      this.chart_view.Name = "chart_view";
      this.chart_view.ShowGrid = false;
      this.chart_view.ShowLegend = true;
      this.chart_view.ShowPanZoom = true;
      this.chart_view.ShowToolTip = true;
      this.chart_view.ShowTrackBall = true;
      this.chart_view.Size = new System.Drawing.Size(535, 331);
      this.chart_view.TabIndex = 1;
      // 
      // btn_layer
      // 
      this.btn_layer.DisplayName = "commandBarButton1";
      this.btn_layer.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.layers;
      this.btn_layer.Name = "btn_layer";
      this.btn_layer.Text = "Layer auswählen";
      this.btn_layer.Click += new System.EventHandler(this.btn_layer_Click);
      // 
      // NGramOverTimeView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.radSplitContainer1);
      this.Controls.Add(this.radCommandBar1);
      this.Name = "NGramOverTimeView";
      this.ShowView += new System.EventHandler(this.GridNGramVisualisation_ShowVisualisation);
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radListView1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).EndInit();
      this.radSplitContainer1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).EndInit();
      this.splitPanel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).EndInit();
      this.splitPanel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.chart_view)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Telerik.WinControls.UI.RadCommandBar radCommandBar1;
    private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement2;
    private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement3;
    private Telerik.WinControls.UI.CommandBarLabel commandBarLabel2;
    private Telerik.WinControls.UI.CommandBarTextBox txt_size;
    private Telerik.WinControls.UI.CommandBarButton btn_run;
    private Telerik.WinControls.UI.RadListView radListView1;
    private Telerik.WinControls.UI.RadSplitContainer radSplitContainer1;
    private Telerik.WinControls.UI.SplitPanel splitPanel1;
    private Telerik.WinControls.UI.SplitPanel splitPanel2;
    private Telerik.WinControls.UI.RadChartView chart_view;
    private Telerik.WinControls.UI.CommandBarLabel commandBarLabel4;
    private Telerik.WinControls.UI.CommandBarDropDownList commandBarDropDownList1;
    private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator1;
    private Telerik.WinControls.UI.CommandBarButton btn_export;
    private Telerik.WinControls.UI.CommandBarButton btn_layer;
  }
}
