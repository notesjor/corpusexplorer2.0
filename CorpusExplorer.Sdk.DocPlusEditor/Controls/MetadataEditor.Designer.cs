using CorpusExplorer.Tool4.DocPlusEditor.Properties;

namespace CorpusExplorer.Tool4.DocPlusEditor.Controls
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MetadataEditor));
      this.btn_meta_add = new Telerik.WinControls.UI.RadButton();
      this.property_meta = new Telerik.WinControls.UI.RadPropertyGrid();
      this.clearPanel1 = new System.Windows.Forms.Panel();
      this.btn_clipboard = new Telerik.WinControls.UI.RadButton();
      ((System.ComponentModel.ISupportInitialize)(this.btn_meta_add)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.property_meta)).BeginInit();
      this.clearPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.btn_clipboard)).BeginInit();
      this.SuspendLayout();
      // 
      // btn_meta_add
      // 
      resources.ApplyResources(this.btn_meta_add, "btn_meta_add");
      this.btn_meta_add.Image = global::CorpusExplorer.Tool4.DocPlusEditor.Properties.Resources.add_button;
      this.btn_meta_add.Name = "btn_meta_add";
      this.btn_meta_add.Click += new System.EventHandler(this.btn_meta_add_Click);
      // 
      // property_meta
      // 
      resources.ApplyResources(this.property_meta, "property_meta");
      this.property_meta.HelpBarHeight = 0F;
      this.property_meta.HelpVisible = false;
      this.property_meta.ItemHeight = 40;
      this.property_meta.ItemIndent = 40;
      this.property_meta.Name = "property_meta";
      this.property_meta.SortOrder = System.Windows.Forms.SortOrder.Ascending;
      this.property_meta.CreateItemElement += new Telerik.WinControls.UI.CreatePropertyGridItemElementEventHandler(this.Property_meta_CreateItemElement);
      this.property_meta.EditorInitialized += new Telerik.WinControls.UI.PropertyGridItemEditorInitializedEventHandler(this.Property_meta_EditorInitialized);
      // 
      // clearPanel1
      // 
      this.clearPanel1.Controls.Add(this.btn_meta_add);
      this.clearPanel1.Controls.Add(this.btn_clipboard);
      resources.ApplyResources(this.clearPanel1, "clearPanel1");
      this.clearPanel1.Name = "clearPanel1";
      // 
      // btn_clipboard
      // 
      resources.ApplyResources(this.btn_clipboard, "btn_clipboard");
      this.btn_clipboard.Image = global::CorpusExplorer.Tool4.DocPlusEditor.Properties.Resources.clipboard_copy;
      this.btn_clipboard.Name = "btn_clipboard";
      this.btn_clipboard.Click += new System.EventHandler(this.btn_clipboard_Click);
      // 
      // MetadataEditor
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.Controls.Add(this.property_meta);
      this.Controls.Add(this.clearPanel1);
      this.Name = "MetadataEditor";
      resources.ApplyResources(this, "$this");
      ((System.ComponentModel.ISupportInitialize)(this.btn_meta_add)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.property_meta)).EndInit();
      this.clearPanel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.btn_clipboard)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private Telerik.WinControls.UI.RadButton btn_meta_add;
    private Telerik.WinControls.UI.RadPropertyGrid property_meta;
    private System.Windows.Forms.Panel clearPanel1;
    private Telerik.WinControls.UI.RadButton btn_clipboard;
  }
}
