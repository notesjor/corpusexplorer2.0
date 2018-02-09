#region

using System.IO;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Json.TwitterStream.Reader;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace CorpusExplorer.Sdk.Extern.Json.Test
{
  [TestClass]
  public sealed class UnitTest1
  {
    [TestMethod]
    public void LoadMultiStreamMessage()
    {
      var dr = new TwitterDataReader();
      var stms = dr.ReadData(Directory.GetFiles("testdata/", "*.json")).ToArray();
      Assert.IsNotNull(stms);
      //Assert.AreEqual(9, stms.Count());
    }

    [TestMethod]
    public void LoadSingleStreamMessage()
    {
      var dr = new TwitterDataReader();
      var stms = dr.ReadData("testdata/1.json");
      Assert.IsNotNull(stms);
      var stm = stms.FirstOrDefault();
      Assert.IsNotNull(stm);
    }
  }
}