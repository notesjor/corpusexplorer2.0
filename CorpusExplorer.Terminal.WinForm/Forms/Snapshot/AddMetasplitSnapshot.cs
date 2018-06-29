#region

using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator.Abstract;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator.Counter;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator.Counter.Abstract;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Terminal.WinForm.Forms.Abstract;
using CorpusExplorer.Terminal.WinForm.Forms.Splash;
using CorpusExplorer.Terminal.WinForm.Helper;
using CorpusExplorer.Terminal.WinForm.Properties;
using Telerik.WinControls.UI.Data;

#endregion

namespace CorpusExplorer.Terminal.WinForm.Forms.Snapshot
{
  public partial class AddMetasplitSnapshot : AbstractDialog
  {
    private readonly Dictionary<AbstractSelectionClusterGenerator, string> _baseGenerators
      = new Dictionary<AbstractSelectionClusterGenerator, string>
      {
        {new SelectionClusterGeneratorStringValue(), "Text-Information / Wertbasierte Information"},
        {new SelectionClusterGeneratorIntegerRange(), "Ganzzahl-Cluster"},
        {new SelectionClusterGeneratorDoubleRange(), "Kommazahl-Cluster"},
        {new SelectionClusterGeneratorDateTimeRange(), "Datums-Angabe"}
      };

    private readonly Dictionary<AbstractSelectionClusterGenerator, string> _dateGenerators
      = new Dictionary<AbstractSelectionClusterGenerator, string>
      {
        {new SelectionClusterGeneratorDateTimeRange(), "Datums-Cluster"},
        {new SelectionClusterGeneratorDateTimeValue(), "Identisches Datum/Uhrzeit"},
        {new SelectionClusterGeneratorDateTimeYearMonthDayHourMinuteOnlyValue(), "Jahr/Monat/Tag/Stunde/Minute"},
        {new SelectionClusterGeneratorDateTimeYearMonthDayHourOnlyValue(), "Jahr/Monat/Tag/Stunde"},
        {new SelectionClusterGeneratorDateTimeYearMonthDayOnlyValue(), "Jahr/Monat/Tag"},
        {new SelectionClusterGeneratorDateTimeYearQuarterOnlyValue(), "Jahr/Quartal"},
        {new SelectionClusterGeneratorDateTimeYearWeekOnlyValue(), "Jahr/Woche"},
        {new SelectionClusterGeneratorDateTimeYearMonthOnlyValue(), "Jahr/Monat"},
        {new SelectionClusterGeneratorDateTimeYearOnlyValue(), "Jahr"},
        {new SelectionClusterGeneratorDateTimeDecadeOnlyValue(), "Jahrzehnt"},
        {new SelectionClusterGeneratorDateTimeCenturyOnlyValue(), "Jahrhundert"}
      };

    private readonly Selection _selection;

    private bool _numSpinLock;

    public AddMetasplitSnapshot(Project project, Selection selection)
      : base(project)
    {
      _selection = selection;
      InitializeComponent();
      drop_metaKey.DataSource = _selection.GetDocumentMetadataPrototypeOnlyProperties();

      drop_auto.SelectedIndex = 0;
      radPageView1.MakeHeaderInvisible();
      radPageView1.SelectedPage = page_none;

      DictionaryBindingHelper.BindDictionary(_baseGenerators, drop_auto);
      DictionaryBindingHelper.BindDictionary(_dateGenerators, drop_dateTime);

      panel_clusterFiller.Visible = false;
    }

    public Selection Result { get; private set; }

    private void AddRandomSnapshot_ButtonOkClick(object sender, EventArgs e)
    {
      var blockGroup = _selection.CreateBlock<SelectionClusterBlock>();
      blockGroup.MetadataKey = drop_metaKey.SelectedItem.Text;
      switch (drop_auto.SelectedIndex)
      {
        case 0:
          blockGroup.ClusterGenerator = new SelectionClusterGeneratorStringValue();
          break;
        case 1:
          if (drop_clusterFiller.SelectedIndex < 1)
            blockGroup.ClusterGenerator = new SelectionClusterGeneratorIntegerRange
            {
              Ranges = (int) num_cluster.Value,
              AutoDetectMinMax = true
            };
          else
            blockGroup.ClusterGenerator =
              MakeComplexClusterGenerator(PredefinedGetOrderByValueDelegateDelegates.GetInteger);
          break;
        case 2:
          if (drop_clusterFiller.SelectedIndex < 1)
            blockGroup.ClusterGenerator = new SelectionClusterGeneratorDoubleRange
            {
              Ranges = (int) num_cluster.Value,
              AutoDetectMinMax = true
            };
          else
            blockGroup.ClusterGenerator =
              MakeComplexClusterGenerator(PredefinedGetOrderByValueDelegateDelegates.GetDouble);
          break;
        case 3:
          switch (drop_dateTime.SelectedIndex)
          {
            case 0:
              if (drop_clusterFiller.SelectedIndex < 1)
                blockGroup.ClusterGenerator =
                  new SelectionClusterGeneratorDateTimeRange
                  {
                    Ranges = (int) num_cluster.Value,
                    AutoDetectMinMax = true
                  };
              else
                blockGroup.ClusterGenerator =
                  MakeComplexClusterGenerator(PredefinedGetOrderByValueDelegateDelegates.GetDateTime);
              break;
            default:
              blockGroup.ClusterGenerator = (AbstractSelectionClusterGenerator) drop_dateTime.SelectedValue;
              break;
          }

          break;
      }

      Hide();

      Processing.Invoke(
        Resources.Autosplit_wird_ausgeführt,
        () =>
        {
          blockGroup.Calculate();

          var dic = blockGroup.SelectionClusters.ToDictionary(x => x.Key, x => x.Value);

          Selection res = null;

          foreach (var range in dic)
            res = _selection.Create(range.Value, range.Key);

          Result = res;
        });
    }

    private void drop_auto_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
    {
      switch (drop_auto.SelectedIndex)
      {
        case -1:
          break;
        case 0:
          radPageView1.SelectedPage = page_none;
          panel_clusterFiller.Visible = false;
          break;
        case 1:
          radPageView1.SelectedPage = page_number;
          panel_clusterFiller.Visible = true;
          break;
        case 2:
          radPageView1.SelectedPage = page_number;
          panel_clusterFiller.Visible = true;
          break;
        case 3:
          radPageView1.SelectedPage = page_datetime;
          drop_dateTime.SelectedIndex = 0;
          panel_clusterFiller.Visible = true;
          break;
      }
    }

    private void drop_dateTime_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
    {
      panel_clusterFiller.Visible = spin_dateTimeClusters.Visible = drop_dateTime.SelectedIndex == 0;
    }

    private AbstractSelectionClusterGenerator MakeComplexClusterGenerator(GetOrderByValueDelegate func)
    {
      AbstractCounterClusterType type = null;
      // ReSharper disable once SwitchStatementMissingSomeCases
      switch (drop_clusterFiller.SelectedIndex)
      {
        // case 0: - Wird bereits zuvor in AddRandomSnapshot_ButtonOkClick behandelt
        case 1:
          type = new CounterClusterTypeDocument();
          break;
        case 2:
          type = new CounterClusterTypeSentence();
          break;
        case 3:
          type = new CounterClusterTypeToken();
          break;
      }

      return new SelectionClusterGeneratorCounter
      {
        EnableAutoOrder = true,
        ClusterType = type,
        GetOrderByValue = func,
        Ranges = (int) num_cluster.Value
      };
    }

    private void num_cluster_ValueChanged(object sender, EventArgs e)
    {
      if (_numSpinLock)
        return;
      _numSpinLock = true;
      spin_dateTimeClusters.Value = num_cluster.Value;
      _numSpinLock = false;
    }

    private void spin_dateTimeClusters_ValueChanged(object sender, EventArgs e)
    {
      if (_numSpinLock)
        return;
      _numSpinLock = true;
      num_cluster.Value = spin_dateTimeClusters.Value;
      _numSpinLock = false;
    }
  }
}