using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.CorpusExplorer;

namespace CorpusExplorer.Sdk.Blocks
{
  public class CooccurrenceSecondLevelProfileBlock : AbstractBlock
  {
    public string LayerValue { get; set; }
    public string LayerDisplayname { get; set; } = "Wort";
    public Dictionary<string, Dictionary<string, double>> CooccurrenceDuos { get; set; }

    public override void Calculate()
    {
      if (string.IsNullOrEmpty(LayerValue))
        return;

      CooccurrenceDuos = new Dictionary<string, Dictionary<string, double>>();
      var dic = GetDictionary();
      if (dic.Count == 0 || !dic.ContainsKey(LayerValue) || dic[LayerValue].Count < 1)
        return;

      var keys = new HashSet<string>(dic[LayerValue].Select(x => x.Key));
      var cetp = new CeDictionary(keys);

      foreach (var key in keys)
      {
        if (!dic.ContainsKey(key))
          continue;

        var idxKey = cetp[key];
        foreach (var cooc in dic[key].Where(x => keys.Contains(x.Key)))
        {
          var idxCoc = cetp[cooc.Key];
          if (idxKey == idxCoc)
            continue;

          var a = idxKey > idxCoc ? key : cooc.Key;
          var b = idxKey > idxCoc ? cooc.Key : key;

          if (CooccurrenceDuos.ContainsKey(a))
          {
            if (CooccurrenceDuos[a].ContainsKey(b))
            {
              if (cooc.Value > CooccurrenceDuos[a][b])
                CooccurrenceDuos[a][b] = cooc.Value;
            }
            else
            {
              CooccurrenceDuos[a].Add(b, cooc.Value);
            }
          }
          else
          {
            CooccurrenceDuos.Add(a, new Dictionary<string, double> {{b, cooc.Value}});
          }
        }
      }
    }

    private Dictionary<string, Dictionary<string, double>> GetDictionary()
    {
      var block = Selection.CreateBlock<CooccurrenceBlock>();
      block.LayerDisplayname = LayerDisplayname;
      block.Calculate();
      return block.CooccurrenceSignificance.CompleteDictionaryToFullDictionary();
    }
  }
}