#region

using System;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster
{
  public class DateTimeYearMonthOnlyCluster : AbstractCluster
  {
    private readonly DateTime _central;
    private readonly int _valueMonth;
    private readonly int _valueYear;

    public DateTimeYearMonthOnlyCluster(DateTime value)
    {
      _valueYear = value.Year;
      _valueMonth = value.Month;
      _central = value;
    }

    public override object CentralValue => _central;

    public override string Displayname => $"{_valueYear:0000}-{_valueMonth:00}";

    public override bool Add(Guid documentGuid, object obj)
    {
      try
      {
        var test = (DateTime)obj;
        if (_valueYear != test.Year || _valueMonth != test.Month)
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