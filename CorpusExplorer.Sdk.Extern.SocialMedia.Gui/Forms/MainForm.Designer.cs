namespace CorpusExplorer.Sdk.Extern.SocialMedia.Gui.Forms
{
  partial class MainForm
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
      if (disposing && (components != null))
      {
        components.Dispose();
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.mainControl1 = new CorpusExplorer.Sdk.Extern.SocialMedia.Gui.Controls.MainControl();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // mainControl1
      // 
      this.mainControl1.BackColor = System.Drawing.Color.White;
      this.mainControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.mainControl1.Location = new System.Drawing.Point(0, 0);
      this.mainControl1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
      this.mainControl1.Name = "mainControl1";
      this.mainControl1.Size = new System.Drawing.Size(1101, 643);
      this.mainControl1.TabIndex = 0;
      // 
      // MainForm
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.ClientSize = new System.Drawing.Size(1101, 643);
      this.Controls.Add(this.mainControl1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Margin = new System.Windows.Forms.Padding(4);
      this.Name = "MainForm";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.Text = "SSMDL - Siegener Social Media Data Lake";
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private Controls.MainControl mainControl1;
  }
}