using CorpusExplorer.Sdk.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpusExplorer.Sdk.Extern.Xml.Ids.Helper
{
  public static class ExportPackageHelper
  {
    public static Dictionary<string, HashSet<Guid>> MakePackages(IHydra hydra)
    {
      var res = new Dictionary<string, HashSet<Guid>>();

      foreach (var d in hydra.DocumentMetadata)
      {
        var key = d.Value.ContainsKey("Datum") && d.Value["Datum"] is DateTime dt
                    ? $"CE{dt.Year}"
                    : "CEXXXX";
        if (res.ContainsKey(key))
          res[key].Add(d.Key);
        else
          res.Add(key, new HashSet<Guid> { d.Key });
      }

      return res;
    }
  }
}
