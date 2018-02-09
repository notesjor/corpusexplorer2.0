using System;
using System.Linq;
using CorpusExplorer.Sdk.Db.Elastic.Sdk.Context;
using Elasticsearch.Net;

namespace CorpusExplorer.Sdk.Db.Elastic.Model.Context
{
  public static class ElasticSearchContextManager
  {
    private static ElasticSearchContext _context;

    public static ElasticSearchContext GetContext() => _context;

    public static void Initialize(string nodeUrl, string index, ElasticSearchContextCredentials credentials = null)
    {
      Initialize(new[] {nodeUrl}, index, credentials);
    }

    public static void Initialize(string[] nodes, string index, ElasticSearchContextCredentials credentials = null)
    {
      Initialize(new StaticConnectionPool(nodes.Select(x => new Uri(x))), index, credentials);
    }

    private static void Initialize(
      IConnectionPool connectionPool,
      string index,
      ElasticSearchContextCredentials credentials = null)
    {
      // Notwendig für korrektes INIT mit allen ElasticSearch Versionen
      new ElasticSearchContext(connectionPool, index, credentials);
      _context = new ElasticSearchContext(connectionPool, index, credentials);
    }
  }
}