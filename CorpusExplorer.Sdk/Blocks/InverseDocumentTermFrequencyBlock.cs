using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;

namespace CorpusExplorer.Sdk.Blocks
{
  public class InverseDocumentTermFrequencyBlock : AbstractSimple1LayerBlock
  {
    private readonly object _lockDocumentTermFrequency = new object();
    private readonly object _lockInverseDocumentTermFrequencyReduced = new object();

    public InverseDocumentTermFrequencyBlock()
    {
      LayerDisplayname = "Wort";
      MetadataKey = "GUID";
    }

    public string MetadataKey { get; set; }

    public Dictionary<string, Dictionary<string, double>> InverseDocumentTermFrequency { get; private set; }

    public Dictionary<string, double> InverseDocumentTermFrequencyReduced { get; private set; }

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

      if (InverseDocumentTermFrequency.ContainsKey(k))
        lock (_lockDocumentTermFrequency)
          foreach (var x in res)
          {
            if (InverseDocumentTermFrequency[k].ContainsKey(x))
              InverseDocumentTermFrequency[k][x] += 1;
            else
              InverseDocumentTermFrequency[k].Add(x, 1);
          }
      else
      {
        var vals = res.ToDictionary(x => x, x => 1d);
        lock (_lockDocumentTermFrequency)
          InverseDocumentTermFrequency.Add(k, vals);
      }

      lock(_lockInverseDocumentTermFrequencyReduced)
        foreach (var x in res)
          if (InverseDocumentTermFrequencyReduced.ContainsKey(x))
            InverseDocumentTermFrequencyReduced[x] += 1;
          else
            InverseDocumentTermFrequencyReduced.Add(x, 1);
    }

    protected override void CalculateCleanup()
    {
    }

    protected override void CalculateFinalize()
    {
      string[] keys;
      var n = (double)Selection.CountDocuments;
      foreach (var x in InverseDocumentTermFrequency)
      {
        try
        {
          keys = x.Value.Keys.ToArray();
          foreach (var key in keys)
            try
            {
              x.Value[key] = Math.Log(n / x.Value[key]);
            }
            catch
            {
              // ignore
            }
        }
        catch
        {
          // ignore
        }
      }

      keys = InverseDocumentTermFrequencyReduced.Keys.ToArray();
      foreach (var key in keys)
        InverseDocumentTermFrequencyReduced[key] = Math.Log(n / InverseDocumentTermFrequencyReduced[key]);
    }

    protected override void CalculateInitProperties()
    {
      InverseDocumentTermFrequency = new Dictionary<string, Dictionary<string, double>>();
      InverseDocumentTermFrequencyReduced = new Dictionary<string, double>();
    }
  }
}