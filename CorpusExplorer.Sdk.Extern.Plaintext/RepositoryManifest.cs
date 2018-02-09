#region

using System.Collections.Generic;
using CorpusExplorer.Sdk.Addon;
using CorpusExplorer.Sdk.Extern.Plaintext.ClanChildes;
using CorpusExplorer.Sdk.Extern.Plaintext.ClarinContentSearch;
using CorpusExplorer.Sdk.Extern.Plaintext.Conll;
using CorpusExplorer.Sdk.Extern.Plaintext.Csv;
using CorpusExplorer.Sdk.Extern.Plaintext.EasyHashtagSeparation;
using CorpusExplorer.Sdk.Extern.Plaintext.Europarl;
using CorpusExplorer.Sdk.Extern.Plaintext.RawMailMsg;
using CorpusExplorer.Sdk.Model.Export.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;
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

    /// <summary>
    ///   Liste mit Exportern die Projekte, Korpora und Schnappschüsse (alle IHydra) exportieren können
    /// </summary>
    public override IEnumerable<KeyValuePair<string, AbstractExporter>> AddonExporters =>
      new Dictionary<string, AbstractExporter> {{"CoNLL (*.conll)|*.conll", new ExporterConll()}};

    /// <summary>
    ///   Liste mit Scrapern die lokale Dateien bestehender Korpora importieren (z. B. XML, EXMERaLDA).
    ///   Für Dateien MIT Annotation.
    /// </summary>
    public override IEnumerable<KeyValuePair<string, AbstractImporter>> AddonImporter =>
      new Dictionary<string, AbstractImporter>
      {
        {"CLAN/Childes (*.cex)|*.cex", new ImporterClanChildes()},
        {"CoNLL (*.conll)|*.conll", new ImporterConll() }
      };

    /// <summary>
    ///   Liste mit Scrapern die lokale Dateien (z. B. TXT, RTF, DOCX, PDF) in Korpusdokumente konvertieren.
    ///   Für Dateien OHNE Annotation.
    /// </summary>
    public override IEnumerable<KeyValuePair<string, AbstractScraper>> AddonScrapers =>
      new Dictionary<string, AbstractScraper>
      {
        {
          "CLARIN ContentSearch CSV-Export (*.csv)|*.csv",
          new ClarinContentSearchScraper()
        },
        {
          "EasyHashtag Plaintext (*.ehp)|*.ehp",
          new EasyHashtagSeparationScraper()
        },
        {
          "E-Mail MIME-Format (*.msg; *.eml)|*.msg;*.eml",
          new RawMsgMsgScraper()
        },
        {
          "CSV-Datei mit Überschriften (*.csv)|*.csv",
          new CsvScraper()
        },
        {
          "EuroParl (*.txt)|*.txt",
          new EuroparlScraper()
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
    public override string Guid => "CorpusExplorer.Sdk.Extern.Plaintext";
  }
}