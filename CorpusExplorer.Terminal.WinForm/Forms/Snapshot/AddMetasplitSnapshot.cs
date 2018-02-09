#region

using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator.Abstract;
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
    private readonly Selection _selection;

    private readonly Dictionary<AbstractSelectionClusterGenerator, string> _baseGenerators
      = new Dictionary<AbstractSelectionClusterGenerator, string>
      {
        {new SelectionClusterGeneratorByStringValue(), "Text-Information"},
        {new SelectionClusterGeneratorByIntegerRange(), "Wert (Ganzzahl)"},
        {new SelectionClusterGeneratorByDoubleRange(), "Wert (Kommazahl)"},
        {new SelectionClusterGeneratorByDateTimeRange(), "Datums-Angabe"}
      };

    private readonly Dictionary<AbstractSelectionClusterGenerator, string> _dateGenerators
      = new Dictionary<AbstractSelectionClusterGenerator, string>
      {
        {new SelectionClusterGeneratorByDateTimeRange(), "Datums-Cluster"},
        {new SelectionClusterGeneratorByDateTimeValue(), "Identisches Datum/Uhrzeit"},
        {new SelectionClusterGeneratorByDateTimeYearMonthDayHourMinuteOnlyValue(), "Jahr/Monat/Tag/Stunde/Minute"},
        {new SelectionClusterGeneratorByDateTimeYearMonthDayHourOnlyValue(), "Jahr/Monat/Tag/Stunde"},
        {new SelectionClusterGeneratorByDateTimeYearMonthDayOnlyValue(), "Jahr/Monat/Tag"},
        {new SelectionClusterGeneratorByDateTimeYearMonthOnlyValue(), "Jahr/Monat"},
        {new SelectionClusterGeneratorByDateTimeYearOnlyValue(), "Jahr"}
      };

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
    }

    public Selection Result { get; private set; }

    private void AddRandomSnapshot_ButtonOkClick(object sender, EventArgs e)
    {
      var blockGroup = _selection.CreateBlock<SelectionClusterBlock>();
      blockGroup.MetadataKey = drop_metaKey.SelectedItem.Text;
      switch (drop_auto.SelectedIndex)
      {
        case 0:
          blockGroup.ClusterGenerator = new SelectionClusterGeneratorByStringValue();
          break;
        case 1:
          blockGroup.ClusterGenerator = new SelectionClusterGeneratorByIntegerRange().Configure((int) num_cluster.Value);
          break;
        case 2:
          blockGroup.ClusterGenerator = new SelectionClusterGeneratorByDoubleRange().Configure((int) num_cluster.Value);
          break;
        case 3:
          switch (drop_dateTime.SelectedIndex)
          {
            case 0:
              blockGroup.ClusterGenerator =
                new SelectionClusterGeneratorByDateTimeRange().Configure((int) num_cluster.Value);
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
          break;
        case 1:
          radPageView1.SelectedPage = page_number;
          break;
        case 2:
          radPageView1.SelectedPage = page_number;
          break;
        case 3:
          radPageView1.SelectedPage = page_datetime;
          break;
      }
    }

    private void drop_dateTime_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
    {
      spin_dateTimeClusters.Visible = drop_dateTime.SelectedIndex == 0;
    }

    private void num_cluster_ValueChanged(object sender, EventArgs e)
    {
      if (_numSpinLock)
        return;
      _numSpinLock = true;
      spin_dateTimeClusters.Value = num_cluster.Value;
      _numSpinLock = false;
    }

    private void radCollapsiblePanel1_Expanded(object sender, EventArgs e) { }

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