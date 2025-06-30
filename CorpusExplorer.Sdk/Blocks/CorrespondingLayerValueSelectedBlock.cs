using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Ecosystem.Model;

namespace CorpusExplorer.Sdk.Blocks
{
  public class CorrespondingLayerValueSelectedBlock : AbstractBlock
  {
    private readonly object _lock = new object();

    public IEnumerable<string> LayerValues { get; set; } = new HashSet<string>();

    public Dictionary<string, HashSet<string>> CorrespondingLayerValues { get; set; } = new Dictionary<string, HashSet<string>>();

    public string Layer1Displayname { get; set; } = "Wort";
    public string Layer2Displayname { get; set; } = "POS";

    public override void Calculate()
    {
      Parallel.ForEach(Selection.CorporaAndDocumentGuids, Configuration.ParallelOptions, csel =>
      {
        var corpus = Project.GetCorpus(csel.Key);
        if (corpus == null)
          return;

        var layer1 = corpus.GetLayers(Layer1Displayname).FirstOrDefault();
        var layer2 = corpus.GetLayers(Layer2Displayname).FirstOrDefault();
        if (layer1 == null || layer2 == null)
          return;

        var indexes = new HashSet<int>(LayerValues.Select(x => layer1[x]).Where(x => x > -1));
        if (indexes.Count == 0)
          return;

        var rdic1 = indexes.ToDictionary(x => x, x => layer1[x]);

        var cindexes = new Dictionary<int, HashSet<int>>();
        var clock = new object();

        Parallel.ForEach(csel.Value, Configuration.ParallelOptions, dsel =>
        {
          var doc1 = layer1[dsel];
          var doc2 = layer2[dsel];

          if (doc1 == null || doc2 == null || doc1.Length != doc2.Length)
            return;

          for (var i = 0; i < doc1.Length; i++)
            for (var j = 0; j < doc1[i].Length; j++)
              if (indexes.Contains(doc1[i][j]))
              {
                if (i > doc2.Length || j > doc2[i].Length)
                  break;

                lock (clock)
                {
                  if (!cindexes.ContainsKey(doc1[i][j]))
                    cindexes[doc1[i][j]] = new HashSet<int>();
                  cindexes[doc1[i][j]].Add(doc2[i][j]);
                }
              }
        });

        var cdic = cindexes.ToDictionary(x => rdic1[x.Key], x => x.Value.Select(y => layer2[y]).ToArray());

        lock (_lock)
          foreach (var x in cdic)
          {
            if (!CorrespondingLayerValues.ContainsKey(x.Key))
              CorrespondingLayerValues[x.Key] = new HashSet<string>();
            CorrespondingLayerValues[x.Key].UnionWith(x.Value);
          }
      });
    }
  }
}