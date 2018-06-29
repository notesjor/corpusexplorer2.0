using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Helper;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator.Abstract;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Model;

namespace CorpusExplorer.Sdk.Blocks
{
  public class SelectionClusterBlock : AbstractBlock
  {
    public AbstractCluster[] Cluster { get; set; }

    public AbstractSelectionClusterGenerator ClusterGenerator { get; set; }

    public string MetadataKey { get; set; }

    public IEnumerable<KeyValuePair<string, IEnumerable<Guid>>> SelectionClusters
    {
      get
      {
        return
          Cluster.Select(
            cluster => new KeyValuePair<string, IEnumerable<Guid>>(cluster.Displayname, cluster.DocumentGuids));
      }
    }

    /// <summary>
    ///   Funktion die aufgerufen wird, wenn eine Berechnung durchgeführt werden soll.
    /// </summary>
    public override void Calculate()
    {
      if (ClusterGenerator == null)
        return;

      ClusterGenerator.MetadataKey = MetadataKey;
      Cluster = ClusterGenerator.AutoGenerate(Selection);
      var meta = ClusterGenerator.GetDocumentGuids(Selection);

      Parallel.ForEach(meta, Configuration.ParallelOptions, x =>
      {
        try
        {
          // Sollte am besten NICHT parallel ausgeführt werden!
          // Da ansonsten die Reihenfolge nicht gewährlesitet werden kann.
          // ReSharper disable once LoopCanBeConvertedToQuery
          foreach (var c in Cluster)
            if (c.Add(x.Key, x.Value == null || !x.Value.ContainsKey(MetadataKey) ? null : x.Value[MetadataKey]))
              return;
        }
        catch
        {
          // ignore
        }
      });
    }

    public IEnumerable<Selection> GetSelectionClusters()
    {
      return Cluster.ToSelection(Selection);
    }
  }
}