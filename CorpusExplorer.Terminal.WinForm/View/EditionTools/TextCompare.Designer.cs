using CorpusExplorer.Terminal.WinForm.Properties;
using CorpusExplorer.Terminal.WinForm.Controls.WinForm.Webbrowser;

namespace CorpusExplorer.Terminal.WinForm.View.EditionTools
{
  partial class TextCompare
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextCompare));
      this.radCommandBar3 = new Telerik.WinControls.UI.RadCommandBar();
      this.commandBarRowElement3 = new Telerik.WinControls.UI.CommandBarRowElement();
      this.commandBarStripElement3 = new Telerik.WinControls.UI.CommandBarStripElement();
      this.commandBarLabel3 = new Telerik.WinControls.UI.CommandBarLabel();
      this.drop_textA = new Telerik.WinControls.UI.CommandBarDropDownList();
      this.commandBarLabel4 = new Telerik.WinControls.UI.CommandBarLabel();
      this.drop_textB = new Telerik.WinControls.UI.CommandBarDropDownList();
      this.webHtml5Visualisation1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.Webbrowser.WebHtml5Visualisation();
      this.clearPanel1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.ClearPanel();
      this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar3)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel1)).BeginInit();
      this.clearPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
      this.SuspendLayout();
      // 
      // radCommandBar3
      // 
      resources.ApplyResources(this.radCommandBar3, "radCommandBar3");
      this.radCommandBar3.Name = "radCommandBar3";
      this.radCommandBar3.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement3});
      // 
      // commandBarRowElement3
      // 
      this.commandBarRowElement3.MinSize = new System.Drawing.Size(25, 25);
      this.commandBarRowElement3.Name = "commandBarRowElement3";
      this.commandBarRowElement3.Strips.AddRange(new Telerik.WinControls.UI.CommandBarStripElement[] {
            this.commandBarStripElement3});
      // 
      // commandBarStripElement3
      // 
      resources.ApplyResources(this.commandBarStripElement3, "commandBarStripElement3");
      this.commandBarStripElement3.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.commandBarLabel3,
            this.drop_textA,
            this.commandBarLabel4,
            this.drop_textB});
      this.commandBarStripElement3.Name = "commandBarStripElement3";
      // 
      // commandBarLabel3
      // 
      resources.ApplyResources(this.commandBarLabel3, "commandBarLabel3");
      this.commandBarLabel3.Name = "commandBarLabel3";
      this.commandBarLabel3.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.TextLinks;
      // 
      // drop_textA
      // 
      resources.ApplyResources(this.drop_textA, "drop_textA");
      this.drop_textA.DropDownAnimationEnabled = true;
      this.drop_textA.MaxDropDownItems = 0;
      this.drop_textA.MinSize = new System.Drawing.Size(200, 22);
      this.drop_textA.Name = "drop_textA";
      this.drop_textA.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.drop_textA_SelectedIndexChanged);
      // 
      // commandBarLabel4
      // 
      resources.ApplyResources(this.commandBarLabel4, "commandBarLabel4");
      this.commandBarLabel4.Name = "commandBarLabel4";
      this.commandBarLabel4.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.TextRechts;
      // 
      // drop_textB
      // 
      resources.ApplyResources(this.drop_textB, "drop_textB");
      this.drop_textB.DropDownAnimationEnabled = true;
      this.drop_textB.MaxDropDownItems = 0;
      this.drop_textB.MinSize = new System.Drawing.Size(200, 22);
      this.drop_textB.Name = "drop_textB";
      this.drop_textB.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.drop_textB_SelectedIndexChanged);
      // 
      // webHtml5Visualisation1
      // 
      this.webHtml5Visualisation1.BackColor = System.Drawing.Color.White;
      resources.ApplyResources(this.webHtml5Visualisation1, "webHtml5Visualisation1");
      this.webHtml5Visualisation1.MainpageUrl = null;
      this.webHtml5Visualisation1.Name = "webHtml5Visualisation1";
      this.webHtml5Visualisation1.TemplateVars = ((System.Collections.Generic.Dictionary<string, string>)(resources.GetObject("webHtml5Visualisation1.TemplateVars")));
      // 
      // clearPanel1
      // 
      this.clearPanel1.Controls.Add(this.radLabel1);
      resources.ApplyResources(this.clearPanel1, "clearPanel1");
      this.clearPanel1.Name = "clearPanel1";
      // 
      // radLabel1
      // 
      resources.ApplyResources(this.radLabel1, "radLabel1");
      this.radLabel1.Name = "radLabel1";
      // 
      // TextCompare
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.Controls.Add(this.webHtml5Visualisation1);
      this.Controls.Add(this.clearPanel1);
      this.Controls.Add(this.radCommandBar3);
      this.Name = "TextCompare";
      this.ShowView += new System.EventHandler(this.TextComparePage_ShowVisualisation_1);
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar3)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel1)).EndInit();
      this.clearPanel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Telerik.WinControls.UI.RadCommandBar radCommandBar3;
    private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement3;
    private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement3;
    private Telerik.WinControls.UI.CommandBarLabel commandBarLabel3;
    private Telerik.WinControls.UI.CommandBarDropDownList drop_textA;
    private Telerik.WinControls.UI.CommandBarLabel commandBarLabel4;
    private Telerik.WinControls.UI.CommandBarDropDownList drop_textB;
    private WebHtml5Visualisation webHtml5Visualisation1;
    private Controls.WinForm.ClearPanel clearPanel1;
    private Telerik.WinControls.UI.RadLabel radLabel1;
  }
}
