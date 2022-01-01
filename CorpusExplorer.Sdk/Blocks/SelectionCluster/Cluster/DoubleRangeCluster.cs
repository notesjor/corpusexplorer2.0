#region

using System;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract;
using CorpusExplorer.Sdk.Helper;

#endregion

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster
{
  public class DoubleRangeCluster : AbstractRangeCluster<double>
  {
    public DoubleRangeCluster(double valueStart, double valueEnd) : base(valueStart, valueEnd)
    {
    }

    public override object CentralValue => _valueStart + (_valueEnd - _valueStart) / 2d;

    public override string Displayname => $"{_valueStart} > {_valueEnd}";

    public override bool Add(Guid documentGuid, object obj)
    {
      try
      {
        var val = obj.SafeCastDouble();
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