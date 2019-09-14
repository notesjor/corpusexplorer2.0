#region

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Forms;
using Bcs.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.ViewModel;
using CorpusExplorer.Terminal.WinForm.Controls.Wpf.Diagram;
using CorpusExplorer.Terminal.WinForm.Controls.Wpf.Diagram.Converter;
using CorpusExplorer.Terminal.WinForm.Controls.Wpf.Diagram.Converter.Abstract;
using CorpusExplorer.Terminal.WinForm.Forms.SelectLayer;
using CorpusExplorer.Terminal.WinForm.Forms.Splash;
using CorpusExplorer.Terminal.WinForm.Helper.UiFramework;
using CorpusExplorer.Terminal.WinForm.Properties;
using HorizontalAlignment = System.Windows.HorizontalAlignment;
using MessageBox = System.Windows.MessageBox;

#endregion

namespace CorpusExplorer.Terminal.WinForm.View.Ngram
{
  /// <summary>
  ///   The grid visualisation.
  /// </summary>
  public partial class NGramDiagram : AbstractView
  {
    private NgramChainViewModel _vm;
    private readonly WpfDiagram simpleDiagram1;

    /// <summary>
    ///   Initializes a new instance of the <see cref="AbstractView" /> class.
    /// </summary>
    public NGramDiagram()
    {
      InitializeComponent();
      simpleDiagram1 = new WpfDiagram
        {VerticalAlignment = VerticalAlignment.Stretch, HorizontalAlignment = HorizontalAlignment.Stretch};
      elementHost1.Child = simpleDiagram1;

      ShowView += (sender, args) => { _vm = GetViewModel<NgramChainViewModel>(); };
    }

    private void Analyse()
    {
      _vm.NGramSize = int.Parse(txt_size.Text);
      _vm.NGramPatternSize = int.Parse(txt_pattern.Text);
      if (SelectedLayerDisplaynames != null)
        _vm.LayerDisplayname = SelectedLayerDisplaynames[0];
      if (!_vm.Execute())
        return;
      var temp = _vm.TakeTopNGrams(int.Parse(txt_max.Text));
      var nodes = new Dictionary<string, NodeInfo>();
      var conns = new Dictionary<string, Dictionary<string, double>>();

      foreach (var x in temp)
        for (var i = 0; i < x.Key.Length; i++)
        {
          // Stelle sicher, dass Knoten exsistiert
          if (!nodes.ContainsKey(x.Key[i]))
            nodes.Add(x.Key[i], new NodeInfo());

          // Baue Knoten-Info
          var ni = nodes[x.Key[i]];
          if (i == 0)
            ni.Start = true;
          else if (i + 1 == x.Key.Length)
            ni.End = true;
          else
            ni.Between = true;
          nodes[x.Key[i]] = ni;

          // Wenn nicht letzter Knoten...
          if (i + 1 == x.Key.Length)
            continue;

          // ... dann baue Verbindung
          if (conns.ContainsKey(x.Key[i]))
          {
            if (conns[x.Key[i]].ContainsKey(x.Key[i + 1]))
              conns[x.Key[i]][x.Key[i + 1]] += x.Value;
            else
              conns[x.Key[i]].Add(x.Key[i + 1], x.Value);
          }
          else
          {
            conns.Add(x.Key[i], new Dictionary<string, double> {{x.Key[i + 1], x.Value}});
          }
        }

      simpleDiagram1.CallNew();
      simpleDiagram1.CallAddNodes(nodes.Keys);
      foreach (var n in nodes)
        simpleDiagram1.CallColorizeNode(n.Key,
                                        n.Value.Start ? new UniversalColor(150, 255, 180) : null,
                                        n.Value.Between ? new UniversalColor(150, 180, 255) : null,
                                        n.Value.End ? new UniversalColor(255, 150, 150) : null);

      var cs = new List<Tuple<string, string, double>>();
      foreach (var c in conns)
      foreach (var d in c.Value)
        cs.Add(new Tuple<string, string, double>(c.Key, d.Key, d.Value));
      simpleDiagram1.CallAddConnections(cs);
      simpleDiagram1.CallConnectionRendering();
      simpleDiagram1.CallLayoutAsTree();
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

    private void commandBarButton1_Click(object sender, EventArgs e)
    {
      Processing.Invoke(Resources.ErstelleUndZähleNGramme, Analyse);
    }

    private void commandBarButton2_Click(object sender, EventArgs e)
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

    private void commandBarButton4_Click(object sender, EventArgs e)
    {
      var ofd = new OpenFileDialog {Filter = Resources.FileExtension_CEDG, CheckFileExists = true};
      if (ofd.ShowDialog() != DialogResult.OK)
        return;

      simpleDiagram1.CallLoad(ofd.FileName);
    }

    private void Export(AbstractGraphConverter type, string filter)
    {
      var sfd = new SaveFileDialog {Filter = filter, CheckPathExists = true};
      if (sfd.ShowDialog() != DialogResult.OK)
        return;
      FileIO.Write(sfd.FileName, simpleDiagram1.CallExport(type), Configuration.Encoding);
    }

    private void btn_layer_Click(object sender, EventArgs e)
    {
      var form = new Select1Layer(SelectedLayerDisplaynames);
      form.ShowDialog();
      SelectedLayerDisplaynames = form.ResultSelectedLayerDisplaynames;
      Analyse();
    }

    private struct NodeInfo
    {
      public bool Start;
      public bool Between;
      public bool End;
    }
  }
}