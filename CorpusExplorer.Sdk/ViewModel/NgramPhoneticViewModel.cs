using System.Collections.Generic;
using System.Data;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Properties;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class NgramPhoneticViewModel : AbstractViewModel, IProvideDataTable
  {
    public Dictionary<string, double> NGramFrequency { get; set; }

    public int NGramSize { get; set; }

    /// <summary>
    ///   Gibt eine Datentabelle zurück
    /// </summary>
    /// <returns>Datentabelle</returns>
    public DataTable GetDataTable()
    {
      var res = new DataTable();
      res.Columns.Add(Resources.NGram, typeof(string));
      res.Columns.Add(Resources.Frequency, typeof(double));

      res.BeginLoadData();

      foreach (var x in NGramFrequency)
        res.Rows.Add(x.Key, x.Value);

      res.EndLoadData();

      return res;
    }

    protected override void ExecuteAnalyse()
    {
      var block = Selection.CreateBlock<NgramPhoneticBlock>();
      block.NGramSize = NGramSize;
      block.Calculate();

      NGramFrequency = block.NGramFrequency;
    }

    protected override bool Validate() { return true; }
  }
}