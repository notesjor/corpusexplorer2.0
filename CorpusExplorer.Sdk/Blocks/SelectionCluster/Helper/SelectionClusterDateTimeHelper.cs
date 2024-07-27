using CorpusExplorer.Sdk.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Helper
{
  public static class SelectionClusterDateTimeHelper
  {
    public static DateTime SafeConvert(object value)
    {
      try
      {
        if (value == null)
          return DateTime.MinValue;

        switch (value)
        {
          case DateTime d:
            return d;
          case int i:
            if (i > 0 && i < DateTime.Now.Year)
              return new DateTime(i, 1, 1);
            return DateTime.MinValue;
          case string s:
            if (s.Length == 4 && int.TryParse(s, out var y))
              return new DateTime(y, 1, 1);
            return DateTimeHelper.Parse(s);
        }

        return DateTime.MinValue;
      }
      catch
      {
        return DateTime.MinValue;
      }
    }
  }
}
