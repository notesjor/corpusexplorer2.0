#region

using System.Collections.Generic;
using System.IO;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Adapter.Layer;

#endregion

namespace CorpusExplorer.Sdk.Extern.QuickIndex.Indices
{
  public static class DictionaryIndex
  {
    public static void Create(LayerAdapterWriteDirect layer, string pathToCec6)
    {
      using (var fs = new FileStream(pathToCec6 + $"_{layer.Displayname}.dic", FileMode.Create, FileAccess.Write))
      {
        DictionarySerializerHelper.Serialize(layer.ReciveRawLayerDictionary(), fs);
      }
    }

    public static Dictionary<string, int> Read(string pathToCec6, string layerDisplayname)
    {
      var dic = new Dictionary<string, int>();
      using (var fs = new FileStream(pathToCec6 + $"_{layerDisplayname}.dic", FileMode.Open, FileAccess.Read))
      {
        DictionarySerializerHelper.Deserialize(fs, ref dic);
      }

      return dic;
    }
  }
}