using System;
using System.Collections.Generic;
using CorpusExplorer.Sdk.Db.Gui;
using CorpusExplorer.Sdk.Db.LinqConnect.Model;
using CorpusExplorer.Sdk.Db.MySql.Adapter;
using CorpusExplorer.Sdk.Db.MySQL.Model;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract.Model.Abstract;

namespace CorpusExplorer.Sdk.Db.MySql.Builder
{
  public class CorpusBuilderMySql : AbstractCorpusBuilder
  {
    public string CorpusDisplayname { get; set; } = "MySQL";

    public string SaveSettingsPath { get; set; }

    protected override AbstractCorpusAdapter CreateCorpus(
      Dictionary<Guid, Dictionary<string, object>> documentMetadata,
      Dictionary<string, object> corpusMetadata,
      List<Concept> concepts)
    {
      var setting = FormHelper.Show("MySQL",
                                    "localhost",
                                    3306, (host, port, dbName, user, password) =>
                                    {
                                      var context =
                                        new DataContext(CreateConnectionString(host, port, dbName, user, password));
                                      if (!context.DatabaseExists())
                                        context.CreateDatabase(true, true);

                                      return context.DatabaseExists();
                                    },
                                    "CorpusExplorer <-> MySQL (*.mysql)|*.mysql",
                                    SaveSettingsPath);

      LinqConnectConfiguration.ConnectionString = CreateConnectionString(setting);

      return CorpusAdapterLinqConnect.Create(CorpusDisplayname, documentMetadata, corpusMetadata, concepts);
    }

    protected override AbstractLayerAdapter CreateLayer(
      AbstractCorpusAdapter corpus,
      AbstractLayerState layer)
    {
      return LayerAdapterLinqConnect.Create(corpus, layer);
    }

    private string CreateConnectionString(DbSettingsReader setting)
      => CreateConnectionString(setting.Host, setting.Port, setting.DbName, setting.Username, setting.Password);

    private string CreateConnectionString(string host, int port, string dbName, string user, string password)
      => $"user id={user};password={password};host={host};port={port};database={dbName};persist security info=True";
  }
}