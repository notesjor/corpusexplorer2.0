#region

using System.Collections.Generic;
using System.IO;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Abstract;
using CorpusExplorer.Sdk.Extern.Xml.Exmaralda.Simple.Model;
using CorpusExplorer.Sdk.Extern.Xml.Helper;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Exmaralda.Simple
{
  public sealed class ExmaraldaExbScraper : AbstractXmlScraper
  {
    public override string DisplayName => "EXMERaLDA-*.EXB";

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      var model = XmlSerializerHelper.Deserialize<basictranscription>(file);
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