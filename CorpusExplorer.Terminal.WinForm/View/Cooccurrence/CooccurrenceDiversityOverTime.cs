using System;
using System.Linq;
using CorpusExplorer.Sdk.ViewModel;
using CorpusExplorer.Terminal.WinForm.Forms.SelectLayer;
using CorpusExplorer.Terminal.WinForm.Forms.Splash;
using CorpusExplorer.Terminal.WinForm.Helper;
using CorpusExplorer.Terminal.WinForm.Helper.UiFramework;
using CorpusExplorer.Terminal.WinForm.Properties;
using Telerik.Charting;
using Telerik.WinControls.UI;

namespace CorpusExplorer.Terminal.WinForm.View.Cooccurrence
{
  public partial class CooccurrenceDiversityOverTime : AbstractView
  {
    private CooccurrencesOverTimeViewModel _vm;

    public CooccurrenceDiversityOverTime()
    {
      InitializeComponent();
      ShowView += FrequencyOverTimeView_ShowView;
    }

    //public double MaximalValue { get; set; }

    public int Clusters { get; set; } = 25;

    private void btn_export_Click(object sender, EventArgs e)
    {
      DataTableExporter.Export(_vm.GetDataTable());
    }

    private void btn_go_Click(object sender, EventArgs e)
    {
      Processing.Invoke("Ermittle Kookkurrenzen für die Auswahlbox", () =>
      {
        var meta = commandBarDropDownList1.SelectedItem.Value as string;
        var queries = radAutoCompleteBox1.Items.Select(item => item.Text).ToArray();

        if (!int.TryParse(commandBarTextBox1.Text, out var clusters))
          clusters = 0;
        Clusters = clusters;

        if (SelectedLayerDisplaynames != null)
          _vm.LayerDisplayname = SelectedLayerDisplaynames[0];
        _vm.DateTimeProperty = meta;
        _vm.LayerQueries = queries;
        _vm.Analyse();

        ResetChart();

        drop_select.Items.Clear();

        foreach (var x in _vm.DateTimeValues)
          foreach (var y in x.Value)
            drop_select.Items.Add(y.Key, false);
      });
    }

    private BarSeries BuildSeries(string query)
    {
      var res = new BarSeries
      {
        LegendTitle = query,
        CombineMode = ChartSeriesCombineMode.Stack100
      };

      var points = _vm.AggregateDateTimeValues(Clusters);

      foreach (var point in points)
      {
        var value = point.Value.ContainsKey(query) ? point.Value[query] : 0;
        //if (value > MaximalValue)
        //  MaximalValue = value;

        res.DataPoints.Add(new CategoricalDataPoint(value, point.Key.ToString("yyyy-MM-dd")));
      }

      return res;
    }

    private void drop_select_ItemCheckedChanged(object sender, RadCheckedListDataItemEventArgs e)
    {
      ResetChart();

      var queries = (from RadCheckedListDataItem x in drop_select.Items where x.Checked select x.Text).ToArray();
      if (queries.Length == 0)
        return;

      //MaximalValue = 0.0d; // wird durch die folgende Zeile ermittelt
      foreach (var query in queries)
        chart_view.Series.Add(BuildSeries(query));

      //foreach (var x in chart_view.Axes.OfType<LinearAxis>()) x.Maximum = MaximalValue;

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
      _vm = GetViewModel<CooccurrencesOverTimeViewModel>();

      radAutoCompleteBox1.AutoCompleteDataSource = Project.CurrentSelection.GetLayerValues(Resources.Wort);
      commandBarDropDownList1.DataSource = _vm.DocumentMetadata;

      foreach (var item in commandBarDropDownList1.Items)
        if (item.Text == Resources.Datum)
          commandBarDropDownList1.SelectedItem = item;
    }

    private void ResetChart()
    {
      chart_view.Series.Clear();
      chart_view.Axes.Clear();
    }

    private void btn_layer_Click(object sender, EventArgs e)
    {
      var form = new Select1Layer(SelectedLayerDisplaynames);
      form.ShowDialog();
      SelectedLayerDisplaynames = form.ResultSelectedLayerDisplaynames;
    }
  }
}