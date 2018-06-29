#region

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CorpusExplorer.Terminal.WinForm.Controls.Wpf.HeatMap.Model;
using Telerik.Windows.Controls.TreeMap;

#endregion

namespace CorpusExplorer.Terminal.WinForm.Controls.Wpf.HeatMap
{
  /// <summary>
  ///   Interaktionslogik für HeatMapView.xaml
  /// </summary>
  public partial class HeatMapView
  {
    private int _maxGrp = 10000;
    private int _maxItm = 10000;
    private int _minGrp;
    private int _minItm;

    /// <summary>
    ///   Initializes a new instance of the <see cref="HeatMapView" /> class.
    /// </summary>
    public HeatMapView()
    {
      InitializeComponent();
    }

    public DataTable DataSource
    {
      set
      {
        var res = new Dictionary<string, HeatmapGroup>();
        var val = 0;
        _minItm = int.MaxValue;
        _maxItm = int.MinValue;
        _minGrp = int.MaxValue;
        _maxGrp = int.MinValue;

        foreach (DataRow row in value.Rows)
        {
          var isGrp = false;
          string key;
          switch (row.ItemArray.Length)
          {
            case 2:
              key = row.ItemArray[0].ToString();
              val = (int) row.ItemArray[1];
              if (res.ContainsKey(key))
              {
                res[key].Children.Add(new HeatmapItem(key, val));
              }
              else
              {
                res.Add(key, new HeatmapGroup(key, new[] {new HeatmapItem(key, val)}));
                isGrp = true;
              }

              break;
            case 3:
              key = row.ItemArray[0].ToString();
              val = (int) row.ItemArray[2];
              if (res.ContainsKey(key))
              {
                res[key].Children.Add(new HeatmapItem(row.ItemArray[1].ToString(), val));
              }
              else
              {
                res.Add(key, new HeatmapGroup(key, new[] {new HeatmapItem(row.ItemArray[1].ToString(), val)}));
                isGrp = true;
              }

              break;
            case 5:
              key = row.ItemArray[0].ToString();
              val = (int) row.ItemArray[2];
              if (res.ContainsKey(key))
              {
                res[key].Children.Add(new HeatmapItem(row.ItemArray[1].ToString(), val));
              }
              else
              {
                res.Add(key, new HeatmapGroup(key, new[] {new HeatmapItem(row.ItemArray[1].ToString(), val)}));
                isGrp = true;
              }

              break;
          }

          if (isGrp)
          {
            if (val > _maxGrp) _maxGrp = val;
            if (val < _minGrp) _minGrp = val;
          }
          else
          {
            if (val > _maxItm) _maxItm = val;
            if (val < _minItm) _minItm = val;
          }
        }

        treeMap1.LayoutStrategy = new SquarifiedStrategy();
        treeMap1.ItemsSource = res.Select(x => x.Value);
        RefreshColor();
      }
    }

    private void Colors_OnColorsChanged(object sender, EventArgs e)
    {
      RefreshColor();
    }

    private void RefreshColor()
    {
      ColorGroup.Mappings.Clear();
      ColorGroup.Mappings.Add(colors.GetValueGradientColorizer(_minGrp, _maxGrp));
      ColorItem.Mappings.Clear();
      ColorItem.Mappings.Add(colors.GetValueGradientColorizer(_minGrp, _maxGrp));
    }
  }
}