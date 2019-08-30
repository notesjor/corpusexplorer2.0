#region

using System.Collections.Generic;
using CorpusExplorer.Sdk.Addon;
using CorpusExplorer.Sdk.Extern.Json.Speedy;
using CorpusExplorer.Sdk.Extern.Json.TwitterStatus;
using CorpusExplorer.Sdk.Extern.Json.TwitterStream;
using CorpusExplorer.Sdk.Extern.Json.Wordpress;
using CorpusExplorer.Sdk.Extern.Json.YourTwapperKeeper;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Extern.Json
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
        {
          "SPEEDy/CODEX (*.json)|*.json",
          new ExporterSpeedy()
        }
      };

    /// <summary>
    ///   Liste mit Scrapern die lokale Dateien bestehender Korpora importieren (z. B. XML, EXMERaLDA).
    ///   Für Dateien MIT Annotation.
    /// </summary>
    public override IEnumerable<KeyValuePair<string, AbstractImporter>> AddonImporter =>
      new Dictionary<string, AbstractImporter>
      {
        {
          "SPEEDy/CODEX (*.json)|*.json",
          new ImporterSpeedy()
        }
      };

    /// <summary>
    ///   Liste mit Scrapern die lokale Dateien (z. B. TXT, RTF, DOCX, PDF) in Korpusdokumente konvertieren.
    ///   Für Dateien OHNE Annotation.
    /// </summary>
    public override IEnumerable<KeyValuePair<string, AbstractScraper>> AddonScrapers =>
      new Dictionary<string, AbstractScraper>
      {
        {
          "SPEEDy/CODEX (*.json)|*.json",
          new SpeedyScraper()
        },
        {
          "Twitter-JSON via StreamAPI (*.json)|*.json",
          new TwitterScraper()
        },
        {
          "Twitter-Status-JSON via SearchAPI (*.json)|*.json",
          new TwitterStatusScraper()
        },
        {
          "Twitter via yourTwappaKeeper (*.php)|*.php",
          new TwapperScraper()
        },
        {
          "WordPress JSON (*.json)|*.json",
          new WordpressScraper()
        },
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
    public override string Guid => "CorpusExplorer.Sdk.Extern.JSON";
  }
}