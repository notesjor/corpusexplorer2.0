#region

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Tei.Speech.Model;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Tei.Speech.Extension
{
  [SuppressMessage("ReSharper", "UnusedMember.Global")]
  public static class UExtension
  {
    public static IEnumerable<anchor> GetAllAnchors(this u u)
    {
      return u.Items.OfType<anchor>().Select(o => o);
    }

    public static IEnumerable<seg> GetAllSegs(this u u)
    {
      return u.Items.OfType<seg>().Select(o => o);
    }
  }
}