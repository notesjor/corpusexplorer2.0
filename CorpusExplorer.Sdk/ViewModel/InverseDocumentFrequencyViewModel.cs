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
    public string LayerDisplayname { get; set; } = "Wort";

    public string MetadataKey { get; set; } = "GUID";

    protected override void ExecuteAnalyse()
    {
      var block = Selection.CreateBlock<InverseDocumentFrequencyBlock>();
      block.LayerDisplayname = LayerDisplayname;
      block.MetadataKey = MetadataKey;

      block.Calculate();
      InverseDocumentTermFrequency = block.InverseDocumentTermFrequency;
    }

    public Dictionary<string, double> InverseDocumentTermFrequency { get; set; }

    protected override bool Validate() => !string.IsNullOrWhiteSpace(LayerDisplayname);

    public DataTable GetDataTable()
    {
      var dt = new DataTable();
      dt.Columns.Add(LayerDisplayname, typeof(string));
      dt.Columns.Add(Resources.Frequency, typeof(double));

      dt.BeginLoadData();
      foreach (var x in InverseDocumentTermFrequency)
        dt.Rows.Add(x.Key, x.Value);
      dt.EndLoadData();

      return dt;
    }
  }
}