using CorpusExplorer.Terminal.WinForm.Properties;
namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm.Snapshot
{
  partial class MetadataSnapshotControl
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
      this.combo_query = new Telerik.WinControls.UI.RadDropDownList();
      this.combo_label = new Telerik.WinControls.UI.RadDropDownList();
      this.txt_values = new Telerik.WinControls.UI.RadTextBox();
      this.clearPanel1 = new ClearPanel();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
      this.radGroupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.combo_query)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.combo_label)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_values)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel1)).BeginInit();
      this.clearPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // radGroupBox1
      // 
      this.radGroupBox1.Controls.Add(this.txt_values);
      this.radGroupBox1.Controls.Add(this.combo_query);
      this.radGroupBox1.Controls.Add(this.clearPanel1);
      this.radGroupBox1.HeaderImage = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.tag_horizontal;
      this.radGroupBox1.HeaderText = Resources.Snapshot_MetaQuery;
      this.radGroupBox1.HeaderTextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.radGroupBox1.Padding = new System.Windows.Forms.Padding(7, 35, 2, 2);
      this.radGroupBox1.Size = new System.Drawing.Size(800, 120);
      this.radGroupBox1.Text = Resources.Snapshot_MetaQuery;
      this.radGroupBox1.Controls.SetChildIndex(this.clearPanel1, 0);
      this.radGroupBox1.Controls.SetChildIndex(this.combo_query, 0);
      this.radGroupBox1.Controls.SetChildIndex(this.txt_values, 0);
      // 
      // combo_query
      // 
      this.combo_query.Dock = System.Windows.Forms.DockStyle.Top;
      this.combo_query.Location = new System.Drawing.Point(202, 35);
      this.combo_query.Name = "combo_query";
      this.combo_query.NullText = Resources.Snapshot_SelectMetaQuery;
      this.combo_query.Size = new System.Drawing.Size(568, 32);
      this.combo_query.TabIndex = 6;
      this.combo_query.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.combo_query_SelectedIndexChanged);
      // 
      // combo_label
      // 
      this.combo_label.Dock = System.Windows.Forms.DockStyle.Top;
      this.combo_label.Location = new System.Drawing.Point(0, 0);
      this.combo_label.Name = "combo_label";
      this.combo_label.NullText = Resources.Snapshot_SelectMetaLabel;
      this.combo_label.Size = new System.Drawing.Size(195, 32);
      this.combo_label.TabIndex = 5;
      // 
      // txt_values
      // 
      this.txt_values.AutoSize = false;
      this.txt_values.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txt_values.Location = new System.Drawing.Point(202, 67);
      this.txt_values.Multiline = true;
      this.txt_values.Name = "txt_values";
      this.txt_values.NullText = Resources.Snapshot_InsertValues;
      this.txt_values.Size = new System.Drawing.Size(568, 51);
      this.txt_values.TabIndex = 7;
      // 
      // clearPanel1
      // 
      this.clearPanel1.Controls.Add(this.combo_label);
      this.clearPanel1.Dock = System.Windows.Forms.DockStyle.Left;
      this.clearPanel1.Location = new System.Drawing.Point(7, 35);
      this.clearPanel1.Name = "clearPanel1";
      this.clearPanel1.Size = new System.Drawing.Size(195, 83);
      this.clearPanel1.TabIndex = 8;
      // 
      // MetadataSnapshotControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Name = "MetadataSnapshotControl";
      this.Size = new System.Drawing.Size(800, 120);
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
      this.radGroupBox1.ResumeLayout(false);
      this.radGroupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.combo_query)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.combo_label)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_values)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel1)).EndInit();
      this.clearPanel1.ResumeLayout(false);
      this.clearPanel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private Telerik.WinControls.UI.RadDropDownList combo_query;
    private Telerik.WinControls.UI.RadDropDownList combo_label;
    private Telerik.WinControls.UI.RadTextBox txt_values;
    private ClearPanel clearPanel1;
  }
}
