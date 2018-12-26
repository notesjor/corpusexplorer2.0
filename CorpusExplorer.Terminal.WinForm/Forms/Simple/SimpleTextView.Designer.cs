using CorpusExplorer.Terminal.WinForm.Properties;
namespace CorpusExplorer.Terminal.WinForm.Forms.Simple
{
  partial class SimpleTextView
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimpleTextView));
      this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
      this.wpfTagger1 = new CorpusExplorer.Terminal.WinForm.Controls.Wpf.Tagger.WpfTagger();
      this.radSplitContainer1 = new Telerik.WinControls.UI.RadSplitContainer();
      this.splitPanel1 = new Telerik.WinControls.UI.SplitPanel();
      this.splitPanel2 = new Telerik.WinControls.UI.SplitPanel();
      this.metadataEditor1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.MetadataEditor();
      this.radCommandBar1 = new Telerik.WinControls.UI.RadCommandBar();
      this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
      this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
      this.btn_prev = new Telerik.WinControls.UI.CommandBarButton();
      this.lbl_index = new Telerik.WinControls.UI.CommandBarLabel();
      this.btn_next = new Telerik.WinControls.UI.CommandBarButton();
      this.commandBarSeparator1 = new Telerik.WinControls.UI.CommandBarSeparator();
      this.btn_export = new Telerik.WinControls.UI.CommandBarButton();
      this.btn_clipboard = new Telerik.WinControls.UI.CommandBarButton();
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).BeginInit();
      this.radSplitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).BeginInit();
      this.splitPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).BeginInit();
      this.splitPanel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // radPanel1
      // 
      resources.ApplyResources(this.radPanel1, "radPanel1");
      // 
      // elementHost1
      // 
      resources.ApplyResources(this.elementHost1, "elementHost1");
      this.elementHost1.Name = "elementHost1";
      this.elementHost1.Child = this.wpfTagger1;
      // 
      // radSplitContainer1
      // 
      this.radSplitContainer1.Controls.Add(this.splitPanel1);
      this.radSplitContainer1.Controls.Add(this.splitPanel2);
      resources.ApplyResources(this.radSplitContainer1, "radSplitContainer1");
      this.radSplitContainer1.Name = "radSplitContainer1";
      // 
      // 
      // 
      this.radSplitContainer1.RootElement.MinSize = new System.Drawing.Size(0, 0);
      this.radSplitContainer1.TabStop = false;
      // 
      // splitPanel1
      // 
      this.splitPanel1.Controls.Add(this.elementHost1);
      resources.ApplyResources(this.splitPanel1, "splitPanel1");
      this.splitPanel1.Name = "splitPanel1";
      // 
      // 
      // 
      this.splitPanel1.RootElement.MinSize = new System.Drawing.Size(0, 0);
      this.splitPanel1.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(0.1821107F, 0F);
      this.splitPanel1.SizeInfo.SplitterCorrection = new System.Drawing.Size(142, 0);
      this.splitPanel1.TabStop = false;
      // 
      // splitPanel2
      // 
      this.splitPanel2.Controls.Add(this.metadataEditor1);
      resources.ApplyResources(this.splitPanel2, "splitPanel2");
      this.splitPanel2.Name = "splitPanel2";
      // 
      // 
      // 
      this.splitPanel2.RootElement.MinSize = new System.Drawing.Size(0, 0);
      this.splitPanel2.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(-0.1821107F, 0F);
      this.splitPanel2.SizeInfo.SplitterCorrection = new System.Drawing.Size(-142, 0);
      this.splitPanel2.TabStop = false;
      // 
      // metadataEditor1
      // 
      this.metadataEditor1.BackColor = System.Drawing.Color.White;
      resources.ApplyResources(this.metadataEditor1, "metadataEditor1");
      this.metadataEditor1.Name = "metadataEditor1";
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
            this.btn_prev,
            this.lbl_index,
            this.btn_next,
            this.commandBarSeparator1,
            this.btn_export,
            this.btn_clipboard});
      this.commandBarStripElement1.Name = "commandBarStripElement1";
      // 
      // btn_prev
      // 
      resources.ApplyResources(this.btn_prev, "btn_prev");
      this.btn_prev.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.button_circle_left;
      this.btn_prev.Name = "btn_prev";
      this.btn_prev.Click += new System.EventHandler(this.btn_prev_Click);
      // 
      // lbl_index
      // 
      resources.ApplyResources(this.lbl_index, "lbl_index");
      this.lbl_index.Name = "lbl_index";
      // 
      // btn_next
      // 
      resources.ApplyResources(this.btn_next, "btn_next");
      this.btn_next.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.button_circle_right;
      this.btn_next.Name = "btn_next";
      this.btn_next.Click += new System.EventHandler(this.btn_next_Click);
      // 
      // commandBarSeparator1
      // 
      resources.ApplyResources(this.commandBarSeparator1, "commandBarSeparator1");
      this.commandBarSeparator1.Name = "commandBarSeparator1";
      this.commandBarSeparator1.VisibleInOverflowMenu = false;
      // 
      // btn_export
      // 
      resources.ApplyResources(this.btn_export, "btn_export");
      this.btn_export.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.export_text;
      this.btn_export.Name = "btn_export";
      this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
      // 
      // btn_clipboard
      // 
      resources.ApplyResources(this.btn_clipboard, "btn_clipboard");
      this.btn_clipboard.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.clipboard_copy;
      this.btn_clipboard.Name = "btn_clipboard";
      this.btn_clipboard.Click += new System.EventHandler(this.btn_clipboard_Click);
      // 
      // SimpleTextView
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      resources.ApplyResources(this, "$this");
      this.Controls.Add(this.radSplitContainer1);
      this.Controls.Add(this.radCommandBar1);
      this.DisplayAbort = true;
      this.Name = "SimpleTextView";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.Controls.SetChildIndex(this.radPanel1, 0);
      this.Controls.SetChildIndex(this.radCommandBar1, 0);
      this.Controls.SetChildIndex(this.radSplitContainer1, 0);
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).EndInit();
      this.radSplitContainer1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).EndInit();
      this.splitPanel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).EndInit();
      this.splitPanel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Integration.ElementHost elementHost1;
    private Controls.Wpf.Tagger.WpfTagger wpfTagger1;
    private Telerik.WinControls.UI.RadSplitContainer radSplitContainer1;
    private Telerik.WinControls.UI.SplitPanel splitPanel1;
    private Telerik.WinControls.UI.SplitPanel splitPanel2;
    private Controls.WinForm.MetadataEditor metadataEditor1;
    private Telerik.WinControls.UI.RadCommandBar radCommandBar1;
    private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
    private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement1;
    private Telerik.WinControls.UI.CommandBarButton btn_prev;
    private Telerik.WinControls.UI.CommandBarLabel lbl_index;
    private Telerik.WinControls.UI.CommandBarButton btn_next;
    private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator1;
    private Telerik.WinControls.UI.CommandBarButton btn_export;
    private Telerik.WinControls.UI.CommandBarButton btn_clipboard;
  }
}