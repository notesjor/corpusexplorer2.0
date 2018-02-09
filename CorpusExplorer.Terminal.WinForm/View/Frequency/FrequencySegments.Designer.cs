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
      this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
      this.commandBarLabel1 = new Telerik.WinControls.UI.CommandBarLabel();
      this.txt_query = new Telerik.WinControls.UI.CommandBarTextBox();
      this.commandBarLabel2 = new Telerik.WinControls.UI.CommandBarLabel();
      this.combo_layer = new Telerik.WinControls.UI.CommandBarDropDownList();
      this.btn_execute = new Telerik.WinControls.UI.CommandBarButton();
      this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
      this.radSplitContainer1 = new Telerik.WinControls.UI.RadSplitContainer();
      this.splitPanel1 = new Telerik.WinControls.UI.SplitPanel();
      this.header1 = new Header();
      this.splitPanel2 = new Telerik.WinControls.UI.SplitPanel();
      this.elementHost2 = new System.Windows.Forms.Integration.ElementHost();
      this.header2 = new Header();
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
      this.radCommandBar1.Size = new System.Drawing.Size(780, 69);
      this.radCommandBar1.TabIndex = 0;
      this.radCommandBar1.Text = "radCommandBar1";
      // 
      // commandBarRowElement1
      // 
      this.commandBarRowElement1.MinSize = new System.Drawing.Size(25, 25);
      this.commandBarRowElement1.Strips.AddRange(new Telerik.WinControls.UI.CommandBarStripElement[] {
            this.commandBarStripElement1});
      // 
      // commandBarStripElement1
      // 
      this.commandBarStripElement1.DisplayName = "commandBarStripElement1";
      this.commandBarStripElement1.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.commandBarLabel1,
            this.txt_query,
            this.commandBarLabel2,
            this.combo_layer,
            this.btn_execute});
      this.commandBarStripElement1.Name = "commandBarStripElement1";
      // 
      // commandBarLabel1
      // 
      this.commandBarLabel1.AccessibleDescription = Resources.Suche;
      this.commandBarLabel1.AccessibleName = Resources.Suche;
      this.commandBarLabel1.DisplayName = "commandBarLabel1";
      this.commandBarLabel1.Name = "commandBarLabel1";
      this.commandBarLabel1.Text = Resources.Suche;
      // 
      // txt_query
      // 
      this.txt_query.DisplayName = "commandBarTextBox1";
      this.txt_query.MinSize = new System.Drawing.Size(200, 0);
      this.txt_query.Name = "txt_query";
      this.txt_query.Text = "";
      // 
      // commandBarLabel2
      // 
      this.commandBarLabel2.AccessibleDescription = Resources.LayerDP;
      this.commandBarLabel2.AccessibleName = Resources.LayerDP;
      this.commandBarLabel2.DisplayName = "commandBarLabel2";
      this.commandBarLabel2.Name = "commandBarLabel2";
      this.commandBarLabel2.Text = Resources.LayerDP;
      // 
      // combo_layer
      // 
      this.combo_layer.DisplayName = "commandBarDropDownList1";
      this.combo_layer.DropDownAnimationEnabled = true;
      this.combo_layer.MaxDropDownItems = 0;
      this.combo_layer.MinSize = new System.Drawing.Size(200, 22);
      this.combo_layer.Name = "combo_layer";
      this.combo_layer.Text = "";
      // 
      // btn_execute
      // 
      this.btn_execute.AccessibleDescription = Resources.Starten;
      this.btn_execute.AccessibleName = Resources.Starten;
      this.btn_execute.DisplayName = "commandBarButton1";
      this.btn_execute.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.button_circle_right;
      this.btn_execute.Name = "btn_execute";
      this.btn_execute.Text = Resources.Starten;
      this.btn_execute.ToolTipText = Resources.AnalyseAusführen;
      this.btn_execute.Click += new System.EventHandler(this.btn_execute_Click);
      // 
      // elementHost1
      // 
      this.elementHost1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.elementHost1.Location = new System.Drawing.Point(0, 58);
      this.elementHost1.Name = "elementHost1";
      this.elementHost1.Size = new System.Drawing.Size(780, 106);
      this.elementHost1.TabIndex = 1;
      this.elementHost1.Text = "elementHost1";
      this.elementHost1.Child = null;
      // 
      // radSplitContainer1
      // 
      this.radSplitContainer1.Controls.Add(this.splitPanel1);
      this.radSplitContainer1.Controls.Add(this.splitPanel2);
      this.radSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radSplitContainer1.Location = new System.Drawing.Point(0, 69);
      this.radSplitContainer1.Name = "radSplitContainer1";
      this.radSplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // 
      // 
      this.radSplitContainer1.RootElement.MinSize = new System.Drawing.Size(0, 0);
      this.radSplitContainer1.Size = new System.Drawing.Size(780, 331);
      this.radSplitContainer1.TabIndex = 2;
      this.radSplitContainer1.TabStop = false;
      this.radSplitContainer1.Text = "radSplitContainer1";
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
      this.splitPanel1.Size = new System.Drawing.Size(780, 164);
      this.splitPanel1.TabIndex = 0;
      this.splitPanel1.TabStop = false;
      this.splitPanel1.Text = "splitPanel1";
      // 
      // header1
      // 
      this.header1.BackColor = System.Drawing.Color.White;
      this.header1.Dock = System.Windows.Forms.DockStyle.Top;
      this.header1.Font = new System.Drawing.Font("Segoe UI", 11F);
      this.header1.HeaderDescribtion = Resources.FrequenzverteilungAufEinNormiertesDokument;
      this.header1.HeaderHead = Resources.Dokumentverteilung;
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
      this.splitPanel2.Location = new System.Drawing.Point(0, 168);
      this.splitPanel2.Name = "splitPanel2";
      // 
      // 
      // 
      this.splitPanel2.RootElement.MinSize = new System.Drawing.Size(0, 0);
      this.splitPanel2.Size = new System.Drawing.Size(780, 163);
      this.splitPanel2.TabIndex = 1;
      this.splitPanel2.TabStop = false;
      this.splitPanel2.Text = "splitPanel2";
      // 
      // elementHost2
      // 
      this.elementHost2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.elementHost2.Location = new System.Drawing.Point(0, 58);
      this.elementHost2.Name = "elementHost2";
      this.elementHost2.Size = new System.Drawing.Size(780, 105);
      this.elementHost2.TabIndex = 0;
      this.elementHost2.Text = "elementHost2";
      this.elementHost2.Child = null;
      // 
      // header2
      // 
      this.header2.BackColor = System.Drawing.Color.White;
      this.header2.Dock = System.Windows.Forms.DockStyle.Top;
      this.header2.Font = new System.Drawing.Font("Segoe UI", 11F);
      this.header2.HeaderDescribtion = Resources.FrequenzverteilungAufEinenNormiertenSatz;
      this.header2.HeaderHead = Resources.Satzverteilung;
      this.header2.Location = new System.Drawing.Point(0, 0);
      this.header2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.header2.Name = "header2";
      this.header2.Size = new System.Drawing.Size(780, 58);
      this.header2.TabIndex = 3;
      // 
      // FrequencySegments
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.radSplitContainer1);
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
        private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement1;
        private Telerik.WinControls.UI.CommandBarLabel commandBarLabel1;
        private Telerik.WinControls.UI.CommandBarTextBox txt_query;
        private Telerik.WinControls.UI.CommandBarLabel commandBarLabel2;
        private Telerik.WinControls.UI.CommandBarDropDownList combo_layer;
        private Telerik.WinControls.UI.CommandBarButton btn_execute;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private Telerik.WinControls.UI.RadSplitContainer radSplitContainer1;
        private Telerik.WinControls.UI.SplitPanel splitPanel1;
        private Header header1;
        private Telerik.WinControls.UI.SplitPanel splitPanel2;
        private System.Windows.Forms.Integration.ElementHost elementHost2;
        private Header header2;
    }
}
