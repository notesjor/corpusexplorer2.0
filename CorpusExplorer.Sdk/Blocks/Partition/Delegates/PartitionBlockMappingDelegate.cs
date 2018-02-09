#region

using CorpusExplorer.Sdk.Blocks.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Blocks.Partition.Delegates
{
  public delegate TK PartitionBlockMappingDelegate<in TB, out TK>(TB block)
    where TB : AbstractBlock;
}