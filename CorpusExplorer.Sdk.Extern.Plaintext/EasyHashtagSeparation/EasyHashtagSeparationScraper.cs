#region

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Extern.Plaintext.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Extern.Plaintext.EasyHashtagSeparation
{
  public sealed class EasyHashtagSeparationScraper : AbstractPlaintextScraper
  {
    public override string DisplayName { get { return "Plaintext #-Triplex-Trennung"; } }

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      var lines = File.ReadAllLines(file, Configuration.Encoding);
      var res = new List<Dictionary<string, object>>();
      var dic = new Dictionary<string, object>();
      var txt = "";

      foreach (var line in lines.Where(line => !string.IsNullOrEmpty(line)))
      {
        if (line.Contains("###"))
        {
          dic.Add("Text", txt.Trim());
          txt = "";

          res.Add(dic);
          dic = new Dictionary<string, object>();

          continue;
        }
        if (line.StartsWith("#"))
        {
          var splits = line.Split(new[] {'#'}, StringSplitOptions.RemoveEmptyEntries);
          if (splits.Length != 2)
            continue;
          if (dic.ContainsKey(splits[0]))
            dic[splits[0]] = splits[1];
          else
            dic.Add(splits[0], splits[1]);
        }
        else
          txt += " " + line;
      }

      if (string.IsNullOrEmpty(txt))
        return res;

      dic.Add("Text", txt.Trim());
      res.Add(dic);

      return res;
    }
  }
}