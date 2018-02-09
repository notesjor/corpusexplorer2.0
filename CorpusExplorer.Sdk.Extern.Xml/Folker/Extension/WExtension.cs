#region

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Folker.Model;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Folker.Extension
{
  [SuppressMessage("ReSharper", "UnusedMember.Global")]
  public static class WExtension
  {
    public static IEnumerable<lengthening> GetAllLengthenings(this w w)
    {
      return w.Items.OfType<lengthening>().Select(o => o);
    }

    public static IEnumerable<stress> GetAllStress(this w w) { return w.Items.OfType<stress>().Select(o => o); }

    public static IEnumerable<time> GetAllTimes(this w w) { return w.Items.OfType<time>().Select(o => o); }
  }
}