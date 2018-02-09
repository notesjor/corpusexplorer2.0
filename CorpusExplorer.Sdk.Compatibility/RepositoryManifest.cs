using System.Collections.Generic;
using CorpusExplorer.Sdk.Addon;
using CorpusExplorer.Sdk.Model.Export.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.Abstract;

namespace CorpusExplorer.Sdk.Compatibility
{
  public class RepositoryManifest : AbstractAddonRepository
  {
    public override IEnumerable<AbstractAdditionalTagger> AddonAdditionalTagger => null;
    public override IEnumerable<KeyValuePair<string, AbstractCorpusBuilder>> AddonBackends => null;

    /// <summary>
    ///   Liste mit Exportern die Projekte, Korpora und Schnappschüsse (alle IHydra) exportieren können
    /// </summary>
    public override IEnumerable<KeyValuePair<string, AbstractExporter>> AddonExporters => null;

    public override IEnumerable<KeyValuePair<string, AbstractImporter>> AddonImporter =>
      new Dictionary<string, AbstractImporter>
      {
        {"OBSOLETE CorpusExplorer v1-v4 (metaK.data)|metaK.data", new ImporterCorpusExplorerV1toV5()}
      };

    public override IEnumerable<KeyValuePair<string, AbstractScraper>> AddonScrapers => null;

    public override IEnumerable<AbstractTagger> AddonTagger => null;

    public override IEnumerable<IAddonView> AddonViews => null;

    public override string Guid => "CorpusExplorer.Sdk.Compatibility";
  }
}