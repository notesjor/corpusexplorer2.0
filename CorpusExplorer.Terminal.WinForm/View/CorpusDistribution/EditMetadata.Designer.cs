using CorpusExplorer.Terminal.WinForm.Properties;
namespace CorpusExplorer.Terminal.WinForm.View.CorpusDistribution
{
  partial class EditMetadata
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditMetadata));
      Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
      this.radCommandBar1 = new Telerik.WinControls.UI.RadCommandBar();
      this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
      this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
      this.btn_save = new Telerik.WinControls.UI.CommandBarButton();
      this.commandBarSeparator3 = new Telerik.WinControls.UI.CommandBarSeparator();
      this.btn_export = new Telerik.WinControls.UI.CommandBarButton();
      this.btn_import = new Telerik.WinControls.UI.CommandBarButton();
      this.commandBarSeparator1 = new Telerik.WinControls.UI.CommandBarSeparator();
      this.commandBarLabel1 = new Telerik.WinControls.UI.CommandBarLabel();
      this.txt_search = new Telerik.WinControls.UI.CommandBarTextBox();
      this.commandBarLabel2 = new Telerik.WinControls.UI.CommandBarLabel();
      this.txt_replace = new Telerik.WinControls.UI.CommandBarTextBox();
      this.btn_doReplace = new Telerik.WinControls.UI.CommandBarButton();
      this.commandBarSeparator2 = new Telerik.WinControls.UI.CommandBarSeparator();
      this.btn_meta_add = new Telerik.WinControls.UI.CommandBarButton();
      this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
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
            this.btn_save,
            this.commandBarSeparator3,
            this.btn_export,
            this.btn_import,
            this.commandBarSeparator1,
            this.commandBarLabel1,
            this.txt_search,
            this.commandBarLabel2,
            this.txt_replace,
            this.btn_doReplace,
            this.commandBarSeparator2,
            this.btn_meta_add});
      this.commandBarStripElement1.Name = "commandBarStripElement1";
      // 
      // btn_save
      // 
      this.btn_save.AccessibleDescription = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Speichern;
      this.btn_save.AccessibleName = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Speichern;
      resources.ApplyResources(this.btn_save, "btn_save");
      this.btn_save.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.save;
      this.btn_save.AutoToolTip = true;
      this.btn_save.Name = "btn_save";
      this.btn_save.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.ÄnderungenSpeichern;
      this.btn_save.ToolTipText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.ÄnderungenSpeichern;
      this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
      // 
      // commandBarSeparator3
      // 
      resources.ApplyResources(this.commandBarSeparator3, "commandBarSeparator3");
      this.commandBarSeparator3.Name = "commandBarSeparator3";
      this.commandBarSeparator3.VisibleInOverflowMenu = false;
      // 
      // btn_export
      // 
      resources.ApplyResources(this.btn_export, "btn_export");
      this.btn_export.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.folder_action_open;
      this.btn_export.AutoToolTip = true;
      this.btn_export.Name = "btn_export";
      this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
      // 
      // btn_import
      // 
      resources.ApplyResources(this.btn_import, "btn_import");
      this.btn_import.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.folder_action_close;
      this.btn_import.AutoToolTip = true;
      this.btn_import.Name = "btn_import";
      this.btn_import.Click += new System.EventHandler(this.btn_import_Click);
      // 
      // commandBarSeparator1
      // 
      this.commandBarSeparator1.AccessibleDescription = "commandBarSeparator1";
      this.commandBarSeparator1.AccessibleName = "commandBarSeparator1";
      resources.ApplyResources(this.commandBarSeparator1, "commandBarSeparator1");
      this.commandBarSeparator1.Name = "commandBarSeparator1";
      this.commandBarSeparator1.VisibleInOverflowMenu = false;
      // 
      // commandBarLabel1
      // 
      resources.ApplyResources(this.commandBarLabel1, "commandBarLabel1");
      this.commandBarLabel1.Name = "commandBarLabel1";
      this.commandBarLabel1.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Suche;
      // 
      // txt_search
      // 
      resources.ApplyResources(this.txt_search, "txt_search");
      this.txt_search.MinSize = new System.Drawing.Size(200, 0);
      this.txt_search.Name = "txt_search";
      // 
      // commandBarLabel2
      // 
      resources.ApplyResources(this.commandBarLabel2, "commandBarLabel2");
      this.commandBarLabel2.Name = "commandBarLabel2";
      // 
      // txt_replace
      // 
      resources.ApplyResources(this.txt_replace, "txt_replace");
      this.txt_replace.MinSize = new System.Drawing.Size(200, 0);
      this.txt_replace.Name = "txt_replace";
      // 
      // btn_doReplace
      // 
      resources.ApplyResources(this.btn_doReplace, "btn_doReplace");
      this.btn_doReplace.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.replace;
      this.btn_doReplace.AutoToolTip = true;
      this.btn_doReplace.Name = "btn_doReplace";
      this.btn_doReplace.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.SuchenUndErsetzenAusführen;
      this.btn_doReplace.ToolTipText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.SuchenUndErsetzenAusführen;
      this.btn_doReplace.Click += new System.EventHandler(this.btn_doReplace_Click);
      // 
      // commandBarSeparator2
      // 
      this.commandBarSeparator2.AccessibleDescription = "commandBarSeparator2";
      this.commandBarSeparator2.AccessibleName = "commandBarSeparator2";
      resources.ApplyResources(this.commandBarSeparator2, "commandBarSeparator2");
      this.commandBarSeparator2.Name = "commandBarSeparator2";
      this.commandBarSeparator2.VisibleInOverflowMenu = false;
      // 
      // btn_meta_add
      // 
      resources.ApplyResources(this.btn_meta_add, "btn_meta_add");
      this.btn_meta_add.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.add_button;
      this.btn_meta_add.AutoToolTip = true;
      this.btn_meta_add.Name = "btn_meta_add";
      this.btn_meta_add.Click += new System.EventHandler(this.btn_meta_add_Click);
      // 
      // radGridView1
      // 
      resources.ApplyResources(this.radGridView1, "radGridView1");
      // 
      // 
      // 
      this.radGridView1.MasterTemplate.AllowAddNewRow = false;
      this.radGridView1.MasterTemplate.ViewDefinition = tableViewDefinition1;
      this.radGridView1.Name = "radGridView1";
      // 
      // EditMetadata
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.Controls.Add(this.radGridView1);
      this.Controls.Add(this.radCommandBar1);
      this.Name = "EditMetadata";
      this.ShowView += new System.EventHandler(this.DocumentMetadataVisualisation_ShowVisualisation);
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Telerik.WinControls.UI.RadCommandBar radCommandBar1;
    private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
    private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement1;
    private Telerik.WinControls.UI.CommandBarButton btn_save;
    private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator1;
    private Telerik.WinControls.UI.CommandBarLabel commandBarLabel1;
    private Telerik.WinControls.UI.CommandBarTextBox txt_search;
    private Telerik.WinControls.UI.CommandBarLabel commandBarLabel2;
    private Telerik.WinControls.UI.CommandBarTextBox txt_replace;
    private Telerik.WinControls.UI.CommandBarButton btn_doReplace;
    private Telerik.WinControls.UI.RadGridView radGridView1;
    private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator2;
    private Telerik.WinControls.UI.CommandBarButton btn_meta_add;
    private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator3;
    private Telerik.WinControls.UI.CommandBarButton btn_export;
    private Telerik.WinControls.UI.CommandBarButton btn_import;
  }
}
