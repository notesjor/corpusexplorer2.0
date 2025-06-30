using System;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Properties;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class CooccurrenceNetworkSelectiveViewModel : AbstractViewModel, IProvideDataTable
  {
    public double CooccurrenceMinSignificance { get; set; } = 0.9;
    public int CooccurrenceMinFrequency { get; set; } = 0;
    public string LayerDisplayname { get; set; } = "Wort";
    public IEnumerable<string> LayerQueries { get; set; }

    protected override void ExecuteAnalyse()
    {
      var vm = new CooccurrenceViewModel
      {
        Selection = Selection,
        LayerDisplayname = LayerDisplayname,
        CooccurrenceMinSignificance = CooccurrenceMinSignificance,
        CooccurrenceMinFrequency = CooccurrenceMinFrequency
      };
      vm.Execute();

      var hash = new HashSet<string>(LayerQueries);
      var dict = new Dictionary<string, Dictionary<string, double>>();

      foreach (var x in hash)
        if (vm.SignificanceDictionary.TryGetValue(x, out var value))
          dict[x] = value;

      foreach (var x in vm.SignificanceDictionary.Where(x => !dict.ContainsKey(x.Key) && x.Value.Any(y => hash.Contains(y.Key))))
        dict[x.Key] = x.Value;

      #region cleanup
      var count = new Dictionary<string, int>();
      foreach (var x in dict)
      {
        if (count.ContainsKey(x.Key))
          count[x.Key] += x.Value.Count;
        else
          count.Add(x.Key, x.Value.Count);
        foreach (var y in x.Value)
          if (count.ContainsKey(y.Key))
            count[y.Key]++;
          else
            count.Add(y.Key, 1);
      }
      var remove = new HashSet<string>(count.Where(x => x.Value < 2).Select(x => x.Key));
      foreach (var x in remove)
        dict.Remove(x);
      var keys = dict.Keys.ToArray();
      foreach (var x in keys)
        dict[x] = dict[x].Where(y => !remove.Contains(y.Key)).ToDictionary(y => y.Key, y => y.Value);      
      keys = dict.Where(x => x.Value.Count < 2).Select(x => x.Key).ToArray();
      foreach (var x in keys)
        dict.Remove(x);
      #endregion

      SignificanceDictionary = dict.CompleteDictionaryToFullDictionary();
    }

    public Dictionary<string, Dictionary<string, double>> SignificanceDictionary { get; private set; }

    protected override bool Validate()
      => !string.IsNullOrWhiteSpace(LayerDisplayname) && LayerQueries != null && LayerQueries.Any();

    public DataTable GetDataTable()
    {
      if (SignificanceDictionary == null)
        ExecuteAnalyse();

      var dt = new DataTable();
      dt.Columns.Add($"{LayerDisplayname} (A)", typeof(string));
      dt.Columns.Add($"{LayerDisplayname} (B)", typeof(string));
      dt.Columns.Add(Resources.Significance, typeof(double));

      dt.BeginLoadData();
      foreach (var x in SignificanceDictionary)
        foreach (var y in x.Value)
          dt.Rows.Add(x.Key, y.Key, y.Value);
      dt.EndLoadData();

      return dt;
    }
  }
}
