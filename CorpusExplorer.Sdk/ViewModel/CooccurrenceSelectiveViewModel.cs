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
    public CooccurrenceSelectiveViewModel() { LayerDisplayname = "Wort"; }

    /// <summary>
    ///   Gets or sets the frequency dictionary.
    /// </summary>
    public Dictionary<string, double> FrequencyDictionary { get; set; }

    public IEnumerable<string> AvailableLayerDisplaynames => Selection.LayerUniqueDisplaynames;
    public IEnumerable<string> AvailableLayerValues => Selection.GetLayerValues(LayerDisplayname);

    public string LayerDisplayname { get; set; }
    public string[] LayerQueries { get; set; }

    /// <summary>
    ///   Gets or sets the significance dictionary.
    /// </summary>
    public Dictionary<string, double> SignificanceDictionary { get; set; }

    /// <summary>
    ///   Gets the data table.
    /// </summary>
    public DataTable GetDataTable()
    {
      var dt = new DataTable();
      dt.Columns.Add(Resources.Cooccurrence, typeof(string));
      dt.Columns.Add(Resources.Frequency, typeof(double));
      dt.Columns.Add(Resources.Significance, typeof(double));

      dt.BeginLoadData();
      foreach (var x in SignificanceDictionary)
        dt.Rows.Add(x.Key, FrequencyDictionary.ContainsKey(x.Key) ? FrequencyDictionary[x.Key] : 0, x.Value);
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

    protected override bool Validate() { return !string.IsNullOrEmpty(LayerDisplayname) && LayerQueries != null && LayerQueries.Any(); }
  }
}