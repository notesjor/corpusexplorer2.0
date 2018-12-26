using CorpusExplorer.Terminal.WinForm.Properties;
namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm.Snapshot
{
  partial class FulltextSnapshotControl
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FulltextSnapshotControl));
      this.combo_layer = new Telerik.WinControls.UI.RadDropDownList();
      this.combo_query = new Telerik.WinControls.UI.RadDropDownList();
      this.txt_values = new Telerik.WinControls.UI.RadAutoCompleteBox();
      this.clearPanel1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.ClearPanel();
      this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
      this.radGroupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.combo_layer)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.combo_query)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_values)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel1)).BeginInit();
      this.clearPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
      this.SuspendLayout();
      // 
      // radGroupBox1
      // 
      this.radGroupBox1.Controls.Add(this.txt_values);
      this.radGroupBox1.Controls.Add(this.combo_query);
      this.radGroupBox1.Controls.Add(this.clearPanel1);
      this.radGroupBox1.HeaderImage = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.text_box;
      this.radGroupBox1.HeaderText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Snapshot_Condition_Fulltext;
      this.radGroupBox1.HeaderTextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      resources.ApplyResources(this.radGroupBox1, "radGroupBox1");
      this.radGroupBox1.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Snapshot_Condition_Fulltext;
      this.radGroupBox1.Controls.SetChildIndex(this.clearPanel1, 0);
      this.radGroupBox1.Controls.SetChildIndex(this.combo_query, 0);
      this.radGroupBox1.Controls.SetChildIndex(this.txt_values, 0);
      // 
      // combo_layer
      // 
      resources.ApplyResources(this.combo_layer, "combo_layer");
      this.combo_layer.Name = "combo_layer";
      this.combo_layer.NullText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Snapshot_SelectLayer;
      this.combo_layer.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.combo_layer_SelectedIndexChanged);
      // 
      // combo_query
      // 
      resources.ApplyResources(this.combo_query, "combo_query");
      this.combo_query.Name = "combo_query";
      this.combo_query.NullText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Snapshot_SelectQuery;
      this.combo_query.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.combo_query_SelectedIndexChanged);
      // 
      // txt_values
      // 
      resources.ApplyResources(this.txt_values, "txt_values");
      this.txt_values.Multiline = true;
      this.txt_values.Name = "txt_values";
      ((Telerik.WinControls.UI.AutoCompleteBoxViewElement)(this.txt_values.GetChildAt(0).GetChildAt(0))).Padding = ((System.Windows.Forms.Padding)(resources.GetObject("resource.Padding")));
      // 
      // clearPanel1
      // 
      this.clearPanel1.Controls.Add(this.radLabel1);
      this.clearPanel1.Controls.Add(this.combo_layer);
      resources.ApplyResources(this.clearPanel1, "clearPanel1");
      this.clearPanel1.Name = "clearPanel1";
      // 
      // radLabel1
      // 
      resources.ApplyResources(this.radLabel1, "radLabel1");
      this.radLabel1.Name = "radLabel1";
      // 
      // FulltextSnapshotControl
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.Name = "FulltextSnapshotControl";
      resources.ApplyResources(this, "$this");
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
      this.radGroupBox1.ResumeLayout(false);
      this.radGroupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.combo_layer)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.combo_query)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_values)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel1)).EndInit();
      this.clearPanel1.ResumeLayout(false);
      this.clearPanel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private Telerik.WinControls.UI.RadDropDownList combo_query;
    private Telerik.WinControls.UI.RadDropDownList combo_layer;
    private Telerik.WinControls.UI.RadAutoCompleteBox txt_values;
    private ClearPanel clearPanel1;
    private Telerik.WinControls.UI.RadLabel radLabel1;
  }
}
