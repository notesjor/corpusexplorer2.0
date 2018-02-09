namespace CorpusExplorer.Terminal.WinForm.View.StyleMetrics
{
  partial class HyphenPivotGrid
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
      this.radPivotFieldList1 = new Telerik.WinControls.UI.RadPivotFieldList();
      this.radPivotGrid1 = new Telerik.WinControls.UI.RadPivotGrid();
      this.radSplitContainer1 = new Telerik.WinControls.UI.RadSplitContainer();
      this.splitPanel1 = new Telerik.WinControls.UI.SplitPanel();
      this.splitPanel2 = new Telerik.WinControls.UI.SplitPanel();
      ((System.ComponentModel.ISupportInitialize)(this.radPivotGrid1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).BeginInit();
      this.radSplitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).BeginInit();
      this.splitPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).BeginInit();
      this.splitPanel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // radPivotFieldList1
      // 
      this.radPivotFieldList1.AssociatedPivotGrid = this.radPivotGrid1;
      this.radPivotFieldList1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radPivotFieldList1.Location = new System.Drawing.Point(0, 0);
      this.radPivotFieldList1.MinimumSize = new System.Drawing.Size(225, 305);
      this.radPivotFieldList1.Name = "radPivotFieldList1";
      this.radPivotFieldList1.Size = new System.Drawing.Size(259, 305);
      this.radPivotFieldList1.TabIndex = 0;
      // 
      // radPivotGrid1
      // 
      this.radPivotGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radPivotGrid1.Location = new System.Drawing.Point(0, 0);
      this.radPivotGrid1.Name = "radPivotGrid1";
      this.radPivotGrid1.Size = new System.Drawing.Size(272, 230);
      this.radPivotGrid1.TabIndex = 1;
      this.radPivotGrid1.Text = "radPivotGrid1";
      // 
      // radSplitContainer1
      // 
      this.radSplitContainer1.Controls.Add(this.splitPanel1);
      this.radSplitContainer1.Controls.Add(this.splitPanel2);
      this.radSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radSplitContainer1.Location = new System.Drawing.Point(0, 0);
      this.radSplitContainer1.Name = "radSplitContainer1";
      // 
      // 
      // 
      this.radSplitContainer1.RootElement.MinSize = new System.Drawing.Size(25, 25);
      this.radSplitContainer1.Size = new System.Drawing.Size(535, 230);
      this.radSplitContainer1.TabIndex = 2;
      this.radSplitContainer1.TabStop = false;
      this.radSplitContainer1.Text = "radSplitContainer1";
      // 
      // splitPanel1
      // 
      this.splitPanel1.Controls.Add(this.radPivotGrid1);
      this.splitPanel1.Location = new System.Drawing.Point(0, 0);
      this.splitPanel1.Name = "splitPanel1";
      // 
      // 
      // 
      this.splitPanel1.RootElement.MinSize = new System.Drawing.Size(25, 25);
      this.splitPanel1.Size = new System.Drawing.Size(272, 230);
      this.splitPanel1.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(0.01224107F, 0F);
      this.splitPanel1.SizeInfo.SplitterCorrection = new System.Drawing.Size(6, 0);
      this.splitPanel1.TabIndex = 0;
      this.splitPanel1.TabStop = false;
      this.splitPanel1.Text = "splitPanel1";
      // 
      // splitPanel2
      // 
      this.splitPanel2.Controls.Add(this.radPivotFieldList1);
      this.splitPanel2.Location = new System.Drawing.Point(276, 0);
      this.splitPanel2.Name = "splitPanel2";
      // 
      // 
      // 
      this.splitPanel2.RootElement.MinSize = new System.Drawing.Size(25, 25);
      this.splitPanel2.Size = new System.Drawing.Size(259, 230);
      this.splitPanel2.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(-0.01224107F, 0F);
      this.splitPanel2.SizeInfo.SplitterCorrection = new System.Drawing.Size(-6, 0);
      this.splitPanel2.TabIndex = 1;
      this.splitPanel2.TabStop = false;
      this.splitPanel2.Text = "splitPanel2";
      // 
      // CorpusDistributionPivotGrid
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.radSplitContainer1);
      this.Name = "FrequencyPivotGrid";
      this.ShowView += new System.EventHandler(this.PivotGridVisualisation_ShowVisualisation);
      ((System.ComponentModel.ISupportInitialize)(this.radPivotGrid1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).EndInit();
      this.radSplitContainer1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).EndInit();
      this.splitPanel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).EndInit();
      this.splitPanel2.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private Telerik.WinControls.UI.RadPivotFieldList radPivotFieldList1;
    private Telerik.WinControls.UI.RadPivotGrid radPivotGrid1;
    private Telerik.WinControls.UI.RadSplitContainer radSplitContainer1;
    private Telerik.WinControls.UI.SplitPanel splitPanel1;
    private Telerik.WinControls.UI.SplitPanel splitPanel2;
  }
}
