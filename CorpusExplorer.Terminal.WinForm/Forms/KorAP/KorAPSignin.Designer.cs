namespace CorpusExplorer.Terminal.WinForm.Forms.KorAP
{
  partial class KorAPSignin
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KorAPSignin));
      this.webPanel = new System.Windows.Forms.Panel();
      this.headPanel1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.HeadPanel();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // webPanel
      // 
      this.webPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.webPanel.Location = new System.Drawing.Point(0, 88);
      this.webPanel.Name = "webPanel";
      this.webPanel.Size = new System.Drawing.Size(959, 531);
      this.webPanel.TabIndex = 0;
      // 
      // headPanel1
      // 
      this.headPanel1.BackColor = System.Drawing.Color.White;
      this.headPanel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.headPanel1.Font = new System.Drawing.Font("Segoe UI", 12F);
      this.headPanel1.HeadPanelDescription = resources.GetString("headPanel1.HeadPanelDescription");
      this.headPanel1.HeadPanelImage = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.korap_48;
      this.headPanel1.HeadPanelTitle = "KorAP-Authorisierung";
      this.headPanel1.Location = new System.Drawing.Point(0, 0);
      this.headPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.headPanel1.Name = "headPanel1";
      this.headPanel1.Size = new System.Drawing.Size(959, 88);
      this.headPanel1.TabIndex = 1;
      // 
      // KorAPSignin
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(959, 619);
      this.Controls.Add(this.webPanel);
      this.Controls.Add(this.headPanel1);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "KorAPSignin";
      this.Text = "KorAP-Authorisierung via OAuth2";
      this.Load += new System.EventHandler(this.KorAPSignin_Load);
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel webPanel;
    private Controls.WinForm.HeadPanel headPanel1;
  }
}