#region

using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Utils.Filter.Queries;
using CorpusExplorer.Sdk.ViewModel;
using CorpusExplorer.Terminal.WinForm.Controls.Wpf.Kwic;
using CorpusExplorer.Terminal.WinForm.Forms.Simple;
using CorpusExplorer.Terminal.WinForm.Forms.Splash;
using CorpusExplorer.Terminal.WinForm.Helper.UiFramework;
using CorpusExplorer.Terminal.WinForm.Properties;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.Enumerations;
using Telerik.WinControls.UI;
using PositionChangedEventArgs = Telerik.WinControls.UI.Data.PositionChangedEventArgs;

#endregion

namespace CorpusExplorer.Terminal.WinForm.View.Fulltext
{
  public partial class FulltextKwicSearch : AbstractView
  {
    private readonly KwicView kwicView1;

    public FulltextKwicSearch()
    {
      InitializeComponent();

      kwicView1 = new KwicView();
      elementHost1.Child = kwicView1;

      ShowView += (sender, args) =>
      {
        cmb_layer.DataSource = Project.CurrentSelection.LayerUniqueDisplaynames;
        cmb_layer.SelectedIndex = 0;
      };
    }

    private void Analyse()
    {
      kwicView1.DataSource = new KeyValuePair<string[], int>[0];
      if ((txt_query.Items == null) ||
          (txt_query.Items.Count == 0) ||
          (cmb_layer.SelectedIndex == -1))
        return;

      var vm = ViewModelGet<TextLiveSearchViewModel>();
      vm.AddQuery(
        new FilterQuerySingleLayerAnyMatch
        {
          Inverse = false,
          LayerDisplayname = cmb_layer.Items[cmb_layer.SelectedIndex].Text,
          LayerQueries = txt_query.Items.Select(x => x.Text)
        });
      vm.Analyse();

      // Sinle Results
      tree.Nodes.Clear();
      var list = new ConcurrentBag<RadTreeNode>();
      Parallel.ForEach(
        vm.SearchResults,
        csel => Parallel.ForEach(
          csel.Value,
          dsel =>
          {
            var title = vm.GetDocumentDisplayname(dsel.Key);
            var dn = new RadTreeNode(title);

            foreach (var sentence in dsel.Value)
              foreach (var w in sentence.Value)
                dn.Nodes.Add(
                    new RadTreeNode(
                      string.Format(
                        Resources.FundstelleSatz0Wort1,
                        sentence.Key,
                        w))
                    {
                      Value =
                        new Tuple
                        <Guid, int,
                          int>(
                          dsel.Key,
                          sentence.Key,
                          w),
                      CheckType =
                        CheckType
                          .CheckBox,
                      Checked = false
                    });
            if (dn.Nodes.Count > 0)
              list.Add(dn);
          }));
      tree.Nodes.AddRange(list);
      tree.ExpandAll();
    }

    private void btn_select_all_Click(object sender, EventArgs e)
    {
      Processing.Invoke(
        Resources.WähleAlleFundstellen,
        () =>
        {
          foreach (
            var node in
            tree.Nodes.SelectMany(parentNodes => parentNodes.Nodes))
            node.CheckState = ToggleState.On;
        });
    }

    private void btn_select_invert_Click(object sender, EventArgs e)
    {
      Processing.Invoke(
        Resources.KehreAuswahlUm,
        () =>
        {
          foreach (
            var node in
            tree.Nodes.SelectMany(parentNodes => parentNodes.Nodes))
            node.CheckState = node.CheckState == ToggleState.Off
                                ? ToggleState.On
                                : ToggleState.Off;
        });
    }

    private void btn_select_none_Click(object sender, EventArgs e)
    {
      foreach (var node in tree.Nodes.SelectMany(parentNodes => parentNodes.Nodes))
        node.CheckState = ToggleState.Off;
    }

    private void btn_snapshot_make_Click(object sender, EventArgs e)
    {
      var form = new SimpleTextInput(
        Resources.NeuerSchnappschuss,
        Resources.GebenSieDemNeuenSchnappschussEinenNamen,
        Resources.camera,
        Resources.NameHierEintragen);
      if (form.ShowDialog() != DialogResult.OK) return;

      var dic = new HashSet<Guid>();

      foreach (var parentNode in tree.Nodes)
      {
        foreach (var node in parentNode.Nodes)
        {
          if (node == null || node.CheckState != ToggleState.On || !(node.Value is Tuple<Guid, int, int>))
            continue;

          var guid = ((Tuple<Guid, int, int>)node.Value).Item1;
          if (guid != Guid.Empty)
            dic.Add(guid);
        }
      }

      Project.CreateSelection(dic, form.Result);
    }

    private void cmb_layer_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
    {
      if (e.Position == -1)
        return;

      txt_query.Text = null;

      txt_query.AutoCompleteDataSource = Project.CurrentSelection.GetLayerValues(cmb_layer.Items[e.Position].Text);
    }

    private void radButton1_Click(object sender, EventArgs e)
    {
      Processing.Invoke(Resources.SucheFundstellen, Analyse);
    }

    private void tree_NodeCheckedChanged(object sender, TreeNodeCheckedEventArgs e)
    {
      var vm = ViewModelGet<TextLiveSearchViewModel>();
      var results = new List<Tuple<Guid, int, int>>();
      var queue = new Queue<RadTreeNode>(tree.Nodes);

      while (queue.Count > 0)
      {
        var node = queue.Dequeue();
        if (node.Nodes.Count > 0)
        {
          foreach (var n in node.Nodes)
            queue.Enqueue(n);
        }
        else
        {
          if (node.Checked)
            results.Add(node.Value as Tuple<Guid, int, int>);
        }
      }

      kwicView1.DataSource =
        results.Select(
          r =>
            new KeyValuePair<string[], int>(
              vm.GetReadableDocumentSnippet(
                  r.Item1,
                  "Wort",
                  r.Item2,
                  r.Item2).ReduceDocumentToStreamDocument()
                .ToArray(),
              r.Item3));
    }
  }
}