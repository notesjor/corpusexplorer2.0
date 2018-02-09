using System.Collections.Generic;
using System.Data;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class KeywordViewModel : AbstractCompareViewModel, IProvideDataTable
  {
    public Dictionary<string, double> KeywordFrequency { get; set; }

    /// <summary>
    ///   Gibt eine Datentabelle zurück
    /// </summary>
    /// <returns>Datentabelle</returns>
    public DataTable GetDataTable()
    {
      var res = new DataTable();
      res.Columns.Add("Keyword", typeof(string));
      res.Columns.Add("Rang", typeof(double));

      res.BeginLoadData();
      foreach (var pair in KeywordFrequency)
        res.Rows.Add(pair.Key, pair.Value);
      res.EndLoadData();

      return res;
    }

    protected override void ExecuteAnalyse()
    {
      var block = Selection.CreateBlock<KeywordBlock>();
      block.SelectionToCompare = SelectionToCompare;
      block.Calculate();

      KeywordFrequency = block.Keywords;
    }
  }
}