using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Helper;
using CorpusExplorer.Sdk.Extern.Xml.Ids.Exceptions;
using CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP.Model.Root;
using CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP.Model.SubSub.Data;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;
using CorpusExplorer.Sdk.Utils.ZipFileIndex;

namespace CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP
{
  public class KorapScraper : AbstractScraper
  {
    public override string DisplayName => "KorAP-XML Scraper";

    public bool Debug { get; set; } = false;
    private object _lockDebug = new object();
    private List<Exception> _debug = new List<Exception>();
    public IEnumerable<Exception> DebugLog
    {
      get
      {
        lock (_lockDebug)
          return _debug;
      }
    }

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      if (Path.GetFileNameWithoutExtension(file).Contains("."))
        return null;

      var res = new List<Dictionary<string, object>>();
      var zip = new ZipFileIndex(file);
      var root = zip.ZipDirectoryRoot.ZipDirectories[0];

      if (root.ZipFiles[0].NameFile != "header.xml")
        return null;

      var header = GetZipHeader(root, file);
      if (header == null)
        return null;

      foreach (var dir in root.ZipDirectories)
      {
        var dTitle = GetSubCorpusName(dir, file);

        foreach (var doc in dir.ZipDirectories)
        {
          var text = GetText(doc.ZipFiles.FirstOrDefault(x => x.NameFile == "data.xml"), file, doc.NamePath);
          if (string.IsNullOrEmpty(text))
            continue;
          var meta = GetMetadata(file, doc.NamePath, header, dTitle, doc.ZipFiles.FirstOrDefault(x => x.NameFile == "header.xml"));
          meta.Add("Text", text);
          res.Add(meta);
        }
      }

      return res;
    }

    private string GetText(ZipFileEntry zip, string path, string zipPath)
    {
      try
      {
        string res = null;
        zip.Read(ms => { res = XmlSerializerHelper.Deserialize<raw_text>(ms)?.text; });
        return res;
      }
      catch (Exception ex)
      {
        // ReSharper disable once InvertIf
        if (Debug)
          lock (_lockDebug)
            _debug.Add(new IdsException(path, zipPath + "/data.xml", ex));
        return null;
      }
    }

    private Dictionary<string, object> GetMetadata(string path, string zipPath, idsHeader corpusHeader, string dTitle, ZipFileEntry entry)
    {
      if (entry == null)
        return new Dictionary<string, object>();

      var res = new Dictionary<string, object>();
      res.Add("Korpus", corpusHeader?.fileDesc?.titleStmt?.ctitle);
      res.Add("Sprache", corpusHeader?.profileDesc?.langUsage?.language?.id);
      res.Add("Taxonomy", GetTaxonomy(corpusHeader?.encodingDesc?.classDecl?.taxonomy));
      res.Add("Dokumentebene", dTitle);
      res.Add("ZipPath", zipPath);

      entry.Read(ms =>
      {
        try
        {
          var meta = XmlSerializerHelper.Deserialize<Model.SubSub.Head.idsHeader>(ms);

          res.Add("Sigle", meta?.fileDesc?.titleStmt?.textSigle);
          res.Add("Titel", meta?.fileDesc?.titleStmt?.textSigle);
          res.Add("Titel (D)", meta?.fileDesc?.titleStmt?.ttitle);
          res.Add("Textsorte", meta?.profileDesc?.textDesc?.textType);
          res.Add("Referenz", Reduce(meta?.fileDesc?.sourceDesc?.reference?.FirstOrDefault(x => x.type == "complete")?.Text));
          res.Add("Datum", GetDate(meta?.fileDesc?.sourceDesc?.biblStruct?.monogr?.imprint?.pubDate));
        }
        catch (Exception ex)
        {
          if (Debug)
            lock (_lockDebug)
              _debug.Add(new IdsException(path, zipPath + "/header.xml", ex));
        }
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

    private string GetSubCorpusName(ZipDirectoryEntry dir, string path)
    {
      var res = string.Empty;
      dir.ZipFiles[0].Read(ms =>
      {
        try
        {
          var sub = XmlSerializerHelper.Deserialize<Model.Sub.idsHeader>(ms);
          res = sub.fileDesc.titleStmt.dtitle;
        }
        catch (Exception ex)
        {
          if (Debug)
            lock (_lockDebug)
              _debug.Add(new IdsException(path, dir.ZipFiles[0].NamePath, ex));
        }
      });
      return res;
    }

    private idsHeader GetZipHeader(ZipDirectoryEntry root, string path)
    {
      idsHeader header = null;
      try
      {
        root.ZipFiles[0].Read((ms) => { header = XmlSerializerHelper.Deserialize<idsHeader>(ms); });
      }
      catch (Exception ex)
      {
        if (Debug)
          lock (_lockDebug)
            _debug.Add(new IdsException(path, root.ZipFiles[0].NamePath, ex));
      }
      return header;
    }
  }
}
