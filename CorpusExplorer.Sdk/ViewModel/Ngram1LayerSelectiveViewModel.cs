using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Properties;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class Ngram1LayerSelectiveViewModel
    : AbstractViewModel,
      IProvideDataTable
  {
    /// <summary>
    ///   Eigenschaft kann gesetzt werden, um die Ausgabe von GetDataTable() zu filtern.
    ///   Zum Filter/Optimieren des Blocks sollte Configuration.MinimumFrequency gesetzt werden.
    /// </summary>
    /// <value>The n gram minimum frequency.</value>
    public int NGramMinFrequency { get; set; } = 0;

    public Dictionary<string, double> NGramFrequency { get; private set; }
    public IEnumerable<string> LayerQueries { get; set; }
    public string LayerDisplayname { get; set; } = "Wort";
    public int NGramSize { get; set; } = 3;

    /// <summary>
    ///   Gets the data table.
    /// </summary>
    public DataTable GetDataTable()
    {
      var dt = new DataTable();
      dt.Columns.Add(Resources.NGram, typeof(string));
      dt.Columns.Add(Resources.Frequency, typeof(double));
      
      dt.BeginLoadData();
      foreach (var x in NGramFrequency.Where(x => !(x.Value < NGramMinFrequency)))
        dt.Rows.Add(x.Key, x.Value);
      dt.EndLoadData();
      return dt;
    }

    protected override void ExecuteAnalyse()
    {
      var block = Selection.CreateBlock<Ngram1LayerSelectiveBlock>();
      block.LayerDisplayname = LayerDisplayname;
      block.NGramSize = NGramSize;
      block.LayerQueries = LayerQueries;
      block.Calculate();

      NGramFrequency = block.NGramFrequency;
    }

    protected override bool Validate()
    {
      return !string.IsNullOrEmpty(LayerDisplayname) && LayerQueries != null && LayerQueries.Any();
    }
  }
}