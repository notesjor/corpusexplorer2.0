using Germanet13Context;

namespace CorpusExplorer.Sdk.Extern.GermaNet.Model
{
  public static class GermaNetConnection
  {
    public static Germanet13DataContext Open(string connection = null)
    {
      return string.IsNullOrEmpty(connection)
               ? new
                 Germanet13DataContext("User Id=germanet;Password=germanet;Host=localhost;Database=germanet13;Persist Security Info=True;Initial Schema=public;Unicode=True;")
               : new Germanet13DataContext(connection);
    }
  }
}