using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CorpusExplorer.Sdk.Data.Model.Extensions.Layer
{
  using CorpusExplorer.Sdk.Data.Helper;

  public static class StaticLayerLimmitExtension
  {
    public static List<Layer2> CloneLimmited(this List<Layer2> layers, IEnumerable<string> documents)
    {
      return
        layers.Select(
          layer =>
          Layer2.Create(
            layer.LayerName,
            new ListOptimized<string>(layer.Daten),
            documents.Where(d => layer._dokumente.ContainsKey(d)).ToDictionary(d => d, d => layer._dokumente[d])))
          .ToList();
    }
  }
}
