using System;
using System.Collections.Generic;
using CorpusExplorer.Sdk.Model.Adapter.Layer;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Universal.LayerState.Abstract
{
  public abstract class AbstractLayerState
  {
    private readonly object _cacheLock = new object();

    protected AbstractLayerState(string displayname)
    {
      Displayname = displayname;
      Documents = new Dictionary<Guid, int[][]>();
      Cache = new Dictionary<string, int>();
    }

    public Dictionary<string, int> Cache { get; set; }
    public string Displayname { get; }
    public Dictionary<Guid, int[][]> Documents { get; set; }
    public abstract bool AllowAnnotation(string[] level1);
    public abstract bool AllowValueChange(string[] level1);
    public abstract int RequestIndex(string[] level1, int lastIndex);

    public LayerAdapterSingleFile ToSingleFileLayer()
    {
      var res = LayerAdapterSingleFile.Create(Documents, Cache, new Dictionary<string, object>(), Displayname);
      Documents = new Dictionary<Guid, int[][]>();
      Cache = new Dictionary<string, int>();
      return res;
    }

    protected int RequestIndex(string data)
    {
      lock (_cacheLock)
      {
        if (Cache.ContainsKey(data))
          return Cache[data];

        var res = Cache.Count;
        Cache.Add(data, res);
        return res;
      }
    }
  }
}