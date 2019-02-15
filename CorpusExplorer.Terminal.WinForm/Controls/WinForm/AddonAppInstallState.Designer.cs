namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm
{
  partial class AddonAppInstallState
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddonAppInstallState));
      this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
      this.lbl_size = new Telerik.WinControls.UI.RadLabel();
      this.btn_action = new Telerik.WinControls.UI.RadButton();
      this.lbl_description = new Telerik.WinControls.UI.RadLabel();
      this.btn_info = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.InfoButton();
      this.lbl_label = new Telerik.WinControls.UI.RadLabel();
      this.clearPanel1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.ClearPanel();
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
      this.radPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.lbl_size)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_action)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.lbl_description)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_info)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.lbl_label)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel1)).BeginInit();
      this.clearPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // radPanel1
      // 
      this.radPanel1.Controls.Add(this.lbl_description);
      this.radPanel1.Controls.Add(this.lbl_size);
      this.radPanel1.Controls.Add(this.clearPanel1);
      this.radPanel1.Controls.Add(this.lbl_label);
      this.radPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radPanel1.Location = new System.Drawing.Point(0, 0);
      this.radPanel1.Name = "radPanel1";
      this.radPanel1.Padding = new System.Windows.Forms.Padding(3);
      this.radPanel1.Size = new System.Drawing.Size(190, 152);
      this.radPanel1.TabIndex = 0;
      // 
      // lbl_size
      // 
      this.lbl_size.AutoSize = false;
      this.lbl_size.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.lbl_size.Font = new System.Drawing.Font("Segoe UI", 8F);
      this.lbl_size.Location = new System.Drawing.Point(3, 98);
      this.lbl_size.Margin = new System.Windows.Forms.Padding(0);
      this.lbl_size.Name = "lbl_size";
      this.lbl_size.Size = new System.Drawing.Size(184, 18);
      this.lbl_size.TabIndex = 5;
      this.lbl_size.Text = "<html><strong>Benötigt:</strong> ca. {Size}</html>";
      this.lbl_size.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
      // 
      // btn_action
      // 
      this.btn_action.Dock = System.Windows.Forms.DockStyle.Fill;
      this.btn_action.Location = new System.Drawing.Point(33, 0);
      this.btn_action.Name = "btn_action";
      this.btn_action.Size = new System.Drawing.Size(151, 33);
      this.btn_action.TabIndex = 4;
      this.btn_action.Text = "Deinstallieren";
      this.btn_action.Click += new System.EventHandler(this.btn_action_Click);
      // 
      // lbl_description
      // 
      this.lbl_description.AutoSize = false;
      this.lbl_description.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lbl_description.Font = new System.Drawing.Font("Segoe UI", 8F);
      this.lbl_description.Location = new System.Drawing.Point(3, 29);
      this.lbl_description.Margin = new System.Windows.Forms.Padding(0);
      this.lbl_description.Name = "lbl_description";
      this.lbl_description.Size = new System.Drawing.Size(184, 69);
      this.lbl_description.TabIndex = 3;
      this.lbl_description.Text = "{Description}";
      this.lbl_description.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
      // 
      // btn_info
      // 
      this.btn_info.Dock = System.Windows.Forms.DockStyle.Left;
      this.btn_info.Image = ((System.Drawing.Image)(resources.GetObject("btn_info.Image")));
      this.btn_info.InfoDescription = null;
      this.btn_info.InfoHeader = null;
      this.btn_info.InfoImage = null;
      this.btn_info.Location = new System.Drawing.Point(0, 0);
      this.btn_info.MaximumSize = new System.Drawing.Size(33, 33);
      this.btn_info.MinimumSize = new System.Drawing.Size(33, 33);
      this.btn_info.Name = "btn_info";
      // 
      // 
      // 
      this.btn_info.RootElement.MaxSize = new System.Drawing.Size(33, 33);
      this.btn_info.RootElement.MinSize = new System.Drawing.Size(33, 33);
      this.btn_info.Size = new System.Drawing.Size(33, 33);
      this.btn_info.TabIndex = 2;
      this.btn_info.Click += new System.EventHandler(this.btn_info_Click);
      // 
      // lbl_label
      // 
      this.lbl_label.AutoSize = false;
      this.lbl_label.Dock = System.Windows.Forms.DockStyle.Top;
      this.lbl_label.Location = new System.Drawing.Point(3, 3);
      this.lbl_label.Name = "lbl_label";
      this.lbl_label.Size = new System.Drawing.Size(184, 26);
      this.lbl_label.TabIndex = 0;
      this.lbl_label.Text = "{LABEL}";
      this.lbl_label.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // clearPanel1
      // 
      this.clearPanel1.Controls.Add(this.btn_action);
      this.clearPanel1.Controls.Add(this.btn_info);
      this.clearPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.clearPanel1.Location = new System.Drawing.Point(3, 116);
      this.clearPanel1.Name = "clearPanel1";
      this.clearPanel1.Size = new System.Drawing.Size(184, 33);
      this.clearPanel1.TabIndex = 6;
      // 
      // AddonInstallState
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.Controls.Add(this.radPanel1);
      this.Name = "AddonInstallState";
      this.Size = new System.Drawing.Size(190, 152);
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
      this.radPanel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.lbl_size)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_action)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.lbl_description)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_info)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.lbl_label)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel1)).EndInit();
      this.clearPanel1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private Telerik.WinControls.UI.RadPanel radPanel1;
    private Telerik.WinControls.UI.RadLabel lbl_label;
    private Telerik.WinControls.UI.RadButton btn_action;
    private Telerik.WinControls.UI.RadLabel lbl_description;
    private InfoButton btn_info;
    private Telerik.WinControls.UI.RadLabel lbl_size;
    private ClearPanel clearPanel1;
  }
}
