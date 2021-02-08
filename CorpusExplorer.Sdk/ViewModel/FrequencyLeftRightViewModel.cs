using System.Collections.Generic;
using System.Data;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Properties;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class FrequencyLeftRightViewModel : AbstractViewModel, IProvideDataTable, IProvideCorrespondingLayerValueFilter
  {
    public Dictionary<string, Dictionary<string, int>> FrequencyLeft { get; set; }
    public Dictionary<string, Dictionary<string, int>> FrequencyRight { get; set; }

    public string LayerDisplayname { get; set; } = "Wort";

    /// <summary>
    ///   Gibt eine Datentabelle zurück
    /// </summary>
    /// <returns>Datentabelle</returns>
    public DataTable GetDataTable()
    {
      var res = new DataTable();
      res.Columns.Add(LayerDisplayname, typeof(string));
      res.Columns.Add("Partner", typeof(string));
      res.Columns.Add("Richtung", typeof(string));
      res.Columns.Add(Resources.Frequency, typeof(int));

      res.BeginLoadData();

      foreach (var x in FrequencyLeft)
        foreach (var y in x.Value)
        {
          if (CorrespondingLayerValueFilter == null)
            res.Rows.Add(
                         x.Key,
                         y.Key,
                         FrequencyRight.ContainsKey(x.Key) && FrequencyRight[x.Key].ContainsKey(y.Key) ? "L/R" : "L",
                         y.Value);
          else
          {
            if (CorrespondingLayerValueFilter.CustomFilter(x.Key))
              res.Rows.Add(
                           x.Key,
                           y.Key,
                           FrequencyRight.ContainsKey(x.Key) && FrequencyRight[x.Key].ContainsKey(y.Key) ? "L/R" : "L",
                           y.Value);
          }
        }

      foreach (var x in FrequencyRight)
        foreach (var y in x.Value)
          if (!(FrequencyLeft.ContainsKey(x.Key) && FrequencyLeft[x.Key].ContainsKey(y.Key)))
            res.Rows.Add(x.Key, y.Key, "R", y.Value);

      res.EndLoadData();

      return res;
    }

    protected override void ExecuteAnalyse()
    {
      var block = Selection.CreateBlock<FrequencyLeftRightBlock>();
      block.LayerDisplayname = LayerDisplayname;
      block.Calculate();

      FrequencyLeft = block.FrequencyLeft;
      FrequencyRight = block.FrequencyRight;
    }

    protected override bool Validate()
    {
      return true;
    }

    public CorrespondingLayerValueFilterViewModel CorrespondingLayerValueFilter { get; set; }
  }
}