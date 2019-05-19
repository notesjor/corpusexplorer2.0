using CorpusExplorer.Terminal.WinForm.Properties;
using CorpusExplorer.Terminal.WinForm.Controls.WinForm;

namespace CorpusExplorer.Terminal.WinForm.View.Fulltext
{
  partial class FulltextKwicTree
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FulltextKwicTree));
      this.radSplitContainer1 = new Telerik.WinControls.UI.RadSplitContainer();
      this.splitPanel1 = new Telerik.WinControls.UI.SplitPanel();
      this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
      this.wordBag1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.WordBag();
      this.radCommandBar1 = new Telerik.WinControls.UI.RadCommandBar();
      this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
      this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
      this.commandBarButton1 = new Telerik.WinControls.UI.CommandBarButton();
      this.commandBarButton2 = new Telerik.WinControls.UI.CommandBarButton();
      this.commandBarDropDownButton1 = new Telerik.WinControls.UI.CommandBarDropDownButton();
      this.btn_export_gexf = new Telerik.WinControls.UI.RadMenuItem();
      this.btn_export_graphviz = new Telerik.WinControls.UI.RadMenuItem();
      this.commandBarButton3 = new Telerik.WinControls.UI.CommandBarButton();
      this.commandBarDropDownButton2 = new Telerik.WinControls.UI.CommandBarDropDownButton();
      this.btn_layout_tree = new Telerik.WinControls.UI.RadMenuItem();
      this.btn_layout_net = new Telerik.WinControls.UI.RadMenuItem();
      this.webHtml5Visualisation1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.Webbrowser.WebHtml5Visualisation();
      this.btn_export_graphml = new Telerik.WinControls.UI.RadMenuItem();
      this.btn_export_csv = new Telerik.WinControls.UI.RadMenuItem();
      ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).BeginInit();
      this.radSplitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).BeginInit();
      this.splitPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
      this.SuspendLayout();
      // 
      // radSplitContainer1
      // 
      this.radSplitContainer1.Controls.Add(this.splitPanel1);
      resources.ApplyResources(this.radSplitContainer1, "radSplitContainer1");
      this.radSplitContainer1.Name = "radSplitContainer1";
      // 
      // 
      // 
      this.radSplitContainer1.RootElement.MinSize = new System.Drawing.Size(0, 0);
      this.radSplitContainer1.TabStop = false;
      // 
      // splitPanel1
      // 
      this.splitPanel1.Controls.Add(this.elementHost1);
      this.splitPanel1.Controls.Add(this.wordBag1);
      this.splitPanel1.Controls.Add(this.radCommandBar1);
      this.splitPanel1.Controls.Add(this.webHtml5Visualisation1);
      resources.ApplyResources(this.splitPanel1, "splitPanel1");
      this.splitPanel1.Name = "splitPanel1";
      // 
      // 
      // 
      this.splitPanel1.RootElement.MinSize = new System.Drawing.Size(0, 0);
      this.splitPanel1.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(0F, -0.3131313F);
      this.splitPanel1.SizeInfo.SplitterCorrection = new System.Drawing.Size(0, -117);
      this.splitPanel1.TabStop = false;
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
            this.commandBarButton1,
            this.commandBarButton2,
            this.commandBarDropDownButton1,
            this.commandBarButton3,
            this.commandBarDropDownButton2});
      this.commandBarStripElement1.Name = "commandBarStripElement1";
      // 
      // commandBarButton1
      // 
      this.commandBarButton1.AutoToolTip = true;
      resources.ApplyResources(this.commandBarButton1, "commandBarButton1");
      this.commandBarButton1.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.document;
      this.commandBarButton1.Name = "commandBarButton1";
      this.commandBarButton1.Click += new System.EventHandler(this.commandBarButton1_Click);
      // 
      // commandBarButton2
      // 
      this.commandBarButton2.AutoToolTip = true;
      resources.ApplyResources(this.commandBarButton2, "commandBarButton2");
      this.commandBarButton2.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.save;
      this.commandBarButton2.Name = "commandBarButton2";
      this.commandBarButton2.Click += new System.EventHandler(this.commandBarButton2_Click);
      // 
      // commandBarDropDownButton1
      // 
      resources.ApplyResources(this.commandBarDropDownButton1, "commandBarDropDownButton1");
      this.commandBarDropDownButton1.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.save_theme;
      this.commandBarDropDownButton1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.btn_export_gexf,
            this.btn_export_graphviz,
            this.btn_export_graphml,
            this.btn_export_csv});
      this.commandBarDropDownButton1.Name = "commandBarDropDownButton1";
      // 
      // btn_export_gexf
      // 
      this.btn_export_gexf.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.save_theme;
      this.btn_export_gexf.Name = "btn_export_gexf";
      resources.ApplyResources(this.btn_export_gexf, "btn_export_gexf");
      this.btn_export_gexf.Click += new System.EventHandler(this.btn_export_gexf_Click);
      // 
      // btn_export_graphviz
      // 
      this.btn_export_graphviz.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.save_theme;
      this.btn_export_graphviz.Name = "btn_export_graphviz";
      resources.ApplyResources(this.btn_export_graphviz, "btn_export_graphviz");
      this.btn_export_graphviz.Click += new System.EventHandler(this.btn_export_graphviz_Click);
      // 
      // commandBarButton3
      // 
      this.commandBarButton3.AutoToolTip = true;
      resources.ApplyResources(this.commandBarButton3, "commandBarButton3");
      this.commandBarButton3.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.folder_open;
      this.commandBarButton3.Name = "commandBarButton3";
      this.commandBarButton3.Click += new System.EventHandler(this.commandBarButton3_Click);
      // 
      // commandBarDropDownButton2
      // 
      resources.ApplyResources(this.commandBarDropDownButton2, "commandBarDropDownButton2");
      this.commandBarDropDownButton2.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.diagram1;
      this.commandBarDropDownButton2.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.btn_layout_tree,
            this.btn_layout_net});
      this.commandBarDropDownButton2.Name = "commandBarDropDownButton2";
      this.commandBarDropDownButton2.Click += new System.EventHandler(this.commandBarDropDownButton2_Click);
      // 
      // btn_layout_tree
      // 
      this.btn_layout_tree.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.diagram1;
      this.btn_layout_tree.Name = "btn_layout_tree";
      resources.ApplyResources(this.btn_layout_tree, "btn_layout_tree");
      this.btn_layout_tree.Click += new System.EventHandler(this.btn_layout_tree_Click);
      // 
      // btn_layout_net
      // 
      this.btn_layout_net.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.diagram1;
      this.btn_layout_net.Name = "btn_layout_net";
      resources.ApplyResources(this.btn_layout_net, "btn_layout_net");
      this.btn_layout_net.Click += new System.EventHandler(this.btn_layout_net_Click);
      // 
      // webHtml5Visualisation1
      // 
      this.webHtml5Visualisation1.BackColor = System.Drawing.Color.White;
      resources.ApplyResources(this.webHtml5Visualisation1, "webHtml5Visualisation1");
      this.webHtml5Visualisation1.MainpageUrl = null;
      this.webHtml5Visualisation1.Name = "webHtml5Visualisation1";
      this.webHtml5Visualisation1.TemplateVars = ((System.Collections.Generic.Dictionary<string, string>)(resources.GetObject("webHtml5Visualisation1.TemplateVars")));
      // 
      // btn_export_graphml
      // 
      this.btn_export_graphml.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.save_theme;
      this.btn_export_graphml.Name = "btn_export_graphml";
      resources.ApplyResources(this.btn_export_graphml, "btn_export_graphml");
      this.btn_export_graphml.Click += new System.EventHandler(this.btn_export_graphml_Click);
      // 
      // btn_export_csv
      // 
      this.btn_export_csv.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.save_theme;
      this.btn_export_csv.Name = "btn_export_csv";
      resources.ApplyResources(this.btn_export_csv, "btn_export_csv");
      this.btn_export_csv.Click += new System.EventHandler(this.btn_export_csv_Click);
      // 
      // FulltextKwicTree
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.Controls.Add(this.radSplitContainer1);
      this.Name = "FulltextKwicTree";
      ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).EndInit();
      this.radSplitContainer1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).EndInit();
      this.splitPanel1.ResumeLayout(false);
      this.splitPanel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private Telerik.WinControls.UI.RadSplitContainer radSplitContainer1;
    private Telerik.WinControls.UI.SplitPanel splitPanel1;
    private Controls.WinForm.Webbrowser.WebHtml5Visualisation webHtml5Visualisation1;
    private System.Windows.Forms.Integration.ElementHost elementHost1;
  
    private Telerik.WinControls.UI.RadCommandBar radCommandBar1;
    private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
    private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement1;
    private Telerik.WinControls.UI.CommandBarButton commandBarButton1;
    private Telerik.WinControls.UI.CommandBarButton commandBarButton2;
    private Telerik.WinControls.UI.CommandBarDropDownButton commandBarDropDownButton1;
    private Telerik.WinControls.UI.CommandBarButton commandBarButton3;
    private Telerik.WinControls.UI.CommandBarDropDownButton commandBarDropDownButton2;
    private Telerik.WinControls.UI.RadMenuItem btn_export_gexf;
    private Telerik.WinControls.UI.RadMenuItem btn_export_graphviz;
    private WordBag wordBag1;
    private Telerik.WinControls.UI.RadMenuItem btn_layout_tree;
    private Telerik.WinControls.UI.RadMenuItem btn_layout_net;
    private Telerik.WinControls.UI.RadMenuItem btn_export_graphml;
    private Telerik.WinControls.UI.RadMenuItem btn_export_csv;
  }
}
