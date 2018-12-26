using CorpusExplorer.Terminal.WinForm.Controls.WinForm;
using CorpusExplorer.Terminal.WinForm.Controls.WinForm.Webbrowser;

namespace CorpusExplorer.Terminal.WinForm.View.Cooccurrence
{
  partial class CooccurrenceTagPie
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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CooccurrenceTagPie));
      this.wordBag1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.WordBag();
      this.webHtml5Visualisation1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.Webbrowser.WebHtml5Visualisation();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.radCommandBar1 = new Telerik.WinControls.UI.RadCommandBar();
      this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
      this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
      this.commandBarButton1 = new Telerik.WinControls.UI.CommandBarButton();
      this.commandBarButton2 = new Telerik.WinControls.UI.CommandBarButton();
      this.commandBarButton3 = new Telerik.WinControls.UI.CommandBarButton();
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
      this.SuspendLayout();
      // 
      // wordBag1
      // 
      this.wordBag1.BackColor = System.Drawing.Color.White;
      resources.ApplyResources(this.wordBag1, "wordBag1");
      this.wordBag1.Name = "wordBag1";
      this.wordBag1.ResultQueries = new string[0];
      this.wordBag1.ResultSelectedLayerDisplayname = null;
      this.wordBag1.ExecuteButtonClicked += new System.EventHandler(this.wordBag1_ExecuteButtonClicked);
      this.wordBag1.Load += new System.EventHandler(this.wordBag1_Load);
      // 
      // webHtml5Visualisation1
      // 
      this.webHtml5Visualisation1.BackColor = System.Drawing.Color.White;
      resources.ApplyResources(this.webHtml5Visualisation1, "webHtml5Visualisation1");
      this.webHtml5Visualisation1.MainpageUrl = null;
      this.webHtml5Visualisation1.Name = "webHtml5Visualisation1";
      this.webHtml5Visualisation1.TemplateVars = ((System.Collections.Generic.Dictionary<string, string>)(resources.GetObject("webHtml5Visualisation1.TemplateVars")));
      // 
      // timer1
      // 
      this.timer1.Interval = 5000;
      this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
      // 
      // radCommandBar1
      // 
      resources.ApplyResources(this.radCommandBar1, "radCommandBar1");
      this.radCommandBar1.Name = "radCommandBar1";
      this.radCommandBar1.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement1});
      // 
      // commandBarRowElement1
      // 
      this.commandBarRowElement1.MinSize = new System.Drawing.Size(25, 25);
      this.commandBarRowElement1.Name = "commandBarRowElement1";
      this.commandBarRowElement1.Strips.AddRange(new Telerik.WinControls.UI.CommandBarStripElement[] {
            this.commandBarStripElement1});
      // 
      // commandBarStripElement1
      // 
      resources.ApplyResources(this.commandBarStripElement1, "commandBarStripElement1");
      this.commandBarStripElement1.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.commandBarButton1,
            this.commandBarButton2,
            this.commandBarButton3});
      this.commandBarStripElement1.Name = "commandBarStripElement1";
      // 
      // commandBarButton1
      // 
      resources.ApplyResources(this.commandBarButton1, "commandBarButton1");
      this.commandBarButton1.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.image;
      this.commandBarButton1.AutoToolTip = true;
      this.commandBarButton1.Name = "commandBarButton1";
      this.commandBarButton1.Click += new System.EventHandler(this.commandBarButton3_Click);
      // 
      // commandBarButton2
      // 
      resources.ApplyResources(this.commandBarButton2, "commandBarButton2");
      this.commandBarButton2.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.export_pdf;
      this.commandBarButton2.AutoToolTip = true;
      this.commandBarButton2.Name = "commandBarButton2";
      this.commandBarButton2.Click += new System.EventHandler(this.commandBarButton4_Click);
      // 
      // commandBarButton3
      // 
      resources.ApplyResources(this.commandBarButton3, "commandBarButton3");
      this.commandBarButton3.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.print;
      this.commandBarButton3.AutoToolTip = true;
      this.commandBarButton3.Name = "commandBarButton3";
      this.commandBarButton3.Click += new System.EventHandler(this.commandBarButton1_Click);
      // 
      // CooccurrenceTagPie
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.Controls.Add(this.webHtml5Visualisation1);
      this.Controls.Add(this.wordBag1);
      this.Controls.Add(this.radCommandBar1);
      this.Name = "CooccurrenceTagPie";
      this.ShowView += new System.EventHandler(this.WordCloudVisualisation_ShowVisualisation);
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private WordBag wordBag1;
    private WebHtml5Visualisation webHtml5Visualisation1;
    private System.Windows.Forms.Timer timer1;
    private Telerik.WinControls.UI.RadCommandBar radCommandBar1;
    private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
    private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement1;
    private Telerik.WinControls.UI.CommandBarButton commandBarButton1;
    private Telerik.WinControls.UI.CommandBarButton commandBarButton2;
    private Telerik.WinControls.UI.CommandBarButton commandBarButton3;
  }
}
