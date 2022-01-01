#region

using System;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract;
using CorpusExplorer.Sdk.Helper;

#endregion

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster
{
  public class DateTimeYearWeekOnlyCluster : AbstractCluster
  {
    private readonly DateTime _central;
    private readonly int _week;
    private readonly int _year;

    public DateTimeYearWeekOnlyCluster(DateTime value)
    {
      _year = value.Year;
      _week = DateTimeHelper.GetYearWeek(value);
      _central = value;
    }

    public override object CentralValue => _central;

    public override string Displayname => $"{_year:D4}-W{_week:D2}";

    public override bool Add(Guid documentGuid, object obj)
    {
      try
      {
        var test = (DateTime)obj;
        if (test.Year != _year || _week != DateTimeHelper.GetYearWeek(test))
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