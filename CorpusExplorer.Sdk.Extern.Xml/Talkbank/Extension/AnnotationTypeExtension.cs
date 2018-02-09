#region

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Talkbank.Model;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Talkbank.Extension
{
  [SuppressMessage("ReSharper", "UnusedMember.Global")]
  public static class AnnotationTypeExtension
  {
    public static IEnumerable<mediaPicType> GetAllMediamediaPicTypes(this annotationType annotationType)
    {
      return annotationType.Items.OfType<mediaPicType>().Select(o => o);
    }

    public static IEnumerable<mediaType> GetAllMediaTypes(this annotationType annotationType)
    {
      return annotationType.Items.OfType<mediaType>().Select(o => o);
    }
  }
}