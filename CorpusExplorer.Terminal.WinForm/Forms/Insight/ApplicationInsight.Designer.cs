namespace CorpusExplorer.Terminal.WinForm.Forms.Insight
{
  partial class ApplicationInsight
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApplicationInsight));
      this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
      this.clearPanel1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.ClearPanel();
      this.btn_accepted = new Telerik.WinControls.UI.RadButton();
      this.btn_denied = new Telerik.WinControls.UI.RadButton();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel1)).BeginInit();
      this.clearPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.btn_accepted)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_denied)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // radLabel1
      // 
      resources.ApplyResources(this.radLabel1, "radLabel1");
      this.radLabel1.Name = "radLabel1";
      // 
      // clearPanel1
      // 
      this.clearPanel1.Controls.Add(this.btn_accepted);
      this.clearPanel1.Controls.Add(this.btn_denied);
      resources.ApplyResources(this.clearPanel1, "clearPanel1");
      this.clearPanel1.Name = "clearPanel1";
      // 
      // btn_accepted
      // 
      resources.ApplyResources(this.btn_accepted, "btn_accepted");
      this.btn_accepted.Name = "btn_accepted";
      this.btn_accepted.Click += new System.EventHandler(this.btn_accepted_Click);
      ((Telerik.WinControls.UI.RadButtonElement)(this.btn_accepted.GetChildAt(0))).Text = resources.GetString("resource.Text");
      ((Telerik.WinControls.UI.RadButtonElement)(this.btn_accepted.GetChildAt(0))).FocusBorderColor = System.Drawing.Color.DarkGreen;
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.btn_accepted.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.btn_accepted.GetChildAt(0).GetChildAt(1).GetChildAt(1))).ForeColor = System.Drawing.Color.DarkGreen;
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.btn_accepted.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = ((System.Drawing.ContentAlignment)(resources.GetObject("resource.Alignment")));
      ((Telerik.WinControls.Primitives.BorderPrimitive)(this.btn_accepted.GetChildAt(0).GetChildAt(2))).ForeColor = System.Drawing.Color.DarkGreen;
      ((Telerik.WinControls.Primitives.BorderPrimitive)(this.btn_accepted.GetChildAt(0).GetChildAt(2))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
      // 
      // btn_denied
      // 
      resources.ApplyResources(this.btn_denied, "btn_denied");
      this.btn_denied.Name = "btn_denied";
      this.btn_denied.Click += new System.EventHandler(this.btn_denied_Click);
      ((Telerik.WinControls.UI.RadButtonElement)(this.btn_denied.GetChildAt(0))).Text = resources.GetString("resource.Text1");
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.btn_denied.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.btn_denied.GetChildAt(0).GetChildAt(1).GetChildAt(1))).ForeColor = System.Drawing.Color.Firebrick;
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.btn_denied.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = ((System.Drawing.ContentAlignment)(resources.GetObject("resource.Alignment1")));
      // 
      // ApplicationInsight
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      resources.ApplyResources(this, "$this");
      this.Controls.Add(this.radLabel1);
      this.Controls.Add(this.clearPanel1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "ApplicationInsight";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.ShowIcon = false;
      this.TopMost = true;
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel1)).EndInit();
      this.clearPanel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.btn_accepted)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_denied)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private Telerik.WinControls.UI.RadLabel radLabel1;
    private Controls.WinForm.ClearPanel clearPanel1;
    private Telerik.WinControls.UI.RadButton btn_accepted;
    private Telerik.WinControls.UI.RadButton btn_denied;
  }
}