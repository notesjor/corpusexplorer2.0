using CorpusExplorer.Terminal.WinForm.Properties;
namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm
{
  partial class Checklist
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Checklist));
      this.radScrollablePanel1 = new Telerik.WinControls.UI.RadScrollablePanel();
      this.header1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.Header();
      this.radButtonWithCheckmark1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.RadButtonWithCheckmark();
      ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel1)).BeginInit();
      this.radScrollablePanel1.PanelContainer.SuspendLayout();
      this.radScrollablePanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.header1)).BeginInit();
      this.SuspendLayout();
      // 
      // radScrollablePanel1
      // 
      resources.ApplyResources(this.radScrollablePanel1, "radScrollablePanel1");
      this.radScrollablePanel1.Name = "radScrollablePanel1";
      // 
      // radScrollablePanel1.PanelContainer
      // 
      this.radScrollablePanel1.PanelContainer.Controls.Add(this.radButtonWithCheckmark1);
      resources.ApplyResources(this.radScrollablePanel1.PanelContainer, "radScrollablePanel1.PanelContainer");
      // 
      // header1
      // 
      resources.ApplyResources(this.header1, "header1");
      this.header1.BackColor = System.Drawing.Color.White;
      this.header1.HeaderDescription = "{HeaderDescription}";
      this.header1.HeaderHead = "{HeaderHead}";
      this.header1.Name = "header1";
      // 
      // radButtonWithCheckmark1
      // 
      this.radButtonWithCheckmark1.BackColor = System.Drawing.Color.White;
      resources.ApplyResources(this.radButtonWithCheckmark1, "radButtonWithCheckmark1");
      this.radButtonWithCheckmark1.Image = null;
      this.radButtonWithCheckmark1.ImageCheckmark = ((System.Drawing.Image)(resources.GetObject("radButtonWithCheckmark1.ImageCheckmark")));
      this.radButtonWithCheckmark1.Label = "radButtonWithCheckmark";
      this.radButtonWithCheckmark1.Name = "radButtonWithCheckmark1";
      this.radButtonWithCheckmark1.ShowCheckmark = false;
      // 
      // Checklist
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.BackColor = System.Drawing.Color.White;
      this.Controls.Add(this.header1);
      this.Controls.Add(this.radScrollablePanel1);
      resources.ApplyResources(this, "$this");
      this.Name = "Checklist";
      this.radScrollablePanel1.PanelContainer.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel1)).EndInit();
      this.radScrollablePanel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.header1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion
    private Header header1;
    private Telerik.WinControls.UI.RadScrollablePanel radScrollablePanel1;
        private RadButtonWithCheckmark radButtonWithCheckmark1;
    }
}
