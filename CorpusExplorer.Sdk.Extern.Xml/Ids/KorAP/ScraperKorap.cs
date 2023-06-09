using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Extern.Xml.Helper;
using CorpusExplorer.Sdk.Extern.Xml.Ids.Exceptions;
using CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP.LoadStrategy;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;
using HtmlAgilityPack;

namespace CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP
{
  public class KorapScraper : AbstractScraper
  {
    public override string DisplayName => "KorAP-XML Scraper";

    public bool Debug { get; set; } = false;
    private object _lockDebug = new object();
    public bool ReadTaxonomy { get; set; } = false;
    public bool ReadLanguage { get; set; } = false;
    public int HtmlDecodeRounds { get; set; } = 0;

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
      try
      {
        using (var zip = new KorapZip(file))
        {
          try
          {
            var corpusRegex = new Regex(@"^[a-zA-Z0-9]*\/header\.xml$");
            var mainHeader = zip.Entries.Single(x => corpusRegex.IsMatch(x));

            if (string.IsNullOrWhiteSpace(mainHeader))
              return null;

            var header = GetZipHeader(file, zip, mainHeader);
            if (header == null)
              return null;

            var resLock = new object();
            var res = new List<Dictionary<string, object>>();

            var dataRegex = new Regex(@"^[a-zA-Z0-9]*\/[a-zA-Z0-9]*\/[a-zA-Z0-9]*\/data\.xml$");
            var tDatas = zip.Entries.Where(x => dataRegex.IsMatch(x)).ToArray();

            Parallel.ForEach(tDatas, Configuration.ParallelOptions, tData =>
            {
              var text = GetText(file, zip, tData);
              if (string.IsNullOrEmpty(text))
                return;

              var meta = GetMetadata(zip, tData.Replace("data.xml", ""), header);
              meta.Add("Text", text);
              lock (resLock)
                res.Add(meta);
            });

            return res;
          }
          catch (Exception ex)
          {
            if (Debug)
              lock (_lockDebug)
                _debug.Add(new IdsException(file, "/", ex));
            return null;
          }
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

    public string GetText(string path, KorapZip zip, string zipPath)
    {
      try
      {
        var res = zip.Read(zipPath).DocumentNode.SelectSingleNode("//text").InnerText;
        for (var i = 0; i < HtmlDecodeRounds; i++)
          res = HttpUtility.HtmlDecode(res);
        return res;
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

    public Dictionary<string, object> GetMetadata(KorapZip zip, string zipPath, Dictionary<string, object> corpusHeader)
    {
      var res = corpusHeader.ToDictionary(x => x.Key, x => x.Value);
      res.Add("ZipPath", zipPath);

      try
      {
        var xml = zip.Read(zipPath + "/header.xml");

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
            _debug.Add(new IdsException(zipPath, "GetMetadata", ex));
      }
      return res;
    }

    private DateTime GetDate(HtmlNode[] pubDates)
    {
      try
      {
        int y = -1, m = -1, d = -1;

        if (pubDates != null)
          foreach (var x in pubDates)
          {
            var type = x.GetAttributeValue("type", "");
            switch (type)
            {
              case "year":
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

        if (y == -1 || m == -1 || d == -1)
          return DateTime.MinValue;

        return new DateTime(y, m, d);
      }
      catch
      {
        return DateTime.MinValue;
      }
    }

    public Dictionary<string, object> GetZipHeader(string path, KorapZip zip, string zipPath)
    {
      Dictionary<string, object> res = null;
      try
      {
        var xml = zip.Read(zipPath);

        res = new Dictionary<string, object>
        {
          {"Korpus", xml.DocumentNode.SelectSingleNode("//c.title")?.InnerText},
        };

        if(ReadLanguage)
          res.Add("Sprache", BuildHeaderLanguageUsage(xml.DocumentNode.SelectNodes("//language")));

        if (ReadTaxonomy)
          res.Add("Taxonomy", BuildHeaderTaxonomy(xml.DocumentNode.SelectNodes("//taxonomy/category/catdesc")));
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
