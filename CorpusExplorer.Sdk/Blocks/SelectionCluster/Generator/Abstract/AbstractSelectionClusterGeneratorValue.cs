using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract;
using CorpusExplorer.Sdk.Model;

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator.Abstract
{
  public abstract class AbstractSelectionClusterGeneratorValue : AbstractSelectionClusterGenerator
  {
    public override AbstractCluster[] AutoGenerate(Selection selection)
    {
      var res = new Dictionary<string, AbstractCluster>();
      foreach (var doc in selection.DocumentMetadata)
        try
        {
          if (doc.Value == null)
            continue;

          var val = doc.Value.ContainsKey(MetadataKey) ? doc.Value[MetadataKey] : null;
          var key = GenerateKey(val);

          if (!res.ContainsKey(key))
            res.Add(key, NewCluster(val));
        }
        catch
        {
          // ignore
        }

      return res.Select(x => x.Value).ToArray();
    }

    protected abstract string GenerateKey(object value);

    protected abstract AbstractCluster NewCluster(object value);
  }
}