using System.Collections;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CorpusExplorer.Sdk.EchtzeitEngine.Reporting.Forms.Model;
using CorpusExplorer.Sdk.EchtzeitEngine.Reporting.Reports;
using CorpusExplorer.Sdk.Helper;
using Telerik.Reporting;
using Telerik.Reporting.Processing;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace CorpusExplorer.Sdk.EchtzeitEngine.Reporting.Forms
{
  public partial class ReportView : RadForm
  {
    private readonly ReportTreeItem _tree;

    public ReportView(ReportTreeItem tree)
    {
      try
      {
        ThemeResolutionService.ApplicationThemeName = "TelerikMetroTouch";
      }
      catch
      {
      }

      InitializeComponent();

      SuspendLayout();
      _tree = tree;
      GenerateTreeView(_tree, null);
      ResumeLayout(false);

      radTreeView1.SelectedNode = radTreeView1.Nodes.FirstOrDefault();
      radTreeView1.ExpandAll();

      btn_export_csv.Click += (s, o) => ExportRenderer("CSV");
      btn_export_excel.Click += (s, o) => ExportRenderer("XSLX");
      btn_export_html.Click += (s, o) => ExportRenderer("MHTML");
      btn_export_pdf.Click += (s, o) => ExportRenderer("PDF");
      btn_export_rtf.Click += (s, o) => ExportRenderer("RTF");
      btn_export_word.Click += (s, o) => ExportRenderer("DOCX");
    }

    private void ExportRenderer(string format)
    {
      var fbd = new FolderBrowserDialog();
      if (fbd.ShowDialog() != DialogResult.OK)
        return;

      var processor = new ReportProcessor();

      RecursiveReportRendering(processor, format, fbd.SelectedPath, _tree);
    }

    private void GenerateTreeView(ReportTreeItem tree, RadTreeNode parent)
    {
      var root = parent == null ? radTreeView1.Nodes.Add(tree.Label) : parent.Nodes.Add(tree.Label);
      root.Tag = tree;
      foreach (var x in tree.SubItems)
        GenerateTreeView(x, root);
    }

    private void radTreeView1_SelectedNodeChanged(object sender, RadTreeViewEventArgs e)
    {
      var ti = e.Node.Tag as ReportTreeItem;
      if (ti == null) return;
      ti.Report.DataSource = new ObjectDataSource {DataSource = ti.DataSource};

      var irs = new InstanceReportSource {ReportDocument = ti.Report};

      reportViewer1.ReportSource = irs;
      reportViewer1.RefreshReport();
    }

    private void RecursiveReportRendering(
      ReportProcessor processor,
      string format,
      string path,
      ReportTreeItem rti)
    {
      if (rti.Report.GetType() == typeof(SectionReport))
      {
        path = Path.Combine(path, rti.Label.EnsureFileName());
      }
      else
      {
        rti.Report.DataSource = new ObjectDataSource {DataSource = rti.DataSource};
        var irs = new InstanceReportSource {ReportDocument = rti.Report};
        var result = processor.RenderReport(format, irs, new Hashtable());

        if (!Directory.Exists(path))
          Directory.CreateDirectory(path);

        using (
          var fs = new FileStream(
            Path.Combine(path, $"{rti.Label}.{format.ToLower()}"),
            FileMode.Create,
            FileAccess.Write))
        {
          fs.Write(result.DocumentBytes, 0, result.DocumentBytes.Length);
        }
      }

      foreach (var item in rti.SubItems)
        RecursiveReportRendering(processor, format, path, item);
    }
  }
}