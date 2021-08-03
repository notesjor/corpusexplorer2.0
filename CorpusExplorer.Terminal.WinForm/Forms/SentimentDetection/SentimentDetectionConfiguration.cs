using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Extern.SentimentDetection.Model;
using CorpusExplorer.Terminal.WinForm.Forms.NamedEntity;
using Telerik.WinControls.UI;

namespace CorpusExplorer.Terminal.WinForm.Forms.SentimentDetection
{
  public partial class SentimentDetectionConfiguration : AbstractExternalModelConfig
  {
    public SentimentDetectionConfiguration()
    {
      InitializeComponent();
    }

    protected override string ModelDefaultPath { get; } =
      Configuration.GetDependencyPath("SentimentDetection/PredefinedModels/iggsa_sentiws.sdm");

    protected override object ConvertToModel(RadGridView radGridView)
    {
      var res = new Dictionary<string, Dictionary<string, double>>();
      foreach (var row in radGridView.Rows)
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
}
