using System;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract;

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster
{
  public class DateTimeRangeCluster : AbstractCluster
  {
    private readonly DateTime _valueEnd;
    private readonly DateTime _valueStart;

    public DateTimeRangeCluster(DateTime valueStart, DateTime valueEnd)
    {
      _valueStart = valueStart;
      _valueEnd = valueEnd;
    }

    public override object CentralValue => _valueStart.Add(_valueEnd - _valueStart);

    public override string Displayname
      => $"{_valueStart:yyyy-MM-dd HH:mm:ss} > {_valueEnd:yyyy-MM-dd HH:mm:ss}";

    public override bool Add(Guid documentGuid, object obj)
    {
      try
      {
        var test = (DateTime) obj;
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