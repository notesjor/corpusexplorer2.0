namespace CorpusExplorer.Terminal.WinForm.Forms.Simple
{
  partial class SimpleMetadata
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
      this.metadataEditor1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.MetadataEditor();
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // metadataEditor1
      // 
      this.metadataEditor1.BackColor = System.Drawing.Color.White;
      this.metadataEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.metadataEditor1.Font = new System.Drawing.Font("Segoe UI", 11F);
      this.metadataEditor1.Location = new System.Drawing.Point(0, 0);
      this.metadataEditor1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.metadataEditor1.Name = "metadataEditor1";
      this.metadataEditor1.Size = new System.Drawing.Size(410, 343);
      this.metadataEditor1.TabIndex = 1;
      // 
      // SimpleMetadata
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.ClientSize = new System.Drawing.Size(410, 381);
      this.Controls.Add(this.metadataEditor1);
      this.DisplayAbort = true;
      this.Name = "SimpleMetadata";
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