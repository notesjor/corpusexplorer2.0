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
    private string[] _roots = new[] { "//text", "//document", "//helpdocument", "//html" };

    protected override void ExecuteCall(string path)
    {
      var xml = new HtmlDocument();
      xml.Load(path, Configuration.Encoding);

      var texts = GetRoot(xml); 
      if (texts == null || texts.Count < 1)
        return;

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

        var sentences = xml.DocumentNode.SelectNodes("//s").ToArray();
        foreach (var sentence in sentences)
        {
          var sent = new Dictionary<string, List<string>> { { "Wort", new List<string>() } };
          var ws = (from x in sentence.ChildNodes where x.Name == "w" select x).ToArray();

          if(ws.Length == 0)
            continue;

          foreach (var w in ws)
          {
            var t = w.InnerText;
            if(string.IsNullOrWhiteSpace(t))
              continue;

            sent["Wort"].Add(t);

            ParseTokenAnnotation(w, "lem", "Lemma", t, ref sent);
            ParseTokenAnnotation(w, "tree", "POS", "", ref sent);
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

    private HtmlNodeCollection GetRoot(HtmlDocument xml)
    {
      foreach (var root in _roots)
      {
        var texts = xml.DocumentNode.SelectNodes(root);
        if (texts != null && texts.Count > 0)
          return texts;
      }
      return null;
    }

    private static void ParseTokenAnnotation(HtmlNode w, string layerAttr,
                                             string layerName, string defaultValue,
                                             ref Dictionary<string, List<string>> sent)
    {
      if (!sent.ContainsKey(layerName))
        sent.Add(layerName, new List<string>());

      var attr = w.Attributes.FirstOrDefault(x => x.Name == layerAttr);
      if (attr == null || string.IsNullOrEmpty(attr.Value))
        sent[layerName].Add(defaultValue);
      else
        sent[layerName].Add(attr.Value);
    }
  }
}
