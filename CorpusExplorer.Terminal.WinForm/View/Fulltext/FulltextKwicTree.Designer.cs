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
      this.wpfDiagram1 = new CorpusExplorer.Terminal.WinForm.Controls.Wpf.Diagram.WpfDiagram();
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
      this.webHtml5Visualisation1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.Webbrowser.WebHtml5Visualisation();
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
      // 
      // splitPanel1
      // 
      this.splitPanel1.Controls.Add(this.elementHost1);
      this.splitPanel1.Controls.Add(this.wordBag1);
      this.splitPanel1.Controls.Add(this.radCommandBar1);
      this.splitPanel1.Controls.Add(this.webHtml5Visualisation1);
      this.splitPanel1.Location = new System.Drawing.Point(0, 0);
      this.splitPanel1.Name = "splitPanel1";
      // 
      // 
      // 
      this.splitPanel1.RootElement.MinSize = new System.Drawing.Size(0, 0);
      this.splitPanel1.Size = new System.Drawing.Size(780, 400);
      this.splitPanel1.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(0F, -0.3131313F);
      this.splitPanel1.SizeInfo.SplitterCorrection = new System.Drawing.Size(0, -117);
      this.splitPanel1.TabIndex = 0;
      this.splitPanel1.TabStop = false;
      this.splitPanel1.Text = "splitPanel1";
      // 
      // elementHost1
      // 
      this.elementHost1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.elementHost1.Location = new System.Drawing.Point(0, 80);
      this.elementHost1.Name = "elementHost1";
      this.elementHost1.Size = new System.Drawing.Size(780, 320);
      this.elementHost1.TabIndex = 4;
      this.elementHost1.Text = "elementHost1";
      this.elementHost1.Child = this.wpfDiagram1;
      // 
      // wordBag1
      // 
      this.wordBag1.BackColor = System.Drawing.Color.White;
      this.wordBag1.Dock = System.Windows.Forms.DockStyle.Top;
      this.wordBag1.Font = new System.Drawing.Font("Segoe UI", 11F);
      this.wordBag1.Location = new System.Drawing.Point(0, 44);
      this.wordBag1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
      this.wordBag1.Name = "wordBag1";
      this.wordBag1.ResultQueries = new string[0];
      this.wordBag1.ResultSelectedLayerDisplayname = "Wort";
      this.wordBag1.Size = new System.Drawing.Size(780, 36);
      this.wordBag1.TabIndex = 6;
      this.wordBag1.ExecuteButtonClicked += new System.EventHandler(this.wordBag1_ExecuteButtonClicked);
      // 
      // radCommandBar1
      // 
      this.radCommandBar1.Dock = System.Windows.Forms.DockStyle.Top;
      this.radCommandBar1.Location = new System.Drawing.Point(0, 0);
      this.radCommandBar1.Name = "radCommandBar1";
      this.radCommandBar1.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement1});
      this.radCommandBar1.Size = new System.Drawing.Size(780, 44);
      this.radCommandBar1.TabIndex = 5;
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
      this.commandBarButton1.DisplayName = "commandBarButton1";
      this.commandBarButton1.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.document;
      this.commandBarButton1.Name = "commandBarButton1";
      this.commandBarButton1.Text = "commandBarButton1";
      this.commandBarButton1.Click += new System.EventHandler(this.commandBarButton1_Click);
      // 
      // commandBarButton2
      // 
      this.commandBarButton2.DisplayName = "commandBarButton2";
      this.commandBarButton2.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.save;
      this.commandBarButton2.Name = "commandBarButton2";
      this.commandBarButton2.Text = "commandBarButton2";
      this.commandBarButton2.Click += new System.EventHandler(this.commandBarButton2_Click);
      // 
      // commandBarDropDownButton1
      // 
      this.commandBarDropDownButton1.DisplayName = "commandBarDropDownButton1";
      this.commandBarDropDownButton1.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.save_theme;
      this.commandBarDropDownButton1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.btn_export_gexf,
            this.btn_export_graphviz});
      this.commandBarDropDownButton1.Name = "commandBarDropDownButton1";
      this.commandBarDropDownButton1.Text = "Exportieren";
      // 
      // btn_export_gexf
      // 
      this.btn_export_gexf.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.save_theme;
      this.btn_export_gexf.Name = "btn_export_gexf";
      this.btn_export_gexf.Text = "Als GEXF-XML exportieren";
      this.btn_export_gexf.Click += new System.EventHandler(this.btn_export_gexf_Click);
      // 
      // btn_export_graphviz
      // 
      this.btn_export_graphviz.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.save_theme;
      this.btn_export_graphviz.Name = "btn_export_graphviz";
      this.btn_export_graphviz.Text = "Als GraphViz exportieren";
      this.btn_export_graphviz.Click += new System.EventHandler(this.btn_export_graphviz_Click);
      // 
      // commandBarButton3
      // 
      this.commandBarButton3.DisplayName = "commandBarButton3";
      this.commandBarButton3.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.folder_open;
      this.commandBarButton3.Name = "commandBarButton3";
      this.commandBarButton3.Text = "commandBarButton3";
      this.commandBarButton3.Click += new System.EventHandler(this.commandBarButton3_Click);
      // 
      // commandBarDropDownButton2
      // 
      this.commandBarDropDownButton2.DisplayName = "commandBarDropDownButton2";
      this.commandBarDropDownButton2.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.diagram1;
      this.commandBarDropDownButton2.Name = "commandBarDropDownButton2";
      this.commandBarDropDownButton2.Text = "commandBarDropDownButton2";
      // 
      // webHtml5Visualisation1
      // 
      this.webHtml5Visualisation1.BackColor = System.Drawing.Color.White;
      this.webHtml5Visualisation1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.webHtml5Visualisation1.Location = new System.Drawing.Point(0, 0);
      this.webHtml5Visualisation1.MainpageUrl = null;
      this.webHtml5Visualisation1.Name = "webHtml5Visualisation1";
      this.webHtml5Visualisation1.Size = new System.Drawing.Size(780, 400);
      this.webHtml5Visualisation1.TabIndex = 3;
      this.webHtml5Visualisation1.TemplateVars = ((System.Collections.Generic.Dictionary<string, string>)(resources.GetObject("webHtml5Visualisation1.TemplateVars")));
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
    private Controls.Wpf.Diagram.WpfDiagram wpfDiagram1;
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
  }
}
