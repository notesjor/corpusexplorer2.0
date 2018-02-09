#region

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Talkbank.Model;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Talkbank.Extension
{
  [SuppressMessage("ReSharper", "UnusedMember.Global")]
  public static class WordTypeExtension
  {
    public static IEnumerable<cadelimiter> GetAllCadelimiters(this wordType wordType)
    {
      return wordType.Items.OfType<cadelimiter>().Select(o => o);
    }

    public static IEnumerable<caelement> GetAllCaelements(this wordType wordType)
    {
      return wordType.Items.OfType<caelement>().Select(o => o);
    }

    public static IEnumerable<italic> GetAllItalics(this wordType wordType)
    {
      return wordType.Items.OfType<italic>().Select(o => o);
    }

    public static IEnumerable<longfeature> GetAllLongfeatures(this wordType wordType)
    {
      return wordType.Items.OfType<longfeature>().Select(o => o);
    }

    public static IEnumerable<morphemic_marker> GetAllMorphemicMarkers(this wordType wordType)
    {
      return wordType.Items.OfType<morphemic_marker>().Select(o => o);
    }

    public static IEnumerable<morType> GetAllMorTypes(this wordType wordType)
    {
      return wordType.Items.OfType<morType>().Select(o => o);
    }

    public static IEnumerable<overlapPointType> GetAllOverlapPointTypes(this wordType wordType)
    {
      return wordType.Items.OfType<overlapPointType>().Select(o => o);
    }

    public static IEnumerable<posType> GetAllPosTypes(this wordType wordType)
    {
      return wordType.Items.OfType<posType>().Select(o => o);
    }

    public static IEnumerable<prosodyType> GetAllProsodyTypes(this wordType wordType)
    {
      return wordType.Items.OfType<prosodyType>().Select(o => o);
    }

    public static IEnumerable<replacement> GetAllReplacements(this wordType wordType)
    {
      return wordType.Items.OfType<replacement>().Select(o => o);
    }

    public static IEnumerable<shorteningType> GetAllShorteningTypes(this wordType wordType)
    {
      return wordType.Items.OfType<shorteningType>().Select(o => o);
    }

    public static IEnumerable<underline> GetAllUnderlines(this wordType wordType)
    {
      return wordType.Items.OfType<underline>().Select(o => o);
    }

    public static IEnumerable<wordnetMarkerType> GetAllWordnetMarkerTypes(this wordType wordType)
    {
      return wordType.Items.OfType<wordnetMarkerType>().Select(o => o);
    }
  }
}