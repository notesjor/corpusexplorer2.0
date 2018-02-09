using System;
using System.Collections.Generic;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;

namespace CorpusExplorer.Sdk.Blocks
{
  public class DocumentWordlistBlock : AbstractSimple1LayerBlock
  {
    private readonly object _lock = new object();
    public DocumentWordlistBlock() { LayerDisplayname = "Wort"; }

    public Dictionary<Guid, HashSet<string>> Wordlist { get; set; }

    protected override void CalculateCall(
      AbstractCorpusAdapter corpus,
      AbstractLayerAdapter layer,
      Guid dsel,
      int[][] doc)
    {
      var dic = new HashSet<string>();

      foreach (var s in doc)
      foreach (var w in s)
        dic.Add(layer[w]);

      lock (_lock)
      {
        Wordlist.Add(dsel, dic);
      }
    }

    protected override void CalculateCleanup() { }

    protected override void CalculateFinalize() { }

    protected override void CalculateInitProperties() { Wordlist = new Dictionary<Guid, HashSet<string>>(); }
  }
}