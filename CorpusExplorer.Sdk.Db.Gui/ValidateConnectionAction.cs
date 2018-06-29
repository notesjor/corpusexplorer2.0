namespace CorpusExplorer.Sdk.Db.Gui
{
  public delegate bool ValidateConnectionAction(string host, int port, string dbName, string user, string password);
}