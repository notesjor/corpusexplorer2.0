#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;
using Bcs.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.ViewModel;
using CorpusExplorer.Terminal.WinForm.Controls.Wpf.Diagram.Converter;
using CorpusExplorer.Terminal.WinForm.Controls.Wpf.Diagram.Converter.Abstract;
using CorpusExplorer.Terminal.WinForm.Forms.Simple;
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
    private HashSet<string> _done;
    private List<Tuple<string, double, string>> _tuples;
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
      var ofd = new OpenFileDialog {Filter = Resources.FileExtension_CEDG, CheckFileExists = true};
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
    }

    private void btn_graph_save_Click(object sender, EventArgs e)
    {
      var sfd = new SaveFileDialog {Filter = Resources.FileExtension_CEDG, CheckPathExists = true};
      if (sfd.ShowDialog() != DialogResult.OK)
        return;

      simpleDiagram1.CallSave(sfd.FileName);
    }

    private void btn_layout_network_Click(object sender, EventArgs e) { simpleDiagram1.CallLayoutAsSugiyama(); }

    private void btn_layout_tree_Click(object sender, EventArgs e) { simpleDiagram1.CallLayoutAsTree(); }

    private void btn_request_fulltext_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(txt_query.Text))
      {
        MessageBox.Show(Resources.BitteGebenSieEinenSuchbegriffEin);
        return;
      }

      simpleDiagram1.CallAdd(
        _vm.GetFulltext(txt_query.Text).Select(x => new Tuple<string, double, string>(txt_query.Text, 0, x)),
        new UniversalColor(255, 255, 255));
    }

    private void btn_request_kookkurrenz_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(txt_query.Text))
      {
        MessageBox.Show(Resources.BitteGebenSieEinenSuchbegriffEin);
        return;
      }

      var collocates = _vm.GetCollocates(txt_query.Text).ToDictionary(x => x.Key, x => x.Value);

      if (!collocates.Any())
      {
        MessageBox.Show(Resources.FürDenSuchbegriffExisitierenKeineSignifikantenKookkurrenzen);
        return;
      }

      _done = new HashSet<string> {txt_query.Text};
      _tuples = new List<Tuple<string, double, string>>();

      foreach (var c in collocates)
      {
        RecursiveCollcationDiscovery(c.Key, 2, (int) radSpinEditor1.Value);
        _tuples.Add(new Tuple<string, double, string>(txt_query.Text, c.Value, c.Key));
      }

      simpleDiagram1.CallAdd(_tuples, new UniversalColor(255, 80, 120));
    }

    private void btn_request_metadata_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(txt_query.Text))
      {
        MessageBox.Show(Resources.BitteGebenSieEinenSuchbegriffEin);
        return;
      }

      if (drop_meta.SelectedIndex == -1)
      {
        MessageBox.Show(Resources.BitteWählenSieEineMetaangabeAus);
        return;
      }

      simpleDiagram1.CallAdd(
        _vm.GetMetadata(txt_query.Text, drop_meta.SelectedItem.Text)
           .Select(x => new Tuple<string, double, string>(txt_query.Text, 0, x)),
        new UniversalColor(80, 255, 120));
    }

    private void Export(AbstractGraphConverter type, string filter)
    {
      var sfd = new SaveFileDialog {Filter = filter, CheckPathExists = true};
      if (sfd.ShowDialog() != DialogResult.OK)
        return;
      FileIO.Write(sfd.FileName, simpleDiagram1.Export(type), Configuration.Encoding);
    }

    private void RecursiveCollcationDiscovery(string query, int i, int max)
    {
      if (i >= max)
        return;
      i++;

      _done.Add(query);
      var collocates = _vm.GetCollocates(txt_query.Text).ToDictionary(x => x.Key, x => x.Value);
      if (!collocates.Any())
        return;

      /*
      foreach (var c in collocates)
      {
        if()
      }
      */
    }

    private void ShowViewCall(object sender, EventArgs e)
    {
      _vm = ViewModelGet<ExplorationViewModel>();
      _vm.SignificanceMinimum = Configuration.MinimumSignificance;
      _vm.Analyse();
      drop_meta.DataSource = _vm.DocumentMetadataProperties;
    }

    private string TextInput()
    {
      var form = new SimpleTextInput(
        Resources.BegriffAsk,
        Resources.GebenSieEinenStartbegriffEin,
        Resources.diagram,
        Resources.BegriffHierEingeben);

      return form.ShowDialog() != DialogResult.OK ? "" : form.Result;
    }
  }
}