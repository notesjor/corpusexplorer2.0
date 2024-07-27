#region

using System;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster
{
  public class DateTimeYearMonthDayHourCluster : AbstractDateTimeCluster
  {
    private readonly DateTime _central;
    private readonly int _valueDay;
    private readonly int _valueHour;
    private readonly int _valueMonth;
    private readonly int _valueYear;

    public DateTimeYearMonthDayHourCluster(DateTime value)
    {
      _valueYear = value.Year;
      _valueMonth = value.Month;
      _valueDay = value.Day;
      _valueHour = value.Hour;
      _central = value;
    }

    public override object CentralValue => _central;

    public override string Displayname => $"{_valueYear:0000}-{_valueMonth:00}-{_valueDay:00} {_valueHour}:00:00";

    public override bool Add(Guid documentGuid, DateTime test)
    {
      try
      {
        if (_valueYear != test.Year || _valueMonth != test.Month || _valueDay != test.Day
         || _valueHour != test.Hour)
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