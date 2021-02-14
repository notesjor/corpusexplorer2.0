using System.Collections.Generic;
using CorpusExplorer.Sdk.Extern.Wiki.WikipediaMetaTalk.Model;
using CorpusExplorer.Sdk.Extern.Xml.Abstract;
using CorpusExplorer.Sdk.Extern.Xml.Helper;

namespace CorpusExplorer.Sdk.Extern.Wiki.WikipediaMetaTalk
{
  public class WikipediaMetaTalkScraper : AbstractXmlScraper
  {
    public override string DisplayName => "Wikipedia-Meta-DUMP";
    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      var model = XmlSerializerHelper.Deserialize<page>(file);
      var text = model.revision.comment.Text == null
                   ? null
                   : string.Join("\r\n", model.revision.comment.Text);
      if (string.IsNullOrEmpty(text))
        return null;

      var doc = new Dictionary<string, object>
      {
        {"Artikel", model.title},
        {"NS", model.ns},
        {"ArtikelID", model.id},
        {"Weiterleitung", model.redirect},
        {"Flag", model.restrictions},
        {"RevisionID", model.revision.id},
        {"ParentRevisionID", model.revision.parentid},
        {"Datum", model.revision.timestamp},
        {"SHA1", model.revision.sha1},
        {"Benutzer gelöscht?", model.revision.contributor.deleted},
        {"Kommentar gelöscht?", model.revision.comment.deleted},
        {"Text", text}
      };
      doc = AppendContributor(doc, model.revision.contributor);
      return new[] {doc};
    }

    private static Dictionary<string, object> AppendContributor(Dictionary<string, object> doc,
                                                                contributor revisionContributor)
    {
      string ip = null, user = null, userId = null;

      for (var i = 0; i < revisionContributor.ItemsElementName.Length; i++)
        switch (revisionContributor.ItemsElementName[i])
        {
          case ItemsChoiceType.id:
            userId = revisionContributor.Items[i];
            break;
          case ItemsChoiceType.ip:
            ip = revisionContributor.Items[i];
            break;
          case ItemsChoiceType.username:
            user = revisionContributor.Items[i];
            break;
        }

      if (ip != null)
        doc.Add("UserIP", ip);
      if (user != null)
        doc.Add("User", user);
      if (userId != null)
        doc.Add("UserID", userId);

      return doc;
    }
  }
}