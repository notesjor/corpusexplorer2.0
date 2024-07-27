using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
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
    public string[] Delimiters { get; set; } = { "\t" };
    public override string DisplayName => "TSV-Datei";

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      var res = new List<Dictionary<string, object>>();

      using (var fs = new FileStream(file, FileMode.Open, FileAccess.Read))
      using (var sr = new StreamReader(fs, Configuration.Encoding))
      {
        var headers = sr.ReadLine().Split(Delimiters, StringSplitOptions.None);

        while (!sr.EndOfStream)
        {
          try
          {
            var row = sr.ReadLine().Split(Delimiters, StringSplitOptions.None);
            if (row.Length != headers.Length)
              continue;
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
                  case "guid":
                    item.Add(key, val == string.Empty ? Guid.Empty : Guid.Parse(val));
                    break;
                  case "Datum":
                  case "datum":
                  case "date":
                    item.Add(key, val == string.Empty ? DateTime.MinValue : DateTimeHelper.Parse(val));
                    break;
                  case "Jahr":
                  case "year":
                  case "Monat":
                  case "month":
                  case "Tag":
                  case "day":
                    var test = int.TryParse(val, out var v);
                    item.Add(key, test ? v : 0);
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

            if (item.ContainsKey("text")) // Fix: Falscher case für Text
            {
              var text = item["text"].ToString();
              item.Remove("text");
              item.Add("Text", text);
            }
            if (item.ContainsKey("Text")) // Fix: Behebt TSV-Sondercodierung von Zeichenketten
            {
              var text = item["Text"].ToString();
              if (text.StartsWith("\"") && text.EndsWith("\""))
                item["Text"] = text.Substring(1, text.Length - 2);
            }

            res.Add(item);
          }
          catch
          {
            // ignore
          }
        }
      }

      return res;
    }
  }
}