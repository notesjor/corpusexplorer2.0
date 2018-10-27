using System;
using System.Linq;
using CorpusExplorer.Sdk.ViewModel;
using CorpusExplorer.Terminal.WinForm.Helper;
using CorpusExplorer.Terminal.WinForm.Helper.UiFramework;
using CorpusExplorer.Terminal.WinForm.Properties;
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

    private FrequencyOverTimeViewModel _vm;

    public FrequencyOverTime()
    {
      InitializeComponent();
      chart_view.ShowPanZoom = true;
      ShowView += FrequencyOverTimeView_ShowView;
    }

    public int Clusters { get; set; } = 25;

    public double MaximalValue { get; set; }

    private void btn_export_Click(object sender, EventArgs e)
    {
      DataTableExporter.Export(_vm.GetDataTable());
    }

    private void wordBag1_ExecuteButtonClicked(object sender, EventArgs e)
    {
      var meta = commandBarDropDownList1.SelectedItem.Value as string;

      if (!int.TryParse(commandBarTextBox1.Text, out var clusters))
        clusters = 0;
      Clusters = clusters;

      _vm.DateTimeProperty = meta;
      _vm.LayerQueries = wordBag1.ResultQueries;
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
      var res = new LineSeries {LegendTitle = query};

      var points = _vm.AggregateDateTimeValues(Clusters);

      foreach (var point in points)
      {
        var value = point.Value.ContainsKey(query) ? point.Value[query] : 0;
        if (value > MaximalValue)
          MaximalValue = value;

        res.DataPoints.Add(new CategoricalDataPoint(value, point.Key.ToString("yyyy-MM-dd")));
      }

      return res;
    }

    private void FrequencyOverTimeView_ShowView(object sender, EventArgs e)
    {
      _vm = GetViewModel<FrequencyOverTimeViewModel>();
      if (!_vm.Execute())
        return;

      commandBarDropDownList1.DataSource = _vm.DocumentMetadata;

      foreach (var item in commandBarDropDownList1.Items)
        if (item.Text == Resources.Datum)
          commandBarDropDownList1.SelectedItem = item;
    }
  }
}