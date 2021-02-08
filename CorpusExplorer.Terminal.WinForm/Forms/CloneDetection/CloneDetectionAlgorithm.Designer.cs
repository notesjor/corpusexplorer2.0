namespace CorpusExplorer.Terminal.WinForm.Forms.CloneDetection
{
  partial class CloneDetectionAlgorithm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CloneDetectionAlgorithm));
      this._headPanel1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.HeadPanel();
      this.radRadioButton1 = new Telerik.WinControls.UI.RadRadioButton();
      this.radRadioButton2 = new Telerik.WinControls.UI.RadRadioButton();
      this.radRadioButton3 = new Telerik.WinControls.UI.RadRadioButton();
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radRadioButton1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radRadioButton2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radRadioButton3)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // radPanel1
      // 
      resources.ApplyResources(this.radPanel1, "radPanel1");
      // 
      // _headPanel1
      // 
      this._headPanel1.BackColor = System.Drawing.Color.White;
      resources.ApplyResources(this._headPanel1, "_headPanel1");
      this._headPanel1.HeadPanelDescription = "Schließt identische Dokumente aus einem Schnappschuss aus.";
      this._headPanel1.HeadPanelTitle = "Clone-Detection";
      this._headPanel1.HeadPanelImage = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.module_warn1;
      this._headPanel1.Name = "_headPanel1";
      // 
      // radRadioButton1
      // 
      resources.ApplyResources(this.radRadioButton1, "radRadioButton1");
      this.radRadioButton1.Name = "radRadioButton1";
      this.radRadioButton1.TabStop = false;
      // 
      // radRadioButton2
      // 
      resources.ApplyResources(this.radRadioButton2, "radRadioButton2");
      this.radRadioButton2.Name = "radRadioButton2";
      this.radRadioButton2.TabStop = false;
      // 
      // radRadioButton3
      // 
      this.radRadioButton3.CheckState = System.Windows.Forms.CheckState.Checked;
      resources.ApplyResources(this.radRadioButton3, "radRadioButton3");
      this.radRadioButton3.Name = "radRadioButton3";
      this.radRadioButton3.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
      // 
      // CloneDetectionAlgorithm
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      resources.ApplyResources(this, "$this");
      this.Controls.Add(this.radRadioButton3);
      this.Controls.Add(this.radRadioButton2);
      this.Controls.Add(this.radRadioButton1);
      this.Controls.Add(this._headPanel1);
      this.DisplayAbort = true;
      this.Name = "CloneDetectionAlgorithm";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.Controls.SetChildIndex(this.radPanel1, 0);
      this.Controls.SetChildIndex(this._headPanel1, 0);
      this.Controls.SetChildIndex(this.radRadioButton1, 0);
      this.Controls.SetChildIndex(this.radRadioButton2, 0);
      this.Controls.SetChildIndex(this.radRadioButton3, 0);
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radRadioButton1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radRadioButton2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radRadioButton3)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Controls.WinForm.HeadPanel _headPanel1;
    private Telerik.WinControls.UI.RadRadioButton radRadioButton1;
    private Telerik.WinControls.UI.RadRadioButton radRadioButton2;
    private Telerik.WinControls.UI.RadRadioButton radRadioButton3;
  }
}