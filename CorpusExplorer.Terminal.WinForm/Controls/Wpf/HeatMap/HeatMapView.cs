#region

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
    /// <summary>
    ///   Initializes a new instance of the <see cref="HeatMapView" /> class.
    /// </summary>
    public HeatMapView() { InitializeComponent(); }

    /*
    public Dictionary<string, Dictionary<string, int>> DataSource
    {
      set
      {
        var temp = value.Select(g => new HeatmapGroup(g.Key, g.Value.Select(e => new HeatmapItem(e.Key, e.Value))));
        treeMap1.ItemsSource = temp;
      }
    }
    */

    public DataTable DataSource
    {
      set
      {
        var res = new Dictionary<string, HeatmapGroup>();
        var max = 0;
        var min = int.MaxValue;
        var val = 0;

        foreach (DataRow row in value.Rows)
        {
          string key;
          switch (row.ItemArray.Length)
          {
            case 2:
              key = row.ItemArray[0].ToString();
              val = (int) row.ItemArray[1];
              if (res.ContainsKey(key))
                res[key].Children.Add(new HeatmapItem(key, val));
              else
                res.Add(key, new HeatmapGroup(key, new[] {new HeatmapItem(key, val)}));
              break;
            case 3:
              key = row.ItemArray[0].ToString();
              val = (int) row.ItemArray[2];
              if (res.ContainsKey(key))
                res[key].Children.Add(new HeatmapItem(row.ItemArray[1].ToString(), val));
              else
                res.Add(key, new HeatmapGroup(key, new[] {new HeatmapItem(row.ItemArray[1].ToString(), val)}));
              break;
            case 5:
              key = row.ItemArray[0].ToString();
              val = (int) row.ItemArray[2];
              if (res.ContainsKey(key))
                res[key].Children.Add(new HeatmapItem(row.ItemArray[1].ToString(), val));
              else
                res.Add(key, new HeatmapGroup(key, new[] {new HeatmapItem(row.ItemArray[1].ToString(), val)}));
              break;
          }

          if (val > max)
            max = val;
          if (val < min)
            min = val;
        }

        treeMap1.LayoutStrategy = new SquarifiedStrategy();
        Colorizer1.RangeMinimum = min;
        Colorizer1.RangeMaximum = max;
        Colorizer2.RangeMinimum = min;
        Colorizer2.RangeMaximum = max;

        treeMap1.ItemsSource = res.Select(x => x.Value);
      }
    }
  }
}