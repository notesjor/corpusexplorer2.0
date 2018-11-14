using CorpusExplorer.Terminal.WinForm.Properties;
namespace CorpusExplorer.Terminal.WinForm.View.Ngram
{
  partial class NGramDiagram
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NGramDiagram));
      this.radCommandBar1 = new Telerik.WinControls.UI.RadCommandBar();
      this.commandBarRowElement2 = new Telerik.WinControls.UI.CommandBarRowElement();
      this.commandBarStripElement3 = new Telerik.WinControls.UI.CommandBarStripElement();
      this.btn_layer = new Telerik.WinControls.UI.CommandBarButton();
      this.commandBarLabel2 = new Telerik.WinControls.UI.CommandBarLabel();
      this.txt_size = new Telerik.WinControls.UI.CommandBarTextBox();
      this.commandBarLabel3 = new Telerik.WinControls.UI.CommandBarLabel();
      this.txt_pattern = new Telerik.WinControls.UI.CommandBarTextBox();
      this.commandBarLabel1 = new Telerik.WinControls.UI.CommandBarLabel();
      this.txt_max = new Telerik.WinControls.UI.CommandBarTextBox();
      this.commandBarButton1 = new Telerik.WinControls.UI.CommandBarButton();
      this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
      this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
      this.commandBarButton2 = new Telerik.WinControls.UI.CommandBarButton();
      this.btn_save = new Telerik.WinControls.UI.CommandBarButton();
      this.commandBarDropDownButton3 = new Telerik.WinControls.UI.CommandBarDropDownButton();
      this.btn_export_graphviz = new Telerik.WinControls.UI.RadMenuItem();
      this.btn_export_gexf = new Telerik.WinControls.UI.RadMenuItem();
      this.commandBarButton4 = new Telerik.WinControls.UI.CommandBarButton();
      this.commandBarDropDownButton1 = new Telerik.WinControls.UI.CommandBarDropDownButton();
      this.btn_layout_default = new Telerik.WinControls.UI.RadMenuItem();
      this.btn_layout_tree = new Telerik.WinControls.UI.RadMenuItem();
      this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
      this.simpleDiagram1 = new CorpusExplorer.Terminal.WinForm.Controls.Wpf.Diagram.WpfDiagram();
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
      this.SuspendLayout();
      // 
      // radCommandBar1
      // 
      this.radCommandBar1.Dock = System.Windows.Forms.DockStyle.Top;
      this.radCommandBar1.Location = new System.Drawing.Point(0, 0);
      this.radCommandBar1.Name = "radCommandBar1";
      this.radCommandBar1.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement1,
            this.commandBarRowElement2});
      this.radCommandBar1.Size = new System.Drawing.Size(780, 85);
      this.radCommandBar1.TabIndex = 0;
      // 
      // commandBarRowElement2
      // 
      this.commandBarRowElement2.MinSize = new System.Drawing.Size(25, 25);
      this.commandBarRowElement2.Name = "commandBarRowElement2";
      this.commandBarRowElement2.Strips.AddRange(new Telerik.WinControls.UI.CommandBarStripElement[] {
            this.commandBarStripElement3});
      // 
      // commandBarStripElement3
      // 
      this.commandBarStripElement3.DisplayName = "commandBarStripElement3";
      this.commandBarStripElement3.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.btn_layer,
            this.commandBarLabel2,
            this.txt_size,
            this.commandBarLabel3,
            this.txt_pattern,
            this.commandBarLabel1,
            this.txt_max,
            this.commandBarButton1});
      this.commandBarStripElement3.Name = "commandBarStripElement3";
      // 
      // btn_layer
      // 
      this.btn_layer.DisplayName = "commandBarButton3";
      this.btn_layer.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.layers;
      this.btn_layer.Name = "btn_layer";
      this.btn_layer.Text = "Layer auswählen";
      this.btn_layer.Click += new System.EventHandler(this.btn_layer_Click);
      // 
      // commandBarLabel2
      // 
      this.commandBarLabel2.DisplayName = "commandBarLabel2";
      this.commandBarLabel2.Name = "commandBarLabel2";
      this.commandBarLabel2.Text = "NGram-Größe:";
      // 
      // txt_size
      // 
      this.txt_size.AccessibleDescription = "3";
      this.txt_size.AccessibleName = "3";
      this.txt_size.DisplayName = "commandBarTextBox1";
      this.txt_size.Name = "txt_size";
      this.txt_size.Text = "5";
      // 
      // commandBarLabel3
      // 
      this.commandBarLabel3.DisplayName = "commandBarLabel3";
      this.commandBarLabel3.Name = "commandBarLabel3";
      this.commandBarLabel3.Text = "Musteranzahl:";
      // 
      // txt_pattern
      // 
      this.txt_pattern.DisplayName = "commandBarTextBox2";
      this.txt_pattern.Name = "txt_pattern";
      this.txt_pattern.Text = "0";
      // 
      // commandBarLabel1
      // 
      this.commandBarLabel1.DisplayName = "commandBarLabel1";
      this.commandBarLabel1.Name = "commandBarLabel1";
      this.commandBarLabel1.Text = "Top:";
      // 
      // txt_max
      // 
      this.txt_max.DisplayName = "commandBarTextBox1";
      this.txt_max.Name = "txt_max";
      this.txt_max.Text = "100";
      // 
      // commandBarButton1
      // 
      this.commandBarButton1.DisplayName = "commandBarButton1";
      this.commandBarButton1.Image = ((System.Drawing.Image)(resources.GetObject("commandBarButton1.Image")));
      this.commandBarButton1.Name = "commandBarButton1";
      this.commandBarButton1.Text = "Ausführen";
      this.commandBarButton1.Click += new System.EventHandler(this.commandBarButton1_Click);
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
            this.commandBarButton2,
            this.btn_save,
            this.commandBarDropDownButton3,
            this.commandBarButton4,
            this.commandBarDropDownButton1});
      this.commandBarStripElement1.Name = "commandBarStripElement1";
      // 
      // commandBarButton2
      // 
      this.commandBarButton2.DisplayName = "commandBarButton2";
      this.commandBarButton2.Image = ((System.Drawing.Image)(resources.GetObject("commandBarButton2.Image")));
      this.commandBarButton2.Name = "commandBarButton2";
      this.commandBarButton2.Text = "Neu";
      this.commandBarButton2.Click += new System.EventHandler(this.commandBarButton2_Click);
      // 
      // btn_save
      // 
      this.btn_save.DisplayName = "commandBarButton1";
      this.btn_save.Image = ((System.Drawing.Image)(resources.GetObject("btn_save.Image")));
      this.btn_save.Name = "btn_save";
      this.btn_save.Text = "Speichern";
      this.btn_save.ToolTipText = "Diagramm speichern";
      this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
      // 
      // commandBarDropDownButton3
      // 
      this.commandBarDropDownButton3.DisplayName = "commandBarDropDownButton3";
      this.commandBarDropDownButton3.Image = ((System.Drawing.Image)(resources.GetObject("commandBarDropDownButton3.Image")));
      this.commandBarDropDownButton3.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.btn_export_graphviz,
            this.btn_export_gexf});
      this.commandBarDropDownButton3.Name = "commandBarDropDownButton3";
      this.commandBarDropDownButton3.Text = "Exportieren";
      this.commandBarDropDownButton3.ToolTipText = "Diagramm exportieren";
      // 
      // btn_export_graphviz
      // 
      this.btn_export_graphviz.Image = ((System.Drawing.Image)(resources.GetObject("btn_export_graphviz.Image")));
      this.btn_export_graphviz.Name = "btn_export_graphviz";
      this.btn_export_graphviz.Text = "Als GraphViz exportieren";
      this.btn_export_graphviz.Click += new System.EventHandler(this.btn_export_graphviz_Click);
      // 
      // btn_export_gexf
      // 
      this.btn_export_gexf.Image = ((System.Drawing.Image)(resources.GetObject("btn_export_gexf.Image")));
      this.btn_export_gexf.Name = "btn_export_gexf";
      this.btn_export_gexf.Text = "Als GEXF-XML exportieren";
      this.btn_export_gexf.Click += new System.EventHandler(this.btn_export_gexf_Click);
      // 
      // commandBarButton4
      // 
      this.commandBarButton4.DisplayName = "commandBarButton4";
      this.commandBarButton4.Image = ((System.Drawing.Image)(resources.GetObject("commandBarButton4.Image")));
      this.commandBarButton4.Name = "commandBarButton4";
      this.commandBarButton4.Text = "Laden";
      this.commandBarButton4.Click += new System.EventHandler(this.commandBarButton4_Click);
      // 
      // commandBarDropDownButton1
      // 
      this.commandBarDropDownButton1.DisplayName = "commandBarDropDownButton1";
      this.commandBarDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("commandBarDropDownButton1.Image")));
      this.commandBarDropDownButton1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.btn_layout_default,
            this.btn_layout_tree});
      this.commandBarDropDownButton1.Name = "commandBarDropDownButton1";
      this.commandBarDropDownButton1.Text = "Layout";
      this.commandBarDropDownButton1.ToolTipText = "Diagramm layouten";
      // 
      // btn_layout_default
      // 
      this.btn_layout_default.Image = ((System.Drawing.Image)(resources.GetObject("btn_layout_default.Image")));
      this.btn_layout_default.Name = "btn_layout_default";
      this.btn_layout_default.Text = "Netzwerk-Layout";
      this.btn_layout_default.Click += new System.EventHandler(this.btn_layout_network_Click);
      // 
      // btn_layout_tree
      // 
      this.btn_layout_tree.Image = ((System.Drawing.Image)(resources.GetObject("btn_layout_tree.Image")));
      this.btn_layout_tree.Name = "btn_layout_tree";
      this.btn_layout_tree.Text = "Baum-Layout";
      this.btn_layout_tree.Click += new System.EventHandler(this.btn_layout_tree_Click);
      // 
      // elementHost1
      // 
      this.elementHost1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.elementHost1.Location = new System.Drawing.Point(0, 85);
      this.elementHost1.Name = "elementHost1";
      this.elementHost1.Size = new System.Drawing.Size(780, 315);
      this.elementHost1.TabIndex = 1;
      this.elementHost1.Text = "elementHost1";
      this.elementHost1.Child = this.simpleDiagram1;
      // 
      // NGramDiagram
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.Controls.Add(this.elementHost1);
      this.Controls.Add(this.radCommandBar1);
      this.Name = "NGramDiagram";
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Telerik.WinControls.UI.RadCommandBar radCommandBar1;
    private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement2;
    private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement3;
    private Telerik.WinControls.UI.CommandBarLabel commandBarLabel2;
    private Telerik.WinControls.UI.CommandBarTextBox txt_size;
    private Telerik.WinControls.UI.CommandBarLabel commandBarLabel3;
    private Telerik.WinControls.UI.CommandBarTextBox txt_pattern;
    private Telerik.WinControls.UI.CommandBarDropDownButton commandBarDropDownButton1;
    private Telerik.WinControls.UI.RadMenuItem btn_layout_tree;
    private Telerik.WinControls.UI.RadMenuItem btn_layout_default;
    private Telerik.WinControls.UI.CommandBarLabel commandBarLabel1;
    private Telerik.WinControls.UI.CommandBarTextBox txt_max;
    private Telerik.WinControls.UI.CommandBarButton btn_save;
    private Telerik.WinControls.UI.CommandBarDropDownButton commandBarDropDownButton3;
    private Telerik.WinControls.UI.RadMenuItem btn_export_graphviz;
    private Telerik.WinControls.UI.RadMenuItem btn_export_gexf;
    private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
    private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement1;
    private System.Windows.Forms.Integration.ElementHost elementHost1;
    private Controls.Wpf.Diagram.WpfDiagram simpleDiagram1;
    private Telerik.WinControls.UI.CommandBarButton commandBarButton1;
    private Telerik.WinControls.UI.CommandBarButton commandBarButton2;
    private Telerik.WinControls.UI.CommandBarButton commandBarButton4;
    private Telerik.WinControls.UI.CommandBarButton btn_layer;
  }
}
