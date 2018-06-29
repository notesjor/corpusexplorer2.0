using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CorpusExplorer.Core.DocumentProcessing.Exporter.Tlv;
using CorpusExplorer.Core.DocumentProcessing.Importer.TlvXml;
using CorpusExplorer.Sdk.Model.Adapter.Corpus;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CorpusExplorer.Sdk.Test
{
  [TestClass]
  public class TlvTest
  {
    [TestMethod]
    public void TestMethod1()
    {
      var corpus1 = CorpusAdapterWriteDirect.Create(@"C:\Projekte\Magisterarbeit\CorpusExplorerNext\CorpusExplorer\CorpusExplorer.Sdk.Test\bin\Debug\EXAMPLE\demoTLV.cec6");
      var exporter = new ExporterTlv();
      var importer = new ImporterTlv();

      exporter.Export(corpus1, "EXAMPLE/TLV1.xml");
      var corpus2 = importer.Execute(new[] {"EXAMPLE/TLV1.xml"}).First();
      
      Assert.AreEqual(corpus1.CountDocuments, corpus2.CountDocuments);
      // Assert.AreEqual(corpus1.CountToken, corpus2.CountToken);

      var l1 = new HashSet<string>(corpus1.GetLayers("Wort").First().Values);
      var l2 = new HashSet<string>(corpus2.GetLayers("Wort").First().Values);

      File.WriteAllLines("EXAMPLE/TLV1.list", l1);
      File.WriteAllLines("EXAMPLE/TLV2.list", l2);

      foreach (var x in l1)
      {
        Assert.IsTrue(l2.Contains(x));
      }
      foreach (var x in l2)
      {
        Assert.IsTrue(l1.Contains(x));
      }
    }

    [TestMethod]
    public void TestMethod2()
    {
      var items1 = new HashSet<string>(File.ReadAllLines("EXAMPLE/TLV1.list"));
      var items2 = new HashSet<string>(File.ReadAllLines("EXAMPLE/TLV2.list"));

      var nonein1 = items2.Where(x => !items1.Contains(x)).ToList();
      var nonein2 = items1.Where(x => !items2.Contains(x)).ToList();

      Assert.IsTrue(nonein1.Count == 0);
      Assert.IsTrue(nonein2.Count == 0);
    }
  }
}
