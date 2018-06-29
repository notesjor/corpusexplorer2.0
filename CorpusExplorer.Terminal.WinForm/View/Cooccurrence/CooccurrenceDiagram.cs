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
using CorpusExplorer.Terminal.WinForm.Controls.Wpf.Diagram.Converter;
using CorpusExplorer.Terminal.WinForm.Controls.Wpf.Diagram.Converter.Abstract;
using CorpusExplorer.Terminal.WinForm.Helper.UiFramework;
using CorpusExplorer.Terminal.WinForm.Properties;
using MessageBox = System.Windows.MessageBox;

#endregion

namespace CorpusExplorer.Terminal.WinForm.View.Cooccurrence
{
  /// <summary>
  ///   The graph visualisation.
  /// </summary>
  public partial class CooccurrenceDiagram : AbstractView
  {
    private HashSet<string> _done = new HashSet<string>();
    private ExplorationViewModel _vm;

    /// <summary>
    ///   Initializes a new instance of the <see cref="AbstractView" /> class.
    /// </summary>
    public CooccurrenceDiagram()
    {
      InitializeComponent();
      ShowView += ShowViewCall;
    }

    private void btn_export_gexf_Click(object sender, EventArgs e)
    {
      Export(new GexfXmlGraphConverter(), Resources.GEXFXMLDokumentGexfGexf);
    }

    private void btn_export_graphviz_Click(object sender, EventArgs e)
    {
      Export(new GraphVizGraphConverter(), Resources.GraphVizDokumentGvGv);
    }

    private void btn_graph_load_Click(object sender, EventArgs e)
    {
      var ofd = new OpenFileDialog { Filter = Resources.FileExtension_CEDG, CheckFileExists = true };
      if (ofd.ShowDialog() != DialogResult.OK)
        return;

      simpleDiagram1.CallLoad(ofd.FileName);
    }

    private void btn_graph_new_Click(object sender, EventArgs e)
    {
      if (
        MessageBox.Show(
          Resources.MöchtenSieWirklichDasDiagrammLöschenUndNeuBeginnen,
          Resources.NeuStarten,
          MessageBoxButton.YesNo,
          MessageBoxImage.Question) != MessageBoxResult.Yes)
        return;

      simpleDiagram1.CallNew();
      _done = new HashSet<string>();
    }

    private void btn_graph_save_Click(object sender, EventArgs e)
    {
      var sfd = new SaveFileDialog { Filter = Resources.FileExtension_CEDG, CheckPathExists = true };
      if (sfd.ShowDialog() != DialogResult.OK)
        return;

      simpleDiagram1.CallSave(sfd.FileName);
    }

    private void btn_layout_network_Click(object sender, EventArgs e)
    {
      simpleDiagram1.CallLayoutAsTreeRadial();
    }

    private void btn_layout_tree_Click(object sender, EventArgs e)
    {
      simpleDiagram1.CallLayoutAsTree();
    }

    private void Export(AbstractGraphConverter type, string filter)
    {
      var sfd = new SaveFileDialog { Filter = filter, CheckPathExists = true };
      if (sfd.ShowDialog() != DialogResult.OK)
        return;
      FileIO.Write(sfd.FileName, simpleDiagram1.CallExport(type), Configuration.Encoding);
    }

    private void ShowViewCall(object sender, EventArgs e)
    {
      Analyse();
    }

    private void Analyse()
    {
      _vm = GetViewModel<ExplorationViewModel>();
      _vm.SignificanceMinimum = Configuration.MinimumSignificance;
      _vm.LayerDisplayname = wordBag1.ResultSelectedLayerDisplayname;
      _vm.Analyse();
    }

    private void wordBag1_ExecuteButtonClicked(object sender, EventArgs e)
    {
      if (!wordBag1.ResultQueries.Any())
      {
        MessageBox.Show(Resources.BitteGebenSieEinenSuchbegriffEin);
        return;
      }

      var queries = wordBag1.ResultQueries.ToArray();
      foreach (var query in queries)
      {
        simpleDiagram1.CallAddNodes(new[] { query });
        simpleDiagram1.CallColorizeNodes(new[] { query }, new UniversalColor(130, 255, 180));

        var collocates = _vm.GetCollocates(query).ToDictionary(x => x.Key, x => x.Value);

        if (!collocates.Any())
        {
          MessageBox.Show(Resources.FürDenSuchbegriffExisitierenKeineSignifikantenKookkurrenzen);
          return;
        }

        var newNodes = new List<string>();
        var connections = new List<Tuple<string, string, double>>();
        foreach (var collocate in collocates)
        {
          connections.Add(new Tuple<string, string, double>(query, collocate.Key, collocate.Value));
          if (_done.Contains(collocate.Key))
            continue;

          _done.Add(collocate.Key);
          newNodes.Add(collocate.Key);
        }

        simpleDiagram1.CallAddNodes(newNodes, color: new UniversalColor(130, 180, 255));
        simpleDiagram1.CallAddConnections(connections);
        simpleDiagram1.CallConnectionRendering();
        simpleDiagram1.CallLayoutAsTreeRadial();
      }
    }
  }
}