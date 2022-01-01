#region

using System;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster
{
  public class DateTimeRangeCluster : AbstractRangeCluster<DateTime>
  {
    public DateTimeRangeCluster(DateTime valueStart, DateTime valueEnd) : base(valueStart, valueEnd)
    {
    }

    public override object CentralValue => _valueStart.Add(new TimeSpan((_valueEnd - _valueStart).Ticks / 2));

    public override string Displayname
      => $"{_valueStart:yyyy-MM-dd HH:mm:ss} > {_valueEnd:yyyy-MM-dd HH:mm:ss}";

    public override bool Add(Guid documentGuid, object obj)
    {
      try
      {
        var test = (DateTime)obj;
        if (test < _valueStart || test > _valueEnd)
          return false;
        Add(documentGuid);
        return true;
      }
      catch
      {
        return false;
      }
    }
  }
}