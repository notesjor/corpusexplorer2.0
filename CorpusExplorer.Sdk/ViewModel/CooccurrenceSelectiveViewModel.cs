using System.Collections.Generic;
using System.Data;
using System.Linq;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Properties;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

namespace CorpusExplorer.Sdk.ViewModel
{
  /// <summary>
  ///   The cooccurrence view model.
  /// </summary>
  public class CooccurrenceSelectiveViewModel
    : AbstractViewModel,
      IProvideDataTable
  {
    public CooccurrenceSelectiveViewModel()
    {
      LayerDisplayname = "Wort";
    }

    /// <summary>
    ///   Gets or sets the frequency dictionary.
    /// </summary>
    public Dictionary<string, double> FrequencyDictionary { get; set; }

    public Dictionary<string, double[]> FrequencySignificanceDictionary
    {
      get
      {
        var res = new Dictionary<string, double[]>();
        try
        {
          if (FrequencyDictionary != null)
            foreach (var x in SignificanceDictionary)
              if (FrequencyDictionary.ContainsKey(x.Key))
                res.Add(x.Key, new[] { FrequencyDictionary[x.Key], x.Value });
        }
        catch
        {
          // ignore
        }

        return res;
      }
    }

    public string LayerDisplayname { get; set; }
    public string[] LayerQueries { get; set; }

    /// <summary>
    ///   Gets or sets the significance dictionary.
    /// </summary>
    public Dictionary<string, double> SignificanceDictionary { get; set; }

    public CorrespondingLayerValueFilterViewModel CorrespondingLayerValueFilter { get; set; }

    /// <summary>
    ///   Gets the data table.
    /// </summary>
    public DataTable GetDataTable()
    {
      var dt = new DataTable();
      dt.Columns.Add(Resources.Cooccurrence, typeof(string));
      dt.Columns.Add(Resources.Frequency, typeof(double));
      dt.Columns.Add(Resources.Significance, typeof(double));

      CorrespondingLayerValueFilter?.DataTableFilterInit(ref dt, new[] { Resources.Cooccurrence });

      dt.BeginLoadData();
      foreach (var data in SignificanceDictionary.Select(x => new object[] { x.Key, FrequencyDictionary.ContainsKey(x.Key) ? FrequencyDictionary[x.Key] : 0, x.Value }))
      {
        if (CorrespondingLayerValueFilter == null)
          dt.Rows.Add(data);
        else
        {
          if (CorrespondingLayerValueFilter.DataTableFilter(data))
            dt.Rows.Add(data);
        }
      }
      dt.EndLoadData();
      return dt;
    }

    protected override void ExecuteAnalyse()
    {
      var block = Selection.CreateBlock<CooccurrenceSelectiveBlock>();
      block.LayerDisplayname = LayerDisplayname;
      block.LayerQueries = LayerQueries;
      block.Calculate();

      FrequencyDictionary = block.CooccurrenceFrequency;
      SignificanceDictionary = block.CooccurrenceSignificance;
    }

    protected override bool Validate()
    {
      return !string.IsNullOrEmpty(LayerDisplayname) && LayerQueries != null && LayerQueries.Any();
    }
  }
}