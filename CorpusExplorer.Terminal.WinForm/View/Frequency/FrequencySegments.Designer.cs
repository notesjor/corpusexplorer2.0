using CorpusExplorer.Terminal.WinForm.Properties;
using CorpusExplorer.Terminal.WinForm.Controls.WinForm;

namespace CorpusExplorer.Terminal.WinForm.View.Frequency
{
    partial class FrequencySegments
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrequencySegments));
      this.radCommandBar1 = new Telerik.WinControls.UI.RadCommandBar();
      this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
      this.commandBarStripElement2 = new Telerik.WinControls.UI.CommandBarStripElement();
      this.btn_export = new Telerik.WinControls.UI.CommandBarButton();
      this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
      this.radSplitContainer1 = new Telerik.WinControls.UI.RadSplitContainer();
      this.splitPanel1 = new Telerik.WinControls.UI.SplitPanel();
      this.header1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.Header();
      this.splitPanel2 = new Telerik.WinControls.UI.SplitPanel();
      this.elementHost2 = new System.Windows.Forms.Integration.ElementHost();
      this.header2 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.Header();
      this.wordBag1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.WordBag();
      this.elementHost3 = new System.Windows.Forms.Integration.ElementHost();
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).BeginInit();
      this.radSplitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).BeginInit();
      this.splitPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).BeginInit();
      this.splitPanel2.SuspendLayout();
      this.SuspendLayout();
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
            this.commandBarStripElement2});
      // 
      // commandBarStripElement2
      // 
      resources.ApplyResources(this.commandBarStripElement2, "commandBarStripElement2");
      this.commandBarStripElement2.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.btn_export});
      this.commandBarStripElement2.Name = "commandBarStripElement2";
      // 
      // btn_export
      // 
      resources.ApplyResources(this.btn_export, "btn_export");
      this.btn_export.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.export_text;
      this.btn_export.AutoToolTip = true;
      this.btn_export.Name = "btn_export";
      this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
      // 
      // elementHost1
      // 
      resources.ApplyResources(this.elementHost1, "elementHost1");
      this.elementHost1.Name = "elementHost1";
      this.elementHost1.Child = null;
      // 
      // radSplitContainer1
      // 
      this.radSplitContainer1.Controls.Add(this.splitPanel1);
      this.radSplitContainer1.Controls.Add(this.splitPanel2);
      resources.ApplyResources(this.radSplitContainer1, "radSplitContainer1");
      this.radSplitContainer1.Name = "radSplitContainer1";
      // 
      // 
      // 
      this.radSplitContainer1.RootElement.MinSize = new System.Drawing.Size(0, 0);
      this.radSplitContainer1.TabStop = false;
      // 
      // splitPanel1
      // 
      this.splitPanel1.Controls.Add(this.elementHost1);
      this.splitPanel1.Controls.Add(this.header1);
      resources.ApplyResources(this.splitPanel1, "splitPanel1");
      this.splitPanel1.Name = "splitPanel1";
      // 
      // 
      // 
      this.splitPanel1.RootElement.MinSize = new System.Drawing.Size(0, 0);
      this.splitPanel1.TabStop = false;
      // 
      // header1
      // 
      this.header1.BackColor = System.Drawing.Color.White;
      resources.ApplyResources(this.header1, "header1");
      this.header1.HeaderDescription = "Frequenzverteilung auf ein normiertes Dokument";
      this.header1.HeaderHead = "Dokumentverteilung";
      this.header1.Name = "header1";
      // 
      // splitPanel2
      // 
      this.splitPanel2.Controls.Add(this.elementHost2);
      this.splitPanel2.Controls.Add(this.header2);
      resources.ApplyResources(this.splitPanel2, "splitPanel2");
      this.splitPanel2.Name = "splitPanel2";
      // 
      // 
      // 
      this.splitPanel2.RootElement.MinSize = new System.Drawing.Size(0, 0);
      this.splitPanel2.TabStop = false;
      // 
      // elementHost2
      // 
      resources.ApplyResources(this.elementHost2, "elementHost2");
      this.elementHost2.Name = "elementHost2";
      this.elementHost2.Child = null;
      // 
      // header2
      // 
      this.header2.BackColor = System.Drawing.Color.White;
      resources.ApplyResources(this.header2, "header2");
      this.header2.HeaderDescription = "Frequenzverteilung auf einen normierten Satz";
      this.header2.HeaderHead = "Satzverteilung";
      this.header2.Name = "header2";
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
      // elementHost3
      // 
      resources.ApplyResources(this.elementHost3, "elementHost3");
      this.elementHost3.Name = "elementHost3";
      this.elementHost3.Child = null;
      // 
      // FrequencySegments
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.Controls.Add(this.radSplitContainer1);
      this.Controls.Add(this.elementHost3);
      this.Controls.Add(this.wordBag1);
      this.Controls.Add(this.radCommandBar1);
      resources.ApplyResources(this, "$this");
      this.Name = "FrequencySegments";
      this.ShowView += new System.EventHandler(this.SegmentVisualisation_ShowVisualisation);
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).EndInit();
      this.radSplitContainer1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).EndInit();
      this.splitPanel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).EndInit();
      this.splitPanel2.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadCommandBar radCommandBar1;
        private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private Telerik.WinControls.UI.RadSplitContainer radSplitContainer1;
        private Telerik.WinControls.UI.SplitPanel splitPanel1;
        private Header header1;
        private Telerik.WinControls.UI.SplitPanel splitPanel2;
        private System.Windows.Forms.Integration.ElementHost elementHost2;
        private Header header2;
    private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement2;
    private Telerik.WinControls.UI.CommandBarButton btn_export;
    private WordBag wordBag1;
    private System.Windows.Forms.Integration.ElementHost elementHost3;
  }
}
