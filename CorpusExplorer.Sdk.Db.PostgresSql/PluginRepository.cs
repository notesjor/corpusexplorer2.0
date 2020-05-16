#region

using System.Collections.Generic;
using CorpusExplorer.Sdk.Addon;
using CorpusExplorer.Sdk.Db.PostgreSql.Builder;
using CorpusExplorer.Sdk.Db.PostgreSql.Exporter;
using CorpusExplorer.Sdk.Db.PostgreSql.Importer;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Db.PostgreSql
{
  public class PluginRepository : AbstractAddonRepository
  {
    public override IEnumerable<AbstractAdditionalTagger> AddonAdditionalTagger => null;

    public override IEnumerable<KeyValuePair<string, AbstractCorpusBuilder>> AddonBackends =>
      new Dictionary<string, AbstractCorpusBuilder>
      {
        {"CorpusExplorer <-> PostgreSQL", new CorpusBuilderPostgreSql()}
      };

    public override IEnumerable<IAction> AddonConsoleActions => null;

    public override IEnumerable<KeyValuePair<string, AbstractExporter>> AddonExporters =>
      new Dictionary<string, AbstractExporter>
      {
        {"CorpusExplorer <-> PostgreSQL (*.psql)|*.psql", new ExporterPostgreSql()},
        {"CorpusExplorer --> PostgreSQL (*.db)|*.db", new ExporterPostgreSqlFullAccess()}
      };

    public override IEnumerable<KeyValuePair<string, AbstractImporter>> AddonImporter =>
      new Dictionary<string, AbstractImporter>
      {
        {"CorpusExplorer <-> PostgreSQL (*.psql)|*.psql", new ImporterPostgreSql()}
      };

    public override IEnumerable<KeyValuePair<string, AbstractScraper>> AddonScrapers => null;
    public override IEnumerable<object> AddonSideloadFeature => null;
    public override IEnumerable<KeyValuePair<string, AbstractTableWriter>> AddonTableWriter => null;
    public override IEnumerable<AbstractTagger> AddonTagger => null;
    public override IEnumerable<IAddonView> AddonViews => null;
    public override string Guid => "CorpusExplorer.Sdk.Db.PostgreSql";
  }
}