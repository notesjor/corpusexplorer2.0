#region

using System;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract;
using CorpusExplorer.Sdk.Helper;

#endregion

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster
{
  public class IntegerRangeCluster : AbstractRangeCluster<int>
  {
    public IntegerRangeCluster(int valueStart, int valueEnd) : base(valueStart, valueEnd)
    {
    }

    public override object CentralValue => _valueStart + (_valueEnd - _valueStart) / 2;

    public override string Displayname => $"{_valueStart} > {_valueEnd}";

    public override bool Add(Guid documentGuid, object obj)
    {
      try
      {
        var val = obj.SafeCastInt();
        if (val < _valueStart || val > _valueEnd)
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