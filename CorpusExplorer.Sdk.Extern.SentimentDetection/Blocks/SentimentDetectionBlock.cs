using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Extern.SentimentDetection.Model;

namespace CorpusExplorer.Sdk.Extern.SentimentDetection.Blocks
{
  public class SentimentDetectionBlock : AbstractBlock
  {
    /// <summary>
    /// Key0 = DocumentGUID / Key1 = SentimentLevel / Key2 = SentimentTag / Value = SentimentTagCount
    /// </summary>
    public Dictionary<Guid, Dictionary<string, Dictionary<string, int>>> DocumentSentimentCount { get; private set; }

    /// <summary>
    /// Based on DocumentSentimentCount - Aggregate Sum-Frequency of all Documents.
    /// Key0 = SentimentLevel / Key1 = SentimentTag / Value = SentimentTagCount
    /// </summary>
    public Dictionary<string, Dictionary<string, int>> SelectionSentimentCountSum
    {
      get
      {
        var res = new Dictionary<string, Dictionary<string, int>>();
        foreach (var d in DocumentSentimentCount)
        {
          foreach (var x in d.Value)
          {
            if (!res.ContainsKey(x.Key))
              res.Add(x.Key, new Dictionary<string, int>());

            foreach (var y in x.Value)
            {
              if (res[x.Key].ContainsKey(y.Key))
                res[x.Key][y.Key] += y.Value;
              else
                res[x.Key].Add(y.Key, y.Value);
            }
          }
        }
        return res;
      }
    }

    /// <summary>
    /// Multiply the DocumentSentimentCount with Model-Rankings
    ///  Key0 = DocumentGUID / Key1 = SentimentLevel / Key2 = SentimentTag / Value = SentimentTagCount * Model.Data[Value]
    /// </summary>
    public Dictionary<Guid, Dictionary<string, Dictionary<string, double>>> DocumentSentimentValues
      =>
        DocumentSentimentCount.ToDictionary(
          d => d.Key,
          d =>
            d.Value.ToDictionary(
              x => x.Key,
              x => x.Value.ToDictionary(
                y => y.Key, 
                y => y.Value * Model.Data[x.Key][y.Key])));

    /// <summary>
    /// Based on DocumentSentimentValues - Aggregate Sum-Values of all Documents.
    /// Key0 = SentimentLevel / Key1 = SentimentTag / Value = SentimentTagCount * Model.Data[Value]
    /// </summary>
    public Dictionary<string, Dictionary<string, double>> SelectionSentimentValuesSum
      =>
        SelectionSentimentCountSum.ToDictionary(
          x => x.Key,
          x => x.Value.ToDictionary(
            y => y.Key,
            y => y.Value * Model.Data[x.Key][y.Key]));

    public string LayerDisplayname { get; set; } = "Wort";

    public SentimentDetectionTagModel Model { get; set; }

    public override void Calculate()
    {
      var data = new ConcurrentDictionary<Guid, Dictionary<string, Dictionary<string, int>>>();
      Parallel.ForEach(
        Selection,
        csel =>
        {
          Parallel.ForEach(
            csel.Value,
            dsel =>
            {
              var sel = Selection.CreateTemporary(new[] {dsel});

              var blo = sel.CreateBlock<Frequency1LayerBlock>();
              blo.LayerDisplayname = LayerDisplayname;
              blo.Calculate();

              data.TryAdd(
                dsel,
                Model.Data.ToDictionary(
                  m => m.Key,
                  m =>
                    m.Value.Where(v => blo.Frequency.ContainsKey(v.Key))
                     .ToDictionary(v => v.Key, v => (int) blo.Frequency[v.Key])));
            });
        });
      DocumentSentimentCount = data.ToDictionary(x => x.Key, x => x.Value);
    }
  }
}