using System;
using System.Collections.Generic;
using System.Data;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Properties;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class CorpusWeightUnlimmitedCompareViewModel : AbstractCompareViewModel, IProvideDataTable
  {
    private DataTable _dataTable;

    /// <summary>
    ///   Gibt eine Datentabelle zurück
    /// </summary>
    /// <returns>Datentabelle</returns>
    public DataTable GetDataTable()
    {
      return _dataTable;
    }

    protected override void ExecuteAnalyse()
    {
      var blockA = Selection.CreateBlock<DocumentMetadataWeightBlock>();
      blockA.Calculate();
      var dicA = blockA.GetAggregatedRelativeSize();

      var blockB = SelectionToCompare.CreateBlock<DocumentMetadataWeightBlock>();
      blockB.Calculate();
      var dicB = blockB.GetAggregatedRelativeSize();

      _dataTable = new DataTable();
      _dataTable.Columns.Add(Resources.Category, typeof(string));
      _dataTable.Columns.Add(Resources.MetadataLabel, typeof(string));
      _dataTable.Columns.Add(Resources.Token1, typeof(double));
      _dataTable.Columns.Add(Resources.Token2, typeof(double));
      _dataTable.Columns.Add(Resources.TokenD12, typeof(double));
      _dataTable.Columns.Add(Resources.Types1, typeof(double));
      _dataTable.Columns.Add(Resources.Types2, typeof(double));
      _dataTable.Columns.Add(Resources.TypesD12, typeof(double));
      _dataTable.Columns.Add(Resources.Dokumente1, typeof(double));
      _dataTable.Columns.Add(Resources.Dokumente2, typeof(double));
      _dataTable.Columns.Add(Resources.DokumenteD12, typeof(double));

      GenerateDataTable(dicA, dicB);
    }

    private void GenerateDataTable(
      Dictionary<string, Dictionary<string, double[]>> a,
      Dictionary<string, Dictionary<string, double[]>> b)
    {
      _dataTable.BeginLoadData();

      foreach (var x in a)
        if (b.ContainsKey(x.Key))
          foreach (var y in x.Value)
            if (b[x.Key].ContainsKey(y.Key))
            {
              _dataTable.Rows.Add(
                x.Key,
                y.Key,
                y.Value[0],
                b[x.Key][y.Key][0],
                Math.Abs(y.Value[0] - b[x.Key][y.Key][0]),
                y.Value[1],
                b[x.Key][y.Key][1],
                Math.Abs(y.Value[1] - b[x.Key][y.Key][1]),
                y.Value[2],
                b[x.Key][y.Key][2],
                Math.Abs(y.Value[2] - b[x.Key][y.Key][2]));
              b[x.Key].Remove(y.Key);
            }
            else
            {
              _dataTable.Rows.Add(
                x.Key,
                y.Key,
                y.Value[0],
                0.0d,
                y.Value[0],
                y.Value[1],
                0.0d,
                y.Value[1],
                y.Value[2],
                0.0d,
                y.Value[2]);
            }
        else
          foreach (var y in x.Value)
            _dataTable.Rows.Add(
              x.Key,
              y.Key,
              y.Value[0],
              0.0d,
              y.Value[0],
              y.Value[1],
              0.0d,
              y.Value[1],
              y.Value[2],
              0.0d,
              y.Value[2]);

      foreach (var x in b)
      foreach (var y in x.Value)
        _dataTable.Rows.Add(
          x.Key,
          y.Key,
          0.0d,
          y.Value[0],
          y.Value[0],
          0.0d,
          y.Value[1],
          y.Value[1],
          0.0d,
          y.Value[2],
          y.Value[2]);

      _dataTable.EndLoadData();
    }
  }
}