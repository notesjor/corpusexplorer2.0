﻿#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
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
        {new SelectionClusterGeneratorDateTime(), "Identisches Datum/Uhrzeit"},
        {new SelectionClusterGeneratorDateTimeYearMonthDayHourMinute(), "Jahr/Monat/Tag/Stunde/Minute"},
        {new SelectionClusterGeneratorDateTimeYearMonthDayHour(), "Jahr/Monat/Tag/Stunde"},
        {new SelectionClusterGeneratorDateTimeYearMonthDay(), "Jahr/Monat/Tag"},
        {new SelectionClusterGeneratorDateTimeYearQuarter(), "Jahr/Quartal"},
        {new SelectionClusterGeneratorDateTimeYearWeek(), "Jahr/Woche"},
        {new SelectionClusterGeneratorDateTimeYearMonth(), "Jahr/Monat"},
        {new SelectionClusterGeneratorDateTimeYear(), "Jahr"},
        {new SelectionClusterGeneratorDateTimeDecade(), "Jahrzehnt"},
        {new SelectionClusterGeneratorDateTimeCentury(), "Jahrhundert"}
      };

    private readonly Selection _selection;

    private bool _numSpinLock;

    public AddMetasplitSnapshot(Project project, Selection selection)
      : base(project)
    {
      _selection = selection;
      InitializeComponent();
      drop_metaKey.DataSource = selection == null ? project.SelectAll.GetDocumentMetadataPrototypeOnlyProperties() : selection.GetDocumentMetadataPrototypeOnlyProperties();

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
      var blockGroup = _selection == null ? Project.SelectAll.CreateBlock<SelectionClusterBlock>() : _selection.CreateBlock<SelectionClusterBlock>();
      blockGroup.MetadataKey = drop_metaKey.SelectedItem.Text;
      blockGroup.NoParent = _selection == null;
      switch (drop_auto.SelectedIndex)
      {
        case 0:
          blockGroup.ClusterGenerator = new SelectionClusterGeneratorStringValue();
          break;
        case 1:
          if (drop_clusterFiller.SelectedIndex < 1)
            blockGroup.ClusterGenerator = new SelectionClusterGeneratorIntegerRange
            {
              Ranges = (int)num_cluster.Value,
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
              Ranges = (int)num_cluster.Value,
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
                    Ranges = (int)num_cluster.Value,
                    AutoDetectMinMax = true
                  };
              else
                blockGroup.ClusterGenerator =
                  MakeComplexClusterGenerator(PredefinedGetOrderByValueDelegateDelegates.GetDateTime);
              break;
            default:
              blockGroup.ClusterGenerator = (AbstractSelectionClusterGenerator)drop_dateTime.SelectedValue;
              break;
          }

          break;
      }

      Hide();

      Processing
       .Invoke(Resources.Autosplit_wird_ausgeführt,
               () =>
               {
                 blockGroup.Calculate();

                 // .ToArray() sorgt dafür, dass zunächst alle Selections erzeugt werden
                 // .First() würde nur dazu führen, dass nur die erste Selection erzeugt wird.
                 var selections = (num_window.Value < 2
                                     ? blockGroup.GetSelectionClusters()
                                     : blockGroup.GetSelectionClustersWindowed((int)num_window.Value)).ToArray();

                 Result = selections.First();
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
        Ranges = (int)num_cluster.Value
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

    private void infoButton1_Click(object sender, EventArgs e)
    {
      MessageBox.Show("Nachdem der Autosplit erfolgreich durchgeführt wurde, wird ein \"Sliding Window\" über die Schnappschüsse gelegt. Damit werden Übergänge fließender. Setzen Sie den Wert auf 1, um das \"Sliding Window\" zu deaktivieren.");
    }
  }
}