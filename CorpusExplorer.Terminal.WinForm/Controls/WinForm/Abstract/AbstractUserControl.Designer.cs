namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm.Abstract
{
  partial class AbstractUserControl
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
      this.telerikMetroTouchTheme1 = new Telerik.WinControls.Themes.TelerikMetroTouchTheme();
      this.SuspendLayout();
      // 
      // AbstractUserControl
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.BackColor = System.Drawing.Color.White;
      this.Font = new System.Drawing.Font("Segoe UI", 11F);
      this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
      this.Name = "AbstractUserControl";
      this.Size = new System.Drawing.Size(681, 388);
      this.ResumeLayout(false);

    }

    #endregion

    private Telerik.WinControls.Themes.TelerikMetroTouchTheme telerikMetroTouchTheme1;
  }
}
