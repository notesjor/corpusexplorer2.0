using CorpusExplorer.Terminal.WinForm.Properties;
namespace CorpusExplorer.Terminal.WinForm.Forms.Error
{
  partial class ErrorConsole
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
      if (disposing && (this.components != null))
      {
        this.components.Dispose();
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorConsole));
      this.radTreeView1 = new Telerik.WinControls.UI.RadTreeView();
      this.btn_save = new Telerik.WinControls.UI.RadButton();
      this.btn_clear = new Telerik.WinControls.UI.RadButton();
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
      this.radPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radTreeView1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_save)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_clear)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // radPanel1
      // 
      this.radPanel1.Controls.Add(this.btn_clear);
      this.radPanel1.Controls.Add(this.btn_save);
      resources.ApplyResources(this.radPanel1, "radPanel1");
      this.radPanel1.Controls.SetChildIndex(this.btn_save, 0);
      this.radPanel1.Controls.SetChildIndex(this.btn_clear, 0);
      // 
      // radTreeView1
      // 
      resources.ApplyResources(this.radTreeView1, "radTreeView1");
      this.radTreeView1.ItemHeight = 40;
      this.radTreeView1.Name = "radTreeView1";
      // 
      // btn_save
      // 
      resources.ApplyResources(this.btn_save, "btn_save");
      this.btn_save.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.save;
      this.btn_save.Name = "btn_save";
      this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
      // 
      // btn_clear
      // 
      resources.ApplyResources(this.btn_clear, "btn_clear");
      this.btn_clear.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.remove_button;
      this.btn_clear.Name = "btn_clear";
      this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
      // 
      // ErrorConsole
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      resources.ApplyResources(this, "$this");
      this.Controls.Add(this.radTreeView1);
      this.DisplayAbort = true;
      this.Name = "ErrorConsole";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.Controls.SetChildIndex(this.radPanel1, 0);
      this.Controls.SetChildIndex(this.radTreeView1, 0);
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
      this.radPanel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radTreeView1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_save)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_clear)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private Telerik.WinControls.UI.RadTreeView radTreeView1;
    private Telerik.WinControls.UI.RadButton btn_save;
    private Telerik.WinControls.UI.RadButton btn_clear;
  }
}