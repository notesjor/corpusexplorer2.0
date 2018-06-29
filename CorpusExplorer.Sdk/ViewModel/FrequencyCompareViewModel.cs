using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Properties;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class FrequencyCompareViewModel : AbstractCompareViewModel, IProvideDataTable
  {
    private DataTable _dataTable;

    public FrequencyCompareViewModel()
    {
      LayerDisplaynames = new List<string>
      {
        "POS",
        "Lemma",
        "Wort"
      };
    }

    public IEnumerable<string> LayerDisplaynames { get; set; }

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
      _dataTable = new DataTable();
      foreach (var mapping in LayerDisplaynames)
        _dataTable.Columns.Add(mapping, typeof(string));
      _dataTable.Columns.Add(Resources.Frequeny1, typeof(double));
      _dataTable.Columns.Add(Resources.Frequeny2, typeof(double));
      _dataTable.Columns.Add(Resources.FrequenyD12, typeof(double));

      var layers = LayerDisplaynames.ToArray();
      switch (LayerDisplaynames.Count())
      {
        case 1:
          Calculate1Layer(layers.FirstOrDefault());
          break;
        case 2:
          Calculate2Layer(layers[0], layers[1]);
          break;
        case 3:
          Calculate3Layer(layers[0], layers[1], layers[2]);
          break;
      }
    }

    protected override bool Validate()
    {
      return true;
    }

    private void Calculate1Layer(string layer)
    {
      var blockA = Selection.CreateBlock<Frequency1LayerBlock>();
      blockA.LayerDisplayname = layer;
      blockA.Calculate();

      var blockB = SelectionToCompare.CreateBlock<Frequency1LayerBlock>();
      blockB.LayerDisplayname = layer;
      blockB.Calculate();

      GenerateDataTable(blockA.Frequency.GetNormalizedDictionary(), blockB.Frequency.GetNormalizedDictionary());
    }

    private void Calculate2Layer(string layer1, string layer2)
    {
      var blockA = Selection.CreateBlock<Frequency2LayerBlock>();
      blockA.Layer1Displayname = layer1;
      blockA.Layer2Displayname = layer2;
      blockA.Calculate();

      var blockB = SelectionToCompare.CreateBlock<Frequency2LayerBlock>();
      blockB.Layer1Displayname = layer1;
      blockB.Layer2Displayname = layer2;
      blockB.Calculate();

      GenerateDataTable(blockA.Frequency.GetNormalizedDictionary(), blockB.Frequency.GetNormalizedDictionary());
    }

    private void Calculate3Layer(string layer1, string layer2, string layer3)
    {
      var blockA = Selection.CreateBlock<Frequency3LayerBlock>();
      blockA.Layer1Displayname = layer1;
      blockA.Layer2Displayname = layer2;
      blockA.Layer3Displayname = layer3;
      blockA.Calculate();

      var blockB = SelectionToCompare.CreateBlock<Frequency3LayerBlock>();
      blockB.Layer1Displayname = layer1;
      blockB.Layer2Displayname = layer2;
      blockA.Layer3Displayname = layer3;
      blockB.Calculate();

      GenerateDataTable(blockA.Frequency.GetNormalizedDictionary(), blockB.Frequency.GetNormalizedDictionary());
    }

    private void GenerateDataTable(
      Dictionary<string, Dictionary<string, Dictionary<string, double>>> a,
      Dictionary<string, Dictionary<string, Dictionary<string, double>>> b)
    {
      _dataTable.BeginLoadData();
      foreach (var x in a)
        if (b.ContainsKey(x.Key))
          foreach (var y in x.Value)
            if (b[x.Key].ContainsKey(y.Key))
              foreach (var z in y.Value)
                if (b[x.Key][y.Key].ContainsKey(z.Key))
                {
                  _dataTable.Rows.Add(
                    x.Key,
                    y.Key,
                    z.Key,
                    z.Value,
                    b[x.Key][y.Key][z.Key],
                    Math.Abs(z.Value - b[x.Key][y.Key][z.Key]));
                  b[x.Key][y.Key].Remove(z.Key);
                }
                else
                {
                  _dataTable.Rows.Add(x.Key, y.Key, z.Key, z.Value, 0.0d, z.Value);
                }
            else
              foreach (var z in y.Value)
                _dataTable.Rows.Add(x.Key, y.Key, z.Key, z.Value, 0.0d, z.Value);
        else
          foreach (var y in x.Value)
          foreach (var z in y.Value)
            _dataTable.Rows.Add(x.Key, y.Key, z.Key, z.Value, 0.0d, z.Value);

      foreach (var x in b)
      foreach (var y in x.Value)
      foreach (var z in y.Value)
        _dataTable.Rows.Add(x.Key, y.Key, z.Key, 0.0d, z.Value, z.Value);

      _dataTable.EndLoadData();
    }

    private void GenerateDataTable(
      Dictionary<string, Dictionary<string, double>> a,
      Dictionary<string, Dictionary<string, double>> b)
    {
      _dataTable.BeginLoadData();
      foreach (var x in a)
        if (b.ContainsKey(x.Key))
          foreach (var y in x.Value)
            if (b[x.Key].ContainsKey(y.Key))
            {
              _dataTable.Rows.Add(x.Key, y.Key, y.Value, b[x.Key][y.Key], Math.Abs(y.Value - b[x.Key][y.Key]));
              b[x.Key].Remove(y.Key);
            }
            else
            {
              _dataTable.Rows.Add(x.Key, y.Key, y.Value, 0.0d, y.Value);
            }
        else
          foreach (var y in x.Value)
            _dataTable.Rows.Add(x.Key, y.Key, y.Value, 0.0d, y.Value);

      foreach (var x in b)
      foreach (var y in x.Value)
        _dataTable.Rows.Add(x.Key, y.Key, 0.0d, y.Value, y.Value);
      _dataTable.EndLoadData();
    }

    private void GenerateDataTable(
      Dictionary<string, double> a,
      Dictionary<string, double> b)
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