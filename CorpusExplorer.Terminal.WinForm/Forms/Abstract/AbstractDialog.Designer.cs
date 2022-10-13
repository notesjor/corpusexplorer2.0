using CorpusExplorer.Terminal.WinForm.Properties;
namespace CorpusExplorer.Terminal.WinForm.Forms.Abstract
{
  partial class AbstractDialog
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AbstractDialog));
      this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
      this.btn_ok = new Telerik.WinControls.UI.RadButton();
      this.btn_abort = new Telerik.WinControls.UI.RadButton();
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
      this.radPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.btn_ok)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_abort)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // radPanel1
      // 
      this.radPanel1.Controls.Add(this.btn_ok);
      this.radPanel1.Controls.Add(this.btn_abort);
      resources.ApplyResources(this.radPanel1, "radPanel1");
      this.radPanel1.Name = "radPanel1";
      // 
      // btn_ok
      // 
      resources.ApplyResources(this.btn_ok, "btn_ok");
      this.btn_ok.Name = "btn_ok";
      this.btn_ok.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.OK;
      this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
      ((Telerik.WinControls.UI.RadButtonElement)(this.btn_ok.GetChildAt(0))).Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.OK;
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.btn_ok.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.btn_ok.GetChildAt(0).GetChildAt(1).GetChildAt(1))).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(129)))), ((int)(((byte)(68)))));
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.btn_ok.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = ((System.Drawing.ContentAlignment)(resources.GetObject("resource.Alignment")));
      // 
      // btn_abort
      // 
      resources.ApplyResources(this.btn_abort, "btn_abort");
      this.btn_abort.Name = "btn_abort";
      this.btn_abort.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Abbrechen;
      this.btn_abort.Click += new System.EventHandler(this.btn_abort_Click);
      ((Telerik.WinControls.UI.RadButtonElement)(this.btn_abort.GetChildAt(0))).Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Abbrechen;
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.btn_abort.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.btn_abort.GetChildAt(0).GetChildAt(1).GetChildAt(1))).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(0)))), ((int)(((byte)(38)))));
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.btn_abort.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = ((System.Drawing.ContentAlignment)(resources.GetObject("resource.Alignment1")));
      // 
      // AbstractDialog
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      resources.ApplyResources(this, "$this");
      this.Controls.Add(this.radPanel1);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "AbstractDialog";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.ShowInTaskbar = false;
      this.TopMost = true;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
      this.radPanel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.btn_ok)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_abort)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private Telerik.WinControls.UI.RadButton btn_ok;
    private Telerik.WinControls.UI.RadButton btn_abort;
    protected Telerik.WinControls.UI.RadPanel radPanel1;
  }
}