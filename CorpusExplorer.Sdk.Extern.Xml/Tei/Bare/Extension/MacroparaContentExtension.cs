#region

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Tei.Bare.Model;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Tei.Bare.Extension
{
  [SuppressMessage("ReSharper", "UnusedMember.Global")]
  public static class MacroparaContentExtension
  {
    public static IEnumerable<modelphrase> GetAllModelphrases(this macroparaContent macroparaContent)
    {
      return macroparaContent.Items.OfType<modelphrase>().Select(o => o);
    }
  }
}