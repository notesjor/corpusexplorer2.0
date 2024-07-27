using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Blocks.Interfaces;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using CorpusExplorer.Sdk.Model.Cache.Helper;
using CorpusExplorer.Sdk.Model.Cache.Helper.Exception;
using CorpusExplorer.Sdk.Model.CorpusExplorer;
using CorpusExplorer.Sdk.Utils.Filter.Queries;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

namespace CorpusExplorer.Sdk.Blocks
{
  [Serializable]
  public class Frequency2LayerSelectBlock
    : AbstractBlock
  {
    public Frequency2LayerSelectBlock()
    {
      Layer1Displayname = "POS";
      Layer2Displayname = "Wort";
    }

    /// <summary>
    ///   POS/Lemma/Wortform/Frequenz-Wörterbuch
    /// </summary>
    public Dictionary<string, double> Frequency { get; private set; }

    public string Layer1Displayname { get; set; }
    public IEnumerable<string> Layer1Queries { get; set; }
    public string Layer2Displayname { get; set; }

    public override void Calculate()
    {
      var block = Selection.CreateBlock<TextLiveSearchBlock>();
      block.LayerQueries = new[]
      {
        new FilterQuerySingleLayerExactPhrase
        {
          LayerQueries = Layer1Queries,
          LayerDisplayname = Layer1Displayname
        }
      };
      block.Calculate();

      var len = Layer1Queries.Count();

      Frequency = new Dictionary<string, double>();
      foreach (var csel in block.SearchResults)
      {
        var layer = Selection.GetCorpus(csel.Key)?.GetLayers(Layer2Displayname).FirstOrDefault();
        if (layer == null)
          continue;

        foreach (var dsel in csel.Value)
        {
          var doc = layer.GetReadableDocumentByGuid(dsel.Key).Select(x => x.ToArray()).ToArray();
          foreach (var s in dsel.Value)
          {
            var queue = new Queue<CeRange>(s.Value);
            while (queue.Count > 0)
            {
              var range = queue.Dequeue();
              var skip = range.From;
              var take = range.To - skip;

              var key = string.Join(" ", doc[s.Key].Skip(skip).Take(len));
              if (Frequency.ContainsKey(key))
                Frequency[key]++;
              else
                Frequency[key] = 1;
            }
          }
        }
      }
    }
  }
}