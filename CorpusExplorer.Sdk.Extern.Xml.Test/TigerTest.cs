#region

using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Tiger.Extension;
using CorpusExplorer.Sdk.Extern.Xml.Tiger.Model;
using CorpusExplorer.Sdk.Extern.Xml.Tiger.Serializer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Test
{
  [TestClass]
  public sealed class TigerTest
  {
    [TestMethod]
    public void TigerSerializerTest()
    {
      var serializer = new TigerSerializer();

      var obj1 = serializer.Deserialize("testdata/tiger_sample.xml");
      ValidateObject(obj1);
    }

    private static void ValidateObject(corpus obj)
    {
      Assert.IsNotNull(obj);
      Assert.IsNotNull(obj.head);
      Assert.IsNotNull(obj.head.annotation);
      Assert.IsNotNull(obj.head.annotation.edgelabel);
      Assert.IsNotNull(obj.head.annotation.feature);
      Assert.IsNotNull(obj.head.annotation.secedgelabel);
      Assert.AreNotEqual(0, obj.head.annotation.edgelabel.Length);
      Assert.AreNotEqual(0, obj.head.annotation.feature.Length);
      Assert.AreNotEqual(0, obj.head.annotation.secedgelabel.Length);
      // Assert.IsNotNull(obj.head.external); - Ist im TigerSearch-Korpus null
      Assert.IsNotNull(obj.head.meta);
      Assert.AreNotEqual(0, obj.body.Length);
      Assert.AreEqual(10, obj.body.Length); // 10 da Sample (tiger_sample.xml) auf 10-<s>-Tags gekürzt wurde
      // Erweiterungsmethoden
      Assert.AreEqual(0, obj.GetChildSubcorpora().Count());
      Assert.AreEqual(10, obj.GetChildSentences().Count());
      // 10 da Sample (tiger_sample.xml) auf 10-<s>-Tags gekürzt wurde

      var sentences = obj.GetChildSentences();
      foreach (var s in sentences)
      {
        Assert.IsNotNull(s.graph);
        Assert.IsNotNull(s.graph.root);
        Assert.IsNotNull(s.graph.nonterminals);
        Assert.IsNotNull(s.graph.terminals);
        Assert.AreNotEqual(0, s.graph.root.Length);
        Assert.AreNotEqual(0, s.graph.nonterminals.Length);
        Assert.AreNotEqual(0, s.graph.terminals.Length);
        Assert.IsNotNull(s.id);
        Assert.IsNull(s.matches);
      }
    }
  }
}