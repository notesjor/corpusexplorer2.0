#region

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Talkbank.Model;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Talkbank.Extension
{
  [SuppressMessage("ReSharper", "UnusedMember.Global")]
  public static class EventTypeExtension
  {
    public static IEnumerable<decimal> GetAllDurations(this eventType eventType)
    {
      return eventType.Items.OfType<decimal>().Select(o => o);
    }

    public static IEnumerable<string> GetAllErrors(this eventType eventType)
    {
      return eventType.Items.OfType<string>().Select(o => o);
    }

    public static IEnumerable<groupAnnotationType> GetAllGroupAnnoationTypes(this eventType eventType)
    {
      return eventType.Items.OfType<groupAnnotationType>().Select(o => o);
    }

    public static IEnumerable<markers> GetAllMarkers(this eventType eventType)
    {
      return eventType.Items.OfType<markers>().Select(o => o);
    }

    public static IEnumerable<overlapType> GetAllOverlapTypes(this eventType eventType)
    {
      return eventType.Items.OfType<overlapType>().Select(o => o);
    }

    public static IEnumerable<repetitionType> GetAllRepetitionType(this eventType eventType)
    {
      return eventType.Items.OfType<repetitionType>().Select(o => o);
    }
  }
}