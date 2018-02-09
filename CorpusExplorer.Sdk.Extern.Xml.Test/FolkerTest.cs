#region

using System;
using CorpusExplorer.Sdk.Extern.Xml.Folker.Model;
using CorpusExplorer.Sdk.Extern.Xml.Folker.Serializer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Test
{
  [TestClass]
  public sealed class FolkerTest
  {
    [TestMethod]
    public void DeserializeTest()
    {
      var serializer = new FolkerSerializer();
      var folker = serializer.Deserialize("testdata/syntax_examples.flk");

      Assert.IsNotNull(folker.speakers);
      Assert.AreEqual(2, folker.speakers.Length);
      Assert.AreEqual("RIGHT", folker.speakers[0].name);
      Assert.AreEqual("RIGHT", folker.speakers[0].speakerid);
      Assert.AreEqual("syntaxbeispiele2.wav", folker.recording.path);
      Assert.AreEqual(42, folker.timeline.Length);
      Assert.AreEqual((decimal) 1.1648, Math.Round(folker.timeline[2].absolutetime, 4));
      Assert.AreEqual(21, folker.contribution.Length);
      Assert.AreEqual(13, folker.contribution[2].Items.Length);
      Assert.IsTrue(folker.contribution[2].Items[1] is pause);
      Assert.IsTrue(folker.contribution[2].Items[2] is w);
      Assert.IsTrue(((w) folker.contribution[2].Items[2]).Text[0] == "segment");
    }
  }
}