namespace CorpusExplorer.Tool4.DocPlusEditor.Forms
{
  partial class Lizenz
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Lizenz));
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.radButton1 = new Telerik.WinControls.UI.RadButton();
      this.radButton2 = new Telerik.WinControls.UI.RadButton();
      ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radButton2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(17, 16);
      this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.textBox1.Multiline = true;
      this.textBox1.Name = "textBox1";
      this.textBox1.ReadOnly = true;
      this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.textBox1.Size = new System.Drawing.Size(625, 234);
      this.textBox1.TabIndex = 5;
      this.textBox1.Text = resources.GetString("textBox1.Text");
      // 
      // radButton1
      // 
      this.radButton1.DialogResult = System.Windows.Forms.DialogResult.Yes;
      this.radButton1.Location = new System.Drawing.Point(17, 260);
      this.radButton1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.radButton1.Name = "radButton1";
      this.radButton1.Size = new System.Drawing.Size(147, 46);
      this.radButton1.TabIndex = 1;
      this.radButton1.Text = "Annehmen";
      this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
      // 
      // radButton2
      // 
      this.radButton2.DialogResult = System.Windows.Forms.DialogResult.No;
      this.radButton2.Location = new System.Drawing.Point(497, 258);
      this.radButton2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.radButton2.Name = "radButton2";
      this.radButton2.Size = new System.Drawing.Size(147, 46);
      this.radButton2.TabIndex = 2;
      this.radButton2.Text = "Ablehnen";
      this.radButton2.Click += new System.EventHandler(this.radButton2_Click);
      // 
      // Lizenz
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.ClientSize = new System.Drawing.Size(665, 310);
      this.Controls.Add(this.radButton2);
      this.Controls.Add(this.radButton1);
      this.Controls.Add(this.textBox1);
      this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.Name = "Lizenz";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.Text = "DPXC - Lizenz";
      ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radButton2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox textBox1;
    private Telerik.WinControls.UI.RadButton radButton1;
    private Telerik.WinControls.UI.RadButton radButton2;
  }
}