using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Model.CorpusExplorer;
using CorpusExplorer.Sdk.Utils.Filter.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpusExplorer.Sdk.Blocks
{
  public class CentralSnipBlock : AbstractBlock
  {
    public string Layer1Displayname { get; set; } = "Wort";
    public string Layer2Displayname { get; set; } = "Wort";
    public IEnumerable<string> LayerQueries { get; set; }
    public int NPre { get; set; } = 3;
    public int NPost { get; set; } = 3;
    public Dictionary<string, int> FrequencyPre { get; set; } = new Dictionary<string, int>();
    public Dictionary<string, int> FrequencyPost { get; set; } = new Dictionary<string, int>();

    public override void Calculate()
    {
      var block = Selection.CreateBlock<TextLiveSearchBlock>();
      block.LayerQueries = new[] {
        new FilterQuerySingleLayerExactPhrase
          {
            LayerDisplayname = Layer1Displayname,
            LayerQueries = LayerQueries
          }
        };
      block.Calculate();

      foreach (var csel in block.SearchResults)
      {
        var corpus = Selection.GetCorpus(csel.Key);
        var layer = corpus?.GetLayers(Layer2Displayname).FirstOrDefault();
        if (layer == null)
          continue;

        foreach (var dsel in csel.Value)
        {
          var doc = layer.GetReadableDocumentByGuid(dsel.Key).Select(x => x.ToArray()).ToArray();
          if (doc == null)
            continue;

          foreach (var s in dsel.Value)
          {
            var sent = doc[s.Key];
            var q = new Queue<CeRange>(s.Value);

            while (q.Count > 0)
            {
              var item = q.Dequeue();

              var from = item.From - NPre;
              if (from < 0)
                from = 0;

              var list = new List<string>();
              for (var i = from; i < item.From; i++)
                list.Add(sent[i]);
              var key = string.Join(" ", list);
              if (FrequencyPre.ContainsKey(key))
                FrequencyPre[key]++;
              else
                FrequencyPre[key] = 1;
              list.Clear();

              from = item.To;
              var to = from + NPost;
              if (to > sent.Length)
                to = sent.Length;

              for(var i = from; i < to; i++)
                list.Add(sent[i]);
              key = string.Join(" ", list);
              if (FrequencyPost.ContainsKey(key))
                FrequencyPost[key]++;
              else
                FrequencyPost[key] = 1;
              list.Clear();
            }
          }
        }
      }
    }
  }
}
