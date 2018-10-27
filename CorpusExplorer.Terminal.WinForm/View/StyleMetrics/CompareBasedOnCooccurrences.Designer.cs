namespace CorpusExplorer.Terminal.WinForm.View.StyleMetrics
{
  partial class CompareBasedOnCooccurrences
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
      this.tree_results = new Telerik.WinControls.UI.RadTreeView();
      this.radCommandBar1 = new Telerik.WinControls.UI.RadCommandBar();
      this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
      this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
      this.commandBarLabel1 = new Telerik.WinControls.UI.CommandBarLabel();
      this.combo_meta = new Telerik.WinControls.UI.CommandBarDropDownList();
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
      this.tree_results.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tree_results.ItemHeight = 40;
      this.tree_results.Location = new System.Drawing.Point(0, 69);
      this.tree_results.Name = "tree_results";
      this.tree_results.Size = new System.Drawing.Size(780, 331);
      this.tree_results.TabIndex = 2;
      this.tree_results.TreeIndent = 40;
      // 
      // radCommandBar1
      // 
      this.radCommandBar1.Dock = System.Windows.Forms.DockStyle.Top;
      this.radCommandBar1.Location = new System.Drawing.Point(0, 0);
      this.radCommandBar1.Name = "radCommandBar1";
      this.radCommandBar1.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement1});
      this.radCommandBar1.Size = new System.Drawing.Size(780, 69);
      this.radCommandBar1.TabIndex = 3;
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
            this.commandBarLabel1,
            this.combo_meta,
            this.btn_start,
            this.commandBarSeparator1,
            this.commandBarLabel2,
            this.txt_searchQuery});
      this.commandBarStripElement1.Name = "commandBarStripElement1";
      // 
      // commandBarLabel1
      // 
      this.commandBarLabel1.DisplayName = "commandBarLabel1";
      this.commandBarLabel1.Name = "commandBarLabel1";
      this.commandBarLabel1.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.MetaangabeDP;
      // 
      // combo_meta
      // 
      this.combo_meta.DisplayName = "commandBarDropDownList1";
      this.combo_meta.DropDownAnimationEnabled = true;
      this.combo_meta.MaxDropDownItems = 0;
      this.combo_meta.MinSize = new System.Drawing.Size(200, 22);
      this.combo_meta.Name = "combo_meta";
      this.combo_meta.NullText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.BitteAuswählen;
      this.combo_meta.Text = "";
      // 
      // btn_start
      // 
      this.btn_start.DisplayName = "commandBarButton1";
      this.btn_start.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.button_circle_right;
      this.btn_start.Name = "btn_start";
      this.btn_start.Text = "Analyse starten";
      this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
      // 
      // commandBarSeparator1
      // 
      this.commandBarSeparator1.DisplayName = "commandBarSeparator1";
      this.commandBarSeparator1.Name = "commandBarSeparator1";
      this.commandBarSeparator1.VisibleInOverflowMenu = false;
      // 
      // commandBarLabel2
      // 
      this.commandBarLabel2.DisplayName = "commandBarLabel2";
      this.commandBarLabel2.Name = "commandBarLabel2";
      this.commandBarLabel2.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Suche;
      // 
      // txt_searchQuery
      // 
      this.txt_searchQuery.DisplayName = "commandBarTextBox1";
      this.txt_searchQuery.MinSize = new System.Drawing.Size(200, 0);
      this.txt_searchQuery.Name = "txt_searchQuery";
      this.txt_searchQuery.NullText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.SuchbegriffHierEingeben;
      this.txt_searchQuery.Text = "";
      this.txt_searchQuery.TextChanged += new System.EventHandler(this.txt_searchQuery_TextChanged);
      // 
      // CompareBasedOnCooccurrences
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.tree_results);
      this.Controls.Add(this.radCommandBar1);
      this.Name = "CompareBasedOnCooccurrences";
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
    private Telerik.WinControls.UI.CommandBarButton btn_start;
    private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator1;
  }
}
