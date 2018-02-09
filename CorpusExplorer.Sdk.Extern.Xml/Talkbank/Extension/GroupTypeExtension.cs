#region

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Talkbank.Model;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Talkbank.Extension
{
  [SuppressMessage("ReSharper", "UnusedMember.Global")]
  public static class GroupTypeExtension
  {
    //

    public static IEnumerable<decimal> GetAllDurations(this groupType groupType)
    {
      return groupType.Items1.OfType<decimal>().Select(o => o);
    }

    public static IEnumerable<string> GetAllErrors(this groupType groupType)
    {
      return groupType.Items1.OfType<string>().Select(o => o);
    }

    public static IEnumerable<eventType> GetAllEventTypes(this groupType groupType)
    {
      return groupType.Items.OfType<eventType>().Select(o => o);
    }

    public static IEnumerable<freecodeType> GetAllFreecodeTypes(this groupType groupType)
    {
      return groupType.Items.OfType<freecodeType>().Select(o => o);
    }

    public static IEnumerable<groupAnnotationType> GetAllGroupAnnoationTypes(this groupType groupType)
    {
      return groupType.Items1.OfType<groupAnnotationType>().Select(o => o);
    }

    public static IEnumerable<groupType> GetAllGroupTypes(this groupType groupType)
    {
      return groupType.Items.OfType<groupType>().Select(o => o);
    }

    public static IEnumerable<italic> GetAllItalics(this groupType groupType)
    {
      return groupType.Items.OfType<italic>().Select(o => o);
    }

    public static IEnumerable<longfeature> GetAllLongfeaturess(this groupType groupType)
    {
      return groupType.Items.OfType<longfeature>().Select(o => o);
    }

    public static IEnumerable<markers> GetAllMarkers(this groupType groupType)
    {
      return groupType.Items1.OfType<markers>().Select(o => o);
    }

    public static IEnumerable<mediaType> GetAllMediaTypes(this groupType groupType)
    {
      return groupType.Items.OfType<mediaType>().Select(o => o);
    }

    public static IEnumerable<nonvocal> GetAllNonvocals(this groupType groupType)
    {
      return groupType.Items.OfType<nonvocal>().Select(o => o);
    }

    public static IEnumerable<overlapPointType> GetAllOverlapPointTypes(this groupType groupType)
    {
      return groupType.Items.OfType<overlapPointType>().Select(o => o);
    }

    public static IEnumerable<overlapType> GetAllOverlapTypes(this groupType groupType)
    {
      return groupType.Items1.OfType<overlapType>().Select(o => o);
    }

    public static IEnumerable<pauseType> GetAllPauseTypes(this groupType groupType)
    {
      return groupType.Items.OfType<pauseType>().Select(o => o);
    }

    public static IEnumerable<phoneticGroupType> GetAllPhoneticGroupTypes(this groupType groupType)
    {
      return groupType.Items.OfType<phoneticGroupType>().Select(o => o);
    }

    public static IEnumerable<quotation2> GetAllQuotation2s(this groupType groupType)
    {
      return groupType.Items.OfType<quotation2>().Select(o => o);
    }

    public static IEnumerable<quotation> GetAllQuotations(this groupType groupType)
    {
      return groupType.Items.OfType<quotation>().Select(o => o);
    }

    public static IEnumerable<repetitionType> GetAllRepetitionType(this groupType groupType)
    {
      return groupType.Items1.OfType<repetitionType>().Select(o => o);
    }

    public static IEnumerable<separatorType> GetAllSeparatorTypes(this groupType groupType)
    {
      return groupType.Items.OfType<separatorType>().Select(o => o);
    }

    public static IEnumerable<signGroupType> GetAllSignGroupTypes(this groupType groupType)
    {
      return groupType.Items.OfType<signGroupType>().Select(o => o);
    }

    public static IEnumerable<tagMarkerType> GetAllTagMarkerTypes(this groupType groupType)
    {
      return groupType.Items.OfType<tagMarkerType>().Select(o => o);
    }

    public static IEnumerable<underline> GetAllUnderlines(this groupType groupType)
    {
      return groupType.Items.OfType<underline>().Select(o => o);
    }

    public static IEnumerable<wordType> GetAllWordTypes(this groupType groupType)
    {
      return groupType.Items.OfType<wordType>().Select(o => o);
    }
  }
}