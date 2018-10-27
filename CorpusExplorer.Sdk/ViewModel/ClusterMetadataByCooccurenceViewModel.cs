using System.Collections.Generic;
using System.Data;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Blocks.ClusterMetadata;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator;
using CorpusExplorer.Sdk.Blocks.Similarity;
using CorpusExplorer.Sdk.Blocks.Similarity.Abstract;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class ClusterMetadataByCooccurenceViewModel : AbstractViewModel, IProvideDataTable
  {
    private ClusterMetadataByCooccurrenceBlock _block;

    public string MetadataKey { get; set; }

    public AbstractDistance SimilarityIndex { get; set; } = new EuclideanDistance();

    public string LayerDisplayname { get; set; } = "Wort";

    public IEnumerable<string> DocumentMetaProperties 
      => Selection.GetDocumentMetadataPrototypeOnlyProperties();

    protected override void ExecuteAnalyse()
    {
      _block = Selection.CreateBlock<ClusterMetadataByCooccurrenceBlock>();
      _block.SimilarityIndex = SimilarityIndex;
      _block.LayerDisplayname = LayerDisplayname;
      _block.SelectionClusterGenerator = new SelectionClusterGeneratorStringValue { MetadataKey = MetadataKey };
      _block.CooccurrenceMinFrequency = CooccurrenceMinFrequency;
      _block.MetadataKey = MetadataKey;
      _block.CooccurrenceMinSignificance = CooccurrenceMinSignificance;
      _block.Calculate();
    }

    public double CooccurrenceMinSignificance { get; set; } = 1;

    public double CooccurrenceMinFrequency { get; set; } = 5;

    public ClusterMetadataItem RootCluster => _block.RootCluster;

    protected override bool Validate() 
      => !string.IsNullOrEmpty(LayerDisplayname) && !string.IsNullOrEmpty(MetadataKey) && SimilarityIndex != null;

    public DataTable GetDataTable()
      => _block.GetDataTable();
  }
}