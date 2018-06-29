using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Blocks.OverTime;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

namespace CorpusExplorer.Sdk.ViewModel.Abstract
{
  public abstract class AbstractOverTimeViewModel<T> : AbstractViewModel, IProvideDataTable
  {
    private OverTimeBlock<T> _block;

    public abstract OverTimeAggregationDelegate<T> AggregationFunction { get; }

    public abstract OverTimeCalculateDelegate<T> CalculateFunction { get; }

    public DateTime ClusterMaxDateTime { get; set; } = DateTime.MaxValue;

    public DateTime ClusterMinDateTime { get; set; } = DateTime.MinValue;

    public IEnumerable<KeyValuePair<DateTime, IEnumerable<Guid>>> DateTimeDocuments { get; private set; }

    public string DateTimeProperty { get; set; } = "Datum";

    public IEnumerable<KeyValuePair<DateTime, T>> DateTimeValues { get; set; }

    public IEnumerable<string> DocumentMetadata => Selection.GetDocumentMetadataPrototypeOnlyProperties();

    public DataTable GetDataTable()
    {
      return GetDataTable(DateTimeValues.Count());
    }

    public Dictionary<DateTime, Guid[]> AggregateDateTimeDocuments(int clusters)
    {
      return AggregateDateTimeDocuments(GetClusters(clusters));
    }

    public Dictionary<DateTime, Guid[]> AggregateDateTimeDocuments(DateTime[][] clusters)
    {
      var res = new Dictionary<DateTime, Guid[]>();
      var dic = DateTimeDocuments.ToDictionary(x => x.Key, x => x.Value);

      foreach (var cluster in clusters)
      {
        var max = DateTime.MinValue;
        var items = new List<Guid>();

        foreach (var dt in cluster)
        {
          if (dt > max)
            max = dt;

          if (dic.ContainsKey(dt))
            items.AddRange(dic[dt]);
        }

        res.Add(max, items.ToArray());
      }

      return res;
    }

    public Dictionary<DateTime, T> AggregateDateTimeValues(int clusters)
    {
      return AggregateDateTimeValues(GetClusters(clusters));
    }

    public Dictionary<DateTime, T> AggregateDateTimeValues(DateTime[][] clusters)
    {
      var res = new Dictionary<DateTime, T>();
      var dic = DateTimeValues.ToDictionary(x => x.Key, x => x.Value);

      foreach (var cluster in clusters)
      {
        var max = DateTime.MinValue;
        var items = new List<T>();

        foreach (var dt in cluster)
        {
          if (dt > max)
            max = dt;

          if (dic.ContainsKey(dt))
            items.Add(dic[dt]);
        }

        res.Add(max, AggregationFunction(items));
      }

      return res;
    }

    public DateTime[][] GetClusters(int clusters)
    {
      var min = ClusterMaxDateTime;
      var max = ClusterMinDateTime;

      foreach (var value in DateTimeValues)
      {
        if (value.Key < min && value.Key > ClusterMinDateTime)
          min = value.Key;
        if (value.Key > max && value.Key < ClusterMaxDateTime)
          max = value.Key;
      }

      var range = max.Ticks - min.Ticks;
      var section = range / clusters;

      var start = min;
      var end = start.AddTicks(section);

      var res = new List<DateTime[]>();

      do
      {
        var items =
          new List<DateTime>(
            from value in DateTimeValues where value.Key >= start && value.Key <= end select value.Key);
        if (items.Count == 0)
          items.Add(end);

        res.Add(items.ToArray());

        start = end;
        end = start.AddTicks(section);
      } while (start < max);

      return res.ToArray();
    }

    public DataTable GetDataTable(int clusters)
    {
      return GetDataTable(GetClusters(clusters));
    }

    public DataTable GetDataTable(DateTime[][] clusters)
    {
      return GetDataTable(AggregateDateTimeValues(clusters));
    }

    public abstract DataTable GetDataTable(Dictionary<DateTime, T> aggregateDateTimeValues);

    protected override void ExecuteAnalyse()
    {
      _block = Selection.CreateBlock<OverTimeBlock<T>>();
      _block.MetadataKey = DateTimeProperty;
      _block.Function = CalculateFunction;
      _block.Calculate();

      DateTimeDocuments = _block.DateTimePoints;
      DateTimeValues = _block.DateTimeValues;
    }

    protected override bool Validate()
    {
      return CalculateFunction != null && !string.IsNullOrEmpty(DateTimeProperty);
    }
  }
}