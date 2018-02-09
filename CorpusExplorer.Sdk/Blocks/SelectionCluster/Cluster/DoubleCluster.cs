using System;
using System.Globalization;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract;

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster
{
  public class DoubleCluster : AbstractCluster
  {
    private readonly double _value;
    public DoubleCluster(double value) { _value = value; }

    public override object CentralValue => _value;

    public override string Displayname => _value.ToString(CultureInfo.CurrentCulture);

    public override bool Add(Guid documentGuid, object obj)
    {
      try
      {
        var test = (double) obj;
        if (Math.Abs(_value - test) > 0)
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