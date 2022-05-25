#region

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Extern.Plaintext.Abstract;
using CorpusExplorer.Sdk.Helper;

#endregion

namespace CorpusExplorer.Sdk.Extern.Plaintext.EasyHashtagSeparation
{
  public sealed class EasyHashtagSeparationScraper : AbstractPlaintextScraper
  {
    public override string DisplayName => "Plaintext #-Triplex-Trennung";

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      var lines = File.ReadAllLines(file, Configuration.Encoding);

      var cnt = 1;
      var name = Path.GetFileNameWithoutExtension(file);
      var res = new List<Dictionary<string, object>>();
      var dic = new Dictionary<string, object> { { "ID", cnt++ }, { "Datei", name } };
      var stb = new StringBuilder();

      foreach (var line in lines.Where(line => !string.IsNullOrEmpty(line)))
      {
        if (line.StartsWith("###"))
        {
          dic.Add("Text", stb.ToString());
          stb.Clear();

          res.Add(dic);
          dic = new Dictionary<string, object> { { "ID", cnt++ }, { "Datei", name } };

          continue;
        }

        if (line.StartsWith("#"))
        {
          var splits = line.Split(new[] { '#' }, StringSplitOptions.RemoveEmptyEntries);
          if (splits.Length != 2 || splits[0] == "Text")
            continue;

          if (splits[0] == "Datum")
          {
            if (dic.ContainsKey(splits[0]))
            {
              dic["Datum (Original)"] = splits[1];
              dic[splits[0]] = DateTimeHelper.Parse(splits[1], true);
            }
            else
            {
              dic.Add("Datum (Original)", splits[1]);
              dic.Add(splits[0], DateTimeHelper.Parse(splits[1], true));
            }
          }
          else
          {
            if (dic.ContainsKey(splits[0]))
              dic[splits[0]] = splits[1];
            else
              dic.Add(splits[0], splits[1]);
          }
        }
        else
        {
          stb.AppendLine(line);
        }
      }

      if (stb.Length > 0)
      {
        dic.Add("Text", stb.ToString());
        res.Add(dic);
      }

      return res;
    }
  }
}