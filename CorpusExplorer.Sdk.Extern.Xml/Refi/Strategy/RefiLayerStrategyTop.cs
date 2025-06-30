using CorpusExplorer.Sdk.Extern.Xml.Refi.Strategy.Abstract;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Refi.Model;

namespace CorpusExplorer.Sdk.Extern.Xml.Refi.Strategy
{
  public class RefiLayerStrategyTop : AbstractRefiLayerStrategy
  {
    public override Dictionary<string, KeyValuePair<string, string>> GetLayerInfo(Code[] codes)
    {
      var res = new Dictionary<string, KeyValuePair<string, string>>();

      foreach (var code in codes)
      {
        var layerName = EnsureHtmlAttributes(code.name);
        res.Add(code.guid, new KeyValuePair<string, string>(layerName, ""));

        foreach (var subCode in code.Items.OfType<Code>())
          RecursiveAdd(ref res, layerName, subCode, null);
      }

      return res;
    }

    private void RecursiveAdd(ref Dictionary<string, KeyValuePair<string, string>> res, string layerName, Code subCode, string prefix)
    {
      var val = prefix == null ? subCode.name : $"{prefix} > {EnsureHtmlAttributes(subCode.name ?? "")}";

      res.Add(subCode.guid, new KeyValuePair<string, string>(layerName, val));

      var items = subCode.Items?.OfType<Code>().ToArray();
      if (items == null || items.Length == 0)
        return;
      foreach (var subSubCode in items)
        RecursiveAdd(ref res, layerName, subSubCode, val);
    }
  }
}
