#region

using System.Collections.Generic;
using CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper;
using CorpusExplorer.Sdk.Extern.Xml.SlashA.Model;
using CorpusExplorer.Sdk.Extern.Xml.SlashA.Serializer;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.SlashA
{
  // ReSharper disable once UnusedMember.Global
  public class SlashAScraper : AbstractGenericXmlSerializerFormatScraper<DSpin>
  {
    public override string DisplayName => "Slash/A-XML";

    protected override AbstractGenericSerializer<DSpin> Serializer => new SlashASerializer();

    protected override IEnumerable<Dictionary<string, object>> ScrapDocuments(string file, DSpin model)
    {
      return new[] {new Dictionary<string, object> {{"Text", model.TextCorpus.text}}};
    }
  }
}