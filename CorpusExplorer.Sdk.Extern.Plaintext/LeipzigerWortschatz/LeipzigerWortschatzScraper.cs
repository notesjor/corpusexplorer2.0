using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Bcs.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Extern.Plaintext.Abstract;
using CorpusExplorer.Sdk.Helper;

namespace CorpusExplorer.Sdk.Extern.Plaintext.LeipzigerWortschatz
{
  public class LeipzigerWortschatzScraper : AbstractPlaintextScraper
  {
    public override string DisplayName => "Leipziger Wortschatz";

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      var dir = Path.GetDirectoryName(file);
      var files = Directory.GetFiles(dir, "*.txt", SearchOption.TopDirectoryOnly);

      var fileSources = (from x in files where x.EndsWith("-sources.txt") select x).FirstOrDefault();
      var fileRelations = (from x in files where x.EndsWith("-inv_so.txt") select x).FirstOrDefault();
      var fileSentences = (from x in files where x.EndsWith("-sentences.txt") select x).FirstOrDefault();

      if (fileSources == null || fileRelations == null || fileSentences == null) return null;

      var sources = ReadSources(fileSources);
      var realtions = ReadRelation(fileRelations);
      var sentences = ReadSentences(fileSentences);

      var res = new List<Dictionary<string, object>>();
      foreach (var sentence in sentences)
        try
        {
          var doc = new Dictionary<string, object> {{"Text", sentence.Value}, {"ID", sentence.Key}};
          try
          {
            var meta = sources[realtions[sentence.Key]];
            foreach (var x in meta)
              doc.Add(x.Key, x.Value);
          }
          catch
          {
            // ignore
          }

          res.Add(doc);
        }
        catch
        {
          // ignore
        }

      return res;
    }

    private Dictionary<int, int> ReadRelation(string fileSources)
    {
      var res = new Dictionary<int, int>();
      var lines = FileIO.ReadLines(fileSources, Configuration.Encoding);
      foreach (var line in lines)
        try
        {
          var split = line.Split(Splitter.Tab, StringSplitOptions.RemoveEmptyEntries);
          if (split.Length != 2)
            continue;

          var source = int.Parse(split[0]);
          var sentence = int.Parse(split[1]);
          res.Add(sentence, source);
        }
        catch
        {
          // ignore
        }

      return res;
    }

    private Dictionary<int, string> ReadSentences(string fileSentences)
    {
      var res = new Dictionary<int, string>();
      var lines = FileIO.ReadLines(fileSentences, Configuration.Encoding);
      foreach (var line in lines)
        try
        {
          var split = line.Split(Splitter.Tab, StringSplitOptions.RemoveEmptyEntries);
          if (split.Length != 2)
            continue;

          res.Add(int.Parse(split[0]), split[1]);
        }
        catch
        {
          // ignore
        }

      return res;
    }

    private Dictionary<int, Dictionary<string, object>> ReadSources(string fileSources)
    {
      var res = new Dictionary<int, Dictionary<string, object>>();
      var lines = FileIO.ReadLines(fileSources, Configuration.Encoding);
      foreach (var line in lines)
        try
        {
          var split = line.Split(Splitter.Tab, StringSplitOptions.RemoveEmptyEntries);
          if (split.Length != 3)
            continue;

          var key = int.Parse(split[0]);
          var dat = DateTimeHelper.Parse(split[2], "yyyy-MM-dd");
          res.Add(key, new Dictionary<string, object>
          {
            {"Datum", dat},
            {"URL", split[1]}
          });
        }
        catch
        {
          // ignore
        }

      return res;
    }
  }
}