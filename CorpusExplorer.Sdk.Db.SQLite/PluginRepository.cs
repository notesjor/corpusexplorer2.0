#region

using System.Collections.Generic;
using CorpusExplorer.Sdk.Addon;
using CorpusExplorer.Sdk.Db.SQLite.Builder;
using CorpusExplorer.Sdk.Db.SQLite.Exporter;
using CorpusExplorer.Sdk.Db.SQLite.Importer;
using CorpusExplorer.Sdk.Db.SQLite.TableWriter;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Db.SQLite
{
  public class PluginRepository : AbstractAddonRepository
  {
    public override IEnumerable<AbstractAdditionalTagger> AddonAdditionalTagger => null;

    public override IEnumerable<KeyValuePair<string, AbstractCorpusBuilder>> AddonBackends =>
      new Dictionary<string, AbstractCorpusBuilder>
      {
        {"CorpusExplorer <-> SQLite", new CorpusBuilderSqlite()}
      };

    public override IEnumerable<IAction> AddonConsoleActions => null;

    public override IEnumerable<KeyValuePair<string, AbstractExporter>> AddonExporters =>
      new Dictionary<string, AbstractExporter>
      {
        {"CorpusExplorer <-> SQLite (*.db)|*.db", new ExporterSqlite()},
        {"CorpusExplorer --> Coquery.org SQLite (*.db)|*.db", new ExporterCoQuery()},
        {"CorpusExplorer --> SQLite (*.db)|*.db", new ExporterFullAccess()}
      };

    public override IEnumerable<KeyValuePair<string, AbstractImporter>> AddonImporter =>
      new Dictionary<string, AbstractImporter>
      {
        {"CorpusExplorer <-> SQLite (*.s3db)|*.s3db", new ImporterSqlite()}
      };

    public override IEnumerable<KeyValuePair<string, AbstractScraper>> AddonScrapers => null;
    public override IEnumerable<object> AddonSideloadFeature => null;
    public override IEnumerable<KeyValuePair<string, AbstractTableWriter>> AddonTableWriter => 
      new Dictionary<string, AbstractTableWriter>
      {
        {"SQLite-Datenbank (*.db)|*.db", new SQLiteTableWriter()}
      };
    public override IEnumerable<AbstractTagger> AddonTagger => null;
    public override IEnumerable<IAddonView> AddonViews => null;
    public override string Guid => "CorpusExplorer.Sdk.Db.SQLite";
  }
}