using System.Linq;
using CorpusExplorer.Sdk.Utils.CorpusManipulation.CorpusMergerTransformation.Abstract;

namespace CorpusExplorer.Sdk.Utils.CorpusManipulation.CorpusMergerTransformation
{
  public class CorpusMergerTransformationLowercase : AbstractCorpusMergerTransformation
  {
    public override string[][] Transform(string[][] input)
    {
      return input.Select(arr => arr.Select(s => s.ToLower()).ToArray()).ToArray();
    }
  }
}
