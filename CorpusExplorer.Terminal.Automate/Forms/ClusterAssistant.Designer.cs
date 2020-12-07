namespace CorpusExplorer.Terminal.Automate
{
  partial class ClusterAssistant
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
      this.radCommandBar1 = new Telerik.WinControls.UI.RadCommandBar();
      this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
      this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
      this.btn_ok = new Telerik.WinControls.UI.CommandBarButton();
      this.btn_abort = new Telerik.WinControls.UI.CommandBarButton();
      this.radScrollablePanel1 = new Telerik.WinControls.UI.RadScrollablePanel();
      this.autoSplit1 = new CorpusExplorer.Terminal.Automate.Controls.AutoSplit();
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel1)).BeginInit();
      this.radScrollablePanel1.PanelContainer.SuspendLayout();
      this.radScrollablePanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // radCommandBar1
      // 
      this.radCommandBar1.Dock = System.Windows.Forms.DockStyle.Top;
      this.radCommandBar1.Location = new System.Drawing.Point(0, 0);
      this.radCommandBar1.Name = "radCommandBar1";
      this.radCommandBar1.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement1});
      this.radCommandBar1.Size = new System.Drawing.Size(580, 44);
      this.radCommandBar1.TabIndex = 0;
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
      this.commandBarStripElement1.DisplayName = "commandBarStripElement1";
      this.commandBarStripElement1.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.btn_ok,
            this.btn_abort});
      this.commandBarStripElement1.Name = "commandBarStripElement1";
      // 
      // btn_ok
      // 
      this.btn_ok.DisplayName = "commandBarButton4";
      this.btn_ok.Image = global::CorpusExplorer.Terminal.Automate.Properties.Resources.ok_button;
      this.btn_ok.Name = "btn_ok";
      this.btn_ok.Text = "Änderungen übernehmen";
      this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
      // 
      // btn_abort
      // 
      this.btn_abort.DisplayName = "commandBarButton5";
      this.btn_abort.Image = global::CorpusExplorer.Terminal.Automate.Properties.Resources.close_window;
      this.btn_abort.Name = "btn_abort";
      this.btn_abort.Text = "Änderungen abbrechen";
      this.btn_abort.Click += new System.EventHandler(this.btn_abort_Click);
      // 
      // radScrollablePanel1
      // 
      this.radScrollablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radScrollablePanel1.Location = new System.Drawing.Point(0, 44);
      this.radScrollablePanel1.Name = "radScrollablePanel1";
      // 
      // radScrollablePanel1.PanelContainer
      // 
      this.radScrollablePanel1.PanelContainer.Controls.Add(this.autoSplit1);
      this.radScrollablePanel1.PanelContainer.Size = new System.Drawing.Size(578, 297);
      this.radScrollablePanel1.Size = new System.Drawing.Size(580, 299);
      this.radScrollablePanel1.TabIndex = 5;
      // 
      // autoSplit1
      // 
      this.autoSplit1.BackColor = System.Drawing.Color.White;
      this.autoSplit1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.autoSplit1.Location = new System.Drawing.Point(0, 0);
      this.autoSplit1.Name = "autoSplit1";
      this.autoSplit1.Size = new System.Drawing.Size(578, 297);
      this.autoSplit1.TabIndex = 0;
      // 
      // ClusterAssistant
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(580, 343);
      this.Controls.Add(this.radScrollablePanel1);
      this.Controls.Add(this.radCommandBar1);
      this.Margin = new System.Windows.Forms.Padding(4);
      this.Name = "ClusterAssistant";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.Text = "CorpusExplorerConsole (CEC) - Visueller Skript Editor (VSE)";
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
      this.radScrollablePanel1.PanelContainer.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel1)).EndInit();
      this.radScrollablePanel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Telerik.WinControls.UI.RadCommandBar radCommandBar1;
    private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
    private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement1;
    private Telerik.WinControls.UI.RadScrollablePanel radScrollablePanel1;
    private Telerik.WinControls.UI.CommandBarButton btn_ok;
    private Telerik.WinControls.UI.CommandBarButton btn_abort;
    private Controls.AutoSplit autoSplit1;
  }
}