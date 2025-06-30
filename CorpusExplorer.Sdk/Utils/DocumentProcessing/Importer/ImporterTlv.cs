using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;
using CorpusExplorer.Sdk.Diagnostic;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract.Model;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract.Model.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Builder;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Sentenizer;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Sentenizer.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tokenizer;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tokenizer.Abstract;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer
{
  public class ImporterTlv : AbstractImporter
  {
    public AbstractSentenizer Sentenizer = new QuickSentenizer();
    public AbstractTokenizer Tokenizer = new HighSpeedGermanTokenizer();

    public IEnumerable<AbstractCorpusAdapter> ExecuteInline(IEnumerable<string> xml)
    {
      var res = new List<AbstractCorpusAdapter>();
      foreach (var x in xml)
      {
        try
        {
          var doc = new XmlDocument();
          doc.LoadXml(x);
          res.AddRange(Execute(ref doc));
        }
        catch (Exception ex)
        {
          InMemoryErrorConsole.Log(ex);
        }
      }
      return res;
    }

    public IEnumerable<AbstractCorpusAdapter> ExecuteInline(string xml)
    {
      var doc = new XmlDocument();
      doc.LoadXml(xml);
      return Execute(ref doc);
    }

    protected override IEnumerable<AbstractCorpusAdapter> Execute(string importFilePath)
    {
      using (var fs = new FileStream(importFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
      using (var bs = new BufferedStream(fs))
      {
        var xml = new XmlDocument();
        xml.Load(bs);
        return Execute(ref xml);
      }
    }

    private string[][] CleanLayerFromPrototype(ref string[][] prototype)
    {
      var list = new List<string[]>();
      foreach (var s in prototype)
      {
        var sen = new List<string>();
        for (var i = 0; i < s.Length; i++) sen.Add(string.Empty);
        list.Add(sen.ToArray());
      }

      return list.ToArray();
    }

    private readonly string _mark = "<-!|!->";
    private readonly string[] _markSplitter = new[] { "<-!|!->" };

    private KeyValuePair<string, object> DeserializeMeta(string outerXml)
    {
      outerXml = outerXml.Replace("<entry category=\"", string.Empty)
                         .Replace("\" type=\"", _mark)
                         .Replace("\">", _mark)
                         .Replace("</entry>", string.Empty);
      var split = outerXml.Split(_markSplitter, StringSplitOptions.RemoveEmptyEntries);
      if (split.Length != 3)
        return new KeyValuePair<string, object>("ERROR", null);

      object value;
      try
      {
        switch (split[1])
        {
          case "System.Int32":
            value = int.Parse(split[2]);
            break;
          case "System.Int64":
            value = long.Parse(split[2]);
            break;
          case "System.Double":
            value = double.Parse(split[2]);
            break;
          case "System.Boolean":
            value = bool.Parse(split[2]);
            break;
          case "System.DateTime":
            value = DateTime.Parse(split[2]);
            break;
          default:
            value = split[2];
            break;
        }
      }
      catch
      {
        value = split[2];
      }

      return new KeyValuePair<string, object>(split[0], value);
    }

    private IEnumerable<AbstractCorpusAdapter> Execute(ref XmlDocument xml)
    {
      var root = xml.DocumentElement;
      var corpusMeta = new Dictionary<string, object>();
      var layerstate = new Dictionary<int, AbstractLayerState>();
      var wortLayer = new LayerValueState("Wort", 999);
      var documentMeta = new Dictionary<Guid, Dictionary<string, object>>();

      #region <meta> Korpusmetadata

      XmlNode cmeta = root?["meta"];
      if (cmeta != null)
        foreach (XmlNode x in cmeta.ChildNodes)
        {
          if (x.Name != "entry")
            continue;

          var entry = DeserializeMeta(x.OuterXml);
          if (entry.Value != null && !corpusMeta.ContainsKey(entry.Key))
            corpusMeta.Add(entry.Key, entry.Value);
        }

      #endregion

      #region <layers>

      XmlNode layers = root["layers"];
      if (layers == null)
        return null;

      foreach (XmlElement x in layers)
      {
        var id = int.Parse(x.GetAttribute("l"));
        var name = x.GetAttribute("name");

        // Wort-Layer muss verworfen werden
        if (string.IsNullOrEmpty(name) || name == "Wort")
          continue;

        var dict = (from XmlElement y in x.ChildNodes where y.Name == "value" select y).ToDictionary(
                                                                                                     y => HttpUtility
                                                                                                      .HtmlDecode(y
                                                                                                                   .GetAttribute("label")),
                                                                                                     y =>
                                                                                                       int
                                                                                                        .Parse(y
                                                                                                                .GetAttribute("v")));

        layerstate.Add(id, new LayerValueState(name, id, dict));
      }

      #endregion

      #region ReverseCache - Wird für den Parsing-Prozess benötigt

      var cache = layerstate.ToDictionary(
                                          x => x.Key,
                                          x => new KeyValuePair<string, Dictionary<int, string>>(
                                                                                                 x.Value.Displayname,
                                                                                                 x.Value.GetCache()
                                                                                                  .ToDictionary(y => y.Value,
                                                                                                                y => y.Key)));

      #endregion

      #region <docs>

      XmlNode docs = root["docs"];
      if (docs == null)
        return null;

      foreach (XmlElement b in docs.ChildNodes)
      {
        var guid = Guid.NewGuid();

        #region <meta> - Dokumentmetadaten

        var dmeta = b["meta"];
        var dmetaDic = new Dictionary<string, object>();
        if (dmeta != null)
          foreach (XmlNode y in dmeta.ChildNodes)
          {
            if (y.Name != "entry")
              continue;

            var entry = DeserializeMeta(y.OuterXml);
            if (entry.Value != null && !dmetaDic.ContainsKey(entry.Key))
              dmetaDic.Add(entry.Key, entry.Value);
          }

        #endregion

        #region <body>

        var body = b["body"];
        if (body == null)
          continue;

        var orig = Sentenizer.Execute(Tokenizer.ExecuteToArray(HttpUtility.HtmlDecode(body.InnerText)));
        var doc = orig.Select(s => s.Select(w => new Word { Content = w }).ToArray()).ToArray();
        var sidx = 0;
        var widx = 0;

        foreach (XmlNode n in body.ChildNodes) ParseNodeRecursive(ref cache, ref doc, ref sidx, ref widx, n);

        var ldocs = new Dictionary<int, string[][]>();
        foreach (var state in layerstate)
        {
          var ldoc = CleanLayerFromPrototype(ref orig);
          for (var s = 0; s < ldoc.Length; s++)
            for (var w = 0; w < ldoc[s].Length; w++)
              if (doc[s][w].Annotation.ContainsKey(state.Value.Displayname))
                ldoc[s][w] = doc[s][w].Annotation[state.Value.Displayname];
          ldocs.Add(state.Key, ldoc);
        }

        #endregion

        #region Speichere Dokument

        documentMeta.Add(guid, dmetaDic);
        wortLayer.AddCompleteDocument(guid, orig);
        foreach (var x in ldocs) ((LayerValueState)layerstate[x.Key]).AddCompleteDocument(guid, x.Value);

        #endregion
      }

      #endregion

      var builder = new CorpusBuilderWriteDirect();
      return builder.Create(new List<AbstractLayerState>(layerstate.Select(x => x.Value)) { wortLayer }, documentMeta,
                            corpusMeta, null);
    }

    private void ParseNodeRecursive(ref Dictionary<int, KeyValuePair<string, Dictionary<int, string>>> cache,
                                    ref Word[][] doc, ref int sidx, ref int widx, XmlNode xmlNode,
                                    Dictionary<string, string> values = null)
    {
      if (xmlNode.Name == "#text")
      {
        var token = Tokenizer.ExecuteToArray(HttpUtility.HtmlDecode(xmlNode.InnerText));
        var count = token.Length;
        for (var i = 0; i < count; i++)
        {
          if (sidx >= doc.Length || widx >= doc[sidx].Length)
            return;

          if (values != null)
            foreach (var value in values)
              if (doc[sidx][widx].Annotation.ContainsKey(value.Key))
                doc[sidx][widx].Annotation[value.Key] = value.Value;
              else
                doc[sidx][widx].Annotation.Add(value.Key, value.Value);

          widx++;
          if (widx >= doc[sidx].Length)
          {
            sidx++;
            widx = 0;
          }
        }

        return;
      }

      if (xmlNode.Name == "t")
      {
        var element = xmlNode as XmlElement;
        if (element == null)
          return;

        if (values == null)
          values = new Dictionary<string, string>();

        var layer = cache[int.Parse(element.GetAttribute("l"))];
        if (layer.Key != "Wort") // Wort-Layer muss verworfen werden.
          if (values.ContainsKey(layer.Key))
            values[layer.Key] = layer.Value[int.Parse(element.GetAttribute("v"))];
          else
            values.Add(layer.Key, layer.Value[int.Parse(element.GetAttribute("v"))]);

        foreach (XmlNode sub in xmlNode.ChildNodes)
          ParseNodeRecursive(ref cache, ref doc, ref sidx, ref widx, sub, values);
      }
    }

    private class Word
    {
      public Dictionary<string, string> Annotation { get; } = new Dictionary<string, string>();
      public string Content { get; set; }
    }
  }
}