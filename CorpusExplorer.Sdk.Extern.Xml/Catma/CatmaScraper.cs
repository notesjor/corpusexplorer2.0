using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using Bcs.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Extern.Xml.Catma.Parser;
using CorpusExplorer.Sdk.Extern.Xml.Catma.Parser.Abstract;
using CorpusExplorer.Sdk.Extern.Xml.Helper;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;

namespace CorpusExplorer.Sdk.Extern.Xml.Catma
{
  public class CatmaScraper : AbstractScraper
  {
    public override string DisplayName => "CATMA-XML";

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      if (string.IsNullOrEmpty(file))
        return null;
      var xml = new XmlDocument();
      using (var fs = new FileStream(file, FileMode.Open, FileAccess.Read))
      using (var bs = new BufferedStream(fs))
      {
        xml.Load(bs);
      }

      var model = xml.DocumentElement;

      var res = new Dictionary<string, object>
      {
        {
          "Text",
          FileIO.ReadText(Path.Combine(Path.GetDirectoryName(file), DetectTextFile(model)), Configuration.Encoding)
        },
        {"Titel", model.GetFirstSubNodeRecursive("title")?.InnerText},
        {"Autor", model.GetFirstSubNodeRecursive("author")?.InnerText},
        {"Sprache", model.GetFirstSubNodeRecursive("language")?.GetAttribute("ident")}
      };

      return new[] {res};
    }

    private static string DetectTextFile(XmlNode model)
    {
      AbstractCatmaRangeParser parser = null;
      var ptrs = model.GetSubNodesRecursive("ptr");
      return ptrs.Select(ptr => GetFileNameFromPtrTag(ref parser, (XmlElement) ptr))
        .FirstOrDefault(file => !string.IsNullOrEmpty(file));
    }

    private static string GetFileNameFromPtrTag(
      ref AbstractCatmaRangeParser parser,
      XmlElement ptr)
    {
      if (ptr == null)
        return null;
      if (parser == null)
        parser = CatmaRangeParserFactory.Create(ptr.GetAttribute("target"));

      return parser.Parse(ptr.GetAttribute("target")).Item1;
    }
  }
}