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
      this.grp.Dock = System.Windows.Forms.DockStyle.Fill;
      this.grp.HeaderText = "[HEADER]";
      this.grp.Location = new System.Drawing.Point(0, 0);
      this.grp.Name = "grp";
      this.grp.Padding = new System.Windows.Forms.Padding(5, 25, 5, 5);
      this.grp.Size = new System.Drawing.Size(400, 62);
      this.grp.TabIndex = 0;
      this.grp.Text = "[HEADER]";
      // 
      // cmb_names
      // 
      this.cmb_names.Dock = System.Windows.Forms.DockStyle.Fill;
      this.cmb_names.Location = new System.Drawing.Point(42, 25);
      this.cmb_names.Name = "cmb_names";
      this.cmb_names.NullText = "Bitte auswählen...";
      this.cmb_names.Size = new System.Drawing.Size(353, 32);
      this.cmb_names.TabIndex = 1;
      // 
      // chk_active
      // 
      this.chk_active.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chk_active.Dock = System.Windows.Forms.DockStyle.Left;
      this.chk_active.Location = new System.Drawing.Point(5, 25);
      this.chk_active.Name = "chk_active";
      this.chk_active.Size = new System.Drawing.Size(37, 32);
      this.chk_active.TabIndex = 0;
      this.chk_active.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
      this.chk_active.CheckStateChanged += new System.EventHandler(this.chk_active_CheckStateChanged);
      // 
      // LayerSettings
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.Controls.Add(this.grp);
      this.Margin = new System.Windows.Forms.Padding(3);
      this.Name = "LayerSettings";
      this.Size = new System.Drawing.Size(400, 62);
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
