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
      this.radCommandBar1.Dock = System.Windows.Forms.DockStyle.Top;
      this.radCommandBar1.Location = new System.Drawing.Point(0, 0);
      this.radCommandBar1.Name = "radCommandBar1";
      this.radCommandBar1.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement1});
      this.radCommandBar1.Size = new System.Drawing.Size(780, 44);
      this.radCommandBar1.TabIndex = 0;
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
      this.commandBarStripElement2.DisplayName = "commandBarStripElement2";
      this.commandBarStripElement2.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.btn_export});
      this.commandBarStripElement2.Name = "commandBarStripElement2";
      // 
      // btn_export
      // 
      this.btn_export.DisplayName = "commandBarButton1";
      this.btn_export.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.export_text;
      this.btn_export.Name = "btn_export";
      this.btn_export.Text = "Export";
      this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
      // 
      // elementHost1
      // 
      this.elementHost1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.elementHost1.Location = new System.Drawing.Point(0, 58);
      this.elementHost1.Name = "elementHost1";
      this.elementHost1.Size = new System.Drawing.Size(780, 78);
      this.elementHost1.TabIndex = 1;
      this.elementHost1.Text = "elementHost1";
      this.elementHost1.Child = null;
      // 
      // radSplitContainer1
      // 
      this.radSplitContainer1.Controls.Add(this.splitPanel1);
      this.radSplitContainer1.Controls.Add(this.splitPanel2);
      this.radSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radSplitContainer1.Location = new System.Drawing.Point(0, 80);
      this.radSplitContainer1.Name = "radSplitContainer1";
      this.radSplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // 
      // 
      this.radSplitContainer1.RootElement.MinSize = new System.Drawing.Size(0, 0);
      this.radSplitContainer1.Size = new System.Drawing.Size(780, 275);
      this.radSplitContainer1.TabIndex = 2;
      this.radSplitContainer1.TabStop = false;
      // 
      // splitPanel1
      // 
      this.splitPanel1.Controls.Add(this.elementHost1);
      this.splitPanel1.Controls.Add(this.header1);
      this.splitPanel1.Location = new System.Drawing.Point(0, 0);
      this.splitPanel1.Name = "splitPanel1";
      // 
      // 
      // 
      this.splitPanel1.RootElement.MinSize = new System.Drawing.Size(0, 0);
      this.splitPanel1.Size = new System.Drawing.Size(780, 136);
      this.splitPanel1.TabIndex = 0;
      this.splitPanel1.TabStop = false;
      this.splitPanel1.Text = "splitPanel1";
      // 
      // header1
      // 
      this.header1.BackColor = System.Drawing.Color.White;
      this.header1.Dock = System.Windows.Forms.DockStyle.Top;
      this.header1.Font = new System.Drawing.Font("Segoe UI", 11F);
      this.header1.HeaderDescribtion = "Frequenzverteilung auf ein normiertes Dokument";
      this.header1.HeaderHead = "Dokumentverteilung";
      this.header1.Location = new System.Drawing.Point(0, 0);
      this.header1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.header1.Name = "header1";
      this.header1.Size = new System.Drawing.Size(780, 58);
      this.header1.TabIndex = 2;
      // 
      // splitPanel2
      // 
      this.splitPanel2.Controls.Add(this.elementHost2);
      this.splitPanel2.Controls.Add(this.header2);
      this.splitPanel2.Location = new System.Drawing.Point(0, 140);
      this.splitPanel2.Name = "splitPanel2";
      // 
      // 
      // 
      this.splitPanel2.RootElement.MinSize = new System.Drawing.Size(0, 0);
      this.splitPanel2.Size = new System.Drawing.Size(780, 135);
      this.splitPanel2.TabIndex = 1;
      this.splitPanel2.TabStop = false;
      this.splitPanel2.Text = "splitPanel2";
      // 
      // elementHost2
      // 
      this.elementHost2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.elementHost2.Location = new System.Drawing.Point(0, 58);
      this.elementHost2.Name = "elementHost2";
      this.elementHost2.Size = new System.Drawing.Size(780, 77);
      this.elementHost2.TabIndex = 0;
      this.elementHost2.Text = "elementHost2";
      this.elementHost2.Child = null;
      // 
      // header2
      // 
      this.header2.BackColor = System.Drawing.Color.White;
      this.header2.Dock = System.Windows.Forms.DockStyle.Top;
      this.header2.Font = new System.Drawing.Font("Segoe UI", 11F);
      this.header2.HeaderDescribtion = "Frequenzverteilung auf einen normierten Satz";
      this.header2.HeaderHead = "Satzverteilung";
      this.header2.Location = new System.Drawing.Point(0, 0);
      this.header2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.header2.Name = "header2";
      this.header2.Size = new System.Drawing.Size(780, 58);
      this.header2.TabIndex = 3;
      // 
      // wordBag1
      // 
      this.wordBag1.BackColor = System.Drawing.Color.White;
      this.wordBag1.Dock = System.Windows.Forms.DockStyle.Top;
      this.wordBag1.Font = new System.Drawing.Font("Segoe UI", 11F);
      this.wordBag1.Location = new System.Drawing.Point(0, 44);
      this.wordBag1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
      this.wordBag1.Name = "wordBag1";
      this.wordBag1.ResultSelectedLayerDisplayname = "Wort";
      this.wordBag1.Size = new System.Drawing.Size(780, 36);
      this.wordBag1.TabIndex = 3;
      this.wordBag1.ExecuteButtonClicked += new System.EventHandler(this.wordBag1_ExecuteButtonClicked);
      // 
      // elementHost3
      // 
      this.elementHost3.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.elementHost3.Location = new System.Drawing.Point(0, 355);
      this.elementHost3.Name = "elementHost3";
      this.elementHost3.Size = new System.Drawing.Size(780, 45);
      this.elementHost3.TabIndex = 4;
      this.elementHost3.Text = "elementHost3";
      this.elementHost3.Child = null;
      // 
      // FrequencySegments
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.Controls.Add(this.radSplitContainer1);
      this.Controls.Add(this.elementHost3);
      this.Controls.Add(this.wordBag1);
      this.Controls.Add(this.radCommandBar1);
      this.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
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
