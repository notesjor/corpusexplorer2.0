#region

using System.Collections.Generic;
using Bcs.Addon;
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
  ///   Base Class for all AddonRepositories
  /// </summary>
  public abstract class AbstractAddonRepository : IAddonRepository
  {
    /// <summary>
    ///   AddonHost der dieses Addon verwaltet
    /// </summary>
    public IAddonHost AddonHost { get; set; } = null;

    /// <summary>
    ///   Eindeutige Bezeichnung (Name) des Addons
    /// </summary>
    public abstract string Guid { get; }

    /// <summary>
    ///   Funktion die beim Laden des Addons in den Speicher aufgerufen wird
    /// </summary>
    public void Initialize()
    {
    }

    /// <summary>
    ///   (Ent-)Lade Priorität des Plugins (Normal: Level2System)
    /// </summary>
    public AddonLoadPriority LoadPriority { get; set; } = AddonLoadPriority.Level1Boot;

    /// <summary>
    ///   Funktion die zum Ausführen des Addons aufgerufen wird
    /// </summary>
    public void Start()
    {
    }

    /// <summary>
    ///   Funktion die zum Unterbrechen der Ausführung des Addons aufgerufen wird
    /// </summary>
    public void Stop()
    {
    }

    /// <summary>
    ///   Funktion die beim Entfernen des Addons aus dem Speicher aufgerufen wird
    /// </summary>
    public void Terminate()
    {
    }

    /// <summary>
    ///   Zusätzlich Tagger (für nachträgliches Processing)
    /// </summary>
    public abstract IEnumerable<AbstractAdditionalTagger> AddonAdditionalTagger { get; }

    /// <summary>
    ///   Liste mit allen zur Verfügung stehenden Backends.
    /// </summary>
    public abstract IEnumerable<KeyValuePair<string, AbstractCorpusBuilder>> AddonBackends { get; }

    /// <summary>
    ///   Liste mit Exportern die Projekte, Korpora und Schnappschüsse (alle IHydra) exportieren können
    /// </summary>
    public abstract IEnumerable<KeyValuePair<string, AbstractExporter>> AddonExporters { get; }

    /// <summary>
    ///   Liste mit Scrapern die lokale Dateien bestehender Korpora importieren (z. B. XML, EXMERaLDA).
    ///   Für Dateien MIT Annotation.
    /// </summary>
    public abstract IEnumerable<KeyValuePair<string, AbstractImporter>> AddonImporter { get; }

    /// <summary>
    ///   Liste mit Scrapern die lokale Dateien (z. B. TXT, RTF, DOCX, PDF) in Korpusdokumente konvertieren.
    ///   Für Dateien OHNE Annotation.
    /// </summary>
    public abstract IEnumerable<KeyValuePair<string, AbstractScraper>> AddonScrapers { get; }

    /// <summary>
    ///   Zusätzliche Tagger
    /// </summary>
    public abstract IEnumerable<AbstractTagger> AddonTagger { get; }

    /// <summary>
    ///   Externe Analysemodule für die Konsole
    /// </summary>
    public abstract IEnumerable<IAction> AddonConsoleActions { get; }

    /// <summary>
    ///   Externe Analysemodule.
    /// </summary>
    public abstract IEnumerable<IAddonView> AddonViews { get; }

    /// <summary>
    ///   Funktionen die per Sideload zur Verfügung gestellt werden.
    /// </summary>
    /// <value>The sideload feature.</value>
    public abstract IEnumerable<object> AddonSideloadFeature { get; }
  }
}