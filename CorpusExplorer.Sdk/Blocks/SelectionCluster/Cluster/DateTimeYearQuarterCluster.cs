#region

using System;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract;
using CorpusExplorer.Sdk.Helper;

#endregion

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster
{
  public class DateTimeYearQuarterCluster : AbstractDateTimeCluster
  {
    private readonly DateTime _central;
    private readonly int _quarter;
    private readonly int _year;

    public DateTimeYearQuarterCluster(DateTime value)
    {
      _year = value.Year;
      _quarter = DateTimeHelper.GetYearQuarter(value);
      _central = value;
    }

    public override object CentralValue => _central;

    public override string Displayname => $"{_year:D4}-Q{_quarter:D1}";

    public override bool Add(Guid documentGuid, DateTime test)
    {
      try
      {
        if (test.Year != _year || _quarter != DateTimeHelper.GetYearQuarter(test))
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