#region

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Folker.Model;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Folker.Extension
{
  [SuppressMessage("ReSharper", "UnusedMember.Global")]
  public static class PhraseExtension
  {
    public static IEnumerable<breathe> GetAllBreathes(this phrase phrase)
    {
      return phrase.Items.OfType<breathe>().Select(o => o);
    }

    public static IEnumerable<nonphonological> GetAllNonphonological(this phrase phrase)
    {
      return phrase.Items.OfType<nonphonological>().Select(o => o);
    }

    public static IEnumerable<pause> GetAllPauses(this phrase phrase)
    {
      return phrase.Items.OfType<pause>().Select(o => o);
    }

    public static IEnumerable<time> GetAllTimes(this phrase phrase)
    {
      return phrase.Items.OfType<time>().Select(o => o);
    }

    public static IEnumerable<uncertain> GetAllUncertains(this phrase phrase)
    {
      return phrase.Items.OfType<uncertain>().Select(o => o);
    }

    public static IEnumerable<w> GetAllWs(this phrase phrase) { return phrase.Items.OfType<w>().Select(o => o); }
  }
}