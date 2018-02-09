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
      this.radLabel1.AutoSize = false;
      this.radLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radLabel1.Location = new System.Drawing.Point(0, 0);
      this.radLabel1.Name = "radLabel1";
      this.radLabel1.Padding = new System.Windows.Forms.Padding(10);
      this.radLabel1.Size = new System.Drawing.Size(540, 132);
      this.radLabel1.TabIndex = 0;
      this.radLabel1.Text = resources.GetString("radLabel1.Text");
      this.radLabel1.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
      this.radLabel1.TextWrap = false;
      // 
      // clearPanel1
      // 
      this.clearPanel1.Controls.Add(this.btn_accepted);
      this.clearPanel1.Controls.Add(this.btn_denied);
      this.clearPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.clearPanel1.Location = new System.Drawing.Point(0, 132);
      this.clearPanel1.Name = "clearPanel1";
      this.clearPanel1.Size = new System.Drawing.Size(540, 32);
      this.clearPanel1.TabIndex = 1;
      // 
      // btn_accepted
      // 
      this.btn_accepted.Dock = System.Windows.Forms.DockStyle.Right;
      this.btn_accepted.Location = new System.Drawing.Point(430, 0);
      this.btn_accepted.Name = "btn_accepted";
      this.btn_accepted.Size = new System.Drawing.Size(110, 32);
      this.btn_accepted.TabIndex = 0;
      this.btn_accepted.Text = "Zulassen";
      this.btn_accepted.Click += new System.EventHandler(this.btn_accepted_Click);
      ((Telerik.WinControls.UI.RadButtonElement)(this.btn_accepted.GetChildAt(0))).Text = "Zulassen";
      ((Telerik.WinControls.UI.RadButtonElement)(this.btn_accepted.GetChildAt(0))).FocusBorderColor = System.Drawing.Color.DarkGreen;
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.btn_accepted.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.btn_accepted.GetChildAt(0).GetChildAt(1).GetChildAt(1))).ForeColor = System.Drawing.Color.DarkGreen;
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.btn_accepted.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
      ((Telerik.WinControls.Primitives.BorderPrimitive)(this.btn_accepted.GetChildAt(0).GetChildAt(2))).ForeColor = System.Drawing.Color.DarkGreen;
      ((Telerik.WinControls.Primitives.BorderPrimitive)(this.btn_accepted.GetChildAt(0).GetChildAt(2))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
      // 
      // btn_denied
      // 
      this.btn_denied.Dock = System.Windows.Forms.DockStyle.Left;
      this.btn_denied.Location = new System.Drawing.Point(0, 0);
      this.btn_denied.Name = "btn_denied";
      this.btn_denied.Size = new System.Drawing.Size(110, 32);
      this.btn_denied.TabIndex = 1;
      this.btn_denied.Text = "Ablehnen";
      this.btn_denied.Click += new System.EventHandler(this.btn_denied_Click);
      ((Telerik.WinControls.UI.RadButtonElement)(this.btn_denied.GetChildAt(0))).Text = "Ablehnen";
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.btn_denied.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.btn_denied.GetChildAt(0).GetChildAt(1).GetChildAt(1))).ForeColor = System.Drawing.Color.Firebrick;
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.btn_denied.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // ApplicationInsight
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(540, 164);
      this.Controls.Add(this.radLabel1);
      this.Controls.Add(this.clearPanel1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "ApplicationInsight";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.ShowIcon = false;
      this.Text = "CorpusExplorer - Telemetrie";
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