namespace CorpusExplorer.Terminal.WinForm.Forms.SelectLayer
{
  partial class Select2Layer
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
      this.layerSettings1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.LayerSettings();
      this.layerSettings2 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.LayerSettings();
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // radPanel1
      // 
      this.radPanel1.Location = new System.Drawing.Point(0, 184);
      // 
      // layerSettings1
      // 
      this.layerSettings1.BackColor = System.Drawing.Color.White;
      this.layerSettings1.Dock = System.Windows.Forms.DockStyle.Top;
      this.layerSettings1.Font = new System.Drawing.Font("Segoe UI", 11F);
      this.layerSettings1.Header = "Layer 1";
      this.layerSettings1.IsLayerOptional = false;
      this.layerSettings1.Location = new System.Drawing.Point(0, 53);
      this.layerSettings1.Name = "layerSettings1";
      this.layerSettings1.Size = new System.Drawing.Size(397, 62);
      this.layerSettings1.TabIndex = 2;
      // 
      // layerSettings2
      // 
      this.layerSettings2.BackColor = System.Drawing.Color.White;
      this.layerSettings2.Dock = System.Windows.Forms.DockStyle.Top;
      this.layerSettings2.Font = new System.Drawing.Font("Segoe UI", 11F);
      this.layerSettings2.Header = "Layer 2";
      this.layerSettings2.IsLayerOptional = true;
      this.layerSettings2.Location = new System.Drawing.Point(0, 115);
      this.layerSettings2.Name = "layerSettings2";
      this.layerSettings2.Size = new System.Drawing.Size(397, 62);
      this.layerSettings2.TabIndex = 3;
      // 
      // Select2Layer
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(397, 222);
      this.Controls.Add(this.layerSettings2);
      this.Controls.Add(this.layerSettings1);
      this.DisplayAbort = true;
      this.Name = "Select2Layer";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.ButtonOkClick += new System.EventHandler(this.Form_ButtonOkClick);
      this.Controls.SetChildIndex(this.radPanel1, 0);
      this.Controls.SetChildIndex(this.layerSettings1, 0);
      this.Controls.SetChildIndex(this.layerSettings2, 0);
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private Controls.WinForm.LayerSettings layerSettings1;
    private Controls.WinForm.LayerSettings layerSettings2;
  }
}