using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Extern.SocialMedia.Abstract;
using CorpusExplorer.Sdk.Helper;
using WordPressPCL;
using WordPressPCL.Client;
using WordPressPCL.Models;

namespace CorpusExplorer.Sdk.Extern.SocialMedia.Wordpress
{
  public class WordPressNoAuthentication : AbstractSimpleAuthentication
  {
    protected override object OpenConnection()
    {
      return new WordPressClient($"{Settings["Url"]}/wp-json/".Replace("//", "/"));
    }

    public override string ProviderName => "WordPress NoAuth";
    public override Dictionary<string, string> Settings { get; set; }
      = new Dictionary<string, string>
      {
        {"Url", ""},
      };
  }
}
