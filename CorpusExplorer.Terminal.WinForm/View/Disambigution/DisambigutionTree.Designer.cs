using CorpusExplorer.Terminal.WinForm.Properties;
using CorpusExplorer.Terminal.WinForm.Controls.WinForm;

namespace CorpusExplorer.Terminal.WinForm.View.Disambigution
{
  partial class DisambigutionTree
  {
    /// <summary> 
    /// Erforderliche Designervariable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Verwendete Ressourcen bereinigen.
    /// </summary>
    /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Vom Komponenten-Designer generierter Code

    /// <summary> 
    /// Erforderliche Methode für die Designerunterstützung. 
    /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
    /// </summary>
    private void InitializeComponent()
    {
      this.clearPanel1 = new ClearPanel();
      this.txt_queryA = new Telerik.WinControls.UI.RadTextBox();
      this.btn_start = new Telerik.WinControls.UI.RadButton();
      this.radTreeView1 = new Telerik.WinControls.UI.RadTreeView();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel1)).BeginInit();
      this.clearPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.txt_queryA)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_start)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radTreeView1)).BeginInit();
      this.SuspendLayout();
      // 
      // clearPanel1
      // 
      this.clearPanel1.Controls.Add(this.txt_queryA);
      this.clearPanel1.Controls.Add(this.btn_start);
      this.clearPanel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.clearPanel1.Location = new System.Drawing.Point(0, 0);
      this.clearPanel1.Name = "clearPanel1";
      this.clearPanel1.Size = new System.Drawing.Size(780, 30);
      this.clearPanel1.TabIndex = 1;
      // 
      // txt_queryA
      // 
      this.txt_queryA.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txt_queryA.Location = new System.Drawing.Point(0, 0);
      this.txt_queryA.Name = "txt_queryA";
      this.txt_queryA.Size = new System.Drawing.Size(625, 30);
      this.txt_queryA.TabIndex = 0;
      // 
      // btn_start
      // 
      this.btn_start.Dock = System.Windows.Forms.DockStyle.Right;
      this.btn_start.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.refresh;
      this.btn_start.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
      this.btn_start.Location = new System.Drawing.Point(625, 0);
      this.btn_start.Name = "btn_start";
      this.btn_start.Size = new System.Drawing.Size(155, 30);
      this.btn_start.TabIndex = 3;
      this.btn_start.Text = Resources.Aktualisieren;
      this.btn_start.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
      // 
      // radTreeView1
      // 
      this.radTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radTreeView1.ItemHeight = 40;
      this.radTreeView1.Location = new System.Drawing.Point(0, 30);
      this.radTreeView1.Name = "radTreeView1";
      this.radTreeView1.Size = new System.Drawing.Size(780, 370);
      this.radTreeView1.TabIndex = 2;
      this.radTreeView1.Text = "radTreeView1";
      this.radTreeView1.TreeIndent = 40;
      // 
      // DisambigutionTree
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.radTreeView1);
      this.Controls.Add(this.clearPanel1);
      this.Name = "DisambigutionTree";
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel1)).EndInit();
      this.clearPanel1.ResumeLayout(false);
      this.clearPanel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.txt_queryA)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_start)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radTreeView1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private ClearPanel clearPanel1;
    private Telerik.WinControls.UI.RadTextBox txt_queryA;
    private Telerik.WinControls.UI.RadButton btn_start;
    private Telerik.WinControls.UI.RadTreeView radTreeView1;
  }
}
