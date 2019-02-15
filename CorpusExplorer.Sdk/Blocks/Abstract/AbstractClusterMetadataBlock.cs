using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Blocks.ClusterMetadata;
using CorpusExplorer.Sdk.Blocks.Helper;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator.Abstract;
using CorpusExplorer.Sdk.Blocks.Similarity;
using CorpusExplorer.Sdk.Blocks.Similarity.Abstract;
using CorpusExplorer.Sdk.Model;

namespace CorpusExplorer.Sdk.Blocks.Abstract
{
  [Serializable]
  public abstract class AbstractClusterMetadataBlock<T> : AbstractBlock
  {
    private List<ClusterMetadataItem> _clusters;
    private ClusterMetadataItem _rootCluster;

    /// <summary>
    ///   Gets or sets the layer displayname.
    /// </summary>
    public string LayerDisplayname { get; set; } = "Wort";

    /// <summary>
    ///   Wurzel-Cluster
    /// </summary>
    /// <value>The root cluster.</value>
    public ClusterMetadataItem RootCluster
    {
      get
      {
        if (_rootCluster != null)
          return _rootCluster;

        _rootCluster = CalculateRootCluster();
        return _rootCluster;
      }
    }

    public AbstractSelectionClusterGenerator SelectionClusterGenerator { get; set; } =
      new SelectionClusterGeneratorStringValue();

    /// <summary>
    ///   Gets or sets the similarity index.
    /// </summary>
    public AbstractDistance SimilarityIndex { get; set; } = new EuclideanDistance();

    public string MetadataKey { get; set; } = "Autor";

    private ClusterMetadataItem CalculateRootCluster()
    {
      var cvalues = CalculateDistances();

      // Filtern und Kombinieren
      while (_clusters.Count > 1)
      {
        int k1 = -1, k2 = -1;
        var min = double.MaxValue;

        // Ermittle min.
        for (var i = 0; i < _clusters.Count; i++)
        for (var j = i + 1; j < _clusters.Count; j++)
        {
          var val = cvalues[_clusters[i].Label, _clusters[j].Label];
          if (val >= min)
            continue;

          min = val;
          k1 = i < j ? i : j; // Notwendig, um später korrekt zu löschen
          k2 = i < j ? j : i;
        }

        // Löse alte Werte aus den bestehenden Werten heraus.
        var c1 = _clusters[k1];
        var c2 = _clusters[k2];
        _clusters.RemoveAt(k2); // Löschreihenfolge wichtig
        _clusters.RemoveAt(k1);
        cvalues.Remove(c1.Label);
        cvalues.Remove(c2.Label);

        // Erstelle neuen Wert und füge diesen ein
        var ncluster = JoinCluster(c1, c2, min);
        foreach (var c in _clusters)
          cvalues.Add(
                      c.Label,
                      ncluster.Label,
                      CalculateDistance(SimilarityIndex, (T) c.Data, (T) ncluster.Data));
        _clusters.Add(ncluster); // Einfügen darf erst nach dem Vergleich erfolgen
      }

      var res = _clusters.FirstOrDefault();
      res?.DisposeData();

      return res;
    }

    private DoubleKeyDictionary<double> CalculateDistances()
    {
      var cvalues = new DoubleKeyDictionary<double>();
      // Prefill
      for (var i = 0; i < _clusters.Count; i++)
      for (var j = i + 1; j < _clusters.Count; j++)
        cvalues.Add(
                    _clusters[i].Label,
                    _clusters[j].Label,
                    CalculateDistance(SimilarityIndex, (T) _clusters[i].Data, (T) _clusters[j].Data));
      return cvalues;
    }

    public DataTable GetDataTable()
    {
      var dic = CalculateDistances();
      var keys = dic.Keys;

      var dt = new DataTable();
      dt.Columns.Add($"{MetadataKey} (A)", typeof(string));
      dt.Columns.Add($"{MetadataKey} (B)", typeof(string));
      dt.Columns.Add("value", typeof(double));

      dt.BeginLoadData();
      foreach (var k1 in keys)
      foreach (var k2 in keys)
        if (dic.ContainsKeyCombination(k1, k2))
          dt.Rows.Add(k1, k2, dic[k1, k2]);
      dt.EndLoadData();

      return dt;
    }

    public DataTable GetCrossDataTable()
    {
      var dic = CalculateDistances();
      var keys = dic.Keys;

      var dt = new DataTable();
      dt.Columns.Add("CLUSTER", typeof(string));
      foreach (var k in keys)
        dt.Columns.Add(k, typeof(double));

      dt.BeginLoadData();
      for (var i = 0; i < keys.Length; i++)
      {
        var row = new object[keys.Length + 1];
        row[0] = keys[i];

        for (var j = 0; j < keys.Length; j++)
          if (i == j)
            row[j + 1] = 1;
          else
            row[j + 1] = dic[keys[i], keys[j]];

        dt.Rows.Add(row.ToArray());
      }

      dt.EndLoadData();

      return dt;
    }

    /// <summary>
    ///   Funktion die aufgerufen wird, wenn eine Berechnung durchgeführt werden soll.
    /// </summary>
    public override void Calculate()
    {
      if (string.IsNullOrEmpty(LayerDisplayname))
        return;

      _clusters = CalculateClusterValues();
    }

    private ClusterMetadataItem JoinCluster(ClusterMetadataItem cA, ClusterMetadataItem cB, double similarity)
    {
      return new ClusterMetadataItem(cA, cB, $"({cA.Label}|{cB.Label})", Join((T) cA.Data, (T) cB.Data), similarity);
    }

    protected abstract T Join(T a, T b);

    protected abstract double CalculateDistance(AbstractDistance similarityIndex, T cA, T cB);

    private List<ClusterMetadataItem> CalculateClusterValues()
    {
      var blockGroup = Selection.CreateBlock<SelectionClusterBlock>();
      blockGroup.ClusterGenerator = SelectionClusterGenerator;
      blockGroup.MetadataKey = MetadataKey;
      blockGroup.Calculate();

      var res = new Dictionary<string, T>();
      var loc = new object();

      var clusters = blockGroup.GetTemporarySelectionClusters();
      Parallel.ForEach(clusters, cluster =>
      {
        try
        {
          var values = CalculateValues(cluster);

          lock (loc)
          {
            if (!res.ContainsKey(cluster.Displayname))
              res.Add(cluster.Displayname, values);
          }
        }
        catch
        {
          // ignore
        }
      });

      return res.Select(x => new ClusterMetadataItem(x.Key, x.Value)).ToList();
    }

    protected abstract T CalculateValues(Selection selection);
  }
}