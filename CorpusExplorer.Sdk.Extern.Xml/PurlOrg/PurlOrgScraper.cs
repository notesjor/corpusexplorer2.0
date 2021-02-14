using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Abstract;
using CorpusExplorer.Sdk.Extern.Xml.Helper;
using CorpusExplorer.Sdk.Extern.Xml.PurlOrg.Model;

namespace CorpusExplorer.Sdk.Extern.Xml.PurlOrg
{
  public class PurlOrgScraper : AbstractXmlScraper
  {
    public override string DisplayName => "purl.org Corpora";

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      var model = XmlSerializerHelper.Deserialize<collection>(file);
      return
        model.text.Select(
          text =>
            new Dictionary<string, object>
            {
              {"Text", text.rohtext},
              {"Anrede", text.anrede},
              {"Datum", text.datum},
              {"Excerpt", text.excerpt},
              {"Ort", text.ort},
              {"Person", text.person},
              {"Titel", text.titel},
              {"Untertitel", text.untertitel},
              {"Url", text.url}
            });
    }
  }
}