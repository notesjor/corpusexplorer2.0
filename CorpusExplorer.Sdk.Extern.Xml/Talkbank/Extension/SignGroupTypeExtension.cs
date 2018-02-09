#region

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Talkbank.Model;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Talkbank.Extension
{
  [SuppressMessage("ReSharper", "UnusedMember.Global")]
  public static class SignGroupTypeExtension
  {
    public static IEnumerable<eventType> GetAllEventTypes(this signGroupType signGroupType)
    {
      return signGroupType.Items.OfType<eventType>().Select(o => o);
    }

    public static IEnumerable<freecodeType> GetAllFreecodeTypes(this signGroupType signGroupType)
    {
      return signGroupType.Items.OfType<freecodeType>().Select(o => o);
    }

    public static IEnumerable<italic> GetAllItalics(this signGroupType signGroupType)
    {
      return signGroupType.Items.OfType<italic>().Select(o => o);
    }

    public static IEnumerable<longfeature> GetAllLongfeaturess(this signGroupType signGroupType)
    {
      return signGroupType.Items.OfType<longfeature>().Select(o => o);
    }

    public static IEnumerable<mediaType> GetAllMediaTypes(this signGroupType signGroupType)
    {
      return signGroupType.Items.OfType<mediaType>().Select(o => o);
    }

    public static IEnumerable<nonvocal> GetAllNonvocals(this signGroupType signGroupType)
    {
      return signGroupType.Items.OfType<nonvocal>().Select(o => o);
    }

    public static IEnumerable<overlapPointType> GetAllOverlapPointTypes(this signGroupType signGroupType)
    {
      return signGroupType.Items.OfType<overlapPointType>().Select(o => o);
    }

    public static IEnumerable<pauseType> GetAllPauseTypes(this signGroupType signGroupType)
    {
      return signGroupType.Items.OfType<pauseType>().Select(o => o);
    }

    public static IEnumerable<phoneticGroupType> GetAllPhoneticGroupTypes(this signGroupType signGroupType)
    {
      return signGroupType.Items.OfType<phoneticGroupType>().Select(o => o);
    }

    public static IEnumerable<quotation2> GetAllQuotation2s(this signGroupType signGroupType)
    {
      return signGroupType.Items.OfType<quotation2>().Select(o => o);
    }

    public static IEnumerable<quotation> GetAllQuotations(this signGroupType signGroupType)
    {
      return signGroupType.Items.OfType<quotation>().Select(o => o);
    }

    public static IEnumerable<separatorType> GetAllSeparatorTypes(this signGroupType signGroupType)
    {
      return signGroupType.Items.OfType<separatorType>().Select(o => o);
    }

    public static IEnumerable<signGroupType> GetAllsignGroupTypes(this signGroupType signGroupType)
    {
      return signGroupType.Items.OfType<signGroupType>().Select(o => o);
    }

    public static IEnumerable<signGroupType> GetAllSignsignGroupTypes(this signGroupType signGroupType)
    {
      return signGroupType.Items.OfType<signGroupType>().Select(o => o);
    }

    public static IEnumerable<tagMarkerType> GetAllTagMarkerTypes(this signGroupType signGroupType)
    {
      return signGroupType.Items.OfType<tagMarkerType>().Select(o => o);
    }

    public static IEnumerable<underline> GetAllUnderlines(this signGroupType signGroupType)
    {
      return signGroupType.Items.OfType<underline>().Select(o => o);
    }

    public static IEnumerable<wordType> GetAllWordTypes(this signGroupType signGroupType)
    {
      return signGroupType.Items.OfType<wordType>().Select(o => o);
    }
  }
}