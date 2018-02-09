using CorpusExplorer.Terminal.WinForm.Properties;
using CorpusExplorer.Terminal.WinForm.Controls.WinForm;

namespace CorpusExplorer.Terminal.WinForm.View.Cooccurrence
{
  partial class CooccurrenceDiagram
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
      this.radCommandBar1 = new Telerik.WinControls.UI.RadCommandBar();
      this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
      this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
      this.btn_graph_new = new Telerik.WinControls.UI.CommandBarButton();
      this.btn_graph_save = new Telerik.WinControls.UI.CommandBarButton();
      this.commandBarDropDownButton1 = new Telerik.WinControls.UI.CommandBarDropDownButton();
      this.btn_export_gexf = new Telerik.WinControls.UI.RadMenuItem();
      this.btn_export_graphviz = new Telerik.WinControls.UI.RadMenuItem();
      this.btn_graph_load = new Telerik.WinControls.UI.CommandBarButton();
      this.commandBarDropDownButton2 = new Telerik.WinControls.UI.CommandBarDropDownButton();
      this.btn_layout_tree2 = new Telerik.WinControls.UI.RadMenuItem();
      this.btn_layout_network2 = new Telerik.WinControls.UI.RadMenuItem();
      this.clearPanel1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.ClearPanel();
      this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
      this.btn_request_metadata = new Telerik.WinControls.UI.RadButton();
      this.drop_meta = new Telerik.WinControls.UI.RadDropDownList();
      this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
      this.btn_request_kookkurrenz = new Telerik.WinControls.UI.RadButton();
      this.clearPanel2 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.ClearPanel();
      this.radSpinEditor1 = new Telerik.WinControls.UI.RadSpinEditor();
      this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
      this.txt_query = new Telerik.WinControls.UI.RadTextBox();
      this.radPageViewPage1 = new Telerik.WinControls.UI.RadPageViewPage();
      this.radPageViewPage2 = new Telerik.WinControls.UI.RadPageViewPage();
      this.page_node = new Telerik.WinControls.UI.RadPageView();
      this.pages = new Telerik.WinControls.UI.RadPageView();
      this.radPageView2 = new Telerik.WinControls.UI.RadPageView();
      this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
      this.simpleDiagram1 = new CorpusExplorer.Terminal.WinForm.Controls.Wpf.Diagram.WpfDiagram();
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel1)).BeginInit();
      this.clearPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
      this.radGroupBox2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.btn_request_metadata)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.drop_meta)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
      this.radGroupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.btn_request_kookkurrenz)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel2)).BeginInit();
      this.clearPanel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radSpinEditor1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_query)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.page_node)).BeginInit();
      this.page_node.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pages)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radPageView2)).BeginInit();
      this.SuspendLayout();
      // 
      // radCommandBar1
      // 
      this.radCommandBar1.Dock = System.Windows.Forms.DockStyle.Top;
      this.radCommandBar1.Location = new System.Drawing.Point(0, 0);
      this.radCommandBar1.Name = "radCommandBar1";
      this.radCommandBar1.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement1});
      this.radCommandBar1.Size = new System.Drawing.Size(780, 44);
      this.radCommandBar1.TabIndex = 0;
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
            this.btn_graph_new,
            this.btn_graph_save,
            this.commandBarDropDownButton1,
            this.btn_graph_load,
            this.commandBarDropDownButton2});
      this.commandBarStripElement1.Name = "commandBarStripElement1";
      // 
      // btn_graph_new
      // 
      this.btn_graph_new.AccessibleDescription = "commandBarButton1";
      this.btn_graph_new.AccessibleName = "commandBarButton1";
      this.btn_graph_new.DisplayName = "commandBarButton1";
      this.btn_graph_new.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.document;
      this.btn_graph_new.Name = "btn_graph_new";
      this.btn_graph_new.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
      this.btn_graph_new.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.NeuesDiagramm;
      this.btn_graph_new.ToolTipText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.NeuesDiagramm;
      this.btn_graph_new.Click += new System.EventHandler(this.btn_graph_new_Click);
      // 
      // btn_graph_save
      // 
      this.btn_graph_save.AccessibleDescription = "commandBarButton2";
      this.btn_graph_save.AccessibleName = "commandBarButton2";
      this.btn_graph_save.DisplayName = "commandBarButton2";
      this.btn_graph_save.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.save;
      this.btn_graph_save.Name = "btn_graph_save";
      this.btn_graph_save.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
      this.btn_graph_save.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.DiagrammSpeichern;
      this.btn_graph_save.ToolTipText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.DiagrammSpeichern;
      this.btn_graph_save.Click += new System.EventHandler(this.btn_graph_save_Click);
      // 
      // commandBarDropDownButton1
      // 
      this.commandBarDropDownButton1.AccessibleDescription = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Export;
      this.commandBarDropDownButton1.AccessibleName = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Export;
      this.commandBarDropDownButton1.DisplayName = "commandBarDropDownButton1";
      this.commandBarDropDownButton1.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.save_theme;
      this.commandBarDropDownButton1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.btn_export_gexf,
            this.btn_export_graphviz});
      this.commandBarDropDownButton1.Name = "commandBarDropDownButton1";
      this.commandBarDropDownButton1.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.DiagrammExportieren;
      this.commandBarDropDownButton1.ToolTipText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.DiagrammExportieren;
      // 
      // btn_export_gexf
      // 
      this.btn_export_gexf.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.save_theme;
      this.btn_export_gexf.Name = "btn_export_gexf";
      this.btn_export_gexf.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.AlsGEXFXMLExportieren;
      this.btn_export_gexf.Click += new System.EventHandler(this.btn_export_gexf_Click);
      // 
      // btn_export_graphviz
      // 
      this.btn_export_graphviz.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.save_theme;
      this.btn_export_graphviz.Name = "btn_export_graphviz";
      this.btn_export_graphviz.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.AlsGraphVizExportieren;
      this.btn_export_graphviz.Click += new System.EventHandler(this.btn_export_graphviz_Click);
      // 
      // btn_graph_load
      // 
      this.btn_graph_load.AccessibleDescription = "commandBarButton3";
      this.btn_graph_load.AccessibleName = "commandBarButton3";
      this.btn_graph_load.DisplayName = "commandBarButton3";
      this.btn_graph_load.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.folder;
      this.btn_graph_load.Name = "btn_graph_load";
      this.btn_graph_load.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
      this.btn_graph_load.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.DiagrammLaden;
      this.btn_graph_load.ToolTipText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.DiagrammLaden;
      this.btn_graph_load.Click += new System.EventHandler(this.btn_graph_load_Click);
      // 
      // commandBarDropDownButton2
      // 
      this.commandBarDropDownButton2.AccessibleDescription = "commandBarDropDownButton2";
      this.commandBarDropDownButton2.AccessibleName = "commandBarDropDownButton2";
      this.commandBarDropDownButton2.DisplayName = "commandBarDropDownButton2";
      this.commandBarDropDownButton2.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.diagram1;
      this.commandBarDropDownButton2.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.btn_layout_tree2,
            this.btn_layout_network2});
      this.commandBarDropDownButton2.Name = "commandBarDropDownButton2";
      this.commandBarDropDownButton2.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.DiagrammLayouten;
      this.commandBarDropDownButton2.ToolTipText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.DiagrammLayouten;
      // 
      // btn_layout_tree2
      // 
      this.btn_layout_tree2.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.diagram1;
      this.btn_layout_tree2.Name = "btn_layout_tree2";
      this.btn_layout_tree2.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.BaumLayout;
      this.btn_layout_tree2.Click += new System.EventHandler(this.btn_layout_tree_Click);
      // 
      // btn_layout_network2
      // 
      this.btn_layout_network2.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.diagram1;
      this.btn_layout_network2.Name = "btn_layout_network2";
      this.btn_layout_network2.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.NetzLayout;
      this.btn_layout_network2.Click += new System.EventHandler(this.btn_layout_network_Click);
      // 
      // clearPanel1
      // 
      this.clearPanel1.Controls.Add(this.radGroupBox2);
      this.clearPanel1.Controls.Add(this.radGroupBox1);
      this.clearPanel1.Dock = System.Windows.Forms.DockStyle.Right;
      this.clearPanel1.Location = new System.Drawing.Point(580, 44);
      this.clearPanel1.Name = "clearPanel1";
      this.clearPanel1.Padding = new System.Windows.Forms.Padding(3);
      this.clearPanel1.Size = new System.Drawing.Size(200, 356);
      this.clearPanel1.TabIndex = 2;
      // 
      // radGroupBox2
      // 
      this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox2.Controls.Add(this.btn_request_metadata);
      this.radGroupBox2.Controls.Add(this.drop_meta);
      this.radGroupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.radGroupBox2.HeaderText = "Metadaten";
      this.radGroupBox2.Location = new System.Drawing.Point(3, 259);
      this.radGroupBox2.Name = "radGroupBox2";
      this.radGroupBox2.Padding = new System.Windows.Forms.Padding(5, 25, 5, 5);
      this.radGroupBox2.Size = new System.Drawing.Size(194, 94);
      this.radGroupBox2.TabIndex = 7;
      this.radGroupBox2.Text = "Metadaten";
      // 
      // btn_request_metadata
      // 
      this.btn_request_metadata.Dock = System.Windows.Forms.DockStyle.Top;
      this.btn_request_metadata.Location = new System.Drawing.Point(5, 57);
      this.btn_request_metadata.Name = "btn_request_metadata";
      this.btn_request_metadata.Size = new System.Drawing.Size(184, 32);
      this.btn_request_metadata.TabIndex = 4;
      this.btn_request_metadata.Text = "Verknüpfen";
      this.btn_request_metadata.Click += new System.EventHandler(this.btn_request_metadata_Click);
      // 
      // drop_meta
      // 
      this.drop_meta.Dock = System.Windows.Forms.DockStyle.Top;
      this.drop_meta.Location = new System.Drawing.Point(5, 25);
      this.drop_meta.Name = "drop_meta";
      this.drop_meta.Size = new System.Drawing.Size(184, 32);
      this.drop_meta.TabIndex = 2;
      // 
      // radGroupBox1
      // 
      this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox1.Controls.Add(this.btn_request_kookkurrenz);
      this.radGroupBox1.Controls.Add(this.clearPanel2);
      this.radGroupBox1.Controls.Add(this.txt_query);
      this.radGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
      this.radGroupBox1.HeaderText = "Kookkurrenzen";
      this.radGroupBox1.Location = new System.Drawing.Point(3, 3);
      this.radGroupBox1.Name = "radGroupBox1";
      this.radGroupBox1.Padding = new System.Windows.Forms.Padding(5, 25, 5, 5);
      this.radGroupBox1.Size = new System.Drawing.Size(194, 129);
      this.radGroupBox1.TabIndex = 6;
      this.radGroupBox1.Text = "Kookkurrenzen";
      // 
      // btn_request_kookkurrenz
      // 
      this.btn_request_kookkurrenz.Dock = System.Windows.Forms.DockStyle.Top;
      this.btn_request_kookkurrenz.Location = new System.Drawing.Point(5, 92);
      this.btn_request_kookkurrenz.Name = "btn_request_kookkurrenz";
      this.btn_request_kookkurrenz.Size = new System.Drawing.Size(184, 32);
      this.btn_request_kookkurrenz.TabIndex = 1;
      this.btn_request_kookkurrenz.Text = "Hinzufügen";
      this.btn_request_kookkurrenz.Click += new System.EventHandler(this.btn_request_kookkurrenz_Click);
      // 
      // clearPanel2
      // 
      this.clearPanel2.Controls.Add(this.radSpinEditor1);
      this.clearPanel2.Controls.Add(this.radLabel2);
      this.clearPanel2.Dock = System.Windows.Forms.DockStyle.Top;
      this.clearPanel2.Location = new System.Drawing.Point(5, 57);
      this.clearPanel2.Name = "clearPanel2";
      this.clearPanel2.Size = new System.Drawing.Size(184, 35);
      this.clearPanel2.TabIndex = 5;
      // 
      // radSpinEditor1
      // 
      this.radSpinEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radSpinEditor1.Location = new System.Drawing.Point(61, 0);
      this.radSpinEditor1.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.radSpinEditor1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.radSpinEditor1.MinimumSize = new System.Drawing.Size(100, 0);
      this.radSpinEditor1.Name = "radSpinEditor1";
      this.radSpinEditor1.NullableValue = new decimal(new int[] {
            3,
            0,
            0,
            0});
      // 
      // 
      // 
      this.radSpinEditor1.RootElement.MinSize = new System.Drawing.Size(100, 0);
      this.radSpinEditor1.Size = new System.Drawing.Size(123, 32);
      this.radSpinEditor1.TabIndex = 1;
      this.radSpinEditor1.TabStop = false;
      this.radSpinEditor1.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
      // 
      // radLabel2
      // 
      this.radLabel2.AutoSize = false;
      this.radLabel2.Dock = System.Windows.Forms.DockStyle.Left;
      this.radLabel2.Location = new System.Drawing.Point(0, 0);
      this.radLabel2.Name = "radLabel2";
      this.radLabel2.Size = new System.Drawing.Size(61, 35);
      this.radLabel2.TabIndex = 0;
      this.radLabel2.Text = "Tiefe:";
      this.radLabel2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // txt_query
      // 
      this.txt_query.Dock = System.Windows.Forms.DockStyle.Top;
      this.txt_query.Location = new System.Drawing.Point(5, 25);
      this.txt_query.Name = "txt_query";
      this.txt_query.NullText = "Begriff hier eingeben...";
      this.txt_query.Size = new System.Drawing.Size(184, 32);
      this.txt_query.TabIndex = 0;
      // 
      // radPageViewPage1
      // 
      this.radPageViewPage1.Location = new System.Drawing.Point(5, 40);
      this.radPageViewPage1.Name = "radPageViewPage1";
      this.radPageViewPage1.Size = new System.Drawing.Size(184, 49);
      this.radPageViewPage1.Text = "radPageViewPage1";
      // 
      // radPageViewPage2
      // 
      this.radPageViewPage2.Location = new System.Drawing.Point(5, 40);
      this.radPageViewPage2.Name = "radPageViewPage2";
      this.radPageViewPage2.Size = new System.Drawing.Size(184, 49);
      this.radPageViewPage2.Text = "radPageViewPage2";
      // 
      // page_node
      // 
      this.page_node.Controls.Add(this.radPageViewPage1);
      this.page_node.Controls.Add(this.radPageViewPage2);
      this.page_node.Dock = System.Windows.Forms.DockStyle.Fill;
      this.page_node.Location = new System.Drawing.Point(3, 150);
      this.page_node.Name = "page_node";
      this.page_node.SelectedPage = this.radPageViewPage1;
      this.page_node.Size = new System.Drawing.Size(194, 94);
      this.page_node.TabIndex = 5;
      this.page_node.Text = "radPageView1";
      // 
      // pages
      // 
      this.pages.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pages.Location = new System.Drawing.Point(3, 150);
      this.pages.Name = "pages";
      this.pages.Size = new System.Drawing.Size(194, 94);
      this.pages.TabIndex = 5;
      this.pages.Text = "radPageView1";
      // 
      // radPageView2
      // 
      this.radPageView2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radPageView2.Location = new System.Drawing.Point(3, 150);
      this.radPageView2.Name = "radPageView2";
      this.radPageView2.Size = new System.Drawing.Size(194, 94);
      this.radPageView2.TabIndex = 5;
      this.radPageView2.Text = "radPageView2";
      // 
      // elementHost1
      // 
      this.elementHost1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.elementHost1.Location = new System.Drawing.Point(0, 44);
      this.elementHost1.Name = "elementHost1";
      this.elementHost1.Size = new System.Drawing.Size(580, 356);
      this.elementHost1.TabIndex = 3;
      this.elementHost1.Text = "elementHost1";
      this.elementHost1.Child = this.simpleDiagram1;
      // 
      // CooccurrenceDiagram
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.elementHost1);
      this.Controls.Add(this.clearPanel1);
      this.Controls.Add(this.radCommandBar1);
      this.Name = "CooccurrenceDiagram";
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel1)).EndInit();
      this.clearPanel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
      this.radGroupBox2.ResumeLayout(false);
      this.radGroupBox2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.btn_request_metadata)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.drop_meta)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
      this.radGroupBox1.ResumeLayout(false);
      this.radGroupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.btn_request_kookkurrenz)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel2)).EndInit();
      this.clearPanel2.ResumeLayout(false);
      this.clearPanel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radSpinEditor1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_query)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.page_node)).EndInit();
      this.page_node.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.pages)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radPageView2)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Telerik.WinControls.UI.RadCommandBar radCommandBar1;
    private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
    private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement1;
    private Telerik.WinControls.UI.CommandBarButton btn_graph_new;
    private Telerik.WinControls.UI.CommandBarButton btn_graph_save;
    private Telerik.WinControls.UI.CommandBarButton btn_graph_load;
    private ClearPanel clearPanel1;
    private Telerik.WinControls.UI.RadButton btn_request_metadata;
    private Telerik.WinControls.UI.RadDropDownList drop_meta;
    private Telerik.WinControls.UI.RadButton btn_request_kookkurrenz;
    private Telerik.WinControls.UI.RadTextBox txt_query;
    private Telerik.WinControls.UI.CommandBarDropDownButton commandBarDropDownButton1;
    private Telerik.WinControls.UI.RadMenuItem btn_export_gexf;
    private Telerik.WinControls.UI.RadMenuItem btn_export_graphviz;
    private Telerik.WinControls.UI.CommandBarDropDownButton commandBarDropDownButton2;
    private Telerik.WinControls.UI.RadMenuItem btn_layout_tree2;
    private Telerik.WinControls.UI.RadMenuItem btn_layout_network2;
    private Telerik.WinControls.UI.RadPageViewPage radPageViewPage1;
    private Telerik.WinControls.UI.RadPageViewPage radPageViewPage2;
    private Telerik.WinControls.UI.RadPageView page_node;
    private Telerik.WinControls.UI.RadPageView pages;
    private Telerik.WinControls.UI.RadPageView radPageView2;

    private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
    private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
    private ClearPanel clearPanel2;
    private Telerik.WinControls.UI.RadSpinEditor radSpinEditor1;
    private Telerik.WinControls.UI.RadLabel radLabel2;
    private System.Windows.Forms.Integration.ElementHost elementHost1;
    private Controls.Wpf.Diagram.WpfDiagram simpleDiagram1;
  }
}
