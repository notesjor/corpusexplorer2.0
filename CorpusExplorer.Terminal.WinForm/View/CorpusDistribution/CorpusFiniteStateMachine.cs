#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using Bcs.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.ViewModel;
using CorpusExplorer.Terminal.WinForm.Controls.Wpf.Diagram;
using CorpusExplorer.Terminal.WinForm.Controls.Wpf.Diagram.Converter;
using CorpusExplorer.Terminal.WinForm.Controls.Wpf.Diagram.Converter.Abstract;
using CorpusExplorer.Terminal.WinForm.Forms.Splash;
using CorpusExplorer.Terminal.WinForm.Helper.UiFramework;
using CorpusExplorer.Terminal.WinForm.Properties;
using HorizontalAlignment = System.Windows.HorizontalAlignment;

#endregion

namespace CorpusExplorer.Terminal.WinForm.View.CorpusDistribution
{
  /// <summary>
  ///   The grid visualisation.
  /// </summary>
  public partial class CorpusFiniteStateMachine : AbstractView
  {
    private List<string> _index;
    private CorpusFiniteStateMachineViewModel _vm;
    private readonly WpfDiagram simpleDiagram1;

    /// <summary>
    ///   Initializes a new instance of the <see cref="AbstractView" /> class.
    /// </summary>
    public CorpusFiniteStateMachine()
    {
      InitializeComponent();
      simpleDiagram1 = new WpfDiagram
        {VerticalAlignment = VerticalAlignment.Stretch, HorizontalAlignment = HorizontalAlignment.Stretch};
      elementHost1.Child = simpleDiagram1;

      ShowView += (sender, args) =>
      {
        _vm = GetViewModel<CorpusFiniteStateMachineViewModel>();
        _index = _vm.AvailableMetadata.ToList();

        drop_category1.DataSource = _vm.AvailableMetadata.ToArray();
        drop_category2.DataSource = _vm.AvailableMetadata.ToArray();
        drop_sort.DataSource = _vm.AvailableMetadata.ToArray();

        drop_sort.SelectedIndex = _index.IndexOf(_vm.MetadataKeyTimestamp);
        drop_category1.SelectedIndex = _index.IndexOf(_vm.MetadataKeyEntity);
        drop_category2.SelectedIndex = _index.IndexOf(_vm.MetadataKeyLevel);
      };
    }

    private void AnalyseAggregated()
    {
      if (drop_sort.SelectedIndex == -1 || drop_category1.SelectedIndex == -1 || drop_category2.SelectedIndex == -1)
        return;

      _vm = GetViewModel<CorpusFiniteStateMachineViewModel>();
      _vm.MetadataKeyTimestamp = _index[drop_sort.SelectedIndex];
      _vm.MetadataKeyEntity = _index[drop_category1.SelectedIndex];
      _vm.MetadataKeyLevel = _index[drop_category2.SelectedIndex];
      _vm.Execute();

      simpleDiagram1.CallNew();
      simpleDiagram1.CallAddNodes(new HashSet<string>(_vm.Entities));
      simpleDiagram1.CallColorizeNodes(_vm.Entities, new UniversalColor(150, 255, 180));
      simpleDiagram1.CallAddNodes(new HashSet<string>(_vm.Levels));
      simpleDiagram1.CallColorizeNodes(_vm.Levels, new UniversalColor(150, 180, 255));

      var cons = new List<Tuple<string, string, double>>();
      foreach (var connection in _vm.ConnectionsAggregated)
      foreach (var dest in connection.Value)
        cons.Add(new Tuple<string, string, double>(connection.Key, dest, 1));

      simpleDiagram1.CallAddConnections(cons);
      simpleDiagram1.CallLayoutAsTree();
    }

    private void btn_export_csv_Click(object sender, EventArgs e)
    {
      Export(new CsvGraphConverter(), Resources.FileExtension_CSV);
    }

    private void btn_export_gexf_Click(object sender, EventArgs e)
    {
      Export(new GexfXmlGraphConverter(), Resources.GEXFXMLDokumentGexfGexf);
    }

    private void btn_export_graphviz_Click(object sender, EventArgs e)
    {
      Export(new GraphVizGraphConverter(), Resources.GraphVizDokumentGvGv);
    }

    private void btn_layout_network_Click(object sender, EventArgs e)
    {
      simpleDiagram1.CallLayoutAsSugiyama();
    }

    private void btn_layout_tree_Click(object sender, EventArgs e)
    {
      simpleDiagram1.CallLayoutAsTree();
    }

    private void btn_save_Click(object sender, EventArgs e)
    {
      var sfd = new SaveFileDialog {Filter = Resources.FileExtension_CEDG, CheckPathExists = true};
      if (sfd.ShowDialog() != DialogResult.OK)
        return;

      simpleDiagram1.CallSave(sfd.FileName);
    }

    private void btn_start_Click(object sender, EventArgs e)
    {
      Processing.Invoke(
                        Resources.CorpusFiniteStateMachine_btn_analyse_aggregated_Click_Erstelle_den_Strukturbaum,
                        AnalyseAggregated);
    }

    private void Export(AbstractGraphConverter type, string filter)
    {
      var sfd = new SaveFileDialog {Filter = filter, CheckPathExists = true};
      if (sfd.ShowDialog() != DialogResult.OK)
        return;
      FileIO.Write(sfd.FileName, simpleDiagram1.CallExport(type), Configuration.Encoding);
    }
  }
}