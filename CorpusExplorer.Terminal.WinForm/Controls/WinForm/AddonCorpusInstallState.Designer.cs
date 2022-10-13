namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm
{
  partial class AddonCorpusInstallState
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
      this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
      this.radRichTextEditor1 = new Telerik.WinControls.UI.RadRichTextEditor();
      this.clearPanel1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.ClearPanel();
      this.btn_action = new Telerik.WinControls.UI.RadButton();
      this.lbl_label = new Telerik.WinControls.UI.RadLabel();
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
      this.radPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radRichTextEditor1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel1)).BeginInit();
      this.clearPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.btn_action)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.lbl_label)).BeginInit();
      this.SuspendLayout();
      // 
      // radPanel1
      // 
      this.radPanel1.Controls.Add(this.radRichTextEditor1);
      this.radPanel1.Controls.Add(this.clearPanel1);
      this.radPanel1.Controls.Add(this.lbl_label);
      this.radPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radPanel1.Location = new System.Drawing.Point(0, 0);
      this.radPanel1.Name = "radPanel1";
      this.radPanel1.Padding = new System.Windows.Forms.Padding(3);
      this.radPanel1.Size = new System.Drawing.Size(190, 152);
      this.radPanel1.TabIndex = 0;
      // 
      // radRichTextEditor1
      // 
      this.radRichTextEditor1.BorderColor = System.Drawing.Color.White;
      this.radRichTextEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radRichTextEditor1.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.radRichTextEditor1.HorizontalScrollBarVisibility = Telerik.WinControls.RichTextEditor.UI.ScrollBarVisibility.Hidden;
      this.radRichTextEditor1.IsContextMenuEnabled = false;
      this.radRichTextEditor1.IsReadOnly = true;
      this.radRichTextEditor1.IsSelectionEnabled = false;
      this.radRichTextEditor1.IsSelectionMiniToolBarEnabled = false;
      this.radRichTextEditor1.Location = new System.Drawing.Point(3, 29);
      this.radRichTextEditor1.Name = "radRichTextEditor1";
      this.radRichTextEditor1.Size = new System.Drawing.Size(184, 87);
      this.radRichTextEditor1.TabIndex = 7;
      // 
      // clearPanel1
      // 
      this.clearPanel1.Controls.Add(this.btn_action);
      this.clearPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.clearPanel1.Location = new System.Drawing.Point(3, 116);
      this.clearPanel1.Name = "clearPanel1";
      this.clearPanel1.Size = new System.Drawing.Size(184, 33);
      this.clearPanel1.TabIndex = 6;
      // 
      // btn_action
      // 
      this.btn_action.Dock = System.Windows.Forms.DockStyle.Fill;
      this.btn_action.Location = new System.Drawing.Point(0, 0);
      this.btn_action.Name = "btn_action";
      this.btn_action.Size = new System.Drawing.Size(184, 33);
      this.btn_action.TabIndex = 4;
      this.btn_action.Text = "Deinstallieren";
      this.btn_action.Click += new System.EventHandler(this.btn_action_Click);
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
      // AddonCorpusInstallState
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.Controls.Add(this.radPanel1);
      this.Name = "AddonCorpusInstallState";
      this.Size = new System.Drawing.Size(190, 152);
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
      this.radPanel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radRichTextEditor1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel1)).EndInit();
      this.clearPanel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.btn_action)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.lbl_label)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private Telerik.WinControls.UI.RadPanel radPanel1;
    private Telerik.WinControls.UI.RadLabel lbl_label;
    private Telerik.WinControls.UI.RadButton btn_action;
    private ClearPanel clearPanel1;
    private Telerik.WinControls.UI.RadRichTextEditor radRichTextEditor1;
  }
}
