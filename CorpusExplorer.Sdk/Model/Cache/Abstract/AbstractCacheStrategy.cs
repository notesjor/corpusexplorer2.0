using System;
using System.Collections.Generic;
using CorpusExplorer.Sdk.Blocks.Abstract;

namespace CorpusExplorer.Sdk.Model.Cache.Abstract
{
  public abstract class AbstractCacheStrategy
  {
    private readonly Dictionary<Guid, Dictionary<string, AbstractBlock>> _cache =
      new Dictionary<Guid, Dictionary<string, AbstractBlock>>();

    private readonly object _cacheLock = new object();

    public void Clear()
    {
      lock (_cacheLock)
      {
        _cache.Clear();
      }

      GC.Collect();
      GC.WaitForPendingFinalizers();
    }

    public virtual AbstractBlock CreateBlock(Selection selection, Type blockType)
    {
      lock (_cacheLock)
      {
        if (_cache.ContainsKey(selection.Guid) && _cache[selection.Guid].ContainsKey(blockType.FullName))
          return _cache[selection.Guid][blockType.FullName];

        var block = CreateNewBlock(selection, blockType);
        if (!_cache.ContainsKey(selection.Guid))
          _cache.Add(selection.Guid, new Dictionary<string, AbstractBlock>());
        _cache[selection.Guid].Add(blockType.FullName, block);
        return block;
      }
    }

    public virtual void CurrentSelectionChanged()
    {
    }

    protected AbstractBlock CreateNewBlock(Selection selection, Type blockType)
    {
      var res = Activator.CreateInstance(blockType) as AbstractBlock;
      return res == null ? null : AbstractBlock.InitializeInstance(selection.Project, selection, res);
    }
  }
}