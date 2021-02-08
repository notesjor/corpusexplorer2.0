using System;
using System.Collections.Generic;
using System.Data;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Blocks.OverTime;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Properties;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class FrequencyCrossFrequencyOverTimeViewModel : AbstractOverTimeViewModel<Dictionary<string, double>>
  {
    public override OverTimeAggregationDelegate<Dictionary<string, double>> AggregationFunction
    {
      get
      {
        return values =>
        {
          var res = new Dictionary<string, double>();

          foreach (var value in values)
            foreach (var pair in value)
              if (res.ContainsKey(pair.Key))
                res[pair.Key] += pair.Value;
              else
                res.Add(pair.Key, pair.Value);

          return res;
        };
      }
    }

    public override OverTimeCalculateDelegate<Dictionary<string, double>> CalculateFunction
    {
      get
      {
        return selection =>
        {
          var block = selection.CreateBlock<CrossFrequencyBlock>();
          block.LayerDisplayname = LayerDisplayname;
          block.Calculate();

          var full = block.CooccurrencesFrequency.CompleteDictionaryToFullDictionary();
          var res = new Dictionary<string, double>();
          foreach (var query in LayerQueries)
          {
            if (!full.ContainsKey(query))
              continue;

            var values = full[query];
            foreach (var v in values)
              if (res.ContainsKey(v.Key))
              {
                if (res[v.Key] < v.Value)
                  res[v.Key] = v.Value;
              }
              else
              {
                res.Add(v.Key, v.Value);
              }
          }

          return res;
        };
      }
    }

    public string LayerDisplayname { get; set; } = "Wort";

    public IEnumerable<string> LayerQueries { get; set; }

    public override DataTable GetDataTable(Dictionary<DateTime, Dictionary<string, double>> aggregateDateTimeValues)
    {
      var dt = new DataTable();

      dt.Columns.Add("Datum", typeof(DateTime));
      dt.Columns.Add(LayerDisplayname, typeof(string));
      dt.Columns.Add(Resources.Frequency, typeof(double));

      dt.BeginLoadData();

      foreach (var date in aggregateDateTimeValues)
        foreach (var x in date.Value)
          dt.Rows.Add(date.Key, x.Key, x.Value);
      dt.EndLoadData();

      return dt;
    }
  }
}