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
      this.radDataFilter1 = new Telerik.WinControls.UI.RadDataFilter();
      ((System.ComponentModel.ISupportInitialize)(this.radDataFilter1)).BeginInit();
      this.SuspendLayout();
      // 
      // radDataFilter1
      // 
      this.radDataFilter1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radDataFilter1.ItemHeight = 40;
      this.radDataFilter1.Location = new System.Drawing.Point(0, 0);
      this.radDataFilter1.Name = "radDataFilter1";
      this.radDataFilter1.Size = new System.Drawing.Size(681, 388);
      this.radDataFilter1.TabIndex = 0;
      this.radDataFilter1.Text = "radDataFilter1";
      // 
      // QueryBuilder
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.radDataFilter1);
      this.Name = "QueryBuilder";
      ((System.ComponentModel.ISupportInitialize)(this.radDataFilter1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private Telerik.WinControls.UI.RadDataFilter radDataFilter1;
  }
}
