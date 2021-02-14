#region

using CorpusExplorer.Sdk.Extern.Xml.Exmaralda.Simple.Model;
using CorpusExplorer.Sdk.Extern.Xml.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Test
{
  [TestClass]
  public sealed class ExmaraldaTest
  {
    [TestMethod]
    public void ExbReadWriteReadTest()
    {
      var obj1 = XmlSerializerHelper.Deserialize<basictranscription>("testdata/Helge_Schneider_Arbeitsamt.exb");
      Assert.IsNotNull(obj1);

      XmlSerializerHelper.Serialize(obj1, "testdata/Helge_Schneider_Arbeitsamt2.exb");

      var obj2 = XmlSerializerHelper.Deserialize<basictranscription>("testdata/Helge_Schneider_Arbeitsamt2.exb");
      Assert.IsNotNull(obj2);

      Assert.AreEqual(obj1.basicbody.tier.Length, obj2.basicbody.tier.Length);
    }

    [TestMethod]
    public void ReadExbFileTest()
    {
      var obj = XmlSerializerHelper.Deserialize<basictranscription>("testdata/Helge_Schneider_Arbeitsamt.exb");

      Assert.IsNotNull(obj);
    }
  }
}