using CorpusExplorer.Sdk.Extern.Xml.Helper;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CorpusExplorer.Sdk.Extern.Xml.FoLiA
{
  public class ImporterFolia : AbstractImporterBase
  {
    protected override void ExecuteCall(string path)
    {
      var xml = new HtmlAgilityPack.HtmlDocument();
      xml.Load(path);

      var guid = Guid.NewGuid();
      ImportMetadata(path, xml, guid);

      var sentences = xml.DocumentNode.SelectNodes("//s");
      var layer = new Dictionary<string, List<string[]>>();

      foreach (var s in sentences)
      {
        var current = new Dictionary<string, List<string>>();
        foreach (var w in s.ChildNodes.Where(x => x.Name.ToLower() == "w"))
        {
          foreach (var x in w.ChildNodes)
          {
            switch (x.Name.ToLower())
            {
              case "t":
                AddToCurrent(ref current, "Wort", x.InnerText);
                break;
              case "lemma":
                AddToCurrent(ref current, "Lemma", x.GetAttributeValue<string>("class", ""));
                break;
              case "pos":
                AddToCurrent(ref current, "POS", x);
                break;
              default:
                AddToCurrent(ref current, x.Name, x);
                break;
            }
          }
        }
        foreach (var x in current)
          if (layer.ContainsKey(x.Key))
            layer[x.Key].Add(x.Value.ToArray());
          else
            layer.Add(x.Key, new List<string[]> { x.Value.ToArray() });
      }

      foreach (var l in layer)
      {
        base.AddDocument(l.Key, guid, l.Value.ToArray());
      }
    }

    private static string _sillyFolieNamingPrefix = "https://raw.githubusercontent.com/proycon/folia/master/setdefinitions/";

    private void AddToCurrent(ref Dictionary<string, List<string>> current, string key, HtmlNode node)
    {
      var postfix = node.GetAttributeValue<string>("set", "").Replace(_sillyFolieNamingPrefix, "");
      if (postfix != "")
        key = $"{key} ({postfix})";

      if (!current.ContainsKey(key))
        current.Add(key, new List<string>());

      current[key].Add(node.GetAttributeValue<string>("class", ""));
    }

    private void AddToCurrent(ref Dictionary<string, List<string>> current, string key, string value)
    {
      if (!current.ContainsKey(key))
        current.Add(key, new List<string>());

      current[key].Add(value);
    }

    private void ImportMetadata(string path, HtmlDocument xml, Guid guid)
    {
      var metaData = new Dictionary<string, object>();
      metaData.Add("Pfad", path);
      metaData.Add("GUID", guid);

      var metas = xml.DocumentNode.SelectNodes("//meta");
      if (metas != null)
        foreach (var m in metas)
        {
          var key = m.GetAttributeValue<string>("id", "");
          var val = m.InnerText;

          if (metaData.ContainsKey(key))
            metaData[key] = val;
          else
            metaData.Add(key, val);
        }

      base.AddDocumentMetadata(guid, metaData);
    }
  }
}
