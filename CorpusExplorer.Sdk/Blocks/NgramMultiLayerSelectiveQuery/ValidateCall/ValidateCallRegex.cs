using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks.NgramMultiLayerSelectiveQuery.ValidateCall.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;

namespace CorpusExplorer.Sdk.Blocks.NgramMultiLayerSelectiveQuery.ValidateCall
{
  public sealed class ValidateCallRegex : AbstractValidateCall
  {
    private readonly HashSet<int> _hashSet;
    public ValidateCallRegex(AbstractLayerAdapter layer, string value)
    {
      var regex = new System.Text.RegularExpressions.Regex(value);
      _hashSet = new HashSet<int>(from x in layer.ReciveRawLayerDictionary() where regex.IsMatch(x.Key) select x.Value);
    }

    public override bool Validate(int index) => _hashSet.Contains(index);
  }
}