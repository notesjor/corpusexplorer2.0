using CorpusExplorer.Terminal.WinForm.Properties;
using CorpusExplorer.Terminal.WinForm.Controls.WinForm;

namespace CorpusExplorer.Terminal.WinForm.View.Fulltext
{
  partial class FulltextKwicSearch
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
      if (disposing && (components != null))
      {
        components.Dispose();
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
      this.radSplitContainer1 = new Telerik.WinControls.UI.RadSplitContainer();
      this.splitPanel1 = new Telerik.WinControls.UI.SplitPanel();
      this.txt_query = new Telerik.WinControls.UI.RadAutoCompleteBox();
      this.clearPanel2 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.ClearPanel();
      this.clearPanel1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.ClearPanel();
      this.radButton1 = new Telerik.WinControls.UI.RadButton();
      this.cmb_layer = new Telerik.WinControls.UI.RadDropDownList();
      this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
      this.splitPanel2 = new Telerik.WinControls.UI.SplitPanel();
      this.radSplitContainer2 = new Telerik.WinControls.UI.RadSplitContainer();
      this.splitPanel3 = new Telerik.WinControls.UI.SplitPanel();
      this.tree = new Telerik.WinControls.UI.RadTreeView();
      this.radCommandBar1 = new Telerik.WinControls.UI.RadCommandBar();
      this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
      this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
      this.commandBarLabel1 = new Telerik.WinControls.UI.CommandBarLabel();
      this.btn_select_all = new Telerik.WinControls.UI.CommandBarButton();
      this.btn_select_none = new Telerik.WinControls.UI.CommandBarButton();
      this.btn_select_invert = new Telerik.WinControls.UI.CommandBarButton();
      this.btn_snapshot_make = new Telerik.WinControls.UI.RadButton();
      this.splitPanel4 = new Telerik.WinControls.UI.SplitPanel();
      this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
      ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).BeginInit();
      this.radSplitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).BeginInit();
      this.splitPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.txt_query)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel1)).BeginInit();
      this.clearPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.cmb_layer)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).BeginInit();
      this.splitPanel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer2)).BeginInit();
      this.radSplitContainer2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel3)).BeginInit();
      this.splitPanel3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.tree)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_snapshot_make)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel4)).BeginInit();
      this.splitPanel4.SuspendLayout();
      this.SuspendLayout();
      // 
      // radSplitContainer1
      // 
      this.radSplitContainer1.Controls.Add(this.splitPanel1);
      this.radSplitContainer1.Controls.Add(this.splitPanel2);
      this.radSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radSplitContainer1.Location = new System.Drawing.Point(0, 0);
      this.radSplitContainer1.Name = "radSplitContainer1";
      this.radSplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // 
      // 
      this.radSplitContainer1.RootElement.MinSize = new System.Drawing.Size(0, 0);
      this.radSplitContainer1.Size = new System.Drawing.Size(780, 400);
      this.radSplitContainer1.TabIndex = 0;
      this.radSplitContainer1.TabStop = false;
      this.radSplitContainer1.Text = "radSplitContainer1";
      // 
      // splitPanel1
      // 
      this.splitPanel1.Controls.Add(this.txt_query);
      this.splitPanel1.Controls.Add(this.clearPanel2);
      this.splitPanel1.Controls.Add(this.clearPanel1);
      this.splitPanel1.Location = new System.Drawing.Point(0, 0);
      this.splitPanel1.Name = "splitPanel1";
      // 
      // 
      // 
      this.splitPanel1.RootElement.MinSize = new System.Drawing.Size(0, 0);
      this.splitPanel1.Size = new System.Drawing.Size(780, 182);
      this.splitPanel1.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(0F, -0.03982301F);
      this.splitPanel1.SizeInfo.SplitterCorrection = new System.Drawing.Size(0, -9);
      this.splitPanel1.TabIndex = 0;
      this.splitPanel1.TabStop = false;
      this.splitPanel1.Text = "splitPanel1";
      // 
      // txt_query
      // 
      this.txt_query.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txt_query.Location = new System.Drawing.Point(0, 35);
      this.txt_query.Name = "txt_query";
      this.txt_query.NullText = "Suchbegriffe hier eingeben...";
      this.txt_query.Size = new System.Drawing.Size(780, 127);
      this.txt_query.TabIndex = 2;
      // 
      // clearPanel2
      // 
      this.clearPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.clearPanel2.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.clearPanel2.Location = new System.Drawing.Point(0, 162);
      this.clearPanel2.Name = "clearPanel2";
      this.clearPanel2.Size = new System.Drawing.Size(780, 20);
      this.clearPanel2.TabIndex = 1;
      this.clearPanel2.Text = "Hinweis: Zum Bestätigen der Begriffe drücken Sie ENTER oder verwenden Sie das Sem" +
    "ikolon \";\"";
      // 
      // clearPanel1
      // 
      this.clearPanel1.Controls.Add(this.radButton1);
      this.clearPanel1.Controls.Add(this.cmb_layer);
      this.clearPanel1.Controls.Add(this.radLabel1);
      this.clearPanel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.clearPanel1.Location = new System.Drawing.Point(0, 0);
      this.clearPanel1.Name = "clearPanel1";
      this.clearPanel1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
      this.clearPanel1.Size = new System.Drawing.Size(780, 35);
      this.clearPanel1.TabIndex = 0;
      // 
      // radButton1
      // 
      this.radButton1.Dock = System.Windows.Forms.DockStyle.Right;
      this.radButton1.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.find;
      this.radButton1.Location = new System.Drawing.Point(691, 3);
      this.radButton1.Name = "radButton1";
      this.radButton1.Size = new System.Drawing.Size(89, 32);
      this.radButton1.TabIndex = 2;
      this.radButton1.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Finden;
      this.radButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
      // 
      // cmb_layer
      // 
      this.cmb_layer.AutoCompleteDisplayMember = null;
      this.cmb_layer.AutoCompleteValueMember = null;
      this.cmb_layer.Dock = System.Windows.Forms.DockStyle.Left;
      this.cmb_layer.Location = new System.Drawing.Point(52, 3);
      this.cmb_layer.Name = "cmb_layer";
      this.cmb_layer.NullText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.BitteAuswählen;
      this.cmb_layer.Size = new System.Drawing.Size(205, 32);
      this.cmb_layer.TabIndex = 1;
      this.cmb_layer.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cmb_layer_SelectedIndexChanged);
      // 
      // radLabel1
      // 
      this.radLabel1.AutoSize = false;
      this.radLabel1.Dock = System.Windows.Forms.DockStyle.Left;
      this.radLabel1.Location = new System.Drawing.Point(0, 3);
      this.radLabel1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
      this.radLabel1.Name = "radLabel1";
      this.radLabel1.Size = new System.Drawing.Size(52, 32);
      this.radLabel1.TabIndex = 0;
      this.radLabel1.Text = "Layer:";
      this.radLabel1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // splitPanel2
      // 
      this.splitPanel2.Controls.Add(this.radSplitContainer2);
      this.splitPanel2.Location = new System.Drawing.Point(0, 186);
      this.splitPanel2.Name = "splitPanel2";
      // 
      // 
      // 
      this.splitPanel2.RootElement.MinSize = new System.Drawing.Size(0, 0);
      this.splitPanel2.Size = new System.Drawing.Size(780, 214);
      this.splitPanel2.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(0F, 0.03982301F);
      this.splitPanel2.SizeInfo.SplitterCorrection = new System.Drawing.Size(0, 9);
      this.splitPanel2.TabIndex = 1;
      this.splitPanel2.TabStop = false;
      this.splitPanel2.Text = "splitPanel2";
      // 
      // radSplitContainer2
      // 
      this.radSplitContainer2.Controls.Add(this.splitPanel3);
      this.radSplitContainer2.Controls.Add(this.splitPanel4);
      this.radSplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radSplitContainer2.Location = new System.Drawing.Point(0, 0);
      this.radSplitContainer2.Name = "radSplitContainer2";
      // 
      // 
      // 
      this.radSplitContainer2.RootElement.MinSize = new System.Drawing.Size(0, 0);
      this.radSplitContainer2.Size = new System.Drawing.Size(780, 214);
      this.radSplitContainer2.SplitterWidth = 8;
      this.radSplitContainer2.TabIndex = 0;
      this.radSplitContainer2.TabStop = false;
      this.radSplitContainer2.Text = "radSplitContainer2";
      this.radSplitContainer2.UseSplitterButtons = true;
      // 
      // splitPanel3
      // 
      this.splitPanel3.Controls.Add(this.tree);
      this.splitPanel3.Controls.Add(this.radCommandBar1);
      this.splitPanel3.Controls.Add(this.btn_snapshot_make);
      this.splitPanel3.Location = new System.Drawing.Point(0, 0);
      this.splitPanel3.Name = "splitPanel3";
      // 
      // 
      // 
      this.splitPanel3.RootElement.MinSize = new System.Drawing.Size(0, 0);
      this.splitPanel3.Size = new System.Drawing.Size(386, 214);
      this.splitPanel3.TabIndex = 0;
      this.splitPanel3.TabStop = false;
      this.splitPanel3.Text = "splitPanel3";
      // 
      // tree
      // 
      this.tree.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tree.ItemHeight = 40;
      this.tree.Location = new System.Drawing.Point(0, 44);
      this.tree.Name = "tree";
      this.tree.Size = new System.Drawing.Size(386, 137);
      this.tree.TabIndex = 0;
      this.tree.Text = "radTreeView1";
      this.tree.TreeIndent = 40;
      this.tree.NodeCheckedChanged += new Telerik.WinControls.UI.TreeNodeCheckedEventHandler(this.tree_NodeCheckedChanged);
      // 
      // radCommandBar1
      // 
      this.radCommandBar1.Dock = System.Windows.Forms.DockStyle.Top;
      this.radCommandBar1.Location = new System.Drawing.Point(0, 0);
      this.radCommandBar1.Name = "radCommandBar1";
      this.radCommandBar1.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement1});
      this.radCommandBar1.Size = new System.Drawing.Size(386, 44);
      this.radCommandBar1.TabIndex = 2;
      this.radCommandBar1.Text = "radCommandBar1";
      // 
      // commandBarRowElement1
      // 
      this.commandBarRowElement1.MinSize = new System.Drawing.Size(25, 25);
      this.commandBarRowElement1.Strips.AddRange(new Telerik.WinControls.UI.CommandBarStripElement[] {
            this.commandBarStripElement1});
      // 
      // commandBarStripElement1
      // 
      this.commandBarStripElement1.DisplayName = "commandBarStripElement1";
      this.commandBarStripElement1.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.commandBarLabel1,
            this.btn_select_all,
            this.btn_select_none,
            this.btn_select_invert});
      this.commandBarStripElement1.Name = "commandBarStripElement1";
      // 
      // commandBarLabel1
      // 
      this.commandBarLabel1.AccessibleDescription = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Auswahl;
      this.commandBarLabel1.AccessibleName = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Auswahl;
      this.commandBarLabel1.DisplayName = "commandBarLabel1";
      this.commandBarLabel1.Name = "commandBarLabel1";
      this.commandBarLabel1.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Auswahl;
      // 
      // btn_select_all
      // 
      this.btn_select_all.AccessibleDescription = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Alle;
      this.btn_select_all.AccessibleName = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Alle;
      this.btn_select_all.DisplayName = "commandBarButton1";
      this.btn_select_all.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.select_all;
      this.btn_select_all.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
      this.btn_select_all.Name = "btn_select_all";
      this.btn_select_all.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Alle;
      this.btn_select_all.ToolTipText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.AlleAuswählen;
      this.btn_select_all.Click += new System.EventHandler(this.btn_select_all_Click);
      // 
      // btn_select_none
      // 
      this.btn_select_none.AccessibleDescription = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Keine;
      this.btn_select_none.AccessibleName = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Keine;
      this.btn_select_none.DisplayName = "commandBarButton2";
      this.btn_select_none.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.select_none;
      this.btn_select_none.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
      this.btn_select_none.Name = "btn_select_none";
      this.btn_select_none.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Keine;
      this.btn_select_none.ToolTipText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.AuswahlLöschen;
      this.btn_select_none.Click += new System.EventHandler(this.btn_select_none_Click);
      // 
      // btn_select_invert
      // 
      this.btn_select_invert.AccessibleDescription = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Invertieren;
      this.btn_select_invert.AccessibleName = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Invertieren;
      this.btn_select_invert.DisplayName = "commandBarButton3";
      this.btn_select_invert.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.select_invert;
      this.btn_select_invert.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
      this.btn_select_invert.Name = "btn_select_invert";
      this.btn_select_invert.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Invertieren;
      this.btn_select_invert.ToolTipText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.AuswahlInvertieren;
      this.btn_select_invert.Click += new System.EventHandler(this.btn_select_invert_Click);
      // 
      // btn_snapshot_make
      // 
      this.btn_snapshot_make.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.btn_snapshot_make.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.btn_snapshot_make.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.camera1;
      this.btn_snapshot_make.Location = new System.Drawing.Point(0, 181);
      this.btn_snapshot_make.Name = "btn_snapshot_make";
      this.btn_snapshot_make.Size = new System.Drawing.Size(386, 33);
      this.btn_snapshot_make.TabIndex = 1;
      this.btn_snapshot_make.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Html_SelectedTextsToSelection;
      this.btn_snapshot_make.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
      this.btn_snapshot_make.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btn_snapshot_make.Click += new System.EventHandler(this.btn_snapshot_make_Click);
      // 
      // splitPanel4
      // 
      this.splitPanel4.Controls.Add(this.elementHost1);
      this.splitPanel4.Location = new System.Drawing.Point(394, 0);
      this.splitPanel4.Name = "splitPanel4";
      // 
      // 
      // 
      this.splitPanel4.RootElement.MinSize = new System.Drawing.Size(0, 0);
      this.splitPanel4.Size = new System.Drawing.Size(386, 214);
      this.splitPanel4.TabIndex = 1;
      this.splitPanel4.TabStop = false;
      this.splitPanel4.Text = "splitPanel4";
      // 
      // elementHost1
      // 
      this.elementHost1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.elementHost1.Location = new System.Drawing.Point(0, 0);
      this.elementHost1.Name = "elementHost1";
      this.elementHost1.Size = new System.Drawing.Size(386, 214);
      this.elementHost1.TabIndex = 0;
      this.elementHost1.Text = "elementHost1";
      this.elementHost1.Child = null;
      // 
      // FulltextKwicSearch
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.Controls.Add(this.radSplitContainer1);
      this.Name = "FulltextKwicSearch";
      ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).EndInit();
      this.radSplitContainer1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).EndInit();
      this.splitPanel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.txt_query)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel1)).EndInit();
      this.clearPanel1.ResumeLayout(false);
      this.clearPanel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.cmb_layer)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).EndInit();
      this.splitPanel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer2)).EndInit();
      this.radSplitContainer2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel3)).EndInit();
      this.splitPanel3.ResumeLayout(false);
      this.splitPanel3.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.tree)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_snapshot_make)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel4)).EndInit();
      this.splitPanel4.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private Telerik.WinControls.UI.RadSplitContainer radSplitContainer1;
    private Telerik.WinControls.UI.SplitPanel splitPanel1;
    private Telerik.WinControls.UI.RadAutoCompleteBox txt_query;
    private ClearPanel clearPanel2;
    private ClearPanel clearPanel1;
    private Telerik.WinControls.UI.RadDropDownList cmb_layer;
    private Telerik.WinControls.UI.RadLabel radLabel1;
    private Telerik.WinControls.UI.SplitPanel splitPanel2;
    private Telerik.WinControls.UI.RadSplitContainer radSplitContainer2;
    private Telerik.WinControls.UI.SplitPanel splitPanel3;
    private Telerik.WinControls.UI.RadTreeView tree;
    private Telerik.WinControls.UI.SplitPanel splitPanel4;
    private System.Windows.Forms.Integration.ElementHost elementHost1;
    private Telerik.WinControls.UI.RadButton btn_snapshot_make;
    private Telerik.WinControls.UI.RadButton radButton1;
    private Telerik.WinControls.UI.RadCommandBar radCommandBar1;
    private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
    private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement1;
    private Telerik.WinControls.UI.CommandBarLabel commandBarLabel1;
    private Telerik.WinControls.UI.CommandBarButton btn_select_all;
    private Telerik.WinControls.UI.CommandBarButton btn_select_none;
    private Telerik.WinControls.UI.CommandBarButton btn_select_invert;
  }
}
