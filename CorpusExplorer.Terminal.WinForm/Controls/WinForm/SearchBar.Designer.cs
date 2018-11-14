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
      this.radButton1 = new Telerik.WinControls.UI.RadButton();
      this.radTextBox1 = new Telerik.WinControls.UI.RadTextBoxControl();
      ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // radButton1
      // 
      this.radButton1.Dock = System.Windows.Forms.DockStyle.Right;
      this.radButton1.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.find;
      this.radButton1.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
      this.radButton1.Location = new System.Drawing.Point(212, 0);
      this.radButton1.Name = "radButton1";
      this.radButton1.Size = new System.Drawing.Size(40, 40);
      this.radButton1.TabIndex = 0;
      this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
      // 
      // radTextBox1
      // 
      this.radTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radTextBox1.Location = new System.Drawing.Point(0, 0);
      this.radTextBox1.Name = "radTextBox1";
      this.radTextBox1.NullText = "{NullText}";
      this.radTextBox1.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
      this.radTextBox1.Size = new System.Drawing.Size(212, 40);
      this.radTextBox1.TabIndex = 1;
      // 
      // SearchBar
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.Controls.Add(this.radTextBox1);
      this.Controls.Add(this.radButton1);
      this.Name = "SearchBar";
      this.Size = new System.Drawing.Size(252, 40);
      ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private Telerik.WinControls.UI.RadButton radButton1;
    private Telerik.WinControls.UI.RadTextBoxControl radTextBox1;

  }
}
