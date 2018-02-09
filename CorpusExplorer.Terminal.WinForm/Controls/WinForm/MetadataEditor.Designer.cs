namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm
{
  partial class MetadataEditor
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
      this.btn_meta_add = new Telerik.WinControls.UI.RadButton();
      this.property_meta = new Telerik.WinControls.UI.RadPropertyGrid();
      this.clearPanel1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.ClearPanel();
      this.btn_clipboard = new Telerik.WinControls.UI.RadButton();
      ((System.ComponentModel.ISupportInitialize)(this.btn_meta_add)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.property_meta)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel1)).BeginInit();
      this.clearPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.btn_clipboard)).BeginInit();
      this.SuspendLayout();
      // 
      // btn_meta_add
      // 
      this.btn_meta_add.Dock = System.Windows.Forms.DockStyle.Fill;
      this.btn_meta_add.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.add_button;
      this.btn_meta_add.ImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
      this.btn_meta_add.Location = new System.Drawing.Point(0, 0);
      this.btn_meta_add.Name = "btn_meta_add";
      this.btn_meta_add.Size = new System.Drawing.Size(292, 34);
      this.btn_meta_add.TabIndex = 0;
      this.btn_meta_add.Text = "Hinzufügen";
      this.btn_meta_add.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
      this.btn_meta_add.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btn_meta_add.Click += new System.EventHandler(this.btn_meta_add_Click);
      // 
      // property_meta
      // 
      this.property_meta.Dock = System.Windows.Forms.DockStyle.Fill;
      this.property_meta.HelpBarHeight = 0F;
      this.property_meta.HelpVisible = false;
      this.property_meta.ItemHeight = 40;
      this.property_meta.ItemIndent = 40;
      this.property_meta.Location = new System.Drawing.Point(0, 34);
      this.property_meta.Name = "property_meta";
      this.property_meta.Size = new System.Drawing.Size(322, 399);
      this.property_meta.SortOrder = System.Windows.Forms.SortOrder.Ascending;
      this.property_meta.TabIndex = 1;
      this.property_meta.Text = "radPropertyGrid1";
      this.property_meta.EditorInitialized += Property_meta_EditorInitialized;
      this.property_meta.CreateItemElement += Property_meta_CreateItemElement;
      // 
      // clearPanel1
      // 
      this.clearPanel1.Controls.Add(this.btn_meta_add);
      this.clearPanel1.Controls.Add(this.btn_clipboard);
      this.clearPanel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.clearPanel1.Location = new System.Drawing.Point(0, 0);
      this.clearPanel1.Name = "clearPanel1";
      this.clearPanel1.Size = new System.Drawing.Size(322, 34);
      this.clearPanel1.TabIndex = 2;
      this.clearPanel1.Text = "clearPanel1";
      // 
      // btn_clipboard
      // 
      this.btn_clipboard.AccessibleDescription = "In die Zwischenablage kopieren";
      this.btn_clipboard.Dock = System.Windows.Forms.DockStyle.Right;
      this.btn_clipboard.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.clipboard_copy;
      this.btn_clipboard.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
      this.btn_clipboard.Location = new System.Drawing.Point(292, 0);
      this.btn_clipboard.Name = "btn_clipboard";
      this.btn_clipboard.Size = new System.Drawing.Size(30, 34);
      this.btn_clipboard.TabIndex = 1;
      this.btn_clipboard.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
      this.btn_clipboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btn_clipboard.Click += new System.EventHandler(this.btn_clipboard_Click);
      // 
      // MetadataEditor
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.property_meta);
      this.Controls.Add(this.clearPanel1);
      this.Name = "MetadataEditor";
      this.Size = new System.Drawing.Size(322, 433);
      ((System.ComponentModel.ISupportInitialize)(this.btn_meta_add)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.property_meta)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel1)).EndInit();
      this.clearPanel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.btn_clipboard)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private Telerik.WinControls.UI.RadButton btn_meta_add;
    private Telerik.WinControls.UI.RadPropertyGrid property_meta;
    private ClearPanel clearPanel1;
    private Telerik.WinControls.UI.RadButton btn_clipboard;
  }
}
