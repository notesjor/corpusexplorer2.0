namespace CorpusExplorer.Terminal.WinForm.Forms.Simple
{
  partial class SimpleObject
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimpleObject));
      this.metadataEditor1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.MetadataEditor();
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // metadataEditor1
      // 
      this.metadataEditor1.BackColor = System.Drawing.Color.White;
      resources.ApplyResources(this.metadataEditor1, "metadataEditor1");
      this.metadataEditor1.Metadata = null;
      this.metadataEditor1.Name = "metadataEditor1";
      this.metadataEditor1.ShowControlBar = false;
      // 
      // SimpleObject
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      resources.ApplyResources(this, "$this");
      this.Controls.Add(this.metadataEditor1);
      this.DisplayAbort = true;
      this.Name = "SimpleObject";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.Controls.SetChildIndex(this.radPanel1, 0);
      this.Controls.SetChildIndex(this.metadataEditor1, 0);
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private Controls.WinForm.MetadataEditor metadataEditor1;
  }
}