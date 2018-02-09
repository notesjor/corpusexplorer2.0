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
      this.radButton1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radButton1.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
      this.radButton1.Location = new System.Drawing.Point(0, 0);
      this.radButton1.Name = "radButton1";
      this.radButton1.Size = new System.Drawing.Size(125, 100);
      this.radButton1.TabIndex = 0;
      this.radButton1.Text = "radButtonWithCheckmark";
      this.radButton1.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
      this.radButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.radButton1.TextWrap = true;
      this.radButton1.Click += new System.EventHandler(this.ButtonClick);
      // 
      // pictureBox1
      // 
      this.pictureBox1.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.ok_button;
      this.pictureBox1.Location = new System.Drawing.Point(96, 4);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(24, 24);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
      this.pictureBox1.TabIndex = 0;
      this.pictureBox1.TabStop = false;
      this.pictureBox1.Visible = false;
      this.pictureBox1.Click += new System.EventHandler(this.ButtonClick);
      // 
      // RadButtonWithCheckmark
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.radButton1);
      this.Name = "RadButtonWithCheckmark";
      this.Size = new System.Drawing.Size(125, 100);
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
