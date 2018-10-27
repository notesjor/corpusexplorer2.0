using System;
using System.Collections.Generic;
using CorpusExplorer.Sdk.ViewModel;
using CorpusExplorer.Terminal.WinForm.Forms.Map;
using CorpusExplorer.Terminal.WinForm.Helper.UiFramework;

namespace CorpusExplorer.Terminal.WinForm.View.Special
{
  public partial class FrequencyMap : AbstractView
  {
    private string[][] _data;
    private Dictionary<string, double> _frequency;
    private Frequency1LayerViewModel _vm;

    public FrequencyMap()
    {
      InitializeComponent();
    }

    private void btn_mapNormal_Click(object sender, EventArgs e)
    {
      mapSwitch1.ShowVectorMap();
    }

    private void btn_mapNormalized_Click(object sender, EventArgs e)
    {
      mapSwitch1.ShowTileMap();
    }

    private void btn_showGrid_Click(object sender, EventArgs e)
    {
      var form = new MapConfiguration(_data);
      form.ShowDialog();

      _data = form.Data;
      if (_data == null)
        return;

      _vm = GetViewModel<Frequency1LayerViewModel>();
      _vm.LayerDisplayname = "Wort";
      _vm.Execute();

      _frequency = new Dictionary<string, double>();
      for (var i = 1; i < _data.Length; i++)
      {
        var key = _data[i][0];
        if (string.IsNullOrEmpty(key))
          continue;

        if (_frequency.ContainsKey(key))
          continue;

        var clone = new HashSet<string>();
        var sum = 0.0d;
        for (var j = 1; j < _data[i].Length; j++)
        {
          if (clone.Contains(_data[i][j]))
            continue;
          sum += _vm.Frequency.ContainsKey(_data[i][j]) ? _vm.Frequency[_data[i][j]] : 0;
          clone.Add(_data[i][j]);
        }

        _frequency.Add(key, sum);
      }

      mapSwitch1.SetData(_frequency);
    }
  }
}