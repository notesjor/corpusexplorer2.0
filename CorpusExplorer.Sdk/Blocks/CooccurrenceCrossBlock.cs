#region

using System;
using System.Collections.Generic;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.ViewModel;

#endregion

namespace CorpusExplorer.Sdk.Blocks
{
  public class CooccurrenceCrossBlock : AbstractBlock
  {
    public List<Tuple<string, string, double, double>> CrossCooccurences;

    public bool EnableExternalCooccurrencesFilter { get; set; } = true;
    public string LayerDisplayname { get; set; } = "Wort";

    public IEnumerable<string> LayerValues { get; set; }

    public override void Calculate()
    {
      var vm = new CooccurrenceViewModel { Selection = Selection, LayerDisplayname = LayerDisplayname };
      vm.Execute();

      var hash = new HashSet<string>(LayerValues);

      var coocs = vm.Search(LayerValues);
      foreach (var x in coocs)
        hash.Add(x.Key);

      CrossCooccurences = new List<Tuple<string, string, double, double>>();

      foreach (var c in coocs)
      {
        var ts = vm.Search(new[] { c.Key });

        foreach (var t in ts)
        {
          if (EnableExternalCooccurrencesFilter && !hash.Contains(t.Key))
            continue;

          CrossCooccurences.Add(new Tuple<string, string, double, double>(c.Key, t.Key, t.Value[0], t.Value[1]));
        }
      }
    }
  }
}