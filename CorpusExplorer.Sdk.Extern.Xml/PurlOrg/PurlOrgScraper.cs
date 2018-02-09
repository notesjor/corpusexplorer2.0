using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Abstract;
using CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper;
using CorpusExplorer.Sdk.Extern.Xml.PurlOrg.Model;
using CorpusExplorer.Sdk.Extern.Xml.PurlOrg.Serializer;

namespace CorpusExplorer.Sdk.Extern.Xml.PurlOrg
{
  public class PurlOrgScraper : AbstractGenericXmlSerializerFormatScraper<collection>
  {
    public override string DisplayName => "purl.org Corpora";

    protected override AbstractGenericSerializer<collection> Serializer => new PurlOrgSerializer();

    protected override IEnumerable<Dictionary<string, object>> ScrapDocuments(collection model)
    {
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