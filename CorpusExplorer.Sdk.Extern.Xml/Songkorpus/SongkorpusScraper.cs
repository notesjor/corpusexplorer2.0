using CorpusExplorer.Sdk.Extern.Xml.Abstract;
using System.Collections.Generic;
using System.IO;
using HtmlAgilityPack;
using System.Linq;

namespace CorpusExplorer.Sdk.Extern.Xml.Songkorpus
{
  public class SongkorpusScraper : AbstractXmlScraper
  {
    public override string DisplayName => "Songkorpus";

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      try
      {
        var xml = new HtmlDocument();
        using (var fs = new FileStream(file, FileMode.Open, FileAccess.Read))
          using(var reader = new StreamReader(fs, System.Text.Encoding.UTF8))
            xml.Load(reader);

        var res = new Dictionary<string, object>();
        AddSafe(ref res, "Titel", FindJoinXpath(xml, "//title"));
        AddSafe(ref res, "Jahr", FindFirstXpath(xml, "//date"));
        AddSafe(ref res, "Publisher", FindJoinXpath(xml, "//publisher"));
        AddSafe(ref res, "Album", FindJoinXpath(xml, "//publicationStmt/ref/name"));
        AddSafe(ref res, "Text", FindJoinXpath(xml, "//l"));
        foreach (var x in FindAuthors(xml))
          res.Add(x.Key, x.Value);

        return new[] { res };
      }
      catch
      {
        return null;
      }
    }

    private void AddSafe(ref Dictionary<string, object> res, string key, string data)
    {
      if (string.IsNullOrEmpty(data))
        return;
      res.Add(key, data);
    }

    private string FindJoinXpath(HtmlDocument xml, string xpath, string sep = " ")
    {
      var nodes = xml.DocumentNode.SelectNodes(xpath.ToLower())?.Select(x => x?.InnerText)?.ToArray();
      return nodes == null ? "" : string.Join(sep, nodes);
    }

    private string FindFirstXpath(HtmlDocument xml, string xpath)
      => xml.DocumentNode.SelectNodes(xpath.ToLower())?.FirstOrDefault()?.InnerText;

    private Dictionary<string, string> FindAuthors(HtmlDocument xml)
    {
      var res = new Dictionary<string, string>();
      foreach (var node in xml.DocumentNode.SelectNodes("//author"))
      {
        var key = $"Autor ({node.GetAttributeValue("role", "?")})";
        var value = node.InnerText;
        if (res.ContainsKey(key))
          res[key] = $"{res[key]} {value}";
        else
          res.Add(key, value);
      }
      return res;
    }
  }
}