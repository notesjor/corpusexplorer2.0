using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpusExplorer.Sdk.Extern.Xml.BundestagOpenAccess.Plenarprotokolle.v2.Model.Extension
{
  public static class ivzeintragExtension
  {
    public static IEnumerable<a> A(this ivzeintrag obj)
    => obj.Items?.OfType<a>();

    public static IEnumerable<ivzeintraginhalt> Ivzeintraginhalt(this ivzeintrag obj)
      => obj.Items?.OfType<ivzeintraginhalt>();

    public static IEnumerable<xref> Xref(this ivzeintrag obj)
      => obj.Items?.OfType<xref>();
  }
}
