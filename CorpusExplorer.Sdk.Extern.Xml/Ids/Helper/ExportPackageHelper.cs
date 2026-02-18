using CorpusExplorer.Sdk.Model.Interface;
using System;
using System.Collections.Generic;

namespace CorpusExplorer.Sdk.Extern.Xml.Ids.Helper
{
  public static class ExportPackageHelper
  {
    public static Dictionary<string, HashSet<Guid>> MakePackages(string prefix, IHydra hydra)
    {
      var res = new Dictionary<string, HashSet<Guid>>();

      if (GetStrategy(hydra)) // if you have a date property (CE2025, CE1981)
      {
        foreach (var d in hydra.DocumentMetadata)
        {
          var key = d.Value.ContainsKey("Datum") && d.Value["Datum"] is DateTime dt && dt.Year > 0001
            ? $"{prefix}_{dt.Year}"
            : $"{prefix}_XXXX";
          if (res.ContainsKey(key))
            res[key].Add(d.Key);
          else
            res.Add(key, new HashSet<Guid> { d.Key });
        }
      }
      else // if you have no date property (CE0001, CE0002, ....)
      {
        var cnt = 0;
        var idx = 0;

        foreach (var d in hydra.DocumentMetadata)
        {
          if (cnt % 1000 == 0)
          {
            idx++;
            cnt = 0;
          }
          var key = $"{prefix}_{idx:D4}";
          if (res.ContainsKey(key))
            res[key].Add(d.Key);
          else
            res.Add(key, new HashSet<Guid> { d.Key });
          cnt++;
        }
      }

      return res;
    }

    private static bool GetStrategy(IHydra hydra)
    {
      try
      {
        var test = new HashSet<string>(hydra.GetDocumentMetadataPrototypeOnlyProperties());
        return test.Contains("Datum");
      }
      catch
      {
        return false;
      }
    }
  }
}
