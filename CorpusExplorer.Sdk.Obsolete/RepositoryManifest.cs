#region

using System.Collections.Generic;
using CorpusExplorer.Core.DocumentProcessing.Importer.CorpusExplorerV5;
using CorpusExplorer.Core.Exporter;
using CorpusExplorer.Sdk.Addon;
using CorpusExplorer.Sdk.Model.Export.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Builder;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.Abstract;

#endregion

namespace CorpusExplorer.Core
{
  // ReSharper disable once UnusedMember.Global
  public class RepositoryManifest : AbstractAddonRepository
  {
    public override IEnumerable<AbstractAdditionalTagger> AddonAdditionalTagger =>
      null;

    public override IEnumerable<KeyValuePair<string, AbstractCorpusBuilder>> AddonBackends =>
      new Dictionary<string, AbstractCorpusBuilder>
      {
        // Wichtig: Sollte der Key "CorpusExplorer v5" geändert werden, muss dieser auch in CorpusExplorer.Terminal.WinForm.Forms.Tagger.SelectTagger.cs geändert werden.
        {"CorpusExplorer v5", new CorpusBuilderSingleFile()},
      };

    /// <summary>
    ///   Liste mit Exportern die Projekte, Korpora und Schnappschüsse (alle IHydra) exportieren können
    /// </summary>
    public override IEnumerable<KeyValuePair<string, AbstractExporter>> AddonExporters =>
      new Dictionary<string, AbstractExporter>
      {
        {"CEC5-Export (*.cec5)|*.cec5", new ExporterCec5()},
      };

    /// <summary>
    ///   Liste mit Scrapern die lokale Dateien bestehender Korpora importieren (z. B. XML, EXMERaLDA).
    ///   Für Dateien MIT Annotation.
    /// </summary>
    public override IEnumerable<KeyValuePair<string, AbstractImporter>> AddonImporter =>
      new Dictionary<string, AbstractImporter>
      {
        {"CorpusExplorer v5 (*.cec5)|*.cec5", new ImporterCec5()},
      };

    /// <summary>
    ///   Liste mit Scrapern die lokale Dateien (z. B. TXT, RTF, DOCX, PDF) in Korpusdokumente konvertieren.
    ///   Für Dateien OHNE Annotation.
    /// </summary>
    public override IEnumerable<KeyValuePair<string, AbstractScraper>> AddonScrapers =>
      null;

    /// <summary>
    ///   Zusätzliche Tagger
    /// </summary>
    public override IEnumerable<AbstractTagger> AddonTagger =>
      null;

    /// <summary>
    ///   Externe Analysemodule.
    /// </summary>
    public override IEnumerable<IAddonView> AddonViews => null;

    /// <summary>
    ///   Eindeutige Bezeichnung (Name) des Addons
    /// </summary>
    public override string Guid => "CorpusExplorer.Obsolete";
  }
}