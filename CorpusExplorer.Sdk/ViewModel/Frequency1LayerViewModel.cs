using System.Collections.Generic;
using System.Data;
using System.Linq;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Properties;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class Frequency1LayerViewModel : AbstractViewModel, IProvideDataTable, IProvideNormalizedDataTable
  {
    private Frequency1LayerBlock _block;

    public Dictionary<string, double> Frequency { get; set; }


    public string LayerDisplayname { get; set; } = "Wort";

    /// <summary>
    ///   Gets the data table.
    /// </summary>
    public DataTable GetDataTable()
    {
      var res = new DataTable();

      res.Columns.Add(LayerDisplayname, typeof(string));
      res.Columns.Add(Resources.Frequency, typeof(double));

      res.BeginLoadData();

      foreach (var f in Frequency)
        res.Rows.Add(f.Key, f.Value);

      res.EndLoadData();
      return res;
    }

    protected override void ExecuteAnalyse()
    {
      _block = Selection.CreateBlock<Frequency1LayerBlock>();
      _block.LayerDisplayname = LayerDisplayname;

      _block.Calculate();
      Frequency = _block.Frequency;
    }

    protected override bool Validate()
    {
      return true;
    }

    public DataTable GetNormalizedDataTable(double baseValue = 1000000)
    {
      var div = Frequency.Select(x => x.Value).Sum() / baseValue;
      var res = new DataTable();

      res.Columns.Add(LayerDisplayname, typeof(string));
      res.Columns.Add(Resources.Frequency, typeof(double));
      res.Columns.Add(Resources.Frequency_Relativ, typeof(double));

      res.BeginLoadData();

      foreach (var f in Frequency)
        res.Rows.Add(f.Key, f.Value, f.Value / div);

      res.EndLoadData();
      return res;
    }
  }
}