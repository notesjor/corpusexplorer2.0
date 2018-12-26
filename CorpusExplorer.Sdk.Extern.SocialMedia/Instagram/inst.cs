using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Extern.SocialMedia.Abstract;
using InstaSharp;

namespace CorpusExplorer.Sdk.Extern.SocialMedia.Instagram
{
  public class InstagramAuthentication : AbstractAuthentication
  {
    protected override object OpenConnection()
    {
      return new OAuth(new InstagramConfig(Settings["ClientId"], Settings["ClientSecret"]));
    }

    public override string ProviderName { get; }

    public override Dictionary<string, string> Settings { get; set; }
      = new Dictionary<string, string>
      {
        {"ClientId", ""},
        {"ClientSecret", ""}
      };
  }
}
