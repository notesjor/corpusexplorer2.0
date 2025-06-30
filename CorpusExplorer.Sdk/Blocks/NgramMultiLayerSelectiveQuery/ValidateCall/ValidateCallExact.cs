using CorpusExplorer.Sdk.Blocks.NgramMultiLayerSelectiveQuery.ValidateCall.Abstract;

namespace CorpusExplorer.Sdk.Blocks.NgramMultiLayerSelectiveQuery.ValidateCall
{
  public sealed class ValidateCallExact : AbstractValidateCall
  {
    private readonly int _index;
    public ValidateCallExact(int index) => _index = index;
    public override bool Validate(int index) => _index == index;
  }
}