using System.Collections.Generic;
using System.Data;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class NormalizedSkipgramProbabilityViewModel : AbstractViewModel, IProvideDataTable
  {
    public Dictionary<string, Dictionary<string, double>> NormalizedSkipgramProbability { get; set; }

    public string LayerDisplayname { get; set; }

    public DataTable GetDataTable()
    {
      var dt = new DataTable();

      dt.Columns.Add($"{LayerDisplayname} A", typeof(string));
      dt.Columns.Add($"{LayerDisplayname} B", typeof(string));
      dt.Columns.Add("PMI", typeof(double));

      dt.BeginLoadData();

      foreach (var x in NormalizedSkipgramProbability)
      foreach (var y in x.Value)
        dt.Rows.Add(x.Key, y.Key, y.Value);
      dt.EndLoadData();

      return dt;
    }

    protected override void ExecuteAnalyse()
    {
      var block = Selection.CreateBlock<NormalizedSkipgramProbabilityBlock>();
      block.LayerDisplayname = LayerDisplayname;
      block.Calculate();

      NormalizedSkipgramProbability = block.NormalizedSkipgramProbability;
    }

    protected override bool Validate()
    {
      return !string.IsNullOrEmpty(LayerDisplayname);
    }
  }
}