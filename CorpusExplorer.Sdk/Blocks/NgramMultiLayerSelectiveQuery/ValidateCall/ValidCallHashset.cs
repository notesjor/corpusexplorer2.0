using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks.NgramMultiLayerSelectiveQuery.ValidateCall.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;

namespace CorpusExplorer.Sdk.Blocks.NgramMultiLayerSelectiveQuery.ValidateCall
{
  public sealed class ValidCallHashset : AbstractValidateCall
  {
    private readonly HashSet<int> _hashSet;
    private ValidCallHashset(HashSet<int> hashSet) => _hashSet = hashSet;
    public static ValidCallHashset CreateContains(AbstractLayerAdapter layer, string value)
      => new ValidCallHashset(new HashSet<int>(layer.Values.Where(x => x.Contains(value)).Select(x => layer[x])));
    public static ValidCallHashset CreateStartsWith(AbstractLayerAdapter layer, string value)
      => new ValidCallHashset(new HashSet<int>(layer.Values.Where(x => x.StartsWith(value)).Select(x => layer[x])));
    public static ValidCallHashset CreateEndsWith(AbstractLayerAdapter layer, string value)
      => new ValidCallHashset(new HashSet<int>(layer.Values.Where(x => x.EndsWith(value)).Select(x => layer[x])));
    public override bool Validate(int index) => _hashSet.Contains(index);
  }
}