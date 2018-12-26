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
      this.mainControl1 = new CorpusExplorer.Sdk.Extern.SocialMedia.Gui.Controls.MainControl();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // mainControl1
      // 
      this.mainControl1.BackColor = System.Drawing.Color.White;
      this.mainControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.mainControl1.Location = new System.Drawing.Point(0, 0);
      this.mainControl1.Name = "mainControl1";
      this.mainControl1.Size = new System.Drawing.Size(822, 501);
      this.mainControl1.TabIndex = 0;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(822, 501);
      this.Controls.Add(this.mainControl1);
      this.Name = "MainForm";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.Text = "MainForm";
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private Controls.MainControl mainControl1;
  }
}