using System;
using System.Collections.Generic;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;

namespace CorpusExplorer.Sdk.Blocks
{
  public class DocumentFrequencyDictionaryBlock : AbstractSimple1LayerBlock
  {
    private readonly object _lock = new object();

    public DocumentFrequencyDictionaryBlock()
    {
      LayerDisplayname = "Wort";
    }

    public Dictionary<Guid, Dictionary<string, double>> DocumentDictionaries { get; set; }

    public Dictionary<Guid, double> DocumentSizeInSentences { get; set; }

    public Dictionary<Guid, double> DocumentSizeInToken { get; set; }

    protected override void CalculateCall(
      AbstractCorpusAdapter corpus,
      AbstractLayerAdapter layer,
      Guid dsel,
      int[][] doc)
    {
      var dic = new Dictionary<string, double>();
      var sen = 0;
      var tok = 0;

      foreach (var s in doc)
      {
        sen++;
        tok += s.Length;

        foreach (var w in s)
          if (dic.ContainsKey(layer[w]))
            dic[layer[w]]++;
          else
            dic.Add(layer[w], 1);
      }

      lock (_lock)
      {
        DocumentDictionaries.Add(dsel, dic);
        DocumentSizeInSentences.Add(dsel, sen);
        DocumentSizeInToken.Add(dsel, tok);
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
      DocumentDictionaries = new Dictionary<Guid, Dictionary<string, double>>();
      DocumentSizeInSentences = new Dictionary<Guid, double>();
      DocumentSizeInToken = new Dictionary<Guid, double>();
    }
  }
}