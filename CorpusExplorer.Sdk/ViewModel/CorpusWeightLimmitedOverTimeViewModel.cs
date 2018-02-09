using System;
using System.Collections.Generic;
using System.Data;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Blocks.OverTime;
using CorpusExplorer.Sdk.Properties;
using CorpusExplorer.Sdk.ViewModel.Abstract;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class CorpusWeightLimmitedOverTimeViewModel : AbstractOverTimeViewModel<Dictionary<string, double[]>>
  {
    public override OverTimeAggregationDelegate<Dictionary<string, double[]>> AggregationFunction
    {
      get
      {
        return values =>
        {
          var res = new Dictionary<string, double[]>();

          foreach (var value in values)
          foreach (var pair in value)
            if (res.ContainsKey(pair.Key))
            {
              res[pair.Key][0] += pair.Value[0];
              res[pair.Key][1] += pair.Value[1];
              res[pair.Key][2] += pair.Value[2];
            }
            else
            {
              res.Add(pair.Key, pair.Value);
            }

          return res;
        };
      }
    }

    public override OverTimeCalculateDelegate<Dictionary<string, double[]>> CalculateFunction
    {
      get
      {
        return selection =>
        {
          var block = selection.CreateBlock<DocumentMetadataWeightBlock>();
          block.Calculate();

          var full = block.GetAggregatedSize();
          return full.ContainsKey(WeightProperty) ? full[WeightProperty] : new Dictionary<string, double[]>();
        };
      }
    }

    public string WeightProperty { get; set; } = "Autor";

    public IEnumerable<string> GetAvailableMetadataValueForCategory(string metadataCategory)
    {
      return Selection.GetDocumentMetadataPrototypeOnlyPropertieValuesAsString(metadataCategory);
    }

    public override DataTable GetDataTable(Dictionary<DateTime, Dictionary<string, double[]>> aggregateDateTimeValues)
    {
      var dt = new DataTable();

      dt.Columns.Add("Datum", typeof(DateTime));
      dt.Columns.Add(WeightProperty, typeof(string));
      dt.Columns.Add(Resources.Token, typeof(double));
      dt.Columns.Add(Resources.Types, typeof(double));
      dt.Columns.Add(Resources.Documents, typeof(double));

      dt.BeginLoadData();

      foreach (var date in aggregateDateTimeValues)
      foreach (var x in date.Value)
        dt.Rows.Add(date.Key, x.Key, x.Value[0], x.Value[1], x.Value[2]);
      dt.EndLoadData();

      return dt;
    }
  }
}