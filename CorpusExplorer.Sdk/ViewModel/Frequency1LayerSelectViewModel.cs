using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Properties;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class Frequency1LayerSelectViewModel : AbstractViewModel, IProvideDataTable
  {
    private Frequency1LayerSelectBlock _block;

    protected override void ExecuteAnalyse()
    {
      _block = Selection.CreateBlock<Frequency1LayerSelectBlock>();
      _block.LayerDisplayname = LayerDisplayname;
      _block.LayerQueries = LayerQueries;
      _block.Calculate();
    }

    public string LayerDisplayname { get; set; }

    public IEnumerable<string> LayerQueries { get; set; }

    public Dictionary<string, double> Frequency => _block?.Frequency;

    public Dictionary<string, double> FrequencyRelative => _block?.FrequencyRelative;

    protected override bool Validate()
    {
      return !string.IsNullOrEmpty(LayerDisplayname) && LayerQueries != null && LayerQueries.Any();
    }

    public DataTable GetDataTable()
    {
      var dt = new DataTable();
      dt.Columns.Add(LayerDisplayname, typeof(string));
      dt.Columns.Add(Resources.Frequency, typeof(double));
      dt.Columns.Add(Resources.Frequency_Relativ, typeof(double));
      if (Frequency == null || FrequencyRelative == null) 
        return dt;
      
      dt.BeginLoadData();
      foreach (var key in Frequency.Keys)
      {
        var row = dt.NewRow();
        row[LayerDisplayname] = key;
        row[Resources.Frequency] = Frequency[key];
        row[Resources.Frequency_Relativ] = FrequencyRelative[key];
        dt.Rows.Add(row);
      }
      dt.EndLoadData();

      return dt;
    }
  }
}
