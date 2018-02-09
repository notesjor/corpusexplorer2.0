using CorpusExplorer.Terminal.WinForm.Properties;
namespace CorpusExplorer.Terminal.WinForm.Forms.Splash.Forms
{
  partial class ProcessingForm
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
      this.components = new System.ComponentModel.Container();
      this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
      this.radWaitingBar1 = new Telerik.WinControls.UI.RadWaitingBar();
      this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radWaitingBar1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // radLabel1
      // 
      this.radLabel1.AutoSize = false;
      this.radLabel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 10F);
      this.radLabel1.Location = new System.Drawing.Point(10, 61);
      this.radLabel1.Name = "radLabel1";
      this.radLabel1.Size = new System.Drawing.Size(221, 94);
      this.radLabel1.TabIndex = 0;
      this.radLabel1.Text = "Lehnen Sie sich zurück und enspannen Sie sich, während CorpusExplorer für Sie rec" +
    "hnet.";
      this.radLabel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // radWaitingBar1
      // 
      this.radWaitingBar1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radWaitingBar1.Location = new System.Drawing.Point(10, 33);
      this.radWaitingBar1.Name = "radWaitingBar1";
      this.radWaitingBar1.Size = new System.Drawing.Size(221, 28);
      this.radWaitingBar1.TabIndex = 1;
      this.radWaitingBar1.Text = "radWaitingBar1";
      this.radWaitingBar1.WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.Dash;
      // 
      // radLabel2
      // 
      this.radLabel2.AutoSize = false;
      this.radLabel2.Dock = System.Windows.Forms.DockStyle.Top;
      this.radLabel2.Location = new System.Drawing.Point(10, 10);
      this.radLabel2.Name = "radLabel2";
      this.radLabel2.Size = new System.Drawing.Size(221, 23);
      this.radLabel2.TabIndex = 2;
      this.radLabel2.Text = "Gut Ding will Weile haben...";
      this.radLabel2.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
      // 
      // timer1
      // 
      this.timer1.Interval = 1000;
      this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
      // 
      // ProcessingForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(241, 165);
      this.ControlBox = false;
      this.Controls.Add(this.radWaitingBar1);
      this.Controls.Add(this.radLabel2);
      this.Controls.Add(this.radLabel1);
      this.Name = "ProcessingForm";
      this.Padding = new System.Windows.Forms.Padding(10);
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.Text = "";
      this.TopMost = true;
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radWaitingBar1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private Telerik.WinControls.UI.RadLabel radLabel1;
    private Telerik.WinControls.UI.RadWaitingBar radWaitingBar1;
    private Telerik.WinControls.UI.RadLabel radLabel2;
    private System.Windows.Forms.Timer timer1;
  }
}