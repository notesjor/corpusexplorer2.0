using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;

namespace CorpusExplorer.Sdk.Extern.Xml.SaltXml
{
  public class ImporterSaltXml : AbstractImporterBase
  {
    private static readonly HashSet<string>
      _sentenceEndings = new HashSet<string> { ".", "!", "?", ";", ":" }; // STTS 2.0

    protected override void ExecuteCall(string path)
    {
      var dsel = Guid.NewGuid();
      AddDocumentMetadata(dsel, new Dictionary<string, object> { { "Pfad", path } });

      var xml = new HtmlDocument();
      xml.Load(path, Configuration.Encoding);

      // valid wird hier und im Folgenden nur verwendet um Abbruchbedingungen zu überprüfen

      var valid = xml.DocumentNode.ChildNodes.FirstOrDefault(x => x.Name == "sdocumentstructure:sdocumentgraph");
      if (valid == null)
        return;

      valid = valid.ChildNodes.Take(5).FirstOrDefault(x => x.Name == "labels" && x.GetAttributeValue("xsi:type", "") == "saltCore:SElementId");
      if (valid == null)
        return;

      var nodes = xml.DocumentNode.SelectNodes("//nodes").ToArray();
      var edges = xml.DocumentNode.SelectNodes("//edges").Where(x => x.GetAttributeValue("target", "") == "//@nodes.0");

      valid = nodes.SingleOrDefault(x => x.GetAttributeValue("xsi:type", "") == "sDocumentStructure:STextualDS");
      if (valid == null)
        return;

      var text = HttpUtility.HtmlDecode(CleanValue(valid.ChildNodes.SingleOrDefault(x => x.Name == "labels" && x.GetAttributeValue("xsi:type", "") == "saltCore:SFeature" && x.GetAttributeValue("name", "") == "SDATA")?.GetAttributeValue("value", null)));

      var ldoc = new Dictionary<string, List<string[]>>();
      var lsentences = new Dictionary<string, List<string>>();

      var presel = nodes.Take(5);
      var hasLemma = presel.Any(x => x.ChildNodes.Any(y => y.Name == "labels" && y.GetAttributeValue("name", "") == "lemma"));
      var hasPos = presel.Any(x => x.ChildNodes.Any(y => y.Name == "labels" && y.GetAttributeValue("name", "") == "pos"));

      ldoc.Add("Wort", new List<string[]>());
      lsentences.Add("Wort", new List<string>());
      if (hasLemma)
      {
        ldoc.Add("Lemma", new List<string[]>());
        lsentences.Add("Lemma", new List<string>());
      }
      if (hasPos)
      {
        ldoc.Add("POS", new List<string[]>());
        lsentences.Add("POS", new List<string>());
      }
      var keys = ldoc.Keys.ToArray();

      var hasAnno = hasLemma || hasPos;

      foreach (var edge in edges)
      {
        var start = int.Parse(edge.ChildNodes.Single(x => x.GetAttributeValue("name", "") == "SSTART").GetAttributeValue("value", "").Substring(3));
        var end = int.Parse(edge.ChildNodes.Single(x => x.GetAttributeValue("name", "") == "SEND").GetAttributeValue("value", "").Substring(3));

        var token = text.Substring(start, end - start);
        lsentences["Wort"].Add(token);

        if (hasAnno)
        {
          var current = nodes[int.Parse(edge.GetAttributeValue("source", "").Substring(9))];

          if (hasLemma)
            lsentences["Lemma"].Add(GetValue(current, "lemma"));
          if (hasPos)
            lsentences["POS"].Add(GetValue(current, "pos"));
        }

        if (_sentenceEndings.Contains(token))
          foreach (var l in keys)
          {
            ldoc[l].Add(lsentences[l].ToArray());
            lsentences[l].Clear();
          }
      }

      if (lsentences["Wort"].Count > 0)
        foreach (var l in keys)
        {
          ldoc[l].Add(lsentences[l].ToArray());
          lsentences[l].Clear();
        }

      foreach (var l in keys)
        AddDocument(l, dsel, ldoc[l].ToArray());
    }

    private static string GetValue(HtmlNode node, string name)
      => CleanValue(node.ChildNodes.FirstOrDefault(x => x.Name == "labels" && x.GetAttributeValue("name", "") == name)?.GetAttributeValue("value", null));

    private static string CleanValue(string v)
      => string.IsNullOrWhiteSpace(v) ? "" : v.Length < 3 ? "" : v.Substring(3);
  }
}
