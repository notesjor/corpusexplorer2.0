namespace CorpusExplorer.Terminal.WinForm.Forms.PosFilter
{
  partial class PosFilter
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
      this.radCheckedListBox1 = new Telerik.WinControls.UI.RadCheckedListBox();
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radCheckedListBox1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // radPanel1
      // 
      this.radPanel1.Location = new System.Drawing.Point(0, 447);
      this.radPanel1.Size = new System.Drawing.Size(456, 38);
      // 
      // ihdPanel1
      // 
      this.ihdPanel1.BackColor = System.Drawing.Color.White;
      this.ihdPanel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.ihdPanel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ihdPanel1.IHDDeescribtion = "Wählen Sie die gewünschten POS-Tags aus...";
      this.ihdPanel1.IHDHeader = "POS-Filter";
      this.ihdPanel1.IHDImage = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.tag_green1;
      this.ihdPanel1.Location = new System.Drawing.Point(0, 0);
      this.ihdPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.ihdPanel1.Name = "ihdPanel1";
      this.ihdPanel1.Size = new System.Drawing.Size(456, 64);
      this.ihdPanel1.TabIndex = 1;
      // 
      // radCheckedListBox1
      // 
      this.radCheckedListBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radCheckedListBox1.GroupItemSize = new System.Drawing.Size(200, 40);
      this.radCheckedListBox1.ItemSize = new System.Drawing.Size(200, 40);
      this.radCheckedListBox1.Location = new System.Drawing.Point(0, 64);
      this.radCheckedListBox1.Name = "radCheckedListBox1";
      this.radCheckedListBox1.Size = new System.Drawing.Size(456, 383);
      this.radCheckedListBox1.TabIndex = 2;
      this.radCheckedListBox1.Text = "radCheckedListBox1";
      // 
      // PosFilter
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.ClientSize = new System.Drawing.Size(456, 485);
      this.Controls.Add(this.radCheckedListBox1);
      this.Controls.Add(this.ihdPanel1);
      this.DisplayAbort = true;
      this.Name = "PosFilter";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.Text = "POS-Filter";
      this.Controls.SetChildIndex(this.radPanel1, 0);
      this.Controls.SetChildIndex(this.ihdPanel1, 0);
      this.Controls.SetChildIndex(this.radCheckedListBox1, 0);
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radCheckedListBox1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private Controls.WinForm.IHDPanel ihdPanel1;
    private Telerik.WinControls.UI.RadCheckedListBox radCheckedListBox1;
  }
}