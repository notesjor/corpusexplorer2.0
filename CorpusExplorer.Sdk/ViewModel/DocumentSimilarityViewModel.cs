using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Blocks.Similarity;
using CorpusExplorer.Sdk.Blocks.Similarity.Abstract;
using CorpusExplorer.Sdk.Properties;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class DocumentSimilarityViewModel : AbstractViewModel, IProvideDataTable
  {
    public IEnumerable<Guid> DocumentGuids { get; set; }

    public double MinimumDocumentSimilarity { get; set; } = 0.7d;

    public double MinimumInversDocumentFrequency { get; set; } = 0.003d;

    public AbstractSimilarity SimilarityMeasure { get; set; } = new CosineMeasure();

    public string LayerDisplayname { get; set; } = "Wort";

    public string MetadataKey { get; set; } = "GUID";

    protected override void ExecuteAnalyse()
    {
      var block = Selection.CreateBlock<DocumentSimilarityBlock>();
      block.Similarity = SimilarityMeasure;
      block.LayerDisplayname = LayerDisplayname;
      block.MetadataKey = MetadataKey;
      block.MinimumInversDocumentFrequency = MinimumInversDocumentFrequency;
      block.MinimumDocumentSimilarity = MinimumDocumentSimilarity;
      block.Calculate();

      SimilarityResults = block.SimilarityResults;
    }

    public IEnumerable<KeyValuePair<string, Dictionary<string, double>>> SimilarityResults { get; set; }
    public IEnumerable<string> DocumentMetaProperties => Selection.GetDocumentMetadataPrototypeOnlyProperties();

    protected override bool Validate()
    {
      return MinimumInversDocumentFrequency > 0 && SimilarityMeasure != null;
    }

    public DataTable GetDataTable()
    {
      var dt = new DataTable();
      dt.Columns.Add(MetadataKey + " (A)", typeof(string));
      dt.Columns.Add(MetadataKey + " (B)", typeof(string));
      dt.Columns.Add(Resources.DocumentSimilarity, typeof(double));

      dt.BeginLoadData();
      foreach (var x in SimilarityResults)
      foreach (var y in x.Value)
        dt.Rows.Add(x.Key, y.Key, y.Value);
      dt.EndLoadData();

      return dt;
    }
  }
}