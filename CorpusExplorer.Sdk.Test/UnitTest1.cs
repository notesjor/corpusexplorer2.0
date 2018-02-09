using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Core.DocumentProcessing.Scraper.Html;
using CorpusExplorer.Core.DocumentProcessing.Tagger.TreeTagger;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Ecosystem;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Extension;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Builder;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Cleanup;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CorpusExplorer.Sdk.Test
{
  [TestClass]
  public class UnitTest1
  {
    [TestMethod]
    public void LiveParsingTest()
    {
      var proj = CorpusExplorerEcosystem.InitializeMinimal();

      var scraper = new LexisNexisScraper();
      scraper.Input.Enqueue("EXAMPLE/LexisNexisDEMO.HTML");
      scraper.Execute();
      var cleaner1 = new StandardCleanup {Input = scraper.Output};
      cleaner1.Execute();

      var docs1 = new ConcurrentQueue<Dictionary<string, object>>(cleaner1.Output.ToArray());

      var tt1 = new ClassicTreeTagger
      {
        Input = docs1,
        LanguageSelected = "Deutsch",
        CorpusBuilder = new CorpusBuilderSingleFile()
      };
      tt1.Execute();
      AbstractCorpusAdapter corp1 = tt1.Output.First();
      Assert.IsTrue(tt1.Output.TryDequeue(out corp1));

      proj.Add(corp1);

      var sel1 = corp1.ToSelection();
      var block1 = sel1.CreateBlock<Frequency1LayerBlock>();
      var freq1 = block1.Frequency;

      var docs2 = new ConcurrentQueue<Dictionary<string, object>>(cleaner1.Output.ToArray());

      var tt2 = new ClassicTreeTagger
      {
        Input = docs2,
        LanguageSelected = "Deutsch",
        CorpusBuilder = new CorpusBuilderSingleFile()
      };
      tt2.Execute();
      AbstractCorpusAdapter corp2 = tt2.Output.First();
      Assert.IsTrue(tt2.Output.TryDequeue(out corp2));
      proj.Add(corp2);

      var sel2 = corp2.ToSelection();
      var block2 = sel2.CreateBlock<Frequency1LayerBlock>();
      var freq2 = block2.Frequency;

      foreach (var f in freq1) Assert.IsFalse(freq2.ContainsKey(f.Key));
      foreach (var f in freq2) Assert.IsFalse(freq1.ContainsKey(f.Key));
      foreach (var f in freq1) Assert.AreNotEqual(f.Value, freq2[f.Key]);
    }
  }
}