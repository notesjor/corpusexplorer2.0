namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm
{
  partial class QuickFix
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
      if (disposing && (this.components != null))
      {
        this.components.Dispose();
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
      this.radCheckBox1 = new Telerik.WinControls.UI.RadCheckBox();
      this.btn_fix = new Telerik.WinControls.UI.RadButton();
      this.btn_refresh = new Telerik.WinControls.UI.RadButton();
      this.btn_info = new Telerik.WinControls.UI.RadButton();
      ((System.ComponentModel.ISupportInitialize)(this.radCheckBox1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_fix)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_refresh)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_info)).BeginInit();
      this.SuspendLayout();
      // 
      // radCheckBox1
      // 
      this.radCheckBox1.AutoSize = false;
      this.radCheckBox1.BackColor = System.Drawing.Color.White;
      this.radCheckBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radCheckBox1.Location = new System.Drawing.Point(0, 0);
      this.radCheckBox1.Name = "radCheckBox1";
      this.radCheckBox1.ReadOnly = true;
      this.radCheckBox1.Size = new System.Drawing.Size(318, 53);
      this.radCheckBox1.TabIndex = 3;
      this.radCheckBox1.Text = "QuickFixText";
      // 
      // btn_fix
      // 
      this.btn_fix.Dock = System.Windows.Forms.DockStyle.Right;
      this.btn_fix.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.execute;
      this.btn_fix.Location = new System.Drawing.Point(318, 0);
      this.btn_fix.Name = "btn_fix";
      this.btn_fix.Size = new System.Drawing.Size(30, 53);
      this.btn_fix.TabIndex = 2;
      this.btn_fix.Click += new System.EventHandler(this.btn_fix_Click);
      ((Telerik.WinControls.UI.RadButtonElement)(this.btn_fix.GetChildAt(0))).Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.execute;
      ((Telerik.WinControls.Primitives.BorderPrimitive)(this.btn_fix.GetChildAt(0).GetChildAt(2))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
      ((Telerik.WinControls.Primitives.BorderPrimitive)(this.btn_fix.GetChildAt(0).GetChildAt(2))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
      // 
      // btn_refresh
      // 
      this.btn_refresh.Dock = System.Windows.Forms.DockStyle.Right;
      this.btn_refresh.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.refresh;
      this.btn_refresh.Location = new System.Drawing.Point(348, 0);
      this.btn_refresh.Name = "btn_refresh";
      this.btn_refresh.Size = new System.Drawing.Size(30, 53);
      this.btn_refresh.TabIndex = 1;
      this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
      ((Telerik.WinControls.UI.RadButtonElement)(this.btn_refresh.GetChildAt(0))).Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.refresh;
      ((Telerik.WinControls.Primitives.BorderPrimitive)(this.btn_refresh.GetChildAt(0).GetChildAt(2))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
      ((Telerik.WinControls.Primitives.BorderPrimitive)(this.btn_refresh.GetChildAt(0).GetChildAt(2))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
      // 
      // btn_info
      // 
      this.btn_info.Dock = System.Windows.Forms.DockStyle.Right;
      this.btn_info.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.info;
      this.btn_info.Location = new System.Drawing.Point(378, 0);
      this.btn_info.Name = "btn_info";
      this.btn_info.Size = new System.Drawing.Size(30, 53);
      this.btn_info.TabIndex = 0;
      this.btn_info.Click += new System.EventHandler(this.btn_info_Click);
      ((Telerik.WinControls.UI.RadButtonElement)(this.btn_info.GetChildAt(0))).Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.info;
      ((Telerik.WinControls.UI.RadButtonElement)(this.btn_info.GetChildAt(0))).Text = "";
      ((Telerik.WinControls.Primitives.BorderPrimitive)(this.btn_info.GetChildAt(0).GetChildAt(2))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
      ((Telerik.WinControls.Primitives.BorderPrimitive)(this.btn_info.GetChildAt(0).GetChildAt(2))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
      // 
      // QuickFix
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.Controls.Add(this.radCheckBox1);
      this.Controls.Add(this.btn_fix);
      this.Controls.Add(this.btn_refresh);
      this.Controls.Add(this.btn_info);
      this.Font = new System.Drawing.Font("Segoe UI", 12F);
      this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.Name = "QuickFix";
      this.Size = new System.Drawing.Size(408, 53);
      ((System.ComponentModel.ISupportInitialize)(this.radCheckBox1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_fix)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_refresh)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_info)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private Telerik.WinControls.UI.RadButton btn_refresh;
    private Telerik.WinControls.UI.RadButton btn_fix;
    private Telerik.WinControls.UI.RadCheckBox radCheckBox1;
    private Telerik.WinControls.UI.RadButton btn_info;
  }
}
