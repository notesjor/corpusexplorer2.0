using System.Collections.Generic;
using CorpusExplorer.Sdk.Addon;
using CorpusExplorer.Sdk.Db.MySql.Builder;
using CorpusExplorer.Sdk.Db.MySql.Exporter;
using CorpusExplorer.Sdk.Db.MySql.Importer;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.Abstract;

namespace CorpusExplorer.Sdk.Db.MySql
{
  public class PluginRepository : AbstractAddonRepository
  {
    public override IEnumerable<AbstractAdditionalTagger> AddonAdditionalTagger => null;

    public override IEnumerable<KeyValuePair<string, AbstractCorpusBuilder>> AddonBackends =>
      new Dictionary<string, AbstractCorpusBuilder>
      {
        {"CorpusExplorer <-> MySQL", new CorpusBuilderMySql()}
      };

    public override IEnumerable<KeyValuePair<string, AbstractExporter>> AddonExporters =>
      new Dictionary<string, AbstractExporter>
      {
        {"CorpusExplorer <-> MySQL (*.mysql)|*.mysql", new ExporterMysql()}
        //{"CorpusExplorer >A> MySQL (*.mysql)|*.mysql", new MysqlAnalyticsExporter()},
      };

    public override IEnumerable<KeyValuePair<string, AbstractImporter>> AddonImporter =>
      new Dictionary<string, AbstractImporter>
      {
        {"CorpusExplorer <-> MySQL (*.mysql)|*.mysql", new ImporterMySql()}
      };

    public override IEnumerable<KeyValuePair<string, AbstractScraper>> AddonScrapers => null;
    public override IEnumerable<AbstractTagger> AddonTagger => null;
    public override IEnumerable<IAddonView> AddonViews => null;
    public override string Guid => "CorpusExplorer.Sdk.Db.MySQL";
  }
}