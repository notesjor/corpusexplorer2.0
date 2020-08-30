namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm
{
  partial class WarnBox
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
      this.error_lbl_message = new Telerik.WinControls.UI.RadLabel();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      ((System.ComponentModel.ISupportInitialize)(this.error_lbl_message)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // error_lbl_message
      // 
      this.error_lbl_message.AutoSize = false;
      this.error_lbl_message.Dock = System.Windows.Forms.DockStyle.Fill;
      this.error_lbl_message.Location = new System.Drawing.Point(32, 0);
      this.error_lbl_message.Name = "error_lbl_message";
      this.error_lbl_message.Size = new System.Drawing.Size(468, 32);
      this.error_lbl_message.TabIndex = 1;
      // 
      // pictureBox1
      // 
      this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
      this.pictureBox1.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.warning;
      this.pictureBox1.Location = new System.Drawing.Point(0, 0);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(32, 32);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
      this.pictureBox1.TabIndex = 0;
      this.pictureBox1.TabStop = false;
      // 
      // WarnBox
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.error_lbl_message);
      this.Controls.Add(this.pictureBox1);
      this.Name = "WarnBox";
      this.Size = new System.Drawing.Size(500, 32);
      ((System.ComponentModel.ISupportInitialize)(this.error_lbl_message)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);

    }

        #endregion
        private Telerik.WinControls.UI.RadLabel error_lbl_message;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
