using CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator.Abstract;
using CorpusExplorer.Sdk.ViewModel;
using CorpusExplorer.Terminal.WinForm.Forms.SelectLayer;
using CorpusExplorer.Terminal.WinForm.Forms.Splash;
using CorpusExplorer.Terminal.WinForm.Helper;
using CorpusExplorer.Terminal.WinForm.Helper.UiFramework;
using CorpusExplorer.Terminal.WinForm.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Telerik.Charting;
using Telerik.WinControls.UI;

namespace CorpusExplorer.Terminal.WinForm.View.Cooccurrence
{
  public partial class CooccurrenceOverTime : AbstractView
  {
    private ClusterEasyGenericViewModel _vm;

    public CooccurrenceOverTime()
    {
      InitializeComponent();
      drop_cluster.Items.Add(new RadListDataItem("Jahr/Monat/Tag", new SelectionClusterGeneratorDateTimeYearMonthDay()));
      drop_cluster.Items.Add(new RadListDataItem("Jahr/Woche", new SelectionClusterGeneratorDateTimeYearWeek()));
      drop_cluster.Items.Add(new RadListDataItem("Jahr/Monat", new SelectionClusterGeneratorDateTimeYearMonth()));
      drop_cluster.Items.Add(new RadListDataItem("Jahr/Quartal", new SelectionClusterGeneratorDateTimeYearQuarter()));
      drop_cluster.Items.Add(new RadListDataItem("Jahr", new SelectionClusterGeneratorDateTimeYear()));
      drop_cluster.Items.Add(new RadListDataItem("Jahrzehnt", new SelectionClusterGeneratorDateTimeDecade()));
      drop_cluster.SelectedIndex = 0;
      ShowView += FrequencyOverTimeView_ShowView;
    }

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

        if (SelectedLayerDisplaynames != null)
          _vm.LayerDisplayname = SelectedLayerDisplaynames[0];
        _vm.ClusterGenerator = drop_cluster.SelectedItem.Value as AbstractSelectionClusterGenerator;
        _vm.MetadataKey = meta;
        _vm.ChildViewModel = new CooccurrenceSelectiveViewModel { LayerDisplayname = _vm.LayerDisplayname, LayerQueries = queries };
        _vm.Execute();

        ResetChart();

        var bag = new HashSet<string>(_vm.ClusterTables.SelectMany(x => x.Value.Rows.Cast<DataRow>().Select(row => row[Resources.Cooccurrence].ToString())));
        var dict = new Dictionary<string, double>();
        foreach (var point in _vm.ClusterTables)
          foreach (var row in point.Value.Rows.Cast<DataRow>())
          {
            var key = row[Resources.Cooccurrence].ToString();
            if (!bag.Contains(key))
              continue;

            var value = Convert.ToDouble(row[Resources.Significance]);
            if (!dict.ContainsKey(key))
              dict.Add(key, value);
            else if (value > dict[key])
              dict[key] = value;
          }

        drop_select.Items.Clear();

        foreach (var x in dict.OrderByDescending(x => x.Value))
          drop_select.Items.Add(x.Key, false);
      });
    }

    private BarSeries BuildSeries(string query)
    {
      var res = new BarSeries
      {
        LegendTitle = query,
        CombineMode = ChartSeriesCombineMode.Stack100
      };

      var points = _vm.ClusterTables;

      foreach (var point in points.OrderBy(x => x.Key))
      {
        var value = point.Value.Rows.Cast<DataRow>().Where(row => row[Resources.Cooccurrence].ToString() == query).Select(row => Convert.ToDouble(row[Resources.Significance])).FirstOrDefault();

        res.DataPoints.Add(new CategoricalDataPoint(value, point.Key));
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
      _vm = GetViewModel<ClusterEasyGenericViewModel>();

      radAutoCompleteBox1.AutoCompleteDataSource = Project.CurrentSelection.GetLayerValues(Resources.Wort);
      commandBarDropDownList1.DataSource = _vm.DocumentMetaProperties;

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