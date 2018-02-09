using System;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract;

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster
{
  public class IntegerRangeCluster : AbstractCluster
  {
    private readonly int _valueEnd;
    private readonly int _valueStart;

    public IntegerRangeCluster(int valueStart, int valueEnd)
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
        var test = (int) obj;
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