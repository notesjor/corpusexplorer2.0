﻿#region

using System.Collections.Generic;
using CorpusExplorer.Sdk.Addon;
using CorpusExplorer.Sdk.Extern.Plaintext.ClanChildes;
using CorpusExplorer.Sdk.Extern.Plaintext.ClarinContentSearch;
using CorpusExplorer.Sdk.Extern.Plaintext.EasyHashtagSeparation;
using CorpusExplorer.Sdk.Extern.Plaintext.Europarl;
using CorpusExplorer.Sdk.Extern.Plaintext.KleineAnfrageDe;
using CorpusExplorer.Sdk.Extern.Plaintext.LeipzigerWortschatz;
using CorpusExplorer.Sdk.Extern.Plaintext.RawMailMsg;
using CorpusExplorer.Sdk.Extern.Plaintext.Redewiedergabe;
using CorpusExplorer.Sdk.Extern.Plaintext.RelAnnis;
using CorpusExplorer.Sdk.Extern.Plaintext.Tsv;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Extern.Plaintext
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
    public override IEnumerable<KeyValuePair<string, AbstractExporter>> AddonExporters => null;

    /// <summary>
    ///   Liste mit Scrapern die lokale Dateien bestehender Korpora importieren (z. B. XML, EXMERaLDA).
    ///   Für Dateien MIT Annotation.
    /// </summary>
    public override IEnumerable<KeyValuePair<string, AbstractImporter>> AddonImporter =>
      new Dictionary<string, AbstractImporter>
      {
        {
          "CLAN/Childes (*.cex)|*.cex", new ImporterClanChildes()
        },
        {
          "Projekt: http://www.redewiedergabe.de/ (metadata.tsv)|metadata.tsv", new ImporterRedewiedergabe()
        },
        {
          "Wortschatz Leipzig (*-sentences.txt)|*-sentences.txt", new ImporterLeipzigerWortschatz()
        },
        {
          "Universelles TSV-Korpus (*.tsv)|*.tsv", new ImporterTsv()
        },
        {
          "ANNIS v3.3 (corpus.annis)|corpus.annis", new ImporterRelAnnis()
        },
        {
          "ANNIS v3.3 (corpus.annis) - Layer-Alternative|corpus.annis", new ImporterRelAnnisAlternative()
        },
      };

    /// <summary>
    ///   Liste mit Scrapern die lokale Dateien (z. B. TXT, RTF, DOCX, PDF) in Korpusdokumente konvertieren.
    ///   Für Dateien OHNE Annotation.
    /// </summary>
    public override IEnumerable<KeyValuePair<string, AbstractScraper>> AddonScrapers =>
      new Dictionary<string, AbstractScraper>
      {
        {
          "kleineAnfrage.de SQL (*.sql)|*.sql",
          new KleineanfrageDeScraper()
        },
        {
          "CLARIN ContentSearch CSV-Export (*.csv)|*.csv",
          new ClarinContentSearchScraper()
        },
        {
          "EasyHashtag Plaintext (*.ehp, *.txt)|*.ehp;*.txt",
          new EasyHashtagSeparationScraper()
        },
        {
          "E-Mail MIME-Format (*.msg; *.eml)|*.msg;*.eml",
          new RawMsgMsgScraper()
        },
        {
          "TSV-Datei mit Überschriften - Windows (*.csv; *.tsv; *.tab)|*.csv;*.tsv;*.tab",
          new TsvAndCsvScraper { NewLine = "\r\n" }
        },
        {
          "TSV-Datei mit Überschriften - Linux (*.csv; *.tsv; *.tab)|*.csv;*.tsv;*.tab",
          new TsvAndCsvScraper { NewLine = "\n" }
        },
        {
          "CSV-Datei mit Überschriften - Windows (*.csv)|*.csv",
          new TsvAndCsvScraper { NewLine = "\r\n" }
        },
        {
          "CSV-Datei mit Überschriften - Linux (*.csv)|*.csv",
          new TsvAndCsvScraper { NewLine = "\n" }
        },
        {
          "EuroParl (*.txt)|*.txt",
          new EuroparlScraper()
        },
        {
          "Wortschatz Leipzig (*-sentences.txt)|*-sentences.txt",
          new LeipzigerWortschatzScraper()
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
    public override string Guid => "CorpusExplorer.Sdk.Extern.Plaintext";
  }
}