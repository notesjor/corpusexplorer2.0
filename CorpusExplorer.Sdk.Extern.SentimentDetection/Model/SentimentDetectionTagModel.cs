using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CorpusExplorer.Sdk.Ecosystem.Model;

namespace CorpusExplorer.Sdk.Extern.SentimentDetection.Model
{
  public class SentimentDetectionTagModel
  {
    private Dictionary<string, Dictionary<string, double>> _data;

    private SentimentDetectionTagModel()
    {
    }

    public Dictionary<string, Dictionary<string, double>> Data => _data ?? RawData;

    public Dictionary<string, Dictionary<string, double>> RawData { get; private set; }

    public static SentimentDetectionTagModel Create(Dictionary<string, Dictionary<string, double>> data)
    {
      return new SentimentDetectionTagModel { RawData = data };
    }

    public static SentimentDetectionTagModel Load(string path)
    {
      var res = new SentimentDetectionTagModel { RawData = new Dictionary<string, Dictionary<string, double>>() };
      using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
      using (var bs = new BufferedStream(fs))
      using (var sr = new StreamReader(bs, Configuration.Encoding))
      {
        do
        {
          var line = sr.ReadLine();
          if (string.IsNullOrEmpty(line))
            continue;

          var splits = line.Split(new[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);
          if (splits.Length != 3)
            continue;
          double val;
          if (!double.TryParse(splits[2], out val))
            continue;
          if (res.RawData.ContainsKey(splits[0]))
          {
            if (!res.RawData[splits[0]].ContainsKey(splits[1]))
              res.RawData[splits[0]].Add(splits[1], val);
          }
          else
          {
            res.RawData.Add(splits[0], new Dictionary<string, double> { { splits[1], val } });
          }
        } while (!sr.EndOfStream);
      }

      return res;
    }

    public void Save(string path)
    {
      using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
      using (var bs = new BufferedStream(fs))
      using (var sw = new StreamWriter(bs, Configuration.Encoding))
      {
        foreach (var x in RawData)
          foreach (var y in x.Value)
            sw.WriteLine($"{x.Key}\t{y.Key}\t{y.Value}");
      }
    }

    public void Compile(IEnumerable<string> layerValues)
    {
      var values = layerValues.ToArray();
      _data = new Dictionary<string, Dictionary<string, double>>();

      foreach (var c in RawData)
      {
        _data.Add(c.Key, new Dictionary<string, double>());
        foreach (var v in c.Value)
        {
          IEnumerable<string> items;
          if (v.Key.StartsWith("*"))
            items = values.Where(x => x.EndsWith(v.Key.Substring(1)));
          else if (v.Key.EndsWith("*"))
            items = values.Where(x => x.StartsWith(v.Key.Substring(0, v.Key.Length - 1)));
          else
            items = new[] { v.Key };
          foreach (var item in items)
            if (!_data[c.Key].ContainsKey(item))
              _data[c.Key].Add(item, v.Value);
        }
      }
    }
  }
}