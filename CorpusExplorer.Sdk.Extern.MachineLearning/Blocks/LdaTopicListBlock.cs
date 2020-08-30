using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Extern.MachineLearning.Blocks.Abstract;

namespace CorpusExplorer.Sdk.Extern.MachineLearning.Blocks
{
  public class LdaTopicListBlock : AbstractLdaBlock
  {
    public Dictionary<string, float>[] Topics { get; private set; }

    public float Treshold { get; set; } = 1;

    protected override void PostCalculate()
    {
      Topics = new Dictionary<string, float>[NumberOfTopics];
      for (var i = 0; i < Topics.Length; i++)
        Topics[i] = new Dictionary<string, float>();

      foreach (var value in Selection.GetLayerValues(LayerDisplayname))
      {
        var tmp = Predict(value);

        for (var i = 0; i < tmp.Length; i++)
          if (tmp[i] >= Treshold)
            Topics[i].Add(value, tmp[i]);
      }
    }
  }
}
