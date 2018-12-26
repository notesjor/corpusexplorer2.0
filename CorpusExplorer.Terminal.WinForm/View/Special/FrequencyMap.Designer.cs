namespace CorpusExplorer.Terminal.WinForm.View.Special
{
  partial class FrequencyMap
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrequencyMap));
      this.radCommandBar1 = new Telerik.WinControls.UI.RadCommandBar();
      this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
      this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
      this.btn_showGrid = new Telerik.WinControls.UI.CommandBarButton();
      this.commandBarSeparator1 = new Telerik.WinControls.UI.CommandBarSeparator();
      this.btn_mapNormal = new Telerik.WinControls.UI.CommandBarButton();
      this.btn_mapNormalized = new Telerik.WinControls.UI.CommandBarButton();
      this.mapSwitch1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.MapSwitch();
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
      this.SuspendLayout();
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
            this.btn_showGrid,
            this.commandBarSeparator1,
            this.btn_mapNormal,
            this.btn_mapNormalized});
      this.commandBarStripElement1.Name = "commandBarStripElement1";
      // 
      // btn_showGrid
      // 
      resources.ApplyResources(this.btn_showGrid, "btn_showGrid");
      this.btn_showGrid.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.button_circle_right;
      this.btn_showGrid.AutoToolTip = true;
      this.btn_showGrid.Name = "btn_showGrid";
      this.btn_showGrid.Click += new System.EventHandler(this.btn_showGrid_Click);
      // 
      // commandBarSeparator1
      // 
      resources.ApplyResources(this.commandBarSeparator1, "commandBarSeparator1");
      this.commandBarSeparator1.Name = "commandBarSeparator1";
      this.commandBarSeparator1.VisibleInOverflowMenu = false;
      // 
      // btn_mapNormal
      // 
      resources.ApplyResources(this.btn_mapNormal, "btn_mapNormal");
      this.btn_mapNormal.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.place;
      this.btn_mapNormal.AutoToolTip = true;
      this.btn_mapNormal.Name = "btn_mapNormal";
      this.btn_mapNormal.Click += new System.EventHandler(this.btn_mapNormal_Click);
      // 
      // btn_mapNormalized
      // 
      resources.ApplyResources(this.btn_mapNormalized, "btn_mapNormalized");
      this.btn_mapNormalized.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.colors1;
      this.btn_mapNormalized.AutoToolTip = true;
      this.btn_mapNormalized.Name = "btn_mapNormalized";
      this.btn_mapNormalized.Click += new System.EventHandler(this.btn_mapNormalized_Click);
      // 
      // mapSwitch1
      // 
      this.mapSwitch1.BackColor = System.Drawing.Color.White;
      resources.ApplyResources(this.mapSwitch1, "mapSwitch1");
      this.mapSwitch1.Name = "mapSwitch1";
      // 
      // FrequencyMap
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.Controls.Add(this.mapSwitch1);
      this.Controls.Add(this.radCommandBar1);
      this.Name = "FrequencyMap";
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Telerik.WinControls.UI.RadCommandBar radCommandBar1;
    private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
    private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement1;
    private Telerik.WinControls.UI.CommandBarButton btn_showGrid;
    private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator1;
    private Telerik.WinControls.UI.CommandBarButton btn_mapNormal;
    private Telerik.WinControls.UI.CommandBarButton btn_mapNormalized;
    private Controls.WinForm.MapSwitch mapSwitch1;
  }
}
