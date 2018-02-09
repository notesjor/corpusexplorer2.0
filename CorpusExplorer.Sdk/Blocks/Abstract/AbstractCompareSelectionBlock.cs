using CorpusExplorer.Sdk.Model;

namespace CorpusExplorer.Sdk.Blocks.Abstract
{
  public abstract class AbstractCompareSelectionBlock : AbstractBlock
  {
    public Selection SelectionToCompare { get; set; }
  }
}