namespace CorpusExplorer.Terminal.WinForm.View.StyleMetrics
{
  partial class CompareBasedOnNgrams
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompareBasedOnNgrams));
      this.tree_results = new Telerik.WinControls.UI.RadTreeView();
      this.radCommandBar1 = new Telerik.WinControls.UI.RadCommandBar();
      this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
      this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
      this.commandBarLabel1 = new Telerik.WinControls.UI.CommandBarLabel();
      this.combo_meta = new Telerik.WinControls.UI.CommandBarDropDownList();
      this.commandBarLabel3 = new Telerik.WinControls.UI.CommandBarLabel();
      this.txt_ngramSize = new Telerik.WinControls.UI.CommandBarTextBox();
      this.btn_start = new Telerik.WinControls.UI.CommandBarButton();
      this.commandBarSeparator1 = new Telerik.WinControls.UI.CommandBarSeparator();
      this.commandBarLabel2 = new Telerik.WinControls.UI.CommandBarLabel();
      this.txt_searchQuery = new Telerik.WinControls.UI.CommandBarTextBox();
      ((System.ComponentModel.ISupportInitialize)(this.tree_results)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
      this.SuspendLayout();
      // 
      // tree_results
      // 
      resources.ApplyResources(this.tree_results, "tree_results");
      this.tree_results.ItemHeight = 40;
      this.tree_results.Name = "tree_results";
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
            this.commandBarLabel1,
            this.combo_meta,
            this.commandBarLabel3,
            this.txt_ngramSize,
            this.btn_start,
            this.commandBarSeparator1,
            this.commandBarLabel2,
            this.txt_searchQuery});
      this.commandBarStripElement1.Name = "commandBarStripElement1";
      // 
      // commandBarLabel1
      // 
      resources.ApplyResources(this.commandBarLabel1, "commandBarLabel1");
      this.commandBarLabel1.Name = "commandBarLabel1";
      this.commandBarLabel1.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.MetaangabeDP;
      // 
      // combo_meta
      // 
      resources.ApplyResources(this.combo_meta, "combo_meta");
      this.combo_meta.DropDownAnimationEnabled = true;
      this.combo_meta.MaxDropDownItems = 0;
      this.combo_meta.MinSize = new System.Drawing.Size(200, 22);
      this.combo_meta.Name = "combo_meta";
      this.combo_meta.NullText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.BitteAuswählen;
      // 
      // commandBarLabel3
      // 
      resources.ApplyResources(this.commandBarLabel3, "commandBarLabel3");
      this.commandBarLabel3.Name = "commandBarLabel3";
      // 
      // txt_ngramSize
      // 
      resources.ApplyResources(this.txt_ngramSize, "txt_ngramSize");
      this.txt_ngramSize.Name = "txt_ngramSize";
      // 
      // btn_start
      // 
      resources.ApplyResources(this.btn_start, "btn_start");
      this.btn_start.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.button_circle_right;
      this.btn_start.AutoToolTip = true;
      this.btn_start.Name = "btn_start";
      this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
      // 
      // commandBarSeparator1
      // 
      resources.ApplyResources(this.commandBarSeparator1, "commandBarSeparator1");
      this.commandBarSeparator1.Name = "commandBarSeparator1";
      this.commandBarSeparator1.VisibleInOverflowMenu = false;
      // 
      // commandBarLabel2
      // 
      resources.ApplyResources(this.commandBarLabel2, "commandBarLabel2");
      this.commandBarLabel2.Name = "commandBarLabel2";
      this.commandBarLabel2.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Suche;
      // 
      // txt_searchQuery
      // 
      resources.ApplyResources(this.txt_searchQuery, "txt_searchQuery");
      this.txt_searchQuery.MinSize = new System.Drawing.Size(200, 0);
      this.txt_searchQuery.Name = "txt_searchQuery";
      this.txt_searchQuery.NullText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.SuchbegriffHierEingeben;
      this.txt_searchQuery.TextChanged += new System.EventHandler(this.txt_searchQuery_TextChanged);
      // 
      // CompareBasedOnNgrams
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.Controls.Add(this.tree_results);
      this.Controls.Add(this.radCommandBar1);
      this.Name = "CompareBasedOnNgrams";
      this.ShowView += new System.EventHandler(this.TextSimilarityPage_ShowVisualisation);
      ((System.ComponentModel.ISupportInitialize)(this.tree_results)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Telerik.WinControls.UI.RadCommandBar radCommandBar1;
    private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
    private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement1;
    private Telerik.WinControls.UI.CommandBarLabel commandBarLabel1;
    private Telerik.WinControls.UI.CommandBarDropDownList combo_meta;
    private Telerik.WinControls.UI.CommandBarLabel commandBarLabel2;
    private Telerik.WinControls.UI.CommandBarTextBox txt_searchQuery;
    private Telerik.WinControls.UI.RadTreeView tree_results;
    private Telerik.WinControls.UI.CommandBarLabel commandBarLabel3;
    private Telerik.WinControls.UI.CommandBarTextBox txt_ngramSize;
    private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator1;
    private Telerik.WinControls.UI.CommandBarButton btn_start;
  }
}
