using System;
using System.Collections.Generic;
using Bcs.IO;
using CorpusExplorer.Sdk.Extern.Plaintext.Abstract;
using CorpusExplorer.Sdk.Helper;

namespace CorpusExplorer.Sdk.Extern.Plaintext.ClarinContentSearch
{
  public class ClarinContentSearchScraper : AbstractPlaintextScraper
  {
    public ClarinContentSearchScraper()
    {
      Separator = ";";
    }

    public override string DisplayName => "CLARIN Content Search";

    public string Separator { get; set; }

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      var lines = FileIO.ReadText(file).Split(Splitter.LineBreaks, StringSplitOptions.RemoveEmptyEntries);

      var res = new List<Dictionary<string, object>>();
      var separator = new[] { Separator };

      for (var i = 1; i < lines.Length; i++)
      {
        var cells = lines[i].Split(separator, StringSplitOptions.None);

        res.Add(
          new Dictionary<string, object>
          {
            {
              "Text",
              string.Join(" ", Get(ref cells, 0), Get(ref cells, 1), Get(ref cells, 2))
                .Replace("\"\"", "\"")
                .Replace("---", "-")
                .Replace("[...]", "")
                .Trim()
            },
            {"PID", Get(ref cells, 3)},
            {"REF", Get(ref cells, 4)}
          });
      }

      return res;
    }

    private string Get(ref string[] cells, int index)
    {
      try
      {
        var text = cells[index].Trim();
        while (text.StartsWith("\""))
          text = text.Substring(1);
        while (text.EndsWith("\""))
          text = text.Substring(0, text.Length - 1);
        return text.Trim();
      }
      catch
      {
        return string.Empty;
      }
    }
  }
}