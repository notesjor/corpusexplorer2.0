#region

using CorpusExplorer.Sdk.Blocks.Cooccurrence;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace CorpusExplorer.Sdk.Test
{
  /// <summary>
  ///   The significant test.
  /// </summary>
  [TestClass]
  public class SignificantTest
  {
    /// <summary>
    ///   The test method 1.
    /// </summary>
    [TestMethod]
    public void TestMethod1()
    {
      var sig = new PoissonSignificance();
      TestIt(sig);
    }

    /// <summary>
    ///   The test method 2.
    /// </summary>
    [TestMethod]
    public void TestMethod2()
    {
      var sig = new ChiSquaredSignificance();
      TestIt(sig);
    }

    /// <summary>
    ///   The test method 3.
    /// </summary>
    [TestMethod]
    public void TestMethod3()
    {
      var sig = new LogLikelihoodSignificance();
      TestIt(sig);
    }

    /// <summary>
    ///   The test it.
    /// </summary>
    /// <param name="sig">
    ///   The sig.
    /// </param>
    private void TestIt(ISignificance sig) { }
  }
}