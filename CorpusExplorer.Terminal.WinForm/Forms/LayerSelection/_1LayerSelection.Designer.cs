using CorpusExplorer.Terminal.WinForm.Properties;
namespace CorpusExplorer.Terminal.WinForm.Forms.LayerSelection
{
  partial class _1LayerSelection
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
      this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
      this.txt_layer1 = new Telerik.WinControls.UI.RadTextBox();
      this.combo_layer1 = new Telerik.WinControls.UI.RadDropDownList();
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
      this.radGroupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.txt_layer1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.combo_layer1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // radPanel1
      // 
      this.radPanel1.Location = new System.Drawing.Point(0, 169);
      // 
      // radGroupBox1
      // 
      this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox1.Controls.Add(this.txt_layer1);
      this.radGroupBox1.Controls.Add(this.combo_layer1);
      this.radGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
      this.radGroupBox1.HeaderText = Resources.Layer;
      this.radGroupBox1.Location = new System.Drawing.Point(0, 69);
      this.radGroupBox1.Name = "radGroupBox1";
      this.radGroupBox1.Padding = new System.Windows.Forms.Padding(5, 25, 5, 5);
      this.radGroupBox1.Size = new System.Drawing.Size(397, 94);
      this.radGroupBox1.TabIndex = 4;
      this.radGroupBox1.Text = Resources.Layer;
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
      // _1LayerSelection
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(397, 207);
      this.Controls.Add(this.radGroupBox1);
      this.DisplayAbort = true;
      this.Name = "_1LayerSelection";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.Text = Resources.LayerAuswählen;
      this.ButtonOkClick += new System.EventHandler(this._1LayerSelection_ButtonOkClick);
      this.Controls.SetChildIndex(this.radPanel1, 0);
      this.Controls.SetChildIndex(this.radGroupBox1, 0);
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
      this.radGroupBox1.ResumeLayout(false);
      this.radGroupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.txt_layer1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.combo_layer1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
    private Telerik.WinControls.UI.RadTextBox txt_layer1;
    private Telerik.WinControls.UI.RadDropDownList combo_layer1;
  }
}