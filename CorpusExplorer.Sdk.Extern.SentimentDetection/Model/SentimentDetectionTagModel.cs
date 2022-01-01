using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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

    private Dictionary<string, Dictionary<string, double>> RawData { get; set; }

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
          if (!double.TryParse(splits[2], out var val))
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
      var values = new HashSet<string>(layerValues);
      var prefixes = new Dictionary<string, KeyValuePair<string, double>>();
      var postfixes = new Dictionary<string, KeyValuePair<string, double>>();
      _data = new Dictionary<string, Dictionary<string, double>>();

      foreach (var c in RawData)
      {
        _data.Add(c.Key, new Dictionary<string, double>());
        foreach (var v in c.Value)
        {
          if (v.Key.EndsWith("*"))
          {
            var prefix = v.Key.Substring(0, v.Key.Length - 1);
            if (!prefixes.ContainsKey(prefix))
              prefixes.Add(prefix, new KeyValuePair<string, double>(c.Key, v.Value));
          }
          else if (v.Key.StartsWith("*"))
          {
            var postfix = v.Key.Substring(1);
            if (!postfixes.ContainsKey(postfix))
              postfixes.Add(postfix, new KeyValuePair<string, double>(c.Key, v.Value));
          }
          else if (values.Contains(v.Key) && !_data[c.Key].ContainsKey(v.Key))
            _data[c.Key].Add(v.Key, v.Value);
        }
      }

      var l = new object();
      int min, max;
      try
      {
        min = prefixes.Keys.Min(x => x.Length);
        max = prefixes.Keys.Max(x => x.Length);
        Parallel.ForEach(values, v =>
        {
          for (var i = min; i < max; i++)
          {
            if (v.Length < i)
              return;

            var key = v.Substring(0, i);
            if (!prefixes.ContainsKey(key))
              return;

            lock (l)
              if (!_data[prefixes[key].Key].ContainsKey(v))
                _data[prefixes[key].Key].Add(v, prefixes[key].Value);
          }
        });
      }
      catch
      {
        // ignore
      }

      try
      {
        min = postfixes.Keys.Min(x => x.Length);
        max = postfixes.Keys.Max(x => x.Length);
        Parallel.ForEach(values, v =>
        {
          for (var i = min; i < max; i++)
          {
            if (v.Length < i)
              return;

            var key = v.Substring(v.Length - i);
            if (!postfixes.ContainsKey(key))
              return;

            lock (l)
              if (!_data[postfixes[key].Key].ContainsKey(v))
                _data[postfixes[key].Key].Add(v, postfixes[key].Value);
          }
        });
      }
      catch
      {
        // ignorieren
      }

      values.Clear();
      prefixes.Clear();
      postfixes.Clear();
      GC.Collect();
    }
  }
}