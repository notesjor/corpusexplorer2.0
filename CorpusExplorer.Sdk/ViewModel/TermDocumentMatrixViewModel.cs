using System.Collections.Generic;
using System.Data;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Properties;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class TermDocumentMatrixViewModel : AbstractViewModel, IProvideDataTable
  {
    public string LayerDisplayname { get; set; } = "Wort";

    public string MetadataKey { get; set; } = "GUID";

    protected override void ExecuteAnalyse()
    {
      var block = Selection.CreateBlock<TermDocumentMatrixBlock>();
      block.LayerDisplayname = LayerDisplayname;
      block.MetadataKey = MetadataKey;

      block.Calculate();
      TermDocumentMatrix = block.TermDocumentMatrix;
    }

    public Dictionary<string, Dictionary<string, double>> TermDocumentMatrix { get; set; }

    protected override bool Validate() => !string.IsNullOrWhiteSpace(LayerDisplayname);

    public DataTable GetDataTable()
    {
      var dt = new DataTable();
      dt.Columns.Add(MetadataKey, typeof(string));
      dt.Columns.Add(LayerDisplayname, typeof(string));
      dt.Columns.Add(Resources.Frequency, typeof(double));

      dt.BeginLoadData();
      foreach (var x in TermDocumentMatrix)
        dt.Rows.Add(x.Key, x.Value);
      dt.EndLoadData();

      return dt;
    }
  }
}