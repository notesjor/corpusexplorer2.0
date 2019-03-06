using System;
using System.Linq;
using System.Text;
using Bcs.IO;
using CorpusExplorer.Sdk.Extern.OpenThesaurus.Model;

namespace CorpusExplorer.Sdk.Extern.OpenThesaurus.Parser
{
  public static class OpenThesaurusParser
  {
    public static QuickThesaurusIndex Read(string path, bool optimizeReverseEntries = true)
    {
      var lines = FileIO.ReadText(path, Encoding.UTF8)
                        .Split(new[] {"\r\n", "\r", "\n"}, StringSplitOptions.RemoveEmptyEntries);

      var res = new QuickThesaurusIndex();

      for (var i = 0; i < lines.Length; i++)
      {
        var line = lines[i];
        if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
          continue;

        // CLEAN
        while (line.Contains("("))
        {
          var s = line.IndexOf("(");
          var e = line.IndexOf(")", s);

          if (e == -1)
          {
            line = line.Replace("(", "");
            continue;
          }

          line = line.Substring(0, s) + line.Substring(e + 1).Replace("  ", " ");
        }

        line = line.Replace(".", "").Replace("?", "").Replace("!", "").Replace(",", "");

        // SPLIT
        var items = line.Split(new[] {";"}, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();

        res.Add(items);
      }

      if (optimizeReverseEntries)
        res.LaunchPostProcessing();
      return res;
    }
  }
}