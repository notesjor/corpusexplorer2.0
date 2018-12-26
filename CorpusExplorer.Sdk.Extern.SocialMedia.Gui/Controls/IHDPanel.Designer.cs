namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm
{
  partial class IHDPanel
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
      if (disposing && (this.components != null))
      {
        this.components.Dispose();
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
      this.panel1 = new System.Windows.Forms.Panel();
      this.panel2 = new System.Windows.Forms.Panel();
      this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
      this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
      this.SuspendLayout();
      // 
      // pictureBox1
      // 
      this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pictureBox1.Location = new System.Drawing.Point(3, 3);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(48, 58);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.pictureBox1.TabIndex = 0;
      this.pictureBox1.TabStop = false;
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.pictureBox1);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Padding = new System.Windows.Forms.Padding(3);
      this.panel1.Size = new System.Drawing.Size(54, 64);
      this.panel1.TabIndex = 2;
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.radLabel2);
      this.panel2.Controls.Add(this.radLabel1);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel2.Location = new System.Drawing.Point(54, 0);
      this.panel2.Name = "panel2";
      this.panel2.Padding = new System.Windows.Forms.Padding(3);
      this.panel2.Size = new System.Drawing.Size(316, 64);
      this.panel2.TabIndex = 3;
      // 
      // radLabel2
      // 
      this.radLabel2.AutoSize = false;
      this.radLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.radLabel2.Location = new System.Drawing.Point(3, 31);
      this.radLabel2.Name = "radLabel2";
      this.radLabel2.Size = new System.Drawing.Size(310, 30);
      this.radLabel2.TabIndex = 1;
      this.radLabel2.Text = "{IHDDESCRIPTION} ";
      this.radLabel2.UseMnemonic = false;
      // 
      // radLabel1
      // 
      this.radLabel1.AutoSize = false;
      this.radLabel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.radLabel1.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.radLabel1.Location = new System.Drawing.Point(3, 3);
      this.radLabel1.Margin = new System.Windows.Forms.Padding(0);
      this.radLabel1.Name = "radLabel1";
      this.radLabel1.Size = new System.Drawing.Size(310, 28);
      this.radLabel1.TabIndex = 0;
      this.radLabel1.Text = "{IHDHEADER}";
      this.radLabel1.UseMnemonic = false;
      // 
      // IHDPanel
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.BackColor = System.Drawing.Color.White;
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.panel1);
      this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.Name = "IHDPanel";
      this.Size = new System.Drawing.Size(370, 64);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.panel1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Panel panel2;
    private Telerik.WinControls.UI.RadLabel radLabel2;
    private Telerik.WinControls.UI.RadLabel radLabel1;
  }
}
