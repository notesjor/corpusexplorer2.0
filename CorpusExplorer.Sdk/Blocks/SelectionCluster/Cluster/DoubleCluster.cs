using System;
using System.Globalization;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract;
using CorpusExplorer.Sdk.Helper;

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster
{
  public class DoubleCluster : AbstractCluster
  {
    private readonly double _value;

    public DoubleCluster(double value)
    {
      _value = value;
    }

    public override object CentralValue => _value;

    public override string Displayname => _value.ToString(CultureInfo.CurrentCulture);

    public override bool Add(Guid documentGuid, object obj)
    {
      try
      {
        var val = obj.SafeCastDouble();
        if (Math.Abs(_value - val) > 0)
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