namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm
{
  partial class LayerSettings
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LayerSettings));
      this.grp = new Telerik.WinControls.UI.RadGroupBox();
      this.cmb_names = new Telerik.WinControls.UI.RadDropDownList();
      this.chk_active = new Telerik.WinControls.UI.RadCheckBox();
      ((System.ComponentModel.ISupportInitialize)(this.grp)).BeginInit();
      this.grp.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.cmb_names)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.chk_active)).BeginInit();
      this.SuspendLayout();
      // 
      // grp
      // 
      this.grp.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.grp.Controls.Add(this.cmb_names);
      this.grp.Controls.Add(this.chk_active);
      resources.ApplyResources(this.grp, "grp");
      this.grp.Name = "grp";
      // 
      // cmb_names
      // 
      resources.ApplyResources(this.cmb_names, "cmb_names");
      this.cmb_names.Name = "cmb_names";
      this.cmb_names.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cmb_names_SelectedIndexChanged);
      // 
      // chk_active
      // 
      this.chk_active.CheckState = System.Windows.Forms.CheckState.Checked;
      resources.ApplyResources(this.chk_active, "chk_active");
      this.chk_active.Name = "chk_active";
      this.chk_active.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
      this.chk_active.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.chk_active_ToggleStateChanged);
      this.chk_active.CheckStateChanged += new System.EventHandler(this.chk_active_CheckStateChanged);
      // 
      // LayerSettings
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.Controls.Add(this.grp);
      resources.ApplyResources(this, "$this");
      this.Name = "LayerSettings";
      ((System.ComponentModel.ISupportInitialize)(this.grp)).EndInit();
      this.grp.ResumeLayout(false);
      this.grp.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.cmb_names)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.chk_active)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private Telerik.WinControls.UI.RadGroupBox grp;
    private Telerik.WinControls.UI.RadCheckBox chk_active;
    private Telerik.WinControls.UI.RadDropDownList cmb_names;
  }
}
