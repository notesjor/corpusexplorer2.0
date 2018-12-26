namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm.SelectLayerValues
{
  partial class SelectLayerValuesControl
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectLayerValuesControl));
      this.radAutoCompleteBox1 = new Telerik.WinControls.UI.RadAutoCompleteBox();
      ((System.ComponentModel.ISupportInitialize)(this.radAutoCompleteBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // radAutoCompleteBox1
      // 
      resources.ApplyResources(this.radAutoCompleteBox1, "radAutoCompleteBox1");
      this.radAutoCompleteBox1.Name = "radAutoCompleteBox1";
      ((Telerik.WinControls.UI.TextBoxWrapPanel)(this.radAutoCompleteBox1.GetChildAt(0).GetChildAt(1))).Padding = ((System.Windows.Forms.Padding)(resources.GetObject("resource.Padding")));
      // 
      // SelectLayerValuesControl
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.Controls.Add(this.radAutoCompleteBox1);
      this.Name = "SelectLayerValuesControl";
      resources.ApplyResources(this, "$this");
      ((System.ComponentModel.ISupportInitialize)(this.radAutoCompleteBox1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private Telerik.WinControls.UI.RadAutoCompleteBox radAutoCompleteBox1;
  }
}
