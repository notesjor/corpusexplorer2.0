#region

using System;
using System.IO;
using CorpusExplorer.Sdk.Extern.Xml.Exmaralda.Serializer;
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
      var serializer = new ExmaraldaExbSerializer();

      var obj1 = serializer.Deserialize("testdata/Helge_Schneider_Arbeitsamt.exb");
      Assert.IsNotNull(obj1);

      serializer.Serialize(obj1, "testdata/Helge_Schneider_Arbeitsamt2.exb");

      var obj2 = serializer.Deserialize("testdata/Helge_Schneider_Arbeitsamt2.exb");
      Assert.IsNotNull(obj2);

      Assert.AreEqual(obj1.basicbody.tier.Length, obj2.basicbody.tier.Length);
    }

    [TestMethod]
    public void ExsReadWriteReadTest()
    {
      var serializer = new ExmaraldaExsSerializer();

      var obj1 = serializer.Deserialize("testdata/Helge_Schneider_Arbeitsamt_s.exs");
      Assert.IsNotNull(obj1);

      serializer.Serialize(obj1, "testdata/Helge_Schneider_Arbeitsamt_s2.exs");

      var obj2 = serializer.Deserialize("testdata/Helge_Schneider_Arbeitsamt_s2.exs");
      Assert.IsNotNull(obj2);

      Assert.AreEqual(obj1.segmentedbody.segmentedtier.Length, obj2.segmentedbody.segmentedtier.Length);
    }

    [TestMethod]
    public void ReadExbFileTest()
    {
      var serializer = new ExmaraldaExbSerializer();

      var obj = serializer.Deserialize("testdata/Helge_Schneider_Arbeitsamt.exb");

      Assert.IsNotNull(obj);
    }

    [TestMethod]
    public void ReadExsFileTest()
    {
      var serializer = new ExmaraldaExsSerializer();

      var obj = serializer.Deserialize("testdata/Helge_Schneider_Arbeitsamt_s.exs");

      Assert.IsNotNull(obj);
    }

    [TestMethod]
    public void WrongSerializerTest()
    {
      var correctExceptionThrowed = false;

      try
      {
        var serializer = new ExmaraldaExsSerializer();

        var obj = serializer.Deserialize("testdata/Helge_Schneider_Arbeitsamt.exb");

        Assert.IsNotNull(obj);
      }
      catch (FileLoadException)
      {
        correctExceptionThrowed = true;
      }
      // ReSharper disable once EmptyGeneralCatchClause
      catch (Exception) {}

      Assert.IsTrue(correctExceptionThrowed);
    }
  }
}