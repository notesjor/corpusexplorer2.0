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
      {"HTML-Tabelle (*.html)|*.html", new HtmlTableSnippetWriter() },
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
        new DistanceEuclidean(),

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
        { "JSON-Export (*.json)|*.json", new ExporterJson() },
        { "JSON-Export + ZIP (*.zip)|*.zip", new ExporterJsonZip() },
        { "XML-Export (*.xml)|*.xml", new ExporterXml() },
        { "TLV-XML-Export (*.xml)|*.xml", new ExporterTlv() },
        { "CorpusExplorer v6 (*.cec6)|*.cec6", new ExporterCec6() },
        { "CorpusExplorer v6 + LZ4 (*.cec6.lz4)|*.cec6.lz4", new ExporterCec6 { UseCompression = true } },
        { "CorpusExplorer v6 + GZip (*.cec6.gz)|*.cec6.gz", new ExporterCec6 { UseCompression = true } },
        { "Plaintext-Export (*.txt)|*.txt", new ExporterPlaintext() },
        { "Plaintext-Export [Nur Wort-Layer] (*.txt)|*.txt", new ExporterPlaintextPure() },
        { "Plaintext-Export [Nur Wort-Layer - Eine Datei] (*.txt)|*.txt", new ExporterPlaintextPureInOneFile() },
        { "Einfacher HTML-Export [Nur Wort-Layer] (*.txt)|*.txt", new ExporterHtmlPure() },
        { "CSV-Export [Nur Metadatan] (*.csv)|*.csv", new ExporterCsvMetadataOnly() },
        { "CSV-Export [Metadaten + Wort-Layer] (*.csv)|*.csv", new ExporterCsv() },
        { "Abfragen-Export [Nur für Schnappschüsse] (*.ceusd)|*.ceusd", new ExporterQuery() },
        { "CoNLL (*.conll)|*.conll", new ExporterConll() },
        { "CoNLL + ZIP (*.zip)|*.zip", new ExporterConllZip() },
        { "TreeTagger (*.treetagger)|*.treetagger", new ExporterTreeTagger() },
        { "TreeTagger + Satzgrenze (*.treetagger)|*.treetagger", new ExporterTreeTagger { UseSentenceTag = true } },
        { "TreeTagger + ZIP (*.zip)|*.zip", new ExporterTreeTaggerZip { UseSentenceTag = true } },
        { "CorpusWorkBench bis 2021(*.vrt)|*.vrt", new ExporterCorpusWorkBench { UseSentenceTag = false } },
        { "CorpusWorkBench bis 2021 inkl. Satzgrene (*.vrt, *.vrt.xml)|*.vrt;*.vrt.xml", new ExporterCorpusWorkBench { UseSentenceTag = true } },
        { "CorpusWorkBench ab 2022 (*.vrt, *.vrt.xml)|*.vrt;*.vrt.xml", new ExporterCorpusWorkBench2022 { UseSentenceTag = true } },
        { "Sketch Engine VERT (*.vert)|*.vert", new ExporterSketchEngine() },
      };

    /// <summary>
    ///   Liste mit Scrapern die lokale Dateien bestehender Korpora importieren (z. B. XML, EXMERaLDA).
    ///   Für Dateien MIT Annotation.
    /// </summary>
    public override IEnumerable<KeyValuePair<string, AbstractImporter>> AddonImporter =>
      new Dictionary<string, AbstractImporter>
      {
        {"CorpusExplorer v6 (*.cec6, *.cec6.lz4, *.cec6.gz)|*.cec6;*.cec6.gz;*.cec6.lz4", new ImporterCec6()},
        {"CorpusExplorer v6 [STREAM] (*.cec6)|*.cec6", new ImporterCec6Stream()},
        {"TLV-XML (*.xml)|*.xml", new ImporterTlv()},
        {"CoNLL (*.conll)|*.conll", new ImporterConll()},
        {"TreeTagger (*.txt)|*.txt", new ImporterTreeTagger()},
        {"CorpusWorkBench VRT (*.vrt)|*.vrt", new ImporterCorpusWorkBench()},
        {"Sketch Engine VERT (*.vert)|*.vert", new ImporterSketchEngine()},
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
        {"Nur Text (*.pdf)|*.pdf", new SimplePdfDocumentScraper()},
        {"Nur Text - Re-Annotation (*.cec5, *.cec6, *.cec6.gz)|*.cec5;*.cec6;*.cec6.gz", new Cec6Scraper()},
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
        new AddTaggerAction(),

        new BasicInformationAction(),

        new ClusterAction(),
        new ClusterListAction(),
        new ConvertAction(),
        new CooccurrenceAction(),
        new CooccurrenceCorrespondingAction(),
        new CooccurrenceCrossAction(),
        new CooccurrenceCrossFullAction(),
        new CooccurrencePolarisationAction(),
        new CooccurrenceProfileAction(),
        new CooccurrenceSelectedAction(),
        new CooccurrenceSelectedCorrespondingAction(),
        new CorrespondingValuesAction(),
        new CrossFrequencyAction(),
        new CrossFrequencyCorrespondingAction(),

        new DisambiguationeAction(),
        new DispersionAction(),
        new DispersionCorrespondingAction(),
        new DocumentCountAction(),
        new DocumentHashAction(),
        new DocumentSimilarityAction(),
        new DocumentTermFrequencyAction(),

        new EditDistanceAction(),

        new Frequency1Action(),
        new Frequency1RawAction(),
        new Frequency1SelectAction(),
        new Frequency2Action(),
        new Frequency2RawAction(),
        new Frequency3Action(),
        new Frequency3RawAction(),

        new GetDocumentAction(),
        new GetDocumentDisplaynamesAction(),
        new GetDocumentMetadataAction(),

        new InverseDocumentFrequencyAction(),

        new KeywordAction(),
        new KeywordCorrespondingAction(),
        new KwicAllInDocumentFilterAction(),
        new KwicAllInSentenceFilterAction(),
        new KwicAnyFilterAction(),
        new KwicExactPhraseFilterAction(),
        new KwicExportAction(),
        new KwicFirstAnyFilterAction(),
        new KwicMdaFilterAction(),
        new KwicNamedEntityAction(),
        new KwicSignificantFilterAction(),
        new KwitAction(),
        new KwitSelectAction(),

        new LayerCloneAction(),
        new LayerNamesAction(),
        new LayerNewAction(),
        new LayerRemoveAction(),
        new LayerRenameAction(),
        new LayerValuesAction(),

        new MetaAction(),
        new MetaCategoriesAction(),
        new MetaDocumentAction(),
        new MetaDocumentSelectAction(),
        new MetaExportAction(),
        new MetaImportAction(),
        new MetaSelectedAction(),
        new MetaSelectedDomainAction(),
        new MtldAction(),

        new NamedEntityAction(),
        new NGramAction(),
        new NGramCooccurrenceAction(),
        new NGramCorrespondingAction(),
        new NGramSelectedAction(),
        new NGramSelectedCooccurrenceAction(),

        new PhraseCountAction(),
        new PositionFrequencyAction(),
        new PositionFrequencyCorrespondingAction(),

        new QueryAction(),
        new QueryCountAllTokenMatchesAction(),
        new QueryCountDocumentsAction(),
        new QueryCountSentencesAction(),
        new QueryListAction(),

        new RemoveLayerAction(),
        new RemoveMetaAction(),

        new SentenceCountAction(),
        new SizeAction(),
        new StyleBurrowsDeltaAction(),
        new StyleNgramAction(),

        new TermFrequencyInverseDocumentFrequencyAction(),
        new TokenCountAction(),
        new TokenListAction(),
        new TokenListSelectAction(),
        new TypeCountAction(),

        new ValidateAction(),
        new VocabularyComplexityAction(),
        new VocdAction(),
      };

    /// <summary>
    ///   Eindeutige Bezeichnung (Name) des Addons
    /// </summary>
    public override string Guid => "CorpusExplorer.BasicAddons";
  }
}