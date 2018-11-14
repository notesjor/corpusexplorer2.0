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
      this.ihdPanel1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.IHDPanel();
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
      this.radPanel1.Location = new System.Drawing.Point(0, 246);
      this.radPanel1.Size = new System.Drawing.Size(530, 38);
      // 
      // ihdPanel1
      // 
      this.ihdPanel1.BackColor = System.Drawing.Color.White;
      this.ihdPanel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.ihdPanel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ihdPanel1.IHDDeescribtion = "Schließt identische Dokumente aus einem Schnappschuss aus.";
      this.ihdPanel1.IHDHeader = "Clone-Detection";
      this.ihdPanel1.IHDImage = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.module_warn1;
      this.ihdPanel1.Location = new System.Drawing.Point(0, 0);
      this.ihdPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.ihdPanel1.Name = "ihdPanel1";
      this.ihdPanel1.Size = new System.Drawing.Size(530, 64);
      this.ihdPanel1.TabIndex = 1;
      // 
      // radRadioButton1
      // 
      this.radRadioButton1.Location = new System.Drawing.Point(12, 72);
      this.radRadioButton1.Name = "radRadioButton1";
      this.radRadioButton1.Size = new System.Drawing.Size(413, 49);
      this.radRadioButton1.TabIndex = 2;
      this.radRadioButton1.TabStop = false;
      this.radRadioButton1.Text = "<html><strong>Schneller Hashvergleich</strong> (Qualität: ● / Performance: ●●●)<b" +
    "r />Nutzt SHA512 - Beseitigt nur 100%ige Kopien.</html>";
      // 
      // radRadioButton2
      // 
      this.radRadioButton2.Location = new System.Drawing.Point(12, 182);
      this.radRadioButton2.Name = "radRadioButton2";
      this.radRadioButton2.Size = new System.Drawing.Size(505, 49);
      this.radRadioButton2.TabIndex = 3;
      this.radRadioButton2.TabStop = false;
      this.radRadioButton2.Text = "<html><strong>Fluss-/Vektorenanalyse </strong> (Qualität: ●●● / Performance: ●)<b" +
    "r />Beseitigt Dokumente, die sich in unwesentlichen Punkten unterscheiden.</html" +
    ">";
      // 
      // radRadioButton3
      // 
      this.radRadioButton3.CheckState = System.Windows.Forms.CheckState.Checked;
      this.radRadioButton3.Location = new System.Drawing.Point(12, 127);
      this.radRadioButton3.Name = "radRadioButton3";
      this.radRadioButton3.Size = new System.Drawing.Size(387, 49);
      this.radRadioButton3.TabIndex = 3;
      this.radRadioButton3.Text = "<html><strong>Fuzzy-Hash-Analyse</strong> (Qualität: ●● / Performance: ●●)<br />B" +
    "asiert auf context triggered piecewise hashes (CTPH).</html>";
      this.radRadioButton3.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
      // 
      // CloneDetectionAlgorithm
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.ClientSize = new System.Drawing.Size(530, 284);
      this.Controls.Add(this.radRadioButton3);
      this.Controls.Add(this.radRadioButton2);
      this.Controls.Add(this.radRadioButton1);
      this.Controls.Add(this.ihdPanel1);
      this.DisplayAbort = true;
      this.Name = "CloneDetectionAlgorithm";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.Text = "Clone-Detection";
      this.Controls.SetChildIndex(this.radPanel1, 0);
      this.Controls.SetChildIndex(this.ihdPanel1, 0);
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

    private Controls.WinForm.IHDPanel ihdPanel1;
    private Telerik.WinControls.UI.RadRadioButton radRadioButton1;
    private Telerik.WinControls.UI.RadRadioButton radRadioButton2;
    private Telerik.WinControls.UI.RadRadioButton radRadioButton3;
  }
}