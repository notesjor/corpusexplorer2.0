namespace CorpusExplorer.Terminal.WinForm.View.StyleMetrics
{
  partial class CompareBasedOnBurrowsDelta
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompareBasedOnBurrowsDelta));
      this.radCommandBar1 = new Telerik.WinControls.UI.RadCommandBar();
      this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
      this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
      this.commandBarLabel1 = new Telerik.WinControls.UI.CommandBarLabel();
      this.combo_groupA = new Telerik.WinControls.UI.CommandBarDropDownList();
      this.commandBarLabel2 = new Telerik.WinControls.UI.CommandBarLabel();
      this.combo_groupB = new Telerik.WinControls.UI.CommandBarDropDownList();
      this.btn_start = new Telerik.WinControls.UI.CommandBarButton();
      this.commandBarSeparator1 = new Telerik.WinControls.UI.CommandBarSeparator();
      this.btn_export = new Telerik.WinControls.UI.CommandBarButton();
      this.radPivotFieldList1 = new Telerik.WinControls.UI.RadPivotFieldList();
      this.radPivotGrid1 = new Telerik.WinControls.UI.RadPivotGrid();
      this.radSplitContainer1 = new Telerik.WinControls.UI.RadSplitContainer();
      this.splitPanel1 = new Telerik.WinControls.UI.SplitPanel();
      this.splitPanel2 = new Telerik.WinControls.UI.SplitPanel();
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radPivotGrid1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).BeginInit();
      this.radSplitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).BeginInit();
      this.splitPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).BeginInit();
      this.splitPanel2.SuspendLayout();
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
            this.commandBarLabel1,
            this.combo_groupA,
            this.commandBarLabel2,
            this.combo_groupB,
            this.btn_start,
            this.commandBarSeparator1,
            this.btn_export});
      this.commandBarStripElement1.Name = "commandBarStripElement1";
      // 
      // commandBarLabel1
      // 
      resources.ApplyResources(this.commandBarLabel1, "commandBarLabel1");
      this.commandBarLabel1.Name = "commandBarLabel1";
      this.commandBarLabel1.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.GruppeA;
      // 
      // combo_groupA
      // 
      resources.ApplyResources(this.combo_groupA, "combo_groupA");
      this.combo_groupA.DropDownAnimationEnabled = true;
      this.combo_groupA.MaxDropDownItems = 0;
      this.combo_groupA.MinSize = new System.Drawing.Size(180, 22);
      this.combo_groupA.Name = "combo_groupA";
      this.combo_groupA.NullText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.BitteAuswählen;
      // 
      // commandBarLabel2
      // 
      resources.ApplyResources(this.commandBarLabel2, "commandBarLabel2");
      this.commandBarLabel2.Name = "commandBarLabel2";
      this.commandBarLabel2.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.GruppeB;
      // 
      // combo_groupB
      // 
      resources.ApplyResources(this.combo_groupB, "combo_groupB");
      this.combo_groupB.DropDownAnimationEnabled = true;
      this.combo_groupB.MaxDropDownItems = 0;
      this.combo_groupB.MinSize = new System.Drawing.Size(180, 22);
      this.combo_groupB.Name = "combo_groupB";
      this.combo_groupB.NullText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.BitteAuswählen;
      // 
      // btn_start
      // 
      resources.ApplyResources(this.btn_start, "btn_start");
      this.btn_start.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.button_circle_right;
      this.btn_start.AutoToolTip = true;
      this.btn_start.Name = "btn_start";
      this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
      // 
      // commandBarSeparator1
      // 
      resources.ApplyResources(this.commandBarSeparator1, "commandBarSeparator1");
      this.commandBarSeparator1.Name = "commandBarSeparator1";
      this.commandBarSeparator1.VisibleInOverflowMenu = false;
      // 
      // btn_export
      // 
      resources.ApplyResources(this.btn_export, "btn_export");
      this.btn_export.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.export_text;
      this.btn_export.AutoToolTip = true;
      this.btn_export.Name = "btn_export";
      this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
      // 
      // radPivotFieldList1
      // 
      this.radPivotFieldList1.AssociatedPivotGrid = this.radPivotGrid1;
      resources.ApplyResources(this.radPivotFieldList1, "radPivotFieldList1");
      this.radPivotFieldList1.Name = "radPivotFieldList1";
      // 
      // radPivotGrid1
      // 
      resources.ApplyResources(this.radPivotGrid1, "radPivotGrid1");
      this.radPivotGrid1.Name = "radPivotGrid1";
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
      this.radSplitContainer1.RootElement.MinSize = new System.Drawing.Size(25, 25);
      this.radSplitContainer1.TabStop = false;
      // 
      // splitPanel1
      // 
      this.splitPanel1.Controls.Add(this.radPivotGrid1);
      resources.ApplyResources(this.splitPanel1, "splitPanel1");
      this.splitPanel1.Name = "splitPanel1";
      // 
      // 
      // 
      this.splitPanel1.RootElement.MinSize = new System.Drawing.Size(25, 25);
      this.splitPanel1.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(0.1237113F, 0F);
      this.splitPanel1.SizeInfo.SplitterCorrection = new System.Drawing.Size(96, 0);
      this.splitPanel1.TabStop = false;
      // 
      // splitPanel2
      // 
      this.splitPanel2.Controls.Add(this.radPivotFieldList1);
      resources.ApplyResources(this.splitPanel2, "splitPanel2");
      this.splitPanel2.Name = "splitPanel2";
      // 
      // 
      // 
      this.splitPanel2.RootElement.MinSize = new System.Drawing.Size(25, 25);
      this.splitPanel2.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(-0.1237113F, 0F);
      this.splitPanel2.SizeInfo.SplitterCorrection = new System.Drawing.Size(-96, 0);
      this.splitPanel2.TabStop = false;
      // 
      // CompareBasedOnBurrowsDelta
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.Controls.Add(this.radSplitContainer1);
      this.Controls.Add(this.radCommandBar1);
      this.Name = "CompareBasedOnBurrowsDelta";
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radPivotGrid1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).EndInit();
      this.radSplitContainer1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).EndInit();
      this.splitPanel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).EndInit();
      this.splitPanel2.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private Telerik.WinControls.UI.RadCommandBar radCommandBar1;
    private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
    private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement1;
    private Telerik.WinControls.UI.CommandBarLabel commandBarLabel1;
    private Telerik.WinControls.UI.CommandBarDropDownList combo_groupA;
    private Telerik.WinControls.UI.CommandBarLabel commandBarLabel2;
    private Telerik.WinControls.UI.CommandBarDropDownList combo_groupB;
    private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator1;
    private Telerik.WinControls.UI.CommandBarButton btn_export;
    private Telerik.WinControls.UI.RadPivotFieldList radPivotFieldList1;
    private Telerik.WinControls.UI.RadPivotGrid radPivotGrid1;
    private Telerik.WinControls.UI.RadSplitContainer radSplitContainer1;
    private Telerik.WinControls.UI.SplitPanel splitPanel1;
    private Telerik.WinControls.UI.SplitPanel splitPanel2;
    private Telerik.WinControls.UI.CommandBarButton btn_start;
  }
}
