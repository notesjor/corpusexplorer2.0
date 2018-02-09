#region

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Tei.Bare.Model;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Tei.Bare.Extension
{
  [SuppressMessage("ReSharper", "UnusedMember.Global")]
  public static class MacrospecialParaExtension
  {
    public static IEnumerable<modeldivPart> GetAllModeldivParts(this macrospecialPara macrospecialPara)
    {
      return macrospecialPara.Items.OfType<modeldivPart>().Select(o => o);
    }

    public static IEnumerable<modelphrase> GetAllModelphrases(this macrospecialPara macrospecialPara)
    {
      return macrospecialPara.Items.OfType<modelphrase>().Select(o => o);
    }
  }
}