using System.Text;
using Elasticsearch.Net;
using Nest;

namespace CorpusExplorer.Sdk.Db.Elastic.Sdk.Context
{
  public class ElasticSearchContextBase
  {
    protected ElasticClient _client;
    protected IConnectionPool _connection;
    protected string _index;
    protected ConnectionSettings _settings;

    public ElasticSearchContextBase(
      IConnectionPool connectionPool,
      string index,
      ElasticSearchContextCredentials credentials = null)
    {
      _index = index;
      _connection = connectionPool;
      _settings = new ConnectionSettings(connectionPool);

      if (credentials != null)
        _settings.BasicAuthentication(credentials.Username, credentials.Password);

      _settings.DefaultIndex(index);
      _client = new ElasticClient(_settings);

      if (!_client.Indices.Exists(index).Exists)
        _client.Indices.Create(index);
    }

    private ElasticSearchContextBase()
    {
    }

    public ElasticClient Client => _client;

    public string Connection
    {
      get
      {
        var stb = new StringBuilder();
        foreach (var node in _connection.Nodes)
          stb.AppendLine(node.Uri.ToString());
        return stb.ToString();
      }
    }

    public string Index => _index;

    public ConnectionSettings Settings => _settings;
  }
}