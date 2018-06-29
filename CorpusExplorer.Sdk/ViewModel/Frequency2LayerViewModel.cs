using System.Collections.Generic;
using System.Data;
using System.Linq;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Properties;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class Frequency2LayerViewModel : AbstractViewModel, IProvideDataTable, IProvideNormalizedDataTable
  {
    private Frequency2LayerBlock _block;

    public Dictionary<string, Dictionary<string, double>> Frequency { get; set; }

    public string Layer1Displayname { get; set; } = "POS";

    public string Layer2Displayname { get; set; } = "Wort";

    /// <summary>
    ///   Gets the data table.
    /// </summary>
    public DataTable GetDataTable()
    {
      var res = new DataTable();

      res.Columns.Add(Layer1Displayname, typeof(string));
      res.Columns.Add(Layer2Displayname, typeof(string));
      res.Columns.Add(Resources.Frequency, typeof(double));

      res.BeginLoadData();

      foreach (var f in Frequency)
      foreach (var s in f.Value)
        res.Rows.Add(f.Key, s.Key, s.Value);

      res.EndLoadData();

      return res;
    }

    protected override void ExecuteAnalyse()
    {
      _block = Selection.CreateBlock<Frequency2LayerBlock>();
      _block.Layer1Displayname = Layer1Displayname;
      _block.Layer2Displayname = Layer2Displayname;

      _block.Calculate();
      Frequency = _block.Frequency;
    }

    protected override bool Validate()
    {
      return true;
    }

    public DataTable GetNormalizedDataTable(double baseValue = 1000000)
    {
      var div = Frequency.SelectMany(x => x.Value).Select(x => x.Value).Sum() / baseValue;
      var res = new DataTable();

      res.Columns.Add(Layer1Displayname, typeof(string));
      res.Columns.Add(Layer2Displayname, typeof(string));
      res.Columns.Add(Resources.Frequency, typeof(double));
      res.Columns.Add(Resources.Frequency_Relativ, typeof(double));

      res.BeginLoadData();

      foreach (var f in Frequency)
      foreach (var s in f.Value)
        res.Rows.Add(f.Key, s.Key, s.Value, s.Value / div);

      res.EndLoadData();
      return res;
    }
  }
}