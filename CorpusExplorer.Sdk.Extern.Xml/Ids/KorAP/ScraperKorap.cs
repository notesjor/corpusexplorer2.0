using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP.Model.Root;
using CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP.Serializer.Root;
using CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP.Serializer.Sub;
using CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP.Serializer.SubSub.Data;
using CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP.Serializer.SubSub.Head;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;
using CorpusExplorer.Sdk.Utils.ZipFileIndex;

namespace CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP
{
  public class KorapScraper : AbstractScraper
  {
    private RootSerializer _rootSerializer = new RootSerializer();
    private SubSerializer _subSerializer = new SubSerializer();
    private SubSubHeadSerializer _subSubHeadSerializer = new SubSubHeadSerializer();
    private SubSubDataSerializer _subSubDataSerializer = new SubSubDataSerializer();

    public override string DisplayName => "KorAP-XML Scraper";

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      if (Path.GetFileNameWithoutExtension(file).Contains("."))
        return null;

      var res = new List<Dictionary<string, object>>();
      var zip = new ZipFileIndex(file);
      var root = zip.ZipDirectoryRoot.ZipDirectories[0];

      if (root.ZipFiles[0].NameFile != "header.xml")
        return null;

      var header = GetZipHeader(root);
      if (header == null)
        return null;

      foreach (var dir in root.ZipDirectories)
      {
        var dTitle = GetSubCorpusName(dir);

        foreach (var doc in dir.ZipDirectories)
        {
          var text = GetText(doc.ZipFiles.FirstOrDefault(x => x.NameFile == "data.xml"));
          if (string.IsNullOrEmpty(text))
            continue;
          var meta = GetMetadata(doc.NamePath, header, dTitle, doc.ZipFiles.FirstOrDefault(x => x.NameFile == "header.xml"));
          meta.Add("Text", text);
          res.Add(meta);
        }
      }

      return res;
    }

    private string GetText(ZipFileEntry zip)
    {
      string res = null;
      zip.Extract(ms =>
      {
        res = _subSubDataSerializer.Deserialize(ms)?.text;
      });
      return res;
    }

    private Dictionary<string, object> GetMetadata(string zipPath, idsHeader corpusHeader, string dTitle, ZipFileEntry entry)
    {
      if (entry == null)
        return new Dictionary<string, object>();

      var res = new Dictionary<string, object>();
      entry.Extract(ms =>
      {
        var meta = _subSubHeadSerializer.Deserialize(ms);
        res.Add("Korpus", corpusHeader?.fileDesc?.titleStmt?.ctitle);
        res.Add("Sprache", corpusHeader?.profileDesc?.langUsage?.language?.id);
        res.Add("Taxonomy", GetTaxonomy(corpusHeader?.encodingDesc?.classDecl?.taxonomy));
        res.Add("Dokumentebene", dTitle);
        res.Add("Sigle", meta?.fileDesc?.titleStmt?.textSigle);
        res.Add("Titel", meta?.fileDesc?.titleStmt?.textSigle);
        res.Add("Titel (D)", meta?.fileDesc?.titleStmt?.ttitle);
        res.Add("Textsorte", meta?.profileDesc?.textDesc?.textType);
        res.Add("Referenz", Reduce(meta?.fileDesc?.sourceDesc?.reference?.FirstOrDefault(x => x.type == "complete")?.Text));
        res.Add("Datum", GetDate(meta?.fileDesc?.sourceDesc?.biblStruct?.monogr?.imprint?.pubDate));
        res.Add("ZipPath", zipPath);
      });
      return res;
    }

    private string GetTaxonomy(taxonomy taxonomy)
      => taxonomy == null
           ? string.Empty
           : string.Join(" | ", taxonomy.category.Select(category => category.id));

    private DateTime GetDate(IEnumerable<Model.SubSub.Head.pubDate> pubDates)
    {
      try
      {
        var y = int.Parse(Reduce(pubDates.FirstOrDefault(x => x.type == "year").Text));
        var m = int.Parse(Reduce(pubDates.FirstOrDefault(x => x.type == "month").Text));
        var d = int.Parse(Reduce(pubDates.FirstOrDefault(x => x.type == "day").Text));

        return new DateTime(y, m, d);
      }
      catch
      {
        return DateTime.MinValue;
      }
    }

    private string Reduce(string[] text)
      => text == null ? "" : string.Join(" ", text);

    private string GetSubCorpusName(ZipDirectoryEntry dir)
    {
      var dTitle = string.Empty;
      dir.ZipFiles[0].Extract(ms =>
      {
        try
        {
          var sub = _subSerializer.Deserialize(ms);
          dTitle = sub.fileDesc.titleStmt.dtitle;
        }
        catch
        {
          // ignore
        }
      });
      return dTitle;
    }

    private idsHeader GetZipHeader(ZipDirectoryEntry root)
    {
      Model.Root.idsHeader header = null;
      root.ZipFiles[0].Extract((ms) => { header = _rootSerializer.Deserialize(ms); });
      return header;
    }
  }
}
