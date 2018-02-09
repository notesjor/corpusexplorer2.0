namespace CorpusExplorer.Terminal.WinForm.Forms.Abstract
{
  partial class AbstractError
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
      if (disposing && (this.components != null))
      {
        this.components.Dispose();
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
      this.lbl_funnyHeader = new Telerik.WinControls.UI.RadLabel();
      this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
      this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
      ((System.ComponentModel.ISupportInitialize)(this.lbl_funnyHeader)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // lbl_funnyHeader
      // 
      this.lbl_funnyHeader.Dock = System.Windows.Forms.DockStyle.Top;
      this.lbl_funnyHeader.Font = new System.Drawing.Font("Segoe UI", 16F);
      this.lbl_funnyHeader.Location = new System.Drawing.Point(0, 0);
      this.lbl_funnyHeader.Name = "lbl_funnyHeader";
      this.lbl_funnyHeader.Size = new System.Drawing.Size(80, 33);
      this.lbl_funnyHeader.TabIndex = 0;
      this.lbl_funnyHeader.Text = "FUNNY";
      // 
      // radLabel1
      // 
      this.radLabel1.AutoSize = false;
      this.radLabel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.radLabel1.Location = new System.Drawing.Point(0, 33);
      this.radLabel1.Name = "radLabel1";
      this.radLabel1.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
      this.radLabel1.Size = new System.Drawing.Size(544, 61);
      this.radLabel1.TabIndex = 1;
      this.radLabel1.Text = "{Beschreibung warum es gerade jetzt passiert}";
      // 
      // radLabel2
      // 
      this.radLabel2.Dock = System.Windows.Forms.DockStyle.Top;
      this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 13F);
      this.radLabel2.Location = new System.Drawing.Point(0, 94);
      this.radLabel2.Name = "radLabel2";
      this.radLabel2.Size = new System.Drawing.Size(181, 27);
      this.radLabel2.TabIndex = 2;
      this.radLabel2.Text = "Alles halb so schlimm:";
      // 
      // AbstractError
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(544, 365);
      this.Controls.Add(this.radLabel2);
      this.Controls.Add(this.radLabel1);
      this.Controls.Add(this.lbl_funnyHeader);
      this.DisplayAbort = true;
      this.Name = "AbstractError";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.Text = "AbstractError";
      this.Controls.SetChildIndex(this.lbl_funnyHeader, 0);
      this.Controls.SetChildIndex(this.radLabel1, 0);
      this.Controls.SetChildIndex(this.radLabel2, 0);
      ((System.ComponentModel.ISupportInitialize)(this.lbl_funnyHeader)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Telerik.WinControls.UI.RadLabel lbl_funnyHeader;
    protected Telerik.WinControls.UI.RadLabel radLabel2;
    protected Telerik.WinControls.UI.RadLabel radLabel1;
  }
}