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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AbstractError));
      this.lbl_funnyHeader = new Telerik.WinControls.UI.RadLabel();
      this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
      this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.lbl_funnyHeader)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // radPanel1
      // 
      resources.ApplyResources(this.radPanel1, "radPanel1");
      // 
      // lbl_funnyHeader
      // 
      resources.ApplyResources(this.lbl_funnyHeader, "lbl_funnyHeader");
      this.lbl_funnyHeader.Name = "lbl_funnyHeader";
      // 
      // radLabel1
      // 
      resources.ApplyResources(this.radLabel1, "radLabel1");
      this.radLabel1.Name = "radLabel1";
      // 
      // radLabel2
      // 
      resources.ApplyResources(this.radLabel2, "radLabel2");
      this.radLabel2.Name = "radLabel2";
      // 
      // AbstractError
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      resources.ApplyResources(this, "$this");
      this.Controls.Add(this.radLabel2);
      this.Controls.Add(this.radLabel1);
      this.Controls.Add(this.lbl_funnyHeader);
      this.DisplayAbort = true;
      this.Name = "AbstractError";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.Controls.SetChildIndex(this.radPanel1, 0);
      this.Controls.SetChildIndex(this.lbl_funnyHeader, 0);
      this.Controls.SetChildIndex(this.radLabel1, 0);
      this.Controls.SetChildIndex(this.radLabel2, 0);
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
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