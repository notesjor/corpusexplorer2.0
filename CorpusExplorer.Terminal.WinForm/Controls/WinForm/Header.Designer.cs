namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm
{
  partial class Header
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
      this.lbl_describtion = new Telerik.WinControls.UI.RadLabel();
      this.lbl_head = new Telerik.WinControls.UI.RadLabel();
      ((System.ComponentModel.ISupportInitialize)(this.lbl_describtion)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.lbl_head)).BeginInit();
      this.SuspendLayout();
      // 
      // lbl_describtion
      // 
      this.lbl_describtion.AutoSize = false;
      this.lbl_describtion.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lbl_describtion.Font = new System.Drawing.Font("Segoe UI", 10F);
      this.lbl_describtion.Location = new System.Drawing.Point(0, 30);
      this.lbl_describtion.Name = "lbl_describtion";
      this.lbl_describtion.Size = new System.Drawing.Size(545, 39);
      this.lbl_describtion.TabIndex = 23;
      this.lbl_describtion.Text = "{HeaderDescribtion}";
      // 
      // lbl_head
      // 
      this.lbl_head.AutoSize = false;
      this.lbl_head.Dock = System.Windows.Forms.DockStyle.Top;
      this.lbl_head.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lbl_head.Location = new System.Drawing.Point(0, 0);
      this.lbl_head.Name = "lbl_head";
      this.lbl_head.Size = new System.Drawing.Size(545, 30);
      this.lbl_head.TabIndex = 22;
      this.lbl_head.Text = "{HeaderHead}";
      // 
      // Header
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.lbl_describtion);
      this.Controls.Add(this.lbl_head);
      this.Name = "Header";
      this.Size = new System.Drawing.Size(545, 69);
      ((System.ComponentModel.ISupportInitialize)(this.lbl_describtion)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.lbl_head)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private Telerik.WinControls.UI.RadLabel lbl_describtion;
    private Telerik.WinControls.UI.RadLabel lbl_head;
  }
}
