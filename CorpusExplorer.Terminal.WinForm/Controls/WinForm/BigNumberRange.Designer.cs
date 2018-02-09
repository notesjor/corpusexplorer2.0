namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm
{
  partial class BigNumberRange
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
      this.txt_dispersion = new Telerik.WinControls.UI.RadLabel();
      this.clearPanel2 = new ClearPanel();
      this.txt_highvalue = new Telerik.WinControls.UI.RadLabel();
      this.pictureBox2 = new System.Windows.Forms.PictureBox();
      this.clearPanel1 = new ClearPanel();
      this.txt_lowvalue = new Telerik.WinControls.UI.RadLabel();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      ((System.ComponentModel.ISupportInitialize)(this.txt_label)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_value)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_dispersion)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel2)).BeginInit();
      this.clearPanel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.txt_highvalue)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel1)).BeginInit();
      this.clearPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.txt_lowvalue)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
      this.txt_value.Font = new System.Drawing.Font("Segoe UI Light", 18F);
      this.txt_value.Location = new System.Drawing.Point(20, 0);
      this.txt_value.Name = "txt_value";
      this.txt_value.Size = new System.Drawing.Size(95, 89);
      this.txt_value.TabIndex = 1;
      this.txt_value.Text = "{VALUE}";
      this.txt_value.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
      // 
      // txt_dispersion
      // 
      this.txt_dispersion.AutoSize = false;
      this.txt_dispersion.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.txt_dispersion.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.txt_dispersion.ForeColor = System.Drawing.Color.Gray;
      this.txt_dispersion.Location = new System.Drawing.Point(20, 89);
      this.txt_dispersion.Name = "txt_dispersion";
      this.txt_dispersion.Size = new System.Drawing.Size(95, 18);
      this.txt_dispersion.TabIndex = 4;
      this.txt_dispersion.Text = "{Dispersion}";
      this.txt_dispersion.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
      // 
      // clearPanel2
      // 
      this.clearPanel2.Controls.Add(this.txt_highvalue);
      this.clearPanel2.Controls.Add(this.pictureBox2);
      this.clearPanel2.Dock = System.Windows.Forms.DockStyle.Right;
      this.clearPanel2.Location = new System.Drawing.Point(115, 0);
      this.clearPanel2.Name = "clearPanel2";
      this.clearPanel2.Size = new System.Drawing.Size(20, 107);
      this.clearPanel2.TabIndex = 6;
      // 
      // txt_highvalue
      // 
      this.txt_highvalue.AutoSize = false;
      this.txt_highvalue.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txt_highvalue.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.txt_highvalue.ForeColor = System.Drawing.Color.LimeGreen;
      this.txt_highvalue.Location = new System.Drawing.Point(0, 20);
      this.txt_highvalue.Name = "txt_highvalue";
      this.txt_highvalue.Size = new System.Drawing.Size(20, 87);
      this.txt_highvalue.TabIndex = 1;
      this.txt_highvalue.Text = "{HighValue}";
      this.txt_highvalue.TextAlignment = System.Drawing.ContentAlignment.TopRight;
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.txt_highvalue.GetChildAt(0).GetChildAt(2).GetChildAt(1))).TextAlignment = System.Drawing.ContentAlignment.TopRight;
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.txt_highvalue.GetChildAt(0).GetChildAt(2).GetChildAt(1))).AngleTransform = 90F;
      // 
      // pictureBox2
      // 
      this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Top;
      this.pictureBox2.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.up_green;
      this.pictureBox2.Location = new System.Drawing.Point(0, 0);
      this.pictureBox2.Name = "pictureBox2";
      this.pictureBox2.Size = new System.Drawing.Size(20, 20);
      this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
      this.pictureBox2.TabIndex = 0;
      this.pictureBox2.TabStop = false;
      // 
      // clearPanel1
      // 
      this.clearPanel1.Controls.Add(this.txt_lowvalue);
      this.clearPanel1.Controls.Add(this.pictureBox1);
      this.clearPanel1.Dock = System.Windows.Forms.DockStyle.Left;
      this.clearPanel1.Location = new System.Drawing.Point(0, 0);
      this.clearPanel1.Name = "clearPanel1";
      this.clearPanel1.Size = new System.Drawing.Size(20, 107);
      this.clearPanel1.TabIndex = 5;
      // 
      // txt_lowvalue
      // 
      this.txt_lowvalue.AutoSize = false;
      this.txt_lowvalue.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txt_lowvalue.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.txt_lowvalue.ForeColor = System.Drawing.Color.Brown;
      this.txt_lowvalue.Location = new System.Drawing.Point(0, 0);
      this.txt_lowvalue.Name = "txt_lowvalue";
      // 
      // 
      // 
      this.txt_lowvalue.RootElement.AngleTransform = 0F;
      this.txt_lowvalue.Size = new System.Drawing.Size(20, 91);
      this.txt_lowvalue.TabIndex = 1;
      this.txt_lowvalue.Text = "{LowValue}";
      this.txt_lowvalue.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.txt_lowvalue.GetChildAt(0).GetChildAt(2).GetChildAt(1))).TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.txt_lowvalue.GetChildAt(0).GetChildAt(2).GetChildAt(1))).AngleTransform = 270F;
      // 
      // pictureBox1
      // 
      this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.pictureBox1.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.down_red;
      this.pictureBox1.Location = new System.Drawing.Point(0, 91);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(20, 16);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
      this.pictureBox1.TabIndex = 0;
      this.pictureBox1.TabStop = false;
      // 
      // BigNumberRange
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.BackColor = System.Drawing.Color.White;
      this.Controls.Add(this.txt_value);
      this.Controls.Add(this.txt_dispersion);
      this.Controls.Add(this.clearPanel2);
      this.Controls.Add(this.clearPanel1);
      this.Controls.Add(this.txt_label);
      this.Font = new System.Drawing.Font("Segoe UI", 11F);
      this.Name = "BigNumberRange";
      this.Size = new System.Drawing.Size(135, 135);
      ((System.ComponentModel.ISupportInitialize)(this.txt_label)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_value)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_dispersion)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel2)).EndInit();
      this.clearPanel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.txt_highvalue)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel1)).EndInit();
      this.clearPanel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.txt_lowvalue)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private Telerik.WinControls.UI.RadLabel txt_label;
    private Telerik.WinControls.UI.RadLabel txt_value;
    private Telerik.WinControls.UI.RadLabel txt_dispersion;
    private ClearPanel clearPanel1;
    private ClearPanel clearPanel2;
    private Telerik.WinControls.UI.RadLabel txt_lowvalue;
    private System.Windows.Forms.PictureBox pictureBox1;
    private Telerik.WinControls.UI.RadLabel txt_highvalue;
    private System.Windows.Forms.PictureBox pictureBox2;
  }
}
