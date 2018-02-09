using System.Collections.Generic;
using System.Data;
using Telerik.Reporting;

namespace CorpusExplorer.Sdk.EchtzeitEngine.Reporting.Forms.Model
{
  public class ReportTreeItem
  {
    private ReportTreeItem() { }

    public ReportTreeItem(string label, Report report, DataTable dataSource)
    {
      Label = label;
      Report = report;
      DataSource = dataSource;
    }

    public DataTable DataSource { get; set; }
    public string Label { get; set; }
    public Report Report { get; set; }

    public List<ReportTreeItem> SubItems { get; set; } = new List<ReportTreeItem>();
  }
}