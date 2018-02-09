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
      this.radCommandBar1.Dock = System.Windows.Forms.DockStyle.Top;
      this.radCommandBar1.Location = new System.Drawing.Point(0, 0);
      this.radCommandBar1.Name = "radCommandBar1";
      this.radCommandBar1.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement1});
      this.radCommandBar1.Size = new System.Drawing.Size(780, 44);
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
      // commandBarSeparator1
      // 
      this.commandBarSeparator1.DisplayName = "commandBarSeparator1";
      this.commandBarSeparator1.Name = "commandBarSeparator1";
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
      this.commandBarTextBox1.Text = "5";
      // 
      // radAutoCompleteBox1
      // 
      this.radAutoCompleteBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radAutoCompleteBox1.Location = new System.Drawing.Point(0, 0);
      this.radAutoCompleteBox1.Name = "radAutoCompleteBox1";
      this.radAutoCompleteBox1.NullText = "1. Hier Suchbegriff(e) eingeben...";
      this.radAutoCompleteBox1.Size = new System.Drawing.Size(356, 32);
      this.radAutoCompleteBox1.TabIndex = 1;
      // 
      // btn_go
      // 
      this.btn_go.Dock = System.Windows.Forms.DockStyle.Right;
      this.btn_go.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.button_circle_right;
      this.btn_go.Location = new System.Drawing.Point(356, 0);
      this.btn_go.Name = "btn_go";
      this.btn_go.Size = new System.Drawing.Size(32, 32);
      this.btn_go.TabIndex = 0;
      this.btn_go.Click += new System.EventHandler(this.btn_go_Click);
      // 
      // radSplitContainer1
      // 
      this.radSplitContainer1.Controls.Add(this.splitPanel1);
      this.radSplitContainer1.Controls.Add(this.splitPanel2);
      this.radSplitContainer1.Dock = System.Windows.Forms.DockStyle.Top;
      this.radSplitContainer1.Location = new System.Drawing.Point(0, 44);
      this.radSplitContainer1.Name = "radSplitContainer1";
      // 
      // 
      // 
      this.radSplitContainer1.RootElement.MinSize = new System.Drawing.Size(0, 0);
      this.radSplitContainer1.Size = new System.Drawing.Size(780, 32);
      this.radSplitContainer1.TabIndex = 2;
      this.radSplitContainer1.TabStop = false;
      this.radSplitContainer1.Text = "radSplitContainer1";
      // 
      // splitPanel1
      // 
      this.splitPanel1.Controls.Add(this.radAutoCompleteBox1);
      this.splitPanel1.Controls.Add(this.btn_go);
      this.splitPanel1.Location = new System.Drawing.Point(0, 0);
      this.splitPanel1.Name = "splitPanel1";
      // 
      // 
      // 
      this.splitPanel1.RootElement.MinSize = new System.Drawing.Size(0, 0);
      this.splitPanel1.Size = new System.Drawing.Size(388, 32);
      this.splitPanel1.TabIndex = 0;
      this.splitPanel1.TabStop = false;
      this.splitPanel1.Text = "splitPanel1";
      // 
      // splitPanel2
      // 
      this.splitPanel2.Controls.Add(this.drop_select);
      this.splitPanel2.Location = new System.Drawing.Point(392, 0);
      this.splitPanel2.Name = "splitPanel2";
      // 
      // 
      // 
      this.splitPanel2.RootElement.MinSize = new System.Drawing.Size(0, 0);
      this.splitPanel2.Size = new System.Drawing.Size(388, 32);
      this.splitPanel2.TabIndex = 1;
      this.splitPanel2.TabStop = false;
      this.splitPanel2.Text = "splitPanel2";
      // 
      // drop_select
      // 
      this.drop_select.Dock = System.Windows.Forms.DockStyle.Fill;
      this.drop_select.Location = new System.Drawing.Point(0, 0);
      this.drop_select.Name = "drop_select";
      this.drop_select.NullText = "2. Dann hier Werte auswählen...";
      this.drop_select.Size = new System.Drawing.Size(388, 32);
      this.drop_select.TabIndex = 0;
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
      this.chart_view.Dock = System.Windows.Forms.DockStyle.Fill;
      this.chart_view.Location = new System.Drawing.Point(0, 76);
      this.chart_view.Name = "chart_view";
      this.chart_view.ShowGrid = false;
      this.chart_view.Size = new System.Drawing.Size(780, 324);
      this.chart_view.TabIndex = 3;
      this.chart_view.Text = "radChartView1";
      // 
      // CooccurrenceDiversityOverTime
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
  }
}
