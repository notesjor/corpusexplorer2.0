using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Extern.SocialMedia.Abstract;
using Facebook;

namespace CorpusExplorer.Sdk.Extern.SocialMedia.Facebook
{
  public class FacebookStatusCommentsService : AbstractService
  {
    protected override void Query(object connection, IEnumerable<string> queries, string outputPath)
    {
      var client = connection as FacebookClient;
      if (client == null)
        return;

      foreach (var query in queries)
      {
        var status = client.Get($"{query}/comments");
        Console.Write(status);
      }
    }
  }
}
