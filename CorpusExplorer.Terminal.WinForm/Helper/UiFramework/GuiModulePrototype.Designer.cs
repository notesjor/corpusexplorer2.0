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
      this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
      this.btn_home = new Telerik.WinControls.UI.RadButton();
      this.Pages = new Telerik.WinControls.UI.RadPageView();
      this.page_HOME = new Telerik.WinControls.UI.RadPageViewPage();
      this.helpPanel1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.HelpPanel();
      this.modul_viewstates = new Telerik.WinControls.UI.RadPanorama();
      this.ihd_home = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.IHDPanel();
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
      this.radPanel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.radPanel1.Location = new System.Drawing.Point(0, 0);
      this.radPanel1.Margin = new System.Windows.Forms.Padding(0);
      this.radPanel1.Name = "radPanel1";
      this.radPanel1.Size = new System.Drawing.Size(545, 32);
      this.radPanel1.TabIndex = 0;
      ((Telerik.WinControls.UI.RadPanelElement)(this.radPanel1.GetChildAt(0))).Text = "";
      ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radPanel1.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
      // 
      // btn_home
      // 
      this.btn_home.AutoSize = true;
      this.btn_home.Dock = System.Windows.Forms.DockStyle.Left;
      this.btn_home.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.gears;
      this.btn_home.Location = new System.Drawing.Point(0, 0);
      this.btn_home.Margin = new System.Windows.Forms.Padding(0);
      this.btn_home.Name = "btn_home";
      this.btn_home.Size = new System.Drawing.Size(187, 32);
      this.btn_home.TabIndex = 1;
      this.btn_home.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.EinstellungÜbersicht;
      this.btn_home.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
      this.btn_home.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btn_home.Click += new System.EventHandler(this.btn_home_Click);
      // 
      // Pages
      // 
      this.Pages.Controls.Add(this.page_HOME);
      this.Pages.Dock = System.Windows.Forms.DockStyle.Fill;
      this.Pages.Location = new System.Drawing.Point(0, 32);
      this.Pages.Name = "Pages";
      this.Pages.SelectedPage = this.page_HOME;
      this.Pages.Size = new System.Drawing.Size(545, 278);
      this.Pages.TabIndex = 1;
      this.Pages.Text = "radPageView1";
      ((Telerik.WinControls.UI.RadPageViewStripElement)(this.Pages.GetChildAt(0))).BorderWidth = 0F;
      ((Telerik.WinControls.UI.RadPageViewStripElement)(this.Pages.GetChildAt(0))).BorderLeftWidth = 0F;
      ((Telerik.WinControls.UI.RadPageViewStripElement)(this.Pages.GetChildAt(0))).BorderTopWidth = 0F;
      ((Telerik.WinControls.UI.RadPageViewStripElement)(this.Pages.GetChildAt(0))).BorderRightWidth = 0F;
      ((Telerik.WinControls.UI.RadPageViewStripElement)(this.Pages.GetChildAt(0))).BorderBottomWidth = 0F;
      ((Telerik.WinControls.UI.RadPageViewLabelElement)(this.Pages.GetChildAt(0).GetChildAt(2))).Text = "HOME";
      ((Telerik.WinControls.UI.RadPageViewLabelElement)(this.Pages.GetChildAt(0).GetChildAt(2))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
      // 
      // page_HOME
      // 
      this.page_HOME.Controls.Add(this.helpPanel1);
      this.page_HOME.Controls.Add(this.modul_viewstates);
      this.page_HOME.Controls.Add(this.ihd_home);
      this.page_HOME.ItemSize = new System.Drawing.SizeF(57F, 29F);
      this.page_HOME.Location = new System.Drawing.Point(5, 40);
      this.page_HOME.Name = "page_HOME";
      this.page_HOME.Size = new System.Drawing.Size(535, 233);
      this.page_HOME.Text = "HOME";
      // 
      // helpPanel1
      // 
      this.helpPanel1.BackColor = System.Drawing.Color.White;
      this.helpPanel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.helpPanel1.Font = new System.Drawing.Font("Segoe UI", 11F);
      this.helpPanel1.HelpHandbookText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.InteraktivesHandbuch;
      this.helpPanel1.HelpHandbookUrl = null;
      this.helpPanel1.HelpHandsonlabText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.PraktischeÜbungen;
      this.helpPanel1.HelpHandsonlabUrl = null;
      this.helpPanel1.HelpLabelDescribtion = "Für dieses Modul stehen folgende Lernressourcen zur Verfügung:";
      this.helpPanel1.HelpLabelHeader = "Hilfe zu diesem Modul - Erste Schritte...";
      this.helpPanel1.HelpOnlineText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.WeitereInformationen;
      this.helpPanel1.HelpOnlineUrl = null;
      this.helpPanel1.HelpVideoText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.KurzesEinstiegsvideo;
      this.helpPanel1.HelpVideoUrl = null;
      this.helpPanel1.Location = new System.Drawing.Point(0, 175);
      this.helpPanel1.MinimumSize = new System.Drawing.Size(0, 165);
      this.helpPanel1.Name = "helpPanel1";
      this.helpPanel1.Size = new System.Drawing.Size(535, 165);
      this.helpPanel1.TabIndex = 33;
      // 
      // modul_viewstates
      // 
      this.modul_viewstates.CellSize = new System.Drawing.Size(125, 100);
      this.modul_viewstates.Dock = System.Windows.Forms.DockStyle.Top;
      this.modul_viewstates.Location = new System.Drawing.Point(0, 55);
      this.modul_viewstates.Name = "modul_viewstates";
      this.modul_viewstates.ScrollBarThickness = 20;
      this.modul_viewstates.ScrollingBackground = true;
      this.modul_viewstates.Size = new System.Drawing.Size(535, 120);
      this.modul_viewstates.TabIndex = 32;
      this.modul_viewstates.Text = "radPanorama1";
      // 
      // ihd_home
      // 
      this.ihd_home.BackColor = System.Drawing.Color.White;
      this.ihd_home.Dock = System.Windows.Forms.DockStyle.Top;
      this.ihd_home.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ihd_home.IHDDeescribtion = "{IHDDESCRIBTION}";
      this.ihd_home.IHDHeader = "{IHDHEADER}";
      this.ihd_home.IHDImage = null;
      this.ihd_home.Location = new System.Drawing.Point(0, 0);
      this.ihd_home.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.ihd_home.Name = "ihd_home";
      this.ihd_home.Size = new System.Drawing.Size(535, 55);
      this.ihd_home.TabIndex = 0;
      // 
      // GuiModulePrototype
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.Controls.Add(this.Pages);
      this.Controls.Add(this.radPanel1);
      this.Font = new System.Drawing.Font("Segoe UI", 11.25F);
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
    protected IHDPanel ihd_home;
    private Telerik.WinControls.UI.RadPanorama modul_viewstates;
    private HelpPanel helpPanel1;
  }
}
