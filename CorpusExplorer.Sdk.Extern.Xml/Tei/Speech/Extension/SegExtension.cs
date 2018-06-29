#region

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Tei.Speech.Model;
using w = CorpusExplorer.Sdk.Extern.Xml.Folker.Model.w;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Tei.Speech.Extension
{
  [SuppressMessage("ReSharper", "UnusedMember.Global")]
  public static class SegExtension
  {
    public static IEnumerable<anchor> GetAllAnchors(this seg seg)
    {
      return seg.Items.OfType<anchor>().Select(o => o);
    }

    public static IEnumerable<string> GetAllCs(this seg seg)
    {
      return seg.Items.OfType<string>().Select(o => o);
    }

    public static IEnumerable<incident> GetAllIncidents(this seg seg)
    {
      return seg.Items.OfType<incident>().Select(o => o);
    }

    public static IEnumerable<pause> GetAllPauses(this seg seg)
    {
      return seg.Items.OfType<pause>().Select(o => o);
    }

    public static IEnumerable<unclear> GetAllUnclears(this seg seg)
    {
      return seg.Items.OfType<unclear>().Select(o => o);
    }

    public static IEnumerable<w> GetAllWs(this seg seg)
    {
      return seg.Items.OfType<w>().Select(o => o);
    }
  }
}