#region

using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using CorpusExplorer.Core.DocumentProcessing.Scraper.Html;
using CorpusExplorer.Core.DocumentProcessing.Tagger.RawText;
using CorpusExplorer.Core.DocumentProcessing.Tagger.TreeTagger;
using CorpusExplorer.Sdk.Ecosystem;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Extern.Xml.LexisNexis;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace CorpusExplorer.Sdk.Test
{
  /// <summary>
  ///   The silly corpus exploration test.
  /// </summary>
  [TestClass]
  public class ParserTest
  {
    public ParserTest()
    {
      CorpusExplorerEcosystem.InitializeMinimal();
      var path = @"C:\Projekte\Magisterarbeit\CorpusExplorerNext\CorpusExplorer\CorpusExplorer.Sdk.Test\output";
      if (!Directory.Exists(path)) Directory.CreateDirectory(path);
    }

    /// <summary>
    ///   The explore frequency.
    /// </summary>
    [TestMethod]
    public void ParserCompareTest()
    {
      var ln = new NexisComScraper();
      ln.Input.Enqueue(
        "C:/Projekte/Magisterarbeit/CorpusExplorerNext/CorpusExplorer/CorpusExplorer.Sdk.Test/EXAMPLE/LexisNexisDEMO.HTML");
      ln.Execute();
      var watch = new Stopwatch();

      var tt1Queue = new ConcurrentQueue<Dictionary<string, object>>(ln.Output.ToArray());

      // TreeTagger

      var tt1 = new ClassicTreeTagger
      {
        LanguageSelected = "Deutsch",
        Input = tt1Queue
      };

      watch.Start();
      tt1.Execute();
      AbstractCorpusAdapter corpus1;
      Assert.IsTrue(tt1.Output.TryDequeue(out corpus1));

      watch.Stop();
      Debug.WriteLine("Classic: " + watch.ElapsedMilliseconds);
      watch.Reset();

      //corpus1.Save("C:/Users/Jan/Desktop/classic.cec5");

      Assert.AreNotEqual(0, corpus1.Layers.Count());

      // NoneParser
      var tt0Queue = new ConcurrentQueue<Dictionary<string, object>>(ln.Output.ToArray());

      var tt0 = new RawTextTagger
      {
        Input = tt0Queue
      };

      watch.Start();
      tt0.Execute();

      AbstractCorpusAdapter corpus0;
      Assert.IsTrue(tt0.Output.TryDequeue(out corpus0));

      watch.Stop();
      Debug.WriteLine("Classic: " + watch.ElapsedMilliseconds);
      watch.Reset();

      corpus0.Save("C:/Users/Jan/Desktop/zeroParsing.cec5");

      Assert.AreNotEqual(0, corpus0.Layers.Count());
      Assert.AreNotEqual(0, corpus0.Layers.First().CountDocuments);
    }
  }
}