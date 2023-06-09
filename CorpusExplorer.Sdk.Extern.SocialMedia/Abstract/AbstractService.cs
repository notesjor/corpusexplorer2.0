using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Extern.SocialMedia.Delegates;

namespace CorpusExplorer.Sdk.Extern.SocialMedia.Abstract
{
  public abstract class AbstractService
  {
    public int Limit { get; set; } = 0;
    
    public void Run(AbstractAuthentication authentication, IEnumerable<string> queries, string outputPath)
    {
      Authentication = authentication;
      var connection = authentication.OpenConnection();
      if (connection == null)
        return;

      Query(connection, queries, outputPath, Limit);
      PostStatusUpdate("Alle Abrfagen wurden abgearbeitet!", 1, 1);
    }

    protected AbstractAuthentication Authentication { get; set; }

    protected abstract void Query(object connection, IEnumerable<string> queries, string outputPath, int limit);

    public StatusUpdateDelegate StatusUpdate;

    public void PostStatusUpdate(string message, int current, int total) => StatusUpdate?.Invoke(message, current, total);
  }
}
