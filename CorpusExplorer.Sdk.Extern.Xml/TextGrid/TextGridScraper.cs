using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using CorpusExplorer.Sdk.Extern.Xml.Abstract;

namespace CorpusExplorer.Sdk.Extern.Xml.TextGrid
{
  public class TextGridScraper : AbstractExtendedXmlScraper
  {
    public override string DisplayName => "TextGrid";

    protected override IEnumerable<Dictionary<string, object>> Execute(string file, XmlDocument xmlDoc)
    {
      var container = xmlDoc.ChildNodes.Cast<XmlNode>().Where(node => node is XmlElement).Cast<XmlElement>()
        .FirstOrDefault(node => node.Name == "teiCorpus");
      if (container == null)
        return null;

      var res = new List<Dictionary<string, object>>();
      var author = PickInnerXml(container, "teiHeader", "fileDesc", "titleStmt", "author");
      var fn = Path.GetFileNameWithoutExtension(file).Replace("Literatur-", "").Replace("-", " ");

      foreach (XmlElement folder in container.ChildNodes)
      {
        if (folder.Name != "teiCorpus")
          continue;

        var queue = new Queue<XmlElement>();
        queue.Enqueue(folder);

        while (queue.Count > 0)
        {
          var current = queue.Dequeue();
          foreach (XmlElement item in current.ChildNodes)
          {
            if (item.Name == "TEI")
              res.Add(
                new Dictionary<string, object>
                {
                  {"Autor", author},
                  {"Datei", fn},
                  {"Titel", PickInnerXml(item, "teiHeader", "fileDesc", "titleStmt", "title")},
                  {"Anmerkung", PickInnerXml(item, "teiHeader", "fileDesc", "noteStmt", "note")},
                  {"Text", PickInnerXml(item, "text", "body")},
                  {
                    "Jahr",
                    PickAttributeValue(item, "when", "", "teiHeader", "fileDesc", "sourceDesc", "biblFull",
                      "publicationStmt", "date")
                  }
                });
            if (item.Name == "teiCorpus") queue.Enqueue(item);
          }
        }
      }

      return res;
    }
  }
}