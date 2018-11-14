using CorpusExplorer.Terminal.WinForm.Properties;
using CorpusExplorer.Terminal.WinForm.Controls.WinForm;

namespace CorpusExplorer.Terminal.WinForm.View.Fulltext
{
  partial class FulltextAnnotationSpeedup
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
      Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
      this.radCommandBar1 = new Telerik.WinControls.UI.RadCommandBar();
      this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
      this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
      this.commandBarLabel1 = new Telerik.WinControls.UI.CommandBarLabel();
      this.drop_selecteddocument = new Telerik.WinControls.UI.CommandBarDropDownList();
      this.btn_showMeta = new Telerik.WinControls.UI.CommandBarButton();
      this.btn_export = new Telerik.WinControls.UI.CommandBarButton();
      this.commandBarRowElement2 = new Telerik.WinControls.UI.CommandBarRowElement();
      this.commandBarStripElement2 = new Telerik.WinControls.UI.CommandBarStripElement();
      this.commandBarLabel2 = new Telerik.WinControls.UI.CommandBarLabel();
      this.drop_layerView = new Telerik.WinControls.UI.CommandBarDropDownList();
      this.commandBarSeparator1 = new Telerik.WinControls.UI.CommandBarSeparator();
      this.commandBarLabel3 = new Telerik.WinControls.UI.CommandBarLabel();
      this.drop_layerAnnotate = new Telerik.WinControls.UI.CommandBarDropDownList();
      this.commandBarDropDownButton1 = new Telerik.WinControls.UI.CommandBarDropDownButton();
      this.btn_layer_add_new = new Telerik.WinControls.UI.RadMenuItem();
      this.btn_layer_add_copy = new Telerik.WinControls.UI.RadMenuItem();
      this.clearPanel1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.ClearPanel();
      this.btn_save = new Telerik.WinControls.UI.RadButton();
      this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel1)).BeginInit();
      this.clearPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.btn_save)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
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
      this.radCommandBar1.Size = new System.Drawing.Size(757, 110);
      this.radCommandBar1.TabIndex = 0;
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
            this.drop_selecteddocument,
            this.btn_showMeta,
            this.btn_export});
      this.commandBarStripElement1.Name = "commandBarStripElement1";
      // 
      // commandBarLabel1
      // 
      this.commandBarLabel1.DisplayName = "commandBarLabel1";
      this.commandBarLabel1.Name = "commandBarLabel1";
      this.commandBarLabel1.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.TextDP;
      // 
      // drop_selecteddocument
      // 
      this.drop_selecteddocument.DisplayName = "commandBarDropDownList1";
      this.drop_selecteddocument.DropDownAnimationEnabled = true;
      this.drop_selecteddocument.MaxDropDownItems = 0;
      this.drop_selecteddocument.MinSize = new System.Drawing.Size(300, 22);
      this.drop_selecteddocument.Name = "drop_selecteddocument";
      this.drop_selecteddocument.Text = "";
      this.drop_selecteddocument.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.drop_selecteddocument_SelectedIndexChanged);
      // 
      // btn_showMeta
      // 
      this.btn_showMeta.DisplayName = "commandBarButton1";
      this.btn_showMeta.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.tag_green;
      this.btn_showMeta.Name = "btn_showMeta";
      this.btn_showMeta.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.MetadatenAnzeigen;
      this.btn_showMeta.ToolTipText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.MetadatenAnzeigen;
      this.btn_showMeta.Click += new System.EventHandler(this.btn_showMeta_Click);
      // 
      // btn_export
      // 
      this.btn_export.DisplayName = "commandBarButton1";
      this.btn_export.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.export_text;
      this.btn_export.Name = "btn_export";
      this.btn_export.Text = "Aktuelles Dokument exportieren";
      this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
      // 
      // commandBarRowElement2
      // 
      this.commandBarRowElement2.MinSize = new System.Drawing.Size(25, 25);
      this.commandBarRowElement2.Name = "commandBarRowElement2";
      this.commandBarRowElement2.Strips.AddRange(new Telerik.WinControls.UI.CommandBarStripElement[] {
            this.commandBarStripElement2});
      // 
      // commandBarStripElement2
      // 
      this.commandBarStripElement2.DisplayName = "commandBarStripElement2";
      this.commandBarStripElement2.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.commandBarLabel2,
            this.drop_layerView,
            this.commandBarSeparator1,
            this.commandBarLabel3,
            this.drop_layerAnnotate,
            this.commandBarDropDownButton1});
      this.commandBarStripElement2.Name = "commandBarStripElement2";
      // 
      // commandBarLabel2
      // 
      this.commandBarLabel2.DisplayName = "commandBarLabel2";
      this.commandBarLabel2.Name = "commandBarLabel2";
      this.commandBarLabel2.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.AnzeigelayerDP;
      // 
      // drop_layerView
      // 
      this.drop_layerView.DisplayName = "commandBarDropDownList2";
      this.drop_layerView.DropDownAnimationEnabled = true;
      this.drop_layerView.MaxDropDownItems = 0;
      this.drop_layerView.MinSize = new System.Drawing.Size(220, 22);
      this.drop_layerView.Name = "drop_layerView";
      this.drop_layerView.Text = "";
      this.drop_layerView.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.drop_layerView_SelectedIndexChanged);
      // 
      // commandBarSeparator1
      // 
      this.commandBarSeparator1.AccessibleDescription = "commandBarSeparator1";
      this.commandBarSeparator1.AccessibleName = "commandBarSeparator1";
      this.commandBarSeparator1.DisplayName = "commandBarSeparator1";
      this.commandBarSeparator1.Name = "commandBarSeparator1";
      this.commandBarSeparator1.VisibleInOverflowMenu = false;
      // 
      // commandBarLabel3
      // 
      this.commandBarLabel3.DisplayName = "commandBarLabel3";
      this.commandBarLabel3.Name = "commandBarLabel3";
      this.commandBarLabel3.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.AnnotationslayerDP;
      // 
      // drop_layerAnnotate
      // 
      this.drop_layerAnnotate.DisplayName = "commandBarDropDownList3";
      this.drop_layerAnnotate.DropDownAnimationEnabled = true;
      this.drop_layerAnnotate.MaxDropDownItems = 0;
      this.drop_layerAnnotate.MinSize = new System.Drawing.Size(220, 22);
      this.drop_layerAnnotate.Name = "drop_layerAnnotate";
      this.drop_layerAnnotate.Text = "";
      this.drop_layerAnnotate.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.drop_layerAnnotate_SelectedIndexChanged);
      // 
      // commandBarDropDownButton1
      // 
      this.commandBarDropDownButton1.DisplayName = "commandBarDropDownButton1";
      this.commandBarDropDownButton1.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.add_button;
      this.commandBarDropDownButton1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.btn_layer_add_new,
            this.btn_layer_add_copy});
      this.commandBarDropDownButton1.Name = "commandBarDropDownButton1";
      this.commandBarDropDownButton1.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.NeuenLayerHinzufügen;
      this.commandBarDropDownButton1.ToolTipText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.NeuenLayerHinzufügen;
      // 
      // btn_layer_add_new
      // 
      this.btn_layer_add_new.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.add_button;
      this.btn_layer_add_new.Name = "btn_layer_add_new";
      this.btn_layer_add_new.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.NeuenLeerenLayerHinzufügen;
      this.btn_layer_add_new.Click += new System.EventHandler(this.btn_addLayer_Click);
      // 
      // btn_layer_add_copy
      // 
      this.btn_layer_add_copy.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.add_button;
      this.btn_layer_add_copy.Name = "btn_layer_add_copy";
      this.btn_layer_add_copy.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.AktuellenLayerKopieren;
      this.btn_layer_add_copy.Click += new System.EventHandler(this.btn_layer_add_copy_Click);
      // 
      // clearPanel1
      // 
      this.clearPanel1.Controls.Add(this.btn_save);
      this.clearPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.clearPanel1.Location = new System.Drawing.Point(0, 187);
      this.clearPanel1.Name = "clearPanel1";
      this.clearPanel1.Padding = new System.Windows.Forms.Padding(5);
      this.clearPanel1.Size = new System.Drawing.Size(757, 43);
      this.clearPanel1.TabIndex = 1;
      // 
      // btn_save
      // 
      this.btn_save.Dock = System.Windows.Forms.DockStyle.Right;
      this.btn_save.Location = new System.Drawing.Point(570, 5);
      this.btn_save.Name = "btn_save";
      this.btn_save.Size = new System.Drawing.Size(182, 33);
      this.btn_save.TabIndex = 0;
      this.btn_save.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.AnnotationSpeichern;
      this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
      // 
      // radGridView1
      // 
      this.radGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radGridView1.Location = new System.Drawing.Point(0, 110);
      // 
      // 
      // 
      this.radGridView1.MasterTemplate.AllowAddNewRow = false;
      this.radGridView1.MasterTemplate.AllowCellContextMenu = false;
      this.radGridView1.MasterTemplate.AllowColumnChooser = false;
      this.radGridView1.MasterTemplate.AllowColumnHeaderContextMenu = false;
      this.radGridView1.MasterTemplate.AllowDeleteRow = false;
      this.radGridView1.MasterTemplate.AllowDragToGroup = false;
      this.radGridView1.MasterTemplate.EnableFiltering = true;
      this.radGridView1.MasterTemplate.EnableGrouping = false;
      this.radGridView1.MasterTemplate.EnableSorting = false;
      this.radGridView1.MasterTemplate.ViewDefinition = tableViewDefinition1;
      this.radGridView1.Name = "radGridView1";
      this.radGridView1.ShowGroupPanel = false;
      this.radGridView1.Size = new System.Drawing.Size(757, 77);
      this.radGridView1.TabIndex = 2;
      this.radGridView1.CellValueChanged += new Telerik.WinControls.UI.GridViewCellEventHandler(this.radGridView1_CellValueChanged);
      // 
      // FulltextAnnotationSpeedup
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.Controls.Add(this.radGridView1);
      this.Controls.Add(this.clearPanel1);
      this.Controls.Add(this.radCommandBar1);
      this.MinimumSize = new System.Drawing.Size(535, 230);
      this.Name = "FulltextAnnotationSpeedup";
      this.Size = new System.Drawing.Size(757, 230);
      this.ShowView += new System.EventHandler(this.SpeedTaggerVisualisation_ShowVisualisation);
      this.Load += new System.EventHandler(this.SpeedTaggerVisualisation_Load);
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel1)).EndInit();
      this.clearPanel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.btn_save)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Telerik.WinControls.UI.RadCommandBar radCommandBar1;
    private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
    private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement1;
    private Telerik.WinControls.UI.CommandBarLabel commandBarLabel1;
    private Telerik.WinControls.UI.CommandBarDropDownList drop_selecteddocument;
    private Telerik.WinControls.UI.CommandBarButton btn_showMeta;
    private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement2;
    private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement2;
    private Telerik.WinControls.UI.CommandBarLabel commandBarLabel2;
    private Telerik.WinControls.UI.CommandBarDropDownList drop_layerView;
    private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator1;
    private Telerik.WinControls.UI.CommandBarLabel commandBarLabel3;
    private Telerik.WinControls.UI.CommandBarDropDownList drop_layerAnnotate;
    private ClearPanel clearPanel1;
    private Telerik.WinControls.UI.RadButton btn_save;
    private Telerik.WinControls.UI.RadGridView radGridView1;
    private Telerik.WinControls.UI.CommandBarDropDownButton commandBarDropDownButton1;
    private Telerik.WinControls.UI.RadMenuItem btn_layer_add_new;
    private Telerik.WinControls.UI.RadMenuItem btn_layer_add_copy;
    private Telerik.WinControls.UI.CommandBarButton btn_export;
  }
}
