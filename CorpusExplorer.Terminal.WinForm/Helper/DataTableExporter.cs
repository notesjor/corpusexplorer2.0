using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CorpusExplorer.Sdk.Utils.DataTableWriter;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;
using CorpusExplorer.Terminal.WinForm.Forms.Splash;
using Telerik.Documents.SpreadsheetStreaming;
using Telerik.WinControls.Export;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;

namespace CorpusExplorer.Terminal.WinForm.Helper
{
  public static class DataTableExporter
  {
    private static readonly KeyValuePair<string, ExportDelegate>[] _exportFormats =
      new Dictionary<string, ExportDelegate>
      {
        {"TSV (*.tsv)|*.tsv", (grid, path) => ExportWithDataTableWriter(grid, new TsvTableWriter(), path)},
        {"CSV (*.csv)|*.csv", (grid, path) => ExportWithDataTableWriter(grid, new CsvTableWriter(), path)},
        {"JSON (*.json)|*.json", (grid, path) => ExportWithDataTableWriter(grid, new JsonTableWriter(), path)},
        {"Microsoft Excel (*.xlsx)|*.xlsx", (grid, path) => ExportToStream(grid, SpreadDocumentFormat.Xlsx, path)},
        {"XML (*.xml)|*.xml", (grid, path) => ExportWithDataTableWriter(grid, new XmlTableWriter(), path)},
        {"HTML (*.html)|*.html", (grid, path) => new ExportToHTML(grid).RunExport(path)},
        {"PDF (*.pdf)|*.pdf", (grid, path) => new ExportToPDF(grid).RunExport(path)},
        {"SQL (*.sql)|*.sql", (grid, path) => ExportWithDataTableWriter(grid, new SqlTableWriter(), path)}
      }.ToArray();

    public static void Export(DataTable dataTable)
    {
      Export(new RadGridView {DataSource = dataTable});
    }

    public static void Export(RadPivotGrid pivot)
    {
      var sfd = new SaveFileDialog
      {
        Filter = "Microsoft Excel (*.xlsx)|*.xlsx",
        CheckPathExists = true
      };

      if (sfd.ShowDialog() != DialogResult.OK)
        return;

      using (var fileStream = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write))
      using (var bs = new BufferedStream(fileStream))
      {
        var exporter = new PivotGridSpreadExport(pivot);
        var renderer = new SpreadExportRenderer();
        exporter.RunExport(bs, renderer);
      }
    }

    public static void Export(RadGridView grid)
    {
      var sfd = new SaveFileDialog
      {
        Filter = string.Join("|", _exportFormats.Select(x => x.Key)),
        CheckPathExists = true
      };

      if (sfd.ShowDialog() != DialogResult.OK)
        return;

      Processing.Invoke("Daten werden exportiert...",
                        () => { _exportFormats[sfd.FilterIndex - 1].Value(grid, sfd.FileName); });
    }

    private static void ExportWithDataTableWriter(RadGridView grid, AbstractTableWriter tableWriter, string path)
    {
      var res = new DataTable();
      var cna = grid.Columns.Select(x => x.Name).ToArray();

      foreach (var col in grid.Columns)
        res.Columns.Add(col.Name, col.DataType);

      res.BeginLoadData();
      foreach (var row in grid.Rows)
        res.Rows.Add(cna.Select(n => row.Cells[n].Value).ToArray());
      res.EndLoadData();

      using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
      {
        tableWriter.OutputStream = fs;
        tableWriter.WriteTable(res);
        tableWriter.Destroy();
      }
    }

    private static void ExportToStream(RadGridView grid, SpreadDocumentFormat format, string filename)
    {
      using (var fs = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None))
      using (var bs = new BufferedStream(fs))
      using (var workbook = SpreadExporter.CreateWorkbookExporter(format, bs))
      using (var sheet = workbook.CreateWorksheetExporter("CorpusExplorer"))
      {
        foreach (var c in grid.Columns)
          using (var column = sheet.CreateColumnExporter())
          {
            column.SetHidden(false);
            column.SetWidthInPixels(256);
          }

        using (var row = sheet.CreateRowExporter())
        {
          foreach (var c in grid.Columns)
            using (var cell = row.CreateCellExporter())
            {
              cell.SetValue(c.Name);
            }
        }


        foreach (var r in grid.Rows)
          using (var row = sheet.CreateRowExporter())
          {
            foreach (GridViewCellInfo c in r.Cells)
              using (var cell = row.CreateCellExporter())
              {
                cell.SetValue(c.Value.ToString());
              }
          }
      }
    }

    private delegate void ExportDelegate(RadGridView grid, string path);
  }
}