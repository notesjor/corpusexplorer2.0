#region

using System.Collections.Generic;
using System.Dynamic;
using Bcs.Addon.Interfaces;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Addon
{
  /// <summary>
  ///   Interface IAddonRepository
  /// </summary>
  internal interface IAddonRepository : IAddon
  {
    /// <summary>
    ///   Zusätzlich Tagger (für nachträgliches Processing)
    /// </summary>
    IEnumerable<AbstractAdditionalTagger> AddonAdditionalTagger { get; }

    /// <summary>
    ///   Daten Backends
    /// </summary>
    IEnumerable<KeyValuePair<string, AbstractCorpusBuilder>> AddonBackends { get; }

    /// <summary>
    ///   Liste mit Exportern die Projekte, Korpora und Schnappschüsse (alle IHydra) exportieren können
    /// </summary>
    IEnumerable<KeyValuePair<string, AbstractExporter>> AddonExporters { get; }

    /// <summary>
    ///   Liste mit Scrapern die lokale Dateien bestehender Korpora importieren (z. B. XML, EXMERaLDA).
    ///   Für Dateien MIT Annotation.
    /// </summary>
    IEnumerable<KeyValuePair<string, AbstractImporter>> AddonImporter { get; }

    /// <summary>
    ///   Liste mit Scrapern die lokale Dateien (z. B. TXT, RTF, DOCX, PDF) in Korpusdokumente konvertieren.
    ///   Für Dateien OHNE Annotation.
    /// </summary>
    IEnumerable<KeyValuePair<string, AbstractScraper>> AddonScrapers { get; }

    /// <summary>
    ///   Zusätzliche Tagger
    /// </summary>
    IEnumerable<AbstractTagger> AddonTagger { get; }

    /// <summary>
    ///   Externe Analysemodule für die Konsole
    /// </summary>
    IEnumerable<IAction> AddonConsoleActions { get; }

    /// <summary>
    ///   Externe Analysemodule für die GUI
    /// </summary>
    IEnumerable<IAddonView> AddonViews { get; }

    /// <summary>
    ///  Funktionen die per Sideload zur Verfügung gestellt werden.
    /// </summary>
    IEnumerable<object> AddonSideloadFeature { get; }
  }
}