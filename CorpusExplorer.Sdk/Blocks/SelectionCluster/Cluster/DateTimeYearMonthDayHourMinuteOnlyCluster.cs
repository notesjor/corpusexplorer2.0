using System;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract;

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster
{
  public class DateTimeYearMonthDayHourMinuteOnlyCluster : AbstractCluster
  {
    private readonly int _valueDay;
    private readonly int _valueHour;
    private readonly int _valueMinute;
    private readonly int _valueMonth;
    private readonly int _valueYear;

    public DateTimeYearMonthDayHourMinuteOnlyCluster(DateTime value)
    {
      _valueYear = value.Year;
      _valueMonth = value.Month;
      _valueDay = value.Day;
      _valueHour = value.Hour;
      _valueMinute = value.Minute;
    }

    public override object CentralValue => _valueYear;

    public override string Displayname
      => _valueYear + "-" + _valueMonth + "-" + _valueDay + "_" + _valueHour + ":" + _valueMinute;

    public override bool Add(Guid documentGuid, object obj)
    {
      try
      {
        var test = (DateTime) obj;
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