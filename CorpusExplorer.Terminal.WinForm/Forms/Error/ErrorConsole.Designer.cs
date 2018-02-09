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
      this.radPanel1.Location = new System.Drawing.Point(0, 352);
      this.radPanel1.Size = new System.Drawing.Size(683, 38);
      this.radPanel1.Controls.SetChildIndex(this.btn_save, 0);
      this.radPanel1.Controls.SetChildIndex(this.btn_clear, 0);
      // 
      // radTreeView1
      // 
      this.radTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radTreeView1.ItemHeight = 40;
      this.radTreeView1.Location = new System.Drawing.Point(0, 0);
      this.radTreeView1.Name = "radTreeView1";
      this.radTreeView1.Size = new System.Drawing.Size(683, 352);
      this.radTreeView1.TabIndex = 1;
      this.radTreeView1.Text = "radTreeView1";
      this.radTreeView1.TreeIndent = 40;
      // 
      // btn_save
      // 
      this.btn_save.Dock = System.Windows.Forms.DockStyle.Left;
      this.btn_save.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.save;
      this.btn_save.ImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
      this.btn_save.Location = new System.Drawing.Point(3, 3);
      this.btn_save.Name = "btn_save";
      this.btn_save.Size = new System.Drawing.Size(212, 32);
      this.btn_save.TabIndex = 3;
      this.btn_save.Text = "Fehlerbereicht speichern";
      this.btn_save.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
      this.btn_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
      // 
      // btn_clear
      // 
      this.btn_clear.Dock = System.Windows.Forms.DockStyle.Left;
      this.btn_clear.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.remove_button;
      this.btn_clear.ImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
      this.btn_clear.Location = new System.Drawing.Point(215, 3);
      this.btn_clear.Name = "btn_clear";
      this.btn_clear.Size = new System.Drawing.Size(212, 32);
      this.btn_clear.TabIndex = 4;
      this.btn_clear.Text = "Fehlerspeicher löschen";
      this.btn_clear.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
      this.btn_clear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
      // 
      // ErrorConsole
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(683, 390);
      this.Controls.Add(this.radTreeView1);
      this.DisplayAbort = true;
      this.Name = "ErrorConsole";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.Text = "Fehlerbericht";
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