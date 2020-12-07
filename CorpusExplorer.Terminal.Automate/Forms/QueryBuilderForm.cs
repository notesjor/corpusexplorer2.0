using System;
using System.Linq;
using CorpusExplorer.Terminal.Console.Xml.Model;
using Telerik.WinControls.UI;

namespace CorpusExplorer.Terminal.Automate
{
  public partial class QueryBuilderForm : AbstractForm
  {
    public QueryBuilderForm(string[] parentQueries, object query = null)
    {
      InitializeComponent();
      pages_options.SelectedPage = page_meta;
      query_drop_parent.Items.AddRange(parentQueries);
    }

    public object Result => _resultBuild;

    private delegate string LiveQueryPreviewDelegate();

    private LiveQueryPreviewDelegate _liveQueryPreview;

    private delegate object ResultBuildDelegate();

    private ResultBuildDelegate _resultBuild;

    private void pages_options_SelectedPageChanged(object sender, EventArgs e)
    {
      if (pages_options.SelectedPage == page_meta)
      {
        query_check_invert.Visible = true;
        _liveQueryPreview = Preview_Meta;
        _resultBuild = Build_Meta;
      }
      else if (pages_options.SelectedPage == page_fulltext)
      {
        query_check_invert.Visible = true;
        _liveQueryPreview = Preview_Fulltext;
        _resultBuild = Build_Fulltext;
      }
      else if (pages_options.SelectedPage == page_random)
      {
        query_check_invert.Visible = false;
        _liveQueryPreview = Preview_Random;
        _resultBuild = Build_Random;
      }
      else if (pages_options.SelectedPage == page_autosplit)
      {
        query_check_invert.Visible = false;
        _liveQueryPreview = Preview_Autosplit;
        _resultBuild = Build_Autosplit;
      }
      else if (pages_options.SelectedPage == page_listBuilder)
      {
        query_check_invert.Visible = false;
        _liveQueryPreview = Preview_ListBuilder;
        _resultBuild = Build_ListBuilder;
        RefreshLivePreview();
      }
      else if (pages_options.SelectedPage == page_group)
      {
        query_check_invert.Visible = false;
        _liveQueryPreview = Preview_Group;
        _resultBuild = Build_Group;
        RefreshLivePreview();
      }
    }

    #region Preview
    private string Preview_Meta()
      => $"{(query_check_invert.Checked ? "!" : "")}M{GetOperator(meta_drop_operator)}{meta_txt_label.Text}::{meta_txt_value.Text}";

    private string Preview_Fulltext()
      => $"{(query_check_invert.Checked ? "!" : "")}T{GetOperator(fulltext_drop_operator)}{fulltext_txt_layer.Text}::{fulltext_txt_values.Text}";

    private string Preview_Random()
      => $"XR::{random_txt_value.Text}";

    private string Preview_Autosplit()
      => autoSplit1.Result;

    private string Preview_ListBuilder()
    {
      return "<queryBuilder> ... </queryBuilder>";
    }

    private string Preview_Group()
    {
      return "<queryGroup> ... </queryGroup>";
    }
    #endregion

    #region Build
    private object Build_Meta()
      => new query
      {
        name = query_txt_name.Text,
        parent = query_drop_parent.SelectedIndex == -1 ? null : query_drop_parent.SelectedItem.Text,
        Text = new[] { Preview_Meta() }
      };

    private object Build_Fulltext()
      => new query
      {
        name = query_txt_name.Text,
        parent = query_drop_parent.SelectedIndex == -1 ? null : query_drop_parent.SelectedItem.Text,
        Text = new[] { Preview_Fulltext() }
      };

    private object Build_Random()
      => new query
      {
        name = query_txt_name.Text,
        parent = query_drop_parent.SelectedIndex == -1 ? null : query_drop_parent.SelectedItem.Text,
        Text = new[] { Preview_Random() }
      };

    private object Build_Autosplit()
      => autoSplit1.Result;

    private object Build_ListBuilder()
      => new queryBuilder
      {
        name = query_txt_name.Text,
        parent = query_drop_parent.SelectedIndex == -1 ? null : query_drop_parent.SelectedItem.Text,
        prefix = list_txt_prefix.Text,
        value = list_grid_values.Rows.Select(x => x.Cells[0].Value.ToString()).ToArray()
      };

    private object Build_Group()
      => new queryGroup
      {
        name = query_txt_name.Text,
        parent = query_drop_parent.SelectedIndex == -1 ? null : query_drop_parent.SelectedItem.Text,
        prefix = group_txt_prefix.Text,
        @operator = group_drop_operator.SelectedItem.Text,
        query = group_grid_queries.Rows.Select(x => new query { Text = new[]{ x.Cells[0].Value.ToString() } }).ToArray()
      };
    #endregion

    private void RefreshLivePreview()
    {
      txt_livePreview.Text = _liveQueryPreview();
    }

    private string GetOperator(RadDropDownList drop)
    {
      if (drop.SelectedIndex == -1)
        return null;

      var txt = drop.SelectedItem.Text;
      var f = txt.IndexOf("=");
      return txt.Substring(0, f - 1).Trim();
    }

    private void refreshlive_textbox(object sender, EventArgs e)
    {
      RefreshLivePreview();
    }

    private void refreshlive_dropdown(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
    {
      RefreshLivePreview();
    }

    private void refreshlive_autosplit(object sender, EventArgs e)
    {
      RefreshLivePreview();
    }
  }
}
