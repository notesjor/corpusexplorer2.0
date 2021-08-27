
namespace CorpusExplorer.Terminal.Automate.Controls
{
  partial class Info
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
      this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
      this.SuspendLayout();
      // 
      // radPanel1
      // 
      this.radPanel1.BackgroundImage = global::CorpusExplorer.Terminal.Automate.Properties.Resources.info;
      this.radPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.radPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radPanel1.Location = new System.Drawing.Point(0, 0);
      this.radPanel1.Name = "radPanel1";
      this.radPanel1.Size = new System.Drawing.Size(32, 32);
      this.radPanel1.TabIndex = 0;
      // 
      // Info
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.Controls.Add(this.radPanel1);
      this.Name = "Info";
      this.Size = new System.Drawing.Size(32, 32);
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private Telerik.WinControls.UI.RadPanel radPanel1;
  }
}
