using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;

namespace CorpusExplorer.Sdk.Blocks
{
  public class SentenceHashBlock : AbstractSimple1LayerBlock
  {
    private readonly object _senteceLock = new object();
    public HashAlgorithm HashAlgorithm { get; set; } = SHA512.Create();

    public Dictionary<string, HashSet<Guid>> Sentences { get; set; }

    protected override void CalculateCall(
      AbstractCorpusAdapter corpus,
      AbstractLayerAdapter layer,
      Guid dsel,
      int[][] doc)
    {
      var bag = new HashSet<string>();
      var blo = new object();

      Parallel.ForEach(
        doc,
        sent =>
        {
          var set = new HashSet<string>();
          foreach (var x in sent)
            set.Add(layer[x]);
          var hsh =
            Convert.ToBase64String(
              HashAlgorithm.ComputeHash(
                Configuration.Encoding.GetBytes(
                  string.Join("|", set.OrderBy(x => x)))));

          lock (blo)
          {
            bag.Add(hsh);
          }
        });

      lock (_senteceLock)
      {
        foreach (var x in bag)
          if (Sentences.ContainsKey(x))
            Sentences[x].Add(dsel);
          else
            Sentences.Add(x, new HashSet<Guid> {dsel});
      }
    }

    protected override void CalculateCleanup() { }
    protected override void CalculateFinalize() { }

    protected override void CalculateInitProperties() { Sentences = new Dictionary<string, HashSet<Guid>>(); }
  }
}