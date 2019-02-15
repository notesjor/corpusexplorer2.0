using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Db.Elastic.Sdk.Context;
using Elasticsearch.Net;

namespace CorpusExplorer.Sdk.Db.ElasticSearch.Elastic.Exporter.ElasticSearchFulltext.Model.Context
{
  public static class ElasticSearchFulltextContextManager
  {
    private static ElasticSearchFulltextContext _context;

    public static ElasticSearchFulltextContext GetContext()
    {
      return _context;
    }

    public static void Initialize(
      IEnumerable<string> connectionPool,
      string index,
      ElasticSearchContextCredentials credentials = null)
    {
      Initialize(
                 connectionPool.Select(x => new Uri(x.Replace("\r\n", "").Replace("\r", "").Replace("\n", "")))
                               .ToArray(), index,
                 credentials);
    }

    public static void Initialize(
      IEnumerable<Uri> connectionPool,
      string index,
      ElasticSearchContextCredentials credentials = null)
    {
      Initialize(new StaticConnectionPool(connectionPool), index, credentials);
    }

    private static void Initialize(
      IConnectionPool connectionPool,
      string index,
      ElasticSearchContextCredentials credentials = null)
    {
      // Notwendig für korrektes INIT mit allen ElasticSearch Versionen
      new ElasticSearchFulltextContext(connectionPool, index, credentials);
      _context = new ElasticSearchFulltextContext(connectionPool, index, credentials);
    }
  }
}