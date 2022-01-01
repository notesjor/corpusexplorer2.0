using System;
using System.Collections.Generic;
using System.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;

namespace CorpusExplorer.Sdk.Model.Localizer
{
  public class ModelLocalization
  {
    private Dictionary<string, string> _dict = null;

    public void LoadLocalization(string path)
    {
      var lines = File.ReadAllLines(path, Configuration.Encoding);
      _dict = new Dictionary<string, string>();
      foreach (var line in lines)
      {
        var split = line.Split(new[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);
        if(split.Length != 2)
          continue;

        if (_dict.ContainsKey(split[0]))
          _dict[split[0]] = split[1];
        else
          _dict.Add(split[0], split[1]);
      }
    }

    public string Translate(string label) 
      => _dict == null ? label : _dict.ContainsKey(label) ? _dict[label] : label;
  }
}
