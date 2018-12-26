#region

using System;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using Bcs.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.ViewModel;
using CorpusExplorer.Terminal.WinForm.Controls.WinForm;
using CorpusExplorer.Terminal.WinForm.Controls.Wpf.Diagram;
using CorpusExplorer.Terminal.WinForm.Controls.Wpf.Diagram.Converter;
using CorpusExplorer.Terminal.WinForm.Controls.Wpf.Diagram.Converter.Abstract;
using CorpusExplorer.Terminal.WinForm.Forms.Splash;
using CorpusExplorer.Terminal.WinForm.Helper.UiFramework;
using CorpusExplorer.Terminal.WinForm.Properties;
using HorizontalAlignment = System.Windows.HorizontalAlignment;
using MessageBox = System.Windows.MessageBox;

#endregion

namespace CorpusExplorer.Terminal.WinForm.View.Fulltext
{
  public partial class FulltextKwicTree : AbstractView
  {
    private TextFlowSearchViewModel _vm;
    private WpfDiagram wpfDiagram1;

    public FulltextKwicTree()
    {
      InitializeComponent();
      wpfDiagram1 = new WpfDiagram { VerticalAlignment = VerticalAlignment.Stretch, HorizontalAlignment = HorizontalAlignment.Stretch };
      elementHost1.Child = wpfDiagram1;
      ShowView += OnShowView;      
    }

    private void Analyse(bool highlight)
    {
      Processing.Invoke(
        Resources.SucheFundstellen,
        () =>
        {
          _vm.LayerQueryPhrase = wordBag1.ResultQueries;
          _vm.LayerDisplayname = wordBag1.ResultSelectedLayerDisplayname;
          _vm.HighlightCooccurrences = highlight;
          _vm.Execute();

          wpfDiagram1.CallNew();
          BuildTree();
        });
    }

    private void btn_export_gexf_Click(object sender, EventArgs e)
    {
      Export(new GexfXmlGraphConverter(), Resources.GEXFXMLDokumentGexfGexf);
    }

    private void btn_export_graphviz_Click(object sender, EventArgs e)
    {
      Export(new GraphVizGraphConverter(), Resources.GraphVizDokumentGvGv);
    }

    private void btn_start_cooccurrence_Click(object sender, EventArgs e)
    {
      Analyse(true);
    }

    private void wordBag1_ExecuteButtonClicked(object sender, EventArgs e)
    {
      Analyse(false);
    }

    private void BuildTree()
    {
      Processing.Invoke("Setze Struktur zusammen...",
        () =>
        {
          elementHost1.SuspendLayout();

          wpfDiagram1.CallNew();
          var pre = _vm.BranchPre.RecursiveNodes().ToArray();
          wpfDiagram1.CallAddNodes(pre);
          wpfDiagram1.CallColorizeNodes(pre, new UniversalColor(180, 200, 255));

          var post = _vm.BranchPost.RecursiveNodes().ToArray();
          wpfDiagram1.CallAddNodes(post);
          wpfDiagram1.CallColorizeNodes(post, new UniversalColor(180, 200, 255));

          wpfDiagram1.CallColorizeNodes(new[] { string.Join(" ", _vm.LayerQueryPhrase) }, new UniversalColor(180, 255, 200));

          wpfDiagram1.CallAddConnections(_vm.BranchPre.RecursiveConnections(false));
          wpfDiagram1.CallAddConnections(_vm.BranchPost.RecursiveConnections(true));

          wpfDiagram1.CallConnectionRendering();

          wpfDiagram1.CallLayoutAsTree();
          elementHost1.ResumeLayout(false);
        });
    }

    private void commandBarButton1_Click(object sender, EventArgs e)
    {
      if (
        MessageBox.Show(
          Resources.MöchtenSieWirklichDasDiagrammLöschenUndNeuBeginnen,
          Resources.NeuStarten,
          MessageBoxButton.YesNo,
          MessageBoxImage.Question) != MessageBoxResult.Yes)
        return;

      wpfDiagram1.CallNew();
    }

    private void commandBarButton2_Click(object sender, EventArgs e)
    {
      var sfd = new SaveFileDialog { Filter = Resources.FileExtension_CEDG, CheckPathExists = true };
      if (sfd.ShowDialog() != DialogResult.OK)
        return;

      wpfDiagram1.CallSave(sfd.FileName);
    }

    private void commandBarButton3_Click(object sender, EventArgs e)
    {
      var ofd = new OpenFileDialog { Filter = Resources.FileExtension_CEDG, CheckFileExists = true };
      if (ofd.ShowDialog() != DialogResult.OK)
        return;

      wpfDiagram1.CallLoad(ofd.FileName);
    }

    private void Export(AbstractGraphConverter type, string filter)
    {
      var sfd = new SaveFileDialog { Filter = filter, CheckPathExists = true };
      if (sfd.ShowDialog() != DialogResult.OK)
        return;
      FileIO.Write(sfd.FileName, wpfDiagram1.CallExport(type), Configuration.Encoding);
    }

    private void OnShowView(object sender, EventArgs eventArgs)
    {
      _vm = GetViewModel<TextFlowSearchViewModel>();
    }

    private void commandBarDropDownButton2_Click(object sender, EventArgs e)
    {

    }

    private void btn_layout_net_Click(object sender, EventArgs e)
    {
      wpfDiagram1.CallLayoutAsTreeRadial();
    }

    private void btn_layout_tree_Click(object sender, EventArgs e)
    {
      wpfDiagram1.CallLayoutAsTree();
    }
  }
}