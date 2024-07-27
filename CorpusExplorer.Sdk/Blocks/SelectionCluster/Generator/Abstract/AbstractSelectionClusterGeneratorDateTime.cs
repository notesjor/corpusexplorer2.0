using CorpusExplorer.Sdk.Blocks.SelectionCluster.Helper;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator.Abstract;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator.Abstract
{
  public abstract class AbstractSelectionClusterGeneratorDateTime : AbstractSelectionClusterGenerator
  {
    public override AbstractCluster[] AutoGenerate(Selection selection)
    {
      var res = new Dictionary<string, AbstractCluster>();
      foreach (var doc in selection.DocumentMetadata)
        try
        {
          if (doc.Value == null)
            continue;

          var val = SelectionClusterDateTimeHelper.SafeConvert(doc.Value.ContainsKey(MetadataKey) ? doc.Value[MetadataKey] : null);
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

    /// <summary>
    ///   Erzeugt aus einem Cluster-Wert einen eindeutigen Schlüssel
    /// </summary>
    /// <param name="value">ClusterWert</param>
    /// <returns></returns>
    protected abstract string GenerateKey(DateTime value);

    /// <summary>
    ///   Erzeugt ein neues Cluster
    /// </summary>
    /// <param name="value">Cluster-Wert</param>
    /// <returns>Cluster</returns>
    protected abstract AbstractCluster NewCluster(DateTime value);
  }
}
