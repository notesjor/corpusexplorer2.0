namespace CorpusExplorer.Terminal.WinForm.View.Ngram
{
  partial class NGramOverTime
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
      Telerik.WinControls.UI.CartesianArea cartesianArea1 = new Telerik.WinControls.UI.CartesianArea();
      Telerik.WinControls.UI.CategoricalAxis categoricalAxis1 = new Telerik.WinControls.UI.CategoricalAxis();
      Telerik.WinControls.UI.LinearAxis linearAxis1 = new Telerik.WinControls.UI.LinearAxis();
      this.radCommandBar1 = new Telerik.WinControls.UI.RadCommandBar();
      this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
      this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
      this.commandBarLabel1 = new Telerik.WinControls.UI.CommandBarLabel();
      this.commandBarDropDownList1 = new Telerik.WinControls.UI.CommandBarDropDownList();
      this.clearPanel1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.ClearPanel();
      this.radAutoCompleteBox1 = new Telerik.WinControls.UI.RadAutoCompleteBox();
      this.btn_go = new Telerik.WinControls.UI.RadButton();
      this.chart_view = new Telerik.WinControls.UI.RadChartView();
      this.commandBarSeparator1 = new Telerik.WinControls.UI.CommandBarSeparator();
      this.commandBarLabel2 = new Telerik.WinControls.UI.CommandBarLabel();
      this.commandBarTextBox1 = new Telerik.WinControls.UI.CommandBarTextBox();
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel1)).BeginInit();
      this.clearPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radAutoCompleteBox1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_go)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.chart_view)).BeginInit();
      this.SuspendLayout();
      // 
      // radCommandBar1
      // 
      this.radCommandBar1.Dock = System.Windows.Forms.DockStyle.Top;
      this.radCommandBar1.Location = new System.Drawing.Point(0, 0);
      this.radCommandBar1.Name = "radCommandBar1";
      this.radCommandBar1.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement1});
      this.radCommandBar1.Size = new System.Drawing.Size(780, 69);
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
            this.commandBarLabel1,
            this.commandBarDropDownList1,
            this.commandBarSeparator1,
            this.commandBarLabel2,
            this.commandBarTextBox1});
      this.commandBarStripElement1.Name = "commandBarStripElement1";
      // 
      // commandBarLabel1
      // 
      this.commandBarLabel1.DisplayName = "commandBarLabel1";
      this.commandBarLabel1.Name = "commandBarLabel1";
      this.commandBarLabel1.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.DatumsID;
      // 
      // commandBarDropDownList1
      // 
      this.commandBarDropDownList1.DisplayName = "commandBarDropDownList1";
      this.commandBarDropDownList1.DropDownAnimationEnabled = true;
      this.commandBarDropDownList1.MaxDropDownItems = 0;
      this.commandBarDropDownList1.MinSize = new System.Drawing.Size(200, 22);
      this.commandBarDropDownList1.Name = "commandBarDropDownList1";
      this.commandBarDropDownList1.NullText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.BitteAuswählen;
      this.commandBarDropDownList1.Text = "";
      // 
      // clearPanel1
      // 
      this.clearPanel1.Controls.Add(this.radAutoCompleteBox1);
      this.clearPanel1.Controls.Add(this.btn_go);
      this.clearPanel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.clearPanel1.Location = new System.Drawing.Point(0, 69);
      this.clearPanel1.Name = "clearPanel1";
      this.clearPanel1.Size = new System.Drawing.Size(780, 32);
      this.clearPanel1.TabIndex = 1;
      // 
      // radAutoCompleteBox1
      // 
      this.radAutoCompleteBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radAutoCompleteBox1.Location = new System.Drawing.Point(0, 0);
      this.radAutoCompleteBox1.Name = "radAutoCompleteBox1";
      this.radAutoCompleteBox1.Size = new System.Drawing.Size(748, 32);
      this.radAutoCompleteBox1.TabIndex = 1;
      // 
      // btn_go
      // 
      this.btn_go.Dock = System.Windows.Forms.DockStyle.Right;
      this.btn_go.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.button_circle_right;
      this.btn_go.Location = new System.Drawing.Point(748, 0);
      this.btn_go.Name = "btn_go";
      this.btn_go.Size = new System.Drawing.Size(32, 32);
      this.btn_go.TabIndex = 0;
      this.btn_go.Click += new System.EventHandler(this.btn_go_Click);
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
      this.chart_view.Location = new System.Drawing.Point(0, 101);
      this.chart_view.Name = "chart_view";
      this.chart_view.ShowGrid = false;
      this.chart_view.ShowLegend = true;
      this.chart_view.ShowPanZoom = true;
      this.chart_view.ShowToolTip = true;
      this.chart_view.ShowTrackBall = true;
      this.chart_view.Size = new System.Drawing.Size(780, 299);
      this.chart_view.TabIndex = 0;
      this.chart_view.Text = "radChartView1";
      // 
      // commandBarSeparator1
      // 
      this.commandBarSeparator1.DisplayName = "commandBarSeparator1";
      this.commandBarSeparator1.Name = "commandBarSeparator1";
      this.commandBarSeparator1.Text = "";
      this.commandBarSeparator1.VisibleInOverflowMenu = false;
      // 
      // commandBarLabel2
      // 
      this.commandBarLabel2.DisplayName = "commandBarLabel2";
      this.commandBarLabel2.Name = "commandBarLabel2";
      this.commandBarLabel2.Text = "Cluster:";
      // 
      // commandBarTextBox1
      // 
      this.commandBarTextBox1.DisplayName = "commandBarTextBox1";
      this.commandBarTextBox1.Name = "commandBarTextBox1";
      this.commandBarTextBox1.Text = "25";
      // 
      // FrequencyOverTimeView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.chart_view);
      this.Controls.Add(this.clearPanel1);
      this.Controls.Add(this.radCommandBar1);
      this.Name = "FrequencyOverTimeView";
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel1)).EndInit();
      this.clearPanel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radAutoCompleteBox1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_go)).EndInit();
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
    private Controls.WinForm.ClearPanel clearPanel1;
    private Telerik.WinControls.UI.RadButton btn_go;
    private Telerik.WinControls.UI.RadChartView chart_view;
    private Telerik.WinControls.UI.RadAutoCompleteBox radAutoCompleteBox1;
    private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator1;
    private Telerik.WinControls.UI.CommandBarLabel commandBarLabel2;
    private Telerik.WinControls.UI.CommandBarTextBox commandBarTextBox1;
  }
}
