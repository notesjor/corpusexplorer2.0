using System;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract;

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster
{
  public class DateTimeYearMonthDayOnlyCluster : AbstractCluster
  {
    private readonly int _valueDay;
    private readonly int _valueMonth;
    private readonly int _valueYear;

    public DateTimeYearMonthDayOnlyCluster(DateTime value)
    {
      _valueYear = value.Year;
      _valueMonth = value.Month;
      _valueDay = value.Day;
    }

    public override object CentralValue => _valueYear;

    public override string Displayname => $"{_valueYear:0000}-{_valueMonth:00}-{_valueDay:00}";

    public override bool Add(Guid documentGuid, object obj)
    {
      try
      {
        var test = (DateTime) obj;
        if (_valueYear != test.Year || _valueMonth != test.Month || _valueDay != test.Day)
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