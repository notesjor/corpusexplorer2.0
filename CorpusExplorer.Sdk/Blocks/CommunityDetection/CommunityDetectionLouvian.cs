using CorpusExplorer.Sdk.Blocks.CommunityDetection.Abstract;
using CorpusExplorer.Sdk.Ecosystem.Model;
using System.Collections.Generic;
using System.Linq;

namespace CorpusExplorer.Sdk.Blocks.CommunityDetection
{
  public class CommunityDetectionLouvian : AbstractCommunityDetection
  {
    public override Community[] Calculate(Dictionary<string, Dictionary<string, double>> edges)
    {
      var totalWeight = (edges.SelectMany(x => x.Value).Sum(y => y.Value)) / 2.0;

      var communities = edges.Keys.ToDictionary(node => node, node => node);
      var improvement = true;
      while (improvement)
      {
        improvement = Calculate(ref communities, ref edges, ref totalWeight);
      }

      return communities
        .GroupBy(kv => kv.Value)
        .Select(g => new Community { Name = g.Key, Members = g.Select(x => x.Key).ToArray() })
        .ToArray();
    }

    private bool Calculate(ref Dictionary<string, string> comm, ref Dictionary<string, Dictionary<string, double>> edges, ref double totalWeight)
    {
      var moved = false;
      var nodes = edges.Keys.OrderBy(n => Configuration.Random.Next()).ToList();
      var nodeDegree = edges.ToDictionary(kv => kv.Key, kv => kv.Value.Values.Sum());
      var commWeight = comm.Keys.ToDictionary(
        node => node,
        node => 0.0);
      foreach (var node in edges.Keys)
      {
        commWeight[comm[node]] += nodeDegree[node];
      }

      foreach (var node in nodes)
      {
        var current = comm[node];
        commWeight[current] -= nodeDegree[node];

        var neighWeight = new Dictionary<string, double>();
        foreach (var x in edges[node])
        {
          var c = comm[x.Key];
          neighWeight[c] = (neighWeight.ContainsKey(c) ? neighWeight[c] : 0.0) + x.Value;
        }

        var bestComm = current;
        double bestGain = 0;
        foreach (var x in neighWeight)
        {
          var gain = (x.Value - (nodeDegree[node] * commWeight[x.Key] / (totalWeight * 2))) / (totalWeight * 2);
          if (gain > bestGain)
          {
            bestGain = gain;
            bestComm = x.Key;
          }
        }

        commWeight[current] += nodeDegree[node];
        if (bestComm != current)
        {
          commWeight[current] -= nodeDegree[node];
          commWeight[bestComm] += nodeDegree[node];
          comm[node] = bestComm;
          moved = true;
        }
      }
      return moved;
    }
  }
}
