#region

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Talkbank.Model;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Talkbank.Extension
{
  [SuppressMessage("ReSharper", "UnusedMember.Global")]
  public static class CommentTypeExtension
  {
    public static IEnumerable<mediaPicType> GetAllMediamediaPicTypes(this commentType commentType)
    {
      return commentType.Items.OfType<mediaPicType>().Select(o => o);
    }

    public static IEnumerable<mediaType> GetAllMediaTypes(this commentType commentType)
    {
      return commentType.Items.OfType<mediaType>().Select(o => o);
    }
  }
}