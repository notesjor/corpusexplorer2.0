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
      this.combo_layer = new Telerik.WinControls.UI.RadDropDownList();
      this.combo_query = new Telerik.WinControls.UI.RadDropDownList();
      this.txt_values = new Telerik.WinControls.UI.RadAutoCompleteBox();
      this.clearPanel1 = new ClearPanel();
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
      this.radGroupBox1.HeaderText = Resources.Snapshot_Condition_Fulltext;
      this.radGroupBox1.HeaderTextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.radGroupBox1.Padding = new System.Windows.Forms.Padding(7, 35, 2, 2);
      this.radGroupBox1.Size = new System.Drawing.Size(800, 120);
      this.radGroupBox1.Text = Resources.Snapshot_Condition_Fulltext;
      this.radGroupBox1.Controls.SetChildIndex(this.clearPanel1, 0);
      this.radGroupBox1.Controls.SetChildIndex(this.combo_query, 0);
      this.radGroupBox1.Controls.SetChildIndex(this.txt_values, 0);
      // 
      // combo_layer
      // 
      this.combo_layer.Dock = System.Windows.Forms.DockStyle.Top;
      this.combo_layer.Location = new System.Drawing.Point(0, 0);
      this.combo_layer.Name = "combo_layer";
      this.combo_layer.NullText = Resources.Snapshot_SelectLayer;
      this.combo_layer.Size = new System.Drawing.Size(195, 30);
      this.combo_layer.TabIndex = 2;
      this.combo_layer.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.combo_layer_SelectedIndexChanged);
      // 
      // combo_query
      // 
      this.combo_query.Dock = System.Windows.Forms.DockStyle.Top;
      this.combo_query.Location = new System.Drawing.Point(202, 35);
      this.combo_query.Name = "combo_query";
      this.combo_query.NullText = Resources.Snapshot_SelectQuery;
      this.combo_query.Size = new System.Drawing.Size(568, 30);
      this.combo_query.TabIndex = 3;
      // 
      // txt_values
      // 
      this.txt_values.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txt_values.Location = new System.Drawing.Point(202, 65);
      this.txt_values.Multiline = true;
      this.txt_values.Name = "txt_values";
      this.txt_values.NullText = Resources.Snapshot_InsertValues;
      this.txt_values.Size = new System.Drawing.Size(568, 53);
      this.txt_values.TabIndex = 4;
      ((Telerik.WinControls.UI.AutoCompleteBoxViewElement)(this.txt_values.GetChildAt(0).GetChildAt(0))).Padding = new System.Windows.Forms.Padding(2, 0, 2, 2);
      // 
      // clearPanel1
      // 
      this.clearPanel1.Controls.Add(this.radLabel1);
      this.clearPanel1.Controls.Add(this.combo_layer);
      this.clearPanel1.Dock = System.Windows.Forms.DockStyle.Left;
      this.clearPanel1.Location = new System.Drawing.Point(7, 35);
      this.clearPanel1.Name = "clearPanel1";
      this.clearPanel1.Size = new System.Drawing.Size(195, 83);
      this.clearPanel1.TabIndex = 5;
      // 
      // radLabel1
      // 
      this.radLabel1.AutoSize = false;
      this.radLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.radLabel1.Location = new System.Drawing.Point(0, 30);
      this.radLabel1.Name = "radLabel1";
      this.radLabel1.Size = new System.Drawing.Size(195, 53);
      this.radLabel1.TabIndex = 3;
      this.radLabel1.Text = Resources.Snapshot_GreenValueHint;
      // 
      // FulltextSnapshotControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Name = "FulltextSnapshotControl";
      this.Size = new System.Drawing.Size(800, 120);
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
