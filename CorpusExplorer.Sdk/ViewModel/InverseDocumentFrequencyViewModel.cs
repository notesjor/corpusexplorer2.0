using System.Collections.Generic;
using System.Data;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Properties;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class InverseDocumentFrequencyViewModel : AbstractViewModel, IProvideDataTable
  {
    private InverseDocumentTermFrequencyBlock _block;
    public string LayerDisplayname { get; set; } = "Wort";

    public string MetadataKey { get; set; } = "GUID";

    protected override void ExecuteAnalyse()
    {
      _block = Selection.CreateBlock<InverseDocumentTermFrequencyBlock>();
      _block.LayerDisplayname = LayerDisplayname;
      _block.MetadataKey = MetadataKey;

      _block.Calculate();
    }

    public Dictionary<string, Dictionary<string, double>> InverseDocumentTermFrequency
      => _block.InverseDocumentTermFrequency;

    public Dictionary<string, double> InverseDocumentTermFrequencyReduced
      => _block.InverseDocumentTermFrequencyReduced;

    protected override bool Validate() => !string.IsNullOrWhiteSpace(LayerDisplayname);

    public DataTable GetDataTable()
    {
      var dt = new DataTable();
      dt.Columns.Add(LayerDisplayname, typeof(string));
      dt.Columns.Add(Resources.Frequency, typeof(double));

      dt.BeginLoadData();
      foreach (var x in InverseDocumentTermFrequencyReduced)
        dt.Rows.Add(x.Key, x.Value);
      dt.EndLoadData();

      return dt;
    }
  }
}