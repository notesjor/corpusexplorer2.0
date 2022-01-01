#region

using System;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster
{
  public class DateTimeYearOnlyCluster : AbstractCluster
  {
    private readonly DateTime _central;
    private readonly int _value;

    public DateTimeYearOnlyCluster(DateTime value)
    {
      _value = value.Year;
      _central = value;
    }

    public override object CentralValue => _central;

    public override string Displayname => $"{_value:0000}";

    public override bool Add(Guid documentGuid, object obj)
    {
      try
      {
        var test = (DateTime)obj;
        if (_value != test.Year)
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