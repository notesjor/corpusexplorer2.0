#region

using System.Collections.Generic;
using CorpusExplorer.Sdk.Addon;
using CorpusExplorer.Sdk.Extern.Xml.AnnotationPro;
using CorpusExplorer.Sdk.Extern.Xml.Dewac;
using CorpusExplorer.Sdk.Extern.Xml.DigitalPlato;
using CorpusExplorer.Sdk.Extern.Xml.DortmunderChatKorpus;
using CorpusExplorer.Sdk.Extern.Xml.Dpxc;
using CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf;
using CorpusExplorer.Sdk.Extern.Xml.Exmaralda;
using CorpusExplorer.Sdk.Extern.Xml.Folker;
using CorpusExplorer.Sdk.Extern.Xml.PostgreSqlDump;
using CorpusExplorer.Sdk.Extern.Xml.PureXml;
using CorpusExplorer.Sdk.Extern.Xml.PurlOrg;
using CorpusExplorer.Sdk.Extern.Xml.SlashA;
using CorpusExplorer.Sdk.Extern.Xml.Tiger;
using CorpusExplorer.Sdk.Extern.Xml.Weblicht;
using CorpusExplorer.Sdk.Model.Export.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml
{
  // ReSharper disable once UnusedMember.Global
  public class RepositoryManifest : AbstractAddonRepository
  {
    public override IEnumerable<AbstractAdditionalTagger> AddonAdditionalTagger => null;
    public override IEnumerable<KeyValuePair<string, AbstractCorpusBuilder>> AddonBackends => null;

    /// <summary>
    ///   Liste mit Exportern die Projekte, Korpora und Schnappschüsse (alle IHydra) exportieren können
    /// </summary>
    public override IEnumerable<KeyValuePair<string, AbstractExporter>> AddonExporters =>
      new Dictionary<string, AbstractExporter>
      {
        {"Slash/A-XML (*.xml)|*.xml", new ExporterSlashA()},
        {"DTA Basisformat (*.tcf.xml)|*.tcf.xml", new ExporterDta()},
        {"WebLicht (*.xml)|*.xml", new ExporterWeblicht()},
        {"AnnotationPro (*.ant)|*.ant", new ExporterAnnoationPro()}
      };

    /// <summary>
    ///   Liste mit Scrapern die lokale Dateien bestehender Korpora importieren (z. B. XML, EXMERaLDA).
    ///   Für Dateien MIT Annotation.
    /// </summary>
    public override IEnumerable<KeyValuePair<string, AbstractImporter>> AddonImporter =>
      new Dictionary<string, AbstractImporter>
      {
        {"DEWAC (DEWAC-*.xml)|DEWAC-*.xml", new ImporterDewac()},
        {"WebLicht (*.xml)|*.xml", new ImporterWeblicht()},
        {"DTAbf Deutsches-Text-Archiv Basisformat (*.tcf.xml)|*.tcf.xml", new ImporterDta()}
      };

    /// <summary>
    ///   Liste mit Scrapern die lokale Dateien (z. B. TXT, RTF, DOCX, PDF) in Korpusdokumente konvertieren.
    ///   Für Dateien OHNE Annotation.
    /// </summary>
    public override IEnumerable<KeyValuePair<string, AbstractScraper>> AddonScrapers =>
      new Dictionary<string, AbstractScraper>
      {
        {
          "PostgreSQL-XML-Dump (*.xml)|*.xml",
          new PostgreSqlDumpScraper()
        },
        {
          "Dortmunder Chat Korpus (*.xml)|*.xml",
          new DortmunderChatKorpusScraper()
        },
        {
          "TiGER-XML (*.xml)|*.xml",
          new TigerScraper()
        },
        {
          "EXMERaLDA-Basic (*.exb)|*.exb",
          new ExmaraldaExbScraper()
        },
        {
          "Purl.org XML-Rohdaten (*.xml)|*.xml",
          new PurlOrgScraper()
        },
        {
          "FOLKER-Transkript (*.flk)|*.flk",
          new FolkerScraper()
        },
        {
          "AnnotationPro (*.ant)|*.ant",
          new AnnotationProScraper()
        },
        {
          "DocPlusXmlCorpus (*.dpxc)|*.dpxc",
          new DpxcScraper()
        },
        {
          "D-Spin Slash/A (*.xml)|*.xml",
          new SlashAScraper()
        },
        {
          "DTA-Basisformat (*.tcf.xml)|*.tcf.xml",
          new DtaScraper()
        },
        {
          "WebLicht-XML (*.xml)|*.xml",
          new WeblichtScraper()
        },
        {
          "Digital-Plato.org (*.xml)|*.xml",
          new DigitalPlatoScraper()
        },
        {
          "Nur Text (*.xml)|*.xml",
          new PureXmlTextScraper()
        }
      };

    /// <summary>
    ///   Zusätzliche Tagger
    /// </summary>
    public override IEnumerable<AbstractTagger> AddonTagger => null;

    /// <summary>
    ///   Externe Analysemodule.
    /// </summary>
    public override IEnumerable<IAddonView> AddonViews => null;

    /// <summary>
    ///   Eindeutige Bezeichnung (Name) des Addons
    /// </summary>
    public override string Guid => "CorpusExplorer.Sdk.Extern.Xml";
  }
}