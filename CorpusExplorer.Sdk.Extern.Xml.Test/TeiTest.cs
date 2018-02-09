#region

using CorpusExplorer.Sdk.Extern.Xml.Tei.Bare.Serializer;
using CorpusExplorer.Sdk.Extern.Xml.Tei.Speech.Model;
using CorpusExplorer.Sdk.Extern.Xml.Tei.Speech.Serializer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using div = CorpusExplorer.Sdk.Extern.Xml.IdsXces.Model.div;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Test
{
  [TestClass]
  public sealed class TeiTest
  {
    [TestMethod]
    public void BareSerializerTest()
    {
      var serializer = new TeiBareSerializer();
      var tei = serializer.Deserialize("testdata/AnneWill_TEI.xml");

      // Hinweis: Die auskommentierten Tests sind in der Test-XML: AnneWill_TEI.xml nicht verfügbar.

      Assert.IsNotNull(tei);
      //Assert.IsNotNull(tei.schemaLocation);
      Assert.IsNotNull(tei.teiHeader);
      Assert.IsNotNull(tei.teiHeader.fileDesc1);
      Assert.IsNotNull(tei.teiHeader.type);
      Assert.IsNotNull(tei.text);
      //Assert.IsNotNull(tei.text.back);
      Assert.IsNotNull(tei.text.body);
      Assert.IsNotNull(tei.text.body.Items);
      Assert.AreNotEqual(0, tei.text.body.Items.Length);
      Assert.IsNotNull(tei.text.body.Items[0]);
      //Assert.IsNotNull(tei.text.front);
    }

    /*
    [TestMethod]
    public void DtaSerializerTest()
    {
      var serializer = new Tei.Dta.Serializer.TeiDtaSerializer();
      var tei = serializer.Deserialize("testdata/abel_leibmedicus_1699.TEI-P5.xml");

      Assert.IsNotNull(tei);
      Assert.IsNotNull(tei.teiHeader);
      //Assert.IsNotNull(tei.teiHeader.encodingDesc);
      Assert.IsNotNull(tei.teiHeader.fileDesc);
      Assert.IsNotNull(tei.teiHeader.fileDesc.publicationStmt);
      Assert.IsNotNull(tei.teiHeader.fileDesc.sourceDesc);
      Assert.IsNotNull(tei.teiHeader.fileDesc.titleStmt);

      Assert.IsNotNull(tei.text);
      Assert.IsNotNull(tei.text.body);
    }
    */

    [TestMethod]
    public void SpeechSerializerTest()
    {
      var serializer = new TeiSpeechSerializer();
      ValidateTeiSpeech(serializer.Deserialize("testdata/AnneWill_TEI.xml"));
      ValidateTeiSpeech(serializer.Deserialize("testdata/ForumWaffenrecht_TEI.xml"));
      ValidateTeiSpeech(serializer.Deserialize("testdata/Helge_Schneider_Arbeitsamt_TEI.xml"));
      ValidateTeiSpeech(serializer.Deserialize("testdata/Hubert_Fichte_Interview_TEI.xml"));
      ValidateTeiSpeech(serializer.Deserialize("testdata/Rossau_TEI.xml"));
      ValidateTeiSpeech(serializer.Deserialize("testdata/EnglishTranslator_TEI.xml"));
      ValidateTeiSpeech(serializer.Deserialize("testdata/HartAberFair_TEI.xml"));
      ValidateTeiSpeech(serializer.Deserialize("testdata/Rudi_Voeller_Wutausbruch_TEI.xml"));
      ValidateTeiSpeech(serializer.Deserialize("testdata/Helge_Schneider_Tropfsteinhoehle_TEI.xml"));
    }

    private static void ValidateTeiSpeech(TEI tei)
    {
      Assert.IsNotNull(tei);
      Assert.IsNotNull(tei.teiHeader);
      Assert.IsNotNull(tei.teiHeader.fileDesc);
      Assert.IsNotNull(tei.teiHeader.profileDesc);
      Assert.IsNotNull(tei.teiHeader.revisionDesc);
      Assert.IsNotNull(tei.text);
      Assert.IsNotNull(tei.text.timeline);
      Assert.IsNotNull(tei.text.timeline.origin);
      Assert.IsNotNull(tei.text.timeline.unit);
      Assert.IsNotNull(tei.text.timeline.when);
      Assert.AreNotEqual(0, tei.text.timeline.when.Length);
      Assert.IsNotNull(tei.text.body);
      Assert.AreNotEqual(0, tei.text.body.Length);

      foreach (var item in tei.text.body)
      {
        Assert.IsTrue(item is div || item is incident);

        if (item is div)
        {
          var div = item as div;
          Assert.IsNotNull(div);
        }

        if (!(item is incident))
          continue;
        var inc = item as incident;
        Assert.IsNotNull(inc);
        Assert.IsNotNull(inc.desc);
        Assert.IsNotNull(inc.end);
        Assert.IsNotNull(inc.start);
        // Assert.IsNotNull(inc.type); // Kann laut Spezifikation null sein
      }
    }
  }
}