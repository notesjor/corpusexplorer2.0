using CorpusExplorer.Sdk.Utils.DocumentProcessing.Universal.LayerState.Abstract;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Universal.LayerState
{
  public class LayerValueState : AbstractLayerState
  {
    private readonly int _valueIndex;

    public LayerValueState(string displayname, int valueIndex) : base(displayname) { _valueIndex = valueIndex; }

    public int MinimumDataLength { get; set; } = 1;

    public override bool AllowAnnotation(string[] data) { return data.Length > MinimumDataLength; }

    public override bool AllowValueChange(string[] data) { return data.Length > MinimumDataLength; }

    public override int RequestIndex(string[] data, int lastIndex) { return RequestIndex(data[_valueIndex]); }
  }
}