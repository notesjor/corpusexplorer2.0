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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetTheorySelectSnapshot));
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
      resources.ApplyResources(this.radPanel1, "radPanel1");
      // 
      // radDropDownList1
      // 
      resources.ApplyResources(this.radDropDownList1, "radDropDownList1");
      this.radDropDownList1.Name = "radDropDownList1";
      this.radDropDownList1.NullText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.BitteAuswählen;
      // 
      // radLabel1
      // 
      resources.ApplyResources(this.radLabel1, "radLabel1");
      this.radLabel1.Name = "radLabel1";
      // 
      // header1
      // 
      this.header1.BackColor = System.Drawing.Color.White;
      resources.ApplyResources(this.header1, "header1");
      this.header1.HeaderDescription = "{DESCRIPTION}";
      this.header1.HeaderHead = "Schnappschuss - Mengenoperation";
      this.header1.Name = "header1";
      // 
      // SetTheorySelectSnapshot
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      resources.ApplyResources(this, "$this");
      this.Controls.Add(this.radDropDownList1);
      this.Controls.Add(this.radLabel1);
      this.Controls.Add(this.header1);
      this.DisplayAbort = true;
      this.Name = "SetTheorySelectSnapshot";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
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