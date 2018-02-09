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
      this.radCommandBar1 = new Telerik.WinControls.UI.RadCommandBar();
      this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
      this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
      this.btn_new = new Telerik.WinControls.UI.CommandBarButton();
      this.btn_load = new Telerik.WinControls.UI.CommandBarButton();
      this.btn_save = new Telerik.WinControls.UI.CommandBarButton();
      this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
      this.queryBuilderControl1 = new CorpusExplorer.Terminal.WinForm.Controls.Wpf.QueryBuilder.QueryBuilderControl();
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // radPanel1
      // 
      this.radPanel1.Location = new System.Drawing.Point(0, 358);
      this.radPanel1.Size = new System.Drawing.Size(653, 38);
      // 
      // radCommandBar1
      // 
      this.radCommandBar1.Dock = System.Windows.Forms.DockStyle.Top;
      this.radCommandBar1.Location = new System.Drawing.Point(0, 0);
      this.radCommandBar1.Name = "radCommandBar1";
      this.radCommandBar1.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement1});
      this.radCommandBar1.Size = new System.Drawing.Size(653, 69);
      this.radCommandBar1.TabIndex = 1;
      this.radCommandBar1.Text = "radCommandBar1";
      // 
      // commandBarRowElement1
      // 
      this.commandBarRowElement1.MinSize = new System.Drawing.Size(25, 25);
      this.commandBarRowElement1.Strips.AddRange(new Telerik.WinControls.UI.CommandBarStripElement[] {
            this.commandBarStripElement1});
      // 
      // commandBarStripElement1
      // 
      this.commandBarStripElement1.DisplayName = "commandBarStripElement1";
      this.commandBarStripElement1.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.btn_new,
            this.btn_load,
            this.btn_save});
      this.commandBarStripElement1.Name = "commandBarStripElement1";
      // 
      // btn_new
      // 
      this.btn_new.DisplayName = "commandBarButton1";
      this.btn_new.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.document;
      this.btn_new.Name = "btn_new";
      this.btn_new.Text = "Neue Abfrage";
      this.btn_new.Click += new System.EventHandler(this.btn_new_Click);
      // 
      // btn_load
      // 
      this.btn_load.DisplayName = "commandBarButton2";
      this.btn_load.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.folder_open;
      this.btn_load.Name = "btn_load";
      this.btn_load.Text = "Abfrage laden...";
      this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
      // 
      // btn_save
      // 
      this.btn_save.DisplayName = "commandBarButton3";
      this.btn_save.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.save;
      this.btn_save.Name = "btn_save";
      this.btn_save.Text = "Abfrage speichern...";
      this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
      // 
      // elementHost1
      // 
      this.elementHost1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.elementHost1.Location = new System.Drawing.Point(0, 69);
      this.elementHost1.Name = "elementHost1";
      this.elementHost1.Size = new System.Drawing.Size(653, 289);
      this.elementHost1.TabIndex = 2;
      this.elementHost1.Text = "elementHost1";
      this.elementHost1.Child = this.queryBuilderControl1;
      // 
      // GridQueryBuilder
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(653, 396);
      this.Controls.Add(this.elementHost1);
      this.Controls.Add(this.radCommandBar1);
      this.DisplayAbort = true;
      this.Name = "GridQueryBuilder";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.Text = "Abfrage-Editor";
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
    private Controls.Wpf.QueryBuilder.QueryBuilderControl queryBuilderControl1;
  }
}