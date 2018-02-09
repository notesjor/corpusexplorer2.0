using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract;

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator.Abstract
{
  public abstract class AbstractSelectionClusterGeneratorByValue : AbstractSelectionClusterGenerator
  {
    protected override AbstractCluster[] AutoGenerate(Dictionary<Guid, object> metadataDictionary)
    {
      var res = new List<AbstractCluster>();
      foreach (var x in metadataDictionary)
        try
        {
          if (res.Any(y => y.Add(x.Key, x.Value)))
            continue;

          var c = NewCluster(x.Value);
          c.Add(x.Key, x.Value);
          res.Add(c);
        }
        catch
        {
          // ignore
        }

      return res.ToArray();
    }

    protected abstract AbstractCluster NewCluster(object value);
  }
}