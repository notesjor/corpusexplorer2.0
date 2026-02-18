using CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator.Abstract;
using CorpusExplorer.Sdk.ViewModel;
using CorpusExplorer.Terminal.WinForm.Helper;
using CorpusExplorer.Terminal.WinForm.Helper.UiFramework;
using CorpusExplorer.Terminal.WinForm.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.Charting;
using Telerik.WinControls.UI;
using PositionChangedEventArgs = Telerik.WinControls.UI.Data.PositionChangedEventArgs;

namespace CorpusExplorer.Terminal.WinForm.View.CorpusDistribution
{
  public partial class CorpusDistributionOverTime : AbstractView
  {
    private readonly ChartSelectionController _selection = new ChartSelectionController();

    private readonly ChartPanZoomController _zoom = new ChartPanZoomController
    {
      PanZoomMode =
        ChartPanZoomMode.Horizontal
    };

    private ClusterEasyGenericViewModel _vm;

    public CorpusDistributionOverTime()
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

      commandBarDropDownList3.Items.Add(new RadListDataItem(Resources.Token, 0));
      commandBarDropDownList3.Items.Add(new RadListDataItem(Resources.Types, 1));
      commandBarDropDownList3.Items.Add(new RadListDataItem(Resources.Dokumente, 2));

      commandBarDropDownList3.SelectedIndex = 0;
    }

    public double MaximalValue { get; set; }

    private void btn_export_Click(object sender, EventArgs e)
    {
      DataTableExporter.Export(_vm.GetDataTable());
    }

    private LineSeries BuildSeries(string query)
    {
      var res = new LineSeries { LegendTitle = query };

      var points = _vm.ClusterTables;

      foreach (var point in points.OrderBy(x => x.Key))
      {
        var value = point.Value.Rows.Cast<System.Data.DataRow>()
          .Where(r => r[Resources.Category].ToString() == commandBarDropDownList2.SelectedItem.Text && r[Resources.Metadaten] == query)
          .Select(r => Convert.ToDouble(r[Resources.Token]))
          .FirstOrDefault();
        if (value > MaximalValue)
          MaximalValue = value;

        res.DataPoints.Add(new CategoricalDataPoint(value, point.Key));
      }

      return res;
    }

    private void commandBarDropDownList2_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
    {
      var meta = commandBarDropDownList1.SelectedItem.Value as string;
      _vm.ClusterGenerator = drop_cluster.SelectedItem.Value as AbstractSelectionClusterGenerator;
      _vm.MetadataKey = meta;
      _vm.ChildViewModel = new CorpusWeightUnlimmitedViewModel();
      ResetChart();
      _vm.Execute();

      var items = GetAvailableMetadataValueForCategory(commandBarDropDownList2.SelectedItem.Text);
      drop_select.Items.Clear();

      foreach (var x in items)
        drop_select.Items.Add(x, false);
    }

    private IEnumerable<string> GetAvailableMetadataValueForCategory(string category)
    {
      var res = new HashSet<string>();
      foreach (var y in _vm.ClusterTables.SelectMany(x => x.Value.Rows.Cast<System.Data.DataRow>()
                 .Where(r => r[Resources.Category].ToString() == category)
                 .Select(r => r[Resources.Metadaten].ToString())))
        res.Add(y);

      return res;
    }

    private void drop_select_ItemCheckedChanged(object sender, RadCheckedListDataItemEventArgs e)
    {
      ResetChart();

      var queries = (from RadCheckedListDataItem x in drop_select.Items where x.Checked select x.Text).ToArray();
      if (queries.Length == 0)
        return;

      MaximalValue = 0.0d; // wird durch die folgende Zeile ermittelt
      foreach (var query in queries)
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

    private void FrequencyOverTimeView_ShowView(object sender, EventArgs e)
    {
      _vm = GetViewModel<ClusterEasyGenericViewModel>();

      commandBarDropDownList1.DataSource = _vm.DocumentMetaProperties;
      commandBarDropDownList2.DataSource = _vm.DocumentMetaProperties;

      foreach (var item in commandBarDropDownList1.Items)
        if (item.Text == Resources.Datum)
          commandBarDropDownList1.SelectedItem = item;

      commandBarDropDownList2.SelectedIndex = _vm.DocumentMetaProperties.Count() - 1;
    }

    private void ResetChart()
    {
      chart_view.Series.Clear();
      chart_view.Axes.Clear();
      chart_view.Controllers.Clear();

      _zoom.PanZoomMode = ChartPanZoomMode.Horizontal;
      chart_view.Controllers.Add(_zoom);
      chart_view.Controllers.Add(_selection);
    }
  }
}