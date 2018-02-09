using System.Collections.Generic;
using System.Data;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class HyphenWordFrequencyViewModel : AbstractViewModel, IProvideDataTable
  {
    private Dictionary<string, double> _wordFrequency;

    public Dictionary<string, Dictionary<string, int>> HypenWordFrequency { get; set; }

    /// <summary>
    ///   Gibt eine Datentabelle zurück
    /// </summary>
    /// <returns>Datentabelle</returns>
    public DataTable GetDataTable()
    {
      var res = new DataTable();
      res.Columns.Add("Silbe", typeof(string));
      res.Columns.Add("Frequenz (Silbe)", typeof(int));
      res.Columns.Add("Wort", typeof(string));
      res.Columns.Add("Frequenz (Wort)", typeof(int));
      res.Columns.Add("Frequenz (Wort * Silbe)", typeof(int));

      res.BeginLoadData();

      foreach (var x in HypenWordFrequency)
      foreach (var y in x.Value)
      {
        var fact = (int) (_wordFrequency.ContainsKey(y.Key) ? _wordFrequency[y.Key] : 0);
        res.Rows.Add(x.Key, y.Value, y.Key, fact, (fact == 0 ? 1 : fact) * y.Value);
      }

      return res;
    }

    protected override void ExecuteAnalyse()
    {
      var block = Selection.CreateBlock<HyphenWordFrequencyBlock>();
      block.Calculate();

      HypenWordFrequency = block.HyphenFrequency;

      var block2 = Selection.CreateBlock<Frequency1LayerBlock>();
      block2.Calculate();

      _wordFrequency = block2.Frequency;
    }

    protected override bool Validate() { return true; }
  }
}