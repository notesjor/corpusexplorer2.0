#region

using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Db.RocksDb;
using CorpusExplorer.Sdk.Model.Adapter.Layer;

#endregion

namespace CorpusExplorer.Sdk.Extern.QuickIndexRocks.Indices
{
  public static class DictionaryIndex
  {
    public static void Create(LayerAdapterWriteDirect layer, string pathToCec6)
    {
      var res = layer.ReciveRawLayerDictionary().ToDictionary(x => x.Key, x => x.Value);
      Save(pathToCec6, layer.Displayname, ref res);
    }

    public static void Save(string pathToCec6, string layerDisplayname, ref Dictionary<string, int> res)
    {
      var db = new EasyRocksDb(pathToCec6 + $"_{layerDisplayname}.dicRDB", true);
      var dbr = new EasyRocksDb(pathToCec6 + $"_{layerDisplayname}.dicrRDB", true);

      var cF = new Dictionary<string,string>();
      var cR = new Dictionary<string, string>();

      foreach (var x in res)
      {
        cF.Add(x.Key, x.Value.ToString());
        cR.Add(x.Value.ToString(), x.Key);

        if (cF.Count % 10000 == 0)
        {
          db.PutBatch(cF);
          dbr.PutBatch(cR);

          cF.Clear();
          cR.Clear();
        }
      }

      if (cF.Count > 0)
      {
        db.PutBatch(cF);
        dbr.PutBatch(cR);
      }

      cF.Clear();
      cR.Clear();
    }

    public static EasyRocksDb ReadDic(string pathToCec6, string layerDisplayname)
      => new EasyRocksDb(pathToCec6 + $"_{layerDisplayname}.dicRDB", false);

    public static EasyRocksDb ReadDicRes(string pathToCec6, string layerDisplayname) 
      => new EasyRocksDb(pathToCec6 + $"_{layerDisplayname}.dicrRDB", false);
  }
}