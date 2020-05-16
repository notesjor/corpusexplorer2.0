#region

using System.Collections.Generic;
using CorpusExplorer.Core.Utils.DocumentProcessing.Scraper.Docx;
using CorpusExplorer.Core.Utils.DocumentProcessing.Scraper.Html;
using CorpusExplorer.Core.Utils.DocumentProcessing.Scraper.Pdf;
using CorpusExplorer.Core.Utils.DocumentProcessing.Scraper.Rtf;
using CorpusExplorer.Sdk.Action;
using CorpusExplorer.Sdk.Addon;
using CorpusExplorer.Sdk.Blocks.Cooccurrence;
using CorpusExplorer.Sdk.Blocks.Measure;
using CorpusExplorer.Sdk.Blocks.ReadingEase;
using CorpusExplorer.Sdk.Blocks.Similarity;
using CorpusExplorer.Sdk.Blocks.VocabularyComplaxity;
using CorpusExplorer.Sdk.Utils.DataTableWriter;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Builder;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Tlv;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.CorpusExplorerV6;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Txt;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.RawText;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.TnTTagger;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.TreeTagger;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.UDPipe;

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

    public override IEnumerable<KeyValuePair<string, AbstractTableWriter>> AddonTableWriter =>
    new Dictionary<string, AbstractTableWriter>
    {
      {"CSV-Tabelle (*.csv)|*.csv", new CsvTableWriter() },
      {"HTML-Dokument (*.html)|*.html", new HtmlTableWriter() },
      {"JSON-Dokument (*.json)|*.json", new JsonTableWriter() },
      {"JSON-Dokument (gerundet) (*.json)|*.json", new JsonRoundedTableWriter() },
      {"SQL-Query nur Daten (*.sql)|*.sql", new SqlDataOnlyTableWriter() },
      {"SQL-Query nur Schema (*.sql)|*.sql", new SqlSchemaOnlyTableWriter() },
      {"SQL-Query Schema und Daten (*.sql)|*.sql", new SqlTableWriter() },
      {"TSV-Tabelle (*.tsv)|*.tsv", new TsvTableWriter() },
      {"TSV-Tabelle (gerundet) (*.tsv)|*.tsv", new TsvRoundedTableWriter() },
      {"XML-Dokument (*.xml)|*.xml", new XmlTableWriter() }
    };

    public override IEnumerable<object> AddonSideloadFeature =>
      new List<object>
      {
        new FelschKincaidGradeIndex(),
        new FelschReadingEaseIndex(),
        new GunningFogIndexIndex(),
        new SmogIndexIndex(),
        new WienerSachtextV1Index(),
        new WienerSachtextV2Index(),
        new WienerSachtextV3Index(),
        new WienerSachtextV4Index(),

        new VocabularyComplexityByBrunet1978(),
        new VocabularyComplexityByHonore1979(),
        new VocabularyComplexityBySichel1975(),
        new VocabularyComplexityByYule1938(),
        new VocabularyComplexityCarrollsCorrectedTTR(),
        new VocabularyComplexityGuiraud1954(),
        new VocabularyComplexityHerdan1960(),
        new VocabularyComplexitySummersIndex(),
        new VocabularyComplexityTypeTokenRatio(),

        new CosineMeasure(),
        new EuclideanDistance(),

        new ChiSquaredSignificance(),
        new LogLikelihoodSignificance(),
        new PoissonSignificance(),

        new BraunMeasure(),
        new DiceCoefficient(),
        new HamannMeasure(),
        new JaccardMeasure(),
        new KappaMeasure(),
        new KulczynskiMeasure(),
        new MCoefficientMeasure(),
        new MutalInformation(),
        new OchiaiMeasure(),
        new PhiMeasure(),
        new RusselRaoMeasure(),
        new SimpsonMeasure(),
        new SneathMeasure(),
        new TanimotoMeasure(),
        new YuleMeasure()
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
        {"CorpusExplorer v6+GZIP (*.cec6.gz)|*.cec6.gz", new ExporterCec6 {UseCompression = true}},
        {"Plaintext-Export (*.txt)|*.txt", new ExporterPlaintext()},
        {"Plaintext-Export [Nur Wort-Layer] (*.txt)|*.txt", new ExporterPlaintextPure()},
        {"Plaintext-Export [Nur Wort-Layer - Eine Datei] (*.txt)|*.txt", new ExporterPlaintextPureInOneFile()},
        {"Einfacher HTML-Export [Nur Wort-Layer] (*.txt)|*.txt", new ExporterHtmlPure()},
        {"CSV-Export [Nur Metadatan] (*.csv)|*.csv", new ExporterCsvMetadataOnly()},
        {"CSV-Export [Metadaten + Wort-Layer] (*.csv)|*.csv", new ExporterCsv()},
        {"Abfragen-Export [Nur für Schnappschüsse] (*.ceusd)|*.ceusd", new ExporterQuery()},
        {"CoNLL (*.conll)|*.conll", new ExporterConll()},
        {"TreeTagger (*.treetagger)|*.treetagger", new ExporterTreeTagger()},
        {"TreeTagger + Satzgrenze (*.treetagger)|*.treetagger", new ExporterTreeTagger {UseSentenceTag = true}},
        {"CorpusWorkBench (*.cwb)|*.cwb", new ExporterCorpusWorkBench{UseSentenceTag = false}},
        {"CorpusWorkBench + Satzgrenze (*.cwb)|*.cwb", new ExporterCorpusWorkBench {UseSentenceTag = true}}
      };

    /// <summary>
    ///   Liste mit Scrapern die lokale Dateien bestehender Korpora importieren (z. B. XML, EXMERaLDA).
    ///   Für Dateien MIT Annotation.
    /// </summary>
    public override IEnumerable<KeyValuePair<string, AbstractImporter>> AddonImporter =>
      new Dictionary<string, AbstractImporter>
      {
        {"CorpusExplorer v6 (*.cec6, *.cec6.gz)|*.cec6;*.cec6.gz", new ImporterCec6()},
        {"CorpusExplorer v6 [STREAM] (*.cec6)|*.cec6", new ImporterCec6Stream()},
        {"TLV-XML (*.xml)|*.xml", new ImporterTlv()},
        {"CoNLL (*.conll)|*.conll", new ImporterConll()},
        {"TreeTagger (*.txt)|*.txt", new ImporterTreeTagger()}
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
        {"COSMAS-RTF ab Version 4 (*.rtf)|*.rtf", new Utils.DocumentProcessing.Scraper.Cosmas.CosmasScraper()},
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

    public override IEnumerable<IAction> AddonConsoleActions =>
      new IAction[]
      {
        new BasicInformationAction(),
        new LayerNamesAction(),
        new MetaCategoriesAction(),

        new DocumentCountAction(),
        new SentenceCountAction(),
        new TokenListAction(),
        new TokenCountAction(),
        new LayerValuesAction(),
        new TypeCountAction(),
        new DocumentHashAction(),

        new Frequency1SelectAction(),
        new Frequency1Action(),
        new Frequency2Action(),
        new Frequency3Action(),
        new Frequency1RawAction(),
        new Frequency2RawAction(),
        new Frequency3RawAction(),
        new CorrespondingValuesAction(),
        new NGramAction(),
        new NGramSelectedAction(),
        new CrossFrequencyAction(),
        new CooccurrenceAction(),
        new CooccurrenceCrossAction(),
        new CooccurrenceCrossFullAction(),
        new CooccurrenceProfileAction(),
        new CooccurrenceSelectedAction(),
        new PositionFrequencyAction(),
        new StyleNgramAction(),
        new MetaAction(),
        new MetaDocumentAction(),
        new MetaSelectedAction(),
        new MetaSelectedDomainAction(),
        new MtldAction(),
        new VocdAction(),
        new GetDocumentAction(),
        new GetDocumentDisplaynamesAction(),
        new GetDocumentMetadataAction(),
        new NamedEntityAction(),
        new EditDistanceAction(),
        new KeywordAction(),

        new VocabularyComplexityAction(),
        new ReadingEaseAction(),
        new StyleBurrowsDeltaAction(),
        new DisambiguationeAction(),

        new KwicAnyFilterAction(),
        new KwicAllInDocumentFilterAction(),
        new KwicAllInSentenceFilterAction(),
        new KwicExactPhraseFilterAction(),
        new KwicFirstAnyFilterAction(),
        new KwicNamedEntityAction(),
        new KwicSignificantFilterAction(),
        new KwitFilterAction(),

        new ClusterAction(),
        new ConvertAction(),
        new QueryAction(),

        new ClusterListAction(),
        new QueryListAction()
      };

    /// <summary>
    ///   Eindeutige Bezeichnung (Name) des Addons
    /// </summary>
    public override string Guid => "CorpusExplorer.BasicAddons";
  }
}