using System;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract;

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster
{
  public class DateTimeDecadeOnlyCluster : AbstractCluster
  {
    private readonly DateTime _central;
    private readonly int _max;
    private readonly int _min;
    private readonly int _value;

    public DateTimeDecadeOnlyCluster(DateTime value)
    {
      _value = int.Parse(value.Year.ToString("D4").Substring(0, 3));
      _min = _value * 10;
      _max = _min + 9;
      _central = value;
    }

    public override object CentralValue => _central;

    public override string Displayname => _value.ToString();

    public override bool Add(Guid documentGuid, object obj)
    {
      try
      {
        var test = (DateTime) obj;
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