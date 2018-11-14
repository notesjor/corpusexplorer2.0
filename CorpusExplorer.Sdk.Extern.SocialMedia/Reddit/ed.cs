using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Extern.SocialMedia.Abstract;

namespace CorpusExplorer.Sdk.Extern.SocialMedia.Reddit
{
  public class RedditAuthentication : AbstractSimpleAuthentication
  {
    protected override object OpenConnection()
    {
      throw new NotImplementedException();
    }

    public override string ProviderName { get; }
    public override Dictionary<string, string> Settings { get; set; }
  }
}