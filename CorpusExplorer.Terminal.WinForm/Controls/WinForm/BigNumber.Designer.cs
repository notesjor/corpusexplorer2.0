namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm
{
  partial class BigNumber
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BigNumber));
      this.txt_label = new Telerik.WinControls.UI.RadLabel();
      this.txt_value = new Telerik.WinControls.UI.RadLabel();
      ((System.ComponentModel.ISupportInitialize)(this.txt_label)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_value)).BeginInit();
      this.SuspendLayout();
      // 
      // txt_label
      // 
      resources.ApplyResources(this.txt_label, "txt_label");
      this.txt_label.Name = "txt_label";
      // 
      // txt_value
      // 
      resources.ApplyResources(this.txt_value, "txt_value");
      this.txt_value.Name = "txt_value";
      // 
      // BigNumber
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.BackColor = System.Drawing.Color.White;
      this.Controls.Add(this.txt_value);
      this.Controls.Add(this.txt_label);
      resources.ApplyResources(this, "$this");
      this.Name = "BigNumber";
      ((System.ComponentModel.ISupportInitialize)(this.txt_label)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_value)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private Telerik.WinControls.UI.RadLabel txt_label;
    private Telerik.WinControls.UI.RadLabel txt_value;
  }
}
