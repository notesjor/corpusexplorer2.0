using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Properties;

#region

using System.Collections.Generic;
using System.Data;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

#endregion

namespace CorpusExplorer.Sdk.ViewModel
{
  /// <summary>
  ///   The corpus weight view model.
  /// </summary>
  public class CorpusWeightLimmitedViewModel : AbstractViewModel, IProvideDataTable
  {
    /// <summary>
    ///   Erzeugt ein neues CorpusWeightLimmitedViewModel.
    /// </summary>
    public CorpusWeightLimmitedViewModel()
    {
      CategroyA = Resources.Newspaper;
      CategroyB = "Autor";
      DataTableMaximumRows = 100;
    }

    public string CategroyA { get; set; }
    public string CategroyB { get; set; }
    public Dictionary<string, Dictionary<string, int[]>> CorpusWeights { get; set; }
    public int DataTableMaximumRows { get; set; }

    /// <summary>
    ///   Gets the data table.
    /// </summary>
    public DataTable GetDataTable()
    {
      var res = new DataTable();
      res.Columns.Add(Resources.Category, typeof(string));
      res.Columns.Add(Resources.MetadataLabel, typeof(string));
      res.Columns.Add(Resources.Token, typeof(int));
      res.Columns.Add(Resources.Types, typeof(int));
      res.Columns.Add(Resources.Documents, typeof(int));

      if (CorpusWeights == null)
        return res;

      res.BeginLoadData();
      foreach (var e1 in CorpusWeights)
      foreach (var e2 in e1.Value)
        res.Rows.Add(e1.Key, e2.Key, e2.Value[0], e2.Value[1], e2.Value[2]);
      res.EndLoadData();

      return res.OnlyTheBiggestRows(Resources.Token, DataTableMaximumRows);
    }

    protected override void ExecuteAnalyse()
    {
      var block = Selection.CreateBlock<DocumentMetadataWeightBlock>();
      block.Calculate();
      CorpusWeights = block.GetAggregatedSize(CategroyA, CategroyB);
    }

    protected override bool Validate()
    {
      return !string.IsNullOrEmpty(CategroyA) && !string.IsNullOrEmpty(CategroyB) && CategroyA != CategroyB;
    }
  }
}