namespace CorpusExplorer.Sdk.Utils.CorpusManipulation.CorpusMergerTransformation.Abstract
{
  public abstract class AbstractCorpusMergerTransformation
  {
    public string LayerDisplayname { get; set; }

    public abstract string[][] Transform(string[][] input);
  }
}
