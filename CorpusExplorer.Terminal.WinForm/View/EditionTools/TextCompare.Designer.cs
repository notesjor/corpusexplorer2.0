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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StyleMetrics.CompareBasedOnCooccurrences));
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
      this.radCommandBar3.Dock = System.Windows.Forms.DockStyle.Top;
      this.radCommandBar3.Location = new System.Drawing.Point(0, 0);
      this.radCommandBar3.Name = "radCommandBar3";
      this.radCommandBar3.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement3});
      this.radCommandBar3.Size = new System.Drawing.Size(780, 44);
      this.radCommandBar3.TabIndex = 3;
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
      this.commandBarStripElement3.DisplayName = "commandBarStripElement3";
      this.commandBarStripElement3.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.commandBarLabel3,
            this.drop_textA,
            this.commandBarLabel4,
            this.drop_textB});
      this.commandBarStripElement3.Name = "commandBarStripElement3";
      // 
      // commandBarLabel3
      // 
      this.commandBarLabel3.DisplayName = "commandBarLabel3";
      this.commandBarLabel3.Name = "commandBarLabel3";
      this.commandBarLabel3.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.TextLinks;
      // 
      // drop_textA
      // 
      this.drop_textA.DisplayName = "commandBarDropDownList1";
      this.drop_textA.DropDownAnimationEnabled = true;
      this.drop_textA.MaxDropDownItems = 0;
      this.drop_textA.MinSize = new System.Drawing.Size(200, 22);
      this.drop_textA.Name = "drop_textA";
      this.drop_textA.Text = "";
      this.drop_textA.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.drop_textA_SelectedIndexChanged);
      // 
      // commandBarLabel4
      // 
      this.commandBarLabel4.DisplayName = "commandBarLabel4";
      this.commandBarLabel4.Name = "commandBarLabel4";
      this.commandBarLabel4.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.TextRechts;
      // 
      // drop_textB
      // 
      this.drop_textB.DisplayName = "commandBarDropDownList2";
      this.drop_textB.DropDownAnimationEnabled = true;
      this.drop_textB.MaxDropDownItems = 0;
      this.drop_textB.MinSize = new System.Drawing.Size(200, 22);
      this.drop_textB.Name = "drop_textB";
      this.drop_textB.Text = "";
      this.drop_textB.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.drop_textB_SelectedIndexChanged);
      // 
      // webHtml5Visualisation1
      // 
      this.webHtml5Visualisation1.BackColor = System.Drawing.Color.White;
      this.webHtml5Visualisation1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.webHtml5Visualisation1.Location = new System.Drawing.Point(0, 44);
      this.webHtml5Visualisation1.MainpageUrl = null;
      this.webHtml5Visualisation1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.webHtml5Visualisation1.Name = "webHtml5Visualisation1";
      this.webHtml5Visualisation1.Size = new System.Drawing.Size(780, 324);
      this.webHtml5Visualisation1.TabIndex = 4;
      this.webHtml5Visualisation1.TemplateVars = ((System.Collections.Generic.Dictionary<string, string>)(resources.GetObject("webHtml5Visualisation1.TemplateVars")));
      // 
      // clearPanel1
      // 
      this.clearPanel1.Controls.Add(this.radLabel1);
      this.clearPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.clearPanel1.Location = new System.Drawing.Point(0, 368);
      this.clearPanel1.Name = "clearPanel1";
      this.clearPanel1.Size = new System.Drawing.Size(780, 32);
      this.clearPanel1.TabIndex = 5;
      // 
      // radLabel1
      // 
      this.radLabel1.AutoSize = false;
      this.radLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radLabel1.Location = new System.Drawing.Point(0, 0);
      this.radLabel1.Name = "radLabel1";
      this.radLabel1.Size = new System.Drawing.Size(780, 32);
      this.radLabel1.TabIndex = 1;
      this.radLabel1.Text = "<html>Notwendige Transformationen (A -&gt; B) - Hinzufügen: <strong>0</strong> - " +
    "Entfernen: <strong>0</strong> - Distanz: <strong>0</strong></html>";
      this.radLabel1.TextWrap = false;
      // 
      // TextCompare
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
