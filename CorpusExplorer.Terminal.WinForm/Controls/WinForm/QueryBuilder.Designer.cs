namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm
{
  partial class QueryBuilder
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QueryBuilder));
      this.radDataFilter1 = new Telerik.WinControls.UI.RadDataFilter();
      ((System.ComponentModel.ISupportInitialize)(this.radDataFilter1)).BeginInit();
      this.SuspendLayout();
      // 
      // radDataFilter1
      // 
      resources.ApplyResources(this.radDataFilter1, "radDataFilter1");
      this.radDataFilter1.ItemHeight = 40;
      this.radDataFilter1.Name = "radDataFilter1";
      // 
      // QueryBuilder
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.Controls.Add(this.radDataFilter1);
      this.Name = "QueryBuilder";
      ((System.ComponentModel.ISupportInitialize)(this.radDataFilter1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private Telerik.WinControls.UI.RadDataFilter radDataFilter1;
  }
}
