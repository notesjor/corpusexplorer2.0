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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcessingForm));
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
      resources.ApplyResources(this.radLabel1, "radLabel1");
      this.radLabel1.Name = "radLabel1";
      // 
      // radWaitingBar1
      // 
      resources.ApplyResources(this.radWaitingBar1, "radWaitingBar1");
      this.radWaitingBar1.Name = "radWaitingBar1";
      this.radWaitingBar1.WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.Dash;
      // 
      // radLabel2
      // 
      resources.ApplyResources(this.radLabel2, "radLabel2");
      this.radLabel2.Name = "radLabel2";
      // 
      // timer1
      // 
      this.timer1.Interval = 1000;
      this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
      // 
      // ProcessingForm
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      resources.ApplyResources(this, "$this");
      this.ControlBox = false;
      this.Controls.Add(this.radWaitingBar1);
      this.Controls.Add(this.radLabel2);
      this.Controls.Add(this.radLabel1);
      this.Name = "ProcessingForm";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
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