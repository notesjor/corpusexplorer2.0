using CorpusExplorer.Terminal.WinForm.Controls.WinForm;

namespace CorpusExplorer.Terminal.WinForm.Forms.Simple
{
  partial class SimpleTextInput
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
      this.ihdPanel1 = new IHDPanel();
      this.radTextBox1 = new Telerik.WinControls.UI.RadTextBox();
      ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // ihdPanel1
      // 
      this.ihdPanel1.BackColor = System.Drawing.Color.White;
      this.ihdPanel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.ihdPanel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ihdPanel1.IHDDeescribtion = "{IHDDESCRIBTION}";
      this.ihdPanel1.IHDHeader = "{IHDHEADER}";
      this.ihdPanel1.IHDImage = null;
      this.ihdPanel1.Location = new System.Drawing.Point(5, 0);
      this.ihdPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.ihdPanel1.Name = "ihdPanel1";
      this.ihdPanel1.Size = new System.Drawing.Size(477, 69);
      this.ihdPanel1.TabIndex = 1;
      // 
      // radTextBox1
      // 
      this.radTextBox1.Dock = System.Windows.Forms.DockStyle.Top;
      this.radTextBox1.Location = new System.Drawing.Point(5, 69);
      this.radTextBox1.Name = "radTextBox1";
      this.radTextBox1.Size = new System.Drawing.Size(477, 30);
      this.radTextBox1.TabIndex = 2;
      // 
      // SimpleTextInput
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.ClientSize = new System.Drawing.Size(487, 142);
      this.Controls.Add(this.radTextBox1);
      this.Controls.Add(this.ihdPanel1);
      this.DisplayAbort = true;
      this.Name = "SimpleTextInput";
      this.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.Text = "SimpleTextInput";
      this.Controls.SetChildIndex(this.ihdPanel1, 0);
      this.Controls.SetChildIndex(this.radTextBox1, 0);
      ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private IHDPanel ihdPanel1;
    private Telerik.WinControls.UI.RadTextBox radTextBox1;
  }
}