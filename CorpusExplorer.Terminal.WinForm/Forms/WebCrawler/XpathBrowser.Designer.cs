namespace CorpusExplorer.Terminal.WinForm.Forms.WebCrawler
{
  partial class XpathBrowser
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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XpathBrowser));
      this.clearPanel4 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.ClearPanel();
      this.radTextBox5 = new Telerik.WinControls.UI.RadTextBox();
      this.radButton2 = new Telerik.WinControls.UI.RadButton();
      this.clearPanel3 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.ClearPanel();
      this.radTextBox3 = new Telerik.WinControls.UI.RadTextBox();
      this.radButton1 = new Telerik.WinControls.UI.RadButton();
      this.panel_webbrowser = new System.Windows.Forms.Panel();
      this.radDesktopAlert1 = new Telerik.WinControls.UI.RadDesktopAlert(this.components);
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel4)).BeginInit();
      this.clearPanel4.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radTextBox5)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radButton2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel3)).BeginInit();
      this.clearPanel3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radTextBox3)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // clearPanel4
      // 
      this.clearPanel4.Controls.Add(this.radTextBox5);
      this.clearPanel4.Controls.Add(this.radButton2);
      resources.ApplyResources(this.clearPanel4, "clearPanel4");
      this.clearPanel4.Name = "clearPanel4";
      // 
      // radTextBox5
      // 
      resources.ApplyResources(this.radTextBox5, "radTextBox5");
      this.radTextBox5.Name = "radTextBox5";
      this.radTextBox5.TextChanged += new System.EventHandler(this.radTextBox5_TextChanged);
      // 
      // radButton2
      // 
      resources.ApplyResources(this.radButton2, "radButton2");
      this.radButton2.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.refresh;
      this.radButton2.Name = "radButton2";
      this.radButton2.Click += new System.EventHandler(this.radButton2_Click);
      // 
      // clearPanel3
      // 
      this.clearPanel3.Controls.Add(this.radTextBox3);
      this.clearPanel3.Controls.Add(this.radButton1);
      resources.ApplyResources(this.clearPanel3, "clearPanel3");
      this.clearPanel3.Name = "clearPanel3";
      // 
      // radTextBox3
      // 
      resources.ApplyResources(this.radTextBox3, "radTextBox3");
      this.radTextBox3.Name = "radTextBox3";
      // 
      // radButton1
      // 
      resources.ApplyResources(this.radButton1, "radButton1");
      this.radButton1.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.button_circle_right;
      this.radButton1.Name = "radButton1";
      this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
      // 
      // panel_webbrowser
      // 
      resources.ApplyResources(this.panel_webbrowser, "panel_webbrowser");
      this.panel_webbrowser.Name = "panel_webbrowser";
      // 
      // radDesktopAlert1
      // 
      this.radDesktopAlert1.AutoCloseDelay = 20;
      this.radDesktopAlert1.AutoSize = true;
      this.radDesktopAlert1.CaptionText = "Hinweis zur XPath-Webseitenvorschau";
      this.radDesktopAlert1.ContentText = resources.GetString("radDesktopAlert1.ContentText");
      this.radDesktopAlert1.ScreenPosition = Telerik.WinControls.UI.AlertScreenPosition.TopCenter;
      // 
      // XpathBrowser
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      resources.ApplyResources(this, "$this");
      this.Controls.Add(this.panel_webbrowser);
      this.Controls.Add(this.clearPanel3);
      this.Controls.Add(this.clearPanel4);
      this.Name = "XpathBrowser";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel4)).EndInit();
      this.clearPanel4.ResumeLayout(false);
      this.clearPanel4.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radTextBox5)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radButton2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel3)).EndInit();
      this.clearPanel3.ResumeLayout(false);
      this.clearPanel3.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radTextBox3)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private Controls.WinForm.ClearPanel clearPanel4;
    private Telerik.WinControls.UI.RadTextBox radTextBox5;
    private Telerik.WinControls.UI.RadButton radButton2;
    private Controls.WinForm.ClearPanel clearPanel3;
    private Telerik.WinControls.UI.RadTextBox radTextBox3;
    private Telerik.WinControls.UI.RadButton radButton1;
    private System.Windows.Forms.Panel panel_webbrowser;
    private Telerik.WinControls.UI.RadDesktopAlert radDesktopAlert1;
  }
}