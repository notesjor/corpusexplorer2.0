#region

using System.Linq;
using CorpusExplorer.Sdk.Utils.Filter;
using CorpusExplorer.Sdk.Utils.Filter.Queries;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace CorpusExplorer.Sdk.Test
{
  [TestClass]
  public class QueryParserTest
  {
    [TestMethod]
    public void Test()
    {
      var t1 = QueryParser.Parse("M.Autor:>Jan Oliver Rüdiger");
      Assert.IsTrue(t1 is FilterQueryMetaContains);
      Assert.AreEqual(((FilterQueryMetaContains) t1).MetaLabel, "Autor");
      Assert.AreEqual(((FilterQueryMetaContains)t1).MetaValues.First(), "Jan Oliver Rüdiger");

      var t2 = QueryParser.Parse("T~Wort:>Jan Oliver Rüdiger");
      Assert.IsTrue(t2 is FilterQuerySingleLayerAnyMatch);
      Assert.AreEqual(((FilterQuerySingleLayerAnyMatch)t2).LayerDisplayname, "Wort");
      var qs = ((FilterQuerySingleLayerAnyMatch) t2).LayerQueries.ToArray();
      Assert.AreEqual(qs.Length, 3);
      Assert.AreEqual(qs[0], "Jan");
      Assert.AreEqual(qs[1], "Oliver");
      Assert.AreEqual(qs[2], "Rüdiger");
    }
  }
}