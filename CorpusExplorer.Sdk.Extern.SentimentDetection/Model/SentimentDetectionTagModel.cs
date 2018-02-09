using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Ecosystem.Model;

namespace CorpusExplorer.Sdk.Extern.SentimentDetection.Model
{
  public class SentimentDetectionTagModel
  {
    public Dictionary<string, Dictionary<string, double>> Data { get; private set; }

    private SentimentDetectionTagModel() { }

    public static SentimentDetectionTagModel Create(Dictionary<string, Dictionary<string, double>> data)
    {
      return new SentimentDetectionTagModel { Data = data };
    }

    public void Save(string path)
    {
      using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
      using (var sw = new StreamWriter(fs, Configuration.Encoding))
      {
        foreach (var x in Data)
          foreach (var y in x.Value)
            sw.WriteLine($"{x.Key}\t{y.Key}\t{y.Value}");
      }
    }

    public static SentimentDetectionTagModel Load(string path)
    {
      var res = new SentimentDetectionTagModel { Data = new Dictionary<string, Dictionary<string, double>>() };
      using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
      using (var sr = new StreamReader(fs, Configuration.Encoding))
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
          if (res.Data.ContainsKey(splits[0]))
          {
            if (!res.Data[splits[0]].ContainsKey(splits[1]))
              res.Data[splits[0]].Add(splits[1], val);
          }
          else
          {
            res.Data.Add(splits[0], new Dictionary<string, double> { { splits[1], val } });
          }
        }
        while (!sr.EndOfStream);
      return res;
    }
  }
}
