#region

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Exmaralda.Model;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Exmaralda.Extension
{
  [SuppressMessage("ReSharper", "UnusedMember.Global")]
  public static class TsExtension
  {
    public static IEnumerable<ats> GetAllAts(this ts ts)
    {
      return ts.Items.OfType<ats>().Select(o => o);
    }

    public static IEnumerable<nts> GetAllNts(this ts ts)
    {
      return ts.Items.OfType<nts>().Select(o => o);
    }

    public static IEnumerable<ts> GetAllTs(this ts ts)
    {
      return ts.Items.OfType<ts>().Select(o => o);
    }
  }
}