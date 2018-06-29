using System.Collections.Generic;
using System.Linq;
using Bcs.IO;
using CorpusExplorer.Sdk.Db.Elastic;
using CorpusExplorer.Sdk.Db.Elastic.Adapter;
using CorpusExplorer.Sdk.Db.Elastic.Model.Context;
using CorpusExplorer.Sdk.Db.Elastic.Sdk.Context;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;

namespace CorpusExplorer.Sdk.Db.Addon.Elastic.Importer
{
  public class ElasticSearchImporter : AbstractImporter
  {
    protected override IEnumerable<AbstractCorpusAdapter> Execute(string importFilePath)
    {
      var lines = FileIO.ReadLines(importFilePath);
      if (lines.Length < 3 || lines.Length > 6)
        return null;

      if (lines[0] != typeof(CorpusBuilderElasticSearch).ToString())
        return null;

      ElasticSearchContextManager
        .Initialize(
          new[] {$"{lines[1]}:{lines[2]}"},
          lines[3].ToLower(),
          lines.Length < 6 || string.IsNullOrEmpty(lines[4])
            ? null
            : new ElasticSearchContextCredentials(lines[4], lines[5]));

      var context = ElasticSearchContextManager.GetContext();
      return context.GetCorpora().Select(guid => CorpusAdapterElasticSearch.Create(context, guid));
    }
  }
}