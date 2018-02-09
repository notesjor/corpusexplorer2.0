using System;
using System.Collections.Generic;
using Bcs.IO;
using CorpusExplorer.Sdk.Extern.Plaintext.Abstract;

namespace CorpusExplorer.Sdk.Extern.Plaintext.Csv
{
  public sealed class CsvScraper : AbstractPlaintextScraper
  {
    public CsvScraper() { Separator = ";"; }

    public override string DisplayName { get { return "CSV-Datei"; } }

    // ReSharper disable once MemberCanBePrivate.Global
    public string Separator { get; set; }

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      var lines = FileIO.ReadLines(file);

      var headers = lines[0].Split(new[] {Separator}, StringSplitOptions.None);
      var res = new List<Dictionary<string, object>>();

      for (var i = 1; i < lines.Length; i++)
      {
        var cells = lines[i].Split(new[] {Separator}, StringSplitOptions.None);
        if (cells.Length != headers.Length)
          continue;

        var dic = new Dictionary<string, object>();
        for (var j = 0; j < headers.Length; j++)
        {
          var head = headers[j];

          var cnt = 1;
          while (dic.ContainsKey(head))
            head = headers[j] + ++cnt;

          dic.Add(head, cells[j]);
        }

        res.Add(dic);
      }

      return res;
    }
  }
}