using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bcs.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper
{
  public sealed class CsvScraper : AbstractScraper
  {
    // ReSharper disable once MemberCanBePrivate.Global
    public string[] Delimiters { get; set; } = { ";" };
    public override string DisplayName => "CSV-Datei";

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      var res = new ConcurrentBag<Dictionary<string, object>>();

      var lines = FileIO.ReadLines(file);
      if (lines == null || lines.Length < 2)
        return res;

      var headers = lines[0].Split(Delimiters, StringSplitOptions.RemoveEmptyEntries).Select(Clean).ToArray();

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

              var val = string.IsNullOrWhiteSpace(row[j]) ? string.Empty : Clean(row[j]);
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

    private string Clean(string input)
    {
      if(input == null || input.Length < 2)
        return input;
      if (input[0] == '"' && input[input.Length - 1] == '"')
        return input.Substring(1, input.Length - 2);
      return input;
    }
  }
}