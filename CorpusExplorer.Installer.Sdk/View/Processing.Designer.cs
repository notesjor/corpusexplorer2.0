using CorpusExplorer.Installer.Sdk.Properties;
namespace CorpusExplorer.Installer.Sdk.View
{
  internal sealed partial class Processing
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (this.components != null))
      {
        this.components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Processing));
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.progressBar1 = new System.Windows.Forms.ProgressBar();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.label3 = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Segoe UI Light", 18F);
      this.label1.Location = new System.Drawing.Point(92, 29);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(167, 32);
      this.label1.TabIndex = 1;
      this.label1.Text = "CorpusExplorer";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.label2.Location = new System.Drawing.Point(98, 60);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(199, 15);
      this.label2.TabIndex = 2;
      this.label2.Text = "Korpuslinguistik war nie so einfach...";
      // 
      // pictureBox1
      // 
      this.pictureBox1.Image = global::CorpusExplorer.Installer.Sdk.Properties.Resources.shipment;
      this.pictureBox1.Location = new System.Drawing.Point(21, 24);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(64, 64);
      this.pictureBox1.TabIndex = 0;
      this.pictureBox1.TabStop = false;
      // 
      // progressBar1
      // 
      this.progressBar1.Location = new System.Drawing.Point(21, 95);
      this.progressBar1.Maximum = 1000;
      this.progressBar1.Name = "progressBar1";
      this.progressBar1.Size = new System.Drawing.Size(572, 23);
      this.progressBar1.TabIndex = 3;
      // 
      // timer1
      // 
      this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
      // 
      // label3
      // 
      this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.label3.Location = new System.Drawing.Point(18, 121);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(575, 24);
      this.label3.TabIndex = 4;
      this.label3.Text = "Überprüfe ob Programm- und/oder Korpusaktualisierungen verfügbar sind...";
      this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // Processing
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.BackColor = System.Drawing.Color.White;
      this.ClientSize = new System.Drawing.Size(619, 154);
      this.ControlBox = false;
      this.Controls.Add(this.label3);
      this.Controls.Add(this.progressBar1);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.pictureBox1);
      this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "Processing";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "CorpusExplorer - Installation";
      this.TopMost = true;
      this.Load += new System.EventHandler(this.Processing_Load);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ProgressBar progressBar1;
    private System.Windows.Forms.Timer timer1;
    private System.Windows.Forms.Label label3;
  }
}