#region

using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Tiger.Scraper.Model;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Tiger.Scraper.Extension
{
  public static class CorpusExtension
  {
    public static IEnumerable<sentenceType> GetChildSentences(this corpus corpus)
    {
      return corpus.body.OfType<sentenceType>().Select(o => o);
    }

    public static IEnumerable<subcorpusType> GetChildSubcorpora(this corpus corpus)
    {
      return corpus.body.OfType<subcorpusType>().Select(o => o);
    }
  }
}