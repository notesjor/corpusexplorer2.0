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
      this.ihdPanel1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.IHDPanel();
      this.radCommandBar1 = new Telerik.WinControls.UI.RadCommandBar();
      this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
      this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
      this.btn_menu_preview = new Telerik.WinControls.UI.CommandBarButton();
      this.lbl_menu = new Telerik.WinControls.UI.CommandBarLabel();
      this.btn_menu_next = new Telerik.WinControls.UI.CommandBarButton();
      this.commandBarSeparator1 = new Telerik.WinControls.UI.CommandBarSeparator();
      this.commandBarHostItem1 = new Telerik.WinControls.UI.CommandBarHostItem();
      this.commandBarLabel1 = new Telerik.WinControls.UI.CommandBarLabel();
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
      this.radPanel1.Location = new System.Drawing.Point(0, 388);
      this.radPanel1.Size = new System.Drawing.Size(652, 38);
      // 
      // ihdPanel1
      // 
      this.ihdPanel1.BackColor = System.Drawing.Color.White;
      this.ihdPanel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.ihdPanel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ihdPanel1.IHDDeescribtion = "Folgende Dokumente und Dokumentmetadaten wurden in den von Ihnen ausgewählten Dat" +
    "eien entdeckt.";
      this.ihdPanel1.IHDHeader = "Gefundene Dokumente";
      this.ihdPanel1.IHDImage = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.cabinet;
      this.ihdPanel1.Location = new System.Drawing.Point(0, 0);
      this.ihdPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.ihdPanel1.Name = "ihdPanel1";
      this.ihdPanel1.Size = new System.Drawing.Size(652, 55);
      this.ihdPanel1.TabIndex = 1;
      // 
      // radCommandBar1
      // 
      this.radCommandBar1.Dock = System.Windows.Forms.DockStyle.Top;
      this.radCommandBar1.Location = new System.Drawing.Point(0, 55);
      this.radCommandBar1.Name = "radCommandBar1";
      this.radCommandBar1.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement1});
      this.radCommandBar1.Size = new System.Drawing.Size(652, 69);
      this.radCommandBar1.TabIndex = 2;
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
      this.commandBarStripElement1.DisplayName = "commandBarStripElement1";
      this.commandBarStripElement1.EnableDragging = false;
      this.commandBarStripElement1.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.btn_menu_preview,
            this.lbl_menu,
            this.btn_menu_next,
            this.commandBarSeparator1,
            this.commandBarHostItem1,
            this.commandBarLabel1});
      this.commandBarStripElement1.Name = "commandBarStripElement1";
      // 
      // 
      // 
      this.commandBarStripElement1.OverflowButton.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
      ((Telerik.WinControls.UI.RadCommandBarOverflowButton)(this.commandBarStripElement1.GetChildAt(2))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
      // 
      // btn_menu_preview
      // 
      this.btn_menu_preview.DisplayName = "commandBarButton1";
      this.btn_menu_preview.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.button_circle_left;
      this.btn_menu_preview.Name = "btn_menu_preview";
      this.btn_menu_preview.Text = "commandBarButton1";
      this.btn_menu_preview.Click += new System.EventHandler(this.btn_menu_preview_Click);
      // 
      // lbl_menu
      // 
      this.lbl_menu.DisplayName = "commandBarLabel1";
      this.lbl_menu.Name = "lbl_menu";
      this.lbl_menu.Text = "{0} / {1}";
      // 
      // btn_menu_next
      // 
      this.btn_menu_next.DisplayName = "commandBarButton2";
      this.btn_menu_next.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.button_circle_right;
      this.btn_menu_next.Name = "btn_menu_next";
      this.btn_menu_next.Text = "commandBarButton2";
      this.btn_menu_next.Click += new System.EventHandler(this.btn_menu_next_Click);
      // 
      // commandBarSeparator1
      // 
      this.commandBarSeparator1.AccessibleDescription = "commandBarSeparator1";
      this.commandBarSeparator1.AccessibleName = "commandBarSeparator1";
      this.commandBarSeparator1.DisplayName = "commandBarSeparator1";
      this.commandBarSeparator1.Name = "commandBarSeparator1";
      this.commandBarSeparator1.VisibleInOverflowMenu = false;
      // 
      // commandBarHostItem1
      // 
      this.commandBarHostItem1.Name = "commandBarHostItem1";
      this.commandBarHostItem1.Text = "";
      // 
      // commandBarLabel1
      // 
      this.commandBarLabel1.DisplayName = "commandBarLabel1";
      this.commandBarLabel1.Name = "commandBarLabel1";
      this.commandBarLabel1.Padding = new System.Windows.Forms.Padding(-5, 0, 0, 0);
      this.commandBarLabel1.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.TextIgnorieren;
      // 
      // radGroupBox1
      // 
      this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox1.Controls.Add(this.metadataEditor1);
      this.radGroupBox1.Dock = System.Windows.Forms.DockStyle.Right;
      this.radGroupBox1.HeaderText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Metadaten;
      this.radGroupBox1.Location = new System.Drawing.Point(429, 124);
      this.radGroupBox1.Name = "radGroupBox1";
      this.radGroupBox1.Padding = new System.Windows.Forms.Padding(10, 25, 10, 10);
      this.radGroupBox1.Size = new System.Drawing.Size(223, 264);
      this.radGroupBox1.TabIndex = 3;
      this.radGroupBox1.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Metadaten;
      // 
      // metadataEditor1
      // 
      this.metadataEditor1.BackColor = System.Drawing.Color.White;
      this.metadataEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.metadataEditor1.Font = new System.Drawing.Font("Segoe UI", 11F);
      this.metadataEditor1.Location = new System.Drawing.Point(10, 25);
      this.metadataEditor1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.metadataEditor1.Metadata = null;
      this.metadataEditor1.Name = "metadataEditor1";
      this.metadataEditor1.Size = new System.Drawing.Size(203, 229);
      this.metadataEditor1.TabIndex = 0;
      // 
      // radGroupBox2
      // 
      this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox2.Controls.Add(this.txt_text);
      this.radGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radGroupBox2.HeaderText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Text;
      this.radGroupBox2.Location = new System.Drawing.Point(0, 124);
      this.radGroupBox2.Name = "radGroupBox2";
      this.radGroupBox2.Padding = new System.Windows.Forms.Padding(10, 25, 10, 10);
      this.radGroupBox2.Size = new System.Drawing.Size(429, 264);
      this.radGroupBox2.TabIndex = 4;
      this.radGroupBox2.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Text;
      // 
      // txt_text
      // 
      this.txt_text.AutoSize = false;
      this.txt_text.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txt_text.Location = new System.Drawing.Point(10, 25);
      this.txt_text.MaxLength = 2147483646;
      this.txt_text.Multiline = true;
      this.txt_text.Name = "txt_text";
      this.txt_text.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.txt_text.Size = new System.Drawing.Size(409, 229);
      this.txt_text.TabIndex = 0;
      // 
      // ShowScraperResults
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(652, 426);
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
      this.Text = "Gefundene Dokumente";
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
    private Telerik.WinControls.UI.CommandBarLabel commandBarLabel1;
    private MetadataEditor metadataEditor1;
  }
}