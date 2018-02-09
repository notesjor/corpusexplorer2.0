using System;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract;

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster
{
  public class DoubleRangeCluster : AbstractCluster
  {
    private readonly double _valueEnd;
    private readonly double _valueStart;

    public DoubleRangeCluster(double valueStart, double valueEnd)
    {
      _valueStart = valueStart;
      _valueEnd = valueEnd;
    }

    public override object CentralValue => _valueEnd - _valueStart;

    public override string Displayname => $"{_valueStart} > {_valueEnd}";

    public override bool Add(Guid documentGuid, object obj)
    {
      try
      {
        var test = (double) obj;
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