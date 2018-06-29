using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks.Abstract;

namespace CorpusExplorer.Sdk.Blocks
{
  public class SyntagmaBlock : AbstractBlock
  {
    private Dictionary<string, Dictionary<string, double>> _cooc;
    private CooccurrenceOverlappingBlock _multi;

    public string LayerDisplayname { get; set; } = "Wort";
    public string LayerQuery { get; set; }

    public Dictionary<string, Tuple<double, Dictionary<string, double[]>>> SyntagmaResults { get; set; }

    public override void Calculate()
    {
      InitCooccurrences();
      InitMultiCooccurrences();

      SyntagmaResults = new Dictionary<string, Tuple<double, Dictionary<string, double[]>>>();

      var master = GetCooccurrences(LayerQuery);
      foreach (var m in master)
      {
        var coocc = GetCooccurrences(m.Key);
        var multi = GetMultiCooccurrences(m.Key);

        coocc = Normalize(coocc);
      }
    }

    private Dictionary<string, double> GetCooccurrences(string query)
    {
      var res = _cooc.ContainsKey(query) ? _cooc[query] : new Dictionary<string, double>();
      foreach (var c in _cooc)
        if (c.Value.ContainsKey(query) && !res.ContainsKey(c.Key))
          res.Add(c.Key, c.Value[query]);
      return res;
    }

    private Dictionary<string, double> GetMultiCooccurrences(string query)
    {
      _multi.LayerQueries = new[] {LayerQuery, query};
      _multi.Calculate();
      return _multi.CooccurrenceSignificance;
    }

    private void InitCooccurrences()
    {
      var block1 = Selection.CreateBlock<CooccurrenceBlock>();
      block1.LayerDisplayname = LayerDisplayname;
      block1.Calculate();
      _cooc = block1.CooccurrenceSignificance;
    }

    private void InitMultiCooccurrences()
    {
      _multi = Selection.CreateBlock<CooccurrenceOverlappingBlock>();
      _multi.LayerDisplayname = LayerDisplayname;
    }

    private Dictionary<string, double> Normalize(Dictionary<string, double> coocc)
    {
      var max = coocc.Select(c => c.Value).Concat(new[] {1d}).Max();
      return coocc.ToDictionary(c => c.Key, c => c.Value / max);
    }
  }
}