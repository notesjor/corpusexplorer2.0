#region

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Tei.Bare.Model;
using head = CorpusExplorer.Sdk.Extern.Xml.IdsXces.Model.head;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Tei.Bare.Extension
{
  [SuppressMessage("ReSharper", "UnusedMember.Global")]
  public static class HeadExtension
  {
    public static IEnumerable<modelphrase> GetAllModelphrases(this head head)
    {
      return head.Items.OfType<modelphrase>().Select(o => o);
    }
  }
}