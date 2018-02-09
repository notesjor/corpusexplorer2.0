using CorpusExplorer.Terminal.WinForm.Properties;
using CorpusExplorer.Terminal.WinForm.Controls.WinForm;

namespace CorpusExplorer.Terminal.WinForm.Forms.GridViewFunctions
{
  partial class PredefinedFunctions
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
      this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
      this.drop_funcs = new Telerik.WinControls.UI.RadDropDownList();
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
      this.radGroupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.drop_funcs)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // radPanel1
      // 
      this.radPanel1.Location = new System.Drawing.Point(0, 142);
      this.radPanel1.Size = new System.Drawing.Size(387, 38);
      // 
      // header1
      // 
      this.header1.BackColor = System.Drawing.Color.White;
      this.header1.Dock = System.Windows.Forms.DockStyle.Top;
      this.header1.Font = new System.Drawing.Font("Segoe UI", 11F);
      this.header1.HeaderDescribtion = Resources.MitDiesenFunktionenKönnenSieSchnellUndEinfachStandardisierteAuswertungenDurchführen;
      this.header1.HeaderHead = Resources.VordefinierteFunktionen;
      this.header1.Location = new System.Drawing.Point(0, 0);
      this.header1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.header1.Name = "header1";
      this.header1.Size = new System.Drawing.Size(387, 69);
      this.header1.TabIndex = 1;
      // 
      // radGroupBox1
      // 
      this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox1.Controls.Add(this.drop_funcs);
      this.radGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
      this.radGroupBox1.HeaderText = Resources.WasMöchtenSieAutomatisieren;
      this.radGroupBox1.Location = new System.Drawing.Point(0, 69);
      this.radGroupBox1.Name = "radGroupBox1";
      this.radGroupBox1.Padding = new System.Windows.Forms.Padding(5, 25, 5, 5);
      this.radGroupBox1.Size = new System.Drawing.Size(387, 61);
      this.radGroupBox1.TabIndex = 2;
      this.radGroupBox1.Text = Resources.WasMöchtenSieAutomatisieren;
      // 
      // drop_funcs
      // 
      this.drop_funcs.Dock = System.Windows.Forms.DockStyle.Fill;
      this.drop_funcs.Location = new System.Drawing.Point(5, 25);
      this.drop_funcs.Name = "drop_funcs";
      this.drop_funcs.NullText = Resources.FunktionAuswählen;
      this.drop_funcs.Size = new System.Drawing.Size(377, 31);
      this.drop_funcs.TabIndex = 0;
      // 
      // PredefinedFunctions
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(387, 180);
      this.Controls.Add(this.radGroupBox1);
      this.Controls.Add(this.header1);
      this.DisplayAbort = true;
      this.Name = "PredefinedFunctions";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.Text = Resources.TabellenFunktionen;
      this.ButtonOkClick += new System.EventHandler(this.PredefinedFunctions_ButtonOkClick);
      this.Load += new System.EventHandler(this.PredefinedFunctions_Load);
      this.Controls.SetChildIndex(this.radPanel1, 0);
      this.Controls.SetChildIndex(this.header1, 0);
      this.Controls.SetChildIndex(this.radGroupBox1, 0);
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
      this.radGroupBox1.ResumeLayout(false);
      this.radGroupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.drop_funcs)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private Header header1;
    private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
    private Telerik.WinControls.UI.RadDropDownList drop_funcs;
  }
}