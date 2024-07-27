#region

using System;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster
{
  public class DateTimeYearMonthDayHourMinuteCluster : AbstractDateTimeCluster
  {
    private readonly DateTime _central;
    private readonly int _valueDay;
    private readonly int _valueHour;
    private readonly int _valueMinute;
    private readonly int _valueMonth;
    private readonly int _valueYear;

    public DateTimeYearMonthDayHourMinuteCluster(DateTime value)
    {
      _valueYear = value.Year;
      _valueMonth = value.Month;
      _valueDay = value.Day;
      _valueHour = value.Hour;
      _valueMinute = value.Minute;
      _central = value;
    }

    public override object CentralValue => _central;

    public override string Displayname
      => _valueYear + "-" + _valueMonth + "-" + _valueDay + "_" + _valueHour + ":" + _valueMinute;

    public override bool Add(Guid documentGuid, DateTime test)
    {
      try
      {
        if (_valueYear != test.Year || _valueMonth != test.Month || _valueDay != test.Day
         || _valueHour != test.Hour || _valueMinute != test.Minute)
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