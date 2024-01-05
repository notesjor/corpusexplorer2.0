using System.Data.Common;

namespace CorpusExplorer.Sdk.Db.Core.Model.SimpleBinary.Manager
{
  public static class CoreBinaryContextManager
  {
    private static CoreBinaryContext _context;

    public static CoreBinaryContext GetContext() => _context;

    public static void Initialize(string connectionString) { _context = new CoreBinaryContext(connectionString); }

    public static void Initialize(DbConnection connection) { _context = new CoreBinaryContext(connection); }
  }
}