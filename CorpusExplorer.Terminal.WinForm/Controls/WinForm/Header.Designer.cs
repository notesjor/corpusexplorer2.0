namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm
{
  partial class Header
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Header));
      this.lbl_description = new Telerik.WinControls.UI.RadLabel();
      this.lbl_head = new Telerik.WinControls.UI.RadLabel();
      ((System.ComponentModel.ISupportInitialize)(this.lbl_description)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.lbl_head)).BeginInit();
      this.SuspendLayout();
      // 
      // lbl_description
      // 
      resources.ApplyResources(this.lbl_description, "lbl_description");
      this.lbl_description.Name = "lbl_description";
      // 
      // lbl_head
      // 
      resources.ApplyResources(this.lbl_head, "lbl_head");
      this.lbl_head.Name = "lbl_head";
      // 
      // Header
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.Controls.Add(this.lbl_description);
      this.Controls.Add(this.lbl_head);
      this.Name = "Header";
      resources.ApplyResources(this, "$this");
      ((System.ComponentModel.ISupportInitialize)(this.lbl_description)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.lbl_head)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private Telerik.WinControls.UI.RadLabel lbl_description;
    private Telerik.WinControls.UI.RadLabel lbl_head;
  }
}
