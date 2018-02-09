using System;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Model.Cache.Abstract;

namespace CorpusExplorer.Sdk.Model.Cache
{
  public class CacheStrategyDisableCaching : AbstractCacheStrategy
  {
    public override AbstractBlock CreateBlock(Selection selection, Type blockType)
    {
      return CreateNewBlock(selection, blockType);
    }
  }
}