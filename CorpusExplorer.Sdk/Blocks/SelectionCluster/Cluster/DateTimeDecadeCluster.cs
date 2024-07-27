#region

using System;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster
{
  public class DateTimeDecadeCluster : AbstractDateTimeCluster
  {
    private readonly DateTime _central;
    private readonly int _max;
    private readonly int _min;
    private readonly int _value;

    public DateTimeDecadeCluster(DateTime value)
    {
      _value = int.Parse(value.Year.ToString("D4").Substring(0, 3));
      _min = _value * 10;
      _max = _min + 9;
      _central = value;
    }

    public override object CentralValue => _central;

    public override string Displayname => _value.ToString();

    public override bool Add(Guid documentGuid, DateTime test)
    {
      try
      {
        if (test.Year < _min || test.Year > _max)
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