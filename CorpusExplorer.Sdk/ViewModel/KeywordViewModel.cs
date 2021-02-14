using System.Collections.Generic;
using System.Data;
using System.Linq;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Properties;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class KeywordViewModel : AbstractCompareViewModel, IProvideDataTable, IProvideCorrespondingLayerValueFilter
  {
    public string LayerDisplayname { get; set; } = "Wort";

    public Dictionary<string, double> KeywordSignificance { get; set; }

    public Dictionary<string, double> KeywordFrequencyReference { get; set; }

    public Dictionary<string, double> KeywordFrequencyCurrent { get; set; }

    public Dictionary<string, double> KeywordDiff { get; set; }

    /// <summary>
    ///   Gibt eine Datentabelle zurück
    /// </summary>
    /// <returns>Datentabelle</returns>
    public DataTable GetDataTable()
    {
      var res = new DataTable();
      res.Columns.Add("Keyword", typeof(string));
      res.Columns.Add(Resources.Frequeny1, typeof(double));
      res.Columns.Add(Resources.Frequeny2, typeof(double));
      res.Columns.Add(Resources.FrequenyD12, typeof(double));
      res.Columns.Add(Resources.Significance, typeof(double));

      res.BeginLoadData();
      foreach (var pair in KeywordDiff.Where(pair => KeywordFrequencyCurrent.ContainsKey(pair.Key) && KeywordFrequencyReference.ContainsKey(pair.Key) && KeywordSignificance.ContainsKey(pair.Key)))
        if(CorrespondingLayerValueFilter == null)
          res.Rows.Add(pair.Key, KeywordFrequencyCurrent[pair.Key], KeywordFrequencyReference[pair.Key], pair.Value, KeywordSignificance[pair.Key]);
        else if(CorrespondingLayerValueFilter.CustomFilter(pair.Key))
          res.Rows.Add(pair.Key, KeywordFrequencyCurrent[pair.Key], KeywordFrequencyReference[pair.Key], pair.Value, KeywordSignificance[pair.Key]);

      res.EndLoadData();

      return res;
    }

    protected override void ExecuteAnalyse()
    {
      var block = Selection.CreateBlock<KeywordBlock>();
      block.SelectionToCompare = SelectionToCompare;
      block.LayerDisplayname = LayerDisplayname;
      block.Calculate();

      KeywordDiff = block.KeywordDiff;
      KeywordFrequencyCurrent = block.KeywordFrequencyCurrent;
      KeywordFrequencyReference = block.KeywordFrequencyReference;
      KeywordSignificance = block.KeywordSignificance;
    }

    public CorrespondingLayerValueFilterViewModel CorrespondingLayerValueFilter { get; set; }
  }
}