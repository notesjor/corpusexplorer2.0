using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks.NgramMultiLayerSelectiveQuery.ValidateCall;
using CorpusExplorer.Sdk.Blocks.NgramMultiLayerSelectiveQuery.ValidateCall.Abstract;
using CorpusExplorer.Sdk.Model;

namespace CorpusExplorer.Sdk.Blocks.NgramMultiLayerSelectiveQuery
{
  public static class QueryCompiler
  {
    public static List<Dictionary<string, AbstractValidateCall>> Compile(Selection selection, Dictionary<string, string[]> simpleQueries, string pattern = "*")
    {
      var n = simpleQueries.First().Value.Length;
      var layers = simpleQueries.Keys.ToArray();
      var compiledQueries = new List<Dictionary<string, AbstractValidateCall>>();
      for (var i = 0; i < n; i++)
      {
        compiledQueries.Add(new Dictionary<string, AbstractValidateCall>());
        foreach (var l in layers)
          compiledQueries[i].Add(l, Compile(selection, l, simpleQueries[l][i], pattern));
      }

      return compiledQueries;
    }

    private static AbstractValidateCall Compile(Selection selection, string l, string query, string pattern)
    {
      if (string.IsNullOrWhiteSpace(query) || query == pattern)
        return new ValidateCallAll();

      var layer = selection.GetLayers(l).First();

      if (query.StartsWith(pattern) && query.EndsWith(pattern))
        return ValidCallHashset.CreateContains(layer, query.Substring(1, query.Length - 2));
      if (query.StartsWith(pattern))
        return ValidCallHashset.CreateEndsWith(layer, query.Substring(1));
      if (query.EndsWith(pattern))
        return ValidCallHashset.CreateStartsWith(layer, query.Substring(0, query.Length - 1));
      if (query.StartsWith("REGEX:"))
        return new ValidateCallRegex(layer, query.Substring(6));

      return new ValidateCallExact(layer[query]);
    }
  }
}
