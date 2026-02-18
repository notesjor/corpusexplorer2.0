using CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator.Abstract;
using CorpusExplorer.Sdk.ViewModel;
using CorpusExplorer.Terminal.WinForm.Helper;
using CorpusExplorer.Terminal.WinForm.Helper.UiFramework;
using CorpusExplorer.Terminal.WinForm.Properties;
using System;
using System.Linq;
using Telerik.Charting;
using Telerik.WinControls.UI;

namespace CorpusExplorer.Terminal.WinForm.View.Frequency
{
  public partial class FrequencyOverTime : AbstractView
  {
    private readonly ChartSelectionController _selection = new ChartSelectionController();

    private readonly ChartPanZoomController _zoom = new ChartPanZoomController
    {
      PanZoomMode =
        ChartPanZoomMode.Horizontal
    };

    private ClusterEasyGenericViewModel _vm;

    public FrequencyOverTime()
    {
      InitializeComponent();
      drop_cluster.Items.Add(new RadListDataItem("Jahr/Monat/Tag", new SelectionClusterGeneratorDateTimeYearMonthDay()));
      drop_cluster.Items.Add(new RadListDataItem("Jahr/Woche", new SelectionClusterGeneratorDateTimeYearWeek()));
      drop_cluster.Items.Add(new RadListDataItem("Jahr/Monat", new SelectionClusterGeneratorDateTimeYearMonth()));
      drop_cluster.Items.Add(new RadListDataItem("Jahr/Quartal", new SelectionClusterGeneratorDateTimeYearQuarter()));
      drop_cluster.Items.Add(new RadListDataItem("Jahr", new SelectionClusterGeneratorDateTimeYear()));
      drop_cluster.Items.Add(new RadListDataItem("Jahrzehnt", new SelectionClusterGeneratorDateTimeDecade()));
      drop_cluster.SelectedIndex = 0;
      chart_view.ShowPanZoom = true;
      ShowView += FrequencyOverTimeView_ShowView;
    }

    public double MaximalValue { get; set; }

    private void btn_export_Click(object sender, EventArgs e)
    {
      DataTableExporter.Export(_vm.GetDataTable());
    }

    private void wordBag1_ExecuteButtonClicked(object sender, EventArgs e)
    {
      var meta = commandBarDropDownList1.SelectedItem.Value as string;
      _vm.ClusterGenerator = drop_cluster.SelectedItem.Value as AbstractSelectionClusterGenerator;
      _vm.MetadataKey = meta;
      _vm.ChildViewModel = new Frequency1LayerSelectViewModel { LayerQueries = wordBag1.ResultQueries, LayerDisplayname = wordBag1.ResultSelectedLayerDisplayname };
      _vm.Execute();

      chart_view.Series.Clear();
      chart_view.Axes.Clear();
      chart_view.Controllers.Clear();

      _zoom.PanZoomMode = ChartPanZoomMode.Horizontal;
      chart_view.Controllers.Add(_zoom);
      chart_view.Controllers.Add(_selection);

      MaximalValue = 0.0d; // wird durch die folgende Zeile ermittelt
      foreach (var query in wordBag1.ResultQueries)
        chart_view.Series.Add(BuildSeries(query));

      foreach (var x in chart_view.Axes.OfType<LinearAxis>())
        x.Maximum = MaximalValue;

      chart_view.ShowPanZoom = true;
      chart_view.ShowLegend = true;
      chart_view.ShowToolTip = true;
      chart_view.ShowTrackBall = true;

      var categoricalAxis = chart_view.Axes[0] as CategoricalAxis;
      if (categoricalAxis == null)
        return;
      categoricalAxis.PlotMode = AxisPlotMode.OnTicksPadded;
      categoricalAxis.LabelFitMode = AxisLabelFitMode.Rotate;
      categoricalAxis.LabelRotationAngle = 310;
    }

    private LineSeries BuildSeries(string query)
    {
      var res = new LineSeries { LegendTitle = query };

      var points = _vm.ClusterNames;

      foreach (var point in points.OrderBy(x => x))
      {
        var data = _vm.ClusterTables[point];
        if (data.Rows.Count == 0)
          continue;
        var value = (double)data.Rows.Cast<System.Data.DataRow>()?
          .FirstOrDefault(r => r[wordBag1.ResultSelectedLayerDisplayname]?.ToString() == query)?[Resources.Frequency_Relativ];

        if (value > MaximalValue)
          MaximalValue = value;

        res.DataPoints.Add(new CategoricalDataPoint(value, point));
      }

      return res;
    }

    private void FrequencyOverTimeView_ShowView(object sender, EventArgs e)
    {
      _vm = GetViewModel<ClusterEasyGenericViewModel>();
      if (!_vm.Execute())
        return;

      commandBarDropDownList1.DataSource = _vm.DocumentMetaProperties;

      foreach (var item in commandBarDropDownList1.Items)
        if (item.Text == Resources.Datum)
          commandBarDropDownList1.SelectedItem = item;
    }
  }
}