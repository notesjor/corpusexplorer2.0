using CorpusExplorer.Terminal.WinForm.Properties;
namespace CorpusExplorer.Terminal.WinForm.View.Cooccurrence
{
  partial class CooccurrenceDiversity
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CooccurrenceDiversity));
      Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
      this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
      this.radCommandBar1 = new Telerik.WinControls.UI.RadCommandBar();
      this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
      this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
      this.btn_layer = new Telerik.WinControls.UI.CommandBarButton();
      this.commandBarLabel1 = new Telerik.WinControls.UI.CommandBarLabel();
      this.txt_queryA = new Telerik.WinControls.UI.CommandBarTextBox();
      this.commandBarLabel2 = new Telerik.WinControls.UI.CommandBarLabel();
      this.txt_queryB = new Telerik.WinControls.UI.CommandBarTextBox();
      this.commandBarButton1 = new Telerik.WinControls.UI.CommandBarButton();
      this.commandBarSeparator1 = new Telerik.WinControls.UI.CommandBarSeparator();
      this.btn_snapshot_create = new Telerik.WinControls.UI.CommandBarButton();
      this.btn_export = new Telerik.WinControls.UI.CommandBarButton();
      ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
      this.SuspendLayout();
      // 
      // radGridView1
      // 
      resources.ApplyResources(this.radGridView1, "radGridView1");
      // 
      // 
      // 
      this.radGridView1.MasterTemplate.AllowAddNewRow = false;
      this.radGridView1.MasterTemplate.AllowCellContextMenu = false;
      this.radGridView1.MasterTemplate.AllowDeleteRow = false;
      this.radGridView1.MasterTemplate.AllowEditRow = false;
      this.radGridView1.MasterTemplate.MultiSelect = true;
      this.radGridView1.MasterTemplate.ViewDefinition = tableViewDefinition1;
      this.radGridView1.Name = "radGridView1";
      this.radGridView1.RowFormatting += new Telerik.WinControls.UI.RowFormattingEventHandler(this.radGridView1_RowFormatting);
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
            this.btn_layer,
            this.commandBarLabel1,
            this.txt_queryA,
            this.commandBarLabel2,
            this.txt_queryB,
            this.commandBarButton1,
            this.commandBarSeparator1,
            this.btn_snapshot_create,
            this.btn_export});
      this.commandBarStripElement1.Name = "commandBarStripElement1";
      // 
      // btn_layer
      // 
      resources.ApplyResources(this.btn_layer, "btn_layer");
      this.btn_layer.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.layers;
      this.btn_layer.AutoToolTip = true;
      this.btn_layer.Name = "btn_layer";
      this.btn_layer.Click += new System.EventHandler(this.btn_layer_Click);
      // 
      // commandBarLabel1
      // 
      resources.ApplyResources(this.commandBarLabel1, "commandBarLabel1");
      this.commandBarLabel1.Name = "commandBarLabel1";
      this.commandBarLabel1.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Html_GreeValues;
      // 
      // txt_queryA
      // 
      resources.ApplyResources(this.txt_queryA, "txt_queryA");
      this.txt_queryA.MinSize = new System.Drawing.Size(200, 0);
      this.txt_queryA.Name = "txt_queryA";
      // 
      // commandBarLabel2
      // 
      resources.ApplyResources(this.commandBarLabel2, "commandBarLabel2");
      this.commandBarLabel2.Name = "commandBarLabel2";
      this.commandBarLabel2.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Html_RedValues;
      // 
      // txt_queryB
      // 
      resources.ApplyResources(this.txt_queryB, "txt_queryB");
      this.txt_queryB.MinSize = new System.Drawing.Size(200, 0);
      this.txt_queryB.Name = "txt_queryB";
      // 
      // commandBarButton1
      // 
      this.commandBarButton1.AccessibleDescription = "commandBarButton1";
      this.commandBarButton1.AccessibleName = "commandBarButton1";
      resources.ApplyResources(this.commandBarButton1, "commandBarButton1");
      this.commandBarButton1.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.button_circle_right;
      this.commandBarButton1.AutoToolTip = true;
      this.commandBarButton1.Name = "commandBarButton1";
      this.commandBarButton1.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.AuswertungStarten;
      this.commandBarButton1.ToolTipText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.AuswertungStarten;
      this.commandBarButton1.Click += new System.EventHandler(this.btn_startB_Click);
      // 
      // commandBarSeparator1
      // 
      this.commandBarSeparator1.AccessibleDescription = "commandBarSeparator1";
      this.commandBarSeparator1.AccessibleName = "commandBarSeparator1";
      resources.ApplyResources(this.commandBarSeparator1, "commandBarSeparator1");
      this.commandBarSeparator1.Name = "commandBarSeparator1";
      this.commandBarSeparator1.VisibleInOverflowMenu = false;
      // 
      // btn_snapshot_create
      // 
      this.btn_snapshot_create.AccessibleDescription = "commandBarButton2";
      this.btn_snapshot_create.AccessibleName = "commandBarButton2";
      resources.ApplyResources(this.btn_snapshot_create, "btn_snapshot_create");
      this.btn_snapshot_create.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.camera_add;
      this.btn_snapshot_create.AutoToolTip = true;
      this.btn_snapshot_create.Name = "btn_snapshot_create";
      this.btn_snapshot_create.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.SchnappschussErstellen;
      this.btn_snapshot_create.ToolTipText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.SchnappschussErstellen;
      this.btn_snapshot_create.Click += new System.EventHandler(this.btn_snapshot_create_Click);
      // 
      // btn_export
      // 
      resources.ApplyResources(this.btn_export, "btn_export");
      this.btn_export.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.export_text;
      this.btn_export.AutoToolTip = true;
      this.btn_export.Name = "btn_export";
      this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
      // 
      // CooccurrenceDiversity
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.Controls.Add(this.radGridView1);
      this.Controls.Add(this.radCommandBar1);
      this.Name = "CooccurrenceDiversity";
      ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Telerik.WinControls.UI.RadGridView radGridView1;
    private Telerik.WinControls.UI.RadCommandBar radCommandBar1;
    private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
    private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement1;
    private Telerik.WinControls.UI.CommandBarLabel commandBarLabel1;
    private Telerik.WinControls.UI.CommandBarTextBox txt_queryA;
    private Telerik.WinControls.UI.CommandBarLabel commandBarLabel2;
    private Telerik.WinControls.UI.CommandBarTextBox txt_queryB;
    private Telerik.WinControls.UI.CommandBarButton commandBarButton1;
    private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator1;
    private Telerik.WinControls.UI.CommandBarButton btn_snapshot_create;
    private Telerik.WinControls.UI.CommandBarButton btn_export;
    private Telerik.WinControls.UI.CommandBarButton btn_layer;
  }
}
