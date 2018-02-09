#region

using System.IO;
using CorpusExplorer.Sdk.Ecosystem;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Extern.Plaintext.ClanChildes;
using CorpusExplorer.Sdk.Extern.Plaintext.EasyHashtagSeparation;
using CorpusExplorer.Sdk.Extern.Plaintext.RawMailMsg;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace CorpusExplorer.Sdk.Extern.Plaintext.Test
{
  [TestClass]
  public sealed class UnitTest1
  {
    public UnitTest1()
    {
      CorpusExplorerEcosystem.InitializeMinimal();
    }

    [TestMethod]
    public void EasyCexImporterTest()
    {
      var importer = new ClanChildesImporter();
      var corpus = importer.Execute(new[] {"testdata/dummyCLAN.cex"});

      Assert.IsNotNull(corpus);
    }

    [TestMethod]
    public void EasyHashtagSeparationScraperTest()
    {
      var files = Directory.GetFiles("testdata", "*.txt");
      var scraper = new EasyHashtagSeparationScraper();
      foreach (var file in files)
        scraper.Input.Enqueue(file);
      scraper.Execute();
      var result = scraper.Output;

      Assert.IsNotNull(result);
      Assert.AreEqual(9, result.Count);
    }

    [TestMethod]
    public void EasyMsgScraperTest()
    {
      var files = Directory.GetFiles("testdata", "*.msg");
      for (var i = 0; i < files.Length; i++)
        files[i] = Path.GetFullPath(files[i]);

      var scraper = new RawMsgMsgScraper();
      foreach (var file in files)
        scraper.Input.Enqueue(file);
      scraper.Execute();
      var result = scraper.Output;

      Assert.IsNotNull(result);
      Assert.AreEqual(9, result.Count);
    }
  }
}