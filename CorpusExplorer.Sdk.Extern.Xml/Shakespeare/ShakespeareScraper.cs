using System.Collections.Generic;
using CorpusExplorer.Sdk.Extern.Xml.Abstract.XmlDocumentBasedScraper;
using HtmlAgilityPack;

namespace CorpusExplorer.Sdk.Extern.Xml.Shakespeare
{
  public class ShakespeareScraper : AbstractHtmlXmlDocumentScraper
  {
    public override string DisplayName => "Shakespeare";

    protected override IEnumerable<Dictionary<string, object>> Execute(string file, HtmlDocument xmlDoc)
    {
      var res = new List<Dictionary<string, object>>();
      var texts = xmlDoc.DocumentNode.SelectNodes("//text");

      foreach (HtmlNode text in texts)
      {
        var title = text.GetAttributeValue("title", "");
        var id = text.GetAttributeValue("id", "");

        var acts = text.Descendants("act");
        foreach (HtmlNode act in acts)
        {
          var actNo = act.GetAttributeValue("n", "");
          var actTitle = act.GetAttributeValue("title", "");

          var scenes = act.Descendants("scene");
          foreach (HtmlNode scene in scenes)
          {
            var sceNo = scene.GetAttributeValue("n", "");
            var sceTy = scene.GetAttributeValue("type", "");
            var sceTi = scene.GetAttributeValue("title", "");

            foreach (var node in scene.ChildNodes)
              switch (node.Name)
              {
                case "join":
                case "normalised":
                case "notvariant":
                case "stage":
                  BuildDocument(ref res, title, id, actNo, actTitle, sceNo, sceTy, sceTi, node.InnerText, node.Name);
                  break;
                case "lb":
                  break; // ignorieren
                case "u":
                  BuildDocument(ref res, title, id, actNo, actTitle, sceNo, sceTy, sceTi, node);
                  break;
              }
          }
        }
      }

      return res;
    }

    private void BuildDocument(ref List<Dictionary<string, object>> docs, string title, string id, string actNo,
                               string actTitle, string sceNo, string sceTy, string sceTi, HtmlNode node)
    {
      docs.Add(new Dictionary<string, object>
      {
        {"Titel", title},
        {"Id", id},
        {"Akt Nr.", actNo},
        {"Akt Titel", actTitle},
        {"Szene Nr.", sceNo},
        {"Szene Typ", sceTy},
        {"Szene Titel", sceTi},
        {"Sprecher ID", node.GetAttributeValue("who", "")},
        {"Sprecher", node.GetAttributeValue("label", "")},
        {"Text", node.InnerText}
      });
    }

    private void BuildDocument(ref List<Dictionary<string, object>> docs, string title, string id, string actNo,
                               string actTitle, string sceNo, string sceTy, string sceTi, string text, string name)
    {
      docs.Add(new Dictionary<string, object>
      {
        {"Titel", title},
        {"Id", id},
        {"Akt Nr.", actNo},
        {"Akt Titel", actTitle},
        {"Szene Nr.", sceNo},
        {"Szene Typ", sceTy},
        {"Szene Titel", sceTi},
        {"Text", text},
        {"Typ", name }
      });
    }
  }
}

