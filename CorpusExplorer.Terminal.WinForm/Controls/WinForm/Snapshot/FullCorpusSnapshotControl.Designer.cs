using CorpusExplorer.Terminal.WinForm.Properties;
namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm.Snapshot
{
  partial class FullCorpusSnapshotControl
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FullCorpusSnapshotControl));
      this.radCheckedDropDownList1 = new Telerik.WinControls.UI.RadCheckedDropDownList();
      this.clearPanel1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.ClearPanel();
      this.clearPanel2 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.ClearPanel();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
      this.radGroupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radCheckedDropDownList1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel2)).BeginInit();
      this.clearPanel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // radGroupBox1
      // 
      this.radGroupBox1.Controls.Add(this.clearPanel2);
      this.radGroupBox1.Controls.Add(this.clearPanel1);
      this.radGroupBox1.HeaderImage = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.cabinet1;
      this.radGroupBox1.HeaderText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Snapshot_CorpusCondition;
      this.radGroupBox1.HeaderTextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.radGroupBox1.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Snapshot_CorpusCondition;
      this.radGroupBox1.Controls.SetChildIndex(this.clearPanel1, 0);
      this.radGroupBox1.Controls.SetChildIndex(this.clearPanel2, 0);
      // 
      // radCheckedDropDownList1
      // 
      resources.ApplyResources(this.radCheckedDropDownList1, "radCheckedDropDownList1");
      this.radCheckedDropDownList1.Name = "radCheckedDropDownList1";
      // 
      // clearPanel1
      // 
      resources.ApplyResources(this.clearPanel1, "clearPanel1");
      this.clearPanel1.Name = "clearPanel1";
      this.clearPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // clearPanel2
      // 
      this.clearPanel2.Controls.Add(this.radCheckedDropDownList1);
      resources.ApplyResources(this.clearPanel2, "clearPanel2");
      this.clearPanel2.Name = "clearPanel2";
      // 
      // FullCorpusSnapshotControl
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.Name = "FullCorpusSnapshotControl";
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
      this.radGroupBox1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radCheckedDropDownList1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel2)).EndInit();
      this.clearPanel2.ResumeLayout(false);
      this.clearPanel2.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private Telerik.WinControls.UI.RadCheckedDropDownList radCheckedDropDownList1;
    private ClearPanel clearPanel2;
    private ClearPanel clearPanel1;
  }
}
