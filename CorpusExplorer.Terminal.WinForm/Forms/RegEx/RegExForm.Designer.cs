namespace CorpusExplorer.Terminal.WinForm.Forms.RegEx
{
  partial class RegExForm
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
      this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
      this.txt_regex = new Telerik.WinControls.UI.RadTextBox();
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
      this.radGroupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.txt_regex)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // header1
      // 
      this.header1.HeaderDescribtion = "Wählen Sie aus, auf welche Spalte der Reguläre Ausdruck angewendet werden soll.";
      this.header1.HeaderHead = "Spalte auswählen";
      this.header1.Size = new System.Drawing.Size(397, 74);
      // 
      // radPanel1
      // 
      this.radPanel1.Location = new System.Drawing.Point(0, 262);
      // 
      // layerSettings1
      // 
      this.layerSettings1.BackColor = System.Drawing.Color.White;
      this.layerSettings1.Dock = System.Windows.Forms.DockStyle.Top;
      this.layerSettings1.Font = new System.Drawing.Font("Segoe UI", 11F);
      this.layerSettings1.Header = "Spalte";
      this.layerSettings1.IsLayerOptional = false;
      this.layerSettings1.Location = new System.Drawing.Point(0, 74);
      this.layerSettings1.Name = "layerSettings1";
      this.layerSettings1.Size = new System.Drawing.Size(397, 62);
      this.layerSettings1.TabIndex = 2;
      // 
      // radGroupBox1
      // 
      this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox1.Controls.Add(this.txt_regex);
      this.radGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radGroupBox1.HeaderText = "Regulärer Ausdruck";
      this.radGroupBox1.Location = new System.Drawing.Point(0, 136);
      this.radGroupBox1.Name = "radGroupBox1";
      this.radGroupBox1.Padding = new System.Windows.Forms.Padding(5, 25, 5, 5);
      this.radGroupBox1.Size = new System.Drawing.Size(397, 126);
      this.radGroupBox1.TabIndex = 3;
      this.radGroupBox1.Text = "Regulärer Ausdruck";
      // 
      // txt_regex
      // 
      this.txt_regex.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txt_regex.Location = new System.Drawing.Point(5, 25);
      this.txt_regex.Multiline = true;
      this.txt_regex.Name = "txt_regex";
      // 
      // 
      // 
      this.txt_regex.RootElement.StretchVertically = true;
      this.txt_regex.Size = new System.Drawing.Size(387, 96);
      this.txt_regex.TabIndex = 0;
      // 
      // RegExForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.ClientSize = new System.Drawing.Size(397, 300);
      this.Controls.Add(this.radGroupBox1);
      this.Controls.Add(this.layerSettings1);
      this.DisplayAbort = true;
      this.Name = "RegExForm";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.Text = "Regular Expression definieren";
      this.ButtonOkClick += new System.EventHandler(this.Form_ButtonOkClick);
      this.Controls.SetChildIndex(this.header1, 0);
      this.Controls.SetChildIndex(this.radPanel1, 0);
      this.Controls.SetChildIndex(this.layerSettings1, 0);
      this.Controls.SetChildIndex(this.radGroupBox1, 0);
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
      this.radGroupBox1.ResumeLayout(false);
      this.radGroupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.txt_regex)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private Controls.WinForm.LayerSettings layerSettings1;
    private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
    private Telerik.WinControls.UI.RadTextBox txt_regex;
  }
}