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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PredefinedFunctions));
      this.header1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.Header();
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
      resources.ApplyResources(this.radPanel1, "radPanel1");
      // 
      // header1
      // 
      this.header1.BackColor = System.Drawing.Color.White;
      resources.ApplyResources(this.header1, "header1");
      this.header1.HeaderDescription = "Mit diesen Funktionen können Sie schnell und einfach standardisierte Auswertungen" +
    " durchführen.";
      this.header1.HeaderHead = "Vordefinierte Funktionen";
      this.header1.Name = "header1";
      // 
      // radGroupBox1
      // 
      this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox1.Controls.Add(this.drop_funcs);
      resources.ApplyResources(this.radGroupBox1, "radGroupBox1");
      this.radGroupBox1.HeaderText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.WasMöchtenSieAutomatisieren;
      this.radGroupBox1.Name = "radGroupBox1";
      this.radGroupBox1.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.WasMöchtenSieAutomatisieren;
      // 
      // drop_funcs
      // 
      resources.ApplyResources(this.drop_funcs, "drop_funcs");
      this.drop_funcs.Name = "drop_funcs";
      this.drop_funcs.NullText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.FunktionAuswählen;
      // 
      // PredefinedFunctions
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      resources.ApplyResources(this, "$this");
      this.Controls.Add(this.radGroupBox1);
      this.Controls.Add(this.header1);
      this.DisplayAbort = true;
      this.Name = "PredefinedFunctions";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
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