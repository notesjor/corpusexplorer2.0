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

    public IEnumerable<Selection> GetSelectionClusters() => Cluster.ToSelection(Selection);

    public IEnumerable<Selection> GetTemporarySelectionClusters() => Cluster.ToTemporarySelection(Selection);

    public IEnumerable<KeyValuePair<string, IEnumerable<Guid>>> SelectionClustersWindowed(int window)
    {
      var cluster = Cluster.OrderBy(x => x.CentralValue).ToArray();

      var res = new List<KeyValuePair<string, IEnumerable<Guid>>>();
      for (var i = 0; i < cluster.Length - window + 1; i++)
      {
        var key = new List<string>();
        var values = new HashSet<Guid>();

        for (var j = 0; j < window; j++)
        {
          var c = cluster[i + j];
          key.Add(c.Displayname);
          foreach (var dsel in c.DocumentGuids)
            values.Add(dsel);
        }

        res.Add(new KeyValuePair<string, IEnumerable<Guid>>(string.Join(@" - ", key), values));
      }

      return res;
    }

    public IEnumerable<Selection> GetSelectionClustersWindowed(int window) 
      => SelectionClustersWindowed(window).Select(x => Selection.Create(x.Value, x.Key));

    public IEnumerable<Selection> GetTemporarySelectionClustersWindowed(int window)
      => SelectionClustersWindowed(window).Select(x => Selection.CreateTemporary(x.Value));
  }
}