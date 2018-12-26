using System;
using CorpusExplorer.Sdk.Helper;

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator
{
  public class SelectionClusterGeneratorRobustDateTimeValue : SelectionClusterGeneratorDateTimeValue
  {
    protected override object PreFixClusterValue(object value)
    {
      if (value == null)
        return null;

      switch (value)
      {
        case DateTime d:
          return d;
        case int i:
          if (i > 0 && i < DateTime.Now.Year)
            return new DateTime(i, 1, 1);
          return i;
        case string s:
          return DateTimeHelper.Parse(s);
      }

      return null;
    }
  }
}