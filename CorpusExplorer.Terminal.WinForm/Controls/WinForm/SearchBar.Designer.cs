namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm
{
  partial class SearchBar
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchBar));
      this.radButton1 = new Telerik.WinControls.UI.RadButton();
      this.radTextBox1 = new Telerik.WinControls.UI.RadTextBoxControl();
      ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // radButton1
      // 
      resources.ApplyResources(this.radButton1, "radButton1");
      this.radButton1.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.find;
      this.radButton1.Name = "radButton1";
      this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
      // 
      // radTextBox1
      // 
      resources.ApplyResources(this.radTextBox1, "radTextBox1");
      this.radTextBox1.Name = "radTextBox1";
      // 
      // SearchBar
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.Controls.Add(this.radTextBox1);
      this.Controls.Add(this.radButton1);
      this.Name = "SearchBar";
      resources.ApplyResources(this, "$this");
      ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private Telerik.WinControls.UI.RadButton radButton1;
    private Telerik.WinControls.UI.RadTextBoxControl radTextBox1;

  }
}
