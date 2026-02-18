using System.Linq;
using CorpusExplorer.Sdk.Utils.CorpusManipulation.CorpusMergerTransformation.Abstract;

namespace CorpusExplorer.Sdk.Utils.CorpusManipulation.CorpusMergerTransformation
{
  public class CorpusMergerTransformationRemoveLongToken : AbstractCorpusMergerTransformation
  {
    public int MaxTokenLength { get; set; } = 50;
    public string TokenReplacement { get; set; } = "###";

    public override string[][] Transform(string[][] input)
    {
      return input.Select(arr => arr.Select(s => s.Length > MaxTokenLength ? TokenReplacement : s).ToArray()).ToArray();
    }
  }
}