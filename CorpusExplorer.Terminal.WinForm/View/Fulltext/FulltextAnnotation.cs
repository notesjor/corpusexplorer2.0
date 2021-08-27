#region

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.ViewModel;
using CorpusExplorer.Terminal.WinForm.Forms.Simple;
using CorpusExplorer.Terminal.WinForm.Helper;
using CorpusExplorer.Terminal.WinForm.Helper.UiFramework;
using CorpusExplorer.Terminal.WinForm.Properties;
using Telerik.WinControls.UI;
using PositionChangedEventArgs = Telerik.WinControls.UI.Data.PositionChangedEventArgs;

#endregion

namespace CorpusExplorer.Terminal.WinForm.View.Fulltext
{
  /// <summary>
  ///   The annotation page.
  /// </summary>
  public partial class FulltextAnnotation : AbstractView
  {
    private readonly List<RadTreeNode> _coloredNodes = new List<RadTreeNode>();
    private readonly Color[] _colors;
    private RadTreeNode _annotationNode;
    private AnnotationViewModel _vmAnnotation;

    /// <summary>
    ///   Initializes a new instance of the <see cref="AbstractView" /> class.
    /// </summary>
    public FulltextAnnotation()
    {
      InitializeComponent();

      ShowView += ShowViewCall;

      _colors = UniversalColorExtension.ToWinFormColor(UniversalColor.Palette);

      tagger1.TaggerItemSelected += Tagger1OnTaggerItemSelected;
    }

    private void btn_clipboard_Click(object sender, EventArgs e)
    {
      Clipboard.SetText(_vmAnnotation.GetDocument().ReduceDocumentToText());
    }

    private void btn_export_Click(object sender, EventArgs e)
    {
      var dic = Configuration.AddonExporters.ToArray();
      var sfd = new SaveFileDialog
      {
        CheckPathExists = true,
        Filter = string.Join("|", dic.Select(x => x.Key))
      };
      if (sfd.ShowDialog() != DialogResult.OK)
        return;

      var exporter = dic[sfd.FilterIndex - 1].Value;
      var snapshot = _vmAnnotation.SelectDocumentAsSelection();
      exporter.Export(snapshot, sfd.FileName);
    }

    private void btn_layer_addValue_Click(object sender, EventArgs e)
    {
      var node = tree.SelectedNode;
      if (node == null ||
          node.Parent != null)
        return; // muss != null sein um zu überprüfen ob es sich um den Layernode handelt

      var form = new SimpleTextInput(
                                     Resources.FulltextAnnotation_NewLayerValue,
                                     Resources.FulltextAnnotation_NewLayerValueDescription,
                                     Resources.layers1,
                                     Resources.FulltextAnnotation_NewLayerValueNullText);
      if (form.ShowDialog() != DialogResult.OK)
        return;

      _vmAnnotation.NewLayerValue(node.Text, form.Result);
      RefreshAll();
    }

    private void btn_layer_export_Click(object sender, EventArgs e)
    {
      var node = tree.SelectedNode;
      if (node == null ||
          node.Parent != null)
        return; // muss != null sein um zu überprüfen ob es sich um den Layernode handelt

      _vmAnnotation.ExportLayer(node.Text);
    }

    private void btn_layer_import_Click(object sender, EventArgs e)
    {
      var node = tree.SelectedNode;
      if (node == null ||
          node.Parent != null)
        return; // muss != null sein um zu überprüfen ob es sich um den Layernode handelt
    }

    private void btn_layer_new_Click(object sender, EventArgs e)
    {
      var form = new SimpleTextInput(
                                     Resources.FulltextAnnotation_NewLayer,
                                     Resources.FulltextAnnotation_NewLayerDescription,
                                     Resources.layers1,
                                     Resources.FulltextAnnotation_NewLayerNullText);
      if (form.ShowDialog() != DialogResult.OK)
        return;

      _vmAnnotation.NewLayer(form.Result);
      RefreshAll();
    }

    private void btn_layer_remove_Click(object sender, EventArgs e)
    {
      var node = tree.SelectedNode;
      if (node == null ||
          node.Parent != null)
        return; // muss != null sein um zu überprüfen ob es sich um den Layernode handelt

      if (
        MessageBox.Show(
                        string.Format(
                                      Resources.FulltextAnnotation_DeleteLayer,
                                      node.Text),
                        Resources.FulltextAnnotation_DeleteLayerHead,
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning) != DialogResult.Yes)
        return;

      _vmAnnotation.DeleteLayer(node.Text);
      RefreshAll();
    }

    private void btn_layer_rename_Click(object sender, EventArgs e)
    {
      var node = tree.SelectedNode;
      if (node == null ||
          node.Parent != null)
        return; // muss != null sein um zu überprüfen ob es sich um den Layernode handelt

      if (node.Text == "Wort" ||
          node.Text == "Lemma" ||
          node.Text == "POS")
        MessageBox.Show(
                        Resources.FulltextAnnotation_RenameLayer,
                        Resources.FulltextAnnotation_RenameLayerHead,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

      var form = new SimpleTextInput(
                                     Resources.FulltextAnnotation_RenameLayer_Head,
                                     Resources.FulltextAnnotation_RenameLayer_Description,
                                     Resources.layers1,
                                     node.Text
                                    );
      if (form.ShowDialog() != DialogResult.OK)
        return;

      _vmAnnotation.RenameLayer(node.Text, form.Result);
      RefreshAll();
    }

    private void btn_layervalue_remove_Click(object sender, EventArgs e)
    {
      var node = tree.SelectedNode;
      if (node?.Parent == null)
        return;

      if (
        MessageBox.Show(
                        string.Format(
                                      Resources.FulltextAnnotation_DeleteLayerValue,
                                      node.Text),
                        Resources.FulltextAnnotation_DeleteLayerValueHead,
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning) != DialogResult.Yes)
        return;

      _vmAnnotation.DeleteLayerValue(node.Parent.Text, node.Text);
      RefreshAll();
    }

    private void btn_layervalue_rename_Click(object sender, EventArgs e)
    {
      var node = tree.SelectedNode;
      if (node?.Parent == null)
        return;

      var form = new SimpleTextInput(
                                     Resources.FulltextAnnotation_DeleteLayerValue_ChangeLayerValue,
                                     Resources.FulltextAnnotation_DeleteLayerValue_ChangeLayerValueDescription,
                                     Resources.layers1,
                                     node.Text
                                    );
      if (form.ShowDialog() != DialogResult.OK)
        return;

      _vmAnnotation.RenameLayerValue(node.Parent.Text, node.Text, form.Result);
      RefreshAll();
    }

    private void btn_showMeta_Click(object sender, EventArgs e)
    {
      var form = new SimpleMetadata(_vmAnnotation.DocumentMetadata);
      form.NewProperty += (o, a) => { _vmAnnotation.SetNewDocumentMetadata((KeyValuePair<string, Type>)o); };

      if (form.ShowDialog() == DialogResult.OK)
        _vmAnnotation.DocumentMetadata = form.DocumentMetadata;
    }

    private void ColorizeNodes()
    {
      tagger1.ClearLayout();

      // _coloredNodes kann _colors nicht überschreiten, dies wird in tree_NodeCheckedChanged sichergestellt
      for (var i = 0; i < _coloredNodes.Count; i++)
      {
        var c = _colors[i];
        _coloredNodes[i].BackColor = c;
        tagger1.SetItemColor(
                             _vmAnnotation.GetLayerValueMask((Guid)_coloredNodes[i].Parent.Tag, _coloredNodes[i].Text),
                             System.Windows.Media.Color.FromArgb(c.A, c.R, c.G, c.B), _coloredNodes[i].Text);
      }
    }

    /// <summary>
    ///   The drop_selecteddocument_ selected index changed.
    /// </summary>
    /// <param name="sender">
    ///   The sender.
    /// </param>
    /// <param name="e">
    ///   The e.
    /// </param>
    private void drop_selecteddocument_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
    {
      if (e == null)
        return;
      _coloredNodes.Clear();
      RefreshAll();
    }

    private void RefreshAll()
    {
      var index = drop_selecteddocument.SelectedIndex;

      // Überprüfe
      if (index == -1)
        return;

      // Wähle Dokument im ViewModel aus
      _vmAnnotation.SelectDocument((Guid)drop_selecteddocument.Items[index].Value);

      // Setze Text
      tagger1.Text = _vmAnnotation.GetDocument();
      tree.Nodes.Clear();

      // Erstelle Layer - Nodes
      var nodes = new List<RadTreeNode>();
      foreach (var layer in _vmAnnotation.Layers.OrderBy(x => x.Value))
      {
        var node = new RadTreeNode(layer.Value) { CheckType = CheckType.None, Tag = layer.Key, ContextMenu = menu_layer };
        foreach (var sub in _vmAnnotation.GetLayerValues(layer.Key).OrderBy(x => x))
          node.Nodes.Add(
                         new RadTreeNode(sub)
                         {
                           CheckType = CheckType.CheckBox,
                           Checked = false,
                           ContextMenu = menu_layervalue
                         });

        nodes.Add(node);
      }

      tree.Nodes.AddRange(nodes);
    }

    private void SetAnnotationNode(RadTreeNode node)
    {
      if (node == null)
        return;

      if (_annotationNode != null)
        SetNodeHighlight(_annotationNode, false);

      _annotationNode = node;
      SetNodeHighlight(_annotationNode, true);
    }

    private void SetNodeHighlight(RadTreeNode node, bool isBold, Color? color = null)
    {
      if (color.HasValue)
        node.BackColor = color.Value;
      var font = node.Font ?? tree.Font;
      node.Font = new Font(font.FontFamily, font.Size, isBold ? FontStyle.Bold : FontStyle.Regular);
    }

    private void ShowViewCall(object sender, EventArgs e)
    {
      _vmAnnotation = GetViewModel<AnnotationViewModel>();
      _vmAnnotation.Execute();
      DictionaryBindingHelper.BindDictionary(_vmAnnotation.Documents, drop_selecteddocument);
      if (_vmAnnotation.Documents.Count > 0)
        drop_selecteddocument.SelectedIndex = 0;
    }

    private void Tagger1OnTaggerItemSelected(int satz, int wort, bool selected)
    {
      _vmAnnotation.SetLayerValueMask(satz, wort);
      ColorizeNodes();
    }

    private void tree_NodeCheckedChanged(object sender, TreeNodeCheckedEventArgs e)
    {
      if (e.Node.Checked)
      {
        if (_coloredNodes.Count + 1 >= _colors.Length)
        {
          MessageBox.Show(
                          string.Format(
                                        Resources.FulltextAnnotation_MaxHighlightLimmit,
                                        _colors.Length),
                          Resources.FulltextAnnotation_MaxHighlightLimmitHead,
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Information);
          return;
        }

        SetAnnotationNode(e.Node);
        _coloredNodes.Add(e.Node);
      }
      else
      {
        if (_coloredNodes.Contains(e.Node))
          _coloredNodes.Remove(e.Node);

        if (_coloredNodes.Count > 0 &&
            _annotationNode == e.Node)
          SetAnnotationNode(_coloredNodes.Last());

        SetNodeHighlight(e.Node, false, Color.White);
      }

      ColorizeNodes();
    }

    private void txt_layer_query_TextChanged(object sender, EventArgs e)
    {
      tree.Filter = txt_layer_query.Text;
    }
  }
}