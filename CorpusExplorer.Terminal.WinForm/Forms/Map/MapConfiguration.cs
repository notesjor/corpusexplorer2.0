using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Bcs.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Terminal.WinForm.Forms.Abstract;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;

namespace CorpusExplorer.Terminal.WinForm.Forms.Map
{
  public partial class MapConfiguration : AbstractDialog
  {
    public MapConfiguration(string[][] table)
    {
      InitializeComponent();
      if (table == null)
        LoadFile(Configuration.GetDependencyPath("Map/global.csv"));
      else
        LoadCsv(table);
    }

    public string[][] Data
    {
      get
      {
        var res = new List<string[]> {radGridView1.Columns.Select(x => x.Name).ToArray()};
        res.AddRange(radGridView1.Rows.Select(row =>
                                                (from GridViewCellInfo c in row.Cells select c.Value?.ToString())
                                               .ToArray()));
        return res.ToArray();
      }
    }

    private void btn_open_Click(object sender, EventArgs e)
    {
      var ofd = new OpenFileDialog {Filter = "CSV-Datei (*.csv)|*.csv"};
      if (ofd.ShowDialog() != DialogResult.OK)
        return;

      LoadFile(ofd.FileName);
    }

    private void btn_save_Click(object sender, EventArgs e)
    {
      var sfd = new SaveFileDialog {Filter = "CSV-Datei (*.csv)|*.csv"};
      if (sfd.ShowDialog() != DialogResult.OK)
        return;

      var csv = new ExportToCSV(radGridView1) {Encoding = Configuration.Encoding};
      csv.RunExport(sfd.FileName);
    }

    private void LoadCsv(IReadOnlyList<string[]> csv)
    {
      radGridView1.Rows.Clear();
      radGridView1.Columns.Clear();
      for (var i = 0; i < csv[0].Length; i++)
        radGridView1.Columns.Add(new GridViewTextBoxColumn(csv[0][i]));

      for (var i = 1; i < csv.Count; i++)
        radGridView1.Rows.Add(csv[i]);

      radGridView1.AllowAutoSizeColumns = true;
      radGridView1.BestFitColumns(BestFitColumnMode.AllCells);
    }

    private void LoadFile(string fileName)
    {
      var lines = FileIO.ReadLines(fileName, Configuration.Encoding);
      LoadCsv(lines.Select(line => line.Split(new[] {";", "\t"}, StringSplitOptions.None)).ToArray());
    }
  }
}