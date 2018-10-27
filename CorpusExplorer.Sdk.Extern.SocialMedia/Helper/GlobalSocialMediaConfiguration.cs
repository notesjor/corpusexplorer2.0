using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Extern.SocialMedia.Interface;

namespace CorpusExplorer.Sdk.Extern.SocialMedia.Helper
{
  public static class GlobalSocialMediaConfiguration
  {
    public static ISimpleAuthenticationForm AuthenticationForm { get; set; }
  }
}
