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
      this.radScrollablePanel1 = new Telerik.WinControls.UI.RadScrollablePanel();
      this.btn_online = new Telerik.WinControls.UI.RadButton();
      this.btn_handbook = new Telerik.WinControls.UI.RadButton();
      this.btn_handson = new Telerik.WinControls.UI.RadButton();
      this.btn_video = new Telerik.WinControls.UI.RadButton();
      this.header1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.Header();
      ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel1)).BeginInit();
      this.radScrollablePanel1.PanelContainer.SuspendLayout();
      this.radScrollablePanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.btn_online)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_handbook)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_handson)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_video)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.header1)).BeginInit();
      this.SuspendLayout();
      // 
      // radScrollablePanel1
      // 
      resources.ApplyResources(this.radScrollablePanel1, "radScrollablePanel1");
      this.radScrollablePanel1.Name = "radScrollablePanel1";
      // 
      // radScrollablePanel1.PanelContainer
      // 
      this.radScrollablePanel1.PanelContainer.Controls.Add(this.btn_online);
      this.radScrollablePanel1.PanelContainer.Controls.Add(this.btn_handbook);
      this.radScrollablePanel1.PanelContainer.Controls.Add(this.btn_handson);
      this.radScrollablePanel1.PanelContainer.Controls.Add(this.btn_video);
      resources.ApplyResources(this.radScrollablePanel1.PanelContainer, "radScrollablePanel1.PanelContainer");
      // 
      // btn_online
      // 
      resources.ApplyResources(this.btn_online, "btn_online");
      this.btn_online.Name = "btn_online";
      this.btn_online.Tag = "";
      this.btn_online.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.WeitereInformationen;
      this.btn_online.TextWrap = true;
      this.btn_online.ThemeName = "TelerikMetroTouch";
      this.btn_online.Click += new System.EventHandler(this.btn_online_Click);
      // 
      // btn_handbook
      // 
      resources.ApplyResources(this.btn_handbook, "btn_handbook");
      this.btn_handbook.Name = "btn_handbook";
      // 
      // 
      // 
      this.btn_handbook.RootElement.MaxSize = new System.Drawing.Size(0, 0);
      this.btn_handbook.Tag = "";
      this.btn_handbook.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.InteraktivesHandbuch;
      this.btn_handbook.TextWrap = true;
      this.btn_handbook.ThemeName = "TelerikMetroTouch";
      this.btn_handbook.Click += new System.EventHandler(this.btn_handbook_Click);
      // 
      // btn_handson
      // 
      resources.ApplyResources(this.btn_handson, "btn_handson");
      this.btn_handson.Name = "btn_handson";
      // 
      // 
      // 
      this.btn_handson.RootElement.MaxSize = new System.Drawing.Size(0, 0);
      this.btn_handson.Tag = "";
      this.btn_handson.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.PraktischeÜbungen;
      this.btn_handson.TextWrap = true;
      this.btn_handson.ThemeName = "TelerikMetroTouch";
      this.btn_handson.Click += new System.EventHandler(this.btn_handson_Click);
      // 
      // btn_video
      // 
      resources.ApplyResources(this.btn_video, "btn_video");
      this.btn_video.Name = "btn_video";
      // 
      // 
      // 
      this.btn_video.RootElement.MaxSize = new System.Drawing.Size(0, 0);
      this.btn_video.Tag = "";
      this.btn_video.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.KurzesEinstiegsvideo;
      this.btn_video.TextWrap = true;
      this.btn_video.ThemeName = "TelerikMetroTouch";
      this.btn_video.Click += new System.EventHandler(this.btn_video_Click);
      // 
      // header1
      // 
      resources.ApplyResources(this.header1, "header1");
      this.header1.BackColor = System.Drawing.Color.White;
      this.header1.HeaderDescription = "{HeaderDescription}";
      this.header1.HeaderHead = "{HeaderHead}";
      this.header1.Name = "header1";
      // 
      // HelpPanel
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.BackColor = System.Drawing.Color.White;
      this.Controls.Add(this.header1);
      this.Controls.Add(this.radScrollablePanel1);
      resources.ApplyResources(this, "$this");
      this.Name = "HelpPanel";
      this.radScrollablePanel1.PanelContainer.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel1)).EndInit();
      this.radScrollablePanel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.btn_online)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_handbook)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_handson)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_video)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.header1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion
    private Telerik.WinControls.UI.RadButton btn_video;
    private Telerik.WinControls.UI.RadButton btn_handson;
    private Telerik.WinControls.UI.RadButton btn_handbook;
    private Telerik.WinControls.UI.RadButton btn_online;
    private Header header1;
    private Telerik.WinControls.UI.RadScrollablePanel radScrollablePanel1;
  }
}
