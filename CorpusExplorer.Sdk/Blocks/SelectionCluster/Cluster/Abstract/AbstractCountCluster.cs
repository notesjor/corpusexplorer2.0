﻿#region

using System;
using CorpusExplorer.Sdk.Model;

#endregion

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract
{
  public abstract class AbstractCountCluster : AbstractCluster
  {
    private readonly object _counterLock = new object();
    private object _centralValue;
    private long _counter;

    public AbstractCountCluster(Selection selection, string displayname)
    {
      Selection = selection;
      Displayname = displayname;
    }

    public bool AcceptAll { get; set; }
    public override object CentralValue => _centralValue;
    public override string Displayname { get; }

    public long Max { get; set; } = 0;

    protected Selection Selection { get; set; }

    public override bool Add(Guid documentGuid, object obj)
    {
      try
      {
        lock (_counterLock)
        {
          if (!CanAdd(documentGuid, _counter, Max))
            return false;
          _counter += Count(documentGuid);
        }

        _centralValue = obj;
        Add(documentGuid);
        return true;
      }
      catch
      {
        return false;
      }
    }

    protected abstract bool CanAdd(Guid documentGuid, long counter, long max);
    protected abstract long Count(Guid documentGuid);
  }
}