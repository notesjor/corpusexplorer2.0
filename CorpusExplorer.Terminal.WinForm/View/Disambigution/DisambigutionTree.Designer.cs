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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DisambigutionTree));
      this.radTreeView1 = new Telerik.WinControls.UI.RadTreeView();
      this.wordBag1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.WordBag();
      ((System.ComponentModel.ISupportInitialize)(this.radTreeView1)).BeginInit();
      this.SuspendLayout();
      // 
      // radTreeView1
      // 
      resources.ApplyResources(this.radTreeView1, "radTreeView1");
      this.radTreeView1.ItemHeight = 40;
      this.radTreeView1.Name = "radTreeView1";
      // 
      // wordBag1
      // 
      this.wordBag1.BackColor = System.Drawing.Color.White;
      resources.ApplyResources(this.wordBag1, "wordBag1");
      this.wordBag1.Name = "wordBag1";
      this.wordBag1.ResultQueries = new string[0];
      this.wordBag1.ResultSelectedLayerDisplayname = null;
      this.wordBag1.ExecuteButtonClicked += new System.EventHandler(this.wordBag1_ExecuteButtonClicked);
      // 
      // DisambigutionTree
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.Controls.Add(this.radTreeView1);
      this.Controls.Add(this.wordBag1);
      this.Name = "DisambigutionTree";
      ((System.ComponentModel.ISupportInitialize)(this.radTreeView1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion
    private Telerik.WinControls.UI.RadTreeView radTreeView1;
    private WordBag wordBag1;
  }
}
