using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bcs.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper
{
  public sealed class TsvScraper : AbstractScraper
  {
    // ReSharper disable once MemberCanBePrivate.Global
    public string[] Delimiters { get; set; } = {"\t"};
    public override string DisplayName => "TSV-Datei";

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      var res = new ConcurrentBag<Dictionary<string, object>>();

      var lines = FileIO.ReadLines(file);
      if (lines == null || lines.Length < 2)
        return res;

      var headers = lines[0].Split(Delimiters, StringSplitOptions.RemoveEmptyEntries);

      Parallel.For(1, lines.Length, Configuration.ParallelOptions, i =>
      {
        try
        {
          var row = lines[i].Split(Delimiters, StringSplitOptions.None);
          if (row.Length != headers.Length)
            return;
          var item = new Dictionary<string, object>();
          for (var j = 0; j < row.Length; j++)
            try
            {
              var key = headers[j];
              if (item.ContainsKey(key))
                continue;

              var val = string.IsNullOrWhiteSpace(row[j]) ? string.Empty : row[j];
              switch (key)
              {
                case "GUID":
                  item.Add(key, val == string.Empty ? Guid.Empty : Guid.Parse(val));
                  break;
                case "Datum":
                  item.Add(key, val == string.Empty ? DateTime.MinValue : DateTimeHelper.Parse(val));
                  break;
                default:
                  item.Add(key, val);
                  break;
              }
            }
            catch
            {
              // ignore
            }

          res.Add(item);
        }
        catch
        {
          // ignore
        }
      });

      return res;
    }
  }
}