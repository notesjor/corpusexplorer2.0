#region

using System.Collections.Generic;
using CorpusExplorer.Sdk.Db.LinqConnect.Model;
using CorpusExplorer.Sdk.Db.SQLite.Adapter;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Db.SQLite.Importer
{
  public class ImporterSqlite : AbstractImporter
  {
    protected override IEnumerable<AbstractCorpusAdapter> Execute(string importFilePath)
    {
      LinqConnectConfiguration.ConnectionString = $"data source={importFilePath};";
      return CorpusAdapterLinqConnect.Create();
    }
  }
}