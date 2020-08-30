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

    protected override void CalculateCall(
      AbstractCorpusAdapter corpus,
      AbstractLayerAdapter layer,
      Guid dsel,
      int[][] doc)
    {
      var res = new Dictionary<string, double>();
      var sum = 0;
      foreach (var s in doc)
      {
        foreach (var w in s)
        {
          var key = layer[w];
          if (res.ContainsKey(key))
            res[key]++;
          else
            res.Add(key, 1);
        }

        sum += s.Length;
      }

      var k = corpus.GetDocumentMetadata(dsel, MetadataKey, string.Empty);
      var v = res.ToDictionary(x => x.Key, x => x.Value / sum);

      lock (_lockDocumentTermFrequency)
      {
        if (DocumentTermFrequency.ContainsKey(k))
          foreach (var x in v)
          {
            if (DocumentTermFrequency[k].ContainsKey(x.Key))
              DocumentTermFrequency[k][x.Key] += x.Value;
            else
              DocumentTermFrequency[k].Add(x.Key, x.Value);
          }
        else
          DocumentTermFrequency.Add(k, v);
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