using System.Collections.Generic;
using CorpusExplorer.Sdk.Addon;
using CorpusExplorer.Sdk.EchtzeitEngine.Importer;
using CorpusExplorer.Sdk.EchtzeitEngine.Model.LightweightFile;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.Abstract;

namespace CorpusExplorer.Sdk.EchtzeitEngine
{
  public class RepositoryManifest : AbstractAddonRepository
  {
    public override IEnumerable<AbstractAdditionalTagger> AddonAdditionalTagger => null;

    public override IEnumerable<KeyValuePair<string, AbstractCorpusBuilder>> AddonBackends
      => new Dictionary<string, AbstractCorpusBuilder>
      {
        {"CorpusExplorer (EchtzeitEngine)", new CorpusBuilderLightweightSingleFile()}
      };

    public override IEnumerable<KeyValuePair<string, AbstractExporter>> AddonExporters => null;

    public override IEnumerable<KeyValuePair<string, AbstractImporter>> AddonImporter
      => new Dictionary<string, AbstractImporter>
      {
        {"CorpusExplorer EchtzeitEngine (*.cec5ee)|*.cec5ee", new ImporterEchtzeitEngine()}
      };

    public override IEnumerable<KeyValuePair<string, AbstractScraper>> AddonScrapers => null;

    public override IEnumerable<AbstractTagger> AddonTagger => null;

    public override IEnumerable<IAddonView> AddonViews => null;

    public override string Guid => "CorpusExplorer.EchtzeitEngine";
  }
}