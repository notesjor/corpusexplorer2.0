﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter;
using CorpusExplorer.Sdk.Utils.Filter;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;

namespace CorpusExplorer.Sdk.Helper
{
  public static class SelectionListConverterHelper
  {
    public static void FromListStream(Project project, string listStream, out string[] errors)
    {
      var res = new Dictionary<Guid, Selection>();
      var err = new List<string>();

      try
      {
        var selDat = listStream.Split(Splitter.Question, StringSplitOptions.RemoveEmptyEntries);
        
        foreach (var sD in selDat)
          try
          {
            var dic = new Dictionary<Guid, HashSet<Guid>>();

            var corpora = sD.Split(Splitter.Hashtag, StringSplitOptions.RemoveEmptyEntries);
            for (var i = 1; i < corpora.Length; i++)
              try
              {
                var items = corpora[i].Split(Splitter.Greater, StringSplitOptions.RemoveEmptyEntries);
                if (items.Length < 2)
                  continue;

                var docs = new HashSet<Guid>();
                for (var j = 1; j < items.Length; j++)
                  docs.Add(Guid.Parse(items[j]));

                dic.Add(Guid.Parse(items[0]), docs);
              }
              catch
              {
                err.Add("Fehler beim Erzeugen der Selektion: " + corpora[i]);
              }

            var head = corpora[0].Split(Splitter.Equal, StringSplitOptions.RemoveEmptyEntries);
            var selection = project.CreateSelection(dic, DisplaynameDecoder(head[2]),
                                                    head[1] == "ROOT" ? null : res[Guid.Parse(head[1])]);

            if (head.Length == 4 && !string.IsNullOrEmpty(head[3]))
              selection.Queries = QueryDecoder(head[3]);

            res.Add(Guid.Parse(head[0]), selection);
          }
          catch
          {
            err.Add("Fehler beim Laden der Selektion: " + sD);
          }
      }
      catch
      {
        err.Add("Fehler beim Laden der Schnappschüsse");
      }

      errors = err.ToArray();
    }

    public static string ToListStream(Selection selection)
    {
      return ToListStream("ROOT", selection);
    }

    private static string DisplaynameDecoder(string displayname)
    {
      return displayname.Replace("&A!", "?").Replace("&E!", "=").Replace("&H!", "#").Replace("&N!", ">");
    }

    private static string DisplaynameEncoder(string displayname)
    {
      return displayname.Replace("?", "&A!").Replace("=", "&E!").Replace("#", "&H!").Replace(">", "&N!");
    }

    private static AbstractFilterQuery[] QueryDecoder(string exportInline)
    {
      return Configuration.Encoding.GetString(Convert.FromBase64String(exportInline.Replace('&', '=')))
                          .Split(Splitter.CRLF, StringSplitOptions.RemoveEmptyEntries).Select(QueryParser.Parse)
                          .ToArray();
    }

    private static string QueryEncoder(string exportInline)
    {
      return string.IsNullOrEmpty(exportInline)
               ? ""
               : Convert.ToBase64String(Configuration.Encoding.GetBytes(exportInline)).Replace("=", "&");
    }

    private static string ToListStream(string parent, Selection selection)
    {
      var stb = new StringBuilder(
                                  $"?{selection.Guid}={parent}={DisplaynameEncoder(selection.Displayname)}={QueryEncoder(ExporterQuery.ExportInline(selection))}");

      foreach (var c in selection)
        stb.Append($"#{c.Key}>{string.Join(">", c.Value.ToArray())}");

      foreach (var sub in selection.SubSelections)
        stb.Append(ToListStream(selection.Guid.ToString(), sub));

      return stb.ToString();
    }
  }
}