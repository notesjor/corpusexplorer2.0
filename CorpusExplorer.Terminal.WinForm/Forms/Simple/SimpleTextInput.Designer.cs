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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimpleTextInput));
      this._headPanel1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.HeadPanel();
      this.radTextBox1 = new Telerik.WinControls.UI.RadTextBox();
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).BeginInit();
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
      this._headPanel1.HeadPanelDescription = "{IHDDESCRIPTION}";
      this._headPanel1.HeadPanelTitle = "{IHDHEADER}";
      this._headPanel1.HeadPanelImage = null;
      this._headPanel1.Name = "_headPanel1";
      // 
      // radTextBox1
      // 
      resources.ApplyResources(this.radTextBox1, "radTextBox1");
      this.radTextBox1.Name = "radTextBox1";
      // 
      // SimpleTextInput
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      resources.ApplyResources(this, "$this");
      this.Controls.Add(this.radTextBox1);
      this.Controls.Add(this._headPanel1);
      this.DisplayAbort = true;
      this.Name = "SimpleTextInput";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.Controls.SetChildIndex(this.radPanel1, 0);
      this.Controls.SetChildIndex(this._headPanel1, 0);
      this.Controls.SetChildIndex(this.radTextBox1, 0);
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private HeadPanel _headPanel1;
        protected Telerik.WinControls.UI.RadTextBox radTextBox1;
    }
}