#region

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Blocks.Disambiguation;
using CorpusExplorer.Sdk.Blocks.Similarity;
using CorpusExplorer.Sdk.Blocks.Similarity.Abstract;
using CorpusExplorer.Sdk.Properties;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

#endregion

namespace CorpusExplorer.Sdk.ViewModel
{
  /// <summary>
  ///   The disambugion view model.
  /// </summary>
  public class DisambiguationViewModel : AbstractViewModel, IProvideDataTable
  {
    private DisambiguationBlock _block;
    private string _layerQuery;

    private string _selectedLayerDisplayname;

    public DisambiguationViewModel()
    {
      LayerDisplayname = "Wort";
      DataTableLevel = 1;
      LayerQuery = "";
      MinimumSignificance = 0.8d;
      SimilarityIndex = new DistanceEuclidean();
    }

    public int DataTableLevel { get; set; }

    /// <summary>
    ///   Gets or sets the layer query.
    /// </summary>
    public string LayerQuery
    {
      get => _layerQuery;
      set
      {
        if (string.IsNullOrEmpty(value) ||
            _layerQuery == value)
          return;

        _layerQuery = value;
      }
    }

    /// <summary>
    ///   Gets or sets the minimum significance.
    /// </summary>
    public double MinimumSignificance { get; set; }

    public IDisambiguationCluster RootCluster { get; private set; }

    public IEnumerable<string> RootClusterLabels => RootCluster.LabelItems;

    /// <summary>
    ///   Gets or sets the similarity index.
    /// </summary>
    public AbstractDistance SimilarityIndex { get; set; }

    public string LayerDisplayname
    {
      get => _selectedLayerDisplayname;
      set
      {
        if (string.IsNullOrEmpty(value) ||
            _selectedLayerDisplayname == value)
          return;

        _selectedLayerDisplayname = value;
      }
    }

    /// <summary>
    ///   Gibt eine Datentabelle zur�ck
    /// </summary>
    /// <returns>Datentabelle</returns>
    public DataTable GetDataTable()
    {
      if (RootCluster == null)
        return new DataTable();

      IEnumerable<IDisambiguationCluster> current = new[] { RootCluster };
      if (DataTableLevel < 1)
        DataTableLevel = 1;

      // Rekursives Schleife die solange die Kinder ausliest bist DataTableLevel erreicht ist.
      for (var i = 0; i < DataTableLevel; i++)
        current = current.SelectMany(c => c.GetClusters());

      var dt = new DataTable();
      dt.Columns.Add(Resources.Label, typeof(string));
      dt.Columns.Add(Resources.Wert, typeof(double));

      dt.BeginLoadData();
      foreach (var item in current)
        dt.Rows.Add(item.Label, item.Value);
      dt.EndLoadData();

      return dt;
    }

    public DataTable GetFullDataTable()
    {
      if (RootCluster == null)
        return new DataTable();

      var dic = GetFullDataTableRecursiveCall(RootCluster);

      var dt = new DataTable();
      dt.Columns.Add(Resources.Label, typeof(string));
      dt.Columns.Add(Resources.Wert, typeof(double));

      dt.BeginLoadData();
      foreach (var item in dic)
        dt.Rows.Add(item.Key, item.Value);
      dt.EndLoadData();

      return dt;
    }

    private Dictionary<string, double> GetFullDataTableRecursiveCall(IDisambiguationCluster cluster)
    {
      var res = new Dictionary<string, double>();

      var subC = cluster.GetClusters();

      if (subC == null)
        res.Add(cluster.Label, cluster.Value);
      else
        foreach (var c in subC)
          foreach (var t in GetFullDataTableRecursiveCall(c))
            if (!res.ContainsKey(t.Key))
              res.Add(t.Key, t.Value);

      return res;
    }


    /// <summary>
    ///   The get cluster level.
    /// </summary>
    /// <param name="level">
    ///   The level.
    /// </param>
    /// <returns>
    ///   The IDisambiguationCluster[]
    /// </returns>
    public IDisambiguationCluster[] GetClusterLevel(int level)
    {
      try
      {
        //level--;
        //if (level < 0) level = 0;

        var res = new Queue<IDisambiguationCluster>();
        res.Enqueue(RootCluster);

        var temp = new List<IDisambiguationCluster>();

        for (var i = 0; i < level; i++)
        {
          while (res.Count > 0)
          {
            var item = res.Dequeue();
            var group = item as DisambiguationCluster;

            if (group == null)
            {
              temp.Add(item);
            }
            else
            {
              temp.Add(group.ClusterA);
              temp.Add(group.ClusterB);
            }
          }

          res = new Queue<IDisambiguationCluster>(temp);
          temp.Clear();
        }

        return res.ToArray();
      }
      catch
      {
        return null;
      }
    }

    protected override void ExecuteAnalyse()
    {
      if (_block == null
        ||
          _block.LayerDisplayname != LayerDisplayname
        ||
          Math.Abs(_block.MinimumSignificance - MinimumSignificance) > 0
        ||
          _block.SimilarityIndex != SimilarityIndex)
      {
        _block = Selection.CreateBlock<DisambiguationBlock>();
        _block.LayerDisplayname = LayerDisplayname;
        _block.MinimumSignificance = MinimumSignificance;
        _block.SimilarityIndex = SimilarityIndex;
      }

      _block.LayerQuery = LayerQuery;
      _block.Calculate();

      RootCluster = _block.RootCluster;
    }

    protected override bool Validate()
    {
      return !string.IsNullOrEmpty(LayerDisplayname) && !string.IsNullOrEmpty(LayerQuery) &&
             !double.IsNaN(MinimumSignificance) && !double.IsInfinity(MinimumSignificance) &&
             SimilarityIndex != null;
    }
  }
}