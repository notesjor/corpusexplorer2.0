using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CorpusExplorer.Sdk.Utils.Filter.Parser.FilterMultiLayerComplex
{
  public static class Parser4FilterQueryMultiLayerComplex
  {
    public static string Separator { get; set; } = "\t";

    public static KeyValuePair<string, HashSet<string>>[] Read(string path)
    {
      var lines = File.ReadAllLines(path);

      var separator = new[] { Separator };
      var res = lines[0].Split(separator, StringSplitOptions.RemoveEmptyEntries).Select(split => new KeyValuePair<string, HashSet<string>>(split, new HashSet<string>())).ToArray();

      foreach (var line in lines.Skip(1))
      {
        if (string.IsNullOrWhiteSpace(line))
          continue;

        var split = line.Split(separator, StringSplitOptions.None); // None ist hier wichtig
        for (var i = 0; i < split.Length; i++)
        {
          if (i >= res.Length)
            continue;

          res[i].Value.Add(split[i].Trim());
        }
      }

      return res;
    }
  }
}
