using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Extern.SocialMedia.Abstract;
using Facebook;

namespace CorpusExplorer.Sdk.Extern.SocialMedia.Facebook
{
  public class FacebookAuthentication : AbstractSimpleAuthentication{
    protected override object OpenConnection()
    {
      return new FacebookClient(Settings["AccessToken"]);
    }

    public override string ProviderName => "Facebook";

    public override Dictionary<string, string> Settings { get; set; }
      = new Dictionary<string, string>
      {
        {"AccessToken", ""}
      };
  }

  public class FacebookService : AbstractService
  {
    protected override AbstractAuthentication Authentication { get; } = new FacebookAuthentication();
    protected override void Query(object connection, IEnumerable<string> queries, string outputPath)
    {
      var context = connection as FacebookClient;
    }
  }
}
