using System.IO;
using System.IO.Compression;
using CorpusExplorer.Sdk.Ecosystem;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Adapter.Corpus;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CorpusExplorer.Sdk.Test
{
  [TestClass]
  public class SerializerTest
  {
    public SerializerTest()
    {
      CorpusExplorerEcosystem.InitializeMinimal();
    }

    [TestMethod]
    public void SerializerDiffTest()
    {
      var corpus = CorpusAdapterSingleFile.Create(Path.Combine(Configuration.MyCorpora, "PEGIDA7DAYS_v2.cec5"));
      Serializer.Serialize(corpus, "test.cec5", true);

      CorpusAdapterSingleFile corpus2 = Serializer.Deserialize<CorpusAdapterSingleFile>("test.cec5");
      
      Assert.AreEqual(corpus, corpus2);
    }
  }
}