using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;
using HtmlAgilityPack;

namespace CorpusExplorer.Sdk.Extern.Xml.Opus
{
  public class ImporterOpusXces : AbstractImporterBase
  {
    protected override void ExecuteCall(string path)
    {
      var xml = new HtmlDocument();
      xml.Load(path, Configuration.Encoding);

      var texts = xml.DocumentNode.SelectNodes("//text");
      if (texts == null || texts.Count < 1)
      {
        texts = xml.DocumentNode.SelectNodes("//document");
        if (texts == null || texts.Count < 1)
          return;
      }

      for (var i = 0; i < texts.Count; i++)
      {
        var text = texts[i];
        var guid = Guid.NewGuid();
        AddDocumentMetadata(guid, new Dictionary<string, object>
        {
          { "Datei", path },
          { "TextId (in Datei)", i + 1 }
        });

        var doc = new Dictionary<string, List<string[]>>();

        var sentences = (from x in text.ChildNodes where x.Name == "s" select x).ToArray();
        foreach (var sentence in sentences)
        {
          var sent = new Dictionary<string, List<string>> { { "Wort", new List<string>() } };
          var ws = (from x in sentence.ChildNodes where x.Name == "w" select x).ToArray();

          foreach (var w in ws)
          {
            sent["Wort"].Add(w.InnerText);

            ParseTokenAnnotation(w, "lem", "Lemma", sent);
            ParseTokenAnnotation(w, "tree", "POS", sent);
          }

          foreach (var s in sent)
          {
            if (doc.ContainsKey(s.Key))
              doc[s.Key].Add(s.Value.ToArray());
            else
              doc.Add(s.Key, new List<string[]> { s.Value.ToArray() });
          }
        }

        foreach (var layer in doc)
          AddDocument(layer.Key, guid, layer.Value.ToArray());
      }
    }

    private static void ParseTokenAnnotation(HtmlNode w, string layerAttr, string layerName,
                                             Dictionary<string, List<string>> sent)
    {
      if (w.Attributes.All(y => y.Name != layerAttr))
        return;

      if (!sent.ContainsKey(layerName))
        sent.Add(layerName, new List<string>());

      sent[layerName].Add(w.GetAttributeValue(layerAttr, ""));
    }
  }
}
