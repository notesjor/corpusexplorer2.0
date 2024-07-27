#region

using System;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using Bcs.IO;
using CorpusExplorer.Sdk.Blocks.Flow;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Utils.Filter.Queries;
using CorpusExplorer.Sdk.ViewModel;
using CorpusExplorer.Terminal.WinForm.Controls.Wpf.Diagram;
using CorpusExplorer.Terminal.WinForm.Controls.Wpf.Diagram.Converter;
using CorpusExplorer.Terminal.WinForm.Controls.Wpf.Diagram.Converter.Abstract;
using CorpusExplorer.Terminal.WinForm.Forms.Splash;
using CorpusExplorer.Terminal.WinForm.Helper.UiFramework;
using CorpusExplorer.Terminal.WinForm.Properties;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.UI;
using HorizontalAlignment = System.Windows.HorizontalAlignment;
using MessageBox = System.Windows.MessageBox;

#endregion

namespace CorpusExplorer.Terminal.WinForm.View.Fulltext
{
  public partial class FulltextKwicTree : AbstractView
  {
    private readonly WpfDiagram wpfDiagram1;

    private RadCheckBox chk_range = new RadCheckBox
    {
      Checked = true,
      Text = "Einschränken?"
    };

    public FulltextKwicTree()
    {
      InitializeComponent();
      wpfDiagram1 = new WpfDiagram
      { VerticalAlignment = VerticalAlignment.Stretch, HorizontalAlignment = HorizontalAlignment.Stretch };
      elementHost1.Child = wpfDiagram1;
      ShowView += OnShowView;

      var root = chk_range.RootElement.Children[0].Children[1].Children[0].Children[0] as TextPrimitive;
      root.Font = new System.Drawing.Font(lbl_post.Font.FontFamily, lbl_post.Font.Size);

      host_range.Padding = new Padding(0, 3, 0, 0);
      host_range.Size = new System.Drawing.Size(chk_range.Size.Width + 5, chk_range.Size.Height + 5);

      host_range.HostedControl = chk_range;
      chk_range.CheckStateChanged += Chk_range_CheckStateChanged;
    }

    private void Chk_range_CheckStateChanged(object sender, EventArgs e)
    {
      lbl_post.Visibility =
        lbl_pre.Visibility =
          txt_post.Visibility =
            txt_pre.Visibility =
              chk_range.Checked
                ? Telerik.WinControls.ElementVisibility.Visible
                : Telerik.WinControls.ElementVisibility.Collapsed;
    }

    private void Analyse(bool highlight)
    {
      Processing.Invoke(
                        Resources.SucheFundstellen,
                        () =>
                        {
                          wpfDiagram1.CallNew();

                          if (chk_range.Checked)
                          {
                            var vm = GetViewModel<TextFlowSearchWithRangeSelectionViewModel>();
                            vm.LayerQueryPhrase = wordBag1.ResultQueries;
                            vm.Layer1Displayname = wordBag1.ResultSelectedLayerDisplayname;
                            vm.MinFrequency = int.Parse(txt_minFreq.Text);
                            vm.Layer2Displayname = "Wort";
                            vm.HighlightCooccurrences = highlight;

                            vm.Pre = int.Parse(txt_pre.Text);
                            vm.Post = int.Parse(txt_post.Text);

                            vm.Execute();
                            BuildTree(vm.BranchPre, vm.BranchPost, string.Join(" ", vm.LayerQueryPhrase));
                          }
                          else
                          {
                            var vm = GetViewModel<TextFlowSearchViewModel>();
                            vm.LayerQuery = new FilterQuerySingleLayerExactPhrase
                            {
                              LayerDisplayname = wordBag1.ResultSelectedLayerDisplayname,
                              LayerQueries = wordBag1.ResultQueries
                            };
                            vm.MinFrequency = int.Parse(txt_minFreq.Text);
                            vm.LayerDisplayname = "Wort";
                            vm.HighlightCooccurrences = highlight;

                            vm.Execute();
                            BuildTree(vm.BranchPre, vm.BranchPost, string.Join(" ", vm.LayerQueryPhrase));
                          }
                        });
    }

    private void btn_export_graphml_Click(object sender, EventArgs e)
    {
      Export(new GraphMlConverter(), Resources.FileExtension_GraphML);
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

    private void btn_start_cooccurrence_Click(object sender, EventArgs e)
    {
      Analyse(true);
    }

    private void wordBag1_ExecuteButtonClicked(object sender, EventArgs e)
    {
      Analyse(false);
    }

    private void BuildTree(FlowNode nodePre, FlowNode nodePost, string label)
    {
      Processing.Invoke("Setze Struktur zusammen...",
                        () =>
                        {
                          elementHost1.SuspendLayout();

                          var pre = nodePre.RecursiveNodes().ToArray();
                          wpfDiagram1.CallAddNodes(pre);
                          wpfDiagram1.CallColorizeNodes(pre, new UniversalColor(180, 200, 255));

                          var post = nodePost.RecursiveNodes().ToArray();
                          wpfDiagram1.CallAddNodes(post);
                          wpfDiagram1.CallColorizeNodes(post, new UniversalColor(180, 200, 255));

                          wpfDiagram1.CallColorizeNodes(new[] { label },
                                                        new UniversalColor(180, 255, 200));

                          wpfDiagram1.CallAddConnections(nodePre.RecursiveConnections(false));
                          wpfDiagram1.CallAddConnections(nodePost.RecursiveConnections(true));

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