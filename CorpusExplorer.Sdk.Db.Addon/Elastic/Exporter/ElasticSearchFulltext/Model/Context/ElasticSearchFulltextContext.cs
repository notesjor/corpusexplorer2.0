using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Db.Elastic.Sdk.Context;
using CorpusExplorer.Sdk.Diagnostic;
using Elasticsearch.Net;
using Nest;

namespace CorpusExplorer.Sdk.Db.Addon.Elastic.Exporter.ElasticSearchFulltext.Model.Context
{
  public class ElasticSearchFulltextContext : ElasticSearchContextBase
  {
    public ElasticSearchFulltextContext(
      IConnectionPool connectionPool,
      string index,
      ElasticSearchContextCredentials credentials = null)
      : base(connectionPool, index, credentials)
    {
      var map = Client.Map<Document>(m => m.AutoMap());
      if (map.OriginalException != null)
        InMemoryErrorConsole.Log(map.OriginalException);
    }

    public void Add(Document document)
    {
      var res = _client.Index(document);
      if (res.OriginalException != null)
        InMemoryErrorConsole.Log(res.OriginalException);
    }    
  }
}