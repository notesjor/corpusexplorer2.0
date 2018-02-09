namespace CorpusExplorer.Terminal.WinForm.Forms.Snapshot
{
  partial class SetTheorySelectSnapshot
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
      this.radDropDownList1 = new Telerik.WinControls.UI.RadDropDownList();
      this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
      this.header1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.Header();
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radDropDownList1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // radPanel1
      // 
      this.radPanel1.Location = new System.Drawing.Point(0, 138);
      this.radPanel1.Size = new System.Drawing.Size(472, 38);
      // 
      // radDropDownList1
      // 
      this.radDropDownList1.Dock = System.Windows.Forms.DockStyle.Top;
      this.radDropDownList1.Location = new System.Drawing.Point(0, 95);
      this.radDropDownList1.Name = "radDropDownList1";
      this.radDropDownList1.NullText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.BitteAuswählen;
      this.radDropDownList1.Size = new System.Drawing.Size(472, 32);
      this.radDropDownList1.TabIndex = 6;
      // 
      // radLabel1
      // 
      this.radLabel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.radLabel1.Location = new System.Drawing.Point(0, 72);
      this.radLabel1.Name = "radLabel1";
      this.radLabel1.Size = new System.Drawing.Size(198, 23);
      this.radLabel1.TabIndex = 5;
      this.radLabel1.Text = "Verfügbare Schnappschüsse:";
      // 
      // header1
      // 
      this.header1.BackColor = System.Drawing.Color.White;
      this.header1.Dock = System.Windows.Forms.DockStyle.Top;
      this.header1.Font = new System.Drawing.Font("Segoe UI", 11F);
      this.header1.HeaderDescribtion = "{DESCRIBTION}";
      this.header1.HeaderHead = "Schnappschuss - Mengenoperation";
      this.header1.Location = new System.Drawing.Point(0, 0);
      this.header1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.header1.Name = "header1";
      this.header1.Size = new System.Drawing.Size(472, 72);
      this.header1.TabIndex = 4;
      // 
      // SetTheorySelectSnapshot
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(472, 176);
      this.Controls.Add(this.radDropDownList1);
      this.Controls.Add(this.radLabel1);
      this.Controls.Add(this.header1);
      this.DisplayAbort = true;
      this.Name = "SetTheorySelectSnapshot";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.Text = "Schnappshuss auswählen...";
      this.ButtonOkClick += new System.EventHandler(this.SetTheorySelectSnapshot_ButtonOkClick);
      this.Controls.SetChildIndex(this.radPanel1, 0);
      this.Controls.SetChildIndex(this.header1, 0);
      this.Controls.SetChildIndex(this.radLabel1, 0);
      this.Controls.SetChildIndex(this.radDropDownList1, 0);
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radDropDownList1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Telerik.WinControls.UI.RadDropDownList radDropDownList1;
    private Telerik.WinControls.UI.RadLabel radLabel1;
    private Controls.WinForm.Header header1;
  }
}