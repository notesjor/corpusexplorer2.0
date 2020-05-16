using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper;
using CorpusExplorer.Sdk.Extern.Xml.Ids.Extension;
using CorpusExplorer.Sdk.Extern.Xml.Ids.Model;
using CorpusExplorer.Sdk.Extern.Xml.Ids.Serializer;

namespace CorpusExplorer.Sdk.Extern.Xml.Ids
{
  public class IdsScraper : AbstractGenericXmlSerializerFormatScraper<idsCorpus>
  {
    public override string DisplayName => "IDS-Korpus";
    protected override AbstractGenericSerializer<idsCorpus> Serializer => new IdsSerializer();

    protected override IEnumerable<Dictionary<string, object>> ScrapDocuments(string file, idsCorpus model)
    {
      return (from category in model.idsDoc
              where category != null
              let categoryLabel = category.idsHeader?.fileDesc?.titleStmt?.TitleD
              from d in category.idsText
              where d != null
              select new Dictionary<string, object>
              {
                {"Kategorie", categoryLabel},
                {"Titel", Reduce(d.idsHeader?.fileDesc?.sourceDesc?.biblStruct?.analytic?.htitle?.Text)},
                {"Autor", d.idsHeader?.fileDesc?.sourceDesc?.biblStruct?.analytic?.hauthor},
                {"Jahr", Reduce(d.idsHeader?.fileDesc?.sourceDesc?.biblStruct?.monogr?.imprint?.GetPubDates()
                                ?.FirstOrDefault(x => x.type == "year")
                                ?.Text)
                },
                {"Datum", GetDate(d.idsHeader?.fileDesc?.sourceDesc?.biblStruct?.monogr?.imprint?.GetPubDates())},
                {"Rubrik(en)", GetCategory(d.idsHeader?.profileDesc?.GetTextClass()?.catRef)},
                {"Text", GetInnerPlaintext(d.text?.body)}
              }).ToList();
    }

    private string GetCategory(catRef[] catRef)
    {
      if (catRef == null)
        return "";

      var list = catRef.Select(x => x.target).ToList();
      list.Sort();

      return string.Join(" | ", list);
    }

    private DateTime GetDate(IEnumerable<pubDate> pubDates)
    {
      try
      {
        var y = int.Parse(Reduce(pubDates.FirstOrDefault(x => x.type == "year").Text));
        var m = int.Parse(Reduce(pubDates.FirstOrDefault(x => x.type == "month").Text));
        var d = int.Parse(Reduce(pubDates.FirstOrDefault(x => x.type == "day").Text));

        return new DateTime(y, m, d);
      }
      catch
      {
        return DateTime.MinValue;
      }
    }

    private string Reduce(string[] text)
      => text == null ? "" : string.Join(" ", text);
  }
}
