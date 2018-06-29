#region

using System.Collections.Generic;
using CorpusExplorer.Core.DocumentProcessing.Exporter;
using CorpusExplorer.Core.DocumentProcessing.Exporter.Tlv;
using CorpusExplorer.Core.DocumentProcessing.Importer.TlvXml;
using CorpusExplorer.Core.DocumentProcessing.Scraper.Docx;
using CorpusExplorer.Core.DocumentProcessing.Scraper.Html;
using CorpusExplorer.Core.DocumentProcessing.Scraper.Pdf;
using CorpusExplorer.Core.DocumentProcessing.Scraper.Rtf;
using CorpusExplorer.Core.DocumentProcessing.Scraper.Txt;
using CorpusExplorer.Core.DocumentProcessing.Tagger.RawText;
using CorpusExplorer.Core.DocumentProcessing.Tagger.TnTTagger;
using CorpusExplorer.Core.DocumentProcessing.Tagger.TreeTagger;
using CorpusExplorer.Core.DocumentProcessing.Tagger.UDPipe;
using CorpusExplorer.Sdk.Addon;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Builder;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.CorpusExplorerV6;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.Abstract;

#endregion

namespace CorpusExplorer.Core
{
  // ReSharper disable once UnusedMember.Global
  public class RepositoryManifest : AbstractAddonRepository
  {
    public override IEnumerable<AbstractAdditionalTagger> AddonAdditionalTagger =>
      new List<AbstractAdditionalTagger>
      {
        new AdditionalTsvValueTagger()
      };

    public override IEnumerable<KeyValuePair<string, AbstractCorpusBuilder>> AddonBackends =>
      new Dictionary<string, AbstractCorpusBuilder>
      {
        // Wichtig: Sollte der Key "CorpusExplorer v5" geändert werden, muss dieser auch in CorpusExplorer.Terminal.WinForm.Forms.Tagger.SelectTagger.cs geändert werden.
        {"CorpusExplorer v6", new CorpusBuilderWriteDirect()}
      };

    /// <summary>
    ///   Liste mit Exportern die Projekte, Korpora und Schnappschüsse (alle IHydra) exportieren können
    /// </summary>
    public override IEnumerable<KeyValuePair<string, AbstractExporter>> AddonExporters =>
      new Dictionary<string, AbstractExporter>
      {
        {"JSON-Export (*.json)|*.json", new ExporterJson()},
        {"XML-Export (*.xml)|*.xml", new ExporterXml()},
        {"TLV-XML-Export (*.xml)|*.xml", new ExporterTlv()},
        {"CorpusExplorer v6 (*.cec6)|*.cec6", new ExporterCec6()},
        {"Plaintext-Export (*.txt)|*.txt", new ExporterPlaintext()},
        {"Plaintext-Export [Nur Wort-Layer] (*.txt)|*.txt", new ExporterPlaintextPure()},
        {"CSV-Export [Nur Metadatan] (*.csv)|*.csv", new ExporterCsvMetadataOnly()},
        {"CSV-Export [Metadaten + Wort-Layer] (*.csv)|*.csv", new ExporterCsv()},
        {"Abfragen-Export [Nur für Schnappschüsse] (*.ceusd)|*.ceusd", new ExporterQuery()}
      };

    /// <summary>
    ///   Liste mit Scrapern die lokale Dateien bestehender Korpora importieren (z. B. XML, EXMERaLDA).
    ///   Für Dateien MIT Annotation.
    /// </summary>
    public override IEnumerable<KeyValuePair<string, AbstractImporter>> AddonImporter =>
      new Dictionary<string, AbstractImporter>
      {
        {"CorpusExplorer v6 (*.cec6)|*.cec6", new ImporterCec6()},
        {"CorpusExplorer v6 [STREAM] (*.cec6)|*.cec6", new ImporterCec6Stream()},
        {"TLV-XML (*.xml)|*.xml", new ImporterTlv()}
      };

    /// <summary>
    ///   Liste mit Scrapern die lokale Dateien (z. B. TXT, RTF, DOCX, PDF) in Korpusdokumente konvertieren.
    ///   Für Dateien OHNE Annotation.
    /// </summary>
    public override IEnumerable<KeyValuePair<string, AbstractScraper>> AddonScrapers =>
      new Dictionary<string, AbstractScraper>
      {
        {"Plain-TXT (*.txt)|*.txt", new TxtScraper()},
        {"COSMAS-TXT (*.rtf)|*.rtf", new CosmasScraper()},
        {"Nur Text (*.docx; *.doc)|*.docx;*.doc", new SimpleDocxDocumentScraper()},
        {"Nur Text (*.rtf)|*.rtf", new SimpleRtfDocumentScraper()},
        {"Nur Text (*.html)|*.htm;*.html", new SimpleHtmlDocumentScraper()},
        {"Nur Text (*.pdf)|*.pdf", new SimplePdfDocumentScraper()}
      };

    /// <summary>
    ///   Zusätzliche Tagger
    /// </summary>
    public override IEnumerable<AbstractTagger> AddonTagger =>
      new AbstractTagger[]
      {
        new ClassicTreeTagger(),
        new SimpleTreeTagger(),
        new TnTTagger(),
        new RawTextTagger(),
        new OwnTreeTagger(),
        new UdPipeExeTagger()
      };

    /// <summary>
    ///   Externe Analysemodule.
    /// </summary>
    public override IEnumerable<IAddonView> AddonViews => null;

    /// <summary>
    ///   Eindeutige Bezeichnung (Name) des Addons
    /// </summary>
    public override string Guid => "CorpusExplorer.BasicAddons";
  }
}