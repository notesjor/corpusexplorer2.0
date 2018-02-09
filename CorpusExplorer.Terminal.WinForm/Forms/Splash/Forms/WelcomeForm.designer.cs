using CorpusExplorer.Terminal.WinForm.Properties;
namespace CorpusExplorer.Terminal.WinForm.Forms.Splash.Forms
{
  partial class WelcomeForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WelcomeForm));
      this.lbl_version = new Telerik.WinControls.UI.RadLabel();
      this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
      this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
      this.radWaitingBar1 = new Telerik.WinControls.UI.RadWaitingBar();
      ((System.ComponentModel.ISupportInitialize)(this.lbl_version)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radWaitingBar1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // lbl_version
      // 
      this.lbl_version.Font = new System.Drawing.Font("Segoe UI Light", 11F);
      this.lbl_version.Location = new System.Drawing.Point(308, 8);
      this.lbl_version.Name = "lbl_version";
      this.lbl_version.Size = new System.Drawing.Size(74, 23);
      this.lbl_version.TabIndex = 11;
      this.lbl_version.Text = "{VERSION}";
      // 
      // radLabel3
      // 
      this.radLabel3.Font = new System.Drawing.Font("Segoe UI Light", 11F);
      this.radLabel3.Location = new System.Drawing.Point(146, 35);
      this.radLabel3.Name = "radLabel3";
      this.radLabel3.Size = new System.Drawing.Size(422, 61);
      this.radLabel3.TabIndex = 10;
      this.radLabel3.Text = resources.GetString("radLabel3.Text");
      // 
      // radLabel2
      // 
      this.radLabel2.Font = new System.Drawing.Font("Segoe UI Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.radLabel2.Location = new System.Drawing.Point(142, 0);
      this.radLabel2.Name = "radLabel2";
      this.radLabel2.Size = new System.Drawing.Size(169, 37);
      this.radLabel2.TabIndex = 9;
      this.radLabel2.Text = "CorpusExplorer";
      // 
      // pictureBox1
      // 
      this.pictureBox1.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.CorpusExplorer;
      this.pictureBox1.Location = new System.Drawing.Point(8, 0);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(128, 128);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.pictureBox1.TabIndex = 8;
      this.pictureBox1.TabStop = false;
      // 
      // radLabel1
      // 
      this.radLabel1.AutoSize = false;
      this.radLabel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.radLabel1.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.radLabel1.Location = new System.Drawing.Point(5, 150);
      this.radLabel1.Name = "radLabel1";
      this.radLabel1.Size = new System.Drawing.Size(568, 25);
      this.radLabel1.TabIndex = 7;
      this.radLabel1.Text = "Der CorpusExplorer wird geladen, bitte warten...";
      this.radLabel1.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
      this.radLabel1.ThemeName = "TelerikMetro";
      // 
      // radWaitingBar1
      // 
      this.radWaitingBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.radWaitingBar1.Location = new System.Drawing.Point(5, 175);
      this.radWaitingBar1.Name = "radWaitingBar1";
      this.radWaitingBar1.Size = new System.Drawing.Size(568, 30);
      this.radWaitingBar1.TabIndex = 6;
      this.radWaitingBar1.Text = "radWaitingBar1";
      this.radWaitingBar1.ThemeName = "TelerikMetro";
      this.radWaitingBar1.WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.Dash;
      // 
      // WelcomeForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.White;
      this.ClientSize = new System.Drawing.Size(578, 210);
      this.ControlBox = false;
      this.Controls.Add(this.lbl_version);
      this.Controls.Add(this.radLabel3);
      this.Controls.Add(this.radLabel2);
      this.Controls.Add(this.pictureBox1);
      this.Controls.Add(this.radLabel1);
      this.Controls.Add(this.radWaitingBar1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "WelcomeForm";
      this.Padding = new System.Windows.Forms.Padding(5, 1, 5, 5);
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.Text = "";
      ((System.ComponentModel.ISupportInitialize)(this.lbl_version)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radWaitingBar1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Telerik.WinControls.UI.RadWaitingBar radWaitingBar1;
    private Telerik.WinControls.UI.RadLabel radLabel1;
    private System.Windows.Forms.PictureBox pictureBox1;
    private Telerik.WinControls.UI.RadLabel radLabel2;
    private Telerik.WinControls.UI.RadLabel radLabel3;
    private Telerik.WinControls.UI.RadLabel lbl_version;


  }
}