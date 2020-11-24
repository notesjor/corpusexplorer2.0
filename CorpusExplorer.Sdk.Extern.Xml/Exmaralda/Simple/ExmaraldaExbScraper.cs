#region

using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper;
using CorpusExplorer.Sdk.Extern.Xml.Exmaralda.Simple.Model;
using CorpusExplorer.Sdk.Extern.Xml.Exmaralda.Simple.Serializer;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Exmaralda.Simple
{
  public sealed class ExmaraldaExbScraper : AbstractGenericXmlSerializerFormatScraper<basictranscription>
  {
    public override string DisplayName => "EXMERaLDA-*.EXB";

    protected override AbstractGenericSerializer<basictranscription> Serializer => new ExmaraldaExbSerializer();

    protected override IEnumerable<Dictionary<string, object>> ScrapDocuments(string file, basictranscription model)
    {
      return from tier in model.basicbody.tier
        from e in tier.@event
        select
          new Dictionary<string, object>
          {
            {"Kategorie", tier.category},
            {"Anzeigename", tier.displayname},
            {"Id", tier.id},
            {"Sprecher", tier.speaker},
            {"Typ", tier.ToString()},
            {"Ende", e.end},
            {"Medium", e.medium.ToString()},
            {"Medium?", e.mediumSpecified},
            {"Start", e.start},
            {"Url", e.url},
            {"Text", string.Join(" ", e.Text)}
          };
    }
  }
}