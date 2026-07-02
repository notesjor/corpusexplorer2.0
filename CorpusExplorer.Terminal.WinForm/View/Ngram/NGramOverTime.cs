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
using Telerik.Windows.Controls.DataVisualization.Map.BingRest;

namespace CorpusExplorer.Terminal.WinForm.View.Ngram
{
  public partial class NGramOverTime : AbstractView
  {
    private readonly ChartSelectionController _selection = new ChartSelectionController();

    private readonly ChartPanZoomController _zoom = new ChartPanZoomController
    {
      PanZoomMode =
        ChartPanZoomMode.Horizontal
    };

    private string _last;
    private string _lastQuery;
    private ClusterEasyGenericViewModel _vm;

    public NGramOverTime()
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

    private void Analyse()
    {
      var meta = commandBarDropDownList1.SelectedItem.Value as string;
      var current = string.Join(";",wordBag1.ResultQueries);

      if (meta != _last || current != _lastQuery)
      {
        _last = meta;
        _lastQuery = current;

        _vm.ClusterGenerator = drop_cluster.SelectedItem.Value as AbstractSelectionClusterGenerator;
        _vm.MetadataKey = meta;
        _vm.ChildViewModel = new Ngram1LayerSelectiveViewModel
        {
          LayerDisplayname = wordBag1.ResultSelectedLayerDisplayname,
          LayerQueries = wordBag1.ResultQueries,
          AutoDetectNGramSize = true
        };
        _vm.Execute();
      }

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
      var res = new LineSeries {LegendTitle = query};

      var points = _vm.ClusterTables;

      foreach (var point in points.OrderBy(x=>x.Key))
      {
        var value = point.Value.Rows.Cast<System.Data.DataRow>()
                         .Where(r => r[Resources.NGram].ToString() == query)
                         .Select(r => Convert.ToDouble(r[Resources.Frequency]))
                         .FirstOrDefault();

        res.DataPoints.Add(new CategoricalDataPoint(value, point.Key));
      }

      return res;
    }

    private void FrequencyOverTimeView_ShowView(object sender, EventArgs e)
    {
      _vm = GetViewModel<ClusterEasyGenericViewModel>();
      commandBarDropDownList1.DataSource = _vm.DocumentMetaProperties;
    }

    private void wordBag1_ExecuteButtonClicked(object sender, EventArgs e)
    {
      Analyse();
    }
  }
}