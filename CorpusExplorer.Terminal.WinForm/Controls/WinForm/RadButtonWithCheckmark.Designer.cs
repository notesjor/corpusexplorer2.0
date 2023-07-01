namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm
{
  partial class RadButtonWithCheckmark
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RadButtonWithCheckmark));
      this.radButton1 = new Telerik.WinControls.UI.RadButton();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
      this.radButton1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // radButton1
      // 
      this.radButton1.Controls.Add(this.pictureBox1);
      resources.ApplyResources(this.radButton1, "radButton1");
      this.radButton1.Name = "radButton1";
      this.radButton1.TextWrap = true;
      this.radButton1.Click += new System.EventHandler(this.ButtonClick);
      // 
      // pictureBox1
      // 
      resources.ApplyResources(this.pictureBox1, "pictureBox1");
      this.pictureBox1.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.ok_button;
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.TabStop = false;
      this.pictureBox1.Click += new System.EventHandler(this.ButtonClick);
      // 
      // RadButtonWithCheckmark
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.Controls.Add(this.radButton1);
      this.Name = "RadButtonWithCheckmark";
      resources.ApplyResources(this, "$this");
      ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
      this.radButton1.ResumeLayout(false);
      this.radButton1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private Telerik.WinControls.UI.RadButton radButton1;
    private System.Windows.Forms.PictureBox pictureBox1;
  }
}
