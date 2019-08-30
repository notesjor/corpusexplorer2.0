using System.Collections.Generic;
using CorpusExplorer.Sdk.Addon;
using CorpusExplorer.Sdk.Db.ElasticSearch.Elastic.Backend;
using CorpusExplorer.Sdk.Db.ElasticSearch.Elastic.Exporter;
using CorpusExplorer.Sdk.Db.ElasticSearch.Elastic.Importer;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.Abstract;

namespace CorpusExplorer.Sdk.Db.ElasticSearch
{
  public class PluginRepository : AbstractAddonRepository
  {
    public override IEnumerable<AbstractAdditionalTagger> AddonAdditionalTagger => null;
    public override IEnumerable<KeyValuePair<string, AbstractTableWriter>> AddonTableWriter => null;
    public override IEnumerable<KeyValuePair<string, AbstractCorpusBuilder>> AddonBackends =>
      new Dictionary<string, AbstractCorpusBuilder>
      {
        {"CorpusExplorer <-> ElasticSearch", new CorpusBuilderElasticSearchLightweightGui()}
      };

    public override IEnumerable<KeyValuePair<string, AbstractExporter>> AddonExporters =>
      new Dictionary<string, AbstractExporter>
      {
        {"CorpusExplorer <-> ElasticSearch (*.elastic)|*.elastic", new ExporterElasticSearch()},
        {"CorpusExplorer >>> ElasticSearch (Kein CE-Reimport möglich)|*.elastic", new ExporterElasticSearchFulltext()}
      };

    public override IEnumerable<KeyValuePair<string, AbstractImporter>> AddonImporter =>
      new Dictionary<string, AbstractImporter>
      {
        {"CorpusExplorer <-> Elasticsearch (*.elastic)|*.elastic", new ElasticSearchImporter()}
      };

    public override IEnumerable<KeyValuePair<string, AbstractScraper>> AddonScrapers => null;
    public override IEnumerable<AbstractTagger> AddonTagger => null;
    public override IEnumerable<IAction> AddonConsoleActions => null;
    public override IEnumerable<IAddonView> AddonViews => null;
    public override IEnumerable<object> AddonSideloadFeature => null;
    public override string Guid => "CorpusExplorer.Sdk.Db.ElasticSearch";
  }
}