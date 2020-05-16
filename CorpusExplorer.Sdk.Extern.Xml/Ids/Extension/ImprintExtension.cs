using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Extern.Xml.Ids.Model;

namespace CorpusExplorer.Sdk.Extern.Xml.Ids.Extension
{
  public static class ImprintExtension
  {
    public static IEnumerable<pubDate> GetPubDates(this imprint obj)
      => obj.Items.OfType<pubDate>();
  }
}
