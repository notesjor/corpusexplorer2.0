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
    public Dictionary<string, Dictionary<string, double>> CooccurrenceDuos { get; set; }

    public DataTable GetDataTable()
    {
      var dt = new DataTable();
      dt.Columns.Add($"{LayerDisplayname} (A)", typeof(string));
      dt.Columns.Add($"{LayerDisplayname} (B)", typeof(string));
      dt.Columns.Add("Signifikanz", typeof(double));

      dt.BeginLoadData();
      foreach (var duo in CooccurrenceDuos)
      foreach (var part in duo.Value)
        dt.Rows.Add(duo.Key, part.Key, part.Value);
      dt.EndLoadData();

      return dt;
    }

    protected override void ExecuteAnalyse()
    {
      var block = Selection.CreateBlock<CooccurrenceSecondLevelProfileBlock>();
      block.LayerValue = LayerValue;
      block.LayerDisplayname = LayerDisplayname;
      block.Calculate();

      CooccurrenceDuos = block.CooccurrenceDuos;
    }

    protected override bool Validate()
    {
      return !string.IsNullOrEmpty(LayerDisplayname) && !string.IsNullOrEmpty(LayerValue);
    }
  }
}