namespace CorpusExplorer.Sdk.Db.Elastic.Sdk.Context
{
  public class ElasticSearchContextCredentials
  {
    public ElasticSearchContextCredentials() { }

    public ElasticSearchContextCredentials(string username, string password)
    {
      Username = username;
      Password = password;
    }

    public string Password { get; set; }
    public string Username { get; set; }
  }
}