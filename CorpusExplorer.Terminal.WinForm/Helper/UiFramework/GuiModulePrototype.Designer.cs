using CorpusExplorer.Terminal.WinForm.Properties;
using CorpusExplorer.Terminal.WinForm.Controls.WinForm;

namespace CorpusExplorer.Terminal.WinForm.Helper.UiFramework
{
  partial class GuiModulePrototype
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GuiModulePrototype));
      this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
      this.btn_home = new Telerik.WinControls.UI.RadButton();
      this.Pages = new Telerik.WinControls.UI.RadPageView();
      this.page_HOME = new Telerik.WinControls.UI.RadPageViewPage();
      this.helpPanel1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.HelpPanel();
      this.modul_viewstates = new Telerik.WinControls.UI.RadPanorama();
      this._headHome = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.HeadPanel();
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
      this.radPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.btn_home)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.Pages)).BeginInit();
      this.Pages.SuspendLayout();
      this.page_HOME.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.modul_viewstates)).BeginInit();
      this.SuspendLayout();
      // 
      // radPanel1
      // 
      this.radPanel1.Controls.Add(this.btn_home);
      resources.ApplyResources(this.radPanel1, "radPanel1");
      this.radPanel1.Name = "radPanel1";
      ((Telerik.WinControls.UI.RadPanelElement)(this.radPanel1.GetChildAt(0))).Text = resources.GetString("resource.Text");
      ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radPanel1.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
      // 
      // btn_home
      // 
      resources.ApplyResources(this.btn_home, "btn_home");
      this.btn_home.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.gears;
      this.btn_home.Name = "btn_home";
      this.btn_home.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.EinstellungÜbersicht;
      this.btn_home.Click += new System.EventHandler(this.btn_home_Click);
      // 
      // Pages
      // 
      this.Pages.Controls.Add(this.page_HOME);
      resources.ApplyResources(this.Pages, "Pages");
      this.Pages.Name = "Pages";
      this.Pages.SelectedPage = this.page_HOME;
      ((Telerik.WinControls.UI.RadPageViewStripElement)(this.Pages.GetChildAt(0))).BorderWidth = 0F;
      ((Telerik.WinControls.UI.RadPageViewStripElement)(this.Pages.GetChildAt(0))).BorderLeftWidth = 0F;
      ((Telerik.WinControls.UI.RadPageViewStripElement)(this.Pages.GetChildAt(0))).BorderTopWidth = 0F;
      ((Telerik.WinControls.UI.RadPageViewStripElement)(this.Pages.GetChildAt(0))).BorderRightWidth = 0F;
      ((Telerik.WinControls.UI.RadPageViewStripElement)(this.Pages.GetChildAt(0))).BorderBottomWidth = 0F;
      ((Telerik.WinControls.UI.RadPageViewLabelElement)(this.Pages.GetChildAt(0).GetChildAt(2))).Text = resources.GetString("resource.Text1");
      ((Telerik.WinControls.UI.RadPageViewLabelElement)(this.Pages.GetChildAt(0).GetChildAt(2))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
      // 
      // page_HOME
      // 
      this.page_HOME.Controls.Add(this.helpPanel1);
      this.page_HOME.Controls.Add(this.modul_viewstates);
      this.page_HOME.Controls.Add(this._headHome);
      this.page_HOME.ItemSize = new System.Drawing.SizeF(57F, 29F);
      resources.ApplyResources(this.page_HOME, "page_HOME");
      this.page_HOME.Name = "page_HOME";
      // 
      // helpPanel1
      // 
      this.helpPanel1.BackColor = System.Drawing.Color.White;
      resources.ApplyResources(this.helpPanel1, "helpPanel1");
      this.helpPanel1.HelpHandbookText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.InteraktivesHandbuch;
      this.helpPanel1.HelpHandbookUrl = null;
      this.helpPanel1.HelpHandsonlabText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.PraktischeÜbungen;
      this.helpPanel1.HelpHandsonlabUrl = null;
      this.helpPanel1.HelpLabelDescription = "Für dieses Modul stehen folgende Lernressourcen zur Verfügung:";
      this.helpPanel1.HelpLabelHeader = "Hilfe zu diesem Modul - Erste Schritte...";
      this.helpPanel1.HelpOnlineText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.WeitereInformationen;
      this.helpPanel1.HelpOnlineUrl = null;
      this.helpPanel1.HelpVideoText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.KurzesEinstiegsvideo;
      this.helpPanel1.HelpVideoUrl = null;
      this.helpPanel1.Name = "helpPanel1";
      // 
      // modul_viewstates
      // 
      this.modul_viewstates.CellSize = new System.Drawing.Size(125, 100);
      resources.ApplyResources(this.modul_viewstates, "modul_viewstates");
      this.modul_viewstates.Name = "modul_viewstates";
      this.modul_viewstates.ScrollBarThickness = 20;
      this.modul_viewstates.ScrollingBackground = true;
      // 
      // _headHome
      // 
      this._headHome.BackColor = System.Drawing.Color.White;
      resources.ApplyResources(this._headHome, "_headHome");
      this._headHome.HeadPanelDescription = "{IHDDESCRIPTION}";
      this._headHome.HeadPanelTitle = "{IHDHEADER}";
      this._headHome.HeadPanelImage = null;
      this._headHome.Name = "_headHome";
      // 
      // GuiModulePrototype
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.Controls.Add(this.Pages);
      this.Controls.Add(this.radPanel1);
      resources.ApplyResources(this, "$this");
      this.Name = "GuiModulePrototype";
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
      this.radPanel1.ResumeLayout(false);
      this.radPanel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.btn_home)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.Pages)).EndInit();
      this.Pages.ResumeLayout(false);
      this.page_HOME.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.modul_viewstates)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private Telerik.WinControls.UI.RadPanel radPanel1;
    protected Telerik.WinControls.UI.RadPageView Pages;
    private Telerik.WinControls.UI.RadButton btn_home;
    protected Telerik.WinControls.UI.RadPageViewPage page_HOME;
    protected HeadPanel _headHome;
    private Telerik.WinControls.UI.RadPanorama modul_viewstates;
    private HelpPanel helpPanel1;
  }
}
