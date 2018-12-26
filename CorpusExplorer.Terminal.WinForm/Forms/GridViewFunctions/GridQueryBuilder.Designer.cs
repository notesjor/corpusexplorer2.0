namespace CorpusExplorer.Terminal.WinForm.Forms.GridViewFunctions
{
  partial class GridQueryBuilder
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GridQueryBuilder));
      this.radCommandBar1 = new Telerik.WinControls.UI.RadCommandBar();
      this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
      this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
      this.btn_new = new Telerik.WinControls.UI.CommandBarButton();
      this.btn_load = new Telerik.WinControls.UI.CommandBarButton();
      this.btn_save = new Telerik.WinControls.UI.CommandBarButton();
      this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // radPanel1
      // 
      resources.ApplyResources(this.radPanel1, "radPanel1");
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
            this.btn_new,
            this.btn_load,
            this.btn_save});
      this.commandBarStripElement1.Name = "commandBarStripElement1";
      // 
      // btn_new
      // 
      resources.ApplyResources(this.btn_new, "btn_new");
      this.btn_new.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.document;
      this.btn_new.Name = "btn_new";
      this.btn_new.Click += new System.EventHandler(this.btn_new_Click);
      // 
      // btn_load
      // 
      resources.ApplyResources(this.btn_load, "btn_load");
      this.btn_load.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.folder_open;
      this.btn_load.Name = "btn_load";
      this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
      // 
      // btn_save
      // 
      resources.ApplyResources(this.btn_save, "btn_save");
      this.btn_save.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.save;
      this.btn_save.Name = "btn_save";
      this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
      // 
      // elementHost1
      // 
      resources.ApplyResources(this.elementHost1, "elementHost1");
      this.elementHost1.Name = "elementHost1";
      this.elementHost1.Child = null;
      // 
      // GridQueryBuilder
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      resources.ApplyResources(this, "$this");
      this.Controls.Add(this.elementHost1);
      this.Controls.Add(this.radCommandBar1);
      this.DisplayAbort = true;
      this.Name = "GridQueryBuilder";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.Controls.SetChildIndex(this.radPanel1, 0);
      this.Controls.SetChildIndex(this.radCommandBar1, 0);
      this.Controls.SetChildIndex(this.elementHost1, 0);
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Telerik.WinControls.UI.RadCommandBar radCommandBar1;
    private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
    private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement1;
    private Telerik.WinControls.UI.CommandBarButton btn_new;
    private Telerik.WinControls.UI.CommandBarButton btn_load;
    private Telerik.WinControls.UI.CommandBarButton btn_save;
    private System.Windows.Forms.Integration.ElementHost elementHost1;    
  }
}