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
      this.radCommandBar1.Dock = System.Windows.Forms.DockStyle.Top;
      this.radCommandBar1.Location = new System.Drawing.Point(0, 0);
      this.radCommandBar1.Name = "radCommandBar1";
      this.radCommandBar1.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement1});
      this.radCommandBar1.Size = new System.Drawing.Size(780, 69);
      this.radCommandBar1.TabIndex = 0;
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
            this.btn_showGrid,
            this.commandBarSeparator1,
            this.btn_mapNormal,
            this.btn_mapNormalized});
      this.commandBarStripElement1.Name = "commandBarStripElement1";
      // 
      // btn_showGrid
      // 
      this.btn_showGrid.DisplayName = "commandBarButton1";
      this.btn_showGrid.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.button_circle_right;
      this.btn_showGrid.Name = "btn_showGrid";
      this.btn_showGrid.Text = "Abfragetabelle";
      this.btn_showGrid.Click += new System.EventHandler(this.btn_showGrid_Click);
      // 
      // commandBarSeparator1
      // 
      this.commandBarSeparator1.DisplayName = "commandBarSeparator1";
      this.commandBarSeparator1.Name = "commandBarSeparator1";
      this.commandBarSeparator1.VisibleInOverflowMenu = false;
      // 
      // btn_mapNormal
      // 
      this.btn_mapNormal.DisplayName = "commandBarButton2";
      this.btn_mapNormal.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.place;
      this.btn_mapNormal.Name = "btn_mapNormal";
      this.btn_mapNormal.Text = "Karte (standard)";
      this.btn_mapNormal.Click += new System.EventHandler(this.btn_mapNormal_Click);
      // 
      // btn_mapNormalized
      // 
      this.btn_mapNormalized.DisplayName = "commandBarButton3";
      this.btn_mapNormalized.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.colors1;
      this.btn_mapNormalized.Name = "btn_mapNormalized";
      this.btn_mapNormalized.Text = "Karte (normiert)";
      this.btn_mapNormalized.Click += new System.EventHandler(this.btn_mapNormalized_Click);
      // 
      // mapSwitch1
      // 
      this.mapSwitch1.BackColor = System.Drawing.Color.White;
      this.mapSwitch1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.mapSwitch1.Font = new System.Drawing.Font("Segoe UI", 11F);
      this.mapSwitch1.Location = new System.Drawing.Point(0, 69);
      this.mapSwitch1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
      this.mapSwitch1.Name = "mapSwitch1";
      this.mapSwitch1.Size = new System.Drawing.Size(780, 331);
      this.mapSwitch1.TabIndex = 1;
      // 
      // FrequencyMap
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
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
