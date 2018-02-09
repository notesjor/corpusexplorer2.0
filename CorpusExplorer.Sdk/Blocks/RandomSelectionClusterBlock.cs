using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Model;

namespace CorpusExplorer.Sdk.Blocks
{
  public class RandomSelectionClusterBlock : AbstractBlock
  {
    public int ClusterCount { get; set; } = 10;

    public Selection[] Clusters { get; set; }

    /// <summary>
    ///   Funktion die aufgerufen wird, wenn eine Berechnung durchgeführt werden soll.
    /// </summary>
    public override void Calculate()
    {
      if (ClusterCount < 1)
        ClusterCount = 1;
      if (ClusterCount == 1)
        Clusters = new[] {Selection};

      var rnd = Configuration.Random;
      var rd = GenerateRandomGuidList();
      var max = rd.Count / ClusterCount;

      var cluster = new List<List<Guid>>();
      for (var i = 0; i < ClusterCount; i++)
      {
        var temp = new List<Guid>();
        for (var j = 0; j < max; j++)
        {
          var guid = rd[rnd.Next(0, rd.Count)];
          temp.Add(guid);
          rd.Remove(guid);
        }
        cluster.Add(temp);
      }

      // Verteile ggf. restliche Dokumente.
      var idx = 0;
      while (rd.Count > 0)
      {
        var guid = rd[rnd.Next(0, rd.Count)];
        cluster[idx++].Add(guid);
        rd.Remove(guid);
        if (idx >= cluster.Count)
          idx = 0;
      }

      Clusters = cluster.Select(c => Selection.CreateTemporary(c)).ToArray();
    }

    private List<Guid> GenerateRandomGuidList()
    {
      var rnd = Configuration.Random;
      var rd = new List<Guid>();
      var sd = new List<Guid>(Selection.DocumentGuids);

      while (sd.Count > 0)
      {
        var guid = sd[rnd.Next(0, sd.Count)];
        rd.Add(guid);
        sd.Remove(guid);
      }
      return rd;
    }
  }
}