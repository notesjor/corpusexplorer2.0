using System.Collections.Generic;
using System.Data;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Properties;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class CooccurrenceOverlappingViewModel : AbstractViewModel, IProvideDataTable
  {
    private CooccurrenceOverlappingBlock _block;
    public Dictionary<string, double> CooccurrenceFrequency { get; set; }

    public Dictionary<string, double> CooccurrenceSignificance { get; set; }
    public string LayerDisplayname { get; set; } = "Wort";
    public IEnumerable<string> LayerQueries { get; set; }
    public IEnumerable<string> LayerValues => Selection.GetLayerValues(LayerDisplayname);

    public DataTable GetDataTable()
    {
      if (CooccurrenceSignificance == null)
        Analyse();

      var dt = new DataTable();
      dt.Columns.Add(Resources.Cooccurrence, typeof(string));
      dt.Columns.Add(Resources.Frequency, typeof(double));
      dt.Columns.Add(Resources.Significance, typeof(double));

      dt.BeginLoadData();

      foreach (var x in CooccurrenceSignificance)
        if (CooccurrenceFrequency.ContainsKey(x.Key))
          dt.Rows.Add(x.Key, CooccurrenceFrequency[x.Key], x.Value);

      dt.EndLoadData();
      return dt;
    }

    protected override void ExecuteAnalyse()
    {
      if (_block == null || _block.LayerDisplayname != LayerDisplayname)
      {
        _block = Selection.CreateBlock<CooccurrenceOverlappingBlock>();
        _block.LayerDisplayname = LayerDisplayname;
      }

      _block.LayerQueries = LayerQueries;
      _block.Calculate();

      CooccurrenceFrequency = _block.CooccurrenceFrequency;
      CooccurrenceSignificance = _block.CooccurrenceSignificance;
    }

    protected override bool Validate()
    {
      return !string.IsNullOrEmpty(LayerDisplayname) && LayerQueries != null;
    }
  }
}