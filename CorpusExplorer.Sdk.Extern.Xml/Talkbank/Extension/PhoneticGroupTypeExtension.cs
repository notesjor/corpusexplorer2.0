#region

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Talkbank.Model;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Talkbank.Extension
{
  [SuppressMessage("ReSharper", "UnusedMember.Global")]
  public static class PhoneticGroupTypeExtension
  {
    //

    public static IEnumerable<actualPhoType> GetAllActualPhoTypes(this phoneticGroupType phoneticGroupType)
    {
      return phoneticGroupType.Items1.OfType<actualPhoType>().Select(o => o);
    }

    public static IEnumerable<eventType> GetAllEventTypes(this phoneticGroupType phoneticGroupType)
    {
      return phoneticGroupType.Items.OfType<eventType>().Select(o => o);
    }

    public static IEnumerable<freecodeType> GetAllFreecodeTypes(this phoneticGroupType phoneticGroupType)
    {
      return phoneticGroupType.Items.OfType<freecodeType>().Select(o => o);
    }

    public static IEnumerable<italic> GetAllItalics(this phoneticGroupType phoneticGroupType)
    {
      return phoneticGroupType.Items.OfType<italic>().Select(o => o);
    }

    public static IEnumerable<longfeature> GetAllLongfeaturess(this phoneticGroupType phoneticGroupType)
    {
      return phoneticGroupType.Items.OfType<longfeature>().Select(o => o);
    }

    public static IEnumerable<mediaType> GetAllMediaTypes(this phoneticGroupType phoneticGroupType)
    {
      return phoneticGroupType.Items.OfType<mediaType>().Select(o => o);
    }

    public static IEnumerable<modelPhoType> GetAllModelPhoTypes(this phoneticGroupType phoneticGroupType)
    {
      return phoneticGroupType.Items1.OfType<modelPhoType>().Select(o => o);
    }

    public static IEnumerable<nonvocal> GetAllNonvocals(this phoneticGroupType phoneticGroupType)
    {
      return phoneticGroupType.Items.OfType<nonvocal>().Select(o => o);
    }

    public static IEnumerable<overlapPointType> GetAllOverlapPointTypes(this phoneticGroupType phoneticGroupType)
    {
      return phoneticGroupType.Items.OfType<overlapPointType>().Select(o => o);
    }

    public static IEnumerable<pauseType> GetAllPauseTypes(this phoneticGroupType phoneticGroupType)
    {
      return phoneticGroupType.Items.OfType<pauseType>().Select(o => o);
    }

    public static IEnumerable<phoneticGroupType> GetAllphoneticGroupTypes(this phoneticGroupType phoneticGroupType)
    {
      return phoneticGroupType.Items.OfType<phoneticGroupType>().Select(o => o);
    }

    public static IEnumerable<phoneticGroupType> GetAllPhoneticGroupTypes(this phoneticGroupType phoneticGroupType)
    {
      return phoneticGroupType.Items.OfType<phoneticGroupType>().Select(o => o);
    }

    public static IEnumerable<quotation2> GetAllQuotation2s(this phoneticGroupType phoneticGroupType)
    {
      return phoneticGroupType.Items.OfType<quotation2>().Select(o => o);
    }

    public static IEnumerable<quotation> GetAllQuotations(this phoneticGroupType phoneticGroupType)
    {
      return phoneticGroupType.Items.OfType<quotation>().Select(o => o);
    }

    public static IEnumerable<separatorType> GetAllSeparatorTypes(this phoneticGroupType phoneticGroupType)
    {
      return phoneticGroupType.Items.OfType<separatorType>().Select(o => o);
    }

    public static IEnumerable<signGroupType> GetAllSignGroupTypes(this phoneticGroupType phoneticGroupType)
    {
      return phoneticGroupType.Items.OfType<signGroupType>().Select(o => o);
    }

    public static IEnumerable<tagMarkerType> GetAllTagMarkerTypes(this phoneticGroupType phoneticGroupType)
    {
      return phoneticGroupType.Items.OfType<tagMarkerType>().Select(o => o);
    }

    public static IEnumerable<underline> GetAllUnderlines(this phoneticGroupType phoneticGroupType)
    {
      return phoneticGroupType.Items.OfType<underline>().Select(o => o);
    }

    public static IEnumerable<wordType> GetAllWordTypes(this phoneticGroupType phoneticGroupType)
    {
      return phoneticGroupType.Items.OfType<wordType>().Select(o => o);
    }
  }
}