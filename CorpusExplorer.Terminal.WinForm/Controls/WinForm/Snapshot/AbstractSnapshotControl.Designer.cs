namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm.Snapshot
{
  partial class AbstractSnapshotControl
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AbstractSnapshotControl));
      this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
      this.btn_remove = new System.Windows.Forms.PictureBox();
      this.telerikMetroTouchTheme1 = new Telerik.WinControls.Themes.TelerikMetroTouchTheme();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
      this.radGroupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.btn_remove)).BeginInit();
      this.SuspendLayout();
      // 
      // radGroupBox1
      // 
      this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox1.Controls.Add(this.btn_remove);
      resources.ApplyResources(this.radGroupBox1, "radGroupBox1");
      this.radGroupBox1.Name = "radGroupBox1";
      // 
      // btn_remove
      // 
      this.btn_remove.Cursor = System.Windows.Forms.Cursors.Hand;
      resources.ApplyResources(this.btn_remove, "btn_remove");
      this.btn_remove.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.remove_button;
      this.btn_remove.Name = "btn_remove";
      this.btn_remove.TabStop = false;
      this.btn_remove.Click += new System.EventHandler(this.btn_remove_Click);
      // 
      // AbstractSnapshotControl
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.BackColor = System.Drawing.Color.White;
      this.Controls.Add(this.radGroupBox1);
      resources.ApplyResources(this, "$this");
      this.Name = "AbstractSnapshotControl";
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
      this.radGroupBox1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.btn_remove)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    protected Telerik.WinControls.UI.RadGroupBox radGroupBox1;
    private System.Windows.Forms.PictureBox btn_remove;
    private Telerik.WinControls.Themes.TelerikMetroTouchTheme telerikMetroTouchTheme1;
  }
}
