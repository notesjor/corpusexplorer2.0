using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Blocks.OverTime;
using CorpusExplorer.Sdk.Properties;
using CorpusExplorer.Sdk.ViewModel.Abstract;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class FrequencyOverTimeViewModel : AbstractOverTimeViewModel<Dictionary<string, double>>
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
          var block = selection.CreateBlock<Frequency1LayerBlock>();
          block.LayerDisplayname = LayerDisplayname;
          block.Calculate();

          var rel = block.FrequencyRelative;

          return LayerQueries.ToDictionary(query => query, query => rel.ContainsKey(query) ? rel[query] : 0);
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