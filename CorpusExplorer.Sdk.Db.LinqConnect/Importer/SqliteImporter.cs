using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Db.LinqConnect.Adapter;
using CorpusExplorer.Sdk.Db.LinqConnect.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;
using Devart.Data.Linq.Mapping.Fluent;

namespace CorpusExplorer.Sdk.Db.LinqConnect.Importer
{
  public class SqliteImporter : AbstractImporter
  {
    protected override IEnumerable<AbstractCorpusAdapter> Execute(string importFilePath)
    {
      LinqConnectConfiguration.ConnectionString = $"data source={importFilePath};";

      return new[] {CorpusAdapterLinqConnect.Create()};
    }
  }
}
