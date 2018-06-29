#region

using System.Collections.Generic;
using System.Data;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Properties;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

#endregion

namespace CorpusExplorer.Sdk.ViewModel
{
  public class DuplicatViewModel : AbstractViewModel, IProvideDataTable
  {
    public int FrequencyMinimum { get; set; } = 1;
    public string LayerDisplayname { get; set; } = "Wort";
    public Dictionary<string, int> SentenceFrequency { get; set; }

    /// <summary>
    ///   Gibt eine Datentabelle zurück
    /// </summary>
    /// <returns>Datentabelle</returns>
    public DataTable GetDataTable()
    {
      var res = new DataTable();
      res.Columns.Add("Satz", typeof(string));
      res.Columns.Add(Resources.Frequency, typeof(int));

      res.BeginLoadData();
      foreach (var s in SentenceFrequency)
        res.Rows.Add(s.Key, s.Value);
      res.EndLoadData();

      return res;
    }

    protected override void ExecuteAnalyse()
    {
      var block = Selection.CreateBlock<DuplicateSentenceBlock>();
      block.FrequencyMinimum = FrequencyMinimum;
      block.LayerDisplayname = LayerDisplayname;
      block.Calculate();

      SentenceFrequency = block.SentenceFrequency;
    }

    protected override bool Validate()
    {
      return !string.IsNullOrEmpty(LayerDisplayname) && FrequencyMinimum > -1;
    }
  }
}