#region

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Talkbank.Model;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Talkbank.Extension
{
  [SuppressMessage("ReSharper", "UnusedMember.Global")]
  public static class PhoTypeExtension
  {
    public static IEnumerable<constituentType> GetAllConstituentTypes(this phoType phoType)
    {
      return phoType.pw.OfType<constituentType>().Select(o => o);
    }

    public static IEnumerable<ss> GetAllSSs(this phoType phoType) { return phoType.pw.OfType<ss>().Select(o => o); }

    public static IEnumerable<wordnetMarkerType> GetAllWordnetMarkerTypes(this phoType phoType)
    {
      return phoType.pw.OfType<wordnetMarkerType>().Select(o => o);
    }
  }
}