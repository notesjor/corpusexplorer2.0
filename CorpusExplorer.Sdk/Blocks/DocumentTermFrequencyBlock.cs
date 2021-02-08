using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;

namespace CorpusExplorer.Sdk.Blocks
{
  public class DocumentTermFrequencyBlock : AbstractSimple1LayerBlock
  {
    private readonly object _lockDocumentTermFrequency = new object();

    public DocumentTermFrequencyBlock()
    {
      LayerDisplayname = "Wort";
      MetadataKey = "GUID";
    }

    public string MetadataKey { get; set; }

    public Dictionary<string, Dictionary<string, double>> DocumentTermFrequency { get; set; }

    public Dictionary<string, double> DocumentTermFrequencyReduced
    {
      get
      {
        var res = new Dictionary<string, double>();

        foreach (var v in DocumentTermFrequency.SelectMany(doc => doc.Value))
          if (res.ContainsKey(v.Key))
            res[v.Key] += v.Value;
          else
            res.Add(v.Key, v.Value);

        return res;
      }
    }

    protected override void CalculateCall(
      AbstractCorpusAdapter corpus,
      AbstractLayerAdapter layer,
      Guid dsel,
      int[][] doc)
    {
      var res = new HashSet<string>();
      var sum = 0;
      foreach (var s in doc)
      {
        foreach (var w in s)
        {
          res.Add(layer[w]);
        }

        sum += s.Length;
      }

      var k = corpus.GetDocumentMetadata(dsel, MetadataKey, string.Empty);

      if (DocumentTermFrequency.ContainsKey(k))
        lock (_lockDocumentTermFrequency)
          foreach (var x in res)
          {
            if (DocumentTermFrequency[k].ContainsKey(x))
              DocumentTermFrequency[k][x] += 1;
            else
              DocumentTermFrequency[k].Add(x, 1);
          }
      else
      {
        var vals = res.ToDictionary(x => x, x => 1d);
        lock (_lockDocumentTermFrequency)
          DocumentTermFrequency.Add(k, vals);
      }
    }

    protected override void CalculateCleanup()
    {
    }

    protected override void CalculateFinalize()
    {
    }

    protected override void CalculateInitProperties()
    {
      DocumentTermFrequency = new Dictionary<string, Dictionary<string, double>>();
    }
  }
}