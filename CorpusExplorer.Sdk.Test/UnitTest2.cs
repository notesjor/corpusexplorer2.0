using System.Diagnostics;
using System.Linq;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Ecosystem;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Adapter.Corpus;
using CorpusExplorer.Sdk.Model.Extension;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CorpusExplorer.Sdk.Test
{
  [TestClass]
  public class UnitTest2
  {
    public UnitTest2()
    {
      CorpusExplorerEcosystem.InitializeMinimal();
    }

    [TestMethod]
    public void TestMethod1()
    {
      var corpus = CorpusAdapterSingleFile.Create(@"C:\Users\Jan\Documents\CorpusExplorer\Meine Korpora\WI-Korpus.cec5");

      var selection = corpus.ToSelection();

      AbstractBlock block = selection.CreateBlock<Frequency3LayerBlock>();
      var watch = new Stopwatch();
      watch.Start();
      block.Calculate();
      watch.Stop();
      var f1 = ((Frequency3LayerBlock) block).Frequency;
      Debug.WriteLine(watch.ElapsedMilliseconds);
      watch.Reset();

      block = selection.CreateBlock<Ngram1LayerPatternBlock>();
      watch.Start();
      block.Calculate();
      watch.Stop();
      var n1 = ((Ngram1LayerPatternBlock) block).NGramFrequency.ToDictionary(x => x.Key, x => (double) x.Value);
      Debug.WriteLine(watch.ElapsedMilliseconds);
      watch.Reset();

      block = selection.CreateBlock<CooccurrenceBlock>();
      watch.Start();
      block.Calculate();
      watch.Stop();
      var c1 = ((CooccurrenceBlock) block).CooccurrenceSignificance;
      Debug.WriteLine(watch.ElapsedMilliseconds);
      watch.Reset();

      Debug.WriteLine("---");

      block = selection.CreateBlock<RandomSelectionBlock>();
      ((RandomSelectionBlock) block).DocumentPercent = 50;
      block.Calculate();
      var compare = ((RandomSelectionBlock) block).RandomSelection;

      block = compare.CreateBlock<Frequency3LayerBlock>();
      block.Calculate();
      var f2 = ((Frequency3LayerBlock) block).Frequency;
      block = compare.CreateBlock<Ngram1LayerPatternBlock>();
      block.Calculate();
      var n2 = ((Ngram1LayerPatternBlock) block).NGramFrequency.ToDictionary(x => x.Key, x => (double) x.Value);
      block = compare.CreateBlock<CooccurrenceBlock>();
      block.Calculate();
      var c2 = ((CooccurrenceBlock) block).CooccurrenceSignificance;

      watch.Start();
      var fk = new[] {f1, f2}.CalculateKeyness();
      watch.Stop();
      Debug.WriteLine(watch.ElapsedMilliseconds);
      watch.Reset();
      watch.Start();
      var nk = new[] {n1, n2}.CalculateKeyness();
      watch.Stop();
      Debug.WriteLine(watch.ElapsedMilliseconds);
      watch.Reset();
      watch.Start();
      var ck = new[] {c1, c2}.CalculateKeyness();
      watch.Stop();
      Debug.WriteLine(watch.ElapsedMilliseconds);
      watch.Reset();
    }
  }
}