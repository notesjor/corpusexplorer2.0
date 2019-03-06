namespace CorpusExplorer.Sdk.Extern.OpenThesaurus.Db
{
  public static class OpenThesaurusConnection
  {
    public static OpenThesaurusContext Open(string connection = null)
    {
      return string.IsNullOrEmpty(connection)
               ? new
                 OpenThesaurusContext("User Id=root;Host=localhost;Database=openthesaurus;Persist Security Info=True;Unicode=True;")
               : new OpenThesaurusContext(connection);
    }
  }
}