using CorpusExplorer.Terminal.WinForm.Properties;
namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm
{
  partial class HelpPanel
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpPanel));
      this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
      this.btn_video = new Telerik.WinControls.UI.RadButton();
      this.btn_handson = new Telerik.WinControls.UI.RadButton();
      this.btn_handbook = new Telerik.WinControls.UI.RadButton();
      this.btn_online = new Telerik.WinControls.UI.RadButton();
      this.header1 = new Header();
      this.flowLayoutPanel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.btn_video)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_handson)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_handbook)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_online)).BeginInit();
      this.SuspendLayout();
      // 
      // flowLayoutPanel2
      // 
      this.flowLayoutPanel2.Controls.Add(this.btn_video);
      this.flowLayoutPanel2.Controls.Add(this.btn_handson);
      this.flowLayoutPanel2.Controls.Add(this.btn_handbook);
      this.flowLayoutPanel2.Controls.Add(this.btn_online);
      this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 55);
      this.flowLayoutPanel2.Name = "flowLayoutPanel2";
      this.flowLayoutPanel2.Size = new System.Drawing.Size(525, 110);
      this.flowLayoutPanel2.TabIndex = 25;
      // 
      // btn_video
      // 
      this.btn_video.Image = ((System.Drawing.Image)(resources.GetObject("btn_video.Image")));
      this.btn_video.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
      this.btn_video.Location = new System.Drawing.Point(3, 3);
      this.btn_video.Name = "btn_video";
      this.btn_video.Size = new System.Drawing.Size(125, 100);
      this.btn_video.TabIndex = 0;
      this.btn_video.Tag = "";
      this.btn_video.Text = Resources.KurzesEinstiegsvideo;
      this.btn_video.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
      this.btn_video.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.btn_video.TextWrap = true;
      this.btn_video.Click += new System.EventHandler(this.btn_video_Click);
      // 
      // btn_handson
      // 
      this.btn_handson.Image = ((System.Drawing.Image)(resources.GetObject("btn_handson.Image")));
      this.btn_handson.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
      this.btn_handson.Location = new System.Drawing.Point(134, 3);
      this.btn_handson.Name = "btn_handson";
      this.btn_handson.Size = new System.Drawing.Size(125, 100);
      this.btn_handson.TabIndex = 2;
      this.btn_handson.Tag = "";
      this.btn_handson.Text = Resources.PraktischeÜbungen;
      this.btn_handson.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
      this.btn_handson.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.btn_handson.TextWrap = true;
      this.btn_handson.Click += new System.EventHandler(this.btn_handson_Click);
      // 
      // btn_handbook
      // 
      this.btn_handbook.Image = ((System.Drawing.Image)(resources.GetObject("btn_handbook.Image")));
      this.btn_handbook.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
      this.btn_handbook.Location = new System.Drawing.Point(265, 3);
      this.btn_handbook.Name = "btn_handbook";
      this.btn_handbook.Size = new System.Drawing.Size(125, 100);
      this.btn_handbook.TabIndex = 1;
      this.btn_handbook.Tag = "";
      this.btn_handbook.Text = Resources.InteraktivesHandbuch;
      this.btn_handbook.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
      this.btn_handbook.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.btn_handbook.TextWrap = true;
      this.btn_handbook.Click += new System.EventHandler(this.btn_handbook_Click);
      // 
      // btn_online
      // 
      this.btn_online.Font = new System.Drawing.Font("Segoe UI", 11F);
      this.btn_online.Image = ((System.Drawing.Image)(resources.GetObject("btn_online.Image")));
      this.btn_online.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
      this.btn_online.Location = new System.Drawing.Point(396, 3);
      this.btn_online.Name = "btn_online";
      this.btn_online.Size = new System.Drawing.Size(125, 100);
      this.btn_online.TabIndex = 3;
      this.btn_online.Tag = "";
      this.btn_online.Text = Resources.WeitereInformationen;
      this.btn_online.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
      this.btn_online.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.btn_online.TextWrap = true;
      this.btn_online.Click += new System.EventHandler(this.btn_online_Click);
      // 
      // header1
      // 
      this.header1.BackColor = System.Drawing.Color.White;
      this.header1.Dock = System.Windows.Forms.DockStyle.Top;
      this.header1.Font = new System.Drawing.Font("Segoe UI", 11F);
      this.header1.HeaderDescribtion = "{HeaderDescribtion}";
      this.header1.HeaderHead = "{HeaderHead}";
      this.header1.Location = new System.Drawing.Point(0, 0);
      this.header1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.header1.Name = "header1";
      this.header1.Size = new System.Drawing.Size(525, 55);
      this.header1.TabIndex = 26;
      // 
      // HelpPanel
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.BackColor = System.Drawing.Color.White;
      this.Controls.Add(this.flowLayoutPanel2);
      this.Controls.Add(this.header1);
      this.Font = new System.Drawing.Font("Segoe UI", 11F);
      this.MinimumSize = new System.Drawing.Size(0, 165);
      this.Name = "HelpPanel";
      this.Size = new System.Drawing.Size(525, 165);
      this.flowLayoutPanel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.btn_video)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_handson)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_handbook)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_online)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
    private Telerik.WinControls.UI.RadButton btn_video;
    private Telerik.WinControls.UI.RadButton btn_handson;
    private Telerik.WinControls.UI.RadButton btn_handbook;
    private Telerik.WinControls.UI.RadButton btn_online;
    private Header header1;
  }
}
