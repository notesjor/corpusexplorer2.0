using CorpusExplorer.Terminal.WinForm.Properties;
using CorpusExplorer.Terminal.WinForm.Controls.WinForm;

namespace CorpusExplorer.Terminal.WinForm.Forms.Scraper
{
  partial class ShowScraperResults
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowScraperResults));
      this.ihdPanel1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.IHDPanel();
      this.radCommandBar1 = new Telerik.WinControls.UI.RadCommandBar();
      this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
      this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
      this.btn_menu_preview = new Telerik.WinControls.UI.CommandBarButton();
      this.lbl_menu = new Telerik.WinControls.UI.CommandBarLabel();
      this.btn_menu_next = new Telerik.WinControls.UI.CommandBarButton();
      this.commandBarSeparator1 = new Telerik.WinControls.UI.CommandBarSeparator();
      this.commandBarHostItem1 = new Telerik.WinControls.UI.CommandBarHostItem();
      this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
      this.metadataEditor1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.MetadataEditor();
      this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
      this.txt_text = new Telerik.WinControls.UI.RadTextBox();
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
      this.radGroupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
      this.radGroupBox2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.txt_text)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // radPanel1
      // 
      resources.ApplyResources(this.radPanel1, "radPanel1");
      // 
      // ihdPanel1
      // 
      this.ihdPanel1.BackColor = System.Drawing.Color.White;
      resources.ApplyResources(this.ihdPanel1, "ihdPanel1");
      this.ihdPanel1.IHDDescription = "Folgende Dokumente und Dokumentmetadaten wurden in den von Ihnen ausgewählten Dat" +
    "eien entdeckt.";
      this.ihdPanel1.IHDHeader = "Gefundene Dokumente";
      this.ihdPanel1.IHDImage = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.cabinet;
      this.ihdPanel1.Name = "ihdPanel1";
      // 
      // radCommandBar1
      // 
      resources.ApplyResources(this.radCommandBar1, "radCommandBar1");
      this.radCommandBar1.Name = "radCommandBar1";
      this.radCommandBar1.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement1});
      // 
      // commandBarRowElement1
      // 
      this.commandBarRowElement1.MinSize = new System.Drawing.Size(25, 25);
      this.commandBarRowElement1.Name = "commandBarRowElement1";
      this.commandBarRowElement1.Strips.AddRange(new Telerik.WinControls.UI.CommandBarStripElement[] {
            this.commandBarStripElement1});
      // 
      // commandBarStripElement1
      // 
      resources.ApplyResources(this.commandBarStripElement1, "commandBarStripElement1");
      this.commandBarStripElement1.EnableDragging = false;
      this.commandBarStripElement1.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.btn_menu_preview,
            this.lbl_menu,
            this.btn_menu_next,
            this.commandBarSeparator1,
            this.commandBarHostItem1});
      this.commandBarStripElement1.Name = "commandBarStripElement1";
      // 
      // 
      // 
      this.commandBarStripElement1.OverflowButton.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
      ((Telerik.WinControls.UI.RadCommandBarOverflowButton)(this.commandBarStripElement1.GetChildAt(2))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
      // 
      // btn_menu_preview
      // 
      resources.ApplyResources(this.btn_menu_preview, "btn_menu_preview");
      this.btn_menu_preview.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.button_circle_left;
      this.btn_menu_preview.Name = "btn_menu_preview";
      this.btn_menu_preview.Click += new System.EventHandler(this.btn_menu_preview_Click);
      // 
      // lbl_menu
      // 
      resources.ApplyResources(this.lbl_menu, "lbl_menu");
      this.lbl_menu.Name = "lbl_menu";
      // 
      // btn_menu_next
      // 
      resources.ApplyResources(this.btn_menu_next, "btn_menu_next");
      this.btn_menu_next.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.button_circle_right;
      this.btn_menu_next.Name = "btn_menu_next";
      this.btn_menu_next.Click += new System.EventHandler(this.btn_menu_next_Click);
      // 
      // commandBarSeparator1
      // 
      this.commandBarSeparator1.AccessibleDescription = "commandBarSeparator1";
      this.commandBarSeparator1.AccessibleName = "commandBarSeparator1";
      resources.ApplyResources(this.commandBarSeparator1, "commandBarSeparator1");
      this.commandBarSeparator1.Name = "commandBarSeparator1";
      this.commandBarSeparator1.VisibleInOverflowMenu = false;
      // 
      // commandBarHostItem1
      // 
      this.commandBarHostItem1.Name = "commandBarHostItem1";
      resources.ApplyResources(this.commandBarHostItem1, "commandBarHostItem1");
      // 
      // radGroupBox1
      // 
      this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox1.Controls.Add(this.metadataEditor1);
      resources.ApplyResources(this.radGroupBox1, "radGroupBox1");
      this.radGroupBox1.HeaderText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Metadaten;
      this.radGroupBox1.Name = "radGroupBox1";
      this.radGroupBox1.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Metadaten;
      // 
      // metadataEditor1
      // 
      this.metadataEditor1.BackColor = System.Drawing.Color.White;
      resources.ApplyResources(this.metadataEditor1, "metadataEditor1");
      this.metadataEditor1.Name = "metadataEditor1";
      // 
      // radGroupBox2
      // 
      this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox2.Controls.Add(this.txt_text);
      resources.ApplyResources(this.radGroupBox2, "radGroupBox2");
      this.radGroupBox2.HeaderText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Text;
      this.radGroupBox2.Name = "radGroupBox2";
      this.radGroupBox2.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Text;
      // 
      // txt_text
      // 
      resources.ApplyResources(this.txt_text, "txt_text");
      this.txt_text.MaxLength = 2147483646;
      this.txt_text.Multiline = true;
      this.txt_text.Name = "txt_text";
      this.txt_text.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      // 
      // ShowScraperResults
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      resources.ApplyResources(this, "$this");
      this.Controls.Add(this.radGroupBox2);
      this.Controls.Add(this.radGroupBox1);
      this.Controls.Add(this.radCommandBar1);
      this.Controls.Add(this.ihdPanel1);
      this.DisplayAbort = true;
      this.Name = "ShowScraperResults";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.Controls.SetChildIndex(this.radPanel1, 0);
      this.Controls.SetChildIndex(this.ihdPanel1, 0);
      this.Controls.SetChildIndex(this.radCommandBar1, 0);
      this.Controls.SetChildIndex(this.radGroupBox1, 0);
      this.Controls.SetChildIndex(this.radGroupBox2, 0);
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
      this.radGroupBox1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
      this.radGroupBox2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.txt_text)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private IHDPanel ihdPanel1;
    private Telerik.WinControls.UI.RadCommandBar radCommandBar1;
    private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
    private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement1;
    private Telerik.WinControls.UI.CommandBarButton btn_menu_preview;
    private Telerik.WinControls.UI.CommandBarLabel lbl_menu;
    private Telerik.WinControls.UI.CommandBarButton btn_menu_next;
    private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
    private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
    private Telerik.WinControls.UI.RadTextBox txt_text;
    private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator1;
    private Telerik.WinControls.UI.CommandBarHostItem commandBarHostItem1;
    private MetadataEditor metadataEditor1;
  }
}