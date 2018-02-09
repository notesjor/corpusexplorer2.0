#region

using CorpusExplorer.Sdk.Extern.Xml.DortmunderChatKorpus.Model;
using CorpusExplorer.Sdk.Extern.Xml.DortmunderChatKorpus.Serializer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Test
{
  [TestClass]
  public sealed class DortmunderChatKorpusTest
  {
    [TestMethod]
    public void SerializeTest()
    {
      var serializer = new DortmunderChatKorpusSerializer();
      var log1 = serializer.Deserialize("testdata/DortmundCK_test.xml");

      ValidateLogfile(log1);

      serializer.Serialize(log1, "testdata/DortmundCK_test_output.xml");
      var log2 = serializer.Deserialize("testdata/DortmundCK_test_output.xml");

      ValidateLogfile(log2);

      Assert.AreEqual(log1.head.creatorList.Length, log2.head.creatorList.Length);
      Assert.AreEqual(log1.head.revisionHistory.Length, log2.head.revisionHistory.Length);
      Assert.AreEqual(log1.body.Length, log2.body.Length);
    }

    private static void ValidateLogfile(logfile log)
    {
      Assert.IsNotNull(log);

      Assert.IsNotNull(log.head);
      Assert.IsNotNull(log.head.creatorList);
      Assert.AreNotEqual(0, log.head.creatorList.Length);
      Assert.IsNotNull(log.head.record);
      Assert.IsNotNull(log.head.revisionHistory);
      Assert.AreNotEqual(0, log.head.revisionHistory.Length);

      Assert.IsNotNull(log.body);
      Assert.AreNotEqual(0, log.body.Length);
      Assert.IsNotNull(log.body[0]);
      Assert.IsNotNull(log.body[0].messageBody);
    }
  }
}