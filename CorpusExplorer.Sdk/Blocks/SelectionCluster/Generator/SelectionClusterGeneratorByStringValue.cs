using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator.Abstract;

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator
{
  public class SelectionClusterGeneratorByStringValue : AbstractSelectionClusterGenerator
  {
    protected override AbstractCluster[] AutoGenerate(Dictionary<Guid, object> metadataDictionary)
    {
      var res = new Dictionary<string, AbstractCluster>();
      foreach (var x in metadataDictionary)
        try
        {
          if (x.Value == null)
            continue;

          var key = x.Value.ToString();

          if (!res.ContainsKey(key))
            res.Add(key, new StringCluster(key));
        }
        catch
        {
          // ignore
        }

      return res.Select(x => x.Value).ToArray();
    }
  }
}