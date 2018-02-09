namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm
{
  partial class BigNumber
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
      this.txt_label = new Telerik.WinControls.UI.RadLabel();
      this.txt_value = new Telerik.WinControls.UI.RadLabel();
      ((System.ComponentModel.ISupportInitialize)(this.txt_label)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_value)).BeginInit();
      this.SuspendLayout();
      // 
      // txt_label
      // 
      this.txt_label.AutoSize = false;
      this.txt_label.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.txt_label.Location = new System.Drawing.Point(0, 107);
      this.txt_label.Name = "txt_label";
      this.txt_label.Size = new System.Drawing.Size(135, 28);
      this.txt_label.TabIndex = 0;
      this.txt_label.Text = "{LABEL}";
      this.txt_label.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
      // 
      // txt_value
      // 
      this.txt_value.AutoSize = false;
      this.txt_value.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txt_value.Font = new System.Drawing.Font("Segoe UI Light", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txt_value.Location = new System.Drawing.Point(0, 0);
      this.txt_value.Name = "txt_value";
      this.txt_value.Size = new System.Drawing.Size(135, 107);
      this.txt_value.TabIndex = 1;
      this.txt_value.Text = "{VALUE}";
      this.txt_value.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
      // 
      // BigNumber
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.BackColor = System.Drawing.Color.White;
      this.Controls.Add(this.txt_value);
      this.Controls.Add(this.txt_label);
      this.Font = new System.Drawing.Font("Segoe UI", 11F);
      this.Name = "BigNumber";
      this.Size = new System.Drawing.Size(135, 135);
      ((System.ComponentModel.ISupportInitialize)(this.txt_label)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_value)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private Telerik.WinControls.UI.RadLabel txt_label;
    private Telerik.WinControls.UI.RadLabel txt_value;
  }
}
