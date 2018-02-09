using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Bcs.IO;
using CorpusExplorer.Core.DocumentProcessing.Importer.TlvXml;
using CorpusExplorer.Core.Exporter.Tlv;
using CorpusExplorer.Core.Exporter.Tlv.Model;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper;
using CorpusExplorer.Sdk.Extern.Xml.Catma.Helper;
using CorpusExplorer.Sdk.Extern.Xml.Catma.Parser;
using CorpusExplorer.Sdk.Extern.Xml.Catma.Parser.Abstract;
using CorpusExplorer.Sdk.Extern.Xml.IdsXces.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;

namespace CorpusExplorer.Sdk.Extern.Xml.Catma
{
  public class ImporterCatma : AbstractImporter
  {
    protected override IEnumerable<AbstractCorpusAdapter> Execute(string importFilePath)
    {
      var xml = new XmlDocument();
      using (var fs = new FileStream(importFilePath, FileMode.Open, FileAccess.Read))
        xml.Load(fs);
      var model = xml.DocumentElement;

      // METADATEN
      var meta = new Dictionary<string, object>
      {
        {"Titel",  model.GetFirstSubNodeRecursive("title")?.InnerText},
        {"Autor", model.GetFirstSubNodeRecursive("author")?.InnerText},
        {"Sprache", model.GetFirstSubNodeRecursive("language")?.GetAttribute("ident")}
      };

      // Um Layerwerte zuordnen zu können, müssen die Farben erkannt werden
      var colors = RemoveClonesByAttribute(
        from x in model.GetSubNodesRecursive("fs")
        where x.HasAttribute("type") && x.HasAttribute("xml:id")
        select x,
        "type").ToDictionary(
        x => x.GetAttribute("type"),
        x => $"#{x.GetAttribute("xml:id")}");

      // Layer erkennen
      var values = new Dictionary<string, KeyValuePair<string, string>>(); // id (über color) > Layer / Value;
      var encodingDesc = model.GetFirstSubNodeRecursive("encodingDesc");
      var layerDef = encodingDesc.GetSubNodes("fsdDecl");

      foreach (var layer in layerDef)
      {
        var sub = from x in layer.GetSubNodes("fsDecl") where x.HasAttribute("xml:id") && colors.ContainsKey(x.GetAttribute("xml:id")) select x;
        foreach (var s in sub)
          values.Add($"#{colors[s.GetAttribute("xml:id")]}", new KeyValuePair<string, string>(layer.GetAttribute("n"), s.GetFirstSubNode("fsDescr").InnerText));
      }

      // Annotationen anwenden
      AbstractCatmaRangeParser parser = null;
      string fileName = null;
      var segs = model.GetSubNodesRecursive("seg");

      foreach (var seg in segs)
      {
        fileName = GetAnnotationPosition(ref parser, seg.GetFirstSubNode("ptr")).Item1;
        if (!string.IsNullOrEmpty(fileName))
          break;
      }
      if (string.IsNullOrEmpty(fileName))
        return null;

      var builder = new TlvBuilder(File.ReadAllText(Path.Combine(Path.GetDirectoryName(importFilePath), fileName), Configuration.Encoding))
      {
        Metadata = meta
      };

      foreach (var seg in segs)
      {
        var split = seg.GetAttribute("ana").Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        var ptr = seg.GetFirstSubNode("ptr");
        if (ptr == null)
          continue;

        foreach (var a in split)
        {
          if (!values.ContainsKey(a))
            continue;

          var ano = values[a];
          var position = GetAnnotationPosition(ref parser, ptr);
          builder.Add(new TlvEntry(ano.Key, ano.Value, position.Item2, position.Item3));
        }
      }

      var tlv = new ImporterTlv();
      return tlv.ExecuteInline(builder.GetXmlOutput());
    }

    private static List<XmlNode> RemoveClonesByAttribute(IEnumerable<XmlNode> nodes, string attributeName)
    {
      var fss = nodes.ToList();
      var clones = new Dictionary<string, int>();
      foreach (var x in fss)
      {
        var type = x.GetAttribute(attributeName);
        if (clones.ContainsKey(type))
          clones[type]++;
        else
          clones.Add(type, 1);
      }
      foreach (var x in clones)
      {
        if (x.Value == 1)
          continue;
        var cloneNodes = fss.Where(y => y.GetAttribute(attributeName) == x.Key).ToArray();
        foreach (var n in cloneNodes)
        {
          fss.Remove(n);
        }
      }
      return fss;
    }

    private Tuple<string, int, int> GetAnnotationPosition(ref AbstractCatmaRangeParser parser, XmlNode ptr)
    {
      if (ptr == null)
        return null;
      if (parser == null)
        parser = CatmaRangeParserFactory.Create(ptr.GetAttribute("target"));

      return parser.Parse(ptr.GetAttribute("target"));
    }
  }
}
