﻿#region

using System.Collections.Generic;
using CorpusExplorer.Sdk.Db.Gui;
using CorpusExplorer.Sdk.Db.LinqConnect.Model;
using CorpusExplorer.Sdk.Db.MySql.Adapter;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Db.MySql.Importer
{
  public class ImporterMySql : AbstractImporter
  {
    private string CreateConnectionString(DbSettingsReader setting) =>
      $"user id={setting.Username};password={setting.Password};host={setting.Host};port={setting.Port};database={setting.DbName};persist security info=True";

    protected override IEnumerable<AbstractCorpusAdapter> Execute(string importFilePath)
    {
      LinqConnectConfiguration.ConnectionString = CreateConnectionString(new DbSettingsReader(importFilePath));
      return CorpusAdapterLinqConnect.Create();
    }
  }
}