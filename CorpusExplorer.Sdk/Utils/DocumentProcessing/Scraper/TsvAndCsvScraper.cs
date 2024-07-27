using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;
using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper
{
  public class TsvAndCsvScraper : AbstractScraper
  {
    public override string DisplayName => "TSV/CSV";

    public string Delimiters { get; set; } = null;
    public string NewLine { get; set; } = Environment.NewLine;

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      var res = new List<Dictionary<string, object>>();

      var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
      {
        DetectDelimiter = Delimiters == null,
        Encoding = Configuration.Encoding,
        HasHeaderRecord = true,
        NewLine = NewLine,
        TrimOptions = TrimOptions.Trim,
      };

      if (Delimiters != null)
        csvConfig.Delimiter = Delimiters;

      using (var fs = new FileStream(file, FileMode.Open, FileAccess.Read))
      using (var reader = new StreamReader(fs, Configuration.Encoding))
      using (var csv = new CsvReader(reader, csvConfig))
      {
        csv.Read();
        csv.ReadHeader();
        var headers = csv.HeaderRecord;
        // fix header
        for (var i = 0; i < headers.Length; i++)
          if (headers[i].ToLower() == "text")
          {
            headers[i] = "Text";
            break;
          }

        while (csv.Read())
        {
          var item = new Dictionary<string, object>();
          for (var j = 0; j < headers.Length; j++)
          {
            try
            {
              var key = headers[j];
              if (item.ContainsKey(key))
                continue;

              var val = string.IsNullOrWhiteSpace(csv.GetField(j)) ? string.Empty : csv.GetField(j);
              switch (key)
              {
                case "GUID":
                case "guid":
                  item.Add(key, val == string.Empty ? Guid.Empty : Guid.Parse(val));
                  break;
                case "Datum":
                case "datum":
                case "date":
                case "datetime":
                case "date-time":
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
          }
          res.Add(item);
        }
      }

      return res;
    }
  }
}
