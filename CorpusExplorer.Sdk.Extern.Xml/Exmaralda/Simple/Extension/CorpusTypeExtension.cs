#region

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Exmaralda.Simple.Model;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Exmaralda.Simple.Extension
{
  [SuppressMessage("ReSharper", "UnusedMember.Global")]
  public static class CorpusTypeExtension
  {
    public static IEnumerable<CorpusType> GetAllCorpora(this CorpusType corpusType)
    {
      return corpusType.Items.OfType<CorpusType>().Select(o => o);
    }

    public static IEnumerable<CorpusData> GetAllCorpusData(this CorpusType corpusType)
    {
      return corpusType.Items.OfType<CorpusData>().Select(o => o);
    }
  }
}