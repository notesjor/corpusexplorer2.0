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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddMetasplitSnapshot));
      Telerik.WinControls.UI.RadListDataItem radListDataItem1 = new Telerik.WinControls.UI.RadListDataItem();
      Telerik.WinControls.UI.RadListDataItem radListDataItem2 = new Telerik.WinControls.UI.RadListDataItem();
      Telerik.WinControls.UI.RadListDataItem radListDataItem3 = new Telerik.WinControls.UI.RadListDataItem();
      Telerik.WinControls.UI.RadListDataItem radListDataItem4 = new Telerik.WinControls.UI.RadListDataItem();
      Telerik.WinControls.UI.RadListDataItem radListDataItem5 = new Telerik.WinControls.UI.RadListDataItem();
      Telerik.WinControls.UI.RadListDataItem radListDataItem6 = new Telerik.WinControls.UI.RadListDataItem();
      Telerik.WinControls.UI.RadListDataItem radListDataItem7 = new Telerik.WinControls.UI.RadListDataItem();
      Telerik.WinControls.UI.RadListDataItem radListDataItem8 = new Telerik.WinControls.UI.RadListDataItem();
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
      this.clearPanel3 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.ClearPanel();
      this.num_window = new Telerik.WinControls.UI.RadSpinEditor();
      this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
      this.infoButton1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.InfoButton();
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
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel3)).BeginInit();
      this.clearPanel3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.num_window)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.infoButton1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.panel_clusterFiller)).BeginInit();
      this.panel_clusterFiller.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.drop_clusterFiller)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // radPanel1
      // 
      resources.ApplyResources(this.radPanel1, "radPanel1");
      // 
      // header1
      // 
      this.header1.BackColor = System.Drawing.Color.White;
      resources.ApplyResources(this.header1, "header1");
      this.header1.HeaderDescription = "Mitteles Multisplit können Sie mehrere Schnappschüsse aufeinmal erstellen. Als Ba" +
    "sis dienen die Dokumentmetadaten.";
      this.header1.HeaderHead = "Multisplit Schnappschüsse";
      this.header1.Name = "header1";
      // 
      // radLabel1
      // 
      resources.ApplyResources(this.radLabel1, "radLabel1");
      this.radLabel1.Name = "radLabel1";
      // 
      // drop_metaKey
      // 
      resources.ApplyResources(this.drop_metaKey, "drop_metaKey");
      this.drop_metaKey.Name = "drop_metaKey";
      this.drop_metaKey.NullText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.BitteAuswählen;
      // 
      // radPageView1
      // 
      this.radPageView1.Controls.Add(this.page_none);
      this.radPageView1.Controls.Add(this.page_number);
      this.radPageView1.Controls.Add(this.page_datetime);
      resources.ApplyResources(this.radPageView1, "radPageView1");
      this.radPageView1.Name = "radPageView1";
      this.radPageView1.SelectedPage = this.page_number;
      // 
      // page_none
      // 
      this.page_none.ItemSize = new System.Drawing.SizeF(55F, 29F);
      resources.ApplyResources(this.page_none, "page_none");
      this.page_none.Name = "page_none";
      // 
      // page_number
      // 
      this.page_number.Controls.Add(this.clearPanel1);
      this.page_number.ItemSize = new System.Drawing.SizeF(98F, 29F);
      resources.ApplyResources(this.page_number, "page_number");
      this.page_number.Name = "page_number";
      // 
      // clearPanel1
      // 
      this.clearPanel1.Controls.Add(this.num_cluster);
      this.clearPanel1.Controls.Add(this.radLabel2);
      resources.ApplyResources(this.clearPanel1, "clearPanel1");
      this.clearPanel1.Name = "clearPanel1";
      // 
      // num_cluster
      // 
      resources.ApplyResources(this.num_cluster, "num_cluster");
      this.num_cluster.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
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
      resources.ApplyResources(this.radLabel2, "radLabel2");
      this.radLabel2.Name = "radLabel2";
      // 
      // page_datetime
      // 
      this.page_datetime.Controls.Add(this.drop_dateTime);
      this.page_datetime.Controls.Add(this.spin_dateTimeClusters);
      this.page_datetime.ItemSize = new System.Drawing.SizeF(82F, 29F);
      resources.ApplyResources(this.page_datetime, "page_datetime");
      this.page_datetime.Name = "page_datetime";
      // 
      // drop_dateTime
      // 
      resources.ApplyResources(this.drop_dateTime, "drop_dateTime");
      this.drop_dateTime.Name = "drop_dateTime";
      this.drop_dateTime.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.drop_dateTime_SelectedIndexChanged);
      // 
      // spin_dateTimeClusters
      // 
      resources.ApplyResources(this.spin_dateTimeClusters, "spin_dateTimeClusters");
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
      resources.ApplyResources(this.radLabel3, "radLabel3");
      this.radLabel3.Name = "radLabel3";
      // 
      // drop_auto
      // 
      resources.ApplyResources(this.drop_auto, "drop_auto");
      radListDataItem1.Text = "Text-Metaangabe";
      radListDataItem2.Text = "Ganzzahl-Metaangabe";
      radListDataItem3.Text = "Kommazahl-Metaangabe";
      radListDataItem4.Text = "Datums-Metaangabe";
      this.drop_auto.Items.Add(radListDataItem1);
      this.drop_auto.Items.Add(radListDataItem2);
      this.drop_auto.Items.Add(radListDataItem3);
      this.drop_auto.Items.Add(radListDataItem4);
      this.drop_auto.Name = "drop_auto";
      this.drop_auto.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.drop_auto_SelectedIndexChanged);
      // 
      // clearPanel2
      // 
      this.clearPanel2.Controls.Add(this.clearPanel3);
      this.clearPanel2.Controls.Add(this.panel_clusterFiller);
      this.clearPanel2.Controls.Add(this.radPageView1);
      this.clearPanel2.Controls.Add(this.drop_auto);
      this.clearPanel2.Controls.Add(this.radLabel3);
      resources.ApplyResources(this.clearPanel2, "clearPanel2");
      this.clearPanel2.Name = "clearPanel2";
      // 
      // clearPanel3
      // 
      this.clearPanel3.Controls.Add(this.num_window);
      this.clearPanel3.Controls.Add(this.radLabel5);
      this.clearPanel3.Controls.Add(this.infoButton1);
      resources.ApplyResources(this.clearPanel3, "clearPanel3");
      this.clearPanel3.Name = "clearPanel3";
      // 
      // num_window
      // 
      resources.ApplyResources(this.num_window, "num_window");
      this.num_window.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
      this.num_window.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.num_window.Name = "num_window";
      this.num_window.NullableValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
      // 
      // 
      // 
      this.num_window.RootElement.MinSize = new System.Drawing.Size(100, 0);
      this.num_window.TabStop = false;
      this.num_window.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      // 
      // radLabel5
      // 
      resources.ApplyResources(this.radLabel5, "radLabel5");
      this.radLabel5.Name = "radLabel5";
      // 
      // infoButton1
      // 
      resources.ApplyResources(this.infoButton1, "infoButton1");
      this.infoButton1.InfoDescription = null;
      this.infoButton1.InfoHeader = null;
      this.infoButton1.InfoImage = null;
      this.infoButton1.Name = "infoButton1";
      // 
      // 
      // 
      this.infoButton1.RootElement.MaxSize = new System.Drawing.Size(33, 33);
      this.infoButton1.RootElement.MinSize = new System.Drawing.Size(33, 33);
      this.infoButton1.Click += new System.EventHandler(this.infoButton1_Click);
      // 
      // panel_clusterFiller
      // 
      this.panel_clusterFiller.Controls.Add(this.drop_clusterFiller);
      this.panel_clusterFiller.Controls.Add(this.radLabel4);
      resources.ApplyResources(this.panel_clusterFiller, "panel_clusterFiller");
      this.panel_clusterFiller.Name = "panel_clusterFiller";
      // 
      // drop_clusterFiller
      // 
      resources.ApplyResources(this.drop_clusterFiller, "drop_clusterFiller");
      radListDataItem5.Text = "Anhand der Werte (Standard)";
      radListDataItem6.Text = "Gleiche Anzahl an Dokumenten";
      radListDataItem7.Text = "Ähnlicher Umfang - Sätze (näherungsweise)";
      radListDataItem8.Text = "Ähnlicher Umfang - Token (näherungsweise)";
      this.drop_clusterFiller.Items.Add(radListDataItem5);
      this.drop_clusterFiller.Items.Add(radListDataItem6);
      this.drop_clusterFiller.Items.Add(radListDataItem7);
      this.drop_clusterFiller.Items.Add(radListDataItem8);
      this.drop_clusterFiller.Name = "drop_clusterFiller";
      // 
      // radLabel4
      // 
      resources.ApplyResources(this.radLabel4, "radLabel4");
      this.radLabel4.Name = "radLabel4";
      // 
      // AddMetasplitSnapshot
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      resources.ApplyResources(this, "$this");
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
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel3)).EndInit();
      this.clearPanel3.ResumeLayout(false);
      this.clearPanel3.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.num_window)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.infoButton1)).EndInit();
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
    private ClearPanel clearPanel3;
    private Telerik.WinControls.UI.RadSpinEditor num_window;
    private Telerik.WinControls.UI.RadLabel radLabel5;
    private InfoButton infoButton1;
  }
}