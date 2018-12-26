using CorpusExplorer.Terminal.WinForm.Properties;
using CorpusExplorer.Terminal.WinForm.Controls.WinForm;

namespace CorpusExplorer.Terminal.WinForm.Forms.Snapshot
{
  partial class AddRandomSnapshot
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddRandomSnapshot));
      this.header1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.Header();
      this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
      this.count_docs = new Telerik.WinControls.UI.RadSpinEditor();
      this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
      this.count_percent = new Telerik.WinControls.UI.RadSpinEditor();
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.count_docs)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.count_percent)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // radPanel1
      // 
      resources.ApplyResources(this.radPanel1, "radPanel1");
      // 
      // header1
      // 
      this.header1.BackColor = System.Drawing.Color.White;
      resources.ApplyResources(this.header1, "header1");
      this.header1.HeaderDescription = resources.GetString("header1.HeaderDescription");
      this.header1.HeaderHead = "Zufallsgenerator";
      this.header1.Name = "header1";
      // 
      // radLabel1
      // 
      resources.ApplyResources(this.radLabel1, "radLabel1");
      this.radLabel1.Name = "radLabel1";
      // 
      // count_docs
      // 
      resources.ApplyResources(this.count_docs, "count_docs");
      this.count_docs.Name = "count_docs";
      // 
      // 
      // 
      this.count_docs.RootElement.MinSize = new System.Drawing.Size(100, 0);
      this.count_docs.TabStop = false;
      this.count_docs.ValueChanged += new System.EventHandler(this.count_docs_ValueChanged);
      // 
      // radLabel2
      // 
      resources.ApplyResources(this.radLabel2, "radLabel2");
      this.radLabel2.Name = "radLabel2";
      // 
      // count_percent
      // 
      resources.ApplyResources(this.count_percent, "count_percent");
      this.count_percent.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
      this.count_percent.Name = "count_percent";
      // 
      // 
      // 
      this.count_percent.RootElement.MinSize = new System.Drawing.Size(100, 0);
      this.count_percent.TabStop = false;
      this.count_percent.ValueChanged += new System.EventHandler(this.count_percent_ValueChanged);
      // 
      // AddRandomSnapshot
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      resources.ApplyResources(this, "$this");
      this.Controls.Add(this.count_percent);
      this.Controls.Add(this.radLabel2);
      this.Controls.Add(this.count_docs);
      this.Controls.Add(this.radLabel1);
      this.Controls.Add(this.header1);
      this.DisplayAbort = true;
      this.Name = "AddRandomSnapshot";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.ButtonOkClick += new System.EventHandler(this.AddRandomSnapshot_ButtonOkClick);
      this.Controls.SetChildIndex(this.radPanel1, 0);
      this.Controls.SetChildIndex(this.header1, 0);
      this.Controls.SetChildIndex(this.radLabel1, 0);
      this.Controls.SetChildIndex(this.count_docs, 0);
      this.Controls.SetChildIndex(this.radLabel2, 0);
      this.Controls.SetChildIndex(this.count_percent, 0);
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.count_docs)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.count_percent)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Header header1;
    private Telerik.WinControls.UI.RadLabel radLabel1;
    private Telerik.WinControls.UI.RadSpinEditor count_docs;
    private Telerik.WinControls.UI.RadLabel radLabel2;
    private Telerik.WinControls.UI.RadSpinEditor count_percent;
  }
}