#region

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Exmaralda.Model;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Exmaralda.Extension
{
  [SuppressMessage("ReSharper", "UnusedMember.Global")]
  public static class SegmentationExtension
  {
    public static IEnumerable<ats> GetAllAts(this segmentation segmentation)
    {
      return segmentation.Items.OfType<ats>().Select(o => o);
    }

    public static IEnumerable<ts> GetAllTs(this segmentation segmentation)
    {
      return segmentation.Items.OfType<ts>().Select(o => o);
    }
  }
}