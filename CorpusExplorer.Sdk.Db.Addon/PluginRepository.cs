using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Addon;
using CorpusExplorer.Sdk.Db.Addon.Elastic.Backend;
using CorpusExplorer.Sdk.Db.Addon.Elastic.Exporter;
using CorpusExplorer.Sdk.Db.Addon.Elastic.Importer;
using CorpusExplorer.Sdk.Model.Export.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.Abstract;

namespace CorpusExplorer.Sdk.Db.Addon
{
  public class PluginRepository : AbstractAddonRepository
  {
    public override string Guid => "CorpusExplorer.Sdk.Db.ElasticSearch";
    public override IEnumerable<AbstractAdditionalTagger> AddonAdditionalTagger => null;

    public override IEnumerable<KeyValuePair<string, AbstractCorpusBuilder>> AddonBackends =>
      new Dictionary<string, AbstractCorpusBuilder>
      {
        {"CorpusExplorer <-> ElasticSearch", new CorpusBuilderElasticSearchLightweightGui()},
      };

    public override IEnumerable<KeyValuePair<string, AbstractExporter>> AddonExporters =>
      new Dictionary<string, AbstractExporter>
      {
        {"CorpusExplorer <-> ElasticSearch (*.elastic)|*.elastic", new ExporterElasticSearch()},
        {"CorpusExplorer >>> ElasticSearch (Kein CE-Reimport möglich)|*.elastic", new ExporterElasticSearchFulltext()},
      };

    public override IEnumerable<KeyValuePair<string, AbstractImporter>> AddonImporter =>
      new Dictionary<string, AbstractImporter>
      {
        {"CorpusExplorer <-> Elasticsearch (*.elastic)|*.elastic", new ElasticSearchImporter()},
      };

    public override IEnumerable<KeyValuePair<string, AbstractScraper>> AddonScrapers => null;
    public override IEnumerable<AbstractTagger> AddonTagger => null;
    public override IEnumerable<IAddonView> AddonViews => null;
  }
}
