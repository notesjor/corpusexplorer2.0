#region

using System.Collections.Generic;
using System.IO;
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
      var res = new List<Dictionary<string, object>>();
      foreach (var tier in model.basicbody.tier)
        res.AddRange(tier.@event.Select((e, i) => new Dictionary<string, object>
        {
          {"Datei", Path.GetFileNameWithoutExtension(file)},
          {"Kategorie", tier.category},
          {"Anzeigename", tier.displayname},
          {"Id", tier.id},
          {"TID", i + 1},
          {"Sprecher", tier.speaker},
          {"Typ", tier.ToString()},
          {"Ende", e.end},
          {"Medium", e.medium.ToString()},
          {"Medium?", e.mediumSpecified},
          {"Start", e.start},
          {"Url", e.url},
          {"Text", string.Join(" ", e.Text)}
        }));

      return res;
    }
  }
}