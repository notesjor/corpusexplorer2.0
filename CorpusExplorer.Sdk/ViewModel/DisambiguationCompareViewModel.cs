using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Blocks.Disambiguation;
using CorpusExplorer.Sdk.Blocks.Similarity;
using CorpusExplorer.Sdk.Blocks.Similarity.Abstract;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Properties;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class DisambiguationCompareViewModel : AbstractCompareViewModel, IUseSpecificLayer, IProvideDataTable
  {
    private DataTable _dataTable;
    private string _layerQuery;

    private string _selectedLayerDisplayname;

    public DisambiguationCompareViewModel()
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

    /// <summary>
    ///   Gets or sets the similarity index.
    /// </summary>
    public AbstractDistance SimilarityIndex { get; set; }

    /// <summary>
    ///   Gibt eine Datentabelle zur�ck
    /// </summary>
    /// <returns>Datentabelle</returns>
    public DataTable GetDataTable()
    {
      return _dataTable;
    }

    public IEnumerable<string> LayerDisplaynames => Selection.LayerUniqueDisplaynames;

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

    protected override void ExecuteAnalyse()
    {
      var blockA = Selection.CreateBlock<DisambiguationBlock>();
      blockA.LayerDisplayname = LayerDisplayname;
      blockA.LayerQuery = LayerQuery;
      blockA.MinimumSignificance = MinimumSignificance;
      blockA.SimilarityIndex = SimilarityIndex;
      blockA.Calculate();

      var blockB = SelectionToCompare.CreateBlock<DisambiguationBlock>();
      blockB.LayerDisplayname = LayerDisplayname;
      blockB.LayerQuery = LayerQuery;
      blockB.MinimumSignificance = MinimumSignificance;
      blockB.SimilarityIndex = SimilarityIndex;
      blockB.Calculate();

      IEnumerable<IDisambiguationCluster> currentA = new[] {blockA.RootCluster};
      IEnumerable<IDisambiguationCluster> currentB = new[] {blockB.RootCluster};
      if (DataTableLevel < 1)
        DataTableLevel = 1;

      // Rekursives Schleife die solange die Kinder ausliest bist DataTableLevel erreicht ist.
      for (var i = 0; i < DataTableLevel; i++)
      {
        currentA = currentA.SelectMany(c => c.GetClusters());
        currentB = currentB.SelectMany(c => c.GetClusters());
      }

      var dt = new DataTable();
      dt.Columns.Add(Resources.Label, typeof(string));
      dt.Columns.Add(Resources.Wert1, typeof(double));
      dt.Columns.Add(Resources.Wert2, typeof(double));
      dt.Columns.Add(Resources.WertD12, typeof(double));

      var dicA = new Dictionary<string, double>();
      foreach (var a in currentA.Where(a => !dicA.ContainsKey(a.Label)))
        dicA.Add(a.Label, a.Value);
      var dicB = new Dictionary<string, double>();
      foreach (var b in currentB.Where(b => !dicB.ContainsKey(b.Label)))
        dicB.Add(b.Label, b.Value);

      _dataTable = new DataTable();
      GenerateDataTable(dicA.GetNormalizedDictionary(), dicB.GetNormalizedDictionary());
    }

    protected override bool Validate()
    {
      return !string.IsNullOrEmpty(LayerDisplayname) && !string.IsNullOrEmpty(LayerQuery)       &&
             !double.IsNaN(MinimumSignificance)      && !double.IsInfinity(MinimumSignificance) &&
             SimilarityIndex != null;
    }

    private void GenerateDataTable(Dictionary<string, double> a, Dictionary<string, double> b)
    {
      _dataTable.BeginLoadData();

      foreach (var x in a)
        if (b.ContainsKey(x.Key))
        {
          _dataTable.Rows.Add(x.Key, x.Value, b[x.Key], Math.Abs(x.Value - b[x.Key]));
          b.Remove(x.Key);
        }
        else
        {
          _dataTable.Rows.Add(x.Key, x.Value, 0.0d, x.Value);
        }

      foreach (var x in b)
        _dataTable.Rows.Add(x.Key, 0.0d, x.Value, x.Value);

      _dataTable.EndLoadData();
    }
  }
}