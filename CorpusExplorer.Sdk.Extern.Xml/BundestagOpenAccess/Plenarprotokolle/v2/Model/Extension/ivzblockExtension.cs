using System.Collections.Generic;
using System.Linq;

namespace CorpusExplorer.Sdk.Extern.Xml.BundestagOpenAccess.Plenarprotokolle.v2.Model.Extension
{
  public static class ivzblockExtension
  {
    public static IEnumerable<ivzeintrag> Ivzeintrag(this ivzblock obj)
      => obj.Items?.OfType<ivzeintrag>();

    public static IEnumerable<ivzblock> Ivzblock(this ivzblock obj)
      => obj.Items?.OfType<ivzblock>();
  }
}