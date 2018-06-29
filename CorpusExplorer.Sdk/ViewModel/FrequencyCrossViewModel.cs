using System.Collections.Generic;
using System.Data;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Properties;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class FrequencyCrossViewModel : AbstractViewModel, IProvideDataTable
  {
    public Dictionary<string, Dictionary<string, double>> CrossFrequency { get; set; }

    public string LayerDisplayname { get; set; } = "Wort";

    /// <summary>
    ///   Gibt eine Datentabelle zurück
    /// </summary>
    /// <returns>Datentabelle</returns>
    public DataTable GetDataTable()
    {
      var res = new DataTable();
      res.Columns.Add("Wort", typeof(string));
      res.Columns.Add(Resources.Partner, typeof(string));
      res.Columns.Add(Resources.Frequency, typeof(double));

      res.BeginLoadData();
      foreach (var x in CrossFrequency)
      foreach (var y in x.Value)
        res.Rows.Add(x.Key, y.Key, y.Value);
      res.EndLoadData();

      return res;
    }

    protected override void ExecuteAnalyse()
    {
      var block = Selection.CreateBlock<CrossFrequencyBlock>();
      block.LayerDisplayname = LayerDisplayname;
      block.Calculate();

      CrossFrequency = block.CooccurrencesFrequency;
    }

    protected override bool Validate()
    {
      return true;
    }
  }
}