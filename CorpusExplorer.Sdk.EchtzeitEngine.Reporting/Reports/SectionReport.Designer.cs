namespace CorpusExplorer.Sdk.EchtzeitEngine.Reporting.Reports
{
  partial class SectionReport
  {
    #region Component Designer generated code
    /// <summary>
    /// Required method for telerik Reporting designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
      Telerik.Reporting.ReportParameter reportParameter2 = new Telerik.Reporting.ReportParameter();
      Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
      this.pageHeaderSection1 = new Telerik.Reporting.PageHeaderSection();
      this.detail = new Telerik.Reporting.DetailSection();
      this.pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
      this.textBox1 = new Telerik.Reporting.TextBox();
      this.textBox2 = new Telerik.Reporting.TextBox();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      // 
      // pageHeaderSection1
      // 
      this.pageHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(2.5D);
      this.pageHeaderSection1.Name = "pageHeaderSection1";
      // 
      // detail
      // 
      this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(5D);
      this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox1,
            this.textBox2});
      this.detail.Name = "detail";
      // 
      // pageFooterSection1
      // 
      this.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(2.5D);
      this.pageFooterSection1.Name = "pageFooterSection1";
      // 
      // textBox1
      // 
      this.textBox1.Docking = Telerik.Reporting.DockingStyle.Top;
      this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(15D), Telerik.Reporting.Drawing.Unit.Cm(0.89999997615814209D));
      this.textBox1.Style.Font.Bold = true;
      this.textBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(20D);
      this.textBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
      this.textBox1.Value = "= Parameters.Section.Value";
      // 
      // textBox2
      // 
      this.textBox2.Docking = Telerik.Reporting.DockingStyle.Top;
      this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0.89999997615814209D));
      this.textBox2.Name = "textBox2";
      this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(15D), Telerik.Reporting.Drawing.Unit.Cm(2.200000524520874D));
      this.textBox2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
      this.textBox2.Value = "= Parameters.SectionInfo.Value";
      // 
      // SectionReport
      // 
      this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pageHeaderSection1,
            this.detail,
            this.pageFooterSection1});
      this.Name = "SectionReport";
      this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D), Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D), Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D), Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D));
      this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
      reportParameter1.Name = "Section";
      reportParameter2.Name = "SectionInfo";
      this.ReportParameters.Add(reportParameter1);
      this.ReportParameters.Add(reportParameter2);
      styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
      styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
      styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
      this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1});
      this.Width = Telerik.Reporting.Drawing.Unit.Cm(15D);
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }
    #endregion

    private Telerik.Reporting.PageHeaderSection pageHeaderSection1;
    private Telerik.Reporting.DetailSection detail;
    private Telerik.Reporting.PageFooterSection pageFooterSection1;
    private Telerik.Reporting.TextBox textBox1;
    private Telerik.Reporting.TextBox textBox2;
  }
}