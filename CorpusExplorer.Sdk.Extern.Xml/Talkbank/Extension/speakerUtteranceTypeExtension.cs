#region

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Talkbank.Model;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Talkbank.Extension
{
  [SuppressMessage("ReSharper", "UnusedMember.Global")]
  public static class speakerUtteranceTypeExtension
  {
    //

    public static IEnumerable<annotationType> GetAllAnnotationTypes(this speakerUtteranceType speakerUtteranceType)
    {
      return speakerUtteranceType.Items1.OfType<annotationType>().Select(o => o);
    }

    public static IEnumerable<string> GetAllErrors(this speakerUtteranceType speakerUtteranceType)
    {
      return speakerUtteranceType.Items1.OfType<string>().Select(o => o);
    }

    public static IEnumerable<eventType> GetAllEventTypes(this speakerUtteranceType speakerUtteranceType)
    {
      return speakerUtteranceType.Items.OfType<eventType>().Select(o => o);
    }

    public static IEnumerable<freecodeType> GetAllFreecodeTypes(this speakerUtteranceType speakerUtteranceType)
    {
      return speakerUtteranceType.Items.OfType<freecodeType>().Select(o => o);
    }

    public static IEnumerable<groupType> GetAllGroupTypes(this speakerUtteranceType speakerUtteranceType)
    {
      return speakerUtteranceType.Items.OfType<groupType>().Select(o => o);
    }

    public static IEnumerable<italic> GetAllItalics(this speakerUtteranceType speakerUtteranceType)
    {
      return speakerUtteranceType.Items.OfType<italic>().Select(o => o);
    }

    public static IEnumerable<longfeature> GetAllLongfeaturess(this speakerUtteranceType speakerUtteranceType)
    {
      return speakerUtteranceType.Items.OfType<longfeature>().Select(o => o);
    }

    public static IEnumerable<markers> GetAllMarkers(this speakerUtteranceType speakerUtteranceType)
    {
      return speakerUtteranceType.Items1.OfType<markers>().Select(o => o);
    }

    public static IEnumerable<mediaType> GetAllMediaTypes(this speakerUtteranceType speakerUtteranceType)
    {
      return speakerUtteranceType.Items.OfType<mediaType>().Select(o => o);
    }

    public static IEnumerable<nonvocal> GetAllNonvocals(this speakerUtteranceType speakerUtteranceType)
    {
      return speakerUtteranceType.Items.OfType<nonvocal>().Select(o => o);
    }

    public static IEnumerable<overlapPointType> GetAllOverlapPointTypes(this speakerUtteranceType speakerUtteranceType)
    {
      return speakerUtteranceType.Items.OfType<overlapPointType>().Select(o => o);
    }

    public static IEnumerable<pauseType> GetAllPauseTypes(this speakerUtteranceType speakerUtteranceType)
    {
      return speakerUtteranceType.Items.OfType<pauseType>().Select(o => o);
    }

    public static IEnumerable<phoneticGroupType> GetAllPhoneticGroupTypes(
      this speakerUtteranceType speakerUtteranceType)
    {
      return speakerUtteranceType.Items.OfType<phoneticGroupType>().Select(o => o);
    }

    public static IEnumerable<quotation2> GetAllQuotation2s(this speakerUtteranceType speakerUtteranceType)
    {
      return speakerUtteranceType.Items.OfType<quotation2>().Select(o => o);
    }

    public static IEnumerable<quotation> GetAllQuotations(this speakerUtteranceType speakerUtteranceType)
    {
      return speakerUtteranceType.Items.OfType<quotation>().Select(o => o);
    }

    public static IEnumerable<repetitionType> GetAllRepetitionTypes(this speakerUtteranceType speakerUtteranceType)
    {
      return speakerUtteranceType.Items1.OfType<repetitionType>().Select(o => o);
    }

    public static IEnumerable<separatorType> GetAllSeparatorTypes(this speakerUtteranceType speakerUtteranceType)
    {
      return speakerUtteranceType.Items.OfType<separatorType>().Select(o => o);
    }

    public static IEnumerable<signGroupType> GetAllSignGroupTypes(this speakerUtteranceType speakerUtteranceType)
    {
      return speakerUtteranceType.Items.OfType<signGroupType>().Select(o => o);
    }

    public static IEnumerable<tagMarkerType> GetAllTagMarkerTypes(this speakerUtteranceType speakerUtteranceType)
    {
      return speakerUtteranceType.Items.OfType<tagMarkerType>().Select(o => o);
    }

    public static IEnumerable<underline> GetAllUnderlines(this speakerUtteranceType speakerUtteranceType)
    {
      return speakerUtteranceType.Items.OfType<underline>().Select(o => o);
    }

    public static IEnumerable<wordType> GetAllWordTypes(this speakerUtteranceType speakerUtteranceType)
    {
      return speakerUtteranceType.Items.OfType<wordType>().Select(o => o);
    }
  }
}