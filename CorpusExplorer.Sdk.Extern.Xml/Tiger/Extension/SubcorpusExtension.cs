#region

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Tiger.Model;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Tiger.Extension
{
  [SuppressMessage("ReSharper", "UnusedMember.Global")]
  public static class SubcorpusExtension
  {
    public static IEnumerable<sentenceType> GetChildSentences(this subcorpusType subcorpus)
    {
      return subcorpus.items.OfType<sentenceType>().Select(o => o);
    }

    public static IEnumerable<subcorpusType> GetChildSubcorpora(this subcorpusType subcorpus)
    {
      return subcorpus.items.OfType<subcorpusType>().Select(o => o);
    }
  }
}