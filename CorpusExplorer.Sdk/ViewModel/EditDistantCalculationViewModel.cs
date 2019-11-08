using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class EditDistantCalculationViewModel : AbstractViewModel, IProvideDataTable, IUseSpecificLayer
  {
    protected override void ExecuteAnalyse()
    {
      var block = new EditDistantCalculationBlock
      {
        LayerDisplayname = LayerDisplayname,
        Selection = Selection,
      };
      block.Calculate();

      EditDistances = block.EditDistances;
    }

    public List<Tuple<Guid, Guid, int, int>> EditDistances { get; set; }

    protected override bool Validate()
      => !string.IsNullOrEmpty(LayerDisplayname);

    public DataTable GetDataTable()
    {
      if (EditDistances == null)
        return new DataTable();

      var dt = new DataTable();
      dt.Columns.Add("Dokument A", typeof(string));
      dt.Columns.Add("Dokument B", typeof(string));
      dt.Columns.Add("Distanz", typeof(int));
      dt.Columns.Add("Max", typeof(int));
      dt.Columns.Add("Prozent", typeof(double));

      dt.BeginLoadData();

      foreach (var x in EditDistances)
        dt.Rows.Add(x.Item1.ToString("N"), x.Item2.ToString("N"), x.Item3, x.Item4, (double) x.Item3 / x.Item4);

      dt.EndLoadData();
      return dt;
    }

    public IEnumerable<string> LayerDisplaynames => new[] { LayerDisplayname };
    public string LayerDisplayname { get; set; } = "Wort";
  }
}
