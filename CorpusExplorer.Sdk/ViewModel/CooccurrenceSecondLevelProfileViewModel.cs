using System.Collections.Generic;
using System.Data;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class CooccurrenceSecondLevelProfileViewModel : AbstractViewModel, IProvideDataTable
  {
    public string LayerValue { get; set; }
    public string LayerDisplayname { get; set; } = "Wort";
    public Dictionary<string, double> CooccurrencesSimilarity { get; set; }

    public DataTable GetDataTable()
    {
      var dt = new DataTable();
      dt.Columns.Add(LayerDisplayname, typeof(string));
      dt.Columns.Add("Ähnlichkeit", typeof(double));

      dt.BeginLoadData();
      foreach (var x in CooccurrencesSimilarity)
      {
        dt.Rows.Add(x.Key, x.Value);
      }
      dt.EndLoadData();

      return dt;
    }

    protected override void ExecuteAnalyse()
    {
      var block = Selection.CreateBlock<CooccurrenceSecondLevelProfileBlock>();
      block.LayerValue = LayerValue;
      block.LayerDisplayname = LayerDisplayname;
      block.Calculate();

      CooccurrencesSimilarity = block.CooccurrencesSimilarity;
    }

    protected override bool Validate()
    {
      return !string.IsNullOrEmpty(LayerDisplayname) && !string.IsNullOrEmpty(LayerValue);
    }
  }
}