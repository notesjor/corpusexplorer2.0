using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Utils.Filter.Queries;

namespace CorpusExplorer.Sdk.Blocks
{
  public class CooccurrenceContextBlock : AbstractBlock
  {
    public string LayerDisplayname { get; set; } = "Wort";
    public string LayerQueryA { get; set; }
    public string LayerQueryB { get; set; }

    public override void Calculate()
    {
      var selection = Selection.CreateTemporary(new[]
      {
        new FilterQuerySingleLayerAllInOneSentence
        {
          Inverse = false,
          LayerDisplayname = LayerDisplayname,
          LayerQueries =
            new[]
            {
              LayerQueryA,
              LayerQueryB
            }
        }
      });

      var sentences = selection.GetSelectedSentences();
      // 1 = SatzIndex / 2 = Worte vor / 3 = Index A / 4 = Worte dazwischen / 5 = Index B / 6 = Worte danach
      var sequences = new Dictionary<Guid, List<Tuple<int, HashSet<string>, int, HashSet<string>, int, HashSet<string>>>>();

      foreach (var x in sentences)
      {
        var layer = Selection.GetLayerOfDocument(x.Key, LayerDisplayname);
        var doc = layer?[x.Key];
        if (doc == null)
          continue;

        sequences.Add(x.Key, new List<Tuple<int, HashSet<string>, int, HashSet<string>, int, HashSet<string>>>());
        var a = layer[LayerQueryA];
        var b = layer[LayerQueryB];        

        foreach (var sI in x.Value)
        {
          var wPre = new HashSet<string>();
          var iA = -1;
          var wBetween = new HashSet<string>();
          var iB = -1;
          var wPost = new HashSet<string>();
          var s = doc[sI];

          for (var i = 0; i < s.Length; i++)
          {
            if (s[i] == a)
              iA = i;
            else if (s[i] == b)
              iB = i;
            else
            {
              if (iA == -1 && iB == -1)
                wPre.Add(layer[s[i]]);
              else if (iA > -1 && iB > -1)
                wPost.Add(layer[s[i]]);
              else
                wBetween.Add(layer[s[i]]);
            }
          }

          if (iA == -1 || iB == -1)
            continue;

          sequences[x.Key].Add(new Tuple<int, HashSet<string>, int, HashSet<string>, int, HashSet<string>>(sI, wPre, iA, wBetween, iB, wPost));
        }
      }
    }
  }
}
