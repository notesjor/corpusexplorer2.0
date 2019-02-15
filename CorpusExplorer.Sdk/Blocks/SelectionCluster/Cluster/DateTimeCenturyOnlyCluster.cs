using System;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract;

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster
{
  public class DateTimeCenturyOnlyCluster : AbstractCluster
  {
    private readonly DateTime _central;
    private readonly int _max;
    private readonly int _min;
    private readonly int _value;

    public DateTimeCenturyOnlyCluster(DateTime value)
    {
      _value = int.Parse(value.Year.ToString("D4").Substring(0, 2));
      _min = _value * 100;
      _max = _min + 99;
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