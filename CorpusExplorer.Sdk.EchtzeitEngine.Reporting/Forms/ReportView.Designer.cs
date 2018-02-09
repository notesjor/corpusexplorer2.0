namespace CorpusExplorer.Sdk.EchtzeitEngine.Reporting.Forms
{
  partial class ReportView
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportView));
      this.telerikMetroTouchTheme1 = new Telerik.WinControls.Themes.TelerikMetroTouchTheme();
      this.reportViewer1 = new Telerik.ReportViewer.WinForms.ReportViewer();
      this.radTreeView1 = new Telerik.WinControls.UI.RadTreeView();
      this.radSplitContainer1 = new Telerik.WinControls.UI.RadSplitContainer();
      this.splitPanel1 = new Telerik.WinControls.UI.SplitPanel();
      this.splitPanel2 = new Telerik.WinControls.UI.SplitPanel();
      this.radDropDownButton1 = new Telerik.WinControls.UI.RadDropDownButton();
      this.btn_export_pdf = new Telerik.WinControls.UI.RadMenuItem();
      this.btn_export_excel = new Telerik.WinControls.UI.RadMenuItem();
      this.btn_export_word = new Telerik.WinControls.UI.RadMenuItem();
      this.btn_export_csv = new Telerik.WinControls.UI.RadMenuItem();
      this.btn_export_html = new Telerik.WinControls.UI.RadMenuItem();
      this.btn_export_rtf = new Telerik.WinControls.UI.RadMenuItem();
      ((System.ComponentModel.ISupportInitialize)(this.radTreeView1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).BeginInit();
      this.radSplitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).BeginInit();
      this.splitPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).BeginInit();
      this.splitPanel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radDropDownButton1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // reportViewer1
      // 
      this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.reportViewer1.Location = new System.Drawing.Point(0, 0);
      this.reportViewer1.Name = "reportViewer1";
      this.reportViewer1.Size = new System.Drawing.Size(499, 395);
      this.reportViewer1.TabIndex = 0;
      // 
      // radTreeView1
      // 
      this.radTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radTreeView1.ItemHeight = 40;
      this.radTreeView1.Location = new System.Drawing.Point(0, 27);
      this.radTreeView1.Name = "radTreeView1";
      this.radTreeView1.Size = new System.Drawing.Size(259, 368);
      this.radTreeView1.TabIndex = 1;
      this.radTreeView1.Text = "radTreeView1";
      this.radTreeView1.ThemeName = "TelerikMetroTouch";
      this.radTreeView1.TreeIndent = 40;
      this.radTreeView1.SelectedNodeChanged += new Telerik.WinControls.UI.RadTreeView.RadTreeViewEventHandler(this.radTreeView1_SelectedNodeChanged);
      // 
      // radSplitContainer1
      // 
      this.radSplitContainer1.Controls.Add(this.splitPanel1);
      this.radSplitContainer1.Controls.Add(this.splitPanel2);
      this.radSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radSplitContainer1.Location = new System.Drawing.Point(0, 0);
      this.radSplitContainer1.Name = "radSplitContainer1";
      // 
      // 
      // 
      this.radSplitContainer1.RootElement.MinSize = new System.Drawing.Size(0, 0);
      this.radSplitContainer1.Size = new System.Drawing.Size(762, 395);
      this.radSplitContainer1.TabIndex = 2;
      this.radSplitContainer1.TabStop = false;
      this.radSplitContainer1.Text = "radSplitContainer1";
      this.radSplitContainer1.ThemeName = "TelerikMetroTouch";
      // 
      // splitPanel1
      // 
      this.splitPanel1.Controls.Add(this.radTreeView1);
      this.splitPanel1.Controls.Add(this.radDropDownButton1);
      this.splitPanel1.Location = new System.Drawing.Point(0, 0);
      this.splitPanel1.Name = "splitPanel1";
      // 
      // 
      // 
      this.splitPanel1.RootElement.MinSize = new System.Drawing.Size(0, 0);
      this.splitPanel1.Size = new System.Drawing.Size(259, 395);
      this.splitPanel1.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(-0.1583113F, 0F);
      this.splitPanel1.SizeInfo.SplitterCorrection = new System.Drawing.Size(-103, 0);
      this.splitPanel1.TabIndex = 0;
      this.splitPanel1.TabStop = false;
      this.splitPanel1.Text = "splitPanel1";
      this.splitPanel1.ThemeName = "TelerikMetroTouch";
      // 
      // splitPanel2
      // 
      this.splitPanel2.Controls.Add(this.reportViewer1);
      this.splitPanel2.Location = new System.Drawing.Point(263, 0);
      this.splitPanel2.Name = "splitPanel2";
      // 
      // 
      // 
      this.splitPanel2.RootElement.MinSize = new System.Drawing.Size(0, 0);
      this.splitPanel2.Size = new System.Drawing.Size(499, 395);
      this.splitPanel2.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(0.1583114F, 0F);
      this.splitPanel2.SizeInfo.SplitterCorrection = new System.Drawing.Size(103, 0);
      this.splitPanel2.TabIndex = 1;
      this.splitPanel2.TabStop = false;
      this.splitPanel2.Text = "splitPanel2";
      this.splitPanel2.ThemeName = "TelerikMetroTouch";
      // 
      // radDropDownButton1
      // 
      this.radDropDownButton1.Dock = System.Windows.Forms.DockStyle.Top;
      this.radDropDownButton1.Image = global::CorpusExplorer.Sdk.EchtzeitEngine.Reporting.Properties.Resources.save;
      this.radDropDownButton1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.btn_export_pdf,
            this.btn_export_excel,
            this.btn_export_csv,
            this.btn_export_word,
            this.btn_export_rtf,
            this.btn_export_html});
      this.radDropDownButton1.Location = new System.Drawing.Point(0, 0);
      this.radDropDownButton1.Name = "radDropDownButton1";
      this.radDropDownButton1.Size = new System.Drawing.Size(259, 27);
      this.radDropDownButton1.TabIndex = 2;
      this.radDropDownButton1.Text = "Bericht komplett speichern...";
      this.radDropDownButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      // 
      // btn_export_pdf
      // 
      this.btn_export_pdf.Image = global::CorpusExplorer.Sdk.EchtzeitEngine.Reporting.Properties.Resources.export_text;
      this.btn_export_pdf.Name = "btn_export_pdf";
      this.btn_export_pdf.Text = "PDF";
      // 
      // btn_export_excel
      // 
      this.btn_export_excel.Image = global::CorpusExplorer.Sdk.EchtzeitEngine.Reporting.Properties.Resources.export_text;
      this.btn_export_excel.Name = "btn_export_excel";
      this.btn_export_excel.Text = "XLS(X)";
      // 
      // btn_export_word
      // 
      this.btn_export_word.Image = global::CorpusExplorer.Sdk.EchtzeitEngine.Reporting.Properties.Resources.export_text;
      this.btn_export_word.Name = "btn_export_word";
      this.btn_export_word.Text = "DOC(X)";
      // 
      // btn_export_csv
      // 
      this.btn_export_csv.Image = global::CorpusExplorer.Sdk.EchtzeitEngine.Reporting.Properties.Resources.export_text;
      this.btn_export_csv.Name = "btn_export_csv";
      this.btn_export_csv.Text = "CSV";
      // 
      // btn_export_html
      // 
      this.btn_export_html.Image = global::CorpusExplorer.Sdk.EchtzeitEngine.Reporting.Properties.Resources.export_text;
      this.btn_export_html.Name = "btn_export_html";
      this.btn_export_html.Text = "HTML";
      // 
      // btn_export_rtf
      // 
      this.btn_export_rtf.Image = global::CorpusExplorer.Sdk.EchtzeitEngine.Reporting.Properties.Resources.export_text;
      this.btn_export_rtf.Name = "btn_export_rtf";
      this.btn_export_rtf.Text = "RTF";
      // 
      // ReportView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(762, 395);
      this.Controls.Add(this.radSplitContainer1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "ReportView";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "CorpusExplorer v2.0 - PaperLinguist";
      this.ThemeName = "TelerikMetroTouch";
      ((System.ComponentModel.ISupportInitialize)(this.radTreeView1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).EndInit();
      this.radSplitContainer1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).EndInit();
      this.splitPanel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).EndInit();
      this.splitPanel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radDropDownButton1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private Telerik.WinControls.Themes.TelerikMetroTouchTheme telerikMetroTouchTheme1;
    private Telerik.ReportViewer.WinForms.ReportViewer reportViewer1;
    private Telerik.WinControls.UI.RadTreeView radTreeView1;
    private Telerik.WinControls.UI.RadSplitContainer radSplitContainer1;
    private Telerik.WinControls.UI.SplitPanel splitPanel1;
    private Telerik.WinControls.UI.SplitPanel splitPanel2;
    private Telerik.WinControls.UI.RadDropDownButton radDropDownButton1;
    private Telerik.WinControls.UI.RadMenuItem btn_export_pdf;
    private Telerik.WinControls.UI.RadMenuItem btn_export_excel;
    private Telerik.WinControls.UI.RadMenuItem btn_export_csv;
    private Telerik.WinControls.UI.RadMenuItem btn_export_word;
    private Telerik.WinControls.UI.RadMenuItem btn_export_rtf;
    private Telerik.WinControls.UI.RadMenuItem btn_export_html;
  }
}