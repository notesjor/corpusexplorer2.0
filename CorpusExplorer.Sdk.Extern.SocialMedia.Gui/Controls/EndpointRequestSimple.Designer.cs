namespace CorpusExplorer.Sdk.Extern.SocialMedia.Gui.Controls
{
  partial class EndpointRequestSimple
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EndpointRequestSimple));
      this.ihdPanel1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.IHDPanel();
      this.radTextBox1 = new Telerik.WinControls.UI.RadTextBox();
      ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // ihdPanel1
      // 
      this.ihdPanel1.BackColor = System.Drawing.Color.White;
      this.ihdPanel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.ihdPanel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ihdPanel1.IHDDeescribtion = resources.GetString("ihdPanel1.IHDDeescribtion");
      this.ihdPanel1.IHDHeader = "Eine Abfrage = Eine Zeile - so einfach...";
      this.ihdPanel1.IHDImage = global::CorpusExplorer.Sdk.Extern.SocialMedia.Gui.Properties.Resources.work_browse_128px;
      this.ihdPanel1.Location = new System.Drawing.Point(0, 0);
      this.ihdPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.ihdPanel1.Name = "ihdPanel1";
      this.ihdPanel1.Size = new System.Drawing.Size(830, 73);
      this.ihdPanel1.TabIndex = 2;
      // 
      // radTextBox1
      // 
      this.radTextBox1.AcceptsReturn = true;
      this.radTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radTextBox1.Location = new System.Drawing.Point(0, 73);
      this.radTextBox1.Multiline = true;
      this.radTextBox1.Name = "radTextBox1";
      this.radTextBox1.NullText = "Geben Sie hier ihre Abfragen ein...";
      // 
      // 
      // 
      this.radTextBox1.RootElement.StretchVertically = true;
      this.radTextBox1.Size = new System.Drawing.Size(830, 383);
      this.radTextBox1.TabIndex = 3;
      // 
      // EndpointRequestSimple
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.radTextBox1);
      this.Controls.Add(this.ihdPanel1);
      this.Name = "EndpointRequestSimple";
      this.Controls.SetChildIndex(this.ihdPanel1, 0);
      this.Controls.SetChildIndex(this.radTextBox1, 0);
      ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private CorpusExplorer.Terminal.WinForm.Controls.WinForm.IHDPanel ihdPanel1;
    private Telerik.WinControls.UI.RadTextBox radTextBox1;
  }
}
