using CorpusExplorer.Terminal.WinForm.Properties;
using CorpusExplorer.Terminal.WinForm.Controls.WinForm;

namespace CorpusExplorer.Terminal.WinForm.Forms.LayerSelection.Abstract
{
  partial class AbstractLayerSelection
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
      this.header1 = new Header();
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // radPanel1
      // 
      this.radPanel1.Location = new System.Drawing.Point(0, 87);
      this.radPanel1.Size = new System.Drawing.Size(397, 38);
      // 
      // header1
      // 
      this.header1.BackColor = System.Drawing.Color.White;
      this.header1.Dock = System.Windows.Forms.DockStyle.Top;
      this.header1.Font = new System.Drawing.Font("Segoe UI", 11F);
      this.header1.HeaderDescribtion = Resources.WählenSieAusAufWelchenEbenenDieAnalyseErfolgenSollUndWieDieErgebnisseInDerTabelleDargestelltWerden;
      this.header1.HeaderHead = Resources.LayerAuswählenUndBenennen;
      this.header1.Location = new System.Drawing.Point(0, 0);
      this.header1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.header1.Name = "header1";
      this.header1.Size = new System.Drawing.Size(397, 69);
      this.header1.TabIndex = 1;
      // 
      // AbstractLayerSelection
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(397, 125);
      this.Controls.Add(this.header1);
      this.DisplayAbort = true;
      this.Name = "AbstractLayerSelection";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.Text = "AbstractLayerSelection";
      this.Controls.SetChildIndex(this.radPanel1, 0);
      this.Controls.SetChildIndex(this.header1, 0);
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private Header header1;
  }
}