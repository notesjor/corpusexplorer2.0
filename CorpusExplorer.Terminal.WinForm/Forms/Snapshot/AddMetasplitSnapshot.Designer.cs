using CorpusExplorer.Terminal.WinForm.Properties;
using CorpusExplorer.Terminal.WinForm.Controls.WinForm;

namespace CorpusExplorer.Terminal.WinForm.Forms.Snapshot
{
  partial class AddMetasplitSnapshot
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
      Telerik.WinControls.UI.RadListDataItem radListDataItem9 = new Telerik.WinControls.UI.RadListDataItem();
      Telerik.WinControls.UI.RadListDataItem radListDataItem10 = new Telerik.WinControls.UI.RadListDataItem();
      Telerik.WinControls.UI.RadListDataItem radListDataItem11 = new Telerik.WinControls.UI.RadListDataItem();
      Telerik.WinControls.UI.RadListDataItem radListDataItem12 = new Telerik.WinControls.UI.RadListDataItem();
      Telerik.WinControls.UI.RadListDataItem radListDataItem1 = new Telerik.WinControls.UI.RadListDataItem();
      Telerik.WinControls.UI.RadListDataItem radListDataItem2 = new Telerik.WinControls.UI.RadListDataItem();
      Telerik.WinControls.UI.RadListDataItem radListDataItem3 = new Telerik.WinControls.UI.RadListDataItem();
      Telerik.WinControls.UI.RadListDataItem radListDataItem4 = new Telerik.WinControls.UI.RadListDataItem();
      this.header1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.Header();
      this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
      this.drop_metaKey = new Telerik.WinControls.UI.RadDropDownList();
      this.radPageView1 = new Telerik.WinControls.UI.RadPageView();
      this.page_none = new Telerik.WinControls.UI.RadPageViewPage();
      this.page_number = new Telerik.WinControls.UI.RadPageViewPage();
      this.clearPanel1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.ClearPanel();
      this.num_cluster = new Telerik.WinControls.UI.RadSpinEditor();
      this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
      this.page_datetime = new Telerik.WinControls.UI.RadPageViewPage();
      this.drop_dateTime = new Telerik.WinControls.UI.RadDropDownList();
      this.spin_dateTimeClusters = new Telerik.WinControls.UI.RadSpinEditor();
      this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
      this.drop_auto = new Telerik.WinControls.UI.RadDropDownList();
      this.clearPanel2 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.ClearPanel();
      this.panel_clusterFiller = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.ClearPanel();
      this.drop_clusterFiller = new Telerik.WinControls.UI.RadDropDownList();
      this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.drop_metaKey)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).BeginInit();
      this.radPageView1.SuspendLayout();
      this.page_number.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel1)).BeginInit();
      this.clearPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.num_cluster)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
      this.page_datetime.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.drop_dateTime)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.spin_dateTimeClusters)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.drop_auto)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel2)).BeginInit();
      this.clearPanel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.panel_clusterFiller)).BeginInit();
      this.panel_clusterFiller.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.drop_clusterFiller)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // radPanel1
      // 
      this.radPanel1.Location = new System.Drawing.Point(0, 328);
      this.radPanel1.Size = new System.Drawing.Size(488, 38);
      // 
      // header1
      // 
      this.header1.BackColor = System.Drawing.Color.White;
      this.header1.Dock = System.Windows.Forms.DockStyle.Top;
      this.header1.Font = new System.Drawing.Font("Segoe UI", 11F);
      this.header1.HeaderDescribtion = "Mitteles Multisplit können Sie mehrere Schnappschüsse aufeinmal erstellen. Als Ba" +
    "sis dienen die Dokumentmetadaten.";
      this.header1.HeaderHead = "Multisplit Schnappschüsse";
      this.header1.Location = new System.Drawing.Point(0, 0);
      this.header1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.header1.Name = "header1";
      this.header1.Size = new System.Drawing.Size(488, 72);
      this.header1.TabIndex = 1;
      // 
      // radLabel1
      // 
      this.radLabel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.radLabel1.Location = new System.Drawing.Point(0, 72);
      this.radLabel1.Name = "radLabel1";
      this.radLabel1.Size = new System.Drawing.Size(159, 23);
      this.radLabel1.TabIndex = 2;
      this.radLabel1.Text = "Dokument-Metadaten:";
      // 
      // drop_metaKey
      // 
      this.drop_metaKey.Dock = System.Windows.Forms.DockStyle.Top;
      this.drop_metaKey.Location = new System.Drawing.Point(0, 95);
      this.drop_metaKey.Name = "drop_metaKey";
      this.drop_metaKey.NullText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.BitteAuswählen;
      this.drop_metaKey.Size = new System.Drawing.Size(488, 32);
      this.drop_metaKey.TabIndex = 3;
      // 
      // radPageView1
      // 
      this.radPageView1.Controls.Add(this.page_none);
      this.radPageView1.Controls.Add(this.page_number);
      this.radPageView1.Controls.Add(this.page_datetime);
      this.radPageView1.Dock = System.Windows.Forms.DockStyle.Top;
      this.radPageView1.Location = new System.Drawing.Point(0, 65);
      this.radPageView1.Name = "radPageView1";
      this.radPageView1.SelectedPage = this.page_number;
      this.radPageView1.Size = new System.Drawing.Size(488, 70);
      this.radPageView1.TabIndex = 5;
      // 
      // page_none
      // 
      this.page_none.ItemSize = new System.Drawing.SizeF(55F, 29F);
      this.page_none.Location = new System.Drawing.Point(5, 40);
      this.page_none.Name = "page_none";
      this.page_none.Size = new System.Drawing.Size(470, 51);
      this.page_none.Text = "NONE";
      // 
      // page_number
      // 
      this.page_number.Controls.Add(this.clearPanel1);
      this.page_number.ItemSize = new System.Drawing.SizeF(98F, 29F);
      this.page_number.Location = new System.Drawing.Point(5, 40);
      this.page_number.Name = "page_number";
      this.page_number.Size = new System.Drawing.Size(478, 25);
      this.page_number.Text = "INT/DOUBLE";
      // 
      // clearPanel1
      // 
      this.clearPanel1.Controls.Add(this.num_cluster);
      this.clearPanel1.Controls.Add(this.radLabel2);
      this.clearPanel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.clearPanel1.Location = new System.Drawing.Point(0, 0);
      this.clearPanel1.Name = "clearPanel1";
      this.clearPanel1.Size = new System.Drawing.Size(478, 32);
      this.clearPanel1.TabIndex = 0;
      // 
      // num_cluster
      // 
      this.num_cluster.Dock = System.Windows.Forms.DockStyle.Fill;
      this.num_cluster.Location = new System.Drawing.Point(240, 0);
      this.num_cluster.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
      this.num_cluster.MinimumSize = new System.Drawing.Size(100, 0);
      this.num_cluster.Name = "num_cluster";
      this.num_cluster.NullableValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
      // 
      // 
      // 
      this.num_cluster.RootElement.MinSize = new System.Drawing.Size(100, 0);
      this.num_cluster.Size = new System.Drawing.Size(238, 32);
      this.num_cluster.TabIndex = 4;
      this.num_cluster.TabStop = false;
      this.num_cluster.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.num_cluster.ValueChanged += new System.EventHandler(this.num_cluster_ValueChanged);
      // 
      // radLabel2
      // 
      this.radLabel2.AutoSize = false;
      this.radLabel2.Dock = System.Windows.Forms.DockStyle.Left;
      this.radLabel2.Location = new System.Drawing.Point(0, 0);
      this.radLabel2.Name = "radLabel2";
      this.radLabel2.Padding = new System.Windows.Forms.Padding(0, 4, 3, 0);
      this.radLabel2.Size = new System.Drawing.Size(240, 32);
      this.radLabel2.TabIndex = 0;
      this.radLabel2.Text = "Wieviele Custer benötigen Sie:";
      this.radLabel2.TextAlignment = System.Drawing.ContentAlignment.TopRight;
      // 
      // page_datetime
      // 
      this.page_datetime.Controls.Add(this.drop_dateTime);
      this.page_datetime.Controls.Add(this.spin_dateTimeClusters);
      this.page_datetime.ItemSize = new System.Drawing.SizeF(82F, 29F);
      this.page_datetime.Location = new System.Drawing.Point(5, 40);
      this.page_datetime.Name = "page_datetime";
      this.page_datetime.Size = new System.Drawing.Size(478, 25);
      this.page_datetime.Text = "DATETIME";
      // 
      // drop_dateTime
      // 
      this.drop_dateTime.Dock = System.Windows.Forms.DockStyle.Fill;
      this.drop_dateTime.Location = new System.Drawing.Point(0, 0);
      this.drop_dateTime.Name = "drop_dateTime";
      this.drop_dateTime.NullText = "Bitte auswählen...";
      this.drop_dateTime.Size = new System.Drawing.Size(378, 25);
      this.drop_dateTime.TabIndex = 0;
      this.drop_dateTime.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.drop_dateTime_SelectedIndexChanged);
      // 
      // spin_dateTimeClusters
      // 
      this.spin_dateTimeClusters.Dock = System.Windows.Forms.DockStyle.Right;
      this.spin_dateTimeClusters.Location = new System.Drawing.Point(378, 0);
      this.spin_dateTimeClusters.MinimumSize = new System.Drawing.Size(100, 0);
      this.spin_dateTimeClusters.Name = "spin_dateTimeClusters";
      this.spin_dateTimeClusters.NullableValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
      // 
      // 
      // 
      this.spin_dateTimeClusters.RootElement.MinSize = new System.Drawing.Size(100, 0);
      this.spin_dateTimeClusters.Size = new System.Drawing.Size(100, 25);
      this.spin_dateTimeClusters.TabIndex = 1;
      this.spin_dateTimeClusters.TabStop = false;
      this.spin_dateTimeClusters.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.spin_dateTimeClusters.ValueChanged += new System.EventHandler(this.spin_dateTimeClusters_ValueChanged);
      // 
      // radLabel3
      // 
      this.radLabel3.AutoSize = false;
      this.radLabel3.Dock = System.Windows.Forms.DockStyle.Top;
      this.radLabel3.Location = new System.Drawing.Point(0, 0);
      this.radLabel3.Name = "radLabel3";
      this.radLabel3.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
      this.radLabel3.Size = new System.Drawing.Size(488, 33);
      this.radLabel3.TabIndex = 3;
      this.radLabel3.Text = "Es handelt sich dabei um eine:";
      // 
      // drop_auto
      // 
      this.drop_auto.Dock = System.Windows.Forms.DockStyle.Top;
      radListDataItem9.Text = "Text-Metaangabe";
      radListDataItem10.Text = "Ganzzahl-Metaangabe";
      radListDataItem11.Text = "Kommazahl-Metaangabe";
      radListDataItem12.Text = "Datums-Metaangabe";
      this.drop_auto.Items.Add(radListDataItem9);
      this.drop_auto.Items.Add(radListDataItem10);
      this.drop_auto.Items.Add(radListDataItem11);
      this.drop_auto.Items.Add(radListDataItem12);
      this.drop_auto.Location = new System.Drawing.Point(0, 33);
      this.drop_auto.Name = "drop_auto";
      this.drop_auto.NullText = "Bitte auswählen...";
      this.drop_auto.Size = new System.Drawing.Size(488, 32);
      this.drop_auto.TabIndex = 2;
      this.drop_auto.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.drop_auto_SelectedIndexChanged);
      // 
      // clearPanel2
      // 
      this.clearPanel2.Controls.Add(this.panel_clusterFiller);
      this.clearPanel2.Controls.Add(this.radPageView1);
      this.clearPanel2.Controls.Add(this.drop_auto);
      this.clearPanel2.Controls.Add(this.radLabel3);
      this.clearPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.clearPanel2.Location = new System.Drawing.Point(0, 127);
      this.clearPanel2.Name = "clearPanel2";
      this.clearPanel2.Size = new System.Drawing.Size(488, 239);
      this.clearPanel2.TabIndex = 5;
      // 
      // panel_clusterFiller
      // 
      this.panel_clusterFiller.Controls.Add(this.drop_clusterFiller);
      this.panel_clusterFiller.Controls.Add(this.radLabel4);
      this.panel_clusterFiller.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel_clusterFiller.Location = new System.Drawing.Point(0, 135);
      this.panel_clusterFiller.Name = "panel_clusterFiller";
      this.panel_clusterFiller.Size = new System.Drawing.Size(488, 74);
      this.panel_clusterFiller.TabIndex = 6;
      this.panel_clusterFiller.Visible = false;
      // 
      // drop_clusterFiller
      // 
      this.drop_clusterFiller.Dock = System.Windows.Forms.DockStyle.Fill;
      radListDataItem1.Text = "Anhand der Werte (Standard)";
      radListDataItem2.Text = "Gleiche Anzahl an Dokumenten";
      radListDataItem3.Text = "Ähnlicher Umfang - Sätze (näherungsweise)";
      radListDataItem4.Text = "Ähnlicher Umfang - Token (näherungsweise)";
      this.drop_clusterFiller.Items.Add(radListDataItem1);
      this.drop_clusterFiller.Items.Add(radListDataItem2);
      this.drop_clusterFiller.Items.Add(radListDataItem3);
      this.drop_clusterFiller.Items.Add(radListDataItem4);
      this.drop_clusterFiller.Location = new System.Drawing.Point(0, 33);
      this.drop_clusterFiller.Name = "drop_clusterFiller";
      this.drop_clusterFiller.NullText = "Bitte auswählen...";
      this.drop_clusterFiller.Size = new System.Drawing.Size(488, 41);
      this.drop_clusterFiller.TabIndex = 5;
      // 
      // radLabel4
      // 
      this.radLabel4.AutoSize = false;
      this.radLabel4.Dock = System.Windows.Forms.DockStyle.Top;
      this.radLabel4.Location = new System.Drawing.Point(0, 0);
      this.radLabel4.Name = "radLabel4";
      this.radLabel4.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
      this.radLabel4.Size = new System.Drawing.Size(488, 33);
      this.radLabel4.TabIndex = 4;
      this.radLabel4.Text = "Methode zur Cluster-Befüllung:";
      // 
      // AddMetasplitSnapshot
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(488, 366);
      this.Controls.Add(this.clearPanel2);
      this.Controls.Add(this.drop_metaKey);
      this.Controls.Add(this.radLabel1);
      this.Controls.Add(this.header1);
      this.DisplayAbort = true;
      this.Name = "AddMetasplitSnapshot";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.Text = "Multisplit Schnappschüsse erzeugen";
      this.ButtonOkClick += new System.EventHandler(this.AddRandomSnapshot_ButtonOkClick);
      this.Controls.SetChildIndex(this.header1, 0);
      this.Controls.SetChildIndex(this.radLabel1, 0);
      this.Controls.SetChildIndex(this.drop_metaKey, 0);
      this.Controls.SetChildIndex(this.clearPanel2, 0);
      this.Controls.SetChildIndex(this.radPanel1, 0);
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.drop_metaKey)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).EndInit();
      this.radPageView1.ResumeLayout(false);
      this.page_number.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel1)).EndInit();
      this.clearPanel1.ResumeLayout(false);
      this.clearPanel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.num_cluster)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
      this.page_datetime.ResumeLayout(false);
      this.page_datetime.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.drop_dateTime)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.spin_dateTimeClusters)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.drop_auto)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel2)).EndInit();
      this.clearPanel2.ResumeLayout(false);
      this.clearPanel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.panel_clusterFiller)).EndInit();
      this.panel_clusterFiller.ResumeLayout(false);
      this.panel_clusterFiller.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.drop_clusterFiller)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Header header1;
    private Telerik.WinControls.UI.RadLabel radLabel1;
    private Telerik.WinControls.UI.RadDropDownList drop_metaKey;
    private Telerik.WinControls.UI.RadLabel radLabel2;
    private Telerik.WinControls.UI.RadDropDownList drop_auto;
    private Telerik.WinControls.UI.RadLabel radLabel3;
    private Telerik.WinControls.UI.RadSpinEditor num_cluster;
    private Telerik.WinControls.UI.RadPageView radPageView1;
    private Telerik.WinControls.UI.RadPageViewPage page_none;
    private Telerik.WinControls.UI.RadPageViewPage page_number;
    private ClearPanel clearPanel1;
    private Telerik.WinControls.UI.RadPageViewPage page_datetime;
    private Telerik.WinControls.UI.RadDropDownList drop_dateTime;
    private Telerik.WinControls.UI.RadSpinEditor spin_dateTimeClusters;
    private ClearPanel clearPanel2;
    private ClearPanel panel_clusterFiller;
    private Telerik.WinControls.UI.RadDropDownList drop_clusterFiller;
    private Telerik.WinControls.UI.RadLabel radLabel4;
  }
}