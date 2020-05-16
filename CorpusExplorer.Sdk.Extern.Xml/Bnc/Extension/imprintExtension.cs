using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Extern.Xml.Bnc.Model;

namespace CorpusExplorer.Sdk.Extern.Xml.Bnc.Extension
{
  public static class imprintExtension
  {
    public static IEnumerable<date> Date(this imprint obj)
      => obj.Items?.OfType<date>();

    public static IEnumerable<pubPlace> PubPlace(this imprint obj)
      => obj.Items?.OfType<pubPlace>();

    public static IEnumerable<publisher> Publisher(this imprint obj)
      => obj.Items?.OfType<publisher>();
  }
}
