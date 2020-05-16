namespace CorpusExplorer.Sdk.Extern.SocialMedia.Gui.Controls
{
  partial class ServiceInformationButton
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
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
      this.SuspendLayout();
      // 
      // pictureBox1
      // 
      this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
      this.pictureBox1.Location = new System.Drawing.Point(4, 4);
      this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(171, 79);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.pictureBox1.TabIndex = 0;
      this.pictureBox1.TabStop = false;
      this.pictureBox1.Click += new System.EventHandler(this.ControlClick);
      // 
      // radLabel1
      // 
      this.radLabel1.AutoSize = false;
      this.radLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radLabel1.Location = new System.Drawing.Point(4, 83);
      this.radLabel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.radLabel1.Name = "radLabel1";
      this.radLabel1.Size = new System.Drawing.Size(171, 144);
      this.radLabel1.TabIndex = 1;
      this.radLabel1.Text = "LABEL";
      this.radLabel1.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
      this.radLabel1.Click += new System.EventHandler(this.ControlClick);
      // 
      // ServiceInformationButton
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.Controls.Add(this.radLabel1);
      this.Controls.Add(this.pictureBox1);
      this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
      this.Name = "ServiceInformationButton";
      this.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.Size = new System.Drawing.Size(179, 231);
      this.Click += new System.EventHandler(this.ControlClick);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.PictureBox pictureBox1;
    private Telerik.WinControls.UI.RadLabel radLabel1;
  }
}
