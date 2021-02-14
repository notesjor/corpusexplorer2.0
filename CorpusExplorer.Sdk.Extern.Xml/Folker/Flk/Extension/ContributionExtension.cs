#region

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Folker.Flk.Model;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Folker.Flk.Extension
{
  [SuppressMessage("ReSharper", "UnusedMember.Global")]
  public static class ContributionExtension
  {
    public static IEnumerable<breathe> GetAllBreathes(this contribution contribution)
    {
      return contribution.Items.OfType<breathe>().Select(o => o);
    }

    public static IEnumerable<nonphonological> GetAllNonphonologicals(this contribution contribution)
    {
      return contribution.Items.OfType<nonphonological>().Select(o => o);
    }

    public static IEnumerable<pause> GetAllPauses(this contribution contribution)
    {
      return contribution.Items.OfType<pause>().Select(o => o);
    }

    public static IEnumerable<phrase> GetAllPhrases(this contribution contribution)
    {
      return contribution.Items.OfType<phrase>().Select(o => o);
    }

    public static IEnumerable<segment> GetAllSegments(this contribution contribution)
    {
      return contribution.Items.OfType<segment>().Select(o => o);
    }

    public static IEnumerable<time> GetAllTimes(this contribution contribution)
    {
      return contribution.Items.OfType<time>().Select(o => o);
    }

    public static IEnumerable<uncertain> GetAllUncertains(this contribution contribution)
    {
      return contribution.Items.OfType<uncertain>().Select(o => o);
    }

    public static IEnumerable<contributionUnparsed> GetAllUnparseds(this contribution contribution)
    {
      return contribution.Items.OfType<contributionUnparsed>().Select(o => o);
    }

    public static IEnumerable<w> GetAllWs(this contribution contribution)
    {
      return contribution.Items.OfType<w>().Select(o => o);
    }
  }
}