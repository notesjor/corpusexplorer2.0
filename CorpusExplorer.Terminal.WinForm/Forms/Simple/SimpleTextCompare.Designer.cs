using CorpusExplorer.Terminal.WinForm.Properties;
namespace CorpusExplorer.Terminal.WinForm.Forms.Simple
{
  partial class SimpleTextCompare
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimpleTextCompare));
      this.webHtml5Visualisation1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.WebBrowserControl();
      this.radCommandBar3 = new Telerik.WinControls.UI.RadCommandBar();
      this.commandBarRowElement3 = new Telerik.WinControls.UI.CommandBarRowElement();
      this.commandBarStripElement3 = new Telerik.WinControls.UI.CommandBarStripElement();
      this.commandBarLabel3 = new Telerik.WinControls.UI.CommandBarLabel();
      this.commandBarDropDownList1 = new Telerik.WinControls.UI.CommandBarDropDownList();
      this.commandBarLabel4 = new Telerik.WinControls.UI.CommandBarLabel();
      this.commandBarDropDownList2 = new Telerik.WinControls.UI.CommandBarDropDownList();
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar3)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // radPanel1
      // 
      resources.ApplyResources(this.radPanel1, "radPanel1");
      // 
      // webHtml5Visualisation1
      // 
      this.webHtml5Visualisation1.BackColor = System.Drawing.Color.White;
      resources.ApplyResources(this.webHtml5Visualisation1, "webHtml5Visualisation1");
      this.webHtml5Visualisation1.Name = "webHtml5Visualisation1";
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
      this.commandBarRowElement3.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
      this.commandBarRowElement3.MinSize = new System.Drawing.Size(25, 25);
      this.commandBarRowElement3.Name = "commandBarRowElement3";
      this.commandBarRowElement3.Strips.AddRange(new Telerik.WinControls.UI.CommandBarStripElement[] {
            this.commandBarStripElement3});
      resources.ApplyResources(this.commandBarRowElement3, "commandBarRowElement3");
      this.commandBarRowElement3.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
      // 
      // commandBarStripElement3
      // 
      this.commandBarStripElement3.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
      resources.ApplyResources(this.commandBarStripElement3, "commandBarStripElement3");
      this.commandBarStripElement3.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.commandBarLabel3,
            this.commandBarDropDownList1,
            this.commandBarLabel4,
            this.commandBarDropDownList2});
      this.commandBarStripElement3.Name = "commandBarStripElement3";
      this.commandBarStripElement3.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
      // 
      // commandBarLabel3
      // 
      this.commandBarLabel3.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
      resources.ApplyResources(this.commandBarLabel3, "commandBarLabel3");
      this.commandBarLabel3.Name = "commandBarLabel3";
      this.commandBarLabel3.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.TextLinks;
      this.commandBarLabel3.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
      // 
      // commandBarDropDownList1
      // 
      resources.ApplyResources(this.commandBarDropDownList1, "commandBarDropDownList1");
      this.commandBarDropDownList1.DropDownAnimationEnabled = true;
      this.commandBarDropDownList1.MaxDropDownItems = 0;
      this.commandBarDropDownList1.MinSize = new System.Drawing.Size(250, 22);
      this.commandBarDropDownList1.Name = "commandBarDropDownList1";
      this.commandBarDropDownList1.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.commandBarDropDownList1_SelectedIndexChanged);
      // 
      // commandBarLabel4
      // 
      this.commandBarLabel4.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
      resources.ApplyResources(this.commandBarLabel4, "commandBarLabel4");
      this.commandBarLabel4.Name = "commandBarLabel4";
      this.commandBarLabel4.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.TextRechts;
      this.commandBarLabel4.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
      // 
      // commandBarDropDownList2
      // 
      resources.ApplyResources(this.commandBarDropDownList2, "commandBarDropDownList2");
      this.commandBarDropDownList2.DropDownAnimationEnabled = true;
      this.commandBarDropDownList2.MaxDropDownItems = 0;
      this.commandBarDropDownList2.MinSize = new System.Drawing.Size(250, 22);
      this.commandBarDropDownList2.Name = "commandBarDropDownList2";
      this.commandBarDropDownList2.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.commandBarDropDownList2_SelectedIndexChanged);
      // 
      // SimpleTextCompare
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      resources.ApplyResources(this, "$this");
      this.Controls.Add(this.webHtml5Visualisation1);
      this.Controls.Add(this.radCommandBar3);
      this.DisplayAbort = true;
      this.Name = "SimpleTextCompare";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.Controls.SetChildIndex(this.radPanel1, 0);
      this.Controls.SetChildIndex(this.radCommandBar3, 0);
      this.Controls.SetChildIndex(this.webHtml5Visualisation1, 0);
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar3)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Controls.WinForm.WebBrowserControl webHtml5Visualisation1;
    private Telerik.WinControls.UI.RadCommandBar radCommandBar3;
    private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement3;
    private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement3;
    private Telerik.WinControls.UI.CommandBarLabel commandBarLabel3;
    private Telerik.WinControls.UI.CommandBarLabel commandBarLabel4;
    private Telerik.WinControls.UI.CommandBarDropDownList commandBarDropDownList1;
    private Telerik.WinControls.UI.CommandBarDropDownList commandBarDropDownList2;
  }
}