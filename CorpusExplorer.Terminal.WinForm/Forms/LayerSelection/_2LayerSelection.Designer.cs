using CorpusExplorer.Terminal.WinForm.Properties;
namespace CorpusExplorer.Terminal.WinForm.Forms.LayerSelection
{
  partial class _2LayerSelection
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
      this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
      this.txt_layer2 = new Telerik.WinControls.UI.RadTextBox();
      this.combo_layer2 = new Telerik.WinControls.UI.RadDropDownList();
      this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
      this.txt_layer1 = new Telerik.WinControls.UI.RadTextBox();
      this.combo_layer1 = new Telerik.WinControls.UI.RadDropDownList();
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
      this.radGroupBox2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.txt_layer2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.combo_layer2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
      this.radGroupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.txt_layer1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.combo_layer1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // radPanel1
      // 
      this.radPanel1.Location = new System.Drawing.Point(0, 263);
      // 
      // radGroupBox2
      // 
      this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox2.Controls.Add(this.txt_layer2);
      this.radGroupBox2.Controls.Add(this.combo_layer2);
      this.radGroupBox2.Dock = System.Windows.Forms.DockStyle.Top;
      this.radGroupBox2.HeaderText = Resources._2Layer;
      this.radGroupBox2.Location = new System.Drawing.Point(0, 163);
      this.radGroupBox2.Name = "radGroupBox2";
      this.radGroupBox2.Padding = new System.Windows.Forms.Padding(5, 25, 5, 5);
      this.radGroupBox2.Size = new System.Drawing.Size(397, 94);
      this.radGroupBox2.TabIndex = 5;
      this.radGroupBox2.Text = Resources._2Layer;
      // 
      // txt_layer2
      // 
      this.txt_layer2.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.txt_layer2.Location = new System.Drawing.Point(5, 59);
      this.txt_layer2.Name = "txt_layer2";
      this.txt_layer2.NullText = Resources.AlternativeLayerbezeichnungHierEingeben;
      this.txt_layer2.Size = new System.Drawing.Size(387, 30);
      this.txt_layer2.TabIndex = 1;
      // 
      // combo_layer2
      // 
      this.combo_layer2.Dock = System.Windows.Forms.DockStyle.Top;
      this.combo_layer2.Location = new System.Drawing.Point(5, 25);
      this.combo_layer2.Name = "combo_layer2";
      this.combo_layer2.Size = new System.Drawing.Size(387, 30);
      this.combo_layer2.TabIndex = 0;
      // 
      // radGroupBox1
      // 
      this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox1.Controls.Add(this.txt_layer1);
      this.radGroupBox1.Controls.Add(this.combo_layer1);
      this.radGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
      this.radGroupBox1.HeaderText = Resources._1Layer;
      this.radGroupBox1.Location = new System.Drawing.Point(0, 69);
      this.radGroupBox1.Name = "radGroupBox1";
      this.radGroupBox1.Padding = new System.Windows.Forms.Padding(5, 25, 5, 5);
      this.radGroupBox1.Size = new System.Drawing.Size(397, 94);
      this.radGroupBox1.TabIndex = 4;
      this.radGroupBox1.Text = Resources._1Layer;
      // 
      // txt_layer1
      // 
      this.txt_layer1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.txt_layer1.Location = new System.Drawing.Point(5, 59);
      this.txt_layer1.Name = "txt_layer1";
      this.txt_layer1.NullText = Resources.AlternativeLayerbezeichnungHierEingeben;
      this.txt_layer1.Size = new System.Drawing.Size(387, 30);
      this.txt_layer1.TabIndex = 1;
      // 
      // combo_layer1
      // 
      this.combo_layer1.Dock = System.Windows.Forms.DockStyle.Top;
      this.combo_layer1.Location = new System.Drawing.Point(5, 25);
      this.combo_layer1.Name = "combo_layer1";
      this.combo_layer1.Size = new System.Drawing.Size(387, 30);
      this.combo_layer1.TabIndex = 0;
      // 
      // _2LayerSelection
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(397, 301);
      this.Controls.Add(this.radGroupBox2);
      this.Controls.Add(this.radGroupBox1);
      this.DisplayAbort = true;
      this.Name = "_2LayerSelection";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.Text = Resources.LayerAuswählen;
      this.ButtonOkClick += new System.EventHandler(this._2LayerSelection_ButtonOkClick);
      this.Controls.SetChildIndex(this.radPanel1, 0);
      this.Controls.SetChildIndex(this.radGroupBox1, 0);
      this.Controls.SetChildIndex(this.radGroupBox2, 0);
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
      this.radGroupBox2.ResumeLayout(false);
      this.radGroupBox2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.txt_layer2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.combo_layer2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
      this.radGroupBox1.ResumeLayout(false);
      this.radGroupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.txt_layer1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.combo_layer1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
    private Telerik.WinControls.UI.RadTextBox txt_layer2;
    private Telerik.WinControls.UI.RadDropDownList combo_layer2;
    private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
    private Telerik.WinControls.UI.RadTextBox txt_layer1;
    private Telerik.WinControls.UI.RadDropDownList combo_layer1;

  }
}