#region

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Exmaralda.Model;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Exmaralda.Extension
{
  [SuppressMessage("ReSharper", "UnusedMember.Global")]
  public static class CorpusDataExtension
  {
    public static IEnumerable<CommunicationType> GetAllCommunicationTypes(this CorpusData corpusData)
    {
      return corpusData.Items.OfType<CommunicationType>().Select(o => o);
    }

    public static IEnumerable<PersonType> GetAllPersonTypes(this CorpusData corpusData)
    {
      return corpusData.Items.OfType<PersonType>().Select(o => o);
    }
  }
}