namespace CorpusExplorer.Terminal.WinForm.View.CorpusDistribution
{
  partial class CorpusFiniteStateMachine
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CorpusFiniteStateMachine));
      this.radCommandBar1 = new Telerik.WinControls.UI.RadCommandBar();
      this.commandBarRowElement2 = new Telerik.WinControls.UI.CommandBarRowElement();
      this.commandBarStripElement3 = new Telerik.WinControls.UI.CommandBarStripElement();
      this.commandBarLabel2 = new Telerik.WinControls.UI.CommandBarLabel();
      this.drop_sort = new Telerik.WinControls.UI.CommandBarDropDownList();
      this.commandBarLabel1 = new Telerik.WinControls.UI.CommandBarLabel();
      this.drop_category1 = new Telerik.WinControls.UI.CommandBarDropDownList();
      this.commandBarLabel3 = new Telerik.WinControls.UI.CommandBarLabel();
      this.drop_category2 = new Telerik.WinControls.UI.CommandBarDropDownList();
      this.btn_start = new Telerik.WinControls.UI.CommandBarButton();
      this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
      this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
      this.commandBarDropDownButton1 = new Telerik.WinControls.UI.CommandBarDropDownButton();
      this.btn_layout_default = new Telerik.WinControls.UI.RadMenuItem();
      this.btn_layout_tree = new Telerik.WinControls.UI.RadMenuItem();
      this.btn_save = new Telerik.WinControls.UI.CommandBarButton();
      this.commandBarDropDownButton3 = new Telerik.WinControls.UI.CommandBarDropDownButton();
      this.btn_export_graphviz = new Telerik.WinControls.UI.RadMenuItem();
      this.btn_export_gexf = new Telerik.WinControls.UI.RadMenuItem();
      this.btn_export_csv = new Telerik.WinControls.UI.RadMenuItem();
      this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
      this.SuspendLayout();
      // 
      // radCommandBar1
      // 
      resources.ApplyResources(this.radCommandBar1, "radCommandBar1");
      this.radCommandBar1.Name = "radCommandBar1";
      this.radCommandBar1.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement2,
            this.commandBarRowElement1});
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
      resources.ApplyResources(this.commandBarStripElement3, "commandBarStripElement3");
      this.commandBarStripElement3.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.commandBarLabel2,
            this.drop_sort,
            this.commandBarLabel1,
            this.drop_category1,
            this.commandBarLabel3,
            this.drop_category2,
            this.btn_start});
      this.commandBarStripElement3.Name = "commandBarStripElement3";
      // 
      // commandBarLabel2
      // 
      resources.ApplyResources(this.commandBarLabel2, "commandBarLabel2");
      this.commandBarLabel2.Name = "commandBarLabel2";
      // 
      // drop_sort
      // 
      resources.ApplyResources(this.drop_sort, "drop_sort");
      this.drop_sort.DropDownAnimationEnabled = true;
      this.drop_sort.MaxDropDownItems = 0;
      this.drop_sort.MinSize = new System.Drawing.Size(175, 22);
      this.drop_sort.Name = "drop_sort";
      // 
      // commandBarLabel1
      // 
      resources.ApplyResources(this.commandBarLabel1, "commandBarLabel1");
      this.commandBarLabel1.Name = "commandBarLabel1";
      // 
      // drop_category1
      // 
      resources.ApplyResources(this.drop_category1, "drop_category1");
      this.drop_category1.DropDownAnimationEnabled = true;
      this.drop_category1.MaxDropDownItems = 0;
      this.drop_category1.MinSize = new System.Drawing.Size(175, 22);
      this.drop_category1.Name = "drop_category1";
      // 
      // commandBarLabel3
      // 
      resources.ApplyResources(this.commandBarLabel3, "commandBarLabel3");
      this.commandBarLabel3.Name = "commandBarLabel3";
      // 
      // drop_category2
      // 
      resources.ApplyResources(this.drop_category2, "drop_category2");
      this.drop_category2.DropDownAnimationEnabled = true;
      this.drop_category2.MaxDropDownItems = 0;
      this.drop_category2.MinSize = new System.Drawing.Size(175, 22);
      this.drop_category2.Name = "drop_category2";
      // 
      // btn_start
      // 
      this.btn_start.AutoToolTip = true;
      resources.ApplyResources(this.btn_start, "btn_start");
      this.btn_start.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.button_circle_right;
      this.btn_start.Name = "btn_start";
      this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
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
            this.commandBarDropDownButton1,
            this.btn_save,
            this.commandBarDropDownButton3});
      this.commandBarStripElement1.Name = "commandBarStripElement1";
      // 
      // commandBarDropDownButton1
      // 
      resources.ApplyResources(this.commandBarDropDownButton1, "commandBarDropDownButton1");
      this.commandBarDropDownButton1.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.diagram1;
      this.commandBarDropDownButton1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.btn_layout_default,
            this.btn_layout_tree});
      this.commandBarDropDownButton1.Name = "commandBarDropDownButton1";
      this.commandBarDropDownButton1.ToolTipText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.DiagrammLayouten;
      // 
      // btn_layout_default
      // 
      this.btn_layout_default.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.diagram1;
      this.btn_layout_default.Name = "btn_layout_default";
      resources.ApplyResources(this.btn_layout_default, "btn_layout_default");
      this.btn_layout_default.Click += new System.EventHandler(this.btn_layout_network_Click);
      // 
      // btn_layout_tree
      // 
      this.btn_layout_tree.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.diagram1;
      this.btn_layout_tree.Name = "btn_layout_tree";
      this.btn_layout_tree.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.BaumLayout;
      this.btn_layout_tree.Click += new System.EventHandler(this.btn_layout_tree_Click);
      // 
      // btn_save
      // 
      this.btn_save.AutoToolTip = true;
      resources.ApplyResources(this.btn_save, "btn_save");
      this.btn_save.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.save;
      this.btn_save.Name = "btn_save";
      this.btn_save.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Speichern;
      this.btn_save.ToolTipText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.DiagrammSpeichern;
      this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
      // 
      // commandBarDropDownButton3
      // 
      resources.ApplyResources(this.commandBarDropDownButton3, "commandBarDropDownButton3");
      this.commandBarDropDownButton3.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.save_theme;
      this.commandBarDropDownButton3.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.btn_export_graphviz,
            this.btn_export_gexf,
            this.btn_export_csv});
      this.commandBarDropDownButton3.Name = "commandBarDropDownButton3";
      this.commandBarDropDownButton3.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Export;
      this.commandBarDropDownButton3.ToolTipText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.DiagrammExportieren;
      // 
      // btn_export_graphviz
      // 
      this.btn_export_graphviz.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.save_theme;
      this.btn_export_graphviz.Name = "btn_export_graphviz";
      this.btn_export_graphviz.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.AlsGraphVizExportieren;
      this.btn_export_graphviz.Click += new System.EventHandler(this.btn_export_graphviz_Click);
      // 
      // btn_export_gexf
      // 
      this.btn_export_gexf.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.save_theme;
      this.btn_export_gexf.Name = "btn_export_gexf";
      this.btn_export_gexf.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.AlsGEXFXMLExportieren;
      this.btn_export_gexf.Click += new System.EventHandler(this.btn_export_gexf_Click);
      // 
      // btn_export_csv
      // 
      this.btn_export_csv.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.save_theme;
      this.btn_export_csv.Name = "btn_export_csv";
      resources.ApplyResources(this.btn_export_csv, "btn_export_csv");
      this.btn_export_csv.Click += new System.EventHandler(this.btn_export_csv_Click);
      // 
      // elementHost1
      // 
      resources.ApplyResources(this.elementHost1, "elementHost1");
      this.elementHost1.Name = "elementHost1";
      this.elementHost1.Child = null;
      // 
      // CorpusFiniteStateMachine
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.Controls.Add(this.elementHost1);
      this.Controls.Add(this.radCommandBar1);
      this.Name = "CorpusFiniteStateMachine";
      resources.ApplyResources(this, "$this");
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Telerik.WinControls.UI.RadCommandBar radCommandBar1;
    private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement2;
    private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement3;
    private Telerik.WinControls.UI.CommandBarDropDownButton commandBarDropDownButton1;
    private Telerik.WinControls.UI.RadMenuItem btn_layout_tree;
    private Telerik.WinControls.UI.RadMenuItem btn_layout_default;
    private Telerik.WinControls.UI.CommandBarButton btn_save;
    private Telerik.WinControls.UI.CommandBarDropDownButton commandBarDropDownButton3;
    private Telerik.WinControls.UI.RadMenuItem btn_export_graphviz;
    private Telerik.WinControls.UI.RadMenuItem btn_export_gexf;
    private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
    private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement1;
    private System.Windows.Forms.Integration.ElementHost elementHost1;
    private Telerik.WinControls.UI.CommandBarLabel commandBarLabel1;
    private Telerik.WinControls.UI.CommandBarDropDownList drop_category1;
    private Telerik.WinControls.UI.CommandBarLabel commandBarLabel3;
    private Telerik.WinControls.UI.CommandBarDropDownList drop_category2;
    private Telerik.WinControls.UI.CommandBarLabel commandBarLabel2;
    private Telerik.WinControls.UI.CommandBarDropDownList drop_sort;
    private Telerik.WinControls.UI.RadMenuItem btn_export_csv;
    private Telerik.WinControls.UI.CommandBarButton btn_start;
  }
}
