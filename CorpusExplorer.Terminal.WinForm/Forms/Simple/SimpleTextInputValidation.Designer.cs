namespace CorpusExplorer.Terminal.WinForm.Forms.Simple
{
  partial class SimpleTextInputValidation
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.warnBox1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.WarnBox();
      ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // radTextBox1
      // 
      this.radTextBox1.Size = new System.Drawing.Size(477, 37);
      this.radTextBox1.TextChanged += new System.EventHandler(this.radTextBox1_TextChanged);
      // 
      // radPanel1
      // 
      this.radPanel1.Location = new System.Drawing.Point(5, 140);
      // 
      // warnBox1
      // 
      this.warnBox1.BackColor = System.Drawing.Color.White;
      this.warnBox1.Dock = System.Windows.Forms.DockStyle.Top;
      this.warnBox1.Font = new System.Drawing.Font("Segoe UI", 11F);
      this.warnBox1.Location = new System.Drawing.Point(5, 106);
      this.warnBox1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
      this.warnBox1.Name = "warnBox1";
      this.warnBox1.Size = new System.Drawing.Size(477, 32);
      this.warnBox1.TabIndex = 3;
      // 
      // SimpleTextInputValidation
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(487, 178);
      this.Controls.Add(this.warnBox1);
      this.DisplayAbort = true;
      this.Name = "SimpleTextInputValidation";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.Text = "SimpleTextInputValidation";
      this.Controls.SetChildIndex(this.radTextBox1, 0);
      this.Controls.SetChildIndex(this.radPanel1, 0);
      this.Controls.SetChildIndex(this.warnBox1, 0);
      ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

        #endregion

        private Controls.WinForm.WarnBox warnBox1;
    }
}