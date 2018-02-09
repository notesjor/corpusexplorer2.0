using CorpusExplorer.Sdk.Ecosystem;
using CorpusExplorer.Sdk.Extern.SentimentDetection.Blocks;
using CorpusExplorer.Sdk.Extern.SentimentDetection.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Adapter.Corpus;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace CorpusExplorer.Sdk.Extern.SentimentDetection.Test
{
  [TestClass]
  public class UnitTest1
  {
    [TestMethod]
    public void TestMethod1()
    {
      var project = CorpusExplorerEcosystem.InitializeMinimal();
      project.Add(CorpusAdapterSingleFile.Create(@"C:\Users\Jan\Documents\CorpusExplorer\Meine Korpora\Kita-Streik.cec5"));
      var selection = project.SelectAll;

      var block = selection.CreateBlock<SentimentDetectionBlock>();
      block.Model = SentimentDetectionTagModel.Load("iggsa.sdmodel");
      block.Calculate();

      Assert.IsNotNull(block.SelectionSentimentCountSum);

      File.WriteAllText("test.csv", block.SelectionSentimentCountSum.ToDataTable("Level", "Tag", "Count").ToCsv());
    }
  }
}