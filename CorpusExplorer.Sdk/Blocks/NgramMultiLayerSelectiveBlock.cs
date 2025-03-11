using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;

namespace CorpusExplorer.Sdk.Blocks
{
  [Serializable]
  public class NgramMultiLayerSelectiveBlock : AbstractBlock
  {
    private string Pattern { get; set; } = "*";
    public Dictionary<string, double> NGramFrequency { get; private set; }
    public Dictionary<string, string[]> LayerAndQueries { get; set; }
    public string LayerDisplayname { get; set; } = "Wort";

    private abstract class AbstractValidateCall
    {
      public abstract bool Validate(int index);
    }

    private sealed class ValidateCallAll : AbstractValidateCall
    {
      public override bool Validate(int index) => true;
    }

    private sealed class ValidateCallExact : AbstractValidateCall
    {
      private readonly int _index;
      public ValidateCallExact(int index) => _index = index;
      public override bool Validate(int index) => _index == index;
    }

    private sealed class ValidCallHashset : AbstractValidateCall
    {
      private readonly HashSet<int> _hashSet;
      private ValidCallHashset(HashSet<int> hashSet) => _hashSet = hashSet;
      public static ValidCallHashset CreateContains(AbstractLayerAdapter layer, string value)
        => new ValidCallHashset(new HashSet<int>(layer.Values.Where(x => x.Contains(value)).Select(x => layer[x])));
      public static ValidCallHashset CreateStartsWith(AbstractLayerAdapter layer, string value)
        => new ValidCallHashset(new HashSet<int>(layer.Values.Where(x => x.StartsWith(value)).Select(x => layer[x])));
      public static ValidCallHashset CreateEndsWith(AbstractLayerAdapter layer, string value)
        => new ValidCallHashset(new HashSet<int>(layer.Values.Where(x => x.EndsWith(value)).Select(x => layer[x])));
      public override bool Validate(int index) => _hashSet.Contains(index);
    }

    private sealed class ValidateCallRegex : AbstractValidateCall
    {
      private readonly HashSet<int> _hashSet;
      public ValidateCallRegex(AbstractLayerAdapter layer, string value)
      {
        var regex = new System.Text.RegularExpressions.Regex(value);
        _hashSet = new HashSet<int>(from x in layer.ReciveRawLayerDictionary() where regex.IsMatch(x.Key) select x.Value);
      }

      public override bool Validate(int index) => _hashSet.Contains(index);
    }

    public override void Calculate()
    {
      NGramFrequency = new Dictionary<string, double>();

      var nMax = LayerAndQueries.First().Value.Length;
      if (LayerAndQueries.Keys.Any(k => LayerAndQueries[k].Length != nMax))
        return;

      var mainLayer = Selection.GetLayers(LayerDisplayname).First();
      var layers = LayerAndQueries.Keys.ToArray();
      var compiledQueries = GetCompiledQueries(nMax, layers);
      var layerNames = new HashSet<string>(layers) { LayerDisplayname };
      var @lock = new object();

      Parallel.ForEach(Selection.DocumentGuids, dsel =>
      {
        var multi = Selection.GetMultilayerDocument(dsel, layerNames);
        if (multi.Count != compiledQueries.Count)
          return;

        var first = multi.First(x => x.Key == LayerDisplayname);
        for (var s = 0; s < first.Value.Length; s++)
        {
          for (var t = 0; t < first.Value[s].Length; t++)
          {
            var valid = true;
            for (var n = 0; n < nMax; n++)
            {
              if (layers.All(l => compiledQueries[n][l].Validate(multi[l][s][t])))
                continue;

              valid = false;
              break;
            }

            if (!valid)
              continue;

            var tmp = new List<string>();
            for (var n = 0; n < nMax; n++)
              tmp.Add(mainLayer[first.Value[s][t + n]]);
            var key = string.Join(" ", tmp);
            lock (@lock)
            {
              if (NGramFrequency.ContainsKey(key))
                NGramFrequency[key]++;
              else
                NGramFrequency.Add(key, 1);
            } 
          }
        }
      });
    }

    private List<Dictionary<string, AbstractValidateCall>> GetCompiledQueries(int n, string[] layers)
    {
      var compiledQueries = new List<Dictionary<string, AbstractValidateCall>>();
      for (var i = 0; i < n; i++)
      {
        compiledQueries.Add(new Dictionary<string, AbstractValidateCall>());
        foreach (var l in layers)
          compiledQueries[i].Add(l, Compile(l, LayerAndQueries[l][i]));
      }

      return compiledQueries;
    }

    private AbstractValidateCall Compile(string lKey, string query)
    {
      var layer = Selection.GetLayers(lKey).First();

      if (string.IsNullOrWhiteSpace(query) || query == Pattern)
        return new ValidateCallAll();
      if (query.StartsWith(Pattern) && query.EndsWith(Pattern))
        return ValidCallHashset.CreateContains(layer, query.Substring(1, query.Length - 2));
      if (query.StartsWith(Pattern))
        return ValidCallHashset.CreateEndsWith(layer, query.Substring(1));
      if (query.EndsWith(Pattern))
        return ValidCallHashset.CreateStartsWith(layer, query.Substring(0, query.Length - 1));
      if (query.StartsWith("REGEX:"))
        return new ValidateCallRegex(layer, query.Substring(6));

      return new ValidateCallExact(layer[query]);
    }
  }
}