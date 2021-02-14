using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CorpusExplorer.Sdk.Extern.Xml.Abstract;
using CorpusExplorer.Sdk.Extern.Xml.Bawe.Model;
using CorpusExplorer.Sdk.Extern.Xml.Helper;
using HtmlAgilityPack;

namespace CorpusExplorer.Sdk.Extern.Xml.Bawe
{
  public class BaweScraper : AbstractXmlScraper
  {
    public override string DisplayName => "BAWE";
    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      var model = XmlSerializerHelper.Deserialize<TEI2>(file);
      var doc = new Dictionary<string, object>();
      ParsePTags(ref doc, model.teiHeader?.fileDesc?.sourceDesc?.p);
      ParsePTags(ref doc, model.teiHeader?.profileDesc?.particDesc?.person?.p);

      var xml = new HtmlDocument();
      xml.Load(file, Encoding.UTF8);

      var sentences = xml.DocumentNode.SelectNodes("//s");
      if (sentences == null || sentences.Count == 0)
        return null;

      var text = string.Join("\r\n", sentences.Select(x => x.InnerText).Where(x => x != null));

      if (doc.ContainsKey("Text"))
        doc["Text"] = text;
      else
        doc.Add("Text", text);

      return new[] { doc };
    }

    private void ParsePTags(ref Dictionary<string, object> doc, p[] ps)
    {
      foreach (var p in ps)
        if (!doc.ContainsKey(p.n) && p.Text != null)
          doc.Add(p.n, string.Join("\r\n", p.Text));
    }
  }
}
