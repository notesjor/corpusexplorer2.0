#region

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Tei.Bare.Model;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Tei.Bare.Extension
{
  [SuppressMessage("ReSharper", "UnusedMember.Global")]
  public static class FrontModeldivLikeDivExtension
  {
    public static IEnumerable<frontModeldivLikeDiv> GetAllfrontModeldivLikeDivs(
      this frontModeldivLikeDiv frontModeldivLikeDiv)
    {
      return frontModeldivLikeDiv.Items.OfType<frontModeldivLikeDiv>().Select(o => o);
    }
  }
}