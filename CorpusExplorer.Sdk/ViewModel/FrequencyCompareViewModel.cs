using System;
using System.Collections.Generic;
using System.Data;
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
      Mapper = new ViewModelLayerDisplaynameMapper(this, new[] { nameof(Layer1Displayname), nameof(Layer2Displayname), nameof(Layer3Displayname) });
    }

    public string Layer1Displayname { get; set; } = "POS";

    public string Layer2Displayname { get; set; } = "Lemma";

    public string Layer3Displayname { get; set; } = "Wort";

    /// <summary>
    ///   Gibt eine Datentabelle zurück
    /// </summary>
    /// <returns>Datentabelle</returns>
    public DataTable GetDataTable()
    {
      return _dataTable;
    }

    public ViewModelLayerDisplaynameMapper Mapper { get; set; }

    public string[] LayerDisplaynamesMultiMapper
    {
      get => new[] { Layer1Displayname, Layer2Displayname, Layer3Displayname };
      set
      {
        Layer1Displayname = Layer2Displayname = Layer3Displayname = null;
        Layer1Displayname = value?[0];
        Layer2Displayname = value?[1];
        Layer3Displayname = value?[2];
      }
    }


    protected override void ExecuteAnalyse()
    {
      _dataTable = new DataTable();
      var val = string.IsNullOrEmpty(Layer2Displayname) ? 1 : string.IsNullOrEmpty(Layer3Displayname) ? 2 : 3;
      _dataTable.Columns.Add(Layer1Displayname, typeof(string));
      if (val > 1)
        _dataTable.Columns.Add(Layer2Displayname, typeof(string));
      if (val > 2)
        _dataTable.Columns.Add(Layer3Displayname, typeof(string));

      _dataTable.Columns.Add(Resources.Frequeny1, typeof(double));
      _dataTable.Columns.Add(Resources.Frequeny2, typeof(double));
      _dataTable.Columns.Add(Resources.FrequenyD12, typeof(double));

      switch (val)
      {
        case 1:
          Calculate1Layer(Layer1Displayname);
          break;
        case 2:
          Calculate2Layer(Layer1Displayname, Layer2Displayname);
          break;
        case 3:
          Calculate3Layer(Layer1Displayname, Layer2Displayname, Layer3Displayname);
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