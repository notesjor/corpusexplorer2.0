using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Bcs.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Extern.SentimentDetection.Model;
using CorpusExplorer.Terminal.WinForm.Forms.Abstract;
using CorpusExplorer.Terminal.WinForm.Forms.Splash;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;

namespace CorpusExplorer.Terminal.WinForm.Forms.SentimentDetection
{
  public partial class SentimentDetectionConfiguration : AbstractDialog
  {
    private const string Filter = "SDM-Datei (*.sdm)|*.sdm";

    public SentimentDetectionConfiguration()
    {
      InitializeComponent();
      LoadFile(Configuration.GetDependencyPath("SentimentDetection/PredefinedModels/iggsa_sentiws.sdm"));
    }

    public SentimentDetectionTagModel Model
    {
      get
      {
        var res = new Dictionary<string, Dictionary<string, double>>();
        foreach (var row in radGridView1.Rows)
        {
          var category = row.Cells[0].Value.ToString();
          if (string.IsNullOrEmpty(category))
            continue;

          if (!res.ContainsKey(category))
            res.Add(category, new Dictionary<string, double>());

          var token = row.Cells[1].Value.ToString();
          if (string.IsNullOrEmpty(category))
            continue;

          if (!res[category].ContainsKey(token))
            res[category].Add(token, double.Parse(row.Cells[2].Value.ToString().Replace(",", ".")));
        }

        return SentimentDetectionTagModel.Create(res);
      }
    }

    public string ModelDisplayname { get; set; }

    private void btn_open_Click(object sender, EventArgs e)
    {
      var ofd = new OpenFileDialog {Filter = Filter};
      if (ofd.ShowDialog() != DialogResult.OK)
        return;

      LoadFile(ofd.FileName);
    }

    private void btn_save_Click(object sender, EventArgs e)
    {
      var sfd = new SaveFileDialog {Filter = Filter};
      if (sfd.ShowDialog() != DialogResult.OK)
        return;

      var csv = new ExportToCSV(radGridView1) {Encoding = Configuration.Encoding};
      csv.RunExport(sfd.FileName);
    }

    private void LoadFile(string fileName)
    {
      Processing.Invoke("Lade Sentiment-Modell...", () =>
      {
        ModelDisplayname = Path.GetFileNameWithoutExtension(fileName);
        var lines = FileIO.ReadLines(fileName, Configuration.Encoding);
        IReadOnlyList<string[]> csv = lines.Select(line => line.Split(new[] {"\t"}, StringSplitOptions.None)).ToArray();

        radGridView1.Rows.Clear();
        for (var i = 1; i < csv.Count; i++)
          radGridView1.Rows.Add(csv[i]);

        radGridView1.AllowAutoSizeColumns = true;
        radGridView1.BestFitColumns(BestFitColumnMode.AllCells);
      });
    }
  }
}