#region

using CorpusExplorer.Sdk.Extern.Xml.Wikipedia.Model;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Wikipedia.Extension
{
  [SuppressMessage("ReSharper", "UnusedMember.Global")]
  public static class PageTypeExtension
  {
    public static IEnumerable<RevisionType> AllRevisionTypes(this PageType pageType)
    {
      return pageType.Items.OfType<RevisionType>().Select(item => item);
    }

    public static IEnumerable<UploadType> AllUploadTypes(this PageType pageType)
    {
      return pageType.Items.OfType<UploadType>().Select(item => item);
    }
  }
}