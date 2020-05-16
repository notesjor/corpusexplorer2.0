#region

using System;
using System.Collections.Generic;
using CorpusExplorer.Sdk.Db.Gui;
using CorpusExplorer.Sdk.Db.LinqConnect.Model;
using CorpusExplorer.Sdk.Db.PostgreSql.Adapter;
using CorpusExplorer.Sdk.Db.PostgreSql.Model.Data;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract.Model.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Db.PostgreSql.Builder
{
  public class CorpusBuilderPostgreSql : AbstractCorpusBuilder
  {
    public string CorpusDisplayname { get; set; } = "PostgreSQL";

    public string SaveSettingsPath { get; set; }

    private string CreateConnectionString(DbSettingsReader setting)
    {
      return CreateConnectionString(setting.Host, setting.Port, setting.DbName, setting.Username, setting.Password);
    }

    private string CreateConnectionString(string host, int port, string dbName, string user, string password)
    {
      return $"user id={user};password={password};host={host};port={port};database={dbName}";
    }

    protected override AbstractCorpusAdapter CreateCorpus(
      Dictionary<Guid, Dictionary<string, object>> documentMetadata,
      Dictionary<string, object> corpusMetadata,
      List<Concept> concepts)
    {
      var setting = FormHelper.Show("PostgreSQL",
                                    "localhost",
                                    5432, (host, port, dbName, user, password) =>
                                    {
                                      var context =
                                        new DataContext(CreateConnectionString(host, port, dbName, user, password));
                                      if (!context.DatabaseExists())
                                        context.CreateDatabase(true, true);

                                      return context.DatabaseExists();
                                    },
                                    "CorpusExplorer <-> PostgreSQL (*.psql)|*.psql",
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
  }
}