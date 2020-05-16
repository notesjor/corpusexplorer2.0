using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Txm.Model;

namespace CorpusExplorer.Sdk.Extern.Xml.Txm.Extension
{
  public static class sExtension
  {
    public static IEnumerable<w> GetW(this s s) => s.Items.OfType<w>();
  }
}
