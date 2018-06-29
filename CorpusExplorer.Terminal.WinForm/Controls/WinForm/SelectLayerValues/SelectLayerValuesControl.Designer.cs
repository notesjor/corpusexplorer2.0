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
      this.radAutoCompleteBox1 = new Telerik.WinControls.UI.RadAutoCompleteBox();
      ((System.ComponentModel.ISupportInitialize)(this.radAutoCompleteBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // radAutoCompleteBox1
      // 
      this.radAutoCompleteBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radAutoCompleteBox1.Location = new System.Drawing.Point(0, 0);
      this.radAutoCompleteBox1.Name = "radAutoCompleteBox1";
      this.radAutoCompleteBox1.NullText = "Suchbegriff hier eingeben...";
      this.radAutoCompleteBox1.Size = new System.Drawing.Size(250, 36);
      this.radAutoCompleteBox1.TabIndex = 0;
      ((Telerik.WinControls.UI.TextBoxWrapPanel)(this.radAutoCompleteBox1.GetChildAt(0).GetChildAt(1))).Padding = new System.Windows.Forms.Padding(2, 7, 2, 2);
      // 
      // SelectLayerValuesControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.radAutoCompleteBox1);
      this.Name = "SelectLayerValuesControl";
      this.Size = new System.Drawing.Size(250, 36);
      ((System.ComponentModel.ISupportInitialize)(this.radAutoCompleteBox1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private Telerik.WinControls.UI.RadAutoCompleteBox radAutoCompleteBox1;
  }
}
