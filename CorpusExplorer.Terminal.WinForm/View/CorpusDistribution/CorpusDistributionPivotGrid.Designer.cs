namespace CorpusExplorer.Terminal.WinForm.View.CorpusDistribution
{
  partial class CorpusDistributionPivotGrid
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CorpusDistributionPivotGrid));
      this.radPivotFieldList1 = new Telerik.WinControls.UI.RadPivotFieldList();
      this.radPivotGrid1 = new Telerik.WinControls.UI.RadPivotGrid();
      this.radSplitContainer1 = new Telerik.WinControls.UI.RadSplitContainer();
      this.splitPanel1 = new Telerik.WinControls.UI.SplitPanel();
      this.splitPanel2 = new Telerik.WinControls.UI.SplitPanel();
      this.radCommandBar1 = new Telerik.WinControls.UI.RadCommandBar();
      this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
      this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
      this.btn_load = new Telerik.WinControls.UI.CommandBarButton();
      this.btn_save = new Telerik.WinControls.UI.CommandBarButton();
      this.btn_export = new Telerik.WinControls.UI.CommandBarButton();
      ((System.ComponentModel.ISupportInitialize)(this.radPivotGrid1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).BeginInit();
      this.radSplitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).BeginInit();
      this.splitPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).BeginInit();
      this.splitPanel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
      this.SuspendLayout();
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
      this.splitPanel1.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(0.01224107F, 0F);
      this.splitPanel1.SizeInfo.SplitterCorrection = new System.Drawing.Size(6, 0);
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
      this.splitPanel2.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(-0.01224107F, 0F);
      this.splitPanel2.SizeInfo.SplitterCorrection = new System.Drawing.Size(-6, 0);
      this.splitPanel2.TabStop = false;
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
            this.btn_load,
            this.btn_save,
            this.btn_export});
      this.commandBarStripElement1.Name = "commandBarStripElement1";
      // 
      // btn_load
      // 
      resources.ApplyResources(this.btn_load, "btn_load");
      this.btn_load.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.folder_open;
      this.btn_load.AutoToolTip = true;
      this.btn_load.Name = "btn_load";
      this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
      // 
      // btn_save
      // 
      resources.ApplyResources(this.btn_save, "btn_save");
      this.btn_save.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.save;
      this.btn_save.AutoToolTip = true;
      this.btn_save.Name = "btn_save";
      this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
      // 
      // btn_export
      // 
      resources.ApplyResources(this.btn_export, "btn_export");
      this.btn_export.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.export_spreadsheet;
      this.btn_export.AutoToolTip = true;
      this.btn_export.Name = "btn_export";
      this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
      // 
      // CorpusDistributionPivotGrid
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.Controls.Add(this.radSplitContainer1);
      this.Controls.Add(this.radCommandBar1);
      this.Name = "CorpusDistributionPivotGrid";
      this.ShowView += new System.EventHandler(this.PivotGridVisualisation_ShowVisualisation);
      ((System.ComponentModel.ISupportInitialize)(this.radPivotGrid1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).EndInit();
      this.radSplitContainer1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).EndInit();
      this.splitPanel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).EndInit();
      this.splitPanel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Telerik.WinControls.UI.RadPivotFieldList radPivotFieldList1;
    private Telerik.WinControls.UI.RadPivotGrid radPivotGrid1;
    private Telerik.WinControls.UI.RadSplitContainer radSplitContainer1;
    private Telerik.WinControls.UI.SplitPanel splitPanel1;
    private Telerik.WinControls.UI.SplitPanel splitPanel2;
    private Telerik.WinControls.UI.RadCommandBar radCommandBar1;
    private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
    private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement1;
    private Telerik.WinControls.UI.CommandBarButton btn_load;
    private Telerik.WinControls.UI.CommandBarButton btn_save;
    private Telerik.WinControls.UI.CommandBarButton btn_export;
  }
}
