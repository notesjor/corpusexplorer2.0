using CorpusExplorer.Terminal.WinForm.Properties;
namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm
{
  partial class InfoPanel
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
      if (disposing && (this.components != null))
      {
        this.components.Dispose();
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoPanel));
      this.radScrollablePanel1 = new Telerik.WinControls.UI.RadScrollablePanel();
      this.num_token = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.BigNumber();
      this.num_layer = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.BigNumber();
      this.num_docs = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.BigNumber();
      this.num_corpora = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.BigNumber();
      ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel1)).BeginInit();
      this.radScrollablePanel1.PanelContainer.SuspendLayout();
      this.radScrollablePanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // radScrollablePanel1
      // 
      resources.ApplyResources(this.radScrollablePanel1, "radScrollablePanel1");
      this.radScrollablePanel1.Name = "radScrollablePanel1";
      // 
      // radScrollablePanel1.PanelContainer
      // 
      this.radScrollablePanel1.PanelContainer.Controls.Add(this.num_token);
      this.radScrollablePanel1.PanelContainer.Controls.Add(this.num_layer);
      this.radScrollablePanel1.PanelContainer.Controls.Add(this.num_docs);
      this.radScrollablePanel1.PanelContainer.Controls.Add(this.num_corpora);
      resources.ApplyResources(this.radScrollablePanel1.PanelContainer, "radScrollablePanel1.PanelContainer");
      ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radScrollablePanel1.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
      // 
      // num_token
      // 
      this.num_token.BackColor = System.Drawing.Color.White;
      resources.ApplyResources(this.num_token, "num_token");
      this.num_token.Label = "Token";
      this.num_token.Name = "num_token";
      this.num_token.Value = ((long)(0));
      this.num_token.ValueAutoCut = true;
      // 
      // num_layer
      // 
      this.num_layer.BackColor = System.Drawing.Color.White;
      resources.ApplyResources(this.num_layer, "num_layer");
      this.num_layer.Label = "Layer";
      this.num_layer.Name = "num_layer";
      this.num_layer.Value = ((long)(0));
      this.num_layer.ValueAutoCut = true;
      // 
      // num_docs
      // 
      this.num_docs.BackColor = System.Drawing.Color.White;
      resources.ApplyResources(this.num_docs, "num_docs");
      this.num_docs.Label = "Dokumente";
      this.num_docs.Name = "num_docs";
      this.num_docs.Value = ((long)(0));
      this.num_docs.ValueAutoCut = true;
      // 
      // num_corpora
      // 
      this.num_corpora.BackColor = System.Drawing.Color.White;
      resources.ApplyResources(this.num_corpora, "num_corpora");
      this.num_corpora.Label = "Korpora";
      this.num_corpora.Name = "num_corpora";
      this.num_corpora.Value = ((long)(0));
      this.num_corpora.ValueAutoCut = true;
      // 
      // InfoPanel
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.BackColor = System.Drawing.Color.White;
      this.Controls.Add(this.radScrollablePanel1);
      resources.ApplyResources(this, "$this");
      this.Name = "InfoPanel";
      this.radScrollablePanel1.PanelContainer.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel1)).EndInit();
      this.radScrollablePanel1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

        #endregion

        private Telerik.WinControls.UI.RadScrollablePanel radScrollablePanel1;
        private BigNumber num_token;
        private BigNumber num_layer;
        private BigNumber num_docs;
        private BigNumber num_corpora;
    }
}
