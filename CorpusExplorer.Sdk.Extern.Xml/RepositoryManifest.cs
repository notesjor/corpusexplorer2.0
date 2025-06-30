#region

using System.Collections.Generic;
using CorpusExplorer.Sdk.Addon;
using CorpusExplorer.Sdk.Extern.Xml.AltoXml._1._2;
using CorpusExplorer.Sdk.Extern.Xml.AnnotationPro;
using CorpusExplorer.Sdk.Extern.Xml.Bawe;
using CorpusExplorer.Sdk.Extern.Xml.Bnc;
using CorpusExplorer.Sdk.Extern.Xml.BundestagOpenAccess.Drucksachen;
using CorpusExplorer.Sdk.Extern.Xml.BundestagOpenAccess.Plenarprotokolle.v1;
using CorpusExplorer.Sdk.Extern.Xml.BundestagOpenAccess.Plenarprotokolle.v2;
using CorpusExplorer.Sdk.Extern.Xml.Catma._5._0;
using CorpusExplorer.Sdk.Extern.Xml.Catma._6._0;
using CorpusExplorer.Sdk.Extern.Xml.CoraXml._0._8;
using CorpusExplorer.Sdk.Extern.Xml.CoraXml._1._0;
using CorpusExplorer.Sdk.Extern.Xml.Dewac;
using CorpusExplorer.Sdk.Extern.Xml.DigitalPlato;
using CorpusExplorer.Sdk.Extern.Xml.DortmunderChatKorpus;
using CorpusExplorer.Sdk.Extern.Xml.Dpxc;
using CorpusExplorer.Sdk.Extern.Xml.DraCor;
using CorpusExplorer.Sdk.Extern.Xml.Dta.Basisformat;
using CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf;
using CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf2017;
using CorpusExplorer.Sdk.Extern.Xml.EuroparlUds;
using CorpusExplorer.Sdk.Extern.Xml.Exmaralda.Simple;
using CorpusExplorer.Sdk.Extern.Xml.FnhdC;
using CorpusExplorer.Sdk.Extern.Xml.FoLiA;
using CorpusExplorer.Sdk.Extern.Xml.Folker.Flk;
using CorpusExplorer.Sdk.Extern.Xml.Folker.Fln;
using CorpusExplorer.Sdk.Extern.Xml.GermaParlTei;
using CorpusExplorer.Sdk.Extern.Xml.Gutenberg;
using CorpusExplorer.Sdk.Extern.Xml.Ids.I5Xml;
using CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP;
using CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP.LoadStrategy;
using CorpusExplorer.Sdk.Extern.Xml.LexisNexis;
using CorpusExplorer.Sdk.Extern.Xml.Opus;
using CorpusExplorer.Sdk.Extern.Xml.Perseus;
using CorpusExplorer.Sdk.Extern.Xml.Pmg;
using CorpusExplorer.Sdk.Extern.Xml.PostgreSqlDump;
using CorpusExplorer.Sdk.Extern.Xml.PureXml;
using CorpusExplorer.Sdk.Extern.Xml.PurlOrg;
using CorpusExplorer.Sdk.Extern.Xml.Refi;
using CorpusExplorer.Sdk.Extern.Xml.SaltXml;
using CorpusExplorer.Sdk.Extern.Xml.Shakespeare;
using CorpusExplorer.Sdk.Extern.Xml.SixCms;
using CorpusExplorer.Sdk.Extern.Xml.SlashA;
using CorpusExplorer.Sdk.Extern.Xml.Songkorpus;
using CorpusExplorer.Sdk.Extern.Xml.Talkbank;
using CorpusExplorer.Sdk.Extern.Xml.Tei.Dwds;
using CorpusExplorer.Sdk.Extern.Xml.Tei.P5Cal2;
using CorpusExplorer.Sdk.Extern.Xml.TextGrid;
using CorpusExplorer.Sdk.Extern.Xml.Tiger.Importer;
using CorpusExplorer.Sdk.Extern.Xml.Tiger.Scraper;
using CorpusExplorer.Sdk.Extern.Xml.Txm;
using CorpusExplorer.Sdk.Extern.Xml.Weblicht;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract;
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
    public override IEnumerable<KeyValuePair<string, AbstractTableWriter>> AddonTableWriter => null;

    /// <summary>
    ///   Liste mit Exportern die Projekte, Korpora und Schnappschüsse (alle IHydra) exportieren können
    /// </summary>
    public override IEnumerable<KeyValuePair<string, AbstractExporter>> AddonExporters =>
      new Dictionary<string, AbstractExporter>
      {
        {"Slash/A-XML (*.xml)|*.xml", new ExporterSlashA()},
        {"DTA-TCF + ZIP (*.zip)|*.zip", new ExporterDtaZip()},
        {"DTA-TCF (*.tcf.xml)|*.tcf.xml", new ExporterDta()},
        {"DTA-TCF bis 2017 (*.tcf.xml)|*.tcf.xml", new ExporterDta2017()},
        {"WebLicht (*.xml)|*.xml", new ExporterWeblicht()},
        {"AnnotationPro (*.ant)|*.ant", new ExporterAnnoationPro()},
        {"DWDS TEI (*.xml)|*.xml", new ExporterDwdsTei() },
        {"TXM TEI-XML (*.xml)|*.xml", new ExporterTxm() },
        {"TXM TEI-XML + ZIP (*.zip)|*.zip", new ExporterTxmZip() },
        {"CATMA 6 (*.xml/*.txt)|*", new ExporterCatma() },
        {"IDS I5 (*.xml)|*.xml", new ExporterI5() },
        {"IDS KorAP (*.zip)|*.zip", new ExporterKorap() },
        {"XCES-XML (https://opus.nlpl.eu/) (*.xml)|*.xml", new ExporterOpusXces() },
        {"SaltXML (*.xml, *.salt)|*.salt;*.xml", new ExporterSaltXml() },
        {"FoLiA-XML (*.xml)|*.xml", new ExporterFolia() }
      };

    /// <summary>
    ///   Liste mit Scrapern die lokale Dateien bestehender Korpora importieren (z. B. XML, EXMERaLDA).
    ///   Für Dateien MIT Annotation.
    /// </summary>
    public override IEnumerable<KeyValuePair<string, AbstractImporter>> AddonImporter =>
      new Dictionary<string, AbstractImporter>
      {
        {"Rotterdam Exchange Format Initiative (*.qdpx, *.zip)|*.qdpx;*.zip", new ImporterRefi()},
        {"DEWAC (DEWAC-*.xml)|DEWAC-*.xml", new ImporterDewac()},
        {"WebLicht (*.xml)|*.xml", new ImporterWeblicht()},
        {"DTA-TCF 2017 (*.tcf.xml)|*.tcf.xml", new ImporterDta2017()},
        {"DTA-TCF (*.tcf.xml)|*.tcf.xml", new ImporterDta()},
        {"CATMA 5.0 (*.xml)|*.xml", new ImporterCatma()},
        {"CoraXML 1.0 (*.xml)|*.xml", new ImporterCoraXml10()},
        {"CoraXML 0.8 (*.xml)|*.xml", new ImporterCoraXml08()},
        {"FnhdC (*.xml)|*.xml", new ImporterFnhdC()},
        {"BNC TEI (*.xml)|*.xml", new ImporterBnc() },
        {"TXM TEI-XML (*.xml)|*.xml", new ImporterTxm() },
        {"TiGER-XML (*.xml)|*.xml", new ImporterTiger() },
        {"FOLKER / OrthoNormal (*.fln)|*.fln", new ImporterFolkerFln() },
        {"IDS KorAP (*.zip)|*.zip", new ImporterKorap { LoadStrategy = KorapLoadStrategyZipFile.AddonInitialize() } },
        {"IDS KorAP ab 2021 (*.zip)|*.zip", new ImporterKorap2021{ LoadStrategy = KorapLoadStrategyZipFile.AddonInitialize() } },
        {"IDS KorAP ab 2021 MINI-META (*.zip)|*.zip", new ImporterKorap2021Mini { LoadStrategy = KorapLoadStrategyZipFile.AddonInitialize() } },
        {"XCES-XML (https://opus.nlpl.eu/) (*.xml)|*.xml", new ImporterOpusXces()},
        {"SaltXML (*.xml, *.salt)|*.salt;*.xml", new ImporterSaltXml() },
        {"FoLiA-XML (*.xml)|*.xml", new ImporterFolia() }
      };

    /// <summary>
    ///   Liste mit Scrapern die lokale Dateien (z. B. TXT, RTF, DOCX, PDF) in Korpusdokumente konvertieren.
    ///   Für Dateien OHNE Annotation.
    /// </summary>
    public override IEnumerable<KeyValuePair<string, AbstractScraper>> AddonScrapers =>
      new Dictionary<string, AbstractScraper>
      {
        {
          "IDS I5-Korpora (*.i5.xml)|*.i5.xml",
          new IdsScraper()
        },
        {
          "IDS KorAP (*.zip)|*.zip",
          new KorapScraper()
        },
        {
          "SixCMS Artikel-Export (*.xml)|*.xml",
          new SixCmsScraper()
        },
        {
          "DraCor.org - Darama - Ganzer Text (*.xml)|*.xml",
          new DraCorFullScraper()
        },
        {
          "DraCor.org - Darama - Einzelne Redebeiträge (*.xml)|*.xml",
          new DraCorTurnScraper()
        },
        {
          "Shakespeare Drama-XML (*.xml)|*.xml",
          new ShakespeareScraper()
        },
        {
          "Songkorpus.de TEI (*.xml)|*.xml",
          new SongkorpusScraper()
        },
        {
          "BAWE TEI-P4 (*.xml)|*.xml",
          new BaweScraper()
        },
        {
          "Perseus CTS-Service (*.xml)|*.xml",
          new PerseusScraper()
        },
        {
          "TEI P5 (*.xml)|*.xml",
          new P5Cal2Scraper()
        },
        {
          "DWDS TEI (*.xml)|*.xml",
          new DwdsTeiScraper()
        },
        {
          "ALTO-XML 1.2 (*.xml)|*.xml",
          new Alto12Scraper()
        },
        {
          "CATMA 5.0 (*.xml)|*.xml",
          new CatmaScraper()
        },
        {
          "Gutenberg 13 DVD (*.xml)|*.xml",
          new GutenbergScraper()
        },
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
          "TXM TEI-XML (*.xml)|*.xml",
          new TxmScraper()
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
          "FOLKER / OrthoNormal (*.fln)|*.fln",
          new FolkerFlnScraper()
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
          "PMG-XML (*.pmg; *.xml)|*.xml;*.pmg",
          new PmgScraper()
        },
        {
          "D-Spin Slash/A (*.xml)|*.xml",
          new SlashAScraper()
        },
        {
          "DTA-TCF 2017 (*.tcf.xml)|*.tcf.xml",
          new Dta2017Scraper()
        },
        {
          "DTA-TCF (*.tcf.xml)|*.tcf.xml",
          new DtaScraper()
        },
        {
          "DTA-Basisformat (*.xml)|*.xml",
          new DtaBasisformatScraper()
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
          "Bundestag OpenAccess Plenarprotokolle (1-18 Legislaturperiode) (*.xml)|*.xml",
          new BundestagPlenarprotokolleScraper()
        },
        {
          "Bundestag OpenAccess Plenarprotokolle (ab 19. Legislaturperiode - gesamtes Protokoll) (*.xml)|*.xml",
          new BundestagDtdPlenarprotokolleSimpleScraper()
        },
        {
          "Bundestag OpenAccess Plenarprotokolle (ab 19. Legislaturperiode - separate Redebeiträge) (*.xml)|*.xml",
          new BundestagDtdPlenarprotokolleTurnScraper()
        },
        {
          "Bundestag OpenAccess Drucksachen (*.xml)|*.xml",
          new BundestagDrucksachenScraper()
        },
        {
          "Nur Text (*.xml)|*.xml",
          new PureXmlTextScraper()
        },
        {
          "Nexis/Uni / Lexis-Nexis (bis 2019) - (*.html)|*.html",
          new NexisComScraper()
        },
        {
          "Europarl-UDS (*.xml)|*.xml",
          new EuroParlUdsScraper()
        },
        {
          "TextGrid (*.xml)|*.xml",
          new TextGridScraper()
        },
        {
          "Talkbank XML (*.xml)|*.xml",
          new TalkbankScraper()
        },
        {
          "GermaParlTEI (*.xml)|*.xml",
          new GermaParlTeiScraper()
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

    public override IEnumerable<IAction> AddonConsoleActions => null;

    public override IEnumerable<object> AddonSideloadFeature => null;

    /// <summary>
    ///   Eindeutige Bezeichnung (Name) des Addons
    /// </summary>
    public override string Guid => "CorpusExplorer.Sdk.Extern.Xml";
  }
}