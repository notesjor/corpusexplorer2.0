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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CooccurrenceDiagram));
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
      this.radPageViewPage1 = new Telerik.WinControls.UI.RadPageViewPage();
      this.radPageViewPage2 = new Telerik.WinControls.UI.RadPageViewPage();
      this.page_node = new Telerik.WinControls.UI.RadPageView();
      this.pages = new Telerik.WinControls.UI.RadPageView();
      this.radPageView2 = new Telerik.WinControls.UI.RadPageView();
      this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
      this.wordBag1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.WordBag();
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.page_node)).BeginInit();
      this.page_node.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pages)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radPageView2)).BeginInit();
      this.SuspendLayout();
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
      this.btn_graph_new.AutoToolTip = true;
      resources.ApplyResources(this.btn_graph_new, "btn_graph_new");
      this.btn_graph_new.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.document;
      this.btn_graph_new.Name = "btn_graph_new";
      this.btn_graph_new.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.NeuesDiagramm;
      this.btn_graph_new.ToolTipText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.NeuesDiagramm;
      this.btn_graph_new.Click += new System.EventHandler(this.btn_graph_new_Click);
      // 
      // btn_graph_save
      // 
      this.btn_graph_save.AccessibleDescription = "commandBarButton2";
      this.btn_graph_save.AccessibleName = "commandBarButton2";
      this.btn_graph_save.AutoToolTip = true;
      resources.ApplyResources(this.btn_graph_save, "btn_graph_save");
      this.btn_graph_save.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.save;
      this.btn_graph_save.Name = "btn_graph_save";
      this.btn_graph_save.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.DiagrammSpeichern;
      this.btn_graph_save.ToolTipText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.DiagrammSpeichern;
      this.btn_graph_save.Click += new System.EventHandler(this.btn_graph_save_Click);
      // 
      // commandBarDropDownButton1
      // 
      this.commandBarDropDownButton1.AccessibleDescription = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Export;
      this.commandBarDropDownButton1.AccessibleName = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Export;
      resources.ApplyResources(this.commandBarDropDownButton1, "commandBarDropDownButton1");
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
      this.btn_graph_load.AutoToolTip = true;
      resources.ApplyResources(this.btn_graph_load, "btn_graph_load");
      this.btn_graph_load.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.folder;
      this.btn_graph_load.Name = "btn_graph_load";
      this.btn_graph_load.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.DiagrammLaden;
      this.btn_graph_load.ToolTipText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.DiagrammLaden;
      this.btn_graph_load.Click += new System.EventHandler(this.btn_graph_load_Click);
      // 
      // commandBarDropDownButton2
      // 
      this.commandBarDropDownButton2.AccessibleDescription = "commandBarDropDownButton2";
      this.commandBarDropDownButton2.AccessibleName = "commandBarDropDownButton2";
      resources.ApplyResources(this.commandBarDropDownButton2, "commandBarDropDownButton2");
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
      // radPageViewPage1
      // 
      resources.ApplyResources(this.radPageViewPage1, "radPageViewPage1");
      this.radPageViewPage1.Name = "radPageViewPage1";
      // 
      // radPageViewPage2
      // 
      resources.ApplyResources(this.radPageViewPage2, "radPageViewPage2");
      this.radPageViewPage2.Name = "radPageViewPage2";
      // 
      // page_node
      // 
      this.page_node.Controls.Add(this.radPageViewPage1);
      this.page_node.Controls.Add(this.radPageViewPage2);
      resources.ApplyResources(this.page_node, "page_node");
      this.page_node.Name = "page_node";
      this.page_node.SelectedPage = this.radPageViewPage1;
      // 
      // pages
      // 
      resources.ApplyResources(this.pages, "pages");
      this.pages.Name = "pages";
      // 
      // radPageView2
      // 
      resources.ApplyResources(this.radPageView2, "radPageView2");
      this.radPageView2.Name = "radPageView2";
      // 
      // elementHost1
      // 
      resources.ApplyResources(this.elementHost1, "elementHost1");
      this.elementHost1.Name = "elementHost1";
      this.elementHost1.Child = null;
      // 
      // wordBag1
      // 
      this.wordBag1.BackColor = System.Drawing.Color.White;
      resources.ApplyResources(this.wordBag1, "wordBag1");
      this.wordBag1.Name = "wordBag1";
      this.wordBag1.ResultQueries = new string[0];
      this.wordBag1.ResultSelectedLayerDisplayname = null;
      this.wordBag1.ExecuteButtonClicked += new System.EventHandler(this.wordBag1_ExecuteButtonClicked);
      // 
      // CooccurrenceDiagram
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.Controls.Add(this.elementHost1);
      this.Controls.Add(this.wordBag1);
      this.Controls.Add(this.radCommandBar1);
      this.Name = "CooccurrenceDiagram";
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
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
    private System.Windows.Forms.Integration.ElementHost elementHost1;    
    private WordBag wordBag1;
  }
}
