#region

using System;
using System.Windows.Forms;
using Bcs.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.ViewModel;
using CorpusExplorer.Terminal.WinForm.Controls.Wpf.Diagram.Converter;
using CorpusExplorer.Terminal.WinForm.Controls.Wpf.Diagram.Converter.Abstract;
using CorpusExplorer.Terminal.WinForm.Forms.Splash;
using CorpusExplorer.Terminal.WinForm.Helper.UiFramework;
using CorpusExplorer.Terminal.WinForm.Properties;

#endregion

namespace CorpusExplorer.Terminal.WinForm.View.Ngram
{
  /// <summary>
  ///   The grid visualisation.
  /// </summary>
  public partial class NGramDiagram : AbstractView
  {
    private NgramChainViewModel _vm;

    /// <summary>
    ///   Initializes a new instance of the <see cref="AbstractView" /> class.
    /// </summary>
    public NGramDiagram()
    {
      InitializeComponent();

      ShowView += (sender, args) =>
      {
        _vm = ViewModelGet<NgramChainViewModel>();
        combo_layer.DataSource = _vm.LayerDisplaynames;
      };
    }

    private void AnalyseAggregated()
    {
      _vm.NGramSize = int.Parse(txt_size.Text);
      _vm.NGramPatternSize = int.Parse(txt_pattern.Text);
      _vm.LayerDisplayname = combo_layer.SelectedItem.Text;
      _vm.Analyse();
      simpleDiagram1.CallBuildAggregatedChain(_vm.TakeNGramFrequency(int.Parse(txt_max.Text)));
    }

    private void AnalyseSimple()
    {
      _vm.NGramSize = int.Parse(txt_size.Text);
      _vm.NGramPatternSize = int.Parse(txt_pattern.Text);
      _vm.LayerDisplayname = combo_layer.SelectedItem.Text;
      _vm.Analyse();
      simpleDiagram1.CallBuildChain(_vm.TakeNGramFrequency(int.Parse(txt_max.Text)));
    }

    private void btn_analyse_aggregated_Click(object sender, EventArgs e)
    {
      Processing.Invoke(Resources.ErstelleUndZähleNGramme, AnalyseAggregated);
    }

    private void btn_execute_Click(object sender, EventArgs e)
    {
      Processing.Invoke(Resources.ErstelleUndZähleNGramme, AnalyseSimple);
    }

    private void btn_export_gexf_Click(object sender, EventArgs e)
    {
      Export(new GexfXmlGraphConverter(), Resources.GEXFXMLDokumentGexfGexf);
    }

    private void btn_export_graphviz_Click(object sender, EventArgs e)
    {
      Export(new GraphVizGraphConverter(), Resources.GraphVizDokumentGvGv);
    }

    private void btn_layout_network_Click(object sender, EventArgs e) { simpleDiagram1.CallLayoutAsSugiyama(); }

    private void btn_layout_tree_Click(object sender, EventArgs e) { simpleDiagram1.CallLayoutAsTree(); }

    private void btn_save_Click(object sender, EventArgs e)
    {
      var sfd = new SaveFileDialog {Filter = Resources.FileExtension_CEDG, CheckPathExists = true};
      if (sfd.ShowDialog() != DialogResult.OK)
        return;

      simpleDiagram1.CallSave(sfd.FileName);
    }

    private void Export(AbstractGraphConverter type, string filter)
    {
      var sfd = new SaveFileDialog {Filter = filter, CheckPathExists = true};
      if (sfd.ShowDialog() != DialogResult.OK)
        return;
      FileIO.Write(sfd.FileName, simpleDiagram1.Export(type), Configuration.Encoding);
    }
  }
}