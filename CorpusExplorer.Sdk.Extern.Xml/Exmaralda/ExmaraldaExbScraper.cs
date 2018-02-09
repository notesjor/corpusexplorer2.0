#region

using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Abstract;
using CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper;
using CorpusExplorer.Sdk.Extern.Xml.Exmaralda.Model;
using CorpusExplorer.Sdk.Extern.Xml.Exmaralda.Serializer;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Exmaralda
{
  public sealed class ExmaraldaExbScraper : AbstractGenericXmlSerializerFormatScraper<basictranscription>
  {
    public override string DisplayName { get { return "EXMERaLDA-*.EXB"; } }

    protected override AbstractGenericSerializer<basictranscription> Serializer
    {
      get { return new ExmaraldaExbSerializer(); }
    }

    protected override IEnumerable<Dictionary<string, object>> ScrapDocuments(basictranscription model)
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