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
  public class ClusterMetadataByNGramViewModel : AbstractViewModel, IProvideDataTable
  {
    private ClusterMetadataByNgramBlock _block;

    public AbstractDistance SimilarityIndex { get; set; } = new EuclideanDistance();

    public string LayerDisplayname { get; set; } = "Wort";

    public IEnumerable<string> DocumentMetaProperties 
      => Selection.GetDocumentMetadataPrototypeOnlyProperties();

    protected override void ExecuteAnalyse()
    {
      _block = Selection.CreateBlock<ClusterMetadataByNgramBlock>();
      _block.SimilarityIndex = SimilarityIndex;
      _block.LayerDisplayname = LayerDisplayname;
      _block.SelectionClusterGenerator = new SelectionClusterGeneratorStringValue { MetadataKey = MetadataKey };
      _block.MetadataKey = MetadataKey;
      _block.NGramSize = NGramSize;
      _block.NGramMinFrequency = NGramMinFrequency;
      _block.Calculate();
    }

    public int NGramMinFrequency { get; set; } = 5;

    public ClusterMetadataItem RootCluster => _block.RootCluster;

    public string MetadataKey { get; set; } = "Autor";

    public int NGramSize { get; set; } = 3;

    protected override bool Validate() 
      => !string.IsNullOrEmpty(LayerDisplayname) && !string.IsNullOrEmpty(MetadataKey) && NGramSize > 0 && SimilarityIndex != null;

    public DataTable GetDataTable()
      => _block.GetDataTable();

    public DataTable GetCrossDataTable()
      => _block.GetCrossDataTable();
  }
}