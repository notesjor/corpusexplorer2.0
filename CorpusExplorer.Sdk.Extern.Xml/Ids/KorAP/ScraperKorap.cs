using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using CorpusExplorer.Sdk.Extern.Xml.Ids.Exceptions;
using CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP.LoadStrategy;
using CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP.LoadStrategy.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;
using HtmlAgilityPack;

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

    public AbstractLoadStrategy Strategy { get; set; } = new LoadStrategyFileStream();

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      try
      {
        using (var als = Strategy.Create(file, null))
        {
          if (als == null)
            return null;

          var prefix = HasLeadingPathPoint(als.Entries) ? @"^\.\/" : @"^";
          var corpusRegex = new Regex(prefix + @"[a-zA-Z0-9]*\/header\.xml");
          var mainHeader = als.Entries.FirstOrDefault(x => corpusRegex.IsMatch(x));

          if (string.IsNullOrWhiteSpace(mainHeader))
            return null;

          var header = GetZipHeader(file, als.GetEntry(mainHeader));
          if (header == null)
            return null;

          var res = new List<Dictionary<string, object>>();
          var dataRegex = new Regex(prefix + @"[a-zA-Z0-9]*\/[a-zA-Z0-9]*\/[a-zA-Z0-9]*\/data\.xml");
          foreach (var tData in als.Entries.Where(x => dataRegex.IsMatch(x)))
          {
            var text = GetText(file, als.GetEntry(tData));
            if (string.IsNullOrEmpty(text))
              continue;

            var mpath = tData.Replace("data.xml", "header.xml");
            var meta = GetMetadata(mpath, als.GetEntry(mpath), header);
            meta.Add("Text", text);
            res.Add(meta);
          }

          return res;
        }
      }
      catch (Exception ex)
      {
        if (Debug)
          lock (_lockDebug)
            _debug.Add(new IdsException(file, "/", ex));
      }

      return null;
    }

    private bool HasLeadingPathPoint(IEnumerable<string> entries)
      => entries.Take(10).Any(x => x.StartsWith("."));

    private string GetText(string path, Stream entry)
    {
      try
      {
        var xml = new HtmlDocument();
        xml.Load(entry, Encoding.UTF8);

        return WebUtility.HtmlDecode(xml.DocumentNode.SelectSingleNode("//text").InnerText);
      }
      catch (Exception ex)
      {
        // ReSharper disable once InvertIf
        if (Debug)
          lock (_lockDebug)
            _debug.Add(new IdsException(path, "GetText", ex));
        return null;
      }
    }

    private Dictionary<string, object> GetMetadata(string path, Stream entry, Dictionary<string, object> corpusHeader)
    {
      if (entry == null)
        return new Dictionary<string, object>();

      var res = corpusHeader.ToDictionary(x => x.Key, x => x.Value);
      res.Add("ZipPath", path.Replace("header.xml", ""));

      try
      {
        var xml = new HtmlDocument();
        xml.Load(entry);

        var titleStmt = xml.DocumentNode.SelectSingleNode("//titlestmt");
        var sigle = titleStmt.SelectSingleNode("./textsigle");
        var source = xml.DocumentNode.SelectSingleNode("//sourcedesc");

        res.Add("Sigle", sigle?.InnerText);
        res.Add("Titel", sigle?.InnerText);
        res.Add("Titel (D)", titleStmt.ChildNodes.FirstOrDefault(x => x.Name == "t.title")?.InnerText);
        res.Add("Textsorte", xml.DocumentNode.SelectSingleNode("//profiledesc/textdesc/texttype")?.InnerText);
        res.Add("Referenz", source.SelectSingleNode("./reference[@type='complete']")?.InnerText);
        res.Add("Datum", GetDate(source.SelectNodes("./biblstruct/monogr/imprint/pubdate")?.ToArray()));
      }
      catch (Exception ex)
      {
        if (Debug)
          lock (_lockDebug)
            _debug.Add(new IdsException(path, "GetMetadata", ex));
      }
      return res;
    }

    private DateTime GetDate(HtmlNode[] pubDates)
    {
      try
      {
        int y = -1, m = -1, d = -1;

        foreach (var x in pubDates)
        {
          var type = x.GetAttributeValue("type", "");
          switch (type)
          {
            case"year":
              y = int.Parse(x.InnerHtml);
              break;
            case "month":
              m = int.Parse(x.InnerHtml);
              break;
            case "day":
              d = int.Parse(x.InnerHtml);
              break;
          }
        }

        if(y == -1 || m == -1 || d == -1)
          return DateTime.MinValue;

        return new DateTime(y, m, d);
      }
      catch
      {
        return DateTime.MinValue;
      }
    }

    private string GetSubCorpusName(string path, ZipArchiveEntry entry, ref object zipLock)
    {
      try
      {
        var xml = new HtmlDocument();
        lock (zipLock)
          xml.Load(entry.Open());

        return xml.DocumentNode.SelectSingleNode("//d.title")?.InnerText;
      }
      catch (Exception ex)
      {
        if (Debug)
          lock (_lockDebug)
            _debug.Add(new IdsException(path, entry.FullName, ex));
        return null;
      }
    }

    private Dictionary<string, object> GetZipHeader(string path, Stream entry)
    {
      Dictionary<string, object> res = null;
      try
      {
        var xml = new HtmlDocument();
        xml.Load(entry);

        res = new Dictionary<string, object>
        {
          {"Korpus", xml.DocumentNode.SelectSingleNode("//c.title")?.InnerText},
          {"Sprache", BuildHeaderLanguageUsage(xml.DocumentNode.SelectNodes("//language"))},
          {"Taxonomy", BuildHeaderTaxonomy(xml.DocumentNode.SelectNodes("//taxonomy/category/catdesc"))}
        };
      }
      catch (Exception ex)
      {
        if (Debug)
          lock (_lockDebug)
            _debug.Add(new IdsException(path, "GetZipHeader", ex));
      }
      return res ?? new Dictionary<string, object>();
    }

    private string BuildHeaderLanguageUsage(HtmlNodeCollection selectNodes)
    {
      try
      {
        return string.Join(" | ",
                           selectNodes.Select(node =>
                                                $"{node.GetAttributeValue("id", "-")} ({node.GetAttributeValue("usage", "0")}%)"));
      }
      catch
      {
        return string.Empty;
      }
    }

    private string BuildHeaderTaxonomy(IEnumerable<HtmlNode> nodes)
    {
      try
      {
        return string.Join(" | ", nodes.Select(n => n.InnerText));
      }
      catch
      {
        return string.Empty;
      }
    }
  }
}
